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
using System.Diagnostics;
using System.Threading;

namespace FrmDemoControl
{
    public partial class Form1 : Form
    {
        Stopwatch _stopwatch;
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
        private void initForm1(object num)
        {
            try
            {
                var tmpnum = (noticeContrls)num;

                for (int i = tmpnum.clFirst; i <= tmpnum.clEnd; i++)
                {
                    var clpersonlist = new UserPerson();

                    var tmpcol = flowLayoutPanel1.Width / clpersonlist.Width;

                    clpersonlist.Top = ((tmpnum.clEnd / tmpcol) + 2) * clpersonlist.Height;

                    clpersonlist.lblTitle.Text = "Test " + i.ToString();

                    clpersonlist.AllEventClick += clpersonlist_AllEventClick;

                    this.BeginInvoke(new Action(delegate()
                    {
                        this.flowLayoutPanel1.Controls.Add(clpersonlist);
                    }));

                }
                if (tmpnum.clEnd >= allNum)
                {
                    //end notice time and show it.
                    _stopwatch.Stop();
                    var msg = "Test1: Use Time:" + _stopwatch.Elapsed.ToString();
                    setMsg(lbl0Msg, msg);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }



            //throw new NotImplementedException();
        }

        void clpersonlist_AllEventClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            UserControl dd = (UserControl)sender;
            if (dd.BorderStyle == BorderStyle.Fixed3D)
            {
                dd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
            else
            {
                dd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }
            if (dd.BackColor == Color.Red)
            {
                dd.BackColor = Color.DarkGray;
            }
            else
            {
                dd.BackColor = Color.Red;
            }
        }

        private void setMsg(Label lbl0Msg, string msg)
        {
            this.Invoke(new Action(delegate()
            {
                lbl0Msg.Text = msg;
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl0Msg.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel1.Refresh();
            setMsg(lbl0Msg, "Test1: 加载控件中。。。。");
            allNum = Int32.Parse(numericUpDown1.Value.ToString());
            //notice time
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            //todo some thing

            var noticeContrls = new noticeContrls();
            noticeContrls.clFirst = 1;
            noticeContrls.clEnd = Int32.Parse(this.numericUpDown1.Value.ToString());
            noticeContrls.batch = noticeContrls.clEnd;
            initForm1(noticeContrls);

            this.button1.Enabled = true;
            this.Cursor = Cursors.Default;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            this.flowLayoutPanel1.Controls.Clear();
            this.flowLayoutPanel1.Refresh();
            setMsg(lbl0Msg, "Test2: 开始加载控件。。。。");
            //notice time
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            allNum = Int32.Parse(numericUpDown1.Value.ToString());

            Task<int> t = new Task<int>(n => test2((int)n), allNum);
            t.Start();
            t.Wait();
            var tmpresult = t.Result.ToString();
            if (tmpresult.Equals("1"))
            {
                setMsg(lbl0Msg, "控件初始化成功。");
            }


            this.button3.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        public int test2(int tmpallNum)
        {
            var tmpnum = 0;
            var batchnum = 10;

            if (tmpallNum % batchnum == 0)
            {
                tmpnum = tmpallNum / batchnum;
            }
            else
            {
                var tmpmod = tmpallNum % batchnum;
                tmpnum = (tmpallNum - tmpmod) / batchnum;
                if (tmpallNum < batchnum)
                {
                    tmpnum = 1;
                }
            }
            for (int i = 0; i <= tmpnum; i++)
            {
                var noticeContrls = new noticeContrls();

                noticeContrls.batch = batchnum;

                if (i * batchnum + 1 <= tmpallNum)
                {
                    noticeContrls.clFirst = i * batchnum + 1;

                    if ((i * batchnum + batchnum) < tmpallNum)
                    {
                        noticeContrls.clEnd = i * batchnum + batchnum;
                    }
                    else
                    {
                        noticeContrls.clEnd = (i * batchnum) + (tmpallNum - i * batchnum);
                    }

                    ThreadPool.QueueUserWorkItem(initForm1, noticeContrls);
                }

            }
            return 1;
        }

        public int allNum { get; set; }
    }

    public class noticeContrls
    {

        public int clFirst { get; set; }
        public int clEnd { get; set; }

        public int batch { get; set; }
    }
}
