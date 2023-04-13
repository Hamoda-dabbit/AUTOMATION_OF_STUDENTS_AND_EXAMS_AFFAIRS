using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AleppoFreeUniversity.PL
{
    public partial class FRM_MAIN : Form
    {
        //------------------------------------------------------------------- التحكم بفورم عن طريق فورم اخر
        private static FRM_MAIN frm;
        static void frm_formClose(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_MAIN getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClose);
                }
                return frm;
            }
        }
        //-------------------------------------------------------------------------------------------

        int panelwidth;
        bool iscollapsed;

        public FRM_MAIN()
        {
            InitializeComponent();
            //----------------------
            if (frm == null)
                frm = this;
            //----------------------
            timertime.Start();
            panelwidth = panelleft.Width;
            panelside.Visible = false;
            iscollapsed = false;
            //UserControls.US_Student_insert Us_std = new UserControls.US_Student_insert();
            //UserControls.US_Dergree_score Us_dgre = new UserControls.US_Dergree_score();
         // addtocontrolspanel(Us_std);
            
          
        }

        
        private void btn_insert_deg_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_insert_deg);
            UserControls.US_Degree_Insert Us_deg = new UserControls.US_Degree_Insert();
            addtocontrolspanel(Us_deg);

          
        }
        private void addControlToPanel(Control c ) 
        {
            c.Dock = DockStyle.Fill;
            panelcontrols.Controls.Clear();
            panelcontrols.Controls.Add(c);
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_users);
            UserControls.US_USER US_USR = new UserControls.US_USER();
            addtocontrolspanel(US_USR);
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_restore);
            UserControls.US_Restore US_Res = new UserControls.US_Restore();
            addtocontrolspanel(US_Res);
        }
        private void addtocontrolspanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelcontrols.Controls.Clear();
            panelcontrols.Controls.Add(c);
        }
        private void movesidepanel(Control btn)
        {
            panelside.Visible=true;
            panelside.Top = btn.Top;
            panelside.Height = btn.Height;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iscollapsed)
            {
                panelleft.Width = panelleft.Width +10;
                timer1.Interval = 10;
                if (panelleft.Width >= panelwidth)
                {
                    timer1.Stop();
                    iscollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelleft.Width = panelleft.Width - 10;
                timer1.Interval = 25;
                if (panelleft.Width <= 64)
                {
                    timer1.Stop();
                    iscollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timertime_Tick(object sender, EventArgs e)
        {            
            DateTime dt = DateTime.Now;
            int H =dt.Hour;
            int M = dt.Minute;
            int S = dt.Second;
            if(H==00)
            { labeltime.Text = "0" + H.ToString() + ":" + M.ToString() + ":" + S.ToString() + " ص  "; }
            else if (H>12)
            {
                H =H- 12;
                labeltime.Text = H.ToString() + ":" + M.ToString() + ":" + S.ToString() + " م  ";
            }
            else
            {labeltime.Text=H.ToString()+":"+M.ToString()+":"+S.ToString()+" ص ";}

            labeldate.Text = dt.ToString("dd / MM / yyyy");
            labelday.Text = dt.ToString("dddd");
       
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btn_insert_std_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_insert_std);
            UserControls.US_Student_Management Us_std = new UserControls.US_Student_Management();
            addtocontrolspanel(Us_std);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            movesidepanel(btn_logout);
           // frmlogin frm = new frmlogin();
            Application.Restart(); 
        //    frm.Show();
        }

        private void btn_deg_score_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_deg_score);
            UserControls.US_Dergree_Management us_ds = new UserControls.US_Dergree_Management();
            addtocontrolspanel(us_ds);
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_backup);
            UserControls.US_Backup Us_ba = new UserControls.US_Backup();
            addtocontrolspanel(Us_ba);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("c"))
            {
                System.IO.File.Delete("c");
            }
            Application.Exit();
            Environment.Exit(0);
        }

        private void دارةالطلابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //movesidepanel(btn_insert_std);
            //UserControls.US_Student_insert Us_std = new UserControls.US_Student_insert();
            //addtocontrolspanel(Us_std);
            if (btn_insert_std.Enabled == true)
            {
                btn_insert_std_Click(sender, e);
            }
        }

        private void ادارةالدارجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //movesidepanel(btn_insert_deg);
            //UserControls.US_Degree_Insert Us_deg = new UserControls.US_Degree_Insert();
            //addtocontrolspanel(Us_deg);
            if (btn_insert_deg.Enabled==true) {
                btn_insert_deg_Click(sender, e); }
        }

        private void كشفالعلاماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //movesidepanel(btn_deg_score);
            //UserControls.US_Dergree_score us_ds = new UserControls.US_Dergree_score();
            //addtocontrolspanel(us_ds);
                if(btn_deg_score.Enabled==true)
            btn_deg_score_Click(sender, e);
        }

        private void إنشاءنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //movesidepanel(btn_backup);
            //UserControls.US_Backup Us_ba = new UserControls.US_Backup();
            //addtocontrolspanel(Us_ba);
            if (btn_backup.Enabled==true)
            { btn_backup_Click(sender, e); }
        }

        private void استعادةنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //movesidepanel(btn_restore);
            //UserControls.US_Restore US_Res = new UserControls.US_Restore();
            //addtocontrolspanel(US_Res);
            if (btn_restore.Enabled == true)
            btn_restore_Click(sender,e);
        }

      

        private void btn_teacher_manage_Click(object sender, EventArgs e)
        {
            movesidepanel(btn_teacher_manage);
            UserControls.US_TeacherandMaterial_Manage US_Teach = new UserControls.US_TeacherandMaterial_Manage();
            addtocontrolspanel(US_Teach);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btn_teacher_manage_Click(sender,e);
        }

        private void ادارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_users_Click(sender,e);
        }
    }
}