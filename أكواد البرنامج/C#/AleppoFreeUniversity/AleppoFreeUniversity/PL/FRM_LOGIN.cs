using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AleppoFreeUniversity
{
    public partial class frmlogin : Form
    {
        int num_of_attempts = 0;
        BL.ClsLogin log = new BL.ClsLogin();
        PL.FRM_MAIN frmlog = new PL.FRM_MAIN();
        public frmlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("c"))
            {
                System.IO.File.Delete("c");
            }
            Application.Exit();
            Environment.Exit(0);
            this.Close();
        }
        private void login()
        {
            StreamWriter sw = new StreamWriter("c");
            if (checkBox1.Checked == true)
            {
                sw.WriteLine(txt_ip.Text);
            }
            else { sw.WriteLine("."); }
            sw.WriteLine(txtuser.Text);
            sw.WriteLine(txtpass.Text);
            sw.Close();
            try
            {
                if (num_of_attempts < 3)
                {
                    DataTable dt = log.LOGIN(txtuser.Text, txtpass.Text);
                    if (dt.Rows.Count > 0)
                    {

                        PL.FRM_MAIN.getMainForm.label7.Text = dt.Rows[0][2].ToString();
                        PL.FRM_MAIN.getMainForm.label6.Text = dt.Rows[0][3].ToString();
                        if (dt.Rows[0][3].ToString() == "مدير")
                        {
                            PL.FRM_MAIN.getMainForm.btn_users.Enabled = true;
                        }
                        else if (dt.Rows[0][3].ToString() == "عادي")
                        {
                            PL.FRM_MAIN.getMainForm.btn_users.Enabled = false;
                        }
                        else if ((dt.Rows[0][3].ToString() == "شؤون الطلاب"))
                        {
                            PL.FRM_MAIN.getMainForm.btn_insert_deg.Enabled = false;
                            PL.FRM_MAIN.getMainForm.btn_deg_score.Enabled = false;
                            PL.FRM_MAIN.getMainForm.btn_users.Enabled = false;
                        }
                        else if ((dt.Rows[0][3].ToString() == "شؤون الامتحانات"))
                        {
                            PL.FRM_MAIN.getMainForm.btn_insert_std.Enabled = false;
                            PL.FRM_MAIN.getMainForm.btn_users.Enabled = false;
                        }
                        MessageBox.Show("تم الإتصال بنجاح", "نجاح الإتصال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmlog.Show();
                        this.Hide();

                    }

                    else
                        MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "فشل الإتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    num_of_attempts++;
                }
                else
                {
                    MessageBox.Show("لقد تجاوزت الحد المسموح للدخول الرجاء المحاولة في غضون 30 ثانية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer_attempts.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                if (ex.Message == "Login failed for user '" + txtuser.Text + "'.")
                {
                    MessageBox.Show("يوجد خطأ بادخال اسم المستخدم أو كلمة المرور");
                }
                else MessageBox.Show(ex.Message);
            }
        }

      
        private void txtpass_Leave(object sender, EventArgs e)
        {
            login();           
        }

        private void frmlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login(); 
            }
        }

        private void timer_attempts_Tick(object sender, EventArgs e)
        {
            if (timer_attempts.Interval>30000)
            {
                num_of_attempts = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                txt_ip.Visible = true;
                lb_ip.Visible = true;
            }
            else
            {
                txt_ip.Visible = false;
                lb_ip.Visible = false;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }
    }
}