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

        // Average 方法使用 LINQ 查詢語法（query syntax）
        // 回傳前 count 個值的平均值（四捨五入到小數點第一位）。
        private double Average(double[] sArray, int count)
        {
            if (sArray == null || count <= 0)
            {
                return 0.0;
            }

            // 使用查詢語法排序並選取前 count 個值
            var query = from v in sArray.Take(count)
                        orderby v
                        select v;

            double avg = query.Any() ? query.Average() : 0.0;
            return Math.Round(avg, 1, MidpointRounding.AwayFromZero);
        }

        // Highest 使用 LINQ method syntax
        private double Highest(double[] sArray, int count)
        {
            if (sArray == null || count <= 0)
            {
                return 0.0;
            }

            // 取前 count 個，若無元素則回傳 0.0
            return sArray.Take(count).DefaultIfEmpty(0.0).Max();
        }

        // Lowest 使用 LINQ method syntax
        private double Lowest(double[] sArray, int count)
        {
            if (sArray == null || count <= 0)
            {
                return 0.0;
            }

            // 取前 count 個，若無元素則回傳 0.0
            return sArray.Take(count).DefaultIfEmpty(0.0).Min();
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

        // 計算檔案中可解析為 double 的行數（使用 LINQ method syntax）
        private int GetFileScoreCount(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return 0;
            }

            try
            {
                return File.ReadLines(filePath).Count(line => double.TryParse(line, out _));
            }
            catch
            {
                MessageBox.Show("無法讀取檔案以計算成績數量。請確認檔案存在且格式正確。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // 讀取檔案並將可解析為 double 的值放入 scores，回傳實際讀入數量（使用 LINQ method syntax）
        private int ReadScores(string filePath, double[] scores)
        {
            if (string.IsNullOrWhiteSpace(filePath) || scores == null || !File.Exists(filePath)) return 0;

            try
            {
                var parsed = File.ReadLines(filePath)
                    .Select(line =>
                    {
                        double v;
                        bool ok = double.TryParse(line, out v);
                        return new { ok, v };
                    })
                    .Where(x => x.ok)
                    .Select(x => x.v)
                    .Take(scores.Length)
                    .ToArray();

                int index = 0;
                foreach (var v in parsed)
                {
                    scores[index++] = v;
                }

                return index;
            }
            catch (Exception)
            {
                MessageBox.Show("讀取成績檔案時發生錯誤。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 先尋找檔案路徑（自動）
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

                // 先計算可解析的成績數量，然後建立陣列並讀入
                int size = GetFileScoreCount(filePath);
                if (size <= 0)
                {
                    MessageBox.Show("檔案中沒有可解析的成績資料。", "資料不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double[] scores = new double[size];
                int index = ReadScores(filePath, scores);

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
                    highScoreLabel.Text = Highest(scores, index).ToString("n1");
                    lowScoreLabel.Text = Lowest(scores, index).ToString("n1");
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