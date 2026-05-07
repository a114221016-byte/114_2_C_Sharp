using System;
using System.Drawing;
using System.Windows.Forms;

   namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // 程式狀態變數
        private readonly Random rand = new Random();
        private int n1, n2, n3;
        private int prize = 0;
        private int balance = 0;
        private int totalDeposited = 0;
        private int totalSpins = 0;
        private int winCount = 0;

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
            // 初始化下注選項（依規格為 $1、$5、$10、$50）
            cmbBet.Items.Clear();
            cmbBet.Items.AddRange(new object[] { "$1", "$5", "$10", "$50" });
            cmbBet.SelectedIndex = 0; // 預設 $1

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
        }

        private void cmbBet_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnSpin_Click(object? sender, EventArgs e)
        {
            int bet = GetBetAmount();
            if (bet <= 0) return;

            if (balance < bet)
            {
                // 防護：若餘額不足則停用按鈕並提示
                UpdateUI();
                MessageBox.Show("餘額不足，無法下注。", "餘額不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 扣款
            balance -= bet;
            prize = 0;
            UpdateUI(); // 先更新餘額顯示

            // 決定及顯示圖片
            GetImage();

            // 判斷勝負並計算獎金
            checkWinner(bet);

            totalSpins++;
            if (prize > 0) winCount++;

            UpdateUI();
            UpdateStats();
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
            // 亂數決定 n1~n3 (0~9)，並更新 PictureBox
            n1 = rand.Next(0, 10);
            n2 = rand.Next(0, 10);
            n3 = rand.Next(0, 10);

            // imageList1 已在 Designer 中配置，直接取用
            if (imageList1.Images.Count >= 10)
            {
                picReel1.Image = imageList1.Images[n1];
                picReel2.Image = imageList1.Images[n2];
                picReel3.Image = imageList1.Images[n3];
            }
            else
            {
                // 若未載入圖片，清空或顯示佔位
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
            btnSpin.Enabled = balance >= bet && bet > 0;
        }

        private void UpdateStats()
        {
            // 因 Designer 為單一 lblStats，使用該標籤顯示三項統計
            double winRate = 0.0;
            if (totalSpins > 0) winRate = (double)winCount / totalSpins * 100.0;
            lblStats.Text = $"旋轉：{totalSpins} 次  中獎：{winCount} 次  勝率：{winRate:F1}%";
        }
    }
}
