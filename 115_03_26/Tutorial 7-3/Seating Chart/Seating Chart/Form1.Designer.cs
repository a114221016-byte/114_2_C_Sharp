namespace Seating_Chart
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理使用中的資源。
        /// </summary>
        /// <param name="disposing">若為 true，表示應釋放受控資源。</param>
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
        /// 設計工具所需的方法 — 請不要以程式碼編輯器修改此方法內容。
        /// 以下以繁體中文加入註解，並將元件文字改為繁體中文、字型大小設為 18，及適度調整元件大小與位置。
        /// </summary>
        private void InitializeComponent()
        {
            this.airplanePictureBox = new System.Windows.Forms.PictureBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.seatPriceDescriptionLabel = new System.Windows.Forms.Label();
            this.colPromptLabel = new System.Windows.Forms.Label();
            this.rowPromptLabel = new System.Windows.Forms.Label();
            this.colTextBox = new System.Windows.Forms.TextBox();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.displayPriceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.airplanePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // airplanePictureBox
            // 
            this.airplanePictureBox.Image = global::Seating_Chart.Properties.Resources.Airplane;
            this.airplanePictureBox.Location = new System.Drawing.Point(-17, 1);
            this.airplanePictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.airplanePictureBox.Name = "airplanePictureBox";
            this.airplanePictureBox.Size = new System.Drawing.Size(873, 785);
            this.airplanePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.airplanePictureBox.TabIndex = 0;
            this.airplanePictureBox.TabStop = false;
            // 
            // priceLabel
            // 
            this.priceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceLabel.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.priceLabel.Location = new System.Drawing.Point(664, 28);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(180, 55);
            this.priceLabel.TabIndex = 21;
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seatPriceDescriptionLabel
            // 
            this.seatPriceDescriptionLabel.AutoSize = true;
            this.seatPriceDescriptionLabel.BackColor = System.Drawing.Color.White;
            this.seatPriceDescriptionLabel.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.seatPriceDescriptionLabel.Location = new System.Drawing.Point(506, 33);
            this.seatPriceDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.seatPriceDescriptionLabel.Name = "seatPriceDescriptionLabel";
            this.seatPriceDescriptionLabel.Size = new System.Drawing.Size(164, 45);
            this.seatPriceDescriptionLabel.TabIndex = 20;
            this.seatPriceDescriptionLabel.Text = "座位票價";
            // 
            // colPromptLabel
            // 
            this.colPromptLabel.AutoSize = true;
            this.colPromptLabel.BackColor = System.Drawing.Color.White;
            this.colPromptLabel.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colPromptLabel.Location = new System.Drawing.Point(18, 102);
            this.colPromptLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.colPromptLabel.Name = "colPromptLabel";
            this.colPromptLabel.Size = new System.Drawing.Size(128, 45);
            this.colPromptLabel.TabIndex = 19;
            this.colPromptLabel.Text = "輸入欄";
            // 
            // rowPromptLabel
            // 
            this.rowPromptLabel.AutoSize = true;
            this.rowPromptLabel.BackColor = System.Drawing.Color.White;
            this.rowPromptLabel.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rowPromptLabel.Location = new System.Drawing.Point(18, 33);
            this.rowPromptLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowPromptLabel.Name = "rowPromptLabel";
            this.rowPromptLabel.Size = new System.Drawing.Size(128, 45);
            this.rowPromptLabel.TabIndex = 18;
            this.rowPromptLabel.Text = "輸入列";
            // 
            // colTextBox
            // 
            this.colTextBox.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colTextBox.Location = new System.Drawing.Point(154, 99);
            this.colTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colTextBox.Name = "colTextBox";
            this.colTextBox.Size = new System.Drawing.Size(166, 55);
            this.colTextBox.TabIndex = 17;
            // 
            // rowTextBox
            // 
            this.rowTextBox.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rowTextBox.Location = new System.Drawing.Point(154, 30);
            this.rowTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(166, 55);
            this.rowTextBox.TabIndex = 16;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exitButton.Location = new System.Drawing.Point(467, 805);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(180, 66);
            this.exitButton.TabIndex = 23;
            this.exitButton.Text = "離開";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // displayPriceButton
            // 
            this.displayPriceButton.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.displayPriceButton.Location = new System.Drawing.Point(126, 805);
            this.displayPriceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.displayPriceButton.Name = "displayPriceButton";
            this.displayPriceButton.Size = new System.Drawing.Size(285, 66);
            this.displayPriceButton.TabIndex = 22;
            this.displayPriceButton.Text = "顯示票價";
            this.displayPriceButton.UseVisualStyleBackColor = true;
            this.displayPriceButton.Click += new System.EventHandler(this.displayPriceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 902);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.displayPriceButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.seatPriceDescriptionLabel);
            this.Controls.Add(this.colPromptLabel);
            this.Controls.Add(this.rowPromptLabel);
            this.Controls.Add(this.colTextBox);
            this.Controls.Add(this.rowTextBox);
            this.Controls.Add(this.airplanePictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "座位圖";
            ((System.ComponentModel.ISupportInitialize)(this.airplanePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox airplanePictureBox;
        internal System.Windows.Forms.Label priceLabel;
        internal System.Windows.Forms.Label seatPriceDescriptionLabel;
        internal System.Windows.Forms.Label colPromptLabel;
        internal System.Windows.Forms.Label rowPromptLabel;
        internal System.Windows.Forms.TextBox colTextBox;
        internal System.Windows.Forms.TextBox rowTextBox;
        internal System.Windows.Forms.Button exitButton;
        internal System.Windows.Forms.Button displayPriceButton;
    }
}

