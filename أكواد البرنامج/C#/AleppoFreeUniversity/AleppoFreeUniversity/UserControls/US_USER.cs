using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AleppoFreeUniversity.UserControls
{
    public partial class US_USER : UserControl
    {
        BL.ClsLogin log = new BL.ClsLogin();
        public US_USER()
        {
            InitializeComponent();
            dataGridViewUser.DataSource = log.Get_All_Users();
        }


        void clear_users()
        {
            txt_oldUsername.Clear();
            txt_newUsername.Clear();
            txtpass.Clear();
            txtname.Clear();
            txt_conPass.Clear();
            cmbrole.SelectedIndex = -1;
            txt_oldUsername.Focus();
        }
        private void dataGridViewUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txt_oldUsername.Text = dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
                txtpass.Text = dataGridViewUser.CurrentRow.Cells[1].Value.ToString();
                txt_conPass.Text = dataGridViewUser.CurrentRow.Cells[1].Value.ToString();
                txtname.Text = dataGridViewUser.CurrentRow.Cells[2].Value.ToString();
                cmbrole.Text = dataGridViewUser.CurrentRow.Cells[3].Value.ToString();
                //comboBox1.SelectedIndex = Convert.ToInt16(dataGridView1.CurrentRow.Cells[3].Value.ToString()) - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ////panel1.Hide();
            ////button3.Text = "حفظ";
            //////btnadd.Text = "عدم الحفظ";

        }

        private void btn_adduser_Click(object sender, EventArgs e)
        {
            button4.Text = "إضافة"; 
            txt_oldUsername.Focus();
            panel1.Visible = true;
            //   panel1.Size = new Size(1025, 505);
            panel1.Location = new Point(51, 22);
            lbl_oldUsername.Text = "اسم المستخدم:";
            lbl_newUsername.Visible = false;
            txt_newUsername.Visible = false;
            clear_users();

        }


        private void btnedit_Click(object sender, EventArgs e)
        {
            button4.Text = "حفظ";
            panel1.Visible = true;
        
            //    panel1.Size = new Size(1025, 505);
            panel1.Location = new Point(51, 22);
            lbl_newUsername.Visible = true;
            txt_newUsername.Visible = true;
            txt_oldUsername.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "إضافة")
            {
                if (txt_oldUsername.Text == string.Empty || txtpass.Text == string.Empty || txtname.Text == string.Empty || txt_conPass.Text == string.Empty)
                {
                    MessageBox.Show("رجاءً أدخل جميع البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtpass.Text != txt_conPass.Text)
                {
                    MessageBox.Show("كلمات المرور غير متطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                log.add_user(txt_oldUsername.Text, txtpass.Text, txtname.Text, cmbrole.Text);
                MessageBox.Show("تم إضافة المستخدم بنجاح", "إضافة مستخدم جديد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_users();
                dataGridViewUser.DataSource = log.Get_All_Users();

            }
            else if (button4.Text == "حفظ")
            {
                try
                {
                    log.edit_user(txt_oldUsername.Text, txtpass.Text, txt_newUsername.Text, txtname.Text, cmbrole.Text);

                    MessageBox.Show("تم التعديل بنجاح", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                button4.Text = "إضافة";
                lbl_oldUsername.Text = "اسم المستخدم:";
                lbl_newUsername.Visible = false;
                txt_newUsername.Visible = false;
                clear_users();
                dataGridViewUser.DataSource = log.Get_All_Users();

            }
            panel1.Hide();

        }

        private void txt_conPass_Validated(object sender, EventArgs e)
        {
            if (txtpass.Text != txt_conPass.Text)
            {
                MessageBox.Show("كلمات السر غير متطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد بالتأكيد حذف المستخدم؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                log.delete_user(dataGridViewUser.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تم الحذف بنجاح", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridViewUser.DataSource = log.Get_All_Users();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }
        }
    }