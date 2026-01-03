using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polibius_cipher.Forms
{
    public partial class Encrypt : Form
    {

        char[,] table = new char[12, 12]{
        {'a','b','c','d','e','f','g','h','i','j','k','l'},
        {'m','n','o','p','q','r','s','t','u','v','w','x'},
        {'y','z','A','B','C','D','E','F','G','H','I','J'},
        {'K','L','M','N','O','P','Q','R','S','T','U','V'},
        {'W','X','Y','Z','0','1','2','3','4','5','6','7'},
        {'8','9','а','б','в','г','ґ','д','е','є','ж','з'},
        {'и','і','ї','й','к','л','м','н','о','п','р','с'},
        {'т','у','ф','х','ц','ч','ш','щ','ь','ю','я','А'},
        {'Б','В','Г','Ґ','Д','Е','Є','Ж','З','И','І','Ї'},
        {'Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф'},
        {'Х','Ц','Ч','Ш','Щ','Ь','Ю','Я',' ','.',',','?'},
        {'!','ъ','Ъ','#','ы','Ы','%','э','Э','*','(',')'}
        };

        public Encrypt()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            lblInput.ForeColor = ThemeColor.SecondaryColor;
            lblOutput.ForeColor = ThemeColor.SecondaryColor;
        }

        private void Encrypt_Load(object sender, EventArgs e)
        {
            LoadTheme();
            textBox1.MaxLength = 300;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog.FileName, textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBox1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
        }

        char[] noChar = new char[] { '@', '$', '"', '^', '&', '_', '-', '+', '=', '\\', '\'', '|', '/', ';', ':'};

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach(char s in noChar)
            {
                if (e.KeyChar == s)
                {
                    e.Handled = true;
                    MessageBox.Show("Не вірний символ", "Помилка");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] text = textBox1.Text.ToCharArray();
                string textEncrypt = "";

                for (int k = 0; k < text.Length; k++)
                    for (int i = 0; i < 12; i++)
                        for (int j = 0; j < 12; j++)
                        {
                            if (table[i, j] == text[k])
                            {
                                textEncrypt += Convert.ToString(table[0, j]) + Convert.ToString(table[0, i]);
                            }
                        }
                textBox2.Text = textEncrypt;
            }
            catch
            {
                textBox1.Text = "";
                MessageBox.Show("Введені не вірні символи", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
