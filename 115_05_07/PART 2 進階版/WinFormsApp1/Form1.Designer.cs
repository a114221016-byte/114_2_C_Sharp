namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.TextBox txtDepositAmount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblLastWin;
        private System.Windows.Forms.Panel panelReel1;
        private System.Windows.Forms.Panel panelReel2;
        private System.Windows.Forms.Panel panelReel3;
        private System.Windows.Forms.PictureBox picReel1;
        private System.Windows.Forms.PictureBox picReel2;
        private System.Windows.Forms.PictureBox picReel3;
        private System.Windows.Forms.Label labelBet;
        private System.Windows.Forms.ComboBox cmbBet;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnSpin;
        private System.Windows.Forms.Button btnExit;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelDeposit = new Label();
            txtDepositAmount = new TextBox();
            btnDeposit = new Button();
            lblBalance = new Label();
            lblLastWin = new Label();
            panelReel1 = new Panel();
            picReel1 = new PictureBox();
            panelReel2 = new Panel();
            picReel2 = new PictureBox();
            panelReel3 = new Panel();
            picReel3 = new PictureBox();
            labelBet = new Label();
            cmbBet = new ComboBox();
            lblStats = new Label();
            btnSpin = new Button();
            btnExit = new Button();
            imageList1 = new ImageList(components);
            panelReel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picReel1).BeginInit();
            panelReel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picReel2).BeginInit();
            panelReel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picReel3).BeginInit();
            SuspendLayout();
            // 
            // labelDeposit
            // 
            labelDeposit.AutoSize = true;
            labelDeposit.Font = new Font("Segoe UI", 10F);
            labelDeposit.Location = new Point(16, 14);
            labelDeposit.Name = "labelDeposit";
            labelDeposit.Size = new Size(128, 28);
            labelDeposit.TabIndex = 0;
            labelDeposit.Text = "存入金額： $";
            // 
            // txtDepositAmount
            // 
            txtDepositAmount.Font = new Font("Segoe UI", 10F);
            txtDepositAmount.Location = new Point(140, 11);
            txtDepositAmount.Name = "txtDepositAmount";
            txtDepositAmount.Size = new Size(180, 34);
            txtDepositAmount.TabIndex = 1;
            // 
            // btnDeposit
            // 
            btnDeposit.Font = new Font("Segoe UI", 9F);
            btnDeposit.Location = new Point(330, 10);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(70, 28);
            btnDeposit.TabIndex = 2;
            btnDeposit.Text = "存入";
            btnDeposit.UseVisualStyleBackColor = true;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 10F);
            lblBalance.Location = new Point(16, 48);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(145, 28);
            lblBalance.TabIndex = 3;
            lblBalance.Text = "餘額：NT$0.00";
            // 
            // lblLastWin
            // 
            lblLastWin.AutoSize = true;
            lblLastWin.Font = new Font("Segoe UI", 10F);
            lblLastWin.Location = new Point(300, 48);
            lblLastWin.Name = "lblLastWin";
            lblLastWin.Size = new Size(185, 28);
            lblLastWin.TabIndex = 4;
            lblLastWin.Text = "本次獲得：NT$0.00";
            // 
            // panelReel1
            // 
            panelReel1.BorderStyle = BorderStyle.FixedSingle;
            panelReel1.Controls.Add(picReel1);
            panelReel1.Location = new Point(40, 80);
            panelReel1.Name = "panelReel1";
            panelReel1.Size = new Size(120, 120);
            panelReel1.TabIndex = 5;
            // 
            // picReel1
            // 
            picReel1.BackColor = Color.LemonChiffon;
            picReel1.Dock = DockStyle.Fill;
            picReel1.Location = new Point(0, 0);
            picReel1.Name = "picReel1";
            picReel1.Size = new Size(118, 118);
            picReel1.SizeMode = PictureBoxSizeMode.StretchImage;
            picReel1.TabIndex = 6;
            picReel1.TabStop = false;
            // 
            // panelReel2
            // 
            panelReel2.BorderStyle = BorderStyle.FixedSingle;
            panelReel2.Controls.Add(picReel2);
            panelReel2.Location = new Point(200, 80);
            panelReel2.Name = "panelReel2";
            panelReel2.Size = new Size(120, 120);
            panelReel2.TabIndex = 7;
            // 
            // picReel2
            // 
            picReel2.BackColor = Color.LemonChiffon;
            picReel2.Dock = DockStyle.Fill;
            picReel2.Location = new Point(0, 0);
            picReel2.Name = "picReel2";
            picReel2.Size = new Size(118, 118);
            picReel2.SizeMode = PictureBoxSizeMode.StretchImage;
            picReel2.TabIndex = 8;
            picReel2.TabStop = false;
            // 
            // panelReel3
            // 
            panelReel3.BorderStyle = BorderStyle.FixedSingle;
            panelReel3.Controls.Add(picReel3);
            panelReel3.Location = new Point(360, 80);
            panelReel3.Name = "panelReel3";
            panelReel3.Size = new Size(120, 120);
            panelReel3.TabIndex = 9;
            // 
            // picReel3
            // 
            picReel3.BackColor = Color.LemonChiffon;
            picReel3.Dock = DockStyle.Fill;
            picReel3.Location = new Point(0, 0);
            picReel3.Name = "picReel3";
            picReel3.Size = new Size(118, 118);
            picReel3.SizeMode = PictureBoxSizeMode.StretchImage;
            picReel3.TabIndex = 10;
            picReel3.TabStop = false;
            // 
            // labelBet
            // 
            labelBet.AutoSize = true;
            labelBet.Font = new Font("Segoe UI", 10F);
            labelBet.Location = new Point(16, 215);
            labelBet.Name = "labelBet";
            labelBet.Size = new Size(112, 28);
            labelBet.TabIndex = 11;
            labelBet.Text = "下注金額：";
            // 
            // cmbBet
            // 
            cmbBet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBet.Font = new Font("Segoe UI", 10F);
            cmbBet.FormattingEnabled = true;
            cmbBet.Items.AddRange(new object[] { "$1", "$5", "$10", "$20" });
            cmbBet.Location = new Point(112, 211);
            cmbBet.Name = "cmbBet";
            cmbBet.Size = new Size(120, 36);
            cmbBet.TabIndex = 12;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new Font("Segoe UI", 10F);
            lblStats.Location = new Point(260, 215);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(326, 28);
            lblStats.TabIndex = 13;
            lblStats.Text = "旋轉：0 次  中獎：0 次  勝率：0.0%";
            // 
            // btnSpin
            // 
            btnSpin.Font = new Font("Segoe UI", 10F);
            btnSpin.Location = new Point(140, 250);
            btnSpin.Name = "btnSpin";
            btnSpin.Size = new Size(100, 36);
            btnSpin.TabIndex = 14;
            btnSpin.Text = "旋轉";
            btnSpin.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 10F);
            btnExit.Location = new Point(260, 250);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 36);
            btnExit.TabIndex = 15;
            btnExit.Text = "離開";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Apple.bmp");
            imageList1.Images.SetKeyName(1, "Banana.bmp");
            imageList1.Images.SetKeyName(2, "Cherries.bmp");
            imageList1.Images.SetKeyName(3, "Grapes.bmp");
            imageList1.Images.SetKeyName(4, "Lemon.bmp");
            imageList1.Images.SetKeyName(5, "Lime.bmp");
            imageList1.Images.SetKeyName(6, "Orange.bmp");
            imageList1.Images.SetKeyName(7, "Pear.bmp");
            imageList1.Images.SetKeyName(8, "Strawberry.bmp");
            imageList1.Images.SetKeyName(9, "Watermelon.bmp");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 320);
            Controls.Add(labelDeposit);
            Controls.Add(txtDepositAmount);
            Controls.Add(btnDeposit);
            Controls.Add(lblBalance);
            Controls.Add(lblLastWin);
            Controls.Add(panelReel1);
            Controls.Add(panelReel2);
            Controls.Add(panelReel3);
            Controls.Add(labelBet);
            Controls.Add(cmbBet);
            Controls.Add(lblStats);
            Controls.Add(btnSpin);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            Text = "吃角子老虎機";
            panelReel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picReel1).EndInit();
            panelReel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picReel2).EndInit();
            panelReel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picReel3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ImageList imageList1;
    }
}
