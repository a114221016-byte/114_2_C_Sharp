using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly string SAVE_FILE = Path.Combine(Application.StartupPath, "savegame.txt");

        // 程式狀態變數
        private readonly Random rand = new Random();
        private int n1, n2, n3;
        private int prize = 0;
        private int balance = 0;
        private int totalDeposited = 0;
        private int totalSpins = 0;
        private int winCount = 0;

        // 進階旋轉動畫所需欄位
        private readonly System.Windows.Forms.Timer spinTimer = new System.Windows.Forms.Timer();
        private int spinTick = 0;
        private const int STOP_LEFT = 10;
        private const int STOP_MID = 16;
        private const int STOP_RIGHT = 22;
        private bool stoppedLeft = false;
        private bool stoppedMid = false;
        private bool stoppedRight = false;
        private int currentBet = 0;

        public Form1()
        {
            InitializeComponent();

            // 綁定事件
            Load += Form1_Load;
            btnDeposit.Click += btnDeposit_Click;
            cmbBet.SelectedIndexChanged += cmbBet_SelectedIndexChanged;
            btnSpin.Click += btnSpin_Click;
            btnExit.Click += btnExit_Click;

            // 確保 PictureBox 使用 StretchImage
            picReel1.SizeMode = PictureBoxSizeMode.StretchImage;
            picReel2.SizeMode = PictureBoxSizeMode.StretchImage;
            picReel3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // 先嘗試載入先前存檔（存在則還原狀態）
            LoadGame();

            // 初始化下注選項（依規格為 $1、$5、$10、$50）
            cmbBet.Items.Clear();
            cmbBet.Items.AddRange(new object[] { "$1", "$5", "$10", "$50" });
            cmbBet.SelectedIndex = 0; // 預設 $1

            // 設定 spinTimer
            spinTimer.Interval = 80;
            spinTimer.Tick += spinTimer_Tick;

            // 顯示初始圖片
            GetImage();

            // 更新介面（會依 balance 決定按鈕狀態）
            UpdateUI();
            UpdateStats();
        }

        private void btnDeposit_Click(object? sender, EventArgs e)
        {
            string input = txtDepositAmount.Text.Trim();
            if (!int.TryParse(input, out int amount) || amount <= 0)
            {
                MessageBox.Show("請輸入有效的存入金額（必須為正整數）", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            balance += amount;
            totalDeposited += amount;
            txtDepositAmount.Clear();

            UpdateUI();
            UpdateStats();

            // 存檔（避免意外造成遺失）
            SaveGame();
        }

        private void cmbBet_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // 若在旋轉中，介面不變，但仍呼叫 UpdateUI 以確保按鈕狀態正確
            UpdateUI();
        }

        private void btnSpin_Click(object? sender, EventArgs e)
        {
            int bet = GetBetAmount();
            if (bet <= 0) return;

            if (balance < bet)
            {
                UpdateUI();
                MessageBox.Show("餘額不足，無法下注。", "餘額不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 扣款
            balance -= bet;
            prize = 0;
            currentBet = bet;

            // 決定最終三個轉輪索引（但不立即顯示）
            n1 = rand.Next(0, 10);
            n2 = rand.Next(0, 10);
            n3 = rand.Next(0, 10);

            // 初始化動畫狀態並啟動 Timer
            spinTick = 0;
            stoppedLeft = stoppedMid = stoppedRight = false;
            spinTimer.Enabled = true;

            UpdateUI(); // 會根據 spinTimer.Enabled 停用相關按鈕
        }

        private void spinTimer_Tick(object? sender, EventArgs e)
        {
            spinTick++;

            // 左轉輪
            if (!stoppedLeft)
            {
                if (spinTick >= STOP_LEFT)
                {
                    // 停在最終結果
                    if (imageList1.Images.Count > n1) picReel1.Image = imageList1.Images[n1];
                    stoppedLeft = true;
                }
                else
                {
                    // 快速顯示隨機圖片
                    if (imageList1.Images.Count >= 10) picReel1.Image = imageList1.Images[rand.Next(0, 10)];
                }
            }

            // 中轉輪
            if (!stoppedMid)
            {
                if (spinTick >= STOP_MID)
                {
                    if (imageList1.Images.Count > n2) picReel2.Image = imageList1.Images[n2];
                    stoppedMid = true;
                }
                else
                {
                    if (imageList1.Images.Count >= 10) picReel2.Image = imageList1.Images[rand.Next(0, 10)];
                }
            }

            // 右轉輪
            if (!stoppedRight)
            {
                if (spinTick >= STOP_RIGHT)
                {
                    if (imageList1.Images.Count > n3) picReel3.Image = imageList1.Images[n3];
                    stoppedRight = true;
                }
                else
                {
                    if (imageList1.Images.Count >= 10) picReel3.Image = imageList1.Images[rand.Next(0, 10)];
                }
            }

            // 全部停止時結束動畫並計算結果
            if (stoppedLeft && stoppedMid && stoppedRight)
            {
                spinTimer.Enabled = false;

                // 判斷勝負並計算獎金
                checkWinner(currentBet);

                totalSpins++;
                if (prize > 0) winCount++;

                // 更新介面與統計（UpdateUI 會重新啟用按鈕）
                UpdateUI();
                UpdateStats();

                // 旋轉結束後存檔
                SaveGame();
            }
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            decimal netGain = balance - totalDeposited;
            string profitLabel = netGain >= 0 ? "獲利" : "虧損";
            string amountLabel = netGain >= 0 ? netGain.ToString("C") : Math.Abs(netGain).ToString("C");

            string msg =
                $"累計存入：{totalDeposited.ToString("C")}\r\n" +
                $"目前餘額：{balance.ToString("C")}\r\n" +
                $"{profitLabel}：{amountLabel}\r\n\r\n" +
                $"旋轉次數：{totalSpins} 次　中獎次數：{winCount} 次";

            MessageBox.Show(msg, "結算摘要", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private int GetBetAmount()
        {
            if (cmbBet.SelectedItem == null) return 0;
            string s = cmbBet.SelectedItem.ToString() ?? string.Empty;
            // 去掉非數字字元
            s = s.Replace("$", "").Trim();
            if (int.TryParse(s, out int bet)) return bet;
            return 0;
        }

        private void GetImage()
        {
            // 顯示隨機初始圖片（用於程式啟動或其他非動畫情況）
            n1 = rand.Next(0, 10);
            n2 = rand.Next(0, 10);
            n3 = rand.Next(0, 10);

            if (imageList1.Images.Count >= 10)
            {
                picReel1.Image = imageList1.Images[n1];
                picReel2.Image = imageList1.Images[n2];
                picReel3.Image = imageList1.Images[n3];
            }
            else
            {
                picReel1.Image = null;
                picReel2.Image = null;
                picReel3.Image = null;
            }
        }

        private void checkWinner(int bet)
        {
            if (n1 == n2 && n2 == n3)
            {
                // 頭獎
                prize = bet * 10;
            }
            else if (n1 == n2 || n1 == n3 || n2 == n3)
            {
                // 普獎
                prize = bet * 2;
            }
            else
            {
                prize = 0;
            }

            if (prize > 0)
            {
                balance += prize;
            }
        }

        private void UpdateUI()
        {
            lblBalance.Text = "餘額：" + balance.ToString("C");
            lblLastWin.Text = "本次獲得：" + prize.ToString("C");

            int bet = GetBetAmount();

            // 在旋轉動畫進行中，停用互動按鈕與選單
            bool spinning = spinTimer.Enabled;
            btnSpin.Enabled = !spinning && bet > 0 && balance >= bet;
            btnDeposit.Enabled = !spinning;
            cmbBet.Enabled = !spinning;
            btnExit.Enabled = !spinning;
        }

        private void UpdateStats()
        {
            double winRate = 0.0;
            if (totalSpins > 0) winRate = (double)winCount / totalSpins * 100.0;
            lblStats.Text = $"旋轉：{totalSpins} 次  中獎：{winCount} 次  勝率：{winRate:F1}%";
        }

        // Save / Load 實作
        private void SaveGame()
        {
            try
            {
                using StreamWriter sw = new StreamWriter(SAVE_FILE, false);
                sw.WriteLine($"balance={balance}");
                sw.WriteLine($"totalDeposited={totalDeposited}");
                sw.WriteLine($"totalSpins={totalSpins}");
                sw.WriteLine($"winCount={winCount}");
            }
            catch
            {
                // 寫入失敗時靜默忽略（按規格）
            }
        }

        private void LoadGame()
        {
            try
            {
                if (!File.Exists(SAVE_FILE)) return;

                string[] lines = File.ReadAllLines(SAVE_FILE);
                // 暫存預設值
                int b = 0, td = 0, ts = 0, wc = 0;

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('=', 2);
                    if (parts.Length != 2) continue;
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    if (key.Equals("balance", StringComparison.OrdinalIgnoreCase))
                    {
                        int.TryParse(value, out b);
                    }
                    else if (key.Equals("totalDeposited", StringComparison.OrdinalIgnoreCase))
                    {
                        int.TryParse(value, out td);
                    }
                    else if (key.Equals("totalSpins", StringComparison.OrdinalIgnoreCase))
                    {
                        int.TryParse(value, out ts);
                    }
                    else if (key.Equals("winCount", StringComparison.OrdinalIgnoreCase))
                    {
                        int.TryParse(value, out wc);
                    }
                }

                // 還原
                balance = b;
                totalDeposited = td;
                totalSpins = ts;
                winCount = wc;
            }
            catch
            {
                // 讀取或解析失敗時依規格重置所有數值為 0
                balance = 0;
                totalDeposited = 0;
                totalSpins = 0;
                winCount = 0;
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveGame();
        }
    }
}
