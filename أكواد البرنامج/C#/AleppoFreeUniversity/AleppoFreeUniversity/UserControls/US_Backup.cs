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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;


namespace AleppoFreeUniversity.UserControls
{
    public partial class US_Backup : UserControl
    {
        BL.Cls_student std = new BL.Cls_student();
        BL.Cls_degree dg = new BL.Cls_degree();
        BL.ClsLogin log = new BL.ClsLogin();

        public string backup;

        public US_Backup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_backup.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_backup.Text == "")
                {
                    string filename = "C:\\backup";
                    if (!File.Exists(filename))
                    {
                        Directory.CreateDirectory(filename);
                    }
                    //    System.IO.Directory.CreateDirectory(filename);
                    // string userName = "Users (HAMODA-P01BRDS\\Users)";
                    //System. Security.AccessControl.FileSystemAccessRule accessRule = new System.Security.AccessControl.FileSystemAccessRule
                    //     (userName, System.Security.AccessControl.FileSystemRights.Write, System.Security.AccessControl.InheritanceFlags.ContainerInherit| System.Security.AccessControl.InheritanceFlags.ObjectInherit,
                    //     System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow);

                    filename += "\\AleppoFreeUniversity" + DateTime.Now.ToShortDateString().Replace('/', '-') + ".bak";
                    log.Backup_database(filename);
                    string path_file = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف\\");
                    if (!System.IO.Directory.Exists(path_file))
                    {
                        System.IO.Directory.CreateDirectory(path_file);
                    }
                    path_file += "ملفات قاعدة البيانات الاحتياطية";
                    if (!System.IO.Directory.Exists(path_file))
                    {
                        System.IO.Directory.CreateDirectory(path_file);
                    }
                    path_file += "\\AleppoFreeUniversity" + DateTime.Now.ToShortDateString().Replace('/', '-') + ".bak";
                    if (File.Exists(path_file))
                    {
                        DialogResult dialog = MessageBox.Show("هل تريد استبدال النسخة القديمة؟", "حذف رسوم", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialog == DialogResult.Yes)
                        {
                            File.Delete(path_file);
                        }
                    }
                    File.Copy(filename, path_file);
                    File.Delete(filename);
                    MessageBox.Show("تم حفظ نسخة احتياطية إلى مجلد الأرشيف");
                }
                else
                {
                    string filename = "C:\\backup";
                    if (!File.Exists(filename))
                    {
                        Directory.CreateDirectory(filename);
                    }
                    filename += "\\AleppoFreeUniversity" + DateTime.Now.ToShortDateString().Replace('/', '-') + ".bak";
                    log.Backup_database(filename);
                    string path = txt_backup.Text;
                    path += "\\AleppoFreeUniversity" + DateTime.Now.ToShortDateString().Replace('/', '-') + ".bak";
                    txt_backup.Clear();
                    this.Cursor = Cursors.Default;
                    File.Copy(filename, path);
                    File.Delete(filename);
                    MessageBox.Show("تم إنشاء النسخة الاحتياطية بنجاح", "إنشاء النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        

        private void btn_list_Click(object sender, EventArgs e)
        {
            try
            {

                backup = "GET_All_Student";
                dataGridViewAll_Std.DataSource = std.GET_All_Student();
                dataGridViewAll_Std.Size = new Size(1165, 580);
                dataGridViewAll_Std.Location = new System.Drawing.Point(3, 86);
                dataGridViewAll_Std.Visible = true;
                panel_backup.Visible = false;
                BtnExport_n.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void BtnExport_n_Click(object sender, EventArgs e)
        {

            try {
                //   exam_record1();
                progressBar1.Visible = true;
                lb_pp.Visible = true;
                BtnExport_n.Enabled = false;
                btn_list.Enabled = false;
                PL.FRM_MAIN.getMainForm.panelleft.Enabled = false;
                dataGridViewAll_Std.Visible = false;
                backgroundWorker1.RunWorkerAsync();
                pnl_list_withFaculty.Enabled = false;
                btn_list_degrees.Enabled = false;
                //   progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exam_record1()
        {
            // التصدير الى السجل السنوي
            try
            {

                string xx = System.IO.Path.GetFullPath("بيانات الطلاب الاحتياطية.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                // this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\بيانات الطلاب الاحتياطية.xlsx");
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

                //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;


                Excel.Worksheet x = app1.Sheets[1];
                int j = 0;
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
                    {
                        dt = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[8].Value);
                        x.Range["I" + (i + 2).ToString()].Value = dt.Year + "/" + dt.Month + "/" + dt.Day;
                    }
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
                    {
                        dt1 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[15].Value);
                        x.Range["P" + (i + 2).ToString()].Value = dt1.Year;
                    }
                    DateTime dt2 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[16].Value.ToString() != "")
                    {
                        dt2 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[16].Value);
                        x.Range["Q" + (i + 2).ToString()].Value = dt2.Year;
                    }
                    if (dataGridViewAll_Std.Rows[i].Cells[17].Value.ToString() != "")
                    {
                        if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[17].Value) == true) { x.Range["R" + (i + 2).ToString()].Value = "موازي"; }
                        else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[17].Value) == false) { x.Range["R" + (i + 2).ToString()].Value = "عام"; }
                        else x.Range["R" + (i + 2).ToString()].Value = "";
                    }
                    x.Range["S" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[18].Value;
                    x.Range["T" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[20].Value;
                    x.Range["U" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[21].Value.ToString();
                    if (dataGridViewAll_Std.Rows[i].Cells[22].Value.ToString() != "")
                    {
                        if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[22].Value) == true) { x.Range["V" + (i + 2).ToString()].Value = "أعزب"; }
                        else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[22].Value) == false) { x.Range["V" + (i + 2).ToString()].Value = "متزوج"; }
                        else x.Range["V" + (i + 2).ToString()].Value = "";
                    }
                    x.Range["W" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[23].Value.ToString();
                    x.Range["X" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[24].Value.ToString();
                    x.Range["Y" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[25].Value;

                    x.Range["Z" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[26].Value.ToString();
                    x.Range["AA" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[27].Value;

                    if (dataGridViewAll_Std.Rows[i].Cells[28].Value.ToString() != "")
                    {
                        if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[28].Value) == true) { x.Range["AB" + (i + 2).ToString()].Value = "مهجر"; }
                        else if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[28].Value) == false) { x.Range["AB" + (i + 2).ToString()].Value = "غير مهجر"; }
                        else x.Range["AB" + (i + 2).ToString()].Value = "";
                    }

                    DateTime dt3 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[29].Value.ToString() != "")
                    {
                        dt3 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[29].Value);
                        x.Range["AC" + (i + 2).ToString()].Value = dt3.ToString("dd/MM/yyyy");
                    }
                    else { x.Range["AC" + (i + 2).ToString()].Value = null; }
                    // x.Range["AC" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[29].Value;
                    x.Range["AD" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[30].Value.ToString();
                    x.Range["AE" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[31].Value.ToString();
                    x.Range["AF" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[32].Value;
                    x.Range["AG" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[33].Value.ToString();
                    x.Range["AH" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[34].Value.ToString();
                    x.Range["AI" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[35].Value;
                    x.Range["AJ" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[36].Value.ToString();
                    x.Range["AK" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[37].Value.ToString();
                    x.Range["AL" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[38].Value.ToString();
                    x.Range["AM" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[39].Value.ToString();
                    x.Range["AN" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[40].Value.ToString();
                    x.Range["AO" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[41].Value;
                    DateTime dt4 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[42].Value.ToString() != "")
                    {
                        dt4 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[42].Value);
                        x.Range["AP" + (i + 2).ToString()].Value = dt4.ToString("dd/MM/yyyy");
                    }
                    else { x.Range["AP" + (i + 2).ToString()].Value = null; }
                    DateTime dt5 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[43].Value.ToString() != "")
                    {
                        dt5 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[43].Value);
                        x.Range["AQ" + (i + 2).ToString()].Value = dt5.ToString("dd/MM/yyyy");
                    }
                    else { x.Range["AQ" + (i + 2).ToString()].Value = null; }
                    x.Range["AR" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[44].Value.ToString();
                    x.Range["AS" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[45].Value;
                    x.Range["AT" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[46].Value.ToString();
                    x.Range["AU" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[47].Value.ToString();
                    DateTime dt6 = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[48].Value.ToString() != "")
                    {
                        dt6 = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[48].Value);
                        x.Range["AV" + (i + 2).ToString()].Value = dt6.ToString("dd/MM/yyyy");
                    }
                    else { x.Range["AV" + (i + 2).ToString()].Value = null; }
                    x.Range["AW" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[49].Value.ToString();
                    x.Range["AX" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[50].Value.ToString();
                    x.Range["AY" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[51].Value.ToString();
                    // prog_valu= i;

                    backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.Rows.Count);
                    // progressBar1.Value = i;
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
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الطلاب" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات الطلاب" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                x.SaveAs(path_excel);

                //  x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                //   System.Diagnostics.Process.Start(path_excel + ".pdf");

                work1.Close();
                app1.Quit();
                //   System.IO.File.Delete(path_excel + ".xlsx");


                //   this.Cursor = Cursors.Default;
                MessageBox.Show("تم تخزين بينات " + dataGridViewAll_Std.Rows.Count.ToString() + " طالب الى ملف اكسل بنجاح ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void backup_degree1()
        {
            // التصدير الى السجل السنوي
            try
            {

                string xx = System.IO.Path.GetFullPath("بيانات العلامات الاحتياطية.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                // this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\بيانات العلامات الاحتياطية.xlsx");
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

                //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;


                Excel.Worksheet x = app1.Sheets[1];
                int j = 0;
                //  for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                Parallel.For(0, dataGridViewAll_Std.Rows.Count, i =>
                {
                    //  DataGridViewRow row = (DataGridViewRow)dataGridViewlist.Rows[0].Clone();
                    x.Range["A" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[0].Value.ToString();
                    x.Range["B" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[1].Value.ToString();
                    x.Range["C" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[2].Value.ToString();
                    x.Range["D" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[3].Value.ToString();
                    x.Range["E" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[4].Value.ToString();
                    x.Range["F" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[5].Value.ToString();
                    x.Range["G" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[6].Value.ToString();
                    x.Range["H" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[7].Value.ToString();
                    DateTime dt = new DateTime();
                    if (dataGridViewAll_Std.Rows[i].Cells[8].Value.ToString() != "")
                    {
                        dt = Convert.ToDateTime(dataGridViewAll_Std.Rows[i].Cells[8].Value);
                        x.Range["I" + (i + 2).ToString()].Value = dt.Year + "/" + dt.Month + "/" + dt.Day;
                    }


                    backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.Rows.Count);
                    // progressBar1.Value = i;
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
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات العلامات" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات العلامات" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                x.SaveAs(path_excel);

                //  x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                //   System.Diagnostics.Process.Start(path_excel + ".pdf");

                work1.Close();
                app1.Quit();
                //   System.IO.File.Delete(path_excel + ".xlsx");


                //   this.Cursor = Cursors.Default;
                MessageBox.Show("تم تخزين بينات " + dataGridViewAll_Std.Rows.Count.ToString() + " علامة الى ملف اكسل بنجاح ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
        private void all_degree_with_student1()
        {
            // التصدير الى السجل السنوي
            try
            {

                string xx = System.IO.Path.GetFullPath("قائمة العلامات والطلاب.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                // this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\قائمة العلامات والطلاب.xlsx");
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

                //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;


                Excel.Worksheet x = app1.Sheets[1];

                int j = 0;

                for (char c = 'A'; c <= 'Z'; c++)
                {
                    x.Range[c + (1).ToString()].Value = dataGridViewAll_Std.Columns[j].HeaderText.ToString();

                    //for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                    Parallel.For(0, dataGridViewAll_Std.Rows.Count, i =>
                    {
                        x.Range[c + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[j].Value.ToString();
                    }
                    );
                    j++;
                    backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.Rows.Count);
                }

                for (char c = 'A'; c <= 'Z'; c++)
                {
                    x.Range["A" + c + (1).ToString()].Value = dataGridViewAll_Std.Columns[j].HeaderText.ToString();
                    // for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                    Parallel.For(0, dataGridViewAll_Std.Rows.Count, i =>
                    {
                        x.Range["A" + c + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[j].Value.ToString();
                    }
                    );
                    j++;
                    backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.Rows.Count);
                }
                for (char c = 'A'; c < 'Q'; c++)
                {
                    x.Range["B" + c + (1).ToString()].Value = dataGridViewAll_Std.Columns[j].HeaderText.ToString();
                    // for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                    Parallel.For(0, dataGridViewAll_Std.Rows.Count, i =>
                    {
                        x.Range["B" + c + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[j].Value.ToString();
                    }
                    );
                    backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.ColumnCount);
                    j++;
                }




                //     التصدير كملف pdf
                path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.MyDocuments), "أرشيف\\");
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "قائمة العلامات والطلاب" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "قائمة العلامات والطلاب" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                x.SaveAs(path_excel);


                work1.Close();
                app1.Quit();
                //   System.IO.File.Delete(path_excel + ".xlsx");


                MessageBox.Show("تم تخزين علامات " + dataGridViewAll_Std.Rows.Count.ToString() + " طالب الى ملف اكسل بنجاح ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }


        }

        private void backup_materials()
        {

            try
            {

                string xx = System.IO.Path.GetFullPath("بيانات المواد الاحتياطية.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                // this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\بيانات المواد الاحتياطية.xlsx");
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");

                //  progressBar1.Maximum = dataGridViewAll_Std.Rows.Count;


                Excel.Worksheet x = app1.Sheets[1];
                int j = 0;
                Parallel.For(0, dataGridViewAll_Std.Rows.Count, i =>
                //  for (int i = 0; i < dataGridViewAll_Std.Rows.Count; i++)
                {
                    //  DataGridViewRow row = (DataGridViewRow)dataGridViewlist.Rows[0].Clone();
                    x.Range["A" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[0].Value.ToString();
                    x.Range["B" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[1].Value.ToString();
                    x.Range["C" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[2].Value.ToString();
                    x.Range["D" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[3].Value.ToString();
                    x.Range["E" + (i + 2).ToString()].Value = dataGridViewAll_Std.Rows[i].Cells[4].Value.ToString();
                    if (Convert.ToBoolean(dataGridViewAll_Std.Rows[i].Cells[5].Value) == false)
                    {
                        x.Range["F" + (i + 2).ToString()].Value = (1).ToString();
                    }
                    else
                    {
                        x.Range["F" + (i + 2).ToString()].Value = (2).ToString();
                    }



                    backgroundWorker1.ReportProgress((j * 100) / dataGridViewAll_Std.Rows.Count);
                    // progressBar1.Value = i;
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
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات المواد" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + "بيانات المواد" + "_" + DateTime.Now.Date.ToString("dd_MM_yyyy"));
                }
                x.SaveAs(path_excel);


                work1.Close();
                app1.Quit();
                //   this.Cursor = Cursors.Default;
                MessageBox.Show("تم تخزين بينات " + dataGridViewAll_Std.Rows.Count.ToString() + " مادة الى ملف اكسل بنجاح ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backup == "GET_All_Student")
            {
                exam_record1();
            }
            else if (backup == "backup_degree")
            {
                backup_degree1();
            }
            else if (backup == "all_degree_with_student")
            {
                all_degree_with_student1();
            }

            else if (backup == "backup_materials")
            {
                backup_materials();
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
            dataGridViewAll_Std.Enabled = false;
            progressBar1.Value = 0;
            lb_pp.Text = null;
            progressBar1.Visible = false;
            lb_pp.Visible = false;
            panel_backup.Visible = true;
            dataGridViewAll_Std.Refresh();
            pnl_list_withFaculty.Enabled = true;
            btn_list_degrees.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                backup = "backup_degree";
                dataGridViewAll_Std.DataSource = dg.backup_degree();
                dataGridViewAll_Std.Size = new Size(1165, 580);
                dataGridViewAll_Std.Location = new System.Drawing.Point(3, 86);
                dataGridViewAll_Std.Visible = true;
                panel_backup.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_list_degrees_Click(object sender, EventArgs e)
        {
            try {
                backup = "backup_degree";
                dataGridViewAll_Std.DataSource = dg.backup_degree();
                dataGridViewAll_Std.Size = new Size(1165, 580);
                dataGridViewAll_Std.Location = new System.Drawing.Point(3, 86);
                dataGridViewAll_Std.Visible = true;
                panel_backup.Visible = false;
                BtnExport_n.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_list_mat_Click(object sender, EventArgs e)
        {
            try {
                backup = "backup_materials";
                dataGridViewAll_Std.DataSource = dg.all_mat(cmbfaculty.SelectedIndex + 1);
                dataGridViewAll_Std.Size = new Size(1165, 580);
                dataGridViewAll_Std.Location = new System.Drawing.Point(3, 86);
                dataGridViewAll_Std.Visible = true;
                panel_backup.Visible = false;
                BtnExport_n.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_list_stu_degree_Click(object sender, EventArgs e)
        {
            try
            {
                backup = "all_degree_with_student";
                dataGridViewAll_Std.DataSource = dg.all_degree_with_student(cmbfaculty.SelectedIndex + 1);
                dataGridViewAll_Std.Size = new Size(1165, 580);
                dataGridViewAll_Std.Location = new System.Drawing.Point(3, 86);
                dataGridViewAll_Std.Visible = true;
                panel_backup.Visible = false;
                BtnExport_n.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }


        private void BtnExport_d_s_Click(object sender, EventArgs e)
        {
            try {
                all_degree_with_student1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbfaculty.SelectedIndex + 1 == 4)
            {
                btn_list_stu_degree.Enabled = true;
            }
            else
            {
                btn_list_stu_degree.Enabled = false;
            }
        }

        private void US_Backup_Load(object sender, EventArgs e)
        {
            cmbfaculty.SelectedIndex = 3;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}