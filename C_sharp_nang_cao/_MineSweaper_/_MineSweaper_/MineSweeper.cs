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
    public partial class MineSweeper : Form
    {
        public MineSweeper()
        {
            InitializeComponent();
        }
        private int getLevel()
        {
            FileStream fs = new FileStream("level.txt", FileMode.Open);
            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            String value = rd.ReadToEnd();// ReadLine() chỉ đọc 1 dòng đầu thoy, ReadToEnd là đọc hết
            int level = Convert.ToInt32(value[0]);
            rd.Close();
            return level - 48;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            
            Option option = new Option(getLevel());
            option.Show();
        }

        private void MineSweeper_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game game = new Game(getLevel());
            game.Show();
        }
    }
}
