using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // Field to hold a list of PhoneBookEntry objects.
        private List<PhoneBookEntry> phoneList = 
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // The ReadFile method reads the contents of the
        // PhoneList.txt file and stores it as PhoneBookEntry
        // objects in the phoneList.
        private void ReadFile()
        {
            try
            {
                StreamReader inputFiles;
                string line;
                char[] delimiters = { ',' };
                PhoneBookEntry entry = new PhoneBookEntry();

                using (inputFiles = File.OpenText("PhoneList.txt"))
                {
                    while (!inputFiles.EndOfStream)
                    {
                        line = inputFiles.ReadLine();
                        string[] fields = line.Split(delimiters);
                        entry.name = fields[0];
                        entry.phone = fields[1];
                        phoneList.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message);
            }
        }

        // The DisplayNames method displays the list of names
        // in the namesListBox control.
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           ReadFile();
            DisplayNames();
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1)
            {
                string phone = phoneList[index].phone;
                phoneLabel.Text = phone;
            }
            }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉視窗：這裡簡單關閉表單即可結束應用程式（若為主窗體）。
            this.Close();
        }
    }
}
