using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Reveiw_Q2
{
    partial class Form1
    {
        private IContainer components = null;

        private GroupBox grpOilLubrication;
        private CheckBox chkReplaceOil;
        private CheckBox chkOilMaintenance;

        private GroupBox grpCleaning;
        private CheckBox chkWaterWash;
        private CheckBox chkTransmissionClean;

        private GroupBox grpOtherServices;
        private CheckBox chkInspection;
        private CheckBox chkReplaceMuffler;
        private CheckBox chkTireRotation;

        private GroupBox grpPartsLabor;
        private Label lblParts;
        private TextBox txtParts;
        private Label lblLaborHours;
        private TextBox txtLaborHours;

        private GroupBox grpSummary;
        private Label lblServiceLabor;
        private Label lblServiceLaborValue;
        private Label lblPartsCost;
        private Label lblPartsCostValue;
        private Label lblPartsTax;
        private Label lblPartsTaxValue;
        private Label lblTotalCost;
        private Label lblTotalCostValue;

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
            grpOilLubrication = new GroupBox();
            chkReplaceOil = new CheckBox();
            chkOilMaintenance = new CheckBox();
            grpCleaning = new GroupBox();
            chkWaterWash = new CheckBox();
            chkTransmissionClean = new CheckBox();
            grpOtherServices = new GroupBox();
            chkInspection = new CheckBox();
            chkReplaceMuffler = new CheckBox();
            chkTireRotation = new CheckBox();
            grpPartsLabor = new GroupBox();
            lblParts = new Label();
            txtParts = new TextBox();
            lblLaborHours = new Label();
            txtLaborHours = new TextBox();
            grpSummary = new GroupBox();
            lblServiceLabor = new Label();
            lblServiceLaborValue = new Label();
            lblPartsCost = new Label();
            lblPartsCostValue = new Label();
            lblPartsTax = new Label();
            lblPartsTaxValue = new Label();
            lblTotalCost = new Label();
            lblTotalCostValue = new Label();
            btnCalculate = new Button();
            btnClear = new Button();
            btnExit = new Button();
            grpOilLubrication.SuspendLayout();
            grpCleaning.SuspendLayout();
            grpOtherServices.SuspendLayout();
            grpPartsLabor.SuspendLayout();
            grpSummary.SuspendLayout();
            SuspendLayout();
            // 
            // grpOilLubrication
            // 
            grpOilLubrication.Controls.Add(chkReplaceOil);
            grpOilLubrication.Controls.Add(chkOilMaintenance);
            grpOilLubrication.Location = new Point(12, 12);
            grpOilLubrication.Name = "grpOilLubrication";
            grpOilLubrication.Size = new Size(240, 90);
            grpOilLubrication.TabIndex = 0;
            grpOilLubrication.TabStop = false;
            grpOilLubrication.Text = "機油和潤滑";
            // 
            // chkReplaceOil
            // 
            chkReplaceOil.AutoSize = true;
            chkReplaceOil.Location = new Point(12, 22);
            chkReplaceOil.Name = "chkReplaceOil";
            chkReplaceOil.Size = new Size(190, 27);
            chkReplaceOil.TabIndex = 0;
            chkReplaceOil.Text = "更換機油 (NT$780)";
            // 
            // chkOilMaintenance
            // 
            chkOilMaintenance.AutoSize = true;
            chkOilMaintenance.Location = new Point(12, 48);
            chkOilMaintenance.Name = "chkOilMaintenance";
            chkOilMaintenance.Size = new Size(190, 27);
            chkOilMaintenance.TabIndex = 1;
            chkOilMaintenance.Text = "潤滑保養 (NT$540)";
            // 
            // grpCleaning
            // 
            grpCleaning.Controls.Add(chkWaterWash);
            grpCleaning.Controls.Add(chkTransmissionClean);
            grpCleaning.Location = new Point(268, 12);
            grpCleaning.Name = "grpCleaning";
            grpCleaning.Size = new Size(240, 90);
            grpCleaning.TabIndex = 1;
            grpCleaning.TabStop = false;
            grpCleaning.Text = "清洗服務";
            // 
            // chkWaterWash
            // 
            chkWaterWash.AutoSize = true;
            chkWaterWash.Location = new Point(12, 22);
            chkWaterWash.Name = "chkWaterWash";
            chkWaterWash.Size = new Size(190, 27);
            chkWaterWash.TabIndex = 0;
            chkWaterWash.Text = "水箱清洗 (NT$900)";
            // 
            // chkTransmissionClean
            // 
            chkTransmissionClean.AutoSize = true;
            chkTransmissionClean.Location = new Point(12, 48);
            chkTransmissionClean.Name = "chkTransmissionClean";
            chkTransmissionClean.Size = new Size(222, 27);
            chkTransmissionClean.TabIndex = 1;
            chkTransmissionClean.Text = "變速箱清洗 (NT$2,400)";
            // 
            // grpOtherServices
            // 
            grpOtherServices.Controls.Add(chkInspection);
            grpOtherServices.Controls.Add(chkReplaceMuffler);
            grpOtherServices.Controls.Add(chkTireRotation);
            grpOtherServices.Location = new Point(12, 112);
            grpOtherServices.Name = "grpOtherServices";
            grpOtherServices.Size = new Size(240, 130);
            grpOtherServices.TabIndex = 2;
            grpOtherServices.TabStop = false;
            grpOtherServices.Text = "其他服務";
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
            // chkReplaceMuffler
            // 
            chkReplaceMuffler.AutoSize = true;
            chkReplaceMuffler.Location = new Point(12, 48);
            chkReplaceMuffler.Name = "chkReplaceMuffler";
            chkReplaceMuffler.Size = new Size(222, 27);
            chkReplaceMuffler.TabIndex = 1;
            chkReplaceMuffler.Text = "更換消音器 (NT$3,000)";
            // 
            // chkTireRotation
            // 
            chkTireRotation.AutoSize = true;
            chkTireRotation.Location = new Point(12, 74);
            chkTireRotation.Name = "chkTireRotation";
            chkTireRotation.Size = new Size(190, 27);
            chkTireRotation.TabIndex = 2;
            chkTireRotation.Text = "輪胎換位 (NT$600)";
            // 
            // grpPartsLabor
            // 
            grpPartsLabor.Controls.Add(lblParts);
            grpPartsLabor.Controls.Add(txtParts);
            grpPartsLabor.Controls.Add(lblLaborHours);
            grpPartsLabor.Controls.Add(txtLaborHours);
            grpPartsLabor.Location = new Point(268, 112);
            grpPartsLabor.Name = "grpPartsLabor";
            grpPartsLabor.Size = new Size(240, 130);
            grpPartsLabor.TabIndex = 3;
            grpPartsLabor.TabStop = false;
            grpPartsLabor.Text = "零件和工時";
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
            txtParts.Location = new Point(135, 22);
            txtParts.Name = "txtParts";
            txtParts.Size = new Size(89, 30);
            txtParts.TabIndex = 1;
            // 
            // lblLaborHours
            // 
            lblLaborHours.AutoSize = true;
            lblLaborHours.Location = new Point(12, 62);
            lblLaborHours.Name = "lblLaborHours";
            lblLaborHours.Size = new Size(117, 23);
            lblLaborHours.TabIndex = 2;
            lblLaborHours.Text = "工時數 (小時)";
            // 
            // txtLaborHours
            // 
            txtLaborHours.Location = new Point(135, 62);
            txtLaborHours.Name = "txtLaborHours";
            txtLaborHours.Size = new Size(89, 30);
            txtLaborHours.TabIndex = 3;
            // 
            // grpSummary
            // 
            grpSummary.Controls.Add(lblServiceLabor);
            grpSummary.Controls.Add(lblServiceLaborValue);
            grpSummary.Controls.Add(lblPartsCost);
            grpSummary.Controls.Add(lblPartsCostValue);
            grpSummary.Controls.Add(lblPartsTax);
            grpSummary.Controls.Add(lblPartsTaxValue);
            grpSummary.Controls.Add(lblTotalCost);
            grpSummary.Controls.Add(lblTotalCostValue);
            grpSummary.Location = new Point(12, 260);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(496, 234);
            grpSummary.TabIndex = 4;
            grpSummary.TabStop = false;
            grpSummary.Text = "費用摘要";
            // 
            // lblServiceLabor
            // 
            lblServiceLabor.AutoSize = true;
            lblServiceLabor.Location = new Point(12, 46);
            lblServiceLabor.Name = "lblServiceLabor";
            lblServiceLabor.Size = new Size(100, 23);
            lblServiceLabor.TabIndex = 0;
            lblServiceLabor.Text = "服務與工資";
            // 
            // lblServiceLaborValue
            // 
            lblServiceLaborValue.BorderStyle = BorderStyle.Fixed3D;
            lblServiceLaborValue.Location = new Point(166, 46);
            lblServiceLaborValue.Name = "lblServiceLaborValue";
            lblServiceLaborValue.Size = new Size(140, 30);
            lblServiceLaborValue.TabIndex = 1;
            lblServiceLaborValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPartsCost
            // 
            lblPartsCost.AutoSize = true;
            lblPartsCost.Location = new Point(12, 95);
            lblPartsCost.Name = "lblPartsCost";
            lblPartsCost.Size = new Size(46, 23);
            lblPartsCost.TabIndex = 2;
            lblPartsCost.Text = "零件";
            // 
            // lblPartsCostValue
            // 
            lblPartsCostValue.BorderStyle = BorderStyle.Fixed3D;
            lblPartsCostValue.Location = new Point(166, 88);
            lblPartsCostValue.Name = "lblPartsCostValue";
            lblPartsCostValue.Size = new Size(140, 30);
            lblPartsCostValue.TabIndex = 3;
            lblPartsCostValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPartsTax
            // 
            lblPartsTax.AutoSize = true;
            lblPartsTax.Location = new Point(12, 137);
            lblPartsTax.Name = "lblPartsTax";
            lblPartsTax.Size = new Size(99, 23);
            lblPartsTax.TabIndex = 4;
            lblPartsTax.Text = "稅金 (零件)";
            // 
            // lblPartsTaxValue
            // 
            lblPartsTaxValue.BorderStyle = BorderStyle.Fixed3D;
            lblPartsTaxValue.Location = new Point(166, 130);
            lblPartsTaxValue.Name = "lblPartsTaxValue";
            lblPartsTaxValue.Size = new Size(140, 30);
            lblPartsTaxValue.TabIndex = 5;
            lblPartsTaxValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Location = new Point(12, 182);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(64, 23);
            lblTotalCost.TabIndex = 6;
            lblTotalCost.Text = "總費用";
            // 
            // lblTotalCostValue
            // 
            lblTotalCostValue.BorderStyle = BorderStyle.Fixed3D;
            lblTotalCostValue.Location = new Point(166, 178);
            lblTotalCostValue.Name = "lblTotalCostValue";
            lblTotalCostValue.Size = new Size(140, 30);
            lblTotalCostValue.TabIndex = 7;
            lblTotalCostValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(24, 520);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(100, 28);
            btnCalculate.TabIndex = 5;
            btnCalculate.Text = "計算總額";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(207, 520);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 28);
            btnClear.TabIndex = 6;
            btnClear.Text = "清除";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(392, 520);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 28);
            btnExit.TabIndex = 7;
            btnExit.Text = "離開";
            // 
            // Form1
            // 
            ClientSize = new Size(526, 580);
            Controls.Add(grpOilLubrication);
            Controls.Add(grpCleaning);
            Controls.Add(grpOtherServices);
            Controls.Add(grpPartsLabor);
            Controls.Add(grpSummary);
            Controls.Add(btnCalculate);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "汽車維修服務";
            grpOilLubrication.ResumeLayout(false);
            grpOilLubrication.PerformLayout();
            grpCleaning.ResumeLayout(false);
            grpCleaning.PerformLayout();
            grpOtherServices.ResumeLayout(false);
            grpOtherServices.PerformLayout();
            grpPartsLabor.ResumeLayout(false);
            grpPartsLabor.PerformLayout();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
