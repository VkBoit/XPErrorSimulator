using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsXPHaha
{
    public partial class MainF : Form
    {
        public MainF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)nud1.Value;
            for (int i = 1; i <= n; i++)
            {
                Form1 f1 = new Form1();
                f1.SetText(textBox1.Text);


                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
                int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
                //f1.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
                int x = w / n;
                int y = h / n;

                f1.StartPosition = FormStartPosition.Manual;
                f1.Left = x * i;
                f1.Top = y * i;
                f1.Show();
            }
        }
    }
}
