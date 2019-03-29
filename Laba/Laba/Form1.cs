using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            this.Controls.Add(Draw.GetNewPictureBox());
            Control.InitializeControl();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    {
                        Control.DoMove(Keys.Up);
                        break;
                    }
                case Keys.Down:
                case Keys.S:
                    {
                        Control.DoMove(Keys.Down);
                        break;
                    }
                case Keys.Right:
                case Keys.D:
                    {
                        Control.DoMove(Keys.Right);
                        break;
                    }
                case Keys.Left:
                case Keys.A:
                    {
                        Control.DoMove(Keys.Left);
                        break;
                    }
            }
        }
    }
}
