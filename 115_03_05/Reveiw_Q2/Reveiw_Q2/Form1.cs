using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Reveiw_Q2
{
    public partial class Form1 : Form
    {
        // 費用常數
        private const decimal OIL_CHANGE = 780m;
        private const decimal OIL_MAINTENANCE = 540m;
        private const decimal WATER_WASH = 900m;
        private const decimal TRANSMISSION_CLEAN = 2400m;
        private const decimal INSPECTION = 450m;
        private const decimal REPLACE_MUFFLER = 3000m;
        private const decimal TIRE_ROTATION = 600m;
        private const decimal LABOR_RATE_PER_HOUR = 600m;
        private const decimal PARTS_TAX_RATE = 0.06m;

        private readonly CultureInfo displayCulture = CultureInfo.CreateSpecificCulture("zh-TW");

        public Form1()
        {
            InitializeComponent();

            // 事件綁定
            btnCalculate.Click += BtnCalculate_Click;
            btnClear.Click += BtnClear_Click;
            btnExit.Click += BtnExit_Click;
            this.FormClosing += Form1_FormClosing;
        }

        private void BtnCalculate_Click(object? sender, EventArgs e)
        {
            // 驗證與解析輸入
            if (!TryParseDecimal(txtParts.Text, out var partsCost))
            {
                MessageBox.Show("請輸入有效的零件費用（數字）。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtParts.Focus();
                return;
            }

            if (!TryParseDecimal(txtLaborHours.Text, out var laborHours))
            {
                MessageBox.Show("請輸入有效的工時數（數字）。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLaborHours.Focus();
                return;
            }

            // 計算服務費用
            decimal serviceFees = 0m;
            if (chkReplaceOil.Checked) serviceFees += OIL_CHANGE;
            if (chkOilMaintenance.Checked) serviceFees += OIL_MAINTENANCE;
            if (chkWaterWash.Checked) serviceFees += WATER_WASH;
            if (chkTransmissionClean.Checked) serviceFees += TRANSMISSION_CLEAN;
            if (chkInspection.Checked) serviceFees += INSPECTION;
            if (chkReplaceMuffler.Checked) serviceFees += REPLACE_MUFFLER;
            if (chkTireRotation.Checked) serviceFees += TIRE_ROTATION;

            // 工時費用
            decimal laborCost = laborHours * LABOR_RATE_PER_HOUR;

            // 服務與工資總額
            decimal serviceAndLaborTotal = serviceFees + laborCost;

            // 零件稅金
            decimal partsTax = Math.Round(partsCost * PARTS_TAX_RATE, 0, MidpointRounding.AwayFromZero);

            // 總費用
            decimal grandTotal = serviceAndLaborTotal + partsCost + partsTax;

            // 格式化顯示（使用台灣貨幣顯示）
            lblServiceLaborValue.Text = serviceAndLaborTotal.ToString("C0", displayCulture);
            lblPartsCostValue.Text = partsCost.ToString("C0", displayCulture);
            lblPartsTaxValue.Text = partsTax.ToString("C0", displayCulture);
            lblTotalCostValue.Text = grandTotal.ToString("C0", displayCulture);
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            // 重設所有選項與輸入
            chkReplaceOil.Checked = false;
            chkOilMaintenance.Checked = false;
            chkWaterWash.Checked = false;
            chkTransmissionClean.Checked = false;
            chkInspection.Checked = false;
            chkReplaceMuffler.Checked = false;
            chkTireRotation.Checked = false;

            txtParts.Text = string.Empty;
            txtLaborHours.Text = string.Empty;

            lblServiceLaborValue.Text = string.Empty;
            lblPartsCostValue.Text = string.Empty;
            lblPartsTaxValue.Text = string.Empty;
            lblTotalCostValue.Text = string.Empty;
        }

        private void BtnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("是否要在離開前儲存維修明細？", "儲存明細", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (result == DialogResult.Yes)
            {
                var saved = SaveReport();
                if (!saved)
                {
                    // 如果使用者在儲存過程取消或失敗，取消關閉
                    e.Cancel = true;
                }
            }
        }

        private bool SaveReport()
        {
            using var sfd = new SaveFileDialog
            {
                Title = "儲存維修明細",
                Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*",
                FileName = $"RepairReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (sfd.ShowDialog() != DialogResult.OK) return false;

            try
            {
                var content = BuildReport();
                File.WriteAllText(sfd.FileName, content, Encoding.UTF8);
                MessageBox.Show($"已儲存：{sfd.FileName}", "儲存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"儲存失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string BuildReport()
        {
            // 重新計算以確保報表數值正確（不會顯示錯誤輸入）
            TryParseDecimal(txtParts.Text, out var partsCost);
            TryParseDecimal(txtLaborHours.Text, out var laborHours);

            decimal serviceFees = 0m;
            var selectedServices = new StringBuilder();
            void AddService(bool condition, string name, decimal price)
            {
                if (!condition) return;
                serviceFees += price;
                selectedServices.AppendLine($"- {name}：{price.ToString("C0", displayCulture)}");
            }

            AddService(chkReplaceOil.Checked, "更換機油", OIL_CHANGE);
            AddService(chkOilMaintenance.Checked, "潤滑保養", OIL_MAINTENANCE);
            AddService(chkWaterWash.Checked, "水箱清洗", WATER_WASH);
            AddService(chkTransmissionClean.Checked, "變速箱清洗", TRANSMISSION_CLEAN);
            AddService(chkInspection.Checked, "檢驗", INSPECTION);
            AddService(chkReplaceMuffler.Checked, "更換消音器", REPLACE_MUFFLER);
            AddService(chkTireRotation.Checked, "輪胎換位", TIRE_ROTATION);

            decimal laborCost = laborHours * LABOR_RATE_PER_HOUR;
            decimal serviceAndLaborTotal = serviceFees + laborCost;
            decimal partsTax = Math.Round(partsCost * PARTS_TAX_RATE, 0, MidpointRounding.AwayFromZero);
            decimal grandTotal = serviceAndLaborTotal + partsCost + partsTax;

            var sb = new StringBuilder();
            sb.AppendLine("汽車維修服務 明細報表");
            sb.AppendLine($"產生時間：{DateTime.Now:yyyy/MM/dd HH:mm:ss}");
            sb.AppendLine(new string('-', 60));
            sb.AppendLine("服務項目：");
            if (selectedServices.Length == 0) sb.AppendLine("- 無選取任何服務");
            else sb.Append(selectedServices.ToString());
            sb.AppendLine();
            sb.AppendLine("明細計算：");
            sb.AppendLine($"服務費用合計：{serviceFees.ToString("C0", displayCulture)}");
            sb.AppendLine($"工時數：{laborHours} 小時 (每小時 {LABOR_RATE_PER_HOUR.ToString("C0", displayCulture)})");
            sb.AppendLine($"工時費用：{laborCost.ToString("C0", displayCulture)}");
            sb.AppendLine($"服務與工資總額：{serviceAndLaborTotal.ToString("C0", displayCulture)}");
            sb.AppendLine($"零件費用：{partsCost.ToString("C0", displayCulture)}");
            sb.AppendLine($"零件稅金（6%）：{partsTax.ToString("C0", displayCulture)}");
            sb.AppendLine($"總費用：{grandTotal.ToString("C0", displayCulture)}");
            sb.AppendLine(new string('-', 60));
            sb.AppendLine("開發者註：本報表以系統設定之費率與稅率計算。");

            return sb.ToString();
        }

        private static bool TryParseDecimal(string? text, out decimal value)
        {
            value = 0m;
            if (string.IsNullOrWhiteSpace(text))
            {
                value = 0m;
                return true;
            }

            // 允許整數或小數輸入（去除可能的千分位分隔符）
            var cleaned = text.Trim().Replace(",", "").Replace(" ", "");
            return decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, out value)
                || decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.CurrentCulture, out value);
        }
    }
}
