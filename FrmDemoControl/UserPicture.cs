using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MachineSystem.UserControls
{
    public partial class UserPicture : UserControl
    {

        public delegate void AllEvent(object sender, EventArgs e);
        public event AllEvent AllEventClick;

        private Color m_bgColor;

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color bgColor 
        {
            get { return m_bgColor; }
            set 
            {
                m_bgColor = value;
                panel1.BackColor = m_bgColor;
            }
        }


        private string m_ImageUrl = string.Empty;

        /// <summary>
        /// 头像路径
        /// </summary>
        public string ImageUrl
        {
            get { return m_ImageUrl; }
            set
            {
                m_ImageUrl = value;

                if (File.Exists(m_ImageUrl))
                {
                    this.pictureBox1.ImageLocation = m_ImageUrl;
                }
                else
                {

                }
            }
        }


        public UserPicture()
        {
            InitializeComponent();
        }

        private void UserPicture_Click(object sender, EventArgs e)
        {

            try
            {
                if (AllEventClick != null)
                {
                    AllEventClick(this, e);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
