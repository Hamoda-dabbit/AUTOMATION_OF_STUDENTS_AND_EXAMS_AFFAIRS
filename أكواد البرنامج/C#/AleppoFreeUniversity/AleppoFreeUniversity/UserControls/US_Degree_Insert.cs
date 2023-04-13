using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace AleppoFreeUniversity.UserControls
{
    public partial class US_Degree_Insert : UserControl
    {
        BL.Cls_degree deg = new BL.Cls_degree();
        BL.Cls_student stud = new BL.Cls_student();
        Boolean theDelete = false;

        public US_Degree_Insert()
        {
            try
            {
                InitializeComponent();
                cmbfaculty.SelectedIndex = 3;
                cmbyear.SelectedIndex = 0;
                cmbSeson.SelectedIndex = 0;
                cmbseas.SelectedIndex = 0;
                dataGridView_mat.DataSource = deg.Get_All_Material(cmbfaculty.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex));
                txtid.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtid.Text != "" && txtmat.Text != "")
                {
                    if (btnadd.Text == "إضافة")
                    {
                        if (Convert.ToInt16(txtprac.Text) != 0 && Convert.ToInt16(txttheo.Text) > 70)
                        {
                            MessageBox.Show("لا يمكن ادخال علامة النظري أكبر من 70");
                        }
                        else
                        {
                            deg.insert_degree(txtid.Text, txtmat.Text, Convert.ToInt16(txtprac.Text), Convert.ToInt16(txttheo.Text), cmbseas.SelectedIndex + 1, dtyear.Value, Convert.ToInt16(txt_teacher.Text));
                            MessageBox.Show("تم الإدخال بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //   txtid.Clear();
                            txttheo.Text = "0";
                            txtprac.Text = "0";
                        }
                    }
                    else if (btnadd.Text == "عدم الحفظ")
                    {
                        btnedit.Text = "تعديل";
                        btnadd.Text = "إضافة";
                        btndel.Show();
                        clear_deg();
                    }
                    txtid.Focus();
                }
                else { MessageBox.Show("الرجاء إدخال رقم الطالب ورمز المادة"); }
            }
            catch (Exception ex)
            { message_error(ex); }
        }
        private void message_error(Exception ex)
        {
            if (ex.Message == "The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Degrees_Materials1\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Material\", column 'id'.\r\nThe statement has been terminated.")
            { MessageBox.Show("رمز المادة خطأ"); }
            else if (ex.Message == "The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Degree_Student\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Student\", column 'id'.\r\nThe statement has been terminated.")
            { MessageBox.Show("رقم الطالب غير موجود"); }
            else if (ex.Message=="The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Degree_Teacher\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Teacher\", column 'id'.\r\nThe statement has been terminated.")
            {
                MessageBox.Show("رقم المدرس غير موجود");
            }
            else if (ex.Message == "Violation of UNIQUE KEY constraint 'PK_UNIQUE_ID_studen_mat'. Cannot insert duplicate key in object 'dbo.Degree'. The duplicate key value is (" + txtid.Text + ", " + txtmat.Text + ").\r\nThe statement has been terminated.")
            {
                System.Data.DataTable dt = deg.replace_fail_degree(txtid.Text, txtmat.Text);
                if (dt.Rows.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show("الطالب لديه علامة راسبة سابقة في هذه المادة, هل تريد حذفها واضافة العلامة الجديدة", "تعديل العلامة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        DialogResult dialog1 = MessageBox.Show("هل تريد حذف علامة العملي واضافة العلامة الجديدة", "تعديل العلامة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog1 == DialogResult.Yes)
                        {
                            deg.delete_degree(txtid.Text, txtmat.Text);
                            deg.insert_degree(txtid.Text, txtmat.Text, Convert.ToInt16(txtprac.Text), Convert.ToInt16(txttheo.Text), cmbseas.SelectedIndex + 1, dtyear.Value, Convert.ToInt16(txt_teacher.Text));
                            MessageBox.Show("تم الإدخال بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dialog1 == DialogResult.No)
                        {
                            deg.edit_degree_prac(txtid.Text, txtmat.Text, Convert.ToInt16(txttheo.Text), cmbseas.SelectedIndex + 1, dtyear.Value, Convert.ToInt16(txt_teacher.Text));
                            MessageBox.Show("تم تعديل علامة النظري بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("تم الغاء العملية");
                    }
                }
                else
                MessageBox.Show("الطالب رقم" + txtid.Text + " لديه علامة سابقة في هذه المادة"); }
            else if (ex.Message == "The INSERT statement conflicted with the CHECK constraint \"CK_Degrees\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Degree\", column 'degree_practical'.\r\nThe statement has been terminated.")
            { MessageBox.Show("لا يمكن أن تكون علامة العملي أكبر من 30"); }
            else if (ex.Message == "The INSERT statement conflicted with the CHECK constraint \"CK_Degrees_theor\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Degree\".\r\nThe statement has been terminated.")
            { MessageBox.Show("العلامة النهائية لا يمكن ان تكون أكبر من 100"); }
            else if (ex.Message == "The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Degree_Material\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Material\", column 'id'.\r\nThe statement has been terminated.")
            { MessageBox.Show("الرجاء التأكد من رمز المادة"); }
            else { MessageBox.Show(ex.Message); }
            textBox2.Text = ex.Message.ToString();
        }

        public void clear_deg()
        {
            txtid.Clear();
            txttheo.Text = "0";
            txtprac.Text = "0";
            txtmat.Clear();
            cmbseas.SelectedIndex = -1;
            dtyear.Value = DateTime.Now;
            txt_teacher.Clear();
            txt_teacher.Text = "0";

        }

        private void dataGridViewAll_Deg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (theDelete == false)
            {

                txtid.Text = dataGridViewAll_Deg.CurrentRow.Cells[0].Value.ToString();
                txtmat.Text = dataGridViewAll_Deg.CurrentRow.Cells[3].Value.ToString();
                txtprac.Text = dataGridViewAll_Deg.CurrentRow.Cells[4].Value.ToString();
                txttheo.Text = dataGridViewAll_Deg.CurrentRow.Cells[5].Value.ToString();
                if (dataGridViewAll_Deg.CurrentRow.Cells[7].Value.ToString() != "")
                {
                    cmbseas.SelectedIndex = Convert.ToInt16(dataGridViewAll_Deg.CurrentRow.Cells[7].Value.ToString()) - 1;
                }
                dtyear.Text = dataGridViewAll_Deg.CurrentRow.Cells[8].Value.ToString();

                panel2.Hide();
                btnedit.Text = "حفظ";
                btnadd.Text = "عدم الحفظ";
            }

            else if (theDelete == true)
            {
                string id_stud = dataGridViewAll_Deg.CurrentRow.Cells[0].Value.ToString();
                string id_mat = dataGridViewAll_Deg.CurrentRow.Cells[3].Value.ToString();
                DialogResult dialog = MessageBox.Show("هل تريد حذف هذه الدرجة؟", "حذف درجة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {

                    deg.delete_degree(id_stud, id_mat);
                    dataGridViewAll_Deg.DataSource = deg.GET_All_DEGREE();
                    MessageBox.Show("تم الحذف بنجاح", "حذف درجة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_search_deg.Clear();
                    txt_search_deg.Focus();
                }
                else
                {
                    panel2.Hide();
                    theDelete = false;
                    btndel.Show();
                    txt_search_deg.Clear();
                }
            }
        }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
}

        private void dataGridView_mat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmat.Text = dataGridView_mat.CurrentRow.Cells[0].Value.ToString();
                txt_matid_lot.Text = dataGridView_mat.CurrentRow.Cells[0].Value.ToString();/////////////---------------------------------------------
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_search_deg.Text == "")
                {
                    dataGridViewAll_Deg.DataSource = deg.GET_All_DEGREE();
                }
                else
                {
                    try
                    {
                        dataGridViewAll_Deg.DataSource = deg.Search_Degree(txt_search_deg.Text, txt_search_deg.Text);
                    }
                    catch (Exception)
                    {
                        dataGridViewAll_Deg.DataSource = deg.Search_Degree("0", txt_search_deg.Text);
                    }

                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmbfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_mat.DataSource = deg.Get_All_Material(cmbfaculty.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex));
            get_names();
        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_mat.DataSource = deg.Get_All_Material(cmbfaculty.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex));
        }

        private void cmbSeson_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_mat.DataSource = deg.Get_All_Material(cmbfaculty.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex));
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_search_deg_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void US_Degree_Insert_Load(object sender, EventArgs e)
        {
            try
            {
                txtid.Focus();
                dataGridView_lot.DataSource = deg.get_all_name_in_year(0, 0);
                dataGridView_lot.Columns.Add("degree_prac", "علامة العملي");
                dataGridView_lot.Columns.Add("degree_theo", "علامة النظري");
                btn_one_Click(sender, e);
            }
            catch (Exception) { }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnedit.Text == "تعديل")
                {
                    panel2.Visible = true;
                    panel2.Size = new Size(805, 610);
                    panel2.Location = new System.Drawing.Point(360, 5);
                    panel2.BringToFront();
                    txt_search_deg.Focus();
                    dataGridViewAll_Deg.DataSource = deg.GET_All_DEGREE();
                    btndel.Hide();
                }


                else if (btnedit.Text == "حفظ")
                {
                    deg.edit_degree(txtid.Text, txtmat.Text, Convert.ToInt16(txtprac.Text), Convert.ToInt16(txttheo.Text), cmbseas.SelectedIndex + 1, dtyear.Value, Convert.ToInt16(txt_teacher.Text));
                    clear_deg();
                    MessageBox.Show("تم التعديل بنجاح", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnedit.Text = "تعديل";
                    btnadd.Text = "إضافة";
                    btndel.Show();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            btndel.Show();
            txt_search_deg.Clear();
            theDelete = false;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                theDelete = true;
                btndel.Hide();
                panel2.Visible = true;
                panel2.Size = new Size(805, 640);
                panel2.Location = new System.Drawing.Point(360, 7);
                dataGridViewAll_Deg.DataSource = deg.GET_All_DEGREE();
                txt_search_deg.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtstdname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtstdname.Text != "")
                {
                    dataGridView1.DataSource = stud.GET_stdnum(txtstdname.Text);
                    txtid.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //  dataGridView1.DataSource = stud.GET_stdname(txtid.Text);
                dataGridView1.DataSource = stud.Search_by3id(txtid.Text, (cmbfaculty.SelectedIndex + 1).ToString());
                if (dataGridView1.Rows.Count < 2)
                {
                    txtstdname.Text = dataGridView1.Rows[0].Cells[2].Value.ToString() + " " + dataGridView1.Rows[0].Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {
                txtstdname.Text = "";
            }
        }
        private void get_names()
        {
            try
            {
                int faculty = 0, year = 0;
                if (cmbfaculty.Text == "الهندسة المعلوماتية")
                { faculty = 4; }
                else { faculty = cmbfaculty.SelectedIndex + 1; }
                if (cmb_year_students.Text == "الخامسة") { year = 5; }
                else if (cmb_year_students.Text == "الرابعة") { year = 4; }
                else if (cmb_year_students.Text == "الثالثة") { year = 3; }
                else if (cmb_year_students.Text == "الثانية") { year = 2; }
                else if (cmb_year_students.Text == "الأولى") { year = 1; }
                else if (cmb_year_students.Text == "السادسة") { year = 6; }

                dataGridView_lot.DataSource = deg.get_all_name_in_year(faculty, year);
                // textBox2.Text = cmbfaculty.Text + "   " + cmbyear.Text + faculty.ToString() + "     " + year;
            }
            catch (Exception) { }
        }

        private void cmb_year_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_names();
        }

        private void btn_one_Click(object sender, EventArgs e)
        {
            //   panel_exam_record.Visible = false;
            panel_lot.Visible = false;
            btn_one.Enabled = false;
            btn_lot.Enabled = true;
            panel_one.Size = new Size(785, 494);
            panel_one.Location = new System.Drawing.Point(356, 110);
            panel_one.Visible = true;


            textBox1.Text = "* لا يمكن ادخال علامة لطالب غير مسجل في جدول الطلاب.\r\n* لا يمكن ادخال علامة لطالب في مادة إذا كان هناك علامة سابقة له في نفس المادة.\r\n* لا يمكن ترك الحقول (الرقم الجامعي, رقم المادة) فارغة.\r\n* علامة العملي لا يمكن أن تزيد عن 30.\r\n* العلامة النهائية لا يمكن أن تزيد عن 100.\r\n";
            //   if (groupBox1.Visible==false)
            //    {
            //    groupBox1. Visible = true;
            // for (int i = 700; i > 0; i-=5)
            // {panel_lot.Size = new Size(770,i); }
            //}
        }

        private void btn_lot_Click(object sender, EventArgs e)
        {

            panel_one.Visible = false;
            panel_lot.Visible = true;
            btn_one.Enabled = true;
            btn_lot.Enabled = false;
            dataGridView_lot.Size = new Size(507, 429);
            dataGridView_lot.Location = new System.Drawing.Point(277, 57);
            cmb_year_students.SelectedIndex = 4;
            panel_lot.Location = new System.Drawing.Point(360, 77);
            for (int i = 0; i < 700; i += 20)
            { panel_lot.Size = new Size(799, i); }
            panel2.Visible = false;
            //  }
            //panel_exam_record.Visible = false;
            textBox1.Text = "* يرجى تحديد السنة لعرض أسماء الدفعة. \r\n* يرجى الإنتباه لرقم المادة والدورة الامتحانية وسنة تقديم المادة قبل حفظ العلامات.  \r\n* لا يمكن ترك علامة أحد الطلاب فارغة في الجدول. \r\n* يمكن اضافة طالب غير موجود في الجدول عن طريق كتابة رقمه في أول حقل.";
            btn_manule_Click(sender, e);
        }

        private void cmb_year_students_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            get_names();
        }

        private void btn_insertlot_Click(object sender, EventArgs e)
        {
            int i = 0; bool ins = false, nu = true;
            try
            {
                if (txt_matid_lot.Text != "" && cmb_sesonlot.Text != "" && txt_teach.Text != "" && (cmb_year_students.Text != "" || dataGridView_lot.Rows.Count > 1))
                {
                    if (btn_exel.Enabled == false)
                    {
                        for (i = 0; i < dataGridView_lot.Rows.Count - 1; i++)
                        {
                            if (dataGridView_lot.Rows[i].Cells[0].Value == null && dataGridView_lot.Rows[i].Cells[1].Value == null)
                            {
                                MessageBox.Show("الرجاء ادخال علامة للطلب رقم " + dataGridView_lot.Rows[i].Cells[3].Value.ToString() + "في السطر " + i + 1);
                                nu = false;
                            }
                        }
                        if (nu == true)
                            for (i = 0; i < dataGridView_lot.Rows.Count - 1; i++)
                            {
                                try
                                {

                                    deg.insert_degree(dataGridView_lot.Rows[i].Cells[3].Value.ToString(), txt_matid_lot.Text,
                                                              Convert.ToInt16(dataGridView_lot.Rows[i].Cells[0].Value), Convert.ToInt16(dataGridView_lot.Rows[i].Cells[1].Value), cmbseas.SelectedIndex + 1, dateTimePicker1.Value, Convert.ToInt16(txt_teach.Text));
                                    ins = true;
                                    //  }
                                    //   else
                                    //  {
                                    //deg.insert_degree(dataGridView_lot_e.Rows[i].Cells[1].Value.ToString(), txt_matid_lot.Text,
                                    //    Convert.ToInt16(dataGridView_lot_e.Rows[i].Cells[4].Value), Convert.ToInt16(dataGridView_lot_e.Rows[i].Cells[5].Value), cmbseas.SelectedIndex + 1, dtyear.Value, Convert.ToInt16(txt_teach.Text));
                                    //  }
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Degree_Student\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Student\", column 'id'.\r\nThe statement has been terminated.")
                                    { MessageBox.Show("الطالب رقم " + dataGridView_lot.Rows[i].Cells[3].Value.ToString() + " غير موجود"); }
                                    //    else if (ex.Message== "Violation of UNIQUE KEY constraint 'PK_UNIQUE_ID_studen_mat'. Cannot insert duplicate key in object 'dbo.Degree'. The duplicate key value is (" + dataGridView_lot.Rows[i].Cells[3].Value.ToString() + ", " + txt_matid_lot.Text + ").\r\nThe statement has been terminated.")
                                    //    { MessageBox.Show("الرجاء ادخال علامة الطالب رقم" + dataGridView_lot.Rows[i].Cells[3].Value.ToString() );
                                    //        break;    }
                                    else
                                    {  //ex.Message = "Violation of UNIQUE KEY constraint 'PK_UNIQUE_ID_studen_mat'. Cannot insert duplicate key in object 'dbo.Degree'. The duplicate key value is (150410002, IES112).\r\nThe statement has been terminated."
                                        if (ex.Message == "Violation of UNIQUE KEY constraint 'PK_UNIQUE_ID_studen_mat'. Cannot insert duplicate key in object 'dbo.Degree'. The duplicate key value is (" + dataGridView_lot.Rows[i].Cells[3].Value.ToString() + ", " + txt_matid_lot.Text + ").\r\nThe statement has been terminated.")
                                            MessageBox.Show("الطالب رقم " + dataGridView_lot.Rows[i].Cells[3].Value.ToString() + " لديه علامة سابقة في هذه المادة");
                                        // textBox2.Text = ex.Message;
                                        //      else if (ex.Message == "Violation of UNIQUE KEY constraint 'PK_UNIQUE_ID_studen_mat'. Cannot insert duplicate key in object 'dbo.Degree'. The duplicate key value is (" + dataGridView_lot_e.Rows[i].Cells[1].Value.ToString() + ", " + txt_matid_lot.Text + ").\r\nThe statement has been terminated.")
                                        //         MessageBox.Show("الطالب رقم " + dataGridView_lot_e.Rows[i].Cells[1].Value.ToString() + " لديه علامة سابقة في هذه المادة");
                                        else message_error(ex);
                                    }
                                }
                            }
                        if (ins == true) MessageBox.Show("تم الإدخال بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        for (i = 0; i < dataGridView_lot_e.Rows.Count - 1; i++)
                        {
                            if (dataGridView_lot_e.Rows[i].Cells[4].Value == null && dataGridView_lot_e.Rows[i].Cells[5].Value == null)
                            {
                                MessageBox.Show("الرجاء ادخال علامة للطلب رقم " + dataGridView_lot.Rows[i].Cells[3].Value.ToString() + "في السطر " + i);
                                nu = false;
                            }
                        }
                        if (nu == true)
                            for (i = 0; i < dataGridView_lot_e.Rows.Count - 1; i++)
                            {
                                try
                                {
                                    deg.insert_degree(dataGridView_lot_e.Rows[i].Cells[1].Value.ToString(), txt_matid_lot.Text,
                                           Convert.ToInt16(dataGridView_lot_e.Rows[i].Cells[4].Value), Convert.ToInt16(dataGridView_lot_e.Rows[i].Cells[5].Value), cmbseas.SelectedIndex + 1, dateTimePicker1.Value, Convert.ToInt16(txt_teach.Text));
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message == "The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Degree_Student\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Student\", column 'id'.\r\nThe statement has been terminated.")
                                    { MessageBox.Show("الطالب رقم " + dataGridView_lot_e.Rows[i].Cells[1].Value.ToString() + " غير موجود"); }
                                    else
                                    {
                                        if (ex.Message == "Violation of UNIQUE KEY constraint 'PK_UNIQUE_ID_studen_mat'. Cannot insert duplicate key in object 'dbo.Degree'. The duplicate key value is (" + dataGridView_lot_e.Rows[i].Cells[1].Value.ToString() + ", " + txt_matid_lot.Text + ").\r\nThe statement has been terminated.")
                                            MessageBox.Show("الطالب رقم " + dataGridView_lot_e.Rows[i].Cells[1].Value.ToString() + " لديه علامة سابقة في هذه المادة");
                                        else message_error(ex);
                                    }
                                }
                            }
                        MessageBox.Show("تم الإدخال بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else { MessageBox.Show("الرجاء التأكد من اختيار المادة والفصل الامتحاني والسنة"); }
            }
            catch (Exception ex)
            {
                message_error(ex);
            }
        }



        public static System.Data.DataTable ConvertExcelToDataTable(string FileName)
        {
            System.Data.DataTable dtResult = null;
            int totalSheet = 0; //No of sheets on excel file  
            using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                System.Data.DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = string.Empty;
                if (dt != null)
                {
                    var tempDataTable = (from dataRow in dt.AsEnumerable()
                                         where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                         select dataRow).CopyToDataTable();
                    dt = tempDataTable;
                    totalSheet = dt.Rows.Count;
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    MessageBox.Show( dt.Rows[i]["TABLE_NAME"].ToString());
                    //}
                    if (dt.Rows.Count == 5)
                    {
                        sheetName = dt.Rows[3]["TABLE_NAME"].ToString();
                    }
                }
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds, "excelData");
                dtResult = ds.Tables["excelData"];
                objConn.Close();
                return dtResult; //Returning Dattable  
            }
        }
        private void طالبواحدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_one_Click(sender, e);
        }

        private void عدةطلابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_lot_Click(sender, e);
        }

        private void btn_manule_Click(object sender, EventArgs e)
        {
            btn_manule.Enabled = false;
            button1.Enabled = true;
            btn_exel.Visible = false;
            btn_exel.Enabled = false;
            dataGridView_lot_e.Visible = false;
        }

        private void إدخاليدويToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_manule_Click(sender, e);
        }

        private void إكسيلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void إستيرادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_exel_Click(sender, e);
        }

        private void btn_exel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("يجب أن تكون البيانات مرتبة ضمن الملف المضمن مع البرنامج\n  أو أن ترتب أرقام الطلاب ضمن العمود بي  \n وعلامات العملي ضمن العمود إي   \n  وعلامات النظري ضمن العمود إف");
            string path = "";
         //   openFileDialog1.Filter = "exel|*.xls;|*.xlsx";
            openFileDialog1.Filter = "exel|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            

            try
            {
                bool sert = true;
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = ConvertExcelToDataTable(path);
                dataGridView_lot_e.DataSource = null;
                dataGridView_lot_e.DataSource = dt;
                for (int i = 0; i < dataGridView_lot_e.Rows.Count - 1; i++)
                {
                    if (!dataGridView_lot_e.Rows[i].Cells[1].Value.ToString().All(Char.IsDigit)  || !dataGridView_lot_e.Rows[i].Cells[4].Value.ToString().All(Char.IsDigit)   || !dataGridView_lot_e.Rows[i].Cells[5].Value.ToString().All(Char.IsDigit))
                    {
                        sert = false;
                    }
                }
                if (sert==false)
                {
                    MessageBox.Show("الجدول لا يناسب التنسيق المحدد, يجب أن يكون الجدول مرتب \n الرقم في العمود الثاني \n علامة العملي في العمود  الخامس \n علامة النظري في العمود السادس \n وجميع القيم يجب أن تكون رقمية");
                    dataGridView_lot_e.DataSource = null;
                }
            }
            catch (Exception ex) {
                if (ex.Message=="وسيطة غير صحيحة.")
                {

                }
               else MessageBox.Show(ex.Message);

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            btn_exel.Enabled = true;
            btn_manule.Enabled = true;
            btn_exel.Visible = true;
            dataGridView_lot_e.Size = new Size(507, 429);
            dataGridView_lot_e.Location = new System.Drawing.Point(277, 57);
            dataGridView_lot_e.Visible = true;
        }

        private void عدةطلابToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btn_lot_Click(sender, e);
        }

        private void txt_teach_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = deg.get_techer_name_id(txt_teach.Text);
            if (dataGridView1.Rows.Count > 0)
            {
                txt_teach_namel.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                txt_teach.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }

        private void txt_teacher_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = deg.get_techer_name_id(txt_teacher.Text);
                if (dataGridView1.Rows.Count > 0)
                {
                    txt_techer_name1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    txt_teacher.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                }
            }
            catch (Exception)
            { }

        }

        private void txt_techer_name1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = deg.get_techer_name_id(txt_techer_name1.Text);
            if (dataGridView1.Rows.Count > 0)
            {
                txt_techer_name1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                txt_teacher.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }

        private void txt_teach_namel_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = deg.get_techer_name_id(txt_teach_namel.Text);
            if (dataGridView1.Rows.Count > 0)
            {
                txt_teach_namel.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                txt_teach.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }

        private void dataGridView_lot_e_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_teach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtprac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_teacher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttheo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}