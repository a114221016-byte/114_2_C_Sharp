using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Reveiw_Q3
{
    partial class Form1
    {
        private IContainer components = null;

        // UI 元件（改為個別 Label）
        private Label lblNumber1;
        private Label lblNumber2;
        private Label lblNumber3;
        private Label lblNumber4;
        private Label lblNumber5;
        private FlowLayoutPanel flowNumbers;
        private FlowLayoutPanel flowButtons;
        private Button btnGenerate;
        private Button btnLoad;
        private Button btnCompare;
        private Button btnExit;
        private GroupBox groupTop;
        private GroupBox groupLeft;
        private GroupBox groupRight;
        private ListBox lstWinningNumbers;
        private Panel panelCompareResult;
        private Label lblCompareResultTitle;
        private Label lblCompareResult;
        private OpenFileDialog openFileDialog1;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
            this.components = new Container();
            this.groupTop = new GroupBox();
            this.flowNumbers = new FlowLayoutPanel();
            this.lblNumber1 = new Label();
            this.lblNumber2 = new Label();
            this.lblNumber3 = new Label();
            this.lblNumber4 = new Label();
            this.lblNumber5 = new Label();
            this.flowButtons = new FlowLayoutPanel();
            this.btnGenerate = new Button();
            this.btnLoad = new Button();
            this.btnCompare = new Button();
            this.btnExit = new Button();
            this.groupLeft = new GroupBox();
            this.lstWinningNumbers = new ListBox();
            this.groupRight = new GroupBox();
            this.panelCompareResult = new Panel();
            this.lblCompareResultTitle = new Label();
            this.lblCompareResult = new Label();
            this.openFileDialog1 = new OpenFileDialog();

            // 標準設計器佈局保護
            this.SuspendLayout();
            //
            // Form1
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(880, 520);
            this.Text = "樂透號碼產生器";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Form1";

            //
            // groupTop
            //
            this.groupTop.Name = "groupTop";
            this.groupTop.Text = "樂透號碼產生器";
            this.groupTop.Location = new Point(12, 12);
            this.groupTop.Size = new Size(856, 170);
            this.groupTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            //
            // flowNumbers
            //
            this.flowNumbers.Name = "flowNumbers";
            this.flowNumbers.Location = new Point(16, 28);
            this.flowNumbers.Size = new Size(824, 80);
            this.flowNumbers.FlowDirection = FlowDirection.LeftToRight;
            this.flowNumbers.WrapContents = false;
            this.flowNumbers.Padding = new Padding(6);
            this.flowNumbers.AutoSize = false;
            this.flowNumbers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // create 5 number labels (individual controls for designer)
            var labels = new[] { this.lblNumber1, this.lblNumber2, this.lblNumber3, this.lblNumber4, this.lblNumber5 };
            for (int i = 0; i < labels.Length; i++)
            {
                var lbl = new Label();
                lbl.Name = "lblNumber" + (i + 1).ToString();
                lbl.Size = new Size(90, 90);
                lbl.Margin = new Padding(10);
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
                lbl.Text = "-";
                labels[i] = lbl;
                this.flowNumbers.Controls.Add(lbl);
            }

            // assign back to fields so designer/runtime can access them
            this.lblNumber1 = labels[0];
            this.lblNumber2 = labels[1];
            this.lblNumber3 = labels[2];
            this.lblNumber4 = labels[3];
            this.lblNumber5 = labels[4];

            //
            // flowButtons
            //
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Location = new Point(16, 115);
            this.flowButtons.Size = new Size(824, 40);
            this.flowButtons.FlowDirection = FlowDirection.LeftToRight;
            this.flowButtons.WrapContents = false;
            this.flowButtons.Padding = new Padding(6);
            this.flowButtons.AutoSize = false;
            this.flowButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            //
            // btnGenerate
            //
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Text = "產生號碼";
            this.btnGenerate.Size = new Size(140, 36);
            this.btnGenerate.Margin = new Padding(10);

            //
            // btnLoad
            //
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Text = "讀取開獎號碼";
            this.btnLoad.Size = new Size(140, 36);
            this.btnLoad.Margin = new Padding(10);

            //
            // btnCompare
            //
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Text = "中獎比對";
            this.btnCompare.Size = new Size(140, 36);
            this.btnCompare.Margin = new Padding(10);

            //
            // btnExit
            //
            this.btnExit.Name = "btnExit";
            this.btnExit.Text = "離開";
            this.btnExit.Size = new Size(140, 36);
            this.btnExit.Margin = new Padding(10);

            // add buttons to flow
            this.flowButtons.Controls.Add(this.btnGenerate);
            this.flowButtons.Controls.Add(this.btnLoad);
            this.flowButtons.Controls.Add(this.btnCompare);
            this.flowButtons.Controls.Add(this.btnExit);

            // add number flow and button flow to groupTop
            this.groupTop.Controls.Add(this.flowNumbers);
            this.groupTop.Controls.Add(this.flowButtons);

            //
            // groupLeft (ListBox)
            //
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Text = "檔案開獎號碼";
            this.groupLeft.Location = new Point(12, 190);
            this.groupLeft.Size = new Size(440, 320);
            this.groupLeft.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            this.lstWinningNumbers.Name = "lstWinningNumbers";
            this.lstWinningNumbers.Location = new Point(12, 24);
            this.lstWinningNumbers.Size = new Size(412, 284);
            this.lstWinningNumbers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.groupLeft.Controls.Add(this.lstWinningNumbers);

            //
            // groupRight (比對結果)
            //
            this.groupRight.Name = "groupRight";
            this.groupRight.Text = "中獎比對結果";
            this.groupRight.Location = new Point(468, 190);
            this.groupRight.Size = new Size(400, 320);
            this.groupRight.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            this.panelCompareResult.Name = "panelCompareResult";
            this.panelCompareResult.Location = new Point(12, 24);
            this.panelCompareResult.Size = new Size(376, 284);
            this.panelCompareResult.BorderStyle = BorderStyle.FixedSingle;
            this.panelCompareResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            this.lblCompareResultTitle.Name = "lblCompareResultTitle";
            this.lblCompareResultTitle.Text = "比對結果：";
            this.lblCompareResultTitle.Location = new Point(8, 8);
            this.lblCompareResultTitle.AutoSize = true;
            this.lblCompareResultTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            this.lblCompareResult.Name = "lblCompareResult";
            this.lblCompareResult.Text = "尚未比對";
            this.lblCompareResult.Location = new Point(8, 36);
            this.lblCompareResult.Size = new Size(356, 232);
            this.lblCompareResult.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCompareResult.BorderStyle = BorderStyle.None;
            this.lblCompareResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            this.panelCompareResult.Controls.Add(this.lblCompareResultTitle);
            this.panelCompareResult.Controls.Add(this.lblCompareResult);
            this.groupRight.Controls.Add(this.panelCompareResult);

            //
            // openFileDialog1
            //
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            this.openFileDialog1.Title = "選擇開獎號碼檔案";

            // add top and groups to form
            this.Controls.Add(this.groupTop);
            this.Controls.Add(this.groupLeft);
            this.Controls.Add(this.groupRight);

            // Resume layout
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
