using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個 int 陣列參數
        // 並回傳該陣列值的平均值（四捨五入到小數點第一位）。
        private double Average(int[] scores)
        {
            if (scores == null || scores.Length == 0)
            {
                return 0.0;
            }

            double total = 0;
            foreach (int score in scores)
            {
                total += score;
            }

            double avg = total / scores.Length;
            // 使用 MidpointRounding.AwayFromZero 做一般人習慣的四捨五入
            return Math.Round(avg, 1, MidpointRounding.AwayFromZero);
        }

        // Highest 方法接受一個 int 陣列參數
        // 並回傳該陣列中的最大值。
        private int Highest(int[] scores)
        {
            int highest = int.MinValue;
            foreach (int score in scores)
            {
                if (score > highest)
                {
                    highest = score;
                }
            }
            return highest;
        }

        // Lowest 方法接受一個 int 陣列參數
        // 並回傳該陣列中的最小值。
        private int Lowest(int[] scores)
        {
            int lowest = int.MaxValue;
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;
            int[] scores = new int[SIZE];
            int index = 0;

            try
            {
                // 使用 using 確保檔案會被正確關閉
                using (StreamReader inputFile = File.OpenText("TestScores.txt"))
                {
                    // 修正條件為 index < scores.Length，並將讀到的值儲存到陣列
                    while (!inputFile.EndOfStream && index < scores.Length)
                    {
                        string line = inputFile.ReadLine();
                        if (int.TryParse(line, out int value))
                        {
                            scores[index] = value;
                            index++;
                        }
                        // 若遇到無法解析的行，則跳過該行
                    }
                }

                // 清除清單並僅加入實際讀入的項目（避免顯示預設的 0）
                testScoresListBox.Items.Clear();
                for (int i = 0; i < index; i++)
                {
                    testScoresListBox.Items.Add(scores[i]);
                }

                // 若至少讀入一筆資料，則更新最高/最低/平均顯示欄位
                if (index > 0)
                {
                    int[] actualScores = scores.Take(index).ToArray();
                    averageScoreLabel.Text = Average(actualScores).ToString("n1");
                    highScoreLabel.Text = Highest(actualScores).ToString();
                    lowScoreLabel.Text = Lowest(actualScores).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
