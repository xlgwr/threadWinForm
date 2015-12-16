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
using System.IO;
using System.Net;

namespace FrmDemoControl
{
    public partial class Form1 : Form
    {
        Stopwatch _stopwatch;
        public Control[] _listControl = null;
        public UserPerson clpersonlist = new UserPerson();
        public Form3 _frm3;
        public int tmpcol = 5;
        public Form1()
        {
            Stopwatch tmpdd = new Stopwatch();
            tmpdd.Start();
            this.Opacity = 1;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);//防止窗口跳动
            SetStyle(ControlStyles.DoubleBuffer, true); //防止控件跳动 


            initwith();
            initfirst();
            tmpdd.Stop();
            var msg = "初始化: Use Time:" + tmpdd.Elapsed.ToString();
            lbl0Msg.Text = msg;
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {

        //        CreateParams cp = base.CreateParams;

        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED  
        //        this.Opacity = 1;

        //        //if (this.IsXpOr2003 == true)
        //        //{
        //        //    cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED
        //        //    this.Opacity = 1;
        //        //}

        //        return cp;

        //    }

        //}  //防止闪烁
        private void initfirst()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += Form1_Resize;
            tmpcol = flowLayoutPanel1.Width / clpersonlist.Width;
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


            xtraScrollableControl1.Left = groupBox1.Left;
            xtraScrollableControl1.Width = groupBox1.Width;
            xtraScrollableControl1.Height = this.Height - xtraScrollableControl1.Top - 50;
            
            flowLayoutPanel1.Top = 0;
            flowLayoutPanel1.Left = 0;
            flowLayoutPanel1.Width = xtraScrollableControl1.Width;


        }
        public SetImage SetImageToPicture(object toimage)
        {

            try
            {
                //考勤系统头像目录
                string AtPathDir = Application.StartupPath + "\\" + Common.AtPathDir;
                if (string.IsNullOrEmpty(Common.AtPathDir))
                {
                    Common.AtPathDir = @"USER_PIC\\";
                    AtPathDir = AtPathDir + Common.AtPathDir;
                }

                if (!Directory.Exists(AtPathDir))
                {
                    Directory.CreateDirectory(AtPathDir);
                }

                SetImage o = (SetImage)toimage;
                if (o.strUserID == "")
                {
                    AtPathDir = AtPathDir + "01.png";
                }
                var setImagePath = AtPathDir + o.strUserID + ".jpg";

                if (!File.Exists(setImagePath))
                {
                    WebClient myWebClient = new WebClient();
                    var getImagePath = Common.getImageHttpURL + o.strUserID + ".jpg";
                    myWebClient.DownloadFile(new Uri(getImagePath), setImagePath);
                }

                AtPathDir = setImagePath;

                //this.Invoke(new Action(delegate()
                //{
                o.userPicture.ImageUrl = AtPathDir;
                //}));

                return o;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void initForm1(object num)
        {
            try
            {
                this.SuspendLayout();
                var tmpnum = (noticeContrls)num;

                var tmpArrNum = tmpnum.clEnd - tmpnum.clFirst + 1;
                this.Invoke(new Action(delegate()
               {
                   if (tmpnum.batch > -tmpnum.clEnd)
                   {
                       flowLayoutPanel1.Height = tmpnum.rows * tmpnum.height;
                   }
                   else
                   {
                       flowLayoutPanel1.Height = tmpnum.rows * tmpnum.height;
                   }


               }));

                Control[] lstContr = new Control[tmpArrNum];
                int arrri = 0;
                for (int i = tmpnum.clFirst; i <= tmpnum.clEnd; i++)
                {
                    var clpersonlist2 = new UserPerson();

                    //clpersonlist2.Top = (i - 1) * clpersonlist2.Height;
                    //clpersonlist.Left = ((i % tmpcol) + 1) * clpersonlist.Width;
                    clpersonlist2.lblTitle.Text = "userPerson" + i.ToString();

                    foreach (Control item in clpersonlist2.Controls)
                    {
                        item.MouseEnter += clpersonlist_MouseEnter;
                        item.MouseHover += clpersonlist_MouseEnter;
                        item.MouseLeave += clpersonlist_MouseLeave;
                    }
                    clpersonlist2.AllEventClick += clpersonlist_AllEventClick;

                    //SetImage o = new SetImage() { userPicture = clpersonlist.userPicture1, strUserID = "F00012" };
                    //Task<SetImage> t = new Task<SetImage>(n => SetImageToPicture((SetImage)n), o);
                    //t.Start();

                    lstContr[arrri] = clpersonlist2;
                    arrri++;
                }
                if (_listControl == null)
                {
                    _listControl = lstContr;
                }
                this.Invoke(new Action(delegate()
                {
                    this.flowLayoutPanel1.Controls.AddRange(lstContr);
                }));
                if (tmpnum.clEnd >= allNum)
                {
                    //end notice time and show it.
                    _stopwatch.Stop();
                    var msg = "Test1: Use Time:" + _stopwatch.Elapsed.ToString();
                    setMsg(lbl0Msg, msg);
                }
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            catch (Exception ex)
            {

                throw ex;
            }



            //throw new NotImplementedException();
        }

        void clpersonlist_MouseLeave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Cursor = Cursors.Default;
        }

        void clpersonlist_MouseEnter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Cursor = Cursors.Hand;
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
            //lbl0Msg.Text = "";
            tmpfrm2 = null;
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

            if (_listControl != null)
            {
                Stopwatch tmpwatch = new Stopwatch();
                tmpwatch.Start();

                if (_frm3 == null)
                {
                    _frm3 = new Form3(_listControl);
                }
                _frm3.Show();

                tmpwatch.Stop();
                lbl0Msg.Text = "User Time:" + tmpwatch.Elapsed.ToString();
            }
            else
            {
                var noticeContrls = new noticeContrls();
                noticeContrls.clFirst = 1;
                noticeContrls.clEnd = Int32.Parse(this.numericUpDown1.Value.ToString());
                noticeContrls.batch = noticeContrls.clEnd;
                noticeContrls.rows = (noticeContrls.clEnd / tmpcol) + 1;
                noticeContrls.cols = tmpcol;
                noticeContrls.height = clpersonlist.Height;
                noticeContrls.width = clpersonlist.Width;

                initForm1(noticeContrls);
            }

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
            var batchnum = 5;

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

                    noticeContrls.rows = tmpnum + 1;
                    noticeContrls.cols = tmpcol;
                    noticeContrls.height = clpersonlist.Height;
                    noticeContrls.width = clpersonlist.Width;

                    ThreadPool.QueueUserWorkItem(initForm1, noticeContrls);
                }

            }
            return 1;
        }

