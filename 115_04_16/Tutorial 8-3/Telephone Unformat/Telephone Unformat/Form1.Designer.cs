namespace Telephone_Unformat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// 設計器初始化方法。
        /// 已將所有顯示文字改為繁體中文，字型統一為「Microsoft JhengHei」18pt，
        /// 並適度調整每個元件的大小與位置以符合較大的字型。
        /// 注意：僅變更元件屬性（Text、Font、Size、Location、TabIndex、TextAlign等），
        /// 其他程式邏輯或事件處理器名稱維持不變。
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.unformatButton = new System.Windows.Forms.Button();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exitButton.Location = new System.Drawing.Point(390, 166);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(180, 55);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "離開";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // unformatButton
            // 
            this.unformatButton.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.unformatButton.Location = new System.Drawing.Point(180, 166);
            this.unformatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unformatButton.Name = "unformatButton";
            this.unformatButton.Size = new System.Drawing.Size(180, 55);
            this.unformatButton.TabIndex = 6;
            this.unformatButton.Text = "移除格式";
            this.unformatButton.UseVisualStyleBackColor = true;
            this.unformatButton.Click += new System.EventHandler(this.unformatButton_Click);
            // 
            // instructionLabel
            // 
            this.instructionLabel.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.instructionLabel.Location = new System.Drawing.Point(18, 17);
            this.instructionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(594, 75);
            this.instructionLabel.TabIndex = 5;
            this.instructionLabel.Text = "請輸入電話號碼，格式為 (XXX)XXX-XXXX，按「移除格式」將只保留數字。";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numberTextBox.Location = new System.Drawing.Point(180, 102);
            this.numberTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(388, 55);
            this.numberTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 249);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.unformatButton);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.numberTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "電話號碼移除格式";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button unformatButton;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.TextBox numberTextBox;
    }
}

