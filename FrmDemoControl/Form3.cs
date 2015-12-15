using MachineSystem.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrmDemoControl
{
    public partial class Form3 : Form
    {


        Random _rd = new Random();
        public Form3()
        {
            InitializeComponent();
            this.Activated += Form2_Activated;
            this.FormClosing += Form3_FormClosing;


        }

        void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            
            this.Hide();
            e.Cancel = true;
        }
        public Form3(Control[] cl)
        {
            InitializeComponent();

            groupBox1.Controls.AddRange(cl);

            this.Activated += Form2_Activated;
            this.FormClosing += Form3_FormClosing;

        }
        int _isNum = 0;
        private void Form2_Activated(object sender, EventArgs e)
        {
            //this.Text += "a" + _isNum;
            //if (_isNum % 2 == 0)
            //{
            //    setPostName(true);
            //}
            //else
            //{
            //    setPostName(false);
            //}
            //_isNum++;
        }
        public void setPostName(bool flag)
        {
            try
            {
                foreach (Control item in this.groupBox1.Controls)
                {
                    if (item.Name.StartsWith("userPerson"))
                    {
                        UserPerson dd = (UserPerson)item;
                        dd.TitleName = item.Name;

                        if (flag)
                        {
                            dd.Top += _rd.Next(100);
                            dd.Left += _rd.Next(100);
                        }
                        else
                        {
                            dd.Top -= _rd.Next(100);
                            dd.Left -= _rd.Next(100);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED  
                this.Opacity = 1;

                //if (this.IsXpOr2003 == true)
                //{
                //    cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED
                //    this.Opacity = 1;
                //}

                return cp;

            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }  //防止闪烁

    }
}
