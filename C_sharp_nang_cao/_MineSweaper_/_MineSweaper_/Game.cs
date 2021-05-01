using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _MineSweaper_
{
    public partial class Game : Form
    {
        private int level;
        private bool[][] Flag;
        private bool[][] isClick;
        private Board board;
        private int numBoom;
        private Button[][] buttons;
        private PictureBox pic;
        private Button BTNlose;
        private Button BTNwin;
        private Button BTNnext;
        public Game(int _level_)
        {
            InitializeComponent();
            level = _level_;
            Flag = new bool[10][];
            isClick = new bool[10][];
            buttons = new Button[10][];
            for(int i = 0; i < 10; i++)
            {
                Flag[i] = new bool[15];
                isClick[i] = new bool[15];
                buttons[i] = new Button[15];
                for(int j = 0; j < 15; j++)
                {
                    Flag[i][j] = false;
                    isClick[i][j] = false;
                    AddButton(i, j);
                }
            }
            AddPicture();
            numBoom = 20;
            board = new Board(_level_,numBoom);
            prepareButtonWL();
        }
        private void playAgain(object sender, MouseEventArgs e)
        {
            this.Hide();
            Game game = new Game(level);
            game.Show();
        }
        private void nextMatch(object sender,MouseEventArgs e)
        {
            this.Hide();
            if (level < 3)
            {
                level++;
            }
            Game game = new Game(level);
            game.Show();
        }
        private void AddPicture()
        {
            string _img = "";
            if (level == 1)
            {
                _img += "easy.PNG";
            }
            else if (level == 2)
            {
                _img += "medium.PNG";
            }
            else
            {
                _img += "hard.PNG";
            }
            Image img = Image.FromFile(@"image\" + _img);
            pic = new PictureBox();
            pic.BackgroundImage = img;
            pic.Location = new Point(323, 33);
            pic.Size = new Size(220, 61);
            this.Controls.Add(pic);
        }
        private void prepareButtonWL()
        {
            BTNlose = new Button() ;
            BTNlose.Location = new Point(310, 560);
            BTNlose.Size = new Size(219, 62);
            BTNlose.FlatStyle = FlatStyle.Flat;
            BTNlose.FlatAppearance.BorderColor = Color.FromArgb(20, 30, 44);
            Image img = Image.FromFile(@"image\again.PNG");
            BTNlose.BackgroundImage = img;
            BTNlose.MouseUp += playAgain;
            BTNwin = BTNlose;
            BTNnext = new Button();
            BTNnext.Location = new Point(537, 559);
            BTNnext.Size = new Size(219, 62);
            BTNnext.FlatStyle = FlatStyle.Flat;
            BTNnext.FlatAppearance.BorderColor = Color.FromArgb(20, 30, 44);
            Image _img = Image.FromFile(@"image\next.PNG");
            BTNnext.BackgroundImage = _img;
            BTNnext.MouseUp += nextMatch;
        }
        private void AddButton(int i,int j)
        {
            Image img = Image.FromFile(@"image\node.PNG");
            buttons[i][j] = new Button() { Text = "", Name=""+((i*15)+j) };
            buttons[i][j].BackgroundImage = img;
            buttons[i][j].Location = new Point(132+36*j, 157+36*i);
            buttons[i][j].Size = new Size(30, 30);
            buttons[i][j].MouseUp += btn_Mouse_Up;
            buttons[i][j].FlatStyle = FlatStyle.Flat;
            buttons[i][j].FlatAppearance.BorderColor = Color.FromArgb(20, 30, 44);
            this.Controls.Add(buttons[i][j]);
        }
        private void btn_Mouse_Up(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            int a = Convert.ToInt32(button.Name);
            int x = a / 15;
            int y = a % 15;
            if (e.Button == MouseButtons.Right&&isClick[x][y]==false)
            {
                if (Flag[x][y] == false)
                {
                    Flag[x][y] = true;
                    Image img = Image.FromFile(@"image\flag.PNG");
                    button.BackgroundImage = img;
                }
                else
                {
                    Flag[x][y] = false;
                    Image img = Image.FromFile(@"image\node.PNG");
                    button.BackgroundImage = img;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (board.get(x, y) == -1 && Flag[x][y]==false)
                {
                    Lose();
                }
                else if (isClick[x][y] == false)
                {
                    getSpaceOneNode(x, y);
                    if (checkWin() == true)
                    {
                        Win();
                    }
                }
            }
        }
        private void Lose()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (board.get(i, j) == -1)
                    {
                        printNode(i, j);
                    }
                }
            }
            MessageBox.Show("Bạn đã thua");
            Thread.Sleep(400);
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    printNode(i, j);
                    buttons[i][j].MouseUp -= btn_Mouse_Up;
                    buttons[i][j].MouseUp += eventBtn;
                }
            }
            this.Controls.Add(BTNlose);
        }
        private void Win()
        {
            MessageBox.Show("Bạn đã thắng");
            this.Controls.Add(BTNwin);
            this.Controls.Add(BTNnext);
        }
        private bool checkWin()
        {
            int result = 0;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    if (isClick[i][j] == false)
                    {
                        result++;
                    }
                }
            }
            if (result == numBoom)
            {
                return true;
            }
            return false;
        }
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void eventBtn(object sender, MouseEventArgs e)
        {
        }
        private void printNode(int x,int y)
        {
            if (Flag[x][y] == true)
            {
                return;
            }
            if (board.get(x, y) != -1)
            {
                isClick[x][y] = true;
            }
            string nameImg = "" + board.get(x, y) + ".PNG";
            Image img = Image.FromFile(@"image\"+nameImg);
            buttons[x][y].BackgroundImage = img;
        }
        public void getSpaceOneNode(int x, int y)
        {
            if (Flag[x][y] == true)
            {
                return;
            }
            if (board.get(x,y) != 0)
            {
                printNode(x, y);
                return;
            }
            printNode(x, y);
            if (x - 1 >= 0 && y - 1 >= 0 && isClick[x - 1][y - 1] == false)
            {
                getSpaceOneNode(x - 1, y - 1);
            }
            if (x - 1 >= 0 && isClick[x - 1][y] == false)
            {
                getSpaceOneNode(x - 1, y);
            }
            if (x - 1 >= 0 && y + 1 < 15 && isClick[x - 1][y + 1] == false)
            {
                getSpaceOneNode(x - 1, y + 1);
            }
            if (y + 1 < 15 && isClick[x][y + 1] == false)
            {
                getSpaceOneNode(x, y + 1);
            }
            if (y - 1 >= 0 && isClick[x][y - 1] == false)
            {
                getSpaceOneNode(x, y - 1);
            }
            if (x + 1 < 10 && y + 1 < 15 && isClick[x + 1][y + 1]==false)
            {
                getSpaceOneNode(x + 1, y + 1);
            }
            if (x + 1 < 10 && isClick[x + 1][y] == false)
            {
                getSpaceOneNode(x + 1, y);
            }
            if (x + 1 < 10 && y - 1 >= 0 && isClick[x + 1][y - 1]==false)
            {
                getSpaceOneNode(x + 1, y - 1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MineSweeper mine = new MineSweeper();
            mine.Show();
        }
    }
}
