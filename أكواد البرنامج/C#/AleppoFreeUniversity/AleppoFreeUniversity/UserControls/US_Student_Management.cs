using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace AleppoFreeUniversity.UserControls
{
    public partial class US_Student_Management : UserControl
    {
        BL.Cls_student std = new BL.Cls_student();
        DAL.DataAccessLayer da = new DAL.DataAccessLayer();
        Boolean theDelete = false;
        Boolean theDel = false;
        //Boolean vis = false;
        public US_Student_Management()
        {
            InitializeComponent();
            cmbcertType.SelectedIndex = 0;
        }


        private void US_Student_insert_Load(object sender, EventArgs e)
        {
            txtfname.Focus();
        }
        public void clear_std()
        {
            txt_id_student.Clear();
            txtbox.Clear();
            txtcity.Clear();
            txtdepart.Clear();
            txtfather.Clear();
            txtfname.Clear();
            txtlname.Clear();
            txtmother.Clear();
            txtphonNumber.Clear();
            txtcer_suors.Clear();
            dt_cer_date.Value = DateTime.Now;
            dtad_year.Value = DateTime.Now;
            dtbirthdate.Value = DateTime.Now;
            cmbad_type.SelectedIndex = 0;
            cmbcertType.SelectedIndex = 0;
            cmbfaculty.SelectedIndex = 0;
            cmbgender.SelectedIndex = 0;
            cmbyear.SelectedIndex = 0;
            txtSection.Text = "1"; txtSecond_language.Clear(); cmbMatrial_status.SelectedIndex = 0;
            txt_idPersonal.Clear(); txtHusband_name.Clear(); txtHusband_work.Clear(); txtChildren_Number.Text = "0"; txtChildren_age.Clear(); cmpMigration.SelectedIndex = 0; dtMigration_date.Value = DateTime.Now; txtFather_work.Clear(); txtHealth_status.Clear(); txtPersonal_notes.Clear();
            txtEmail.Clear(); txtphonNumber.Clear(); txtAddress_current.Clear(); txtAddress_original.Clear();
            txtcer_suors.Clear(); cmbcertType.SelectedIndex = 0; dt_cer_date.Value = DateTime.Now; txtCertifcate_state.Clear(); txtCertifcate_id.Clear(); txtCertifcate_total.Text = "0"; ofd.FileName = null;
            txtOld_universirt.Clear(); txtOld_faculty.Clear(); txtOld_Department.Clear(); dtad_year.Value = DateTime.Now; dtDate_ofStop.Value = DateTime.Now; cmbOld_yearStudy.SelectedIndex = 0; txtOld_documents_note.Clear();
            txtOld_Institute.Clear(); txtOld_Institute_department.Clear(); dtOld_Institute_date.Value = DateTime.Now; cmbOld_yearStudy.SelectedIndex = 0; txtOld_Institute_total.Text = "0"; txtOld_Institute_rating.Clear(); cmpOld_Institute_seson.SelectedIndex = 0;
            pic.Image = null;

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txt_search.Text == "")
                {
                    dataGridViewAll_Std.DataSource = std.GET_All_Student();
                }
                else
                {


                    dataGridViewAll_Std.DataSource = std.Search_Student_name(txt_search.Text);
                    //  dataGridViewAll_Std.DataSource = std.Search_Student(id_serch);      
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridViewAll_Std_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (theDelete == false)
            {

                txt_id_student.Text = dataGridViewAll_Std.CurrentRow.Cells[1].Value.ToString();
                txtfname.Text = dataGridViewAll_Std.CurrentRow.Cells[2].Value.ToString();
                txtlname.Text = dataGridViewAll_Std.CurrentRow.Cells[3].Value.ToString();
                txtfather.Text = dataGridViewAll_Std.CurrentRow.Cells[4].Value.ToString();
                txtmother.Text = dataGridViewAll_Std.CurrentRow.Cells[5].Value.ToString();
                string gen = dataGridViewAll_Std.CurrentRow.Cells[6].Value.ToString();
                if (gen == "True")
                {
                    cmbgender.SelectedIndex = 1;
                }
                else if (gen == "False")
                {
                    cmbgender.SelectedIndex = 0;
                }
                txtcity.Text = dataGridViewAll_Std.CurrentRow.Cells[7].Value.ToString();
                dtbirthdate.Text = dataGridViewAll_Std.CurrentRow.Cells[8].Value.ToString();
                txtbox.Text = dataGridViewAll_Std.CurrentRow.Cells[9].Value.ToString();
                cmbfaculty.SelectedIndex = Convert.ToInt16(dataGridViewAll_Std.CurrentRow.Cells[10].Value.ToString()) - 1;
                cmbyear.SelectedIndex = Convert.ToInt16(dataGridViewAll_Std.CurrentRow.Cells[11].Value.ToString()) - 1;
                txtphonNumber.Text = dataGridViewAll_Std.CurrentRow.Cells[12].Value.ToString();
                string cer = dataGridViewAll_Std.CurrentRow.Cells[13].Value.ToString();
                if (cer == "")
                {
                    cmbcertType.SelectedIndex = -1;
                }
                else
                {
                    cmbcertType.SelectedIndex = Convert.ToInt16(dataGridViewAll_Std.CurrentRow.Cells[13].Value.ToString()) - 1;
                }
                txtcer_suors.Text = dataGridViewAll_Std.CurrentRow.Cells[14].Value.ToString();
                dt_cer_date.Text = dataGridViewAll_Std.CurrentRow.Cells[15].Value.ToString();
                dtad_year.Text = dataGridViewAll_Std.CurrentRow.Cells[16].Value.ToString();
                string ad_type = dataGridViewAll_Std.CurrentRow.Cells[17].Value.ToString();
                if (ad_type == "True")
                {
                    cmbad_type.SelectedIndex = 1;
                }
                else if (ad_type == "False")
                {
                    cmbad_type.SelectedIndex = 0;
                }

                txtdepart.Text = dataGridViewAll_Std.CurrentRow.Cells[18].Value.ToString();// picture
                if (dataGridViewAll_Std.CurrentRow.Cells[19].Value.ToString() != "")
                {
                    byte[] bt = (byte[])dataGridViewAll_Std.CurrentRow.Cells[19].Value;
                    MemoryStream ms = new MemoryStream(bt);
                    pic.Image = Image.FromStream(ms);
                }
                txtSection.Text = dataGridViewAll_Std.CurrentRow.Cells[20].Value.ToString();
                txtSecond_language.Text = dataGridViewAll_Std.CurrentRow.Cells[21].Value.ToString();
                string family = dataGridViewAll_Std.CurrentRow.Cells[22].Value.ToString();
                if (family == "True")
                {
                    cmbMatrial_status.SelectedIndex = 1;
                }
                else if (family == "False")
                {
                    cmbMatrial_status.SelectedIndex = 0;
                }
                txt_idPersonal.Text = dataGridViewAll_Std.CurrentRow.Cells[23].Value.ToString();
                txtHusband_name.Text = dataGridViewAll_Std.CurrentRow.Cells[24].Value.ToString();
                txtHusband_work.Text = dataGridViewAll_Std.CurrentRow.Cells[25].Value.ToString();
                txtChildren_Number.Text = dataGridViewAll_Std.CurrentRow.Cells[26].Value.ToString();
                txtChildren_age.Text = dataGridViewAll_Std.CurrentRow.Cells[27].Value.ToString();
                string migration = dataGridViewAll_Std.CurrentRow.Cells[28].Value.ToString();
                if (migration == "True")
                {
                    cmpMigration.SelectedIndex = 1;
                }
                else if (migration == "False")
                {
                    cmpMigration.SelectedIndex = 0;
                }
                dtMigration_date.Text = dataGridViewAll_Std.CurrentRow.Cells[29].Value.ToString();
                txtFather_work.Text = dataGridViewAll_Std.CurrentRow.Cells[30].Value.ToString();
                txtHealth_status.Text = dataGridViewAll_Std.CurrentRow.Cells[31].Value.ToString();
                txtPersonal_notes.Text = dataGridViewAll_Std.CurrentRow.Cells[32].Value.ToString();
                txtEmail.Text = dataGridViewAll_Std.CurrentRow.Cells[33].Value.ToString();
                txtAddress_original.Text = dataGridViewAll_Std.CurrentRow.Cells[34].Value.ToString();
                txtAddress_current.Text = dataGridViewAll_Std.CurrentRow.Cells[35].Value.ToString();
                txtCertifcate_state.Text = dataGridViewAll_Std.CurrentRow.Cells[36].Value.ToString();
                txtCertifcate_id.Text = dataGridViewAll_Std.CurrentRow.Cells[37].Value.ToString();
                txtCertifcate_total.Text = dataGridViewAll_Std.CurrentRow.Cells[38].Value.ToString();
                txtOld_universirt.Text = dataGridViewAll_Std.CurrentRow.Cells[39].Value.ToString();
                txtOld_faculty.Text = dataGridViewAll_Std.CurrentRow.Cells[40].Value.ToString();
                txtOld_Department.Text = dataGridViewAll_Std.CurrentRow.Cells[41].Value.ToString();
                dtOld_yearOfAdmission.Text = dataGridViewAll_Std.CurrentRow.Cells[42].Value.ToString();
                dtDate_ofStop.Text = dataGridViewAll_Std.CurrentRow.Cells[43].Value.ToString();
                if (dataGridViewAll_Std.CurrentRow.Cells[44].Value.ToString() != "")
                { cmbOld_yearStudy.SelectedIndex = Convert.ToInt16(dataGridViewAll_Std.CurrentRow.Cells[44].Value.ToString()) - 1; }
                txtOld_documents_note.Text = dataGridViewAll_Std.CurrentRow.Cells[45].Value.ToString();
                txtOld_Institute.Text = dataGridViewAll_Std.CurrentRow.Cells[46].Value.ToString();
                txtOld_Institute_department.Text = dataGridViewAll_Std.CurrentRow.Cells[47].Value.ToString();
                dtOld_Institute_date.Text = dataGridViewAll_Std.CurrentRow.Cells[48].Value.ToString();
                if (dataGridViewAll_Std.CurrentRow.Cells[49].Value.ToString() != "")
                { cmpOld_Institute_seson.SelectedIndex = Convert.ToInt16(dataGridViewAll_Std.CurrentRow.Cells[49].Value.ToString()) - 1; }
                txtOld_Institute_total.Text = dataGridViewAll_Std.CurrentRow.Cells[50].Value.ToString();
                txtOld_Institute_rating.Text = dataGridViewAll_Std.CurrentRow.Cells[51].Value.ToString();
                ////////
                if (txtSection.Text == "") { txtSection.Text = "1"; }
                if (txtChildren_Number.Text == "") { txtChildren_Number.Text = "0"; }
                if (txtCertifcate_total.Text == "") { txtCertifcate_total.Text = "0"; }
                if (txtOld_Institute_total.Text == "") { txtOld_Institute_total.Text = "0"; }
                ///////////

                txt_search.Clear();
                panel1.Hide();
                btnedit.Text = "حفظ";
                btnadd.Text = "عدم الحفظ";
            }
            else if (theDelete == true)
            {
                string id_stud = dataGridViewAll_Std.CurrentRow.Cells[1].Value.ToString();
                string name1 = dataGridViewAll_Std.CurrentRow.Cells[2].Value.ToString();
                string name3 = dataGridViewAll_Std.CurrentRow.Cells[3].Value.ToString();
                string name2 = dataGridViewAll_Std.CurrentRow.Cells[4].Value.ToString();
                string fullName = name1 + " " + name2 + " " + name3;
                DialogResult dialog = MessageBox.Show(" (" + id_stud + ") " + "هل تريد حذف الطالب" + " " + fullName, "حذف طالب", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    std.delet_student(id_stud);
                    dataGridViewAll_Std.DataSource = std.GET_All_Student();
                    MessageBox.Show("تم الحذف بنجاح", "حذف طالب", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_search.Clear();
                    txt_search.Focus();
                }
                else
                {
                    panel1.Hide();
                    theDelete = false;
                    btndel.Show();
                    txt_search.Clear();
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_id_student_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtfname.Text != "" && txtlname.Text != "" && txt_id_student.Text != "")
                {
                    if (btnadd.Text == "إضافة")
                    {

                        std.add_student(txt_id_student.Text, txtfname.Text, txtlname.Text, txtfather.Text, txtmother.Text,
                        Convert.ToBoolean(cmbgender.SelectedIndex), txtcity.Text, dtbirthdate.Value, txtbox.Text, cmbfaculty.SelectedIndex + 1,
                       cmbyear.SelectedIndex + 1, txtphonNumber.Text, cmbcertType.SelectedIndex + 1, txtcer_suors.Text, dt_cer_date.Value, dtad_year.Value,
                        Convert.ToBoolean(cmbad_type.SelectedIndex), txtdepart.Text);
                        byte[] byt1 = null, file1 = null;
                        if (pic.Image != null)
                        { MemoryStream ms = new MemoryStream(); pic.Image.Save(ms, pic.Image.RawFormat); byt1 = ms.ToArray(); }

                        if (ofd.FileName != "openFileDialog1")
                        {
                            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read); BinaryReader br = new BinaryReader(fs);
                            file1 = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
                        }
                        std.add_student_detile(txt_id_student.Text, byt1, Convert.ToInt16(txtSection.Text)
                        , txtSecond_language.Text, Convert.ToBoolean(cmbMatrial_status.SelectedIndex), txt_idPersonal.Text, txtHusband_name.Text, txtHusband_work.Text,
                         Convert.ToInt16(txtChildren_Number.Text), txtChildren_age.Text, Convert.ToBoolean(cmpMigration.SelectedIndex), dtMigration_date.Value, txtFather_work.Text, txtHealth_status.Text, txtPersonal_notes.Text, txtEmail.Text, txtAddress_original.Text,
                          txtAddress_current.Text, txtCertifcate_state.Text, txtCertifcate_id.Text, Convert.ToInt16(txtCertifcate_total.Text),
                         file1, txtOld_Department.Text, txtOld_faculty.Text, txtOld_Department.Text, dtOld_yearOfAdmission.Value,
                         dtDate_ofStop.Value, cmbOld_yearStudy.SelectedIndex + 1, txtOld_documents_note.Text, file1, txtOld_Institute.Text, txtOld_Institute_department.Text, dtOld_Institute_date.Value, cmpOld_Institute_seson.SelectedIndex + 1,
                         txtOld_Institute_total.Text, txtOld_Institute_rating.Text);
                        clear_std();
                        MessageBox.Show("تم الإدخال بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (btnadd.Text == "عدم الحفظ")
                    {
                        btnedit.Text = "تعديل";
                        btnadd.Text = "إضافة";
                        btndel.Show();
                        clear_std();
                    }
                }
                else { MessageBox.Show("الرجاء التأكد أن الحقول(اسم الطالب,الكنية,الرقم الجامعي,الكلية) ليست فارغة"); }
            }
            catch (Exception ex)
            {
                string n = txt_id_student.Text;
                string m = ex.Message;
                //    string msg = "";
                if (m == "Violation of PRIMARY KEY constraint 'PK_Students'. Cannot insert duplicate key in object 'dbo.Student'. The duplicate key value is (" + n + ").\r\nThe statement has been terminated.")
                {
                    MessageBox.Show("هذا الرقم موجود مسبقا لطالب آخر الرجاء ادخال رقم جديد");
                }
                else if (m == "The INSERT statement conflicted with the CHECK constraint \"CK_Students_yearOfAdmission\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Student\", column 'yearOfAdmission'.\r\nThe statement has been terminated.")
                {
                    MessageBox.Show("الرجاء تغيير تاريخ القبول لما بعد 2015");
                }
                else if (m == "The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_Students_University_Faculties\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.University_Faculty\", column 'id'.\r\nThe statement has been terminated.")
                {
                    MessageBox.Show("الرجاء ادخال الكلية");
                }
                else MessageBox.Show(m);


            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnedit.Text == "تعديل")
            {
                panel1.Visible = true;
                panel1.Size = new Size(1160, 665);
                panel1.Location = new Point(2, 2);

                dataGridViewAll_Std.DataSource = std.GET_All_Student();
                txt_search.Focus();
                btndel.Hide();
            }
            else if (btnedit.Text == "حفظ")
            {
                try
                {
                    byte[] byt1 = null;
                    if (pic.Image != null)
                    { MemoryStream ms = new MemoryStream(); pic.Image.Save(ms, pic.Image.RawFormat); byt1 = ms.ToArray(); }
                    //    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read); BinaryReader br = new BinaryReader(fs);
                    //    byte[] file1 = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
                    DataTable dt = std.chek_student_detile(txt_id_student.Text);
                    if (dt.Rows.Count < 1)
                    {
                        std.add_student_detile(txt_id_student.Text, byt1, Convert.ToInt16(txtSection.Text)
                       , txtSecond_language.Text, Convert.ToBoolean(cmbMatrial_status.SelectedIndex), txt_idPersonal.Text, txtHusband_name.Text, txtHusband_work.Text,
                        Convert.ToInt16(txtChildren_Number.Text), txtChildren_age.Text, Convert.ToBoolean(cmpMigration.SelectedIndex), dtMigration_date.Value, txtFather_work.Text, txtHealth_status.Text, txtPersonal_notes.Text, txtEmail.Text, txtAddress_original.Text,
                         txtAddress_current.Text, txtCertifcate_state.Text, txtCertifcate_id.Text, Convert.ToInt16(txtCertifcate_total.Text),
                        null, txtOld_Department.Text, txtOld_faculty.Text, txtOld_Department.Text, dtOld_yearOfAdmission.Value,
                        dtDate_ofStop.Value, cmbOld_yearStudy.SelectedIndex + 1, txtOld_documents_note.Text, null, txtOld_Institute.Text, txtOld_Institute_department.Text, dtOld_Institute_date.Value, cmpOld_Institute_seson.SelectedIndex + 1,
                        txtOld_Institute_total.Text, txtOld_Institute_rating.Text);
                    }


                    std.edit_student(txt_id_student.Text, txtfname.Text, txtlname.Text, txtfather.Text, txtmother.Text,
                        Convert.ToBoolean(cmbgender.SelectedIndex), txtcity.Text, dtbirthdate.Value, txtbox.Text, cmbfaculty.SelectedIndex + 1,
                        cmbyear.SelectedIndex + 1, txtphonNumber.Text, cmbcertType.SelectedIndex + 1, txtcer_suors.Text, dt_cer_date.Value, dtad_year.Value,
                        Convert.ToBoolean(cmbad_type.SelectedIndex), txtdepart.Text,
                        byt1,
                        Convert.ToInt16(txtSection.Text)
                       , txtSecond_language.Text, Convert.ToBoolean(cmbMatrial_status.SelectedIndex), txt_idPersonal.Text, txtHusband_name.Text, txtHusband_work.Text,
                        Convert.ToInt16(txtChildren_Number.Text)
                        , txtChildren_age.Text, Convert.ToBoolean(cmpMigration.SelectedIndex), dtMigration_date.Value, txtFather_work.Text, txtHealth_status.Text, txtPersonal_notes.Text, txtEmail.Text, txtAddress_original.Text,
                         txtAddress_current.Text, txtCertifcate_state.Text, txtCertifcate_id.Text,
                         Convert.ToInt16(txtCertifcate_total.Text),
                       /* file1,*/ txtOld_Department.Text, txtOld_faculty.Text, txtOld_Department.Text, dtOld_yearOfAdmission.Value,
                        dtDate_ofStop.Value, cmbOld_yearStudy.SelectedIndex + 1, txtOld_documents_note.Text,  /* file1,*/ txtOld_Institute.Text, txtOld_Institute_department.Text, dtOld_Institute_date.Value, cmpOld_Institute_seson.SelectedIndex + 1,
                        Convert.ToInt16(txtOld_Institute_total.Text), txtOld_Institute_rating.Text);

                    clear_std();
                    MessageBox.Show("تم التعديل بنجاح", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                        if (ex.Message == "The UPDATE statement conflicted with the FOREIGN KEY constraint \"FK_Students_Certificate_SEC\". The conflict occurred in database \"AleppoFreeUniversity\", table \"dbo.Certificate_SEC\", column 'id'.\r\nThe statement has been terminated.")
                        { }
                        else
                            MessageBox.Show(ex.Message);
                }
                btnedit.Text = "تعديل";
                btnadd.Text = "إضافة";
                btndel.Show();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                theDelete = true;
                btndel.Hide();
                panel1.Visible = true;
                panel1.Size = new Size(1160, 665);
                panel1.Location = new Point(2, 2);
                dataGridViewAll_Std.DataSource = std.GET_All_Student();
                txt_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            btndel.Show();
            txt_search.Clear();
            theDelete = false;
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            btn_fees.Enabled = true;
            btn_cncl.Enabled = true;
            panel_fees.Visible = false;
            panel_succes.Visible = false;
            btn_succes.Visible = true;
            panel2.Hide();
            panel3.Hide();
            btn_pic.Hide();
            pic.Hide();
            panel_fees.Hide();
            panel_list.Visible = true;
            dataGridViewlist.Visible = true;
            dataGridViewlist.Dock = DockStyle.Fill;
           //5 dataGridViewAll_Std.Rows.Clear();
            dataGridViewAll_Std.DataSource = std.GET_All_Student();
            list();
            txt_serch_list.Focus();
            btn_list.Enabled = false;
            pic.Hide();
            btn_pic.Hide();
            panel_lists.Visible = true;
            panel_add.Size = new Size(1132, 595);
            panel_add.Location = new Point(3, 74);
            panel_add.Visible = true;
        }
        private void list()
        {
            dataGridViewlist.Rows.Clear();

            for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewlist.Rows[0].Clone();
                row.Cells[0].Value = dataGridViewAll_Std.Rows[i].Cells[0].Value.ToString();
                row.Cells[1].Value = dataGridViewAll_Std.Rows[i].Cells[1].Value.ToString();
                row.Cells[2].Value = dataGridViewAll_Std.Rows[i].Cells[2].Value.ToString();
                row.Cells[3].Value = dataGridViewAll_Std.Rows[i].Cells[3].Value.ToString();
                row.Cells[4].Value = dataGridViewAll_Std.Rows[i].Cells[4].Value;
                row.Cells[5].Value = dataGridViewAll_Std.Rows[i].Cells[5].Value;
                if (dataGridViewAll_Std.Rows[i].Cells[6].Value.ToString() != "")
                {
                    if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[6].Value) == true) { row.Cells[6].Value = "أنثى"; }
                    else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[6].Value) == false) { row.Cells[6].Value = "ذكر"; }
                    else row.Cells[6].Value = "";
                }
                row.Cells[7].Value = dataGridViewAll_Std.Rows[i].Cells[7].Value;
                DateTime dt = new DateTime();
                if (dataGridViewAll_Std.Rows[i].Cells[8].Value.ToString() != "")
                { dt = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[8].Value); 
                row.Cells[8].Value = dt.Year + "/" + dt.Month + "/" + dt.Day;}
                row.Cells[9].Value = dataGridViewAll_Std.Rows[i].Cells[9].Value;
                 if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 1)
                { row.Cells[10].Value = "الطب البشري"; }
                else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 2)
                { row.Cells[10].Value = "طب الأسنان"; }
                else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 3)
                { row.Cells[10].Value = "الصيدلة"; }
                else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 4)
                { row.Cells[10].Value = "الهندسة المعلوماتية"; }
                else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 5)
                { row.Cells[10].Value = "هندسة الميكاترونيك"; }
                else
                { row.Cells[10].Value = dataGridViewAll_Std.Rows[i].Cells[10].Value; }
                if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[11].Value) == 6&& Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 4)
                { row.Cells[11].Value = "خريج"; }
                else
                {
                    row.Cells[11].Value = dataGridViewAll_Std.Rows[i].Cells[11].Value;
                }
                row.Cells[12].Value = dataGridViewAll_Std.Rows[i].Cells[12].Value.ToString();
                //  row.Cells[13].Value = dataGridViewAll_Std.Rows[i].Cells[13].Value.ToString();               
                    if (dataGridViewAll_Std.Rows[i].Cells[13].Value.ToString() != "")
                {
                    if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[13].Value) == 1)
                    { row.Cells[13].Value = "علمي"; }
                    else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[13].Value) == 2)
                    { row.Cells[13].Value = "أدبي"; }
                    else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[13].Value) == 3)
                    { row.Cells[13].Value = "مهنية صناعية"; }
                    else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[13].Value) == 4)
                    { row.Cells[13].Value = "ثانوية شرعية"; }
                    else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[13].Value) == 5)
                    { row.Cells[13].Value = "تجارة"; }
                    else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[13].Value) == 6)
                    { row.Cells[13].Value = "معياري"; }
                }
                row.Cells[14].Value = dataGridViewAll_Std.Rows[i].Cells[14].Value;
                DateTime dt1 = new DateTime();
                if (dataGridViewAll_Std.Rows[i].Cells[15].Value.ToString() != "")
                { dt1 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[15].Value);
                row.Cells[15].Value = dt1.Year; }
                DateTime dt2 = new DateTime();
                if (dataGridViewAll_Std.Rows[i].Cells[16].Value.ToString() != "")
                { dt2 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[16].Value); 
                row.Cells[16].Value = dt2.Year;
                }
                if (dataGridViewAll_Std.Rows[i].Cells[17].Value.ToString() != "")
                {
                    if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[17].Value) == true) { row.Cells[17].Value = "موازي"; }
                    else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[17].Value) == false) { row.Cells[17].Value = "عام"; }
                    else row.Cells[17].Value = "";
                }
                row.Cells[18].Value = dataGridViewAll_Std.Rows[i].Cells[18].Value;
                dataGridViewlist.Rows.Add(row);
            }

        }

        private void btn_cncl_Click(object sender, EventArgs e)
        {
            btn_cncl.Enabled = false;
            btn_fees.Enabled = true;
            panel_fees.Visible = false;
            panel_succes.Visible = false;
            btn_succes.Visible = false;
            panel_lists.Visible = false;
            panel2.Show();
            panel3.Show();
            btn_pic.Show();
            //button1.Show();
            label2.Show();
            pic.Show();
            btn_pic.Show();
            groupBox3.Show();
            pic.Show();
            btn_list.Enabled = true;
            panel_list.Visible = false;
            dataGridViewlist.Visible = false;
            panel_fees.Hide();
            btn_list.Visible = true;
            panel_add.Size = new Size(1132, 618);
            panel_add.Location = new Point(3, 49);
            panel_add.Visible = true;
            cmbMatrial_status.SelectedIndex = 1;
            cmpMigration.SelectedIndex = 0;


        }

        private void txt_serch_list_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txt_serch_list.Text == "")
                {
                    dataGridViewAll_Std.DataSource = std.GET_All_Student();
                    dataGridViewlist.Rows.Clear();
                    //
                    dt_fees.DataSource = std.get_all_fees();
                    //

                    list();

                }
                else
                {
                    //dataGridViewlist.Columns.Clear();
                    dataGridViewAll_Std.DataSource = std.Search_Student_name(txt_serch_list.Text);
                    dataGridViewlist.Rows.Clear();
                    //
                    dt_fees.DataSource = std.get_std_fees(txt_serch_list.Text);
                    //
                    list();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "image|*.jpg;|*.png;|*.pmb";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pic.Image = Image.FromFile(of.FileName);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel_add.Size = new Size(1132, 699);
            }

            else
            {
                panel_add.Size = new Size(1132, 619);
            }
        }
        public string path_file;
        private void btn_openduc_Click(object sender, EventArgs e)
        {
            ofd.Filter = "ALL files (*.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path_file = Path.GetExtension(ofd.FileName);
            }
        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void btn_fees_Click(object sender, EventArgs e)
        {
            btn_fees_list_Click(sender, e);
            btn_fees.Enabled = false;
            btn_cncl.Enabled = true;
            panel_add.Visible = false;
            panel_succes.Visible = false;
            btn_succes.Visible = false;
            panel_lists.Visible = false;
            panel_fees.Size = new Size(1034, 542);
            panel_fees.Location = new Point(80, 79);
            panel_fees.Visible = true;
            dataGridViewlist.Visible = false;
            panel_list.Hide();
            panel2.Hide();
            panel3.Hide();
            btn_pic.Hide();
            //button1.Hide();
            pic.Hide();
            label2.Hide();
            groupBox3.Hide();
       //    dt_fees.DataSource = std.get_all_fees();
          //  dt_fees.DataSource = std.all_fees_with_student(3,0);
            txt_serch_list.Focus();
            btn_list.Enabled = true;
            dt_fees.Size = new Size(1024, 419);
            dt_fees.Location = new Point(5, 60);
            dt_fees.Visible = true;
            dt_fees.DataSource = std.all_fees_with_student(3, 0);
            cmb_fees_fuc.SelectedIndex = 3;
            btn_fees_list.Enabled = false;
            export = "all_fees_with_student";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btn_add_fees_Click(object sender, EventArgs e)
        {
            dt_fees.Hide();
            panel_list.Hide();
            group_fees.Visible = true;
            group_fees.Location = new Point(30, 59);
            group_fees.Size = new Size(981, 302);
            btn_add_f.Text = "إضافة";
            //  btn_can.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = true;
            btn_fees_list.Enabled =true ;
            btn_add_fees.Enabled =false ;
            btn_edit_fees.Enabled = true;
            btn_del_fees.Enabled = true;
            panel_fees_year.Visible = false ;
            btn_fees_export.Visible = false ;
            btn_cnl_dt_fees.Visible = false;
        }

        private void btn_edit_fees_Click(object sender, EventArgs e)
        {
            dt_fees.DataSource = std.get_all_fees();
            panel_list.Visible = true;
            theDel = false;
            dt_fees.Size = new Size(1024, 419);
            dt_fees.Location = new Point(5, 60);
            dt_fees.Visible = true;
            btn_cnl_dt_fees.Visible = true;
            panel_list.Show();
            label3.Text = "البحث حسب الرقم الجامعي:";
            //group_fees.Visible = true;
            //  group_fees.Location = new Point(17, 14);
            //   group_fees.Size = new Size(990, 310);
            btn_can.Visible = true;
            btn_fees_list.Enabled = true;
            btn_add_fees.Enabled = true;
            btn_edit_fees.Enabled =false;
            btn_del_fees.Enabled = true;
            panel_fees_year.Visible = false;
            btn_fees_export.Visible = true;
            export = "all_fees";
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_del_fees_Click(object sender, EventArgs e)
        {
            dt_fees.DataSource = std.get_all_fees();
            theDel = true;
            dt_fees.Size = new Size(1024, 419);
            dt_fees.Location = new Point(5, 60);
            dt_fees.Visible = true;
            btn_cnl_dt_fees.Visible = true;
            panel_list.Show();
            label3.Text = "البحث حسب الرقم الجامعي:";
            btn_fees_list.Enabled = true;
            btn_add_fees.Enabled = true;
            btn_edit_fees.Enabled = true;
            btn_del_fees.Enabled =false;
            panel_fees_year.Visible = false;
            btn_fees_export.Visible = false;
        }

        private void dt_fees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                panel_list.Visible = false;
                textBox3.Visible = false;


                if (btn_fees_list.Enabled == false)
                {

                }
                else
                {
                    int acad = Convert.ToInt16(dt_fees.CurrentRow.Cells[11].Value.ToString());


                    if (theDel == false)
                    {
                        dt_fees.Visible = false;
                        btn_cnl_dt_fees.Visible = false;
                        txt_std_id.Text = dt_fees.CurrentRow.Cells[0].Value.ToString();
                        txt_full.Text = dt_fees.CurrentRow.Cells[3].Value.ToString();
                        txt_f_paid.Text = dt_fees.CurrentRow.Cells[4].Value.ToString();
                        string does = dt_fees.CurrentRow.Cells[5].Value.ToString();
                        if (does == "True")
                        {
                            cmb_d_paid.SelectedIndex = 1;
                        }
                        else if (does == "False")
                        {
                            cmb_d_paid.SelectedIndex = 0;
                        }
                        txt_dis_rate.Text = dt_fees.CurrentRow.Cells[6].Value.ToString();
                        txt_amount.Text = dt_fees.CurrentRow.Cells[7].Value.ToString();
                        txt_after_dis.Text = dt_fees.CurrentRow.Cells[8].Value.ToString();
                        txt_reason.Text = dt_fees.CurrentRow.Cells[9].Value.ToString();
                        txt_old_unpaid.Text = dt_fees.CurrentRow.Cells[10].Value.ToString();
                        if (acad == 1)
                        {
                            cmb_acad_year.SelectedIndex = 0;
                        }
                        else if (acad == 2)
                        {
                            cmb_acad_year.SelectedIndex = 1;
                        }
                        else if (acad == 3)
                        {
                            cmb_acad_year.SelectedIndex = 2;
                        }
                        else if (acad == 4)
                        {
                            cmb_acad_year.SelectedIndex = 3;
                        }
                        else if (acad == 5)
                        {
                            cmb_acad_year.SelectedIndex = 4;
                        }
                        else
                        {
                            cmb_acad_year.SelectedIndex = 5;
                        }

                        txt_stud_year.Text = dt_fees.CurrentRow.Cells[12].Value.ToString();
                        txt_vouch_num.Text = dt_fees.CurrentRow.Cells[13].Value.ToString();
                        dt_date_paid.Text = dt_fees.CurrentRow.Cells[14].Value.ToString();
                        txt_notes.Text = dt_fees.CurrentRow.Cells[15].Value.ToString();
                        ////////
                        ///////////

                        txt_serch_list.Clear();
                        textBox2.Visible = true;
                        txt_full.Focus();
                        txt_std_id.Enabled = false;
                        btn_add_f.Text = "حفظ";
                        btn_fees_list.Enabled = true;
                        btn_add_fees.Enabled = false;
                        btn_edit_fees.Enabled = true;
                        btn_del_fees.Enabled = true;
                    }
                    else if (theDel == true)
                    {
                        string stud_id = dt_fees.CurrentRow.Cells[0].Value.ToString();
                        string std_name = dt_fees.CurrentRow.Cells[1].Value.ToString();
                        string stud_year = dt_fees.CurrentRow.Cells[12].Value.ToString();
                        DialogResult dialog = MessageBox.Show(" (" + stud_id + ") " + "هل تريد حذف رسوم الطالب" + " " + std_name, "حذف رسوم", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialog == DialogResult.Yes)
                        {
                            std.delete_fees(stud_id, acad, stud_year);
                            dt_fees.DataSource = std.get_all_fees();
                            MessageBox.Show("تم الحذف بنجاح", "حذف رسوم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_serch_list.Clear();
                            txt_serch_list.Focus();
                        }
                        else
                        {
                            theDelete = false;
                            txt_serch_list.Clear();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_f_Click(object sender, EventArgs e)
        {

            try
            {
                if (txt_id_student.Text != null && txt_f_paid.Text != null && cmb_d_paid.SelectedIndex != -1 && cmb_acad_year.SelectedIndex != -1 && txt_after_dis.Text != null && txt_full.Text != null && txt_dis_rate.Text != null && txt_amount.Text != null && txt_after_dis.Text != null && txt_old_unpaid.Text != null)
                {


                    if (btn_add_f.Text == "إضافة")
                    {
                        std.add_fees(txt_std_id.Text, Convert.ToInt16(txt_full.Text), float.Parse(txt_f_paid.Text), Convert.ToBoolean(cmb_d_paid.SelectedIndex), float.Parse(txt_dis_rate.Text), float.Parse(txt_amount.Text), float.Parse(txt_after_dis.Text), txt_reason.Text, float.Parse(txt_old_unpaid.Text), cmb_acad_year.SelectedIndex + 1, txt_stud_year.Text, txt_vouch_num.Text, dt_date_paid.Value, txt_notes.Text);
                        clear_fees();
                        dt_fees.DataSource = std.get_all_fees();
                        MessageBox.Show("تم الإدخال بنجاح", "نجاح الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (btn_add_f.Text == "حفظ")
                    {
                        std.edit_fees(txt_std_id.Text,
                            Convert.ToInt16(txt_full.Text), float.Parse(txt_f_paid.Text), Convert.ToBoolean(cmb_d_paid.SelectedIndex), float.Parse(txt_dis_rate.Text), float.Parse(txt_amount.Text), float.Parse(txt_after_dis.Text), txt_reason.Text, float.Parse(txt_old_unpaid.Text), cmb_acad_year.SelectedIndex + 1, txt_stud_year.Text, txt_vouch_num.Text, dt_date_paid.Value, txt_notes.Text);
                        clear_fees();
                        dt_fees.DataSource = std.get_all_fees();

                        MessageBox.Show("تم التعديل بنجاح", "نجاح التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_add_f.Text = "إضافة";
                        textBox2.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("يجب تعبئة الحقول: الرقم الجامعي, الرسم السنوي الكامل, مقدار الرسوم التي سددها, هل سدد الطالب الرسوم, نسبة الاعفاء, مقدار الاعفاء , الرسم السنوي بعد الاعفاء, الرسوم القديمة غير المستوفاة ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void clear_fees()
        {
            textBox2.Visible = false;
            textBox3.Visible = true;
            txt_serch_list.Clear();
            txt_std_id.Clear();
            txt_full.Text = 0.ToString();
            txt_f_paid.Text = 0.ToString();
            cmb_d_paid.SelectedIndex = -1;
            txt_dis_rate.Text = 0.ToString();
            txt_amount.Text = 0.ToString();
            txt_after_dis.Text = 0.ToString();
            txt_old_unpaid.Text = 0.ToString();
            cmb_acad_year.SelectedIndex = -1;
            txt_reason.Clear();
            txt_stud_year.Clear();
            txt_vouch_num.Clear();
            dt_date_paid.Value = DateTime.Now;
            txt_notes.Clear();
            textBox2.Visible = false;
            txt_std_id.Enabled = true;
            btn_add_f.Text = "إضافة";
        }

        private void btn_can_Click(object sender, EventArgs e)
        {
            clear_fees();
        }

        private void btn_cnl_dt_fees_Click(object sender, EventArgs e)
        {
            dt_fees.Visible = false;
            btn_cnl_dt_fees.Visible = false;
            panel_list.Visible = false;
            textBox3.Visible = true;
            txt_std_id.Enabled = true;
            panel_fees_year.Visible = false;
            btn_fees_export.Visible = false;
            btn_fees_list.Enabled = true;
            btn_add_fees.Enabled = false;
            btn_edit_fees.Enabled = true;
            btn_del_fees.Enabled = true;
        }

        private void btn_succes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("يجب عدم استعمال هذا الزر الا بعد انتهاء العام الدراسي وادخال كافة الدرجات لجميع الطلاب");
            panel_add.Visible = false;
            panel_list.Visible = false;
            panel_lists.Visible = false;
            panel_succes.Size = new Size(1143, 561);
            panel_succes.Location = new Point(6, 55);
            panel_succes.Visible = true;
            button2.Visible = true;
            cmb_year_students.SelectedIndex = 3;
            cmb_succ_fuc.SelectedIndex = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView_all_succes.DataSource = std.success_year(Convert.ToInt16(txt_n_ofMat.Text), cmb_year_students.SelectedIndex + 1, cmb_succ_fuc.SelectedIndex + 1);
            dataGridView_all_not_succes.DataSource = std.not_success_year(Convert.ToInt16(txt_n_ofMat.Text), cmb_year_students.SelectedIndex + 1, cmb_succ_fuc.SelectedIndex + 1);
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("تحذير: لايمكن التراجع عن هذه العملية بعد الضغط على زر موافق\n    هل أنت متأكد من ترفيع الطلاب الموجودين في الجدول؟   ", "ترفيع الطلاب", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                std.success_year_ok(Convert.ToInt16(txt_n_ofMat.Text), cmb_year_students.SelectedIndex + 1, cmb_succ_fuc.SelectedIndex + 1);
                MessageBox.Show("تم ترفيع الطلاب للسنة التالية");
            }
            else
            {
                MessageBox.Show("تم الغاء العملية");
            }
        }

        private void تسجيلطالبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_cncl_Click(sender, e);
        }

        private void إدارةالرسومToolStripMenuItem_Click(object sender, EventArgs e)
        {

            btn_fees_Click(sender, e);

        }

        private void قائمةالطلابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_list_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pic.Image = null;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked==true)
            {
                cmb_list_fuc.Enabled = true;
                cmb_list_year.Enabled = true;
                cmb_list_year.SelectedIndex = 0;
                cmb_list_fuc.SelectedIndex = 3;               
                txt_serch_list.Enabled = false;
                list_year();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmb_list_fuc.Enabled = false;
                cmb_list_year.Enabled = false;
                BtnExport_n.Enabled = false;
                txt_serch_list.Enabled = true;
                dataGridViewAll_Std.DataSource = std.GET_All_Student();
                list();
            }
        }
        public void list_year()
        {

            dataGridViewlist.Rows.Clear();
            dataGridViewAll_Std.DataSource = std.Get_All_student_inYear(cmb_list_fuc.SelectedIndex+1,cmb_list_year.SelectedIndex+1);
            list();
            if (dataGridViewlist.Rows.Count > 1)
            {
                BtnExport_n.Enabled = true;
            }
            else { BtnExport_n.Enabled = false; }
        }

        private void cmb_list_fuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_year();
        }

        private void cmb_list_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_year();
        }
        private void export_student()
        {
            try
            {

                string xx = System.IO.Path.GetFullPath("بيانات الطلاب.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                // this.Cursor = Cursors.WaitCursor;
                Microsoft.Office.Interop.Excel.Application app1 = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\‏‏بيانات الطلاب.xlsx");
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

                //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;


                Microsoft.Office.Interop.Excel.Worksheet x = app1.Sheets[1];
                int j = 1;
            string s = "", f = "";
                //  for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                Parallel.For(0, dataGridViewAll_Std.Rows.Count, i =>
                {
                    //  DataGridViewRow row = (DataGridViewRow)dataGridViewlist.Rows[0].Clone();
                    x.Range["A" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[0].Value.ToString();
                    x.Range["B" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[1].Value.ToString();
                    x.Range["C" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[2].Value.ToString();
                    x.Range["D" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[3].Value.ToString();
                    x.Range["E" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[4].Value;
                    x.Range["F" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[5].Value;
                    if (dataGridViewAll_Std.Rows[i].Cells[6].Value.ToString() != "")
                    {
                        if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[6].Value) == true) { x.Range["G" + (i + 2).ToString()].Value = "أنثى"; }
                        else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[6].Value) == false) { x.Range["G" + (i + 2).ToString()].Value = "ذكر"; }
                        else x.Range["G" + (i + 2).ToString()].Value = "";
                    }
                    x.Range["H" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[7].Value;
                    DateTime dt = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[8].Value.ToString() != "")
                    { dt = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[8].Value); }
                    x.Range["I" + (i + 2).ToString()].Value = dt.Year + "/" + dt.Month + "/" + dt.Day;
                    x.Range["J" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[9].Value;
                    if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 4)
                    { x.Range["K" + (i + 2).ToString()].Value = "الهندسة المعلوماتية"; }
                    else if (Convert.ToInt16(dataGridViewAll_Std.Rows[i].Cells[10].Value) == 5)
                    { x.Range["K" + (i + 2).ToString()].Value = "هندسة الميكاترونيك"; }
                    else
                    { x.Range["K" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[10].Value; }
                    x.Range["L" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[11].Value;
                    x.Range["M" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[12].Value.ToString();
                    x.Range["N" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[13].Value.ToString();
                    x.Range["O" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[14].Value;
                    DateTime dt1 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[15].Value.ToString() != "")
                    { dt1 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[15].Value); }
                    x.Range["P" + (i + 2).ToString()].Value = dt1.Year;
                    DateTime dt2 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[16].Value.ToString() != "")
                    { dt2 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[16].Value); }
                    x.Range["Q" + (i + 2).ToString()].Value = dt2.Year;
                    if (dataGridViewAll_Std.Rows[i].Cells[17].Value.ToString() != "")
                    {
                        if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[17].Value) == true) { x.Range["R" + (i + 2).ToString()].Value = "موازي"; }
                        else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[17].Value) == false) { x.Range["R" + (i + 2).ToString()].Value = "عام"; }
                        else x.Range["R" + (i + 2).ToString()].Value = "";
                    }
                    x.Range["S" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[18].Value;

                    // prog_valu= i;

                      backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.Rows.Count);
                    //  lb_pp.Text = ((i * 100) / dataGridViewAll_Std.Rows.Count).ToString() + "%";
                    j++;
                }
                    );


                //     التصدير كملف pdf
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.MyDocuments), "أرشيف\\");
            if (!System.IO.Directory.Exists(path_excel))
            {
                System.IO.Directory.CreateDirectory(path_excel);
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
              Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الطلاب" + "_" + dataGridViewAll_Std.Rows[0].Cells[11].Value + "_" + dataGridViewAll_Std.Rows[0].Cells[10].Value + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
            }
            else
            {
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الطلاب" + "_" + dataGridViewAll_Std.Rows[0].Cells[11].Value + "_" + dataGridViewAll_Std.Rows[0].Cells[10].Value + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
            }
                x.SaveAs(path_excel);
                //  x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                //   System.Diagnostics.Process.Start(path_excel + ".pdf");
                work1.Close();
                app1.Quit();
                //   System.IO.File.Delete(path_excel + ".xlsx");
                //   this.Cursor = Cursors.Default;
                MessageBox.Show("تم تخزين بيانات " + dataGridViewAll_Std.Rows.Count.ToString() + " طالب الى ملف اكسل بنجاح ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnExport_n_Click(object sender, EventArgs e)
        {
            //   exam_record1();
            progressBar1.Visible = true;
            lb_pp.Visible = true;
            this.Enabled = false;
            PL.FRM_MAIN.getMainForm.panelleft.Enabled = false;
            dataGridViewAll_Std.Visible = false;          
            progressBar1.Value = 0;
            lb_pp.Text = null;
            export = "export_student";
            backgroundWorker1.RunWorkerAsync();
            //   progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (export == "all_fees_with_student")
            {
                all_fees_with_student();
            }
            else if (export == "all_fees")
            {
                all_fees();
            }
            else if (export == "export_student")
            {
                export_student();
            }
        }

     
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lb_pp.Text = e.ProgressPercentage.ToString();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnExport_n.Enabled = true;
            btn_list.Enabled = true;
            PL.FRM_MAIN.getMainForm.panelleft.Enabled = true;
            this.Enabled = true;
            dataGridViewAll_Std.Enabled = false;
            progressBar1.Value = 0;
            lb_pp.Text = null;
            progressBar1.Visible = false;
            lb_pp.Visible = false;
            dataGridViewAll_Std.Refresh();
        }

        private void btn_fees_list_Click(object sender, EventArgs e)
        {
            dt_fees.DataSource = std.all_fees_with_student(cmb_fees_fuc.SelectedIndex+1, 0);
            panel_list.Hide();
            theDel = false;
            dt_fees.Size = new Size(1024, 419);
            dt_fees.Location = new Point(5, 60);
            dt_fees.Visible = true;
            btn_cnl_dt_fees.Visible = true;
            panel_list.Hide();
            label3.Text = "البحث حسب الرقم الجامعي:";
            //group_fees.Visible = true;
            //  group_fees.Location = new Point(17, 14);
            //   group_fees.Size = new Size(990, 310);
            btn_can.Visible = true;

            btn_fees_list.Enabled = false;
            btn_add_fees.Enabled = true;
            btn_edit_fees.Enabled = true;
            btn_del_fees.Enabled = true;
            panel_fees_year.Visible = true;
            btn_fees_export.Visible = true;
            export = "all_fees_with_student";
        }

        private void قائمةالرسومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_fees_list_Click(sender,e);
        }

        private void اضافةرسومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_add_fees_Click(sender, e);
        }

        private void تعديلالرسومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_edit_fees_Click(sender, e);
        }

        private void حذفرسومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_del_fees_Click(sender, e);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cmb_fees_year.Enabled = false;
            dt_fees.DataSource = std.all_fees_with_student(cmb_fees_fuc.SelectedIndex + 1, 0);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmb_fees_year.Enabled = true;
            cmb_fees_year.SelectedIndex = 4;
            dt_fees.DataSource = std.all_fees_with_student(cmb_fees_fuc.SelectedIndex + 1, cmb_fees_year.SelectedIndex + 1);
        }

        private void cmb_fees_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_fees.DataSource = std.all_fees_with_student(cmb_fees_fuc.SelectedIndex + 1, cmb_fees_year.SelectedIndex + 1);
        }

        private void cmb_fees_fuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt_fees.DataSource = std.all_fees_with_student(cmb_fees_fuc.SelectedIndex + 1, cmb_fees_year.SelectedIndex + 1);
        }
        public string export = "";

        private void all_fees()
        {
            try
            {

                string xx = System.IO.Path.GetFullPath("بيانات الرسوم.xlsx");
            string path2 = System.IO.Path.GetDirectoryName(xx);
            // this.Cursor = Cursors.WaitCursor;
            Microsoft.Office.Interop.Excel.Application app1 = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\بيانات الرسوم.xlsx");
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

            //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;
            
            Microsoft.Office.Interop.Excel.Worksheet x = app1.Sheets[1];
            int j = 1; 
            //  for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
            Parallel.For(0, dt_fees.Rows.Count, i =>
            {
                //  DataGridViewRow row = (DataGridViewRow)dataGridViewlist.Rows[0].Clone();
                x.Range["A" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[0].Value.ToString();
                x.Range["B" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[1].Value.ToString();
                x.Range["C" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[2].Value.ToString();
                x.Range["D" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[3].Value.ToString();
                x.Range["E" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[4].Value;
                if (dt_fees.Rows[i].Cells[5].Value.ToString() != "")
                {
                    if (Convert.ToBoolean(dt_fees.Rows[i].Cells[5].Value) == true) { x.Range["F" + (i + 2).ToString()].Value = "دفع"; }
                    else if (Convert.ToBoolean(dt_fees.Rows[i].Cells[5].Value) == false) { x.Range["F" + (i + 2).ToString()].Value = "لم يدفع"; }
                    else x.Range["F" + (i + 2).ToString()].Value = "";
                }
                x.Range["G" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[6].Value;
                x.Range["H" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[7].Value;
                x.Range["I" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[8].Value.ToString();
                x.Range["J" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[9].Value.ToString();
                x.Range["K" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[10].Value;
                x.Range["L" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[11].Value.ToString();
                x.Range["M" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[12].Value.ToString();
                x.Range["N" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[13].Value.ToString();
                DateTime dt = new DateTime();
                if (dt_fees.Rows[i].Cells[14].Value.ToString() != "")
                { dt = Convert.ToDateTime(dt_fees.Rows[i].Cells[14].Value); }
                x.Range["O" + (i + 2).ToString()].Value = dt.Year + "/" + dt.Month + "/" + dt.Day;

                x.Range["P" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[15].Value.ToString();
                
                // prog_valu= i;

                backgroundWorker1.ReportProgress((j * 100) / dt_fees.Rows.Count);
                //  lb_pp.Text = ((i * 100) / dataGridViewAll_Std.Rows.Count).ToString() + "%";
                j++;
            }
                );
            
            //     التصدير كملف pdf
            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
           Environment.SpecialFolder.MyDocuments), "أرشيف\\");
            if (!System.IO.Directory.Exists(path_excel))
            {
                System.IO.Directory.CreateDirectory(path_excel);
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
              Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الرسوم" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
            }
            else
            {
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الرسوم" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
            }
            x.SaveAs(path_excel);

            //  x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
            //   System.Diagnostics.Process.Start(path_excel + ".pdf");

            work1.Close();
            app1.Quit();
            //   System.IO.File.Delete(path_excel + ".xlsx");
            //   this.Cursor = Cursors.Default;
            MessageBox.Show("تم تخزين بينات " + dt_fees.Rows.Count.ToString() + " رسم الى ملف اكسل بنجاح ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void all_fees_with_student()
        {
            try
            {

                string xx = System.IO.Path.GetFullPath("‏‏بيانات الرسوم والطلاب.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                // this.Cursor = Cursors.WaitCursor;
                Microsoft.Office.Interop.Excel.Application app1 = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\‏‏بيانات الرسوم والطلاب.xlsx");
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

                //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;

                Microsoft.Office.Interop.Excel.Worksheet x = app1.Sheets[1];
                int j = 1;
                //  for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                Parallel.For(0, dt_fees.Rows.Count, i =>
                {
                //  DataGridViewRow row = (DataGridViewRow)dataGridViewlist.Rows[0].Clone();
                x.Range["A" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[0].Value.ToString();
                    x.Range["B" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[1].Value.ToString();
                    x.Range["C" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[2].Value.ToString();
                    x.Range["D" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[3].Value.ToString();
                    x.Range["E" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[4].Value;
                    x.Range["F" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[5].Value.ToString();
                    x.Range["G" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[6].Value;
                    x.Range["H" + (i + 2).ToString()].Value = dt_fees.Rows[i].Cells[7].Value.ToString();

                // prog_valu= i;
                backgroundWorker1.ReportProgress((j * 100) / dt_fees.Rows.Count);
                //  lb_pp.Text = ((i * 100) / dataGridViewAll_Std.Rows.Count).ToString() + "%";
                j++;
                }
                    );

                //     التصدير كملف pdf
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.MyDocuments), "أرشيف\\");
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                  Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الرسوم والطلاب" + "_" + faculty + "_" + year + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الرسوم والطلاب" + "_" + faculty + "_" + year + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                x.SaveAs(path_excel);

                //  x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                //   System.Diagnostics.Process.Start(path_excel + ".pdf");

                work1.Close();
                app1.Quit();
                //   System.IO.File.Delete(path_excel + ".xlsx");
                //   this.Cursor = Cursors.Default;
                MessageBox.Show("تم تخزين بيانات " + dt_fees.Rows.Count.ToString() + " رسوم الى ملف اكسل بنجاح ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_fees_export_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }
        public string faculty = "", year = "";

        private void cmbMatrial_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMatrial_status.SelectedIndex == 0)
            {
                label18.Location = new Point(403,92);
                cmpMigration.Location = new Point(249,92);

                label7.Visible = false;
                txtHusband_name.Visible = false;
                label8.Visible = false;
                txtHusband_work.Visible = false;
                label9.Visible = false;
                txtChildren_Number.Visible = false;
                label10.Visible = false;
                txtChildren_age.Visible = false;

            }
            if (cmbMatrial_status.SelectedIndex == 1)
            {
                label18.Location = new Point(402, 131);
                cmpMigration.Location = new Point(249, 129);
                label7.Visible = true;
                txtHusband_name.Visible = true;
                label8.Visible = true;
                txtHusband_work.Visible =true;
                label9.Visible = true;
                txtChildren_Number.Visible = true;
                label10.Visible = true;
                txtChildren_age.Visible = true;
            }
        }

        private void cmpMigration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmpMigration.SelectedIndex == 0)
            {
                label21.Visible = true;
                dtMigration_date.Visible = true;
             /*   if (cmbMatrial_status.SelectedIndex == 1)
                {
                    label21.Location = new Point(402,92);
                    dtMigration_date.Location = new Point(252,92);
                }
                if (cmbMatrial_status.SelectedIndex == 0)
                {
                    label21.Location = new Point(161, 93);
                    dtMigration_date.Location = new Point(9, 93);
                }
                */
            }
            if (cmpMigration.SelectedIndex == 1)
            {
                label21.Visible = false;
                dtMigration_date.Visible = false;
            }

        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void cmb_year_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            if (cmb_year_students.SelectedIndex == 4)
            {
                txt_n_ofMat.Text = 0.ToString();
                txt_n_ofMat.Enabled = false;
            }
            else { txt_n_ofMat.Enabled = true; }
        }

        private void txtSection_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

      
        private void txtChildren_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChildren_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtphonNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCertifcate_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCertifcate_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOld_Institute_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_n_ofMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_std_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_full_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_f_paid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_dis_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_after_dis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_old_unpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_stud_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_vouch_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtphonNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_std_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //  dataGridView1.DataSource = stud.GET_stdname(txtid.Text);
                dataGridView1.DataSource = std.Search_by3id(txt_std_id.Text, (cmb_fees_fuc.SelectedIndex + 1).ToString());
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

        private void txtstdname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtstdname.Text != "")
                {
                    dataGridView1.DataSource = std.GET_stdnum(txtstdname.Text);
                    txt_std_id.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btn_fees_export_Click_1(object sender, EventArgs e)
        {
            faculty = cmb_fees_fuc.Text;
            year = cmb_fees_year.Text;
            this.Enabled = false;
            progressBar1.Visible = true;
            lb_pp.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}