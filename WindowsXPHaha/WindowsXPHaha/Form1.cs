using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsXPHaha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_Load(object sender, EventArgs e)
        {
            xx = this.Left;
            yy = this.Top;
            _myProperty = 1;
        }

        private void HeaderTab_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                dewd();
            }
        }

        public void SetText(string txt)
        {
            label2.Text = txt;
        }

        public void Drag(int xi, int yi)
        {
            Form1 f1 = new Form1();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Left = xi;
            f1.Top = yi;
            f1.Show();
        }

        
        public int _myProperty;
                
        public int MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {                
                //The property changed event will get fired whenever
                //the value changes. The subscriber will do work if the value is
                //1. This way you can keep your business logic outside of the setter
                if (value != _myProperty)
                {
                    _myProperty = value;
                    DoWorkOnMyProperty();
                }                
            }
        }               

        void DoWorkOnMyProperty()
        {
            //get position
            //put in static var
            //sense significant change
            //create new form in previous location
            Drag(xx, yy);
        }

        private void dewd()
        {
            int x, y;
            x = this.Left;
            y = this.Top;
            if (x != xx || y != yy)
            {
                xx = x;
                yy = y;
                _myProperty++;
            }

        }

        public static int yy;
        public static int xx;

    


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
