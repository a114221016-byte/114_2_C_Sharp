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

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void getScoresButton_Click(object sender, EventArgs e)
        {
          string filePath = "TestScores.txt";
            try
            {
                // Read all lines from the file and display them in the list box.
                string[] scores = File.ReadAllLines(filePath);
                testScoresListBox.Items.Clear();
                testScoresListBox.Items.AddRange(scores);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file 'TestScores.txt' was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double Average(List<double> scores)
        {
            if (scores.Count == 0)
                return 0;
            double sum = scores.Sum();
            return sum / scores.Count;
        }

        private int AboveAverage(List<int>scoresList,double avg)
        {
            int count = 0;
            foreach (int score in scoresList)
            {
                if (score > avg)
                    count++;
            }
            return count;
        }
        private int BelowAverage(List<int> scoresList, double avg)
        {
            int count = 0;
            foreach (int score in scoresList)
            {
                if (score < avg)
                    count++;
            }
            return count;
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            int searchScore;
            int position;

            if(!int.TryParse(searchTextBox.Text, out searchScore))
            {
                searchResultLabel.Text = "Please enter a valid integer score.";
                return;
            }   
            if((position=testScoresListBox.Items.IndexOf(searchScore.ToString())) != -1)
            {
                searchResultLabel.Text = $"Score {searchScore} found at position {position}.";
            }
            else
            {
                searchResultLabel.Text = $"Score {searchScore} not found in the list.";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
