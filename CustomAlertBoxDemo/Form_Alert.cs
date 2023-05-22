using CustomAlertBoxDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomAlertBoxDemo
{
    public partial class Form_Alert : Form
    {
        public Form_Alert()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private Form_Alert.enmAction action;

        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 3000;
                    action = enmAction.close;
                    break;
                case Form_Alert.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = Form_Alert.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;// take location as in control
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Form_Alert frm = (Form_Alert)Application.OpenForms[fname];//Logic : take the current open Form

                if (frm == null)
                {
                    this.Name = fname;
                    //The Working Area is Destop Area of the display
                    // this.width is the width of Form defined in Control
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15; //MediaQuery : take width of Screen
                    //this.x = Screen.PrimaryScreen.WorkingArea.Width - (this.Width + 5) * i;
                   // this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;//take Screen Height
                    /*When i=0 => start at 0,0 y=> - 3*0-5*0 =0
                     * i => 1 start at 0,8 y => -3*1-5*1=8 (0,8)
                     * i => 2 start at 0,16 y => 16
                     * Formula : (height+gap)*i;
                     */
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch(type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.lblMsg.Text = msg;

            this.Show(); //the main to show Form
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
