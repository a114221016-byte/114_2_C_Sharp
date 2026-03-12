namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNumber1 = new System.Windows.Forms.Label();
            this.lblNumber2 = new System.Windows.Forms.Label();
            this.lblNumber3 = new System.Windows.Forms.Label();
            this.lblNumber4 = new System.Windows.Forms.Label();
            this.lblNumber5 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnLoadWinning = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listBoxLottery = new System.Windows.Forms.ListBox();
            this.lblResultContent = new System.Windows.Forms.Label();
            this.lblResultBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("新細明體", 14F);
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "樂選號碼產生器";
            // 
            // lblNumber1
            // 
            this.lblNumber1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumber1.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblNumber1.Location = new System.Drawing.Point(130, 60);
            this.lblNumber1.Name = "lblNumber1";
            this.lblNumber1.Size = new System.Drawing.Size(100, 48);
            this.lblNumber1.TabIndex = 1;
            this.lblNumber1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber2
            // 
            this.lblNumber2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumber2.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblNumber2.Location = new System.Drawing.Point(275, 60);
            this.lblNumber2.Name = "lblNumber2";
            this.lblNumber2.Size = new System.Drawing.Size(100, 48);
            this.lblNumber2.TabIndex = 2;
            this.lblNumber2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber3
            // 
            this.lblNumber3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumber3.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblNumber3.Location = new System.Drawing.Point(420, 60);
            this.lblNumber3.Name = "lblNumber3";
            this.lblNumber3.Size = new System.Drawing.Size(100, 48);
            this.lblNumber3.TabIndex = 3;
            this.lblNumber3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber4
            // 
            this.lblNumber4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumber4.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblNumber4.Location = new System.Drawing.Point(565, 60);
            this.lblNumber4.Name = "lblNumber4";
            this.lblNumber4.Size = new System.Drawing.Size(100, 48);
            this.lblNumber4.TabIndex = 4;
            this.lblNumber4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumber5
            // 
            this.lblNumber5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumber5.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblNumber5.Location = new System.Drawing.Point(710, 60);
            this.lblNumber5.Name = "lblNumber5";
            this.lblNumber5.Size = new System.Drawing.Size(100, 48);
            this.lblNumber5.TabIndex = 5;
            this.lblNumber5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnGenerate.Location = new System.Drawing.Point(130, 120);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(116, 40);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "產生號碼";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnLoadWinning
            // 
            this.btnLoadWinning.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnLoadWinning.Location = new System.Drawing.Point(370, 120);
            this.btnLoadWinning.Name = "btnLoadWinning";
            this.btnLoadWinning.Size = new System.Drawing.Size(118, 40);
            this.btnLoadWinning.TabIndex = 7;
            this.btnLoadWinning.Text = "開獎號碼";
            this.btnLoadWinning.UseVisualStyleBackColor = true;
            this.btnLoadWinning.Click += new System.EventHandler(this.BtnLoadWinning_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnClose.Location = new System.Drawing.Point(610, 120);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "離開";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // listBoxLottery
            // 
            this.listBoxLottery.Font = new System.Drawing.Font("新細明體", 11F);
            this.listBoxLottery.FormattingEnabled = true;
            this.listBoxLottery.ItemHeight = 22;
            this.listBoxLottery.Location = new System.Drawing.Point(50, 190);
            this.listBoxLottery.Name = "listBoxLottery";
            this.listBoxLottery.Size = new System.Drawing.Size(359, 246);
            this.listBoxLottery.TabIndex = 9;
            // 
            // lblResultContent
            // 
            this.lblResultContent.AutoSize = true;
            this.lblResultContent.Font = new System.Drawing.Font("新細明體", 11F);
            this.lblResultContent.Location = new System.Drawing.Point(440, 215);
            this.lblResultContent.Name = "lblResultContent";
            this.lblResultContent.Size = new System.Drawing.Size(0, 22);
            this.lblResultContent.TabIndex = 11;
            // 
            // lblResultBox
            // 
            this.lblResultBox.Font = new System.Drawing.Font("新細明體", 11F);
            this.lblResultBox.ForeColor = System.Drawing.Color.Red;
            this.lblResultBox.Location = new System.Drawing.Point(440, 190);
            this.lblResultBox.Name = "lblResultBox";
            this.lblResultBox.Size = new System.Drawing.Size(370, 230);
            this.lblResultBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 480);
            this.Controls.Add(this.lblResultBox);
            this.Controls.Add(this.lblResultContent);
            this.Controls.Add(this.listBoxLottery);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoadWinning);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblNumber5);
            this.Controls.Add(this.lblNumber4);
            this.Controls.Add(this.lblNumber3);
            this.Controls.Add(this.lblNumber2);
            this.Controls.Add(this.lblNumber1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "樂選號碼產生器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNumber1;
        private System.Windows.Forms.Label lblNumber2;
        private System.Windows.Forms.Label lblNumber3;
        private System.Windows.Forms.Label lblNumber4;
        private System.Windows.Forms.Label lblNumber5;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnLoadWinning;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listBoxLottery;
        private System.Windows.Forms.Label lblResultContent;
        private System.Windows.Forms.Label lblResultBox;
    }
}

