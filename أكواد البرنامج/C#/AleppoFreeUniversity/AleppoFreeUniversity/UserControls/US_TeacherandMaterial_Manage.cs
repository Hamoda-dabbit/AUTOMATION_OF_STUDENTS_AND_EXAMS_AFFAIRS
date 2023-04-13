using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AleppoFreeUniversity.UserControls
{
    public partial class US_TeacherandMaterial_Manage : UserControl
    {
        BL.Cls_TeacherandMaterial tam = new BL.Cls_TeacherandMaterial();
        Boolean theDel_t=false;
        Boolean theDel_m = false;
        Boolean ser_m = false;

        public US_TeacherandMaterial_Manage()
        {
            InitializeComponent();
            txt_teachid.Focus();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            btnadd.Enabled = false;
            btnedit.Enabled = true;
            btndel.Enabled = true;
            groupBox1.Visible = true;
            dt_teach.Visible = false;
            txt_serch.Visible = false;
            btn_add_t.Text="إضافة";
            label3.Visible = false;
            txt_serch.Visible = false;
        }

        public void clear_teacher()
        {
            txt_teachid.Clear();
            txtname.Clear();
            cmbscien_rank.SelectedIndex=-1;
            txt_num_mat.Clear();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            btnadd.Enabled =true ;
            btnedit.Enabled = false;
            btndel.Enabled = true;
            label3.Visible = true;
            txt_serch.Visible = true;
            dt_teach.Visible = true;
            dt_teach.Size = new Size(740, 205);
            dt_teach.Location = new Point(17, 0);
            theDel_t = false;
        }

        private void dt_teach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (theDel_t == false)
                {
                    txt_teachid.Text = dt_teach.CurrentRow.Cells[0].Value.ToString();
                    txtname.Text = dt_teach.CurrentRow.Cells[1].Value.ToString();
                    int scien_ran = Convert.ToInt16(dt_teach.CurrentRow.Cells[2].Value.ToString());
                    if (scien_ran == 0)
                    {
                        cmbscien_rank.SelectedIndex = 0;
                    }
                    else if (scien_ran == 1)
                    {
                        cmbscien_rank.SelectedIndex = 1;
                    }
                    else if (scien_ran == 2)
                    {
                        cmbscien_rank.SelectedIndex = 2;
                    }
                    else if (scien_ran == 3)
                    {
                        cmbscien_rank.SelectedIndex = 3;
                    }
                    else if (scien_ran == 4)
                    {
                        cmbscien_rank.SelectedIndex = 4;
                    }
                    else
                    {
                        cmbscien_rank.SelectedIndex = 5;
                    }

                    txt_num_mat.Text = dt_teach.CurrentRow.Cells[3].Value.ToString();
                    ////////
                    ///////////

                    txt_serch.Clear();
                    btn_add_t.Text = "حفظ";
                }
                else if (theDel_t == true)
                {
                    int teach_id =Convert.ToInt16(dt_teach.CurrentRow.Cells[0].Value.ToString());
                    string teach_name = dt_teach.CurrentRow.Cells[1].Value.ToString();
                    DialogResult dialog = MessageBox.Show(" (" +"ذو الرقم" +teach_id+ ") " + "هل تريد حذف المدرس" + " " + teach_name, "حذف مدرس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        tam.delete_teacher(teach_id);
                        MessageBox.Show("تم الحذف بنجاح", "حذف مدرس", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_teach.DataSource = tam.Get_all_teacher();
                        txt_serch.Clear();
                        txt_serch.Focus();
                    }
                    else
                    {
                        theDel_t = false;
                        txt_serch.Clear();
                    }

                }
                dt_teach.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_teacher_Click(object sender, EventArgs e)
        {
            btn_material.Enabled =true ;
            btn_teacher.Enabled = false;
            btnadd .Enabled = false;
            ser_m = false;
            panel_material.Visible = false;
            label3.Visible = false;
            txt_serch.Visible = false;
            panel_teach.Visible = true;
            panel_teach.Size = new Size(782, 322);
            panel_teach.Location = new Point(276, 89);
            dt_teach.DataSource = tam.Get_all_teacher();
            
        }

        private void btn_add_t_Click(object sender, EventArgs e)
        {

            try
            {
               // dt_teach.Visible = false;
                if (txt_teachid.Text != "" && txtname.Text != "" && cmbscien_rank.SelectedIndex != -1 && txt_num_mat.Text != "")
                {
                    if (btn_add_t.Text=="إضافة")
                    {
                    tam.add_teacher(Convert.ToInt16(txt_teachid.Text), txtname.Text, cmbscien_rank.SelectedIndex +1, Convert.ToInt16(txt_num_mat.Text));
                    MessageBox.Show("تم الإضافة بنجاح", "نجاح الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   dt_teach.DataSource= tam.Get_all_teacher();
                    clear_teacher();
                    }
                    else if (btn_add_t.Text == "حفظ")
                    {
                        tam.edit_teacher(Convert.ToInt16(txt_teachid.Text), txtname.Text, cmbscien_rank.SelectedIndex +1, Convert.ToInt16(txt_num_mat.Text));
                        MessageBox.Show("تم التعديل بنجاح", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       dt_teach.DataSource= tam.Get_all_teacher();
                        clear_teacher();

                    }
                }
                else
                {
                    MessageBox.Show("يجب تعبئة الحقول: رقم المدرس, اسم المدرس, رتبة المدرس, عدد المواد التي يدرسها ");
                }
           }
            catch (Exception ex)
            {

                if (ex.Message=="Violation of PRIMARY KEY constraint 'PK_Teacher'. Cannot insert duplicate key in object 'dbo.Teacher'. The duplicate key value is ("+txt_teachid.Text+").\r\nThe statement has been terminated.")
                {
                    MessageBox.Show("رقم المدرس موجود مسبقا الرجاء تغييره");
                }
               else MessageBox.Show(ex.Message);
            }

        }

        private void btn_can_t_Click(object sender, EventArgs e)
        {
            clear_teacher();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            btnadd.Enabled = true;
            btnedit.Enabled = true;
            btndel.Enabled =false ;
            label3.Visible = true;
            txt_serch.Visible = true;
            dt_teach.Visible = true;
            dt_teach.Size = new Size(740, 205);
            dt_teach.Location = new Point(17, 0);
            theDel_t = true;

        }

        private void btn_addmat_Click(object sender, EventArgs e)
        {
            btn_addmat.Enabled = false;
            btn_editmat.Enabled = true;
            btn_delmat.Enabled = true;
            groupBox2.Visible = true;
            dt_material.Visible = false;
            txt_serch.Visible = false;
            btn_add_m.Text = "إضافة";
            label3.Visible = false;
            txt_serch.Visible = false;

        }

        private void btn_editmat_Click(object sender, EventArgs e)
        {
            btn_addmat.Enabled =true ;
            btn_editmat.Enabled = false;
            btn_delmat.Enabled = true;
            label3.Visible = true;
            txt_serch.Visible = true;
            dt_material.Visible = true;
            dt_material.Size = new Size(740, 230);
            dt_material.Location = new Point(17, 0);
            theDel_m = false;

        }

        private void btn_delmat_Click(object sender, EventArgs e)
        {
            btn_addmat.Enabled =true ;
            btn_editmat.Enabled = true;
            btn_delmat.Enabled = false;
            label3.Visible = true;
            txt_serch.Visible = true;
            dt_material.Visible = true;
            dt_material.Size = new Size(740, 230);
            dt_material.Location = new Point(17, 0);
            theDel_m = true;

        }

        private void btn_material_Click(object sender, EventArgs e)
        {
            try
            {
                btn_addmat.Enabled = false;
                btn_material.Enabled = false;
                btn_teacher.Enabled = true;
                ser_m = true;
                panel_teach.Visible = false;
                txt_serch.Visible = false;
                label3.Visible = false;
                panel_material.Visible = true;
                panel_material.Size = new Size(797, 295);
                panel_material.Location = new Point(276, 89);
                dt_material.DataSource = tam.Get_material();
            }
            catch (Exception ex)
            {
                if (ex.Message=="The EXECUTE permission was denied on the object 'Get_Material', database 'AleppoFreeUniversity', schema 'dbo'.")
                {
                    MessageBox.Show("ليس لديك الصلاحية لتنفيذ هذا الاجراء");
                }
                else
                MessageBox.Show(ex.Message);
            }
           

        }

        private void dt_material_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (theDel_m == false)
                {
                    txt_matid.Text = dt_material.CurrentRow.Cells[0].Value.ToString();
                    txt_matname.Text = dt_material.CurrentRow.Cells[1].Value.ToString();
                    int fac = Convert.ToInt16(dt_material.CurrentRow.Cells[2].Value.ToString());
                    if (fac == 1)
                    {
                        cmb_faculty.SelectedIndex = 0;
                    }
                    else if (fac == 2)
                    {
                        cmb_faculty.SelectedIndex = 1;
                    }
                    else if (fac == 3)
                    {
                        cmb_faculty.SelectedIndex = 2;
                    }
                    else if (fac == 4)
                    {
                        cmb_faculty.SelectedIndex = 3;
                    }
                    else if (fac == 5)
                    {
                        cmb_faculty.SelectedIndex = 4;
                    }
                    else if (fac == 6)
                    {
                        cmb_faculty.SelectedIndex = 5;
                    }
                    else if (fac == 7)
                    {
                        cmb_faculty.SelectedIndex = 6;
                    }
                    else if (fac == 8)
                    {
                        cmb_faculty.SelectedIndex = 7;
                    }
                    else if (fac == 9)
                    {
                        cmb_faculty.SelectedIndex = 8;
                    }
                    else if (fac == 10)
                    {
                        cmb_faculty.SelectedIndex = 9;
                    }
                    else if (fac == 11)
                    {
                        cmb_faculty.SelectedIndex = 10;
                    }
                    else if (fac == 12)
                    {
                        cmb_faculty.SelectedIndex = 11;
                    }
                    else if (fac == 13)
                    {
                        cmb_faculty.SelectedIndex = 12;
                    }
                    else if (fac == 14)
                    {
                        cmb_faculty.SelectedIndex = 13;
                    }
                    else if (fac == 15)
                    {
                        cmb_faculty.SelectedIndex = 14;
                    }
                    else if (fac == 16)
                    {
                        cmb_faculty.SelectedIndex = 15;
                    }
                    else 
                    {
                        cmb_faculty.SelectedIndex = 16;
                    }


                    int year = Convert.ToInt16(dt_material.CurrentRow.Cells[3].Value.ToString());
                    if (year == 1)
                    {
                        cmb_matyear.SelectedIndex = 0;
                    }
                    else if (year == 2)
                    {
                        cmb_matyear.SelectedIndex = 1;
                    }
                    else if (year == 3)
                    {
                        cmb_matyear.SelectedIndex = 2;
                    }
                    else if (year == 4)
                    {
                        cmb_matyear.SelectedIndex = 3;
                    }
                    else if (year == 5)
                    {
                        cmb_matyear.SelectedIndex = 4;
                    }
                    else 
                    {
                        cmb_matyear.SelectedIndex = 5;
                    }


                    string seas = dt_material.CurrentRow.Cells[4].Value.ToString();
                    if (seas == "True")
                    {
                        cmb_season.SelectedIndex = 1;
                    }
                    else if (seas == "False")
                    {
                        cmb_season.SelectedIndex = 0;
                    }
                    dt_material.Visible = false;
                    txt_serch.Clear();
                    btn_add_m.Text = "حفظ";
                }
                else if (theDel_m == true)
                {
                    string mat_id = dt_material.CurrentRow.Cells[0].Value.ToString();
                    string mat_name = dt_material.CurrentRow.Cells[1].Value.ToString();
                    DialogResult dialog = MessageBox.Show(" ("  + "ذات الرمز" + mat_id + ") " + "هل تريد حذف مادة" + " " + mat_name, "حذف مادة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        tam.delete_material(mat_id);
                        MessageBox.Show("تم الحذف بنجاح", "حذف مادة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_material.DataSource = tam.Get_material();
                        txt_serch.Clear();
                        txt_serch.Focus();
                    }
                    else
                    {
                        theDel_m = false;
                        txt_serch.Clear();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_add_m_Click(object sender, EventArgs e)
        {
            try
            {
                // dt_teach.Visible = false;
                if (txt_matid.Text != "" && txt_matname.Text != "" && cmb_faculty.SelectedIndex != -1 && cmb_matyear.SelectedIndex != -1 && cmb_season.SelectedIndex != -1)
                {
                    if (btn_add_m.Text == "إضافة")
                    {
                        tam.add_material(txt_matid.Text, txt_matname.Text, cmb_faculty.SelectedIndex + 1, cmb_matyear.SelectedIndex + 1, Convert.ToBoolean(cmb_season.SelectedIndex));
                        MessageBox.Show("تم الإضافة بنجاح", "نجاح الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_material.DataSource = tam.Get_material();
                        clear_material();
                    }
                    else if (btn_add_m.Text == "حفظ")
                    {
                        tam.edit_material(txt_matid.Text,txt_matname.Text, cmb_faculty.SelectedIndex + 1, cmb_matyear.SelectedIndex + 1, Convert.ToBoolean(cmb_season.SelectedIndex + 1));
                        MessageBox.Show("تم التعديل بنجاح", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt_material.DataSource = tam.Get_material();
                        clear_material();

                    }
                }
                else
                {
                    MessageBox.Show("يجب تعبئة الحقول: رمز المادة, اسم المادة, الكلية, سنة المادة, الفصل الدراسي للمادة ");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message=="Violation of PRIMARY KEY constraint 'PK_Material'. Cannot insert duplicate key in object 'dbo.Material'. The duplicate key value is ("+txt_matid.Text+").\r\nThe statement has been terminated.")
                {
                    MessageBox.Show("رمز المادة موجود مسبقا الرجاء تغييره");
                }
                else
                MessageBox.Show(ex.Message);
            }

        }

        public void clear_material()
        {
            txt_matid.Clear();
            txt_matname.Clear();
            cmb_faculty.SelectedIndex = -1;
            cmb_matyear.SelectedIndex = -1;
            cmb_season.SelectedIndex = -1;
        }

        private void US_TeacherandMaterial_Manage_Load(object sender, EventArgs e)
        {
            btn_material_Click(sender,e);
        }

        private void ادارةالموادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_material_Click(sender, e);
        }

        private void ادارةالمدرسينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_teacher_Click(sender,e);
        }
        
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void txt_serch_TextChanged(object sender, EventArgs e)
        {  
            try
            {
                if (txt_serch.Text == "")
                {
                    dt_material.DataSource = tam.Get_material();
                    dt_teach.DataSource = tam.Get_all_teacher();
                }
                else
                {
                        //dt_material.DataSource = tam.search_material_by_id(txt_serch.Text);

                    if (IsDigitsOnly(txt_serch.Text))
                    {               
                        dt_teach.DataSource = tam.search_teacher_by_id(Convert.ToInt16(txt_serch.Text));

                    }
                    else
                    {
                        if (ser_m) dt_material.DataSource = tam.search_material_by_name(txt_serch.Text);
                        else dt_teach.DataSource = tam.search_teacher_by_name(txt_serch.Text);

                    }

                }
            }
            catch (Exception)
            {

            }

        }

        private void btn_can_m_Click_1(object sender, EventArgs e)
        {
            clear_material();
        }

        private void txt_teachid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}