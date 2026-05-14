using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The GetPhoneData method accepts a CellPhone object
        // as an argument. It assigns the data entered by the
        // user to the object's properties.
        private void GetPhoneData(CellPhone phone)
        {
            phone.Brand = this.brandTextBox.Text;
            phone.Model = this.modelTextBox.Text;
            if (decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                phone.Price = (double)price;
            }
            else
            {
                MessageBox.Show("請輸入有效的價格");
                phone.Price = 0;
            }

        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myphone = new CellPhone();
            GetPhoneData(myphone);
            this.outputBrandLabel.Text = myphone.Brand;
            this.outputModelLabel.Text = myphone.Model;
            this.outputPriceLabel.Text = myphone.Price.ToString("C");

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void enterDataGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void outputBrandLabel_Click(object sender, EventArgs e)
        {

        }

        private void outputPriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void brandLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
