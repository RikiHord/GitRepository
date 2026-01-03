using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Great_Town
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeThePlayingField();
        }

        #region InitializeThePlayingField

        const int THE_SIZE_OF_THE_GAME_FIELD = 10;
        const int NUMBER_OF_WALLS_ON_THE_GAME_FIELD = 10;

        Random random = new Random();
        int clearArea = (int)Math.Pow(THE_SIZE_OF_THE_GAME_FIELD, 2) - NUMBER_OF_WALLS_ON_THE_GAME_FIELD;
        string currentName;
        Color currentColor;

        Class.TypeArea[,] game_field = new Class.TypeArea[THE_SIZE_OF_THE_GAME_FIELD , THE_SIZE_OF_THE_GAME_FIELD];

        public void InitializeThePlayingField()
        {
            for(int x_pos = 0; x_pos < 10; x_pos++)
            {
                for(int y_pos = 0; y_pos < 10; y_pos++)
                {
                    Button button = new Button();
                    tlp_GameField.Controls.Add(button, x_pos, y_pos);
                    Control cell = tlp_GameField.GetControlFromPosition(x_pos, y_pos) as Control;
                    cell.Dock = DockStyle.Fill;
                    cell.Click += btn_area_Click;
                    cell.Tag = new Point(x_pos, y_pos);
                    game_field[x_pos, y_pos] = new Class.TypeArea("NULL", Color.White);
                }
            }
            RandomWalls(NUMBER_OF_WALLS_ON_THE_GAME_FIELD);
        }

        public void RandomWalls(int countWalls)
        {
            for(int countWall = 0; countWall < countWalls; countWall++)
            {
                int position = random.Next(0, (int)Math.Pow(THE_SIZE_OF_THE_GAME_FIELD,2));
                int x_pos = position / THE_SIZE_OF_THE_GAME_FIELD;
                int y_pos = position % THE_SIZE_OF_THE_GAME_FIELD;
                IsWall(x_pos, y_pos);
            }
        }

        public void IsWall(int x_pos, int y_pos)
        {
            if(game_field[x_pos,y_pos].Name == "Wall")
            {
                int position = random.Next(0, (int)Math.Pow(THE_SIZE_OF_THE_GAME_FIELD, 2));
                x_pos = position / THE_SIZE_OF_THE_GAME_FIELD;
                y_pos = position % THE_SIZE_OF_THE_GAME_FIELD;
                IsWall(x_pos, y_pos);
            }
            else
            {
                Control wall = tlp_GameField.GetControlFromPosition(x_pos, y_pos) as Control;
                wall.BackColor = Color.Black;
                wall.Enabled = false;
                game_field[x_pos, y_pos] = new Class.TypeArea("Wall", Color.Black);
                console.Text += "\t Add wall in pos (" + x_pos + ", " + y_pos + ")\n";
            }
        }

        #endregion

        #region createObject

        private void btn_choiseHouse_Click(object sender, EventArgs e)
        {
            currentName = "House";
            currentColor = Color.Green; 
        }

        private void btn_choisePark_Click(object sender, EventArgs e)
        {
            currentName = "Park";
            currentColor = Color.Gold;
        }

        public void btn_area_Click(object sender, EventArgs e)
        {
            Point p = (Point)((Button)sender).Tag;
            Control cell = tlp_GameField.GetControlFromPosition(p.X, p.Y) as Control;
            cell.BackColor = currentColor;
            cell.Enabled = false;
            game_field[p.X, p.Y] = new Class.TypeArea(currentName, currentColor);
            switch (currentName)
            {
                case "House":
                    cell.Text = "1";
                    l_pointsCount.Text = Convert.ToString(Convert.ToInt32(l_pointsCount.Text) + 1);
                    break;
                default:
                    cell.Text = "0";
                    break;
            }
            console.Text += "\t Add house in pos (" + p.X + ", " + p.Y + ")\n";
            --clearArea;
            Recalculation(currentName, p.X, p.Y);
            if(clearArea == 0)
            {
                MessageBox.Show("Вы набрали "+ l_pointsCount.Text + " очков!");
            }
        }

        #endregion

        #region Counting points

        public void Recalculation(string type, int x_pos, int y_pos)
        {
            if(type == "House")
            {
                RecalculationHouse(x_pos, y_pos, true);
            }
            if (type == "Park")
            {
                RecalculationPark(x_pos, y_pos);
            }
        }

        public void RecalculationHouse(int x_pos, int y_pos, bool recN)
        {
            Control house = tlp_GameField.GetControlFromPosition(x_pos, y_pos) as Control;
            l_pointsCount.Text = Convert.ToString(Convert.ToInt32(l_pointsCount.Text) - Convert.ToInt32(house.Text));
            int points = 1;
            bool x2 = false;
            if(x_pos >= 1)
            {
                rec(game_field[x_pos - 1, y_pos].Name);
                if (recN && game_field[x_pos - 1, y_pos].Name == "House") RecalculationHouse(x_pos - 1, y_pos, false);
            }
            if(x_pos <= 8)
            {
                rec(game_field[x_pos + 1, y_pos].Name);
                if (recN && game_field[x_pos + 1, y_pos].Name == "House") RecalculationHouse(x_pos + 1, y_pos, false);
            }
            if (y_pos >= 1)
            {
                rec(game_field[x_pos, y_pos - 1].Name);
                if (recN && game_field[x_pos, y_pos - 1].Name == "House") RecalculationHouse(x_pos, y_pos - 1, false);
            }
            if (y_pos <= 8)
            {
                rec(game_field[x_pos, y_pos + 1].Name);
                if (recN && game_field[x_pos, y_pos + 1].Name == "House") RecalculationHouse(x_pos, y_pos + 1, false);
            }
            void rec(string neighbor)
            {
                switch (neighbor)
                {
                    case "NULL":
                        break;
                    case "House":
                        ++points;
                        break;
                    case "Park":
                        x2 = true;
                        break;
                }
            }
            if (x2)
            {
                points *= 2;
            }
            l_pointsCount.Text = Convert.ToString(Convert.ToInt32(l_pointsCount.Text) + points);
            house.Text = Convert.ToString(points);
        }

        public void RecalculationPark(int x_pos, int y_pos)
        {
            if (x_pos >= 1)
            {
                if (game_field[x_pos - 1, y_pos].Name == "House") RecalculationHouse(x_pos - 1, y_pos, false);
            }
            if (x_pos <= 8)
            {
                if (game_field[x_pos + 1, y_pos].Name == "House") RecalculationHouse(x_pos + 1, y_pos, false);
            }
            if (y_pos >= 1)
            {
                if (game_field[x_pos, y_pos - 1].Name == "House") RecalculationHouse(x_pos, y_pos - 1, false);
            }
            if (y_pos <= 8)
            {
                if (game_field[x_pos, y_pos + 1].Name == "House") RecalculationHouse(x_pos, y_pos + 1, false);
            }
        }
        #endregion

        #region delete

        private void btn_del1_Click(object sender, EventArgs e)
        {
            tlp_GameField.Controls.Clear();
            console.Clear();
            l_pointsCount.Text = "0";
            clearArea = (int)Math.Pow(THE_SIZE_OF_THE_GAME_FIELD, 2) - NUMBER_OF_WALLS_ON_THE_GAME_FIELD;
            InitializeThePlayingField();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int x_pos = 0; x_pos < 10; x_pos++)
            {
                for (int y_pos = 0; y_pos < 10; y_pos++)
                {
                    console.Text += game_field[x_pos, y_pos].Name + " ";
                }
                console.Text += "\n";
            }
        }

        #endregion

    }
}
