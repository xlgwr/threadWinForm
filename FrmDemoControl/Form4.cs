using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MachineSystem.UserControls;

namespace FrmDemoControl
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            initControl();
            initFirst();

        }
        public Form4(bool flag2)
        {
            InitializeComponent();
            initControl2();
            initFirst();
        }
        void initFirst()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Activated += Form4_Activated;
        }

        void Form4_Activated(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void initControl()
        {
            //throw new NotImplementedException();
            var trow = tableLayoutPanel1.RowCount;
            var tcol = tableLayoutPanel1.ColumnCount;

            Control[] _listCtl = new Control[trow * tcol];
            try
            {
                this.SuspendLayout();

                for (int i = 1; i <= trow; i++)
                {
                    for (int j = 1; j <= tcol; j++)
                    {
                        var tmpi = (i - 1) * tcol + j;
                        var tmpnew = new UserPerson();
                        tmpnew.TitleName = "T" + tmpi;
                        tmpnew.UserID = "U" + tmpi;
                        tmpnew.UserName = "UN:" + tmpi;
                        tmpnew.M_x = i - 1;
                        tmpnew.M_y = j - 1;

                        _listCtl[tmpi - 1] = tmpnew;
                        //tableLayoutPanel1.Controls.Add(tmpnew);
                        //tableLayoutPanel1.SetRow(tmpnew, i);
                        //tableLayoutPanel1.SetColumn(tmpnew, j);
                    }
                }
                tableLayoutPanel1.Controls.AddRange(_listCtl);
                foreach (UserPerson item in _listCtl)
                {
                    tableLayoutPanel1.SetRow(item, item.M_x);
                    tableLayoutPanel1.SetColumn(item, item.M_y);
                }

                tableLayoutPanel1.Refresh();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }

        }


        private void initControl2()
        {
            //throw new NotImplementedException();
            var trow = tableLayoutPanel1.RowCount;
            var tcol = tableLayoutPanel1.ColumnCount;

            try
            {
                this.SuspendLayout();

                for (int i = 0; i < trow; i++)
                {
                    for (int j = 0; j < tcol; j++)
                    {
                        var tmpi = (i - 1) * tcol + j;
                        var tmpnew = new UserPerson();
                        tmpnew.TitleName = "T" + tmpi;
                        tmpnew.UserID = "U" + tmpi;
                        tmpnew.UserName = "UN:" + tmpi;
                        tmpnew.M_x = i;
                        tmpnew.M_y = j;

                        tableLayoutPanel1.Controls.Add(tmpnew);
                        tableLayoutPanel1.SetRow(tmpnew, i);
                        tableLayoutPanel1.SetColumn(tmpnew, j);
                    }
                }
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }

        }

    }
}
