using System;
using System.Linq;
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

        // Average 方法接受一個 int 陣列參數，及實際讀入的 count
        // 並回傳該陣列前 count 個值的平均值（四捨五入到小數點第一位）。
        private double Average(int[] scores, int count)
        {
            if (scores == null || count <= 0)
            {
                return 0.0;
            }

            double total = 0;
            for (int i = 0; i < count; i++)
            {
                total += scores[i];
            }

            double avg = total / count;
            return Math.Round(avg, 1, MidpointRounding.AwayFromZero);
        }

        // Highest 方法接受一個 int 陣列參數與實際數量 count
        // 並回傳該陣列前 count 個值中的最大值。
        private int Highest(int[] scores, int count)
        {
            if (scores == null || count <= 0)
            {
                return 0;
            }

            int highest = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }

        // Lowest 方法接受一個 int 陣列參數與實際數量 count
        // 並回傳該陣列前 count 個值中的最小值。
        private int Lowest(int[] scores, int count)
        {
            if (scores == null || count <= 0)
            {
                return 0;
            }

            int lowest = int.MaxValue;
            for (int i = 0; i < count; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }
            return lowest;
        }

        // 嘗試尋找常見的 scores.txt 路徑（執行目錄、應用程式目錄、專案上層）
        private string LocateScoresFile(string fileName = "scores.txt")
        {
            var candidates = new[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName),               // exe 目錄
                Path.Combine(Application.StartupPath, fileName),                           // WinForms 啟動目錄
                Path.Combine(Environment.CurrentDirectory, fileName),                       // 當前工作目錄
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", fileName)) // 專案根目錄（除錯時可能有用）
            };

            foreach (var path in candidates)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                    {
                        return path;
                    }
                }
                catch
                {
                    // 忽略無法檢查的候選路徑
                }
            }

            return null;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 60;
            int[] scores = new int[SIZE];
            int index = 0;

            try
            {
                string filePath = LocateScoresFile("scores.txt");

                // 若自動尋找不到，提示使用者選擇檔案
                if (string.IsNullOrEmpty(filePath))
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        ofd.Title = "請選擇成績檔案";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            filePath = ofd.FileName;
                        }
                    }
                }

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("找不到 scores.txt。請確認檔案存在或使用「讀取成績」時選擇正確檔案。", "檔案未找到", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (StreamReader inputFile = File.OpenText(filePath))
                {
                    while (!inputFile.EndOfStream && index < scores.Length)
                    {
                        string line = inputFile.ReadLine();
                        if (int.TryParse(line, out int value))
                        {
                            scores[index++] = value;
                        }
                        // 無法解析的行會被跳過
                    }
                }

                // 清除並加入實際讀入的項目
                testScoresListBox.Items.Clear();
                for (int i = 0; i < index; i++)
                {
                    testScoresListBox.Items.Add(scores[i]);
                }

                // 若至少讀入一筆資料，則更新顯示；否則清空顯示欄位
                if (index > 0)
                {
                    averageScoreLabel.Text = Average(scores, index).ToString("n1");
                    highScoreLabel.Text = Highest(scores, index).ToString();
                    lowScoreLabel.Text = Lowest(scores, index).ToString();
                }
                else
                {
                    averageScoreLabel.Text = string.Empty;
                    highScoreLabel.Text = string.Empty;
                    lowScoreLabel.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案發生錯誤: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}