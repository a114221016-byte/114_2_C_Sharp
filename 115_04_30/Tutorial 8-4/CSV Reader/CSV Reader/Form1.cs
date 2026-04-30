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
using System.Globalization;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select CSV file";
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.InitialDirectory = Application.StartupPath;

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string path = ofd.FileName;

                string[] lines;
                try
                {
                    lines = File.ReadAllLines(path, Encoding.Default);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法讀取檔案: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                averagesListBox.Items.Clear();
                averagesListBox.Items.Add("班級 學號 姓名 平均成績");

                bool firstLine = true;
                foreach (var raw in lines)
                {
                    if (string.IsNullOrWhiteSpace(raw))
                    {
                        continue;
                    }

                    var parts = SplitCsvLine(raw);
                    // 預期欄位：班級,學號,姓名,score1,score2,score3,score4,score5 => 共 8 個欄位
                    if (parts.Length < 8)
                    {
                        // 欄位不足，略過
                        continue;
                    }

                    // 若第一列看起來像標頭（score 欄為非數字），則略過標頭列
                    if (firstLine)
                    {
                        double tmp;
                        if (!TryParseScore(parts[3], out tmp))
                        {
                            firstLine = false;
                            continue;
                        }
                        firstLine = false;
                    }

                    var className = TrimQuotes(parts[0]).Trim();
                    var studentId = TrimQuotes(parts[1]).Trim();
                    var studentName = TrimQuotes(parts[2]).Trim();

                    var scores = new List<double>();
                    bool parseFailed = false;
                    for (int i = 3; i <= 7; i++)
                    {
                        double s;
                        if (TryParseScore(parts[i], out s))
                        {
                            scores.Add(s);
                        }
                        else
                        {
                            parseFailed = true;
                            break;
                        }
                    }

                    if (parseFailed || scores.Count != 5)
                    {
                        // 成績解析失敗或不足五科，略過該列
                        continue;
                    }

                    double average = scores.Sum() / scores.Count;
                    string avgStr = average.ToString("F2", CultureInfo.InvariantCulture);

                    averagesListBox.Items.Add(string.Format("{0} {1} {2} {3}", className, studentId, studentName, avgStr));
                }
            }
        }

        private bool TryParseScore(string input, out double value)
        {
            var s = TrimQuotes(input).Trim();
            // 先用 InvariantCulture，再用 CurrentCulture
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return true;
            }
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
            {
                return true;
            }
            value = 0;
            return false;
        }

        private string TrimQuotes(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            s = s.Trim();
            if (s.Length >= 2 && s.StartsWith("\"") && s.EndsWith("\""))
            {
                s = s.Substring(1, s.Length - 2).Replace("\"\"", "\"");
            }
            return s;
        }

        // 簡單的 CSV 解析，支援雙引號內含逗號與雙引號跳脫
        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '"')
                {
                    // 如果是連續兩個雙引號，視為跳脫字元，加入一個雙引號
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"');
                        i++; // 跳過下一個雙引號
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            result.Add(sb.ToString());
            return result.ToArray();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