        public int allNum { get; set; }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stopwatch tmpwatch = new Stopwatch();
            tmpwatch.Start();


            if (tmpfrm2 == null)
            {
                tmpfrm2 = new Form2();
            }
            else
            {
                tmpfrm2.lbl0Msg.Text = "已预加载过。";
            }

            tmpfrm2.Show();

            tmpwatch.Stop();
            lbl0Msg.Text = "User Time:" + tmpwatch.Elapsed.ToString();
        }

        void tmpfrm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public Form2 tmpfrm2 { get; set; }

        private void button4_Click(object sender, EventArgs e)
        {
            _frm3 = null;
            _listControl = null;
            tmpfrm2 = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Stopwatch tmpwatch = new Stopwatch();
            tmpwatch.Start();
            Form4 frm4 = new Form4(true);
            frm4.Show();
            tmpwatch.Stop();
            lbl0Msg.Text = "Test4: User Time:" + tmpwatch.Elapsed.ToString();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

    public class noticeContrls
    {

        public int clFirst { get; set; }
        public int clEnd { get; set; }

        public int rows { get; set; }
        public int cols { get; set; }

        public int height { get; set; }
        public int width { get; set; }

        public int batch { get; set; }
    }
    public class SetImage
    {
        public UserPicture userPicture { get; set; }
        public string strUserID { get; set; }
    }
}
