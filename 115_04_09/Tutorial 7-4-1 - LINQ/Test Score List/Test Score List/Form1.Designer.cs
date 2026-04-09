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

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 讀取分數檔案，檔案每行格式為："學號 空白 分數"（例如：A114221055 54）
        /// - 解析每一行的學號與分數
        /// - 將分數加入傳入的 scoresList（作為 int）
        /// - 並在 ListBox 中加入呈現字串 "學號 分數"
        /// - 遇到空行或格式不符的行會略過；發生例外會以訊息視窗顯示錯誤（中文訊息）
        /// </summary>
        /// <param name="scoresList">用於儲存解析後的分數清單（不可為 null）</param>
        private void ReadScores(List<int> scoresList)
        {
            if (scoresList == null)
            {
                throw new ArgumentNullException(nameof(scoresList));
            }

            string filePath = "TestScores.txt";

            try
            {
                // 讀取前清空 ListBox 與 scoresList（避免重複累加）
                testScoresListBox.Items.Clear();
                scoresList.Clear();

                // 若檔案不存在，提早通知並結束
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"找不到檔案 '{filePath}'。", "檔案不存在", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 使用 File.ReadLines 逐行讀取，減少記憶體一次性載入的成本
                foreach (var rawLine in File.ReadLines(filePath))
                {
                    var line = rawLine?.Trim();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // 跳過空白或空行
                        continue;
                    }

                    // 以任意空白（支援多個空白或 tab）分割欄位
                    string[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                    // 期待至少有學號與分數兩個欄位
                    if (parts.Length < 2)
                    {
                        // 欄位不足（例如只有學號或只有分數），略過該列
                        continue;
                    }

                    // 將最後一個欄位視為分數，其餘合併為學號（以防學號不慎含空白）
                    string scoreText = parts[parts.Length - 1].Trim();
                    string studentId = parts.Length == 2
                        ? parts[0].Trim()
                        : string.Join(" ", parts.Take(parts.Length - 1)).Trim();

                    // 解析分數
                    if (!int.TryParse(scoreText, out int score))
                    {
                        // 分數欄位無法解析為整數，略過該列
                        continue;
                    }

                    // 成功解析：加入 scoresList，並在 ListBox 顯示 "學號 分數"
                    scoresList.Add(score);
                    testScoresListBox.Items.Add($"{studentId} {score}");
                }
            }
            catch (Exception ex)
            {
                // 顯示中文錯誤訊息，包含例外內容以利除錯
                MessageBox.Show("讀取成績時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 按下「讀取分數並計算」按鈕時呼叫：
        /// - 讀取檔案、填入 scoresList、更新 ListBox（ReadScores 已處理）
        /// - 計算平均、高於/低於平均人數並更新畫面
        /// </summary>
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            // 建立分數清單並呼叫 ReadScores 解析檔案
            List<int> scoresList = new List<int>();
            ReadScores(scoresList);

            // 若沒有任何分數，顯示提示並清除顯示欄位
            if (scoresList.Count == 0)
            {
                averageLabel.Text = string.Empty;
                aboveAverageLabel.Text = string.Empty;
                belowAverageLabel.Text = string.Empty;
                MessageBox.Show("未讀取到任何有效成績。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 計算並顯示平均（到小數點一位）
            double avg = Average(scoresList);
            averageLabel.Text = avg.ToString("n1");

            // 計算並顯示高於平均與低於平均的筆數
            int above = AboveAverage(scoresList, avg);
            int below = BelowAverage(scoresList, avg);
            aboveAverageLabel.Text = above.ToString();
            belowAverageLabel.Text = below.ToString();
        }

        /// <summary>
        /// 計算平均（處理空清單返回 0）
        /// </summary>
        private double Average(List<int> scores)
        {
            if (scores == null || scores.Count == 0)
            {
                return 0.0;
            }

            // 使用 long 以避免大量資料導致 overflow（雖然對測驗分數不太可能）
            long sum = 0;
            foreach (var s in scores)
            {
                sum += s;
            }
            return (double)sum / scores.Count;
        }

        /// <summary>
        /// 計算高於平均的數量（比較以 double avg）
        /// </summary>
        private int AboveAverage(List<int> scores, double avg)
        {
            int count = 0;
            foreach (var s in scores)
            {
                if (s > avg) count++;
            }
            return count;
        }

        /// <summary>
        /// 計算低於平均的數量（比較以 double avg）
        /// </summary>
        private int BelowAverage(List<int> scores, double avg)
        {
            int count = 0;
            foreach (var s in scores)
            {
                if (s < avg) count++;
            }
            return count;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }

}

