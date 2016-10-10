using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wjjq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
       

        
        private void login_Click(object sender, EventArgs e)
        {
            Utility u = new Utility();
            VisitLogManager vManager = new VisitLogManager();
            UserManager uManager = new UserManager();
            UserInfo temp = new UserInfo();
            temp.Account = textbox_Account.Text;
            temp.Password = textbox_Password.Text;
           
            if (u.UserLogin(temp))
            {
                MessageBox.Show(u.USER.Account + "登陆成功!");

                if(u.Judgment())
                    this.Hide();
            }
        }

        private void Announce_Load(object sender, EventArgs e)
        {
            List<Notices> noteList=new List<Notices>();
            NoticesManager nManager = new NoticesManager();
            noteList=nManager.CheckNotices("announce");
            notice.Text = noteList[0].NoticeContent;
        }
      
        
        
    }
}
