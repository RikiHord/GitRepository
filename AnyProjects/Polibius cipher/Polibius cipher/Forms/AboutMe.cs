using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polibius_cipher.Forms
{
    public partial class AboutMe : Form
    {
        public AboutMe()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control panels in this.Controls)
            {
                if (panels.GetType() == typeof(Panel))
                {
                    Panel panel = (Panel)panels;
                    panel.BackColor = ThemeColor.SecondaryColor;
                    foreach (Control rtboxs in panel.Controls)
                    {
                        if (rtboxs.GetType() == typeof(RichTextBox))
                        {
                            RichTextBox richTextBox = (RichTextBox)rtboxs;
                            richTextBox.BackColor = ThemeColor.SecondaryColor;
                        }
                    }
                }
            }
        }

        private void AboutMe_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
