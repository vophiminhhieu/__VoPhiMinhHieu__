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
namespace _MineSweaper_
{
    public partial class Option : Form
    {
        private int level;
        public Option(int _level_)
        {
            level = _level_;
            InitializeComponent();
            button_set_level(level);
        }
        private void button_set_level(int level)
        {
            if (level == 1)
            {
                button1.Text = "Mức độ: Dễ";
            }
            else if (level == 2)
            {
                button1.Text = "Mức độ: Trung Bình";
            }
            else if (level == 3)
            {
                button1.Text = "Mức độ: Khó";
            }
            else
            {
                button1.Text = "" + level;
            }
        }
        private void Option_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (level < 3)
            {
                level++;
            }
            else
            {
                level = 1;
            }
            button_set_level(level);
            FileStream fs = new FileStream("level.txt", FileMode.Open);
            StreamWriter wt = new StreamWriter(fs, Encoding.UTF8);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String value = "" + level;
            wt.Write(value);
            wt.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MineSweeper mine = new MineSweeper();
            mine.Show();
        }
    }
}
