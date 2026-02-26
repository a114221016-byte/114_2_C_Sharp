using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Review_Q2
{
    partial class Form1
    {
        private IContainer components = null;

        private GroupBox groupBoxOil;
        private CheckBox chkOilChange;
        private CheckBox chkOilService;

        private GroupBox groupBoxWash;
        private CheckBox chkRadiator;
        private CheckBox chkTransmission;

        private GroupBox groupBoxOther;
        private CheckBox chkInspection;
        private CheckBox chkMuffler;
        private CheckBox chkAlignment;

        private GroupBox groupBoxPartsLabor;
        private Label lblParts;
        private TextBox txtParts;
        private Label lblHours;
        private TextBox txtHours;

        private GroupBox groupBoxSummary;
        private Label lblServiceAndLabor;
        private Label lblServiceAndLaborValue;
        private Label lblPartsSummary;
        private Label lblPartsValue;
        private Label lblTax;
        private Label lblTaxValue;
        private Label lblTotal;
        private Label lblTotalValue;

        private Button btnCalculate;
        private Button btnClear;
        private Button btnExit;

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

        private void InitializeComponent()
        {
            groupBoxOil = new GroupBox();
            chkOilChange = new CheckBox();
            chkOilService = new CheckBox();
            groupBoxWash = new GroupBox();
            chkRadiator = new CheckBox();
            chkTransmission = new CheckBox();
            groupBoxOther = new GroupBox();
            chkInspection = new CheckBox();
            chkMuffler = new CheckBox();
            chkAlignment = new CheckBox();
            groupBoxPartsLabor = new GroupBox();
            lblParts = new Label();
            txtParts = new TextBox();
            lblHours = new Label();
            txtHours = new TextBox();
            groupBoxSummary = new GroupBox();
            lblServiceAndLabor = new Label();
            lblServiceAndLaborValue = new Label();
            lblPartsSummary = new Label();
            lblPartsValue = new Label();
            lblTax = new Label();
            lblTaxValue = new Label();
            lblTotal = new Label();
            lblTotalValue = new Label();
            btnCalculate = new Button();
            btnClear = new Button();
            btnExit = new Button();
            groupBoxOil.SuspendLayout();
            groupBoxWash.SuspendLayout();
            groupBoxOther.SuspendLayout();
            groupBoxPartsLabor.SuspendLayout();
            groupBoxSummary.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxOil
            // 
            groupBoxOil.Controls.Add(chkOilChange);
            groupBoxOil.Controls.Add(chkOilService);
            groupBoxOil.Location = new Point(12, 12);
            groupBoxOil.Name = "groupBoxOil";
            groupBoxOil.Size = new Size(232, 92);
            groupBoxOil.TabIndex = 0;
            groupBoxOil.TabStop = false;
            groupBoxOil.Text = "機油和潤滑";
            // 
            // chkOilChange
            // 
            chkOilChange.AutoSize = true;
            chkOilChange.Location = new Point(12, 24);
            chkOilChange.Name = "chkOilChange";
            chkOilChange.Size = new Size(190, 27);
            chkOilChange.TabIndex = 0;
            chkOilChange.Text = "更換機油 (NT$780)";
            // 
            // chkOilService
            // 
            chkOilService.AutoSize = true;
            chkOilService.Location = new Point(12, 52);
            chkOilService.Name = "chkOilService";
            chkOilService.Size = new Size(190, 27);
            chkOilService.TabIndex = 1;
            chkOilService.Text = "潤滑保養 (NT$540)";
            // 
            // groupBoxWash
            // 
            groupBoxWash.Controls.Add(chkRadiator);
            groupBoxWash.Controls.Add(chkTransmission);
            groupBoxWash.Location = new Point(250, 12);
            groupBoxWash.Name = "groupBoxWash";
            groupBoxWash.Size = new Size(262, 92);
            groupBoxWash.TabIndex = 1;
            groupBoxWash.TabStop = false;
            groupBoxWash.Text = "清洗服務";
            // 
            // chkRadiator
            // 
            chkRadiator.AutoSize = true;
            chkRadiator.Location = new Point(12, 24);
            chkRadiator.Name = "chkRadiator";
            chkRadiator.Size = new Size(190, 27);
            chkRadiator.TabIndex = 0;
            chkRadiator.Text = "水箱清洗 (NT$900)";
            // 
            // chkTransmission
            // 
            chkTransmission.AutoSize = true;
            chkTransmission.Location = new Point(12, 52);
            chkTransmission.Name = "chkTransmission";
            chkTransmission.Size = new Size(222, 27);
            chkTransmission.TabIndex = 1;
            chkTransmission.Text = "變速箱清洗 (NT$2,400)";
            // 
            // groupBoxOther
            // 
            groupBoxOther.Controls.Add(chkInspection);
            groupBoxOther.Controls.Add(chkMuffler);
            groupBoxOther.Controls.Add(chkAlignment);
            groupBoxOther.Location = new Point(12, 110);
            groupBoxOther.Name = "groupBoxOther";
            groupBoxOther.Size = new Size(232, 120);
            groupBoxOther.TabIndex = 2;
            groupBoxOther.TabStop = false;
            groupBoxOther.Text = "其他服務";
            // 
            // chkInspection
            // 
            chkInspection.AutoSize = true;
            chkInspection.Location = new Point(12, 22);
            chkInspection.Name = "chkInspection";
            chkInspection.Size = new Size(154, 27);
            chkInspection.TabIndex = 0;
            chkInspection.Text = "檢驗 (NT$450)";
            // 
            // chkMuffler
            // 
            chkMuffler.AutoSize = true;
            chkMuffler.Location = new Point(12, 50);
            chkMuffler.Name = "chkMuffler";
            chkMuffler.Size = new Size(222, 27);
            chkMuffler.TabIndex = 1;
            chkMuffler.Text = "更換消音器 (NT$3,000)";
            // 
            // chkAlignment
            // 
            chkAlignment.AutoSize = true;
            chkAlignment.Location = new Point(12, 78);
            chkAlignment.Name = "chkAlignment";
            chkAlignment.Size = new Size(190, 27);
            chkAlignment.TabIndex = 2;
            chkAlignment.Text = "輪胎定位 (NT$600)";
            // 
            // groupBoxPartsLabor
            // 
            groupBoxPartsLabor.Controls.Add(lblParts);
            groupBoxPartsLabor.Controls.Add(txtParts);
            groupBoxPartsLabor.Controls.Add(lblHours);
            groupBoxPartsLabor.Controls.Add(txtHours);
            groupBoxPartsLabor.Location = new Point(250, 110);
            groupBoxPartsLabor.Name = "groupBoxPartsLabor";
            groupBoxPartsLabor.Size = new Size(262, 120);
            groupBoxPartsLabor.TabIndex = 3;
            groupBoxPartsLabor.TabStop = false;
            groupBoxPartsLabor.Text = "零件和工時";
            // 
            // lblParts
            // 
            lblParts.AutoSize = true;
            lblParts.Location = new Point(12, 28);
            lblParts.Name = "lblParts";
            lblParts.Size = new Size(98, 23);
            lblParts.TabIndex = 0;
            lblParts.Text = "零件 (NT$)";
            // 
            // txtParts
            // 
            txtParts.Location = new Point(134, 25);
            txtParts.Name = "txtParts";
            txtParts.Size = new Size(100, 30);
            txtParts.TabIndex = 1;
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Location = new Point(12, 64);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(117, 23);
            lblHours.TabIndex = 2;
            lblHours.Text = "工時數 (小時)";
            // 
            // txtHours
            // 
            txtHours.Location = new Point(134, 61);
            txtHours.Name = "txtHours";
            txtHours.Size = new Size(100, 30);
            txtHours.TabIndex = 3;
            // 
            // groupBoxSummary
            // 
            groupBoxSummary.Controls.Add(lblServiceAndLabor);
            groupBoxSummary.Controls.Add(lblServiceAndLaborValue);
            groupBoxSummary.Controls.Add(lblPartsSummary);
            groupBoxSummary.Controls.Add(lblPartsValue);
            groupBoxSummary.Controls.Add(lblTax);
            groupBoxSummary.Controls.Add(lblTaxValue);
            groupBoxSummary.Controls.Add(lblTotal);
            groupBoxSummary.Controls.Add(lblTotalValue);
            groupBoxSummary.Location = new Point(12, 245);
            groupBoxSummary.Name = "groupBoxSummary";
            groupBoxSummary.Size = new Size(458, 179);
            groupBoxSummary.TabIndex = 4;
            groupBoxSummary.TabStop = false;
            groupBoxSummary.Text = "費用摘要";
            // 
            // lblServiceAndLabor
            // 
            lblServiceAndLabor.AutoSize = true;
            lblServiceAndLabor.Location = new Point(12, 28);
            lblServiceAndLabor.Name = "lblServiceAndLabor";
            lblServiceAndLabor.Size = new Size(100, 23);
            lblServiceAndLabor.TabIndex = 0;
            lblServiceAndLabor.Text = "服務與工資";
            // 
            // lblServiceAndLaborValue
            // 
            lblServiceAndLaborValue.BorderStyle = BorderStyle.Fixed3D;
            lblServiceAndLaborValue.Location = new Point(140, 24);
            lblServiceAndLaborValue.Name = "lblServiceAndLaborValue";
            lblServiceAndLaborValue.Size = new Size(300, 23);
            lblServiceAndLaborValue.TabIndex = 1;
            lblServiceAndLaborValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPartsSummary
            // 
            lblPartsSummary.AutoSize = true;
            lblPartsSummary.Location = new Point(12, 58);
            lblPartsSummary.Name = "lblPartsSummary";
            lblPartsSummary.Size = new Size(46, 23);
            lblPartsSummary.TabIndex = 2;
            lblPartsSummary.Text = "零件";
            // 
            // lblPartsValue
            // 
            lblPartsValue.BorderStyle = BorderStyle.Fixed3D;
            lblPartsValue.Location = new Point(140, 54);
            lblPartsValue.Name = "lblPartsValue";
            lblPartsValue.Size = new Size(300, 23);
            lblPartsValue.TabIndex = 3;
            lblPartsValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(12, 88);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(99, 23);
            lblTax.TabIndex = 4;
            lblTax.Text = "稅金 (零件)";
            // 
            // lblTaxValue
            // 
            lblTaxValue.BorderStyle = BorderStyle.Fixed3D;
            lblTaxValue.Location = new Point(140, 84);
            lblTaxValue.Name = "lblTaxValue";
            lblTaxValue.Size = new Size(300, 23);
            lblTaxValue.TabIndex = 5;
            lblTaxValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 120);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(64, 23);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "總費用";
            // 
            // lblTotalValue
            // 
            lblTotalValue.BorderStyle = BorderStyle.Fixed3D;
            lblTotalValue.Location = new Point(140, 120);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(300, 23);
            lblTotalValue.TabIndex = 7;
            lblTotalValue.TextAlign = ContentAlignment.MiddleRight;
            lblTotalValue.Click += lblTotalValue_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(40, 448);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(100, 28);
            btnCalculate.TabIndex = 5;
            btnCalculate.Text = "計算總額";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(209, 448);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 28);
            btnClear.TabIndex = 6;
            btnClear.Text = "清除";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(384, 448);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 28);
            btnExit.TabIndex = 7;
            btnExit.Text = "離開";
            // 
            // Form1
            // 
            ClientSize = new Size(553, 533);
            Controls.Add(groupBoxOil);
            Controls.Add(groupBoxWash);
            Controls.Add(groupBoxOther);
            Controls.Add(groupBoxPartsLabor);
            Controls.Add(groupBoxSummary);
            Controls.Add(btnCalculate);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Font = new Font("Microsoft JhengHei UI", 9F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "汽車維修服務";
            groupBoxOil.ResumeLayout(false);
            groupBoxOil.PerformLayout();
            groupBoxWash.ResumeLayout(false);
            groupBoxWash.PerformLayout();
            groupBoxOther.ResumeLayout(false);
            groupBoxOther.PerformLayout();
            groupBoxPartsLabor.ResumeLayout(false);
            groupBoxPartsLabor.PerformLayout();
            groupBoxSummary.ResumeLayout(false);
            groupBoxSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
