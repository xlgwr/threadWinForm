using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MachineSystem.UserControls;

namespace FrmDemoControl
{
    public partial class Form1 : Form
    {
        frmMain _tmpfrmain;
        public Form1()
        {
            InitializeComponent();
            initwith();
            initfirst();
            
        }
        private void initfirst()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += Form1_Resize;
            //throw new NotImplementedException();


        }

        void Form1_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            initwith();
        }
        private void initwith()
        {
            //throw new NotImplementedException();
            groupBox1.Width = this.Width - groupBox1.Left - 25;

            groupBox2.Left = groupBox1.Left;
            groupBox2.Width = groupBox1.Width;
            groupBox2.Height = this.Height - groupBox2.Top - 50;

        }


        public Form1(frmMain tmpfrmain)
        {
            InitializeComponent();
            _tmpfrmain = tmpfrmain;
            initfirst();
        }

        private void initForm1()
        {

            for (int i = 0; i <= this.numericUpDown1.Value; i++)
            {
                var clpersonlist = new UserPerson();
                clpersonlist.Top = i * clpersonlist.Height;
                this.flowLayoutPanel1.Controls.Add(clpersonlist);
            }
            //throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            initForm1();
        }

    }
}
