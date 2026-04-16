using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 判斷字串是否符合美式電話格式 (XX)XXXX-XXXX
        // 回傳 true 表示格式正確；否則回傳 false。
        private bool IsValidFormat(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            // 移除前後空白再檢查長度
            str = str.Trim();

            // 正確格式長度應為 13 個字元，例如 "(12)3456-7890"
            if (str.Length != 13)
            {
                return false;
            }

            // 檢查固定位置的符號：0='(', 3=')', 8='-'
            if (str[0] != '(' || str[3] != ')' || str[8] != '-')
            {
                return false;
            }

            // 檢查數字位置是否為數字
            // 1-2、4-7、9-12 應為數字
            for (int i = 1; i <= 2; i++)
            {
                if (!char.IsDigit(str[i])) return false;
            }
            for (int i = 4; i <= 7; i++)
            {
                if (!char.IsDigit(str[i])) return false;
            }
            for (int i = 9; i <= 12; i++)
            {
                if (!char.IsDigit(str[i])) return false;
            }

            return true;
        }

        // 將傳入的電話字串移除'('、')'與'-'，回傳純數字字串（使用 ref 修改原字串）
        private void Unformat(ref string str)
        {
            if (str == null) return;

            // 移除括號與連字號，並去除前後空白
            str = str.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty);
        }

        // 按下「移除格式」按鈕時的行為：
        // - 驗證輸入是否為 (XX)XXXX-XXXX
        // - 若正確則移除格式並顯示結果（同時將結果回填到輸入框）
        // - 若錯誤則提示使用者並將游標聚焦於輸入框
        private void unformatButton_Click(object sender, EventArgs e)
        {
            // 取得使用者輸入
            string input = numberTextBox.Text ?? string.Empty;

            if (!IsValidFormat(input))
            {
                // 格式錯誤，顯示提示並選取全部文字方便重新輸入
                MessageBox.Show("請輸入正確格式的電話號碼，格式為 (XX)XXXX-XXXX。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numberTextBox.Focus();
                numberTextBox.SelectAll();
                return;
            }

            // 移除格式並顯示結果
            Unformat(ref input);
            numberTextBox.Text = input; // 回填純數字到輸入框
            MessageBox.Show("移除格式後的電話號碼：" + input, "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
