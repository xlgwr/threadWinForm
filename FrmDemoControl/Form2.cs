using MachineSystem.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrmDemoControl
{
    public partial class Form2 : Form
    {
        Random _rd = new Random();
        public Form2()
        {
            Stopwatch tmpdd = new Stopwatch();
            tmpdd.Start();

            InitializeComponent();

            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            var msg = "初始化加载50个控件时间: Use Time:" + tmpdd.Elapsed.ToString();
            lbl0Msg.Text = msg;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form2_FormClosing;

        }
        public void setPostName(bool flag)
        {
            foreach (Control item in groupBox2.Controls)
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

        }  //防止闪烁
        void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            this.Hide();
            e.Cancel = true;
        }
        int _isNum = 0;
        private void Form2_Activated(object sender, EventArgs e)
        {
            this.Text += "a" + _isNum;
            if (_isNum % 2 == 0)
            {
                setPostName(true);
            }
            else
            {
                setPostName(false);
            }
            _isNum++;
        }
    }
}
