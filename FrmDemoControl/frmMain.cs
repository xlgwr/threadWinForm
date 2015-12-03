using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmDemoControl
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            initForm();
        }

        private void initForm()
        {
            //throw new NotImplementedException();

            this.StartPosition = FormStartPosition.CenterScreen;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmpTest1 = new Form1(this);
            tmpTest1.Show();
        }
    }
}
