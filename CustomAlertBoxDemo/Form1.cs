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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg,type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Alert("Success Alert",Form_Alert.enmType.Success);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Alert("Warning Alert", Form_Alert.enmType.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Alert("Error Alert", Form_Alert.enmType.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Alert("Info Alert", Form_Alert.enmType.Info);
        }
    }
}
