using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // 開獎號碼陣列
        private int[] winningNumbers = null;
        
        // 產生的亂數號碼陣列
        private int[] generatedNumbers = null;

        // 隨機數產生器，使用靜態實例以提高效率
        private static readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化時，產生號碼按鈕應該是 disable 狀態
            btnGenerate.Enabled = false;
        }

        /// <summary>
        /// Step 1：開獎號碼按鈕事件
        /// 處理檔案選擇與讀取開獎號碼的流程
        /// 修正：改為讀取整個檔案並用 Regex 擷取所有整數，避免只顯示一個數字或被分隔符號影響解析
        /// 並將每個號碼分別加入 listBox 以便逐條顯示
        /// </summary>
        private void BtnLoadWinning_Click(object sender, EventArgs e)
        {
            // 建立 OpenFileDialog 物件用於選擇檔案
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            // 設定檔案篩選條件
            openFileDialog.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            openFileDialog.Title = "選擇開獎號碼檔案";

            // 顯示檔案選擇對話方塊
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 取得選擇的檔案路徑
                    string filePath = openFileDialog.FileName;

                    // 使用 StreamReader 讀取整個檔案內容
                    using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                    {
                        string content = reader.ReadToEnd();

                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            // 使用 Regex 擷取所有整數（含負號，可依需要移除 -）
                            MatchCollection matches = Regex.Matches(content, @"-?\d+");

                            if (matches.Count > 0)
                            {
                                // 初始化開獎號碼陣列並填入
                                winningNumbers = new int[matches.Count];
                                for (int i = 0; i < matches.Count; i++)
                                {
                                    if (int.TryParse(matches[i].Value, out int number))
                                    {
                                        winningNumbers[i] = number;
                                    }
                                    else
                                    {
                                        // 若無法解析則設為 0（或可選擇跳過/報錯）
                                        winningNumbers[i] = 0;
                                    }
                                }

                                // 將開獎號碼逐一顯示在 listBoxLottery 中（每個數字一行，較直觀）
                                listBoxLottery.Items.Clear();
                                listBoxLottery.Items.Add("開獎號碼:");
                                foreach (var num in winningNumbers)
                                {
                                    listBoxLottery.Items.Add(num.ToString());
                                }

                                // 成功讀取後，啟用產生號碼按鈕
                                btnGenerate.Enabled = true;

                                // 顯示成功訊息
                                MessageBox.Show("開獎號碼讀取成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // 檔案中找不到任何數字
                                MessageBox.Show("檔案中未找到任何號碼!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // 檔案為空
                            MessageBox.Show("檔案內容為空!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 捕捉並顯示任何發生的例外
                    MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Step 2：產生號碼按鈕事件
        /// 負責產生隨機號碼並顯示在介面上，比對開獎號碼，產生中獎結果並輸出
        /// </summary>
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            // 檢查開獎號碼是否已讀取
            if (winningNumbers == null || winningNumbers.Length == 0)
            {
                MessageBox.Show("請先讀取開獎號碼!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 產生隨機號碼，最多產生 5 個
            int numberCount = 5;
            generatedNumbers = GenerateRandomNumbers(1, 49, numberCount);

            // 將產生的號碼顯示在介面上的 Label
            lblNumber1.Text = generatedNumbers[0].ToString();
            lblNumber2.Text = generatedNumbers[1].ToString();
            lblNumber3.Text = generatedNumbers[2].ToString();
            lblNumber4.Text = generatedNumbers[3].ToString();
            lblNumber5.Text = generatedNumbers[4].ToString();

            // 比對開獎號碼
            CompareNumbers();
        }

        /// <summary>
        /// Step 3：離開按鈕事件
        /// 提供程式結束的功能
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            // 關閉視窗，結束程式
            this.Close();
        }

        /// <summary>
        /// 核心功能方法：不重複亂數產生
        /// 使用基本迴圈和條件判斷實現不重複數字的產生
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="count">產生的數字個數</param>
        /// <returns>不重複的隨機數字陣列</returns>
        private int[] GenerateRandomNumbers(int min, int max, int count)
        {
            // 初始化結果陣列
            int[] result = new int[count];

            // 計數器用於追蹤已產生的號碼個數
            int currentCount = 0;

            // 產生不重複的隨機數字
            while (currentCount < count)
            {
                // 產生隨機數字
                int randomNumber = random.Next(min, max + 1);

                // 檢查是否重複
                bool isDuplicate = false;
                for (int i = 0; i < currentCount; i++)
                {
                    if (result[i] == randomNumber)
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                // 如果不重複，則存放在陣列中
                if (!isDuplicate)
                {
                    result[currentCount] = randomNumber;
                    currentCount++;
                }
            }

            // 回傳隨機數字陣列
            return result;
        }

        /// <summary>
        /// 核心功能方法：號碼比對
        /// 實作使用者號碼與開獎號碼的比對邏輯，計算中獎數量並判定獎項等級
        /// </summary>
        private void CompareNumbers()
        {
            // 計算中獎個數
            int matchCount = 0;

            // 逐一比對每個產生的號碼是否在開獎號碼中
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                // 在開獎號碼中搜尋該號碼
                for (int j = 0; j < winningNumbers.Length; j++)
                {
                    // 如果找到相同號碼，中獎個數加一
                    if (generatedNumbers[i] == winningNumbers[j])
                    {
                        matchCount++;
                        break;
                    }
                }
            }

            // 根據中獎個數判定獎項等級
            string resultMessage = "";

            if (matchCount == 0)
            {
                resultMessage = "沒有中獎";
            }
            else if (matchCount == 1)
            {
                resultMessage = "中獎等級: 六等獎 (1個號碼相符)";
            }
            else if (matchCount == 2)
            {
                resultMessage = "中獎等級: 五等獎 (2個號碼相符)";
            }
            else if (matchCount == 3)
            {
                resultMessage = "中獎等級: 四等獎 (3個號碼相符)";
            }
            else if (matchCount == 4)
            {
                resultMessage = "中獎等級: 三等獎 (4個號碼相符)";
            }
            else if (matchCount == 5)
            {
                resultMessage = "中獎等級: 二等獎 (5個號碼相符)";
            }

            // 將結果輸出至 lblResultBox，最上方顯示標題
            lblResultBox.Text = "中獎比對結果" + Environment.NewLine + Environment.NewLine + 
                                "中獎號碼數: " + matchCount.ToString() + Environment.NewLine + resultMessage;
        }
    }
}
