using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法
        // 功能：檢查傳入的字串是否為「剛好 10 位數且僅包含數字」。
        // 實作說明：
        // - 先檢查是否為空或僅空白，若是回傳 false。
        // - 使用 LINQ 計算字元中數字的數量，並確認原字串全部為數字（避免含有其他符號）。
        // 回傳：若符合條件回傳 true，否則 false。
        private bool IsValidNumber(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            // 移除前後空白後判斷每個字元是否皆為數字，並計算數字數量
            var trimmed = str.Trim();
            if (trimmed.Length != 10)
            {
                // 若長度不是 10，直接回傳 false
                return false;
            }

            // 確認所有字元皆為數字
            return trimmed.All(char.IsDigit);
        }

        // TelephoneFormat 方法
        // 功能：將傳入的字串（以參考方式）格式化為電話號碼樣式：(XX) XXXX-XXXX
        // 前置：呼叫此方法前應先確保傳入字串至少包含 10 個數字（此處仍會嘗試提取數字並檢查長度）
        private void TelephoneFormat(ref string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            // 只保留數字字元（以防使用者輸入了空白或其他符號）
            var digits = new string(str.Where(char.IsDigit).ToArray());

            // 若非 10 位數，則不做格式化
            if (digits.Length != 10)
            {
                return;
            }

            // 格式化為 (XX) XXXX-XXXX
            str = $"({digits.Substring(0, 2)}) {digits.Substring(2, 4)}-{digits.Substring(6, 4)}";
        }

        // formatButton_Click 事件處理器
        // 功能：取得輸入欄位內容，驗證是否為 10 位數字，成功則格式化並顯示於欄位；失敗則顯示錯誤訊息。
        private void formatButton_Click(object sender, EventArgs e)
        {
            var input = numberTextBox.Text ?? string.Empty;

            // 驗證輸入
            if (!IsValidNumber(input))
            {
                MessageBox.Show(
                    "請輸入剛好十位且僅包含數字的電話號碼（不含空格或特殊符號）。",
                    "輸入錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 格式化並回寫到文字方塊
            TelephoneFormat(ref input);
            numberTextBox.Text = input;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
