using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace AleppoFreeUniversity.UserControls
{
  
    public partial class US_Dergree_Management : UserControl
    {
        BL.Cls_student std = new BL.Cls_student();
        BL.Cls_degree cost = new BL.Cls_degree();
    
        public US_Dergree_Management()
        {
            InitializeComponent();            
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

            //AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            dataGridView_autoComblete.DataSource = std.Search_by3id(txtid.Text, (cmbfaculty.SelectedIndex + 1).ToString());
            if (dataGridView_autoComblete.Rows.Count > 0)
            {            
                if (dataGridView_autoComblete.Rows.Count < 2)
                { txt_idfull.Text = dataGridView_autoComblete.Rows[0].Cells[1].Value.ToString(); }
                else { txt_idfull.Text = ""; }
            }
            if (txt_idfull.Text == "")
            {
                panel_score.Size = new Size(1147, 527);
                panel_newspaper.Size = new Size(1135, 520);
                clear(); }
            
            score();
            score_n();

            if (txtid.Text == "") { txt_idfull.Text = ""; button8.Enabled = false; button9.Enabled = false; }
            if (txt_idfull.Text != "") { button8.Enabled = true; button9.Enabled = true; }
            else { button8.Enabled = false; button9.Enabled = false; }
        }    
        private void score()
        {
            if (txtid.Text != null)
            {
                try
                {
                    groupBoxY1.Visible = false;
                    groupBoxY2.Visible = false;
                    groupBoxY3.Visible = false;
                    groupBoxY4.Visible = false;
                    groupBoxY5.Visible = false;
                    BtnExport.Enabled = false;
                    groupBoxtop10.Visible = false;
                    BtnExport.Visible = true;
                    dataGridViewnull.DataSource = cost.null_matirial(Convert.ToInt32(txt_idfull.Text));
                    groupBoxfail.Visible = true; groupBoxnull.Visible = true;
                    dataGridViewfail.DataSource = cost.fail_degree(Convert.ToInt32(txt_idfull.Text));
                    dataGridView_detils.DataSource = std.GET_DETILE_STUD(txt_idfull.Text);
                    button6.Visible = true;
                    //////////
                    if (dataGridView_detils.Rows.Count > 0)
                    {

                        /////////
                        int x = Convert.ToUInt16(dataGridView_detils.Rows[0].Cells[5].Value);
                        if (x >= 1) { groupBoxY1.Visible = true; BtnExport.Enabled = true;  }
                        if (x >= 2) { groupBoxY2.Visible = true; BtnExport.Enabled = true; }
                        if (x >= 3) { groupBoxY3.Visible = true; BtnExport.Enabled = true; }
                        if (x >= 4) { groupBoxY4.Visible = true; BtnExport.Enabled = true; }
                        if (x >= 5) { groupBoxY5.Visible = true; BtnExport.Enabled = true;
                                     panel_score.Size = new Size(1147, 700);               }
                        else        { panel_score.Size = new Size(1147, 527);              }
         
                        txtName.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString();
                        txtfather.Text = dataGridView_detils.Rows[0].Cells[1].Value.ToString();
                        txtmother.Text = dataGridView_detils.Rows[0].Cells[2].Value.ToString();
                        txtbirthdate.Text = dataGridView_detils.Rows[0].Cells[3].Value.ToString();
                        txtYearOfAdmission.Text = dataGridView_detils.Rows[0].Cells[4].Value.ToString();
                        txtYear.Text = dataGridView_detils.Rows[0].Cells[5].Value.ToString();
                        txtfaculty.Text = dataGridView_detils.Rows[0].Cells[6].Value.ToString();
                        txtbirthcity.Text = dataGridView_detils.Rows[0].Cells[7].Value.ToString();
                        if (dataGridView_detils.Rows[0].Cells[8].Value.ToString() == "True")
                        {
                            txtadmission.Text = "موازي";
                        }
                        else if (dataGridView_detils.Rows[0].Cells[8].Value.ToString() == "False")
                        {
                            txtadmission.Text = "عام";
                        }
                        txtDepartment.Text = dataGridView_detils.Rows[0].Cells[9].Value.ToString();

                        //  year1
                        dataGridViewY1s1.DataSource = cost.GET_DEGREE(txt_idfull.Text, 1, false);
                        dataGridViewY1s2.DataSource = cost.GET_DEGREE(txt_idfull.Text, 1, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 1);
                        if (dataGridView_detils.Rows.Count > 0)
                        {
                            txtavg1.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString();
                        }
                        else txtavg1.Text = "00.00";

                        //year2
                        dataGridViewY4s1.Refresh(); dataGridViewY4s2.Refresh();
                        dataGridViewY2s1.DataSource = cost.GET_DEGREE(txt_idfull.Text, 2, false);
                        dataGridViewY2s2.DataSource = cost.GET_DEGREE(txt_idfull.Text, 2, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 2);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg2.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg2.Text = "00.00";
                        //year3

                        dataGridViewY3s1.DataSource = cost.GET_DEGREE(txt_idfull.Text, 3, false);
                        dataGridViewY3s2.DataSource = cost.GET_DEGREE(txt_idfull.Text, 3, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 3);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg3.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg3.Text = "00.00";
                        //  year4
                        dataGridViewY4s1.DataSource = cost.GET_DEGREE(txt_idfull.Text, 4, false);
                        dataGridViewY4s2.DataSource = cost.GET_DEGREE(txt_idfull.Text, 4, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 4);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg4.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg4.Text = "00.00";
                        //  year5
                        dataGridViewY5s1.DataSource = cost.GET_DEGREE(txt_idfull.Text, 5, false);
                        dataGridViewY5s2.DataSource = cost.GET_DEGREE(txt_idfull.Text, 5, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 5);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg5.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg5.Text = "00.00";

                        textBox2.Text = "ok";
                        dataGridView_detils.DataSource = std.GET_DETILE_STUD(txt_idfull.Text);
                    }
                    else { textBox2.Text = "لا يوجد طالب بهذا الرقم"; clear(); }
                }

                catch (Exception ex) { textBox2.Text = ex.Message; }
            }
            if (txtid.TextLength == 0)
            { 
                 clear();
                 textBox2.Text = "الرجاء إدخال الرقم الجامعي";
            }
               
        }

        private void clear()
        {
            txtadmission.Clear(); txtbirthcity.Clear(); txtbirthdate.Clear(); txtDepartment.Clear(); txtYear.Clear();
            txtfaculty.Clear(); txtfather.Clear();  txtmother.Clear(); txtYearOfAdmission.Clear();txtName.Clear();
            txtavg1.Clear(); txtavg2.Clear(); txtavg3.Clear(); txtavg4.Clear(); txtavg5.Clear(); 
            BtnExport.Visible = false; groupBoxfail.Visible = false; groupBoxnull.Visible = false; button6.Visible = false;
            groupBoxY1.Visible = false;groupBoxY2.Visible = false;groupBoxY3.Visible = false;
            groupBoxY4.Visible = false;groupBoxY5.Visible = false;
            txtavg1.Clear(); txtavg2.Clear(); txtavg3.Clear(); txtavg4.Clear(); txtavg5.Clear();
            BtnExport_n.Visible = false;
            groupBoxY1_n.Visible = false; groupBoxY2_n.Visible = false; groupBoxY3_n.Visible = false;
            groupBoxY4_n.Visible = false; groupBoxY5_n.Visible = false;
        }

        private void US_Dergree_score_Load(object sender, EventArgs e)
        {
            txtid.Focus();
            cmbfaculty.SelectedIndex = 3;
            button9.BackColor = Color.Green;
            panel_score.Location = new System.Drawing.Point(7, 142);
            button4_Click(sender, e);
        }



        private void BtnExport_Click_1(object sender, EventArgs e)
        {
            // التصدير الى ملف اكسيل
            try   
            {

                string xx = System.IO.Path.GetFullPath("كشف علامات.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                this.Cursor = Cursors.WaitCursor;
       
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1;
                if (Convert.ToInt16(txtYear.Text) == 5)
                {
                  work1 = app1.Workbooks.Open(path2 + @"\كشف علامات.xlsx");
                }
                else
                { work1 = app1.Workbooks.Open(path2 + @"\‏‏كشف علامات4.xlsx"); }
                Excel.Worksheet x = app1.Sheets[1];
             //   x.Range["L3"].Value = txtid.Text;
                x.Range["A5"].Value = "كلية" + " " + txtfaculty.Text;
                x.Range["B6"].Value = txtName.Text;
                x.Range["B7"].Value = txtfather.Text;
                x.Range["B8"].Value = txtmother.Text;
                x.Range["G6"].Value = txtbirthcity.Text+" "+ txtbirthdate.Text;
                x.Range["G7"].Value = "سوريا";
                x.Range["L6"].Value = txtYearOfAdmission.Text;
                x.Range["L7"].Value = txtYear.Text;
                x.Range["G8"].Value = txtadmission.Text;
              //  x.Range["I6"].Value = txtbirthdate.Text;

                String aaa;
                int dateEnter = 2015;
                if (txtYearOfAdmission.Text != "")
                {
                    aaa = txtYearOfAdmission.Text;
                    aaa = aaa.Substring(0, 4);
                    dateEnter = Convert.ToInt16(aaa);
                }

                //y1s1 subject
                if (dataGridViewY1s1.RowCount != 0)
                { ///اسماء
                  //  x.Range["J9"].Value = txtavg1.Text;
                    x.Range["E9"].Value = Convert.ToString(dateEnter) + "-" + Convert.ToString(dateEnter + 1);
                    for (int j = 13, i = 0; i < dataGridViewY1s1.RowCount; j++, i++)
                    { x.Range["A" + j.ToString()].Value = dataGridViewY1s1.Rows[i].Cells[0].Value; }

                    ///علامات
                    for (int j = 13, i = 0; i < dataGridViewY1s1.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY1s1.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["D" + j.ToString()].Value = dataGridViewY1s1.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY1s1.Rows[i].Cells[1].Value) >0)
                            x.Range["E" + j.ToString()].Value += " (عملي فقط) ";
                            x.Range["J9"].Value = "00.00";
                        }
                        else
                            x.Range["D" + j.ToString()].Value = dataGridViewY1s1.Rows[i].Cells[3].Value;
                    }
                }

                //y1s2 subject
                if (dataGridViewY1s2.RowCount != 0)
                { 
                    for (int j = 13, i = 0; i < dataGridViewY1s2.RowCount; j++, i++)
                    { x.Range["I" + j.ToString()].Value = dataGridViewY1s2.Rows[i].Cells[0].Value; }

                    for (int j = 13, i = 0; i < dataGridViewY1s2.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY1s2.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["L" + j.ToString()].Value = dataGridViewY1s2.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY1s2.Rows[i].Cells[1].Value) > 0)
                            x.Range["M" + j.ToString()].Value += " (عملي فقط) ";
                          //  x.Range["L" + j.ToString()].Value +
                            x.Range["J9"].Value = "00.00";

                        }
                        else x.Range["L" + j.ToString()].Value = dataGridViewY1s2.Rows[i].Cells[3].Value;
                    }
                }

                //y2s1 subject
                if (dataGridViewY2s1.RowCount != 0)
                {
                   // x.Range["J21"].Value = txtavg2.Text;
                    x.Range["E20"].Value = Convert.ToString(dateEnter + 1) + "-" + Convert.ToString(dateEnter + 2);
                    for (int j = 24, i = 0; i < dataGridViewY2s1.RowCount; j++, i++)
                    { x.Range["A" + j.ToString()].Value = dataGridViewY2s1.Rows[i].Cells[0].Value; }

                    for (int j = 24, i = 0; i < dataGridViewY2s1.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY2s1.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["D" + j.ToString()].Value = dataGridViewY2s1.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY2s1.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["E" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J21"].Value = "00.00";
                        }
                        else x.Range["D" + j.ToString()].Value = dataGridViewY2s1.Rows[i].Cells[3].Value;
                    }
                }

                //y2s2 subject
                if (dataGridViewY2s2.RowCount != 0)
                {

                    for (int j = 24, i = 0; i < dataGridViewY2s2.RowCount; j++, i++)
                    { x.Range["I" + j.ToString()].Value = dataGridViewY2s2.Rows[i].Cells[0].Value; }

                    for (int j = 24, i = 0; i < dataGridViewY2s2.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY2s2.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["L" + j.ToString()].Value = dataGridViewY2s2.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY2s2.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["M" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J21"].Value = "00.00";

                        }
                        else x.Range["L" + j.ToString()].Value = dataGridViewY2s2.Rows[i].Cells[3].Value;
                    }
                }

                //y3s1 subject
                if (dataGridViewY3s1.RowCount != 0)
                {
                 //   x.Range["J33"].Value = txtavg3.Text;
                    x.Range["E31"].Value = Convert.ToString(dateEnter + 2) + "-" + Convert.ToString(dateEnter + 3);
                    for (int j = 35, i = 0; i < dataGridViewY3s1.RowCount; j++, i++)
                    { x.Range["A" + j.ToString()].Value = dataGridViewY3s1.Rows[i].Cells[0].Value; }

                    for (int j = 35, i = 0; i < dataGridViewY3s1.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY3s1.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["D" + j.ToString()].Value = dataGridViewY3s1.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY3s1.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["E" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J33"].Value = "00.00";

                        }
                        else x.Range["D" + j.ToString()].Value = dataGridViewY3s1.Rows[i].Cells[3].Value;
                    }
                }

                //y3s2 subject
                if (dataGridViewY3s2.RowCount != 0)
                {

                    for (int j = 35, i = 0; i < dataGridViewY3s2.RowCount; j++, i++)
                    { x.Range["I" + j.ToString()].Value = dataGridViewY3s2.Rows[i].Cells[0].Value; }

                    for (int j = 35, i = 0; i < dataGridViewY3s2.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY3s2.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["L" + j.ToString()].Value = dataGridViewY3s2.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY3s2.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["M" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J33"].Value = "00.00";
                        }
                        else x.Range["L" + j.ToString()].Value = dataGridViewY3s2.Rows[i].Cells[3].Value;
                    }

                }

                //y4s1 subject
                if (dataGridViewY4s1.RowCount != 0)
                {
                 //   x.Range["J45"].Value = txtavg4.Text;
                    x.Range["E42"].Value = Convert.ToString(dateEnter + 3) + "-" + Convert.ToString(dateEnter + 4);
                    for (int j = 46, i = 0; i < dataGridViewY4s1.RowCount; j++, i++)
                    { x.Range["A" + j.ToString()].Value = dataGridViewY4s1.Rows[i].Cells[0].Value; }

                    for (int j = 46, i = 0; i < dataGridViewY4s1.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY4s1.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["D" + j.ToString()].Value = dataGridViewY4s1.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY4s1.Rows[i].Cells[1].Value) > 0){
                            x.Range["E" + j.ToString()].Value += " (عملي فقط) ";
                            x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J45"].Value = "00.00";
                        }
                        else x.Range["D" + j.ToString()].Value = dataGridViewY4s1.Rows[i].Cells[3].Value;
                    }
                }

                //y4s2 subject
                if (dataGridViewY4s2.RowCount != 0)
                {
                    for (int j = 46, i = 0; i < dataGridViewY4s2.RowCount; j++, i++)
                    { x.Range["I" + j.ToString()].Value = dataGridViewY4s2.Rows[i].Cells[0].Value; }

                    for (int j = 46, i = 0; i < dataGridViewY4s2.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY4s2.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["L" + j.ToString()].Value = dataGridViewY4s2.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY4s2.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["M" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J45"].Value = "00.00";
                        }
                        else x.Range["L" + j.ToString()].Value = dataGridViewY4s2.Rows[i].Cells[3].Value;
                    }
                }

                //y5s1 subject
                if (dataGridViewY5s1.RowCount != 0)
                {
                  //  x.Range["J57"].Value = txtavg5.Text;
                    x.Range["E53"].Value = Convert.ToString(dateEnter + 4) + "-" + Convert.ToString(dateEnter + 5);
                    for (int j = 57, i = 0; i < dataGridViewY5s1.RowCount; j++, i++)
                    { x.Range["A" + j.ToString()].Value = dataGridViewY5s1.Rows[i].Cells[0].Value; }

                    for (int j = 57, i = 0; i < dataGridViewY5s1.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY5s1.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["D" + j.ToString()].Value = dataGridViewY5s1.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY5s1.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["E" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J57"].Value = "00.00";
                        }
                        else x.Range["D" + j.ToString()].Value = dataGridViewY5s1.Rows[i].Cells[3].Value;
                    }
                }
                //y5s2 subject
                if (dataGridViewY5s2.RowCount != 0)
                {
                    
                    for (int j = 57, i = 0; i < dataGridViewY5s2.RowCount; j++, i++)
                    { x.Range["I" + j.ToString()].Value = dataGridViewY5s2.Rows[i].Cells[0].Value; }

                    for (int j = 57, i = 0; i < dataGridViewY5s2.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY5s2.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["L" + j.ToString()].Value = dataGridViewY5s2.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY5s2.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["M" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["L" + j.ToString()].Value += "/30";
                            }
                            x.Range["J57"].Value = "00.00";
                        }
                        else x.Range["L" + j.ToString()].Value = dataGridViewY5s2.Rows[i].Cells[3].Value;
                    }
                }
                //سنوات الدراسة
                int y = Convert.ToUInt16(dataGridView_detils.Rows[0].Cells[5].Value);
                if (y >= 1) { x.Range["L7"].Value = x.Range["E9"].Value; }
                if (y >= 2) { x.Range["L7"].Value += "حتى" + x.Range["E20"].Value; }
                if (y >= 3) { x.Range["L7"].Value = x.Range["E9"].Value + " حتى " + x.Range["E31"].Value; }
                if (y >= 4) { x.Range["L7"].Value = x.Range["E9"].Value + " حتى " + x.Range["E42"].Value; }
                if (y >= 5) { x.Range["L7"].Value = x.Range["E9"].Value + " حتى " + Convert.ToString(DateTime.Now.Year-1)+" - "+ Convert.ToString(DateTime.Now.Year) + "م"; }


                //     التصدير كملف pdf
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.MyDocuments), "أرشيف كشف العلامات\\");
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف كشف العلامات\\" + "كشف علامات" + "_" + txtName.Text);
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف كشف العلامات\\" + "كشف علامات" + "_" + txtName.Text);
                }
                work1.SaveAs(path_excel);
                work1.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                this.Cursor = Cursors.Default;
                textBox2.Text = "pdf تم تصدير كشف العلامات إلى ملف";
                System.Diagnostics.Process.Start(path_excel + ".pdf");
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }



        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_top10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView_top10.DataSource = cost.Get_Top10(Convert.ToInt16(txt_top10.Text), cmb_top_fucty.SelectedIndex + 1);
            }
            catch (Exception)
            { dataGridView_top10.DataSource = null; }
            txt_top10.SelectAll();
        }

        private void btn_top10_Click(object sender, EventArgs e)
        { 
            txtid.Text = null;
             if (btn_top10.BackColor ==SystemColors.Highlight)
            {
                groupBoxtop10.Visible = true;
                btn_top10.BackColor = Color.Green;
                groupBoxtop10.Size = new Size(268, 390);
                groupBoxtop10.Location = new System.Drawing.Point(20, 160);
                cmb_top_fucty.SelectedIndex = 3;
                txt_top10.Focus();
            }
            else
            {
                btn_top10.BackColor = SystemColors.Highlight;
                groupBoxtop10.Visible = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxtop10.Visible = false;
            txtid.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = true;
            panel_lot_student.Visible = true;
            //    panel_lot_student.Size=new Size(1170, 610);
            //    panel_lot_student.Location = new System.Drawing.Point(0,51);
            panel_lot_student.Size = new Size(1150, 665);
            panel_lot_student.Location = new System.Drawing.Point(3, 3);
            groupBoxY5.Visible = false;
            groupBox1.Visible = false;
            cmb_std.SelectedIndex = 0;
            button8.Hide();
            button9.Hide();
            //  cmbfaculty.Hide();
            //  label19.Hide();
            panel_fucluty.Hide();
            panel_newspaper.Hide();
            panel_score.Hide();
           button7_Click(sender,e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button11_Click(sender,e);
            button4.Enabled = false;
            button3.Enabled = true;
            groupBox1.Visible = true;
            button8.Show();
            button9.Show();
          //  cmbfaculty.Show();
          //  label19.Show();
          panel_fucluty.Show();
            panel_lot_student.Visible = false;
            txtid.Focus();
            score();
           // groupBoxY5.Visible = true;
        }

        private void failon()
        {
            groupBoxnull.Size = new Size(181, 223);
            groupBoxfail.Size = new Size(181, 223);
        }

        private void failoff()
        {
            groupBoxnull.Size = new Size(150, 223);
            groupBoxfail.Size = new Size(150, 223);
        }
       

      

       

        private void txt_top10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))|| (e.KeyChar<49||e.KeyChar>54))
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //export_mat_lot();
            panel_exam_record.Visible = false;
           // if (groupBox_mat_year.Visible == true)
            //{
                groupBox_mat_year.Visible =true ;
              groupBox_mat_year.Size= new Size (834, 614);
                groupBox_mat_year.Location = new System.Drawing.Point(297, 48);
      //      }
     //       else { groupBox_mat_year.Visible = true; }

            btn_exam_record.Enabled = true;
            button7.Enabled =false ;
        }

        private void panel_lot_student_VisibleChanged(object sender, EventArgs e)
        {
            cmb_facluty_lot.SelectedIndex = 3;
            cmbyear.SelectedIndex = 0;
            cmbSeson.SelectedIndex = 0;
            cmbseas.SelectedIndex = 0;
            dataGridView_mat.DataSource = cost.Get_All_Material(cmb_facluty_lot.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex));
            txt_year.Focus()  ;
        }

        private void export_mat_lot()
        {
            try
            {
                if (cmb_std.SelectedIndex == 0)
                {
                    dataGridView_mat_year.DataSource = cost.get_mat_year1(txtmat.Text, Convert.ToInt16(txt_year.Text));
                    exam_statistics();
                }
                else if (cmb_std.SelectedIndex == 1)
                {
                    dataGridView_mat_year.DataSource = cost.get_mat_year2(txtmat.Text, Convert.ToInt16(txt_year.Text));
                    clear_statistics();
                }
                else if (cmb_std.SelectedIndex == 2)
                {
                    dataGridView_mat_year.DataSource = cost.get_mat_year3(txtmat.Text, Convert.ToInt16(txt_year.Text));
                    clear_statistics();
                }

            }
            catch (Exception) {  }
        }

        private void cmb_facluty_lot_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_mat.DataSource = cost.Get_All_Material(cmb_facluty_lot.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex));            
        }

        private void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_mat.DataSource = cost.Get_All_Material(cmb_facluty_lot.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex)); 
        }

        private void cmbSeson_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView_mat.DataSource = cost.Get_All_Material(cmb_facluty_lot.SelectedIndex + 1, cmbyear.SelectedIndex + 1, Convert.ToBoolean(cmbSeson.SelectedIndex)); 
        }

        private void dataGridView_mat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtmat.Text = dataGridView_mat.CurrentRow.Cells[0].Value.ToString();
                txtmat_name.Text= dataGridView_mat.CurrentRow.Cells[1].Value.ToString();
                exam_statistics();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtmat_TextChanged(object sender, EventArgs e)
        {
            export_mat_lot();


        }

        private void txt_year_TextChanged(object sender, EventArgs e)
        {
            export_mat_lot();
        }


        private void cmb_std_SelectedIndexChanged(object sender, EventArgs e)
        {
            export_mat_lot();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor.ToString() == "Color [Highlight]")
            {
                button8.BackColor = Color.Green;
                panel_newspaper.Visible = true; panel_score.Visible = false;
                button9.BackColor = Color.FromName("Highlight");
                panel_newspaper.Location = new System.Drawing.Point(5,143);
               if (Convert.ToUInt16(dataGridView_detils.Rows[0].Cells[5].Value) >= 5)
                {       panel_newspaper.Size = new Size(1135, 700); }
               else
                panel_newspaper.Size = new Size(1135, 520);
            }
            else
            {
                button8.BackColor = Color.FromName("Highlight");
                panel_newspaper.Visible = false;
            }
        }
       

        private void score_n()
        {
            if (txt_idfull.Text != null)
            {
                try
                {
                    groupBoxY1_n.Visible = false;
                    groupBoxY2_n.Visible = false;
                    groupBoxY3_n.Visible = false;
                    groupBoxY4_n.Visible = false;
                    groupBoxY5_n.Visible = false;
                    BtnExport_n.Enabled = false;
             //       groupBoxtop10.Visible = false;
                    BtnExport_n.Visible = true;
             //       groupBoxnull.Visible = true; dataGridViewnull.DataSource = cost.null_matirial(Convert.ToInt32(txt_idfull.Text));
             //       groupBoxfail.Visible = true; dataGridViewfail.DataSource = cost.fail_degree(Convert.ToInt32(txt_idfull.Text));
            //        dataGridView_detils.DataSource = std.GET_DETILE_STUD(txt_idfull.Text);
            //        button6.Visible = true;
                    //////////
                    if (dataGridView_detils.Rows.Count > 0)
                    {

                        /////////
                        int x = Convert.ToUInt16(dataGridView_detils.Rows[0].Cells[5].Value);
                        if (x >= 1) { groupBoxY1_n.Visible = true; BtnExport_n.Enabled = true; }
                        if (x >= 2) { groupBoxY2_n.Visible = true; BtnExport_n.Enabled = true; }
                        if (x >= 3) { groupBoxY3_n.Visible = true; BtnExport_n.Enabled = true; }
                        if (x >= 4) { groupBoxY4_n.Visible = true; BtnExport_n.Enabled = true; }
                        if (x >= 5) { groupBoxY5_n.Visible = true; BtnExport_n.Enabled = true;
                              panel_newspaper.Size = new Size(1135, 700);                      }
                         else       {   panel_newspaper.Size = new Size(1135, 520);            }        
                       
                    txtName.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString();
                        txtfather.Text = dataGridView_detils.Rows[0].Cells[1].Value.ToString();
                        txtmother.Text = dataGridView_detils.Rows[0].Cells[2].Value.ToString();
                        txtbirthdate.Text = dataGridView_detils.Rows[0].Cells[3].Value.ToString();
                        txtYearOfAdmission.Text = dataGridView_detils.Rows[0].Cells[4].Value.ToString();
                        txtYear.Text = dataGridView_detils.Rows[0].Cells[5].Value.ToString();
                        txtfaculty.Text = dataGridView_detils.Rows[0].Cells[6].Value.ToString();
                        txtbirthcity.Text = dataGridView_detils.Rows[0].Cells[7].Value.ToString();
                        if (dataGridView_detils.Rows[0].Cells[8].Value.ToString() == "True")
                        {
                            txtadmission.Text = "موازي";
                        }
                        else if (dataGridView_detils.Rows[0].Cells[8].Value.ToString() == "False")
                        {
                            txtadmission.Text = "عام";
                        }
                        txtDepartment.Text = dataGridView_detils.Rows[0].Cells[9].Value.ToString();

                        //  year1
                        dataGridViewY1s1_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 1, false);
                        dataGridViewY1s2_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 1, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 1);
                        if (dataGridView_detils.Rows.Count > 0)
                        {
                            txtavg1_n.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString();
                        }
                        else txtavg1_n.Text = "00.00";

                        //year2
               //         dataGridViewY4s1_n.Refresh(); dataGridViewY4s2.Refresh();
                        dataGridViewY2s1_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 2, false);
                        dataGridViewY2s2_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 2, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 2);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg2_n.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg2_n.Text = "00.00";
                        //year3

                        dataGridViewY3s1_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 3, false);
                        dataGridViewY3s2_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 3, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 3);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg3_n.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg3_n.Text = "00.00";
                        //  year4
                        dataGridViewY4s1_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 4, false);
                        dataGridViewY4s2_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 4, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 4);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg4_n.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg4_n.Text = "00.00";
                        //  year5
                        dataGridViewY5s1_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 5, false);
                        dataGridViewY5s2_n.DataSource = cost.get_degreesWithSeson(txt_idfull.Text, 5, true);
                        dataGridView_detils.DataSource = cost.GET_AVG_STUDENT(txt_idfull.Text, 5);
                        if (dataGridView_detils.Rows.Count > 0)
                        { txtavg5_n.Text = dataGridView_detils.Rows[0].Cells[0].Value.ToString(); }
                        else txtavg5_n.Text = "00.00";

                      //  textBox2.Text = "ok";
                        dataGridView_detils.DataSource = std.GET_DETILE_STUD(txt_idfull.Text);
                    }
                    else { textBox2.Text = "لا يوجد طالب بهذا الرقم"; clear(); }
                }

                catch (Exception ex) { textBox2.Text = ex.Message; }
            }
            if (txt_idfull.TextLength == 0)
            {
                clear();
                textBox2.Text = "الرجاء إدخال الرقم الجامعي";
            }

        }

        private void newspaper_student()
        {
            // التصدير الى صحيفة الطالب
            try
            {

                string xx = System.IO.Path.GetFullPath("صحيفة الطالب.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(xx);
                this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\صحيفة الطالب.xlsx");
                Excel.Worksheet x = app1.Sheets[1];
                //  x.Range["AL2"].Value = txtid.Text;
                x.Range["AL2"].Value = txt_idfull.Text;
               // x.Range["A5"].Value = "كلية" + " " + txtfaculty.Text;
                x.Range["D1"].Value = txtName.Text;
                x.Range["P1"].Value = txtfather.Text;
                x.Range["D2"].Value = txtmother.Text;
                x.Range["W1"].Value = txtbirthcity.Text+"-"+ txtbirthdate.Text;
                x.Range["I2"].Value = "سوريا";
                x.Range["AD2"].Value = txtDepartment.Text;
            
             //   x.Range["L6"].Value = txtYearOfAdmission.Text;
             //   x.Range["L7"].Value = txtYear.Text;
                x.Range["Q2"].Value = txtadmission.Text;
                //      x.Range["I6"].Value = txtbirthdate.Text;
                      if (Convert.ToBoolean(dataGridView_detils.Rows[0].Cells[8].Value) == true) {x.Range["AC1"].Value = "أنثى"; }
                    else if (Convert.ToBoolean(dataGridView_detils.Rows[0].Cells[8].Value) == false) { x.Range["AC1"].Value = "ذكر"; }
                    else x.Range["AC1"].Value = "";
                
                String aaa;
                int dateEnter = 2015;
                if (txtYearOfAdmission.Text != "")
                {
                    aaa = txtYearOfAdmission.Text;
              //      aaa = aaa.Substring(0, 4);
                    dateEnter = Convert.ToInt16(aaa);
                }

                //y1s1 subject
                if (dataGridViewY1s1_n.RowCount != 0)
                { ///اسماء
                    x.Range["N4"].Value = txtavg1_n.Text;
                    x.Range["D4"].Value = Convert.ToString(dateEnter) + "-" + Convert.ToString(dateEnter + 1);
                    for (int j = 8, i = 0; i < dataGridViewY1s1_n.RowCount; j++, i++)
                    { x.Range["C" + j.ToString()].Value = dataGridViewY1s1_n.Rows[i].Cells[0].Value;
                        x.Range["J" + j.ToString()].Value = dataGridViewY1s1_n.Rows[i].Cells[4].Value;
                        x.Range["I" + j.ToString()].Value = dataGridViewY1s1_n.Rows[i].Cells[5].Value;
                    }

                    ///علامات
                    for (int j = 8, i = 0; i < dataGridViewY1s1_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY1s1_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["F" + j.ToString()].Value = dataGridViewY1s1_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY1s1_n.Rows[i].Cells[1].Value) > 0)
                                x.Range["G" + j.ToString()].Value += " (عملي فقط) ";
                            x.Range["N4"].Value = "00.00";
                        }
                        else
                            x.Range["F" + j.ToString()].Value = dataGridViewY1s1_n.Rows[i].Cells[3].Value;
                    }
                }

                //y1s2 subject
                if (dataGridViewY1s2_n.RowCount != 0)
                {
                    for (int j = 8, i = 0; i < dataGridViewY1s2_n.RowCount; j++, i++)
                    { x.Range["M" + j.ToString()].Value = dataGridViewY1s2_n.Rows[i].Cells[0].Value;
                        x.Range["T" + j.ToString()].Value = dataGridViewY1s2_n.Rows[i].Cells[4].Value;
                        x.Range["S" + j.ToString()].Value = dataGridViewY1s2_n.Rows[i].Cells[5].Value;
                    }
                    for (int j = 8, i = 0; i < dataGridViewY1s2_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY1s2_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["P" + j.ToString()].Value = dataGridViewY1s2_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY1s2_n.Rows[i].Cells[1].Value) > 0)
                                x.Range["Q" + j.ToString()].Value += " (عملي فقط) ";
                            x.Range["N4"].Value = "00.00";

                        }
                        else x.Range["P" + j.ToString()].Value = dataGridViewY1s2_n.Rows[i].Cells[3].Value;
                    }
                }

                //y2s1 subject
                if (dataGridViewY2s1_n.RowCount != 0)
                {
                    x.Range["AH4"].Value = txtavg2_n.Text;
                    x.Range["X4"].Value = Convert.ToString(dateEnter + 1) + "-" + Convert.ToString(dateEnter + 2);
                    for (int j = 8, i = 0; i < dataGridViewY2s1_n.RowCount; j++, i++)
                    { x.Range["W" + j.ToString()].Value = dataGridViewY2s1_n.Rows[i].Cells[0].Value;
                        x.Range["AD" + j.ToString()].Value = dataGridViewY2s1_n.Rows[i].Cells[4].Value;
                        x.Range["AC" + j.ToString()].Value = dataGridViewY2s1_n.Rows[i].Cells[5].Value;
                    }
                    for (int j = 8, i = 0; i < dataGridViewY2s1_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY2s1_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["Z" + j.ToString()].Value = dataGridViewY2s1_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY2s1_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["AA" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["Z" + j.ToString()].Value += "/30";
                            }
                            x.Range["AH4"].Value = "00.00";
                        }
                        else x.Range["Z" + j.ToString()].Value = dataGridViewY2s1_n.Rows[i].Cells[3].Value;
                    }
                }

                //y2s2 subject
                if (dataGridViewY2s2_n.RowCount != 0)
                {

                    for (int j = 8, i = 0; i < dataGridViewY2s2_n.RowCount; j++, i++)
                    { x.Range["AG" + j.ToString()].Value = dataGridViewY2s2_n.Rows[i].Cells[0].Value;
                        x.Range["AN" + j.ToString()].Value = dataGridViewY2s2_n.Rows[i].Cells[4].Value;
                        x.Range["AM" + j.ToString()].Value = dataGridViewY2s2_n.Rows[i].Cells[5].Value;
                    }
                    for (int j = 8, i = 0; i < dataGridViewY2s2_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY2s2_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["AJ" + j.ToString()].Value = dataGridViewY2s2_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY2s2_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["AK" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["AH4" + j.ToString()].Value += "/30";
                            }
                            x.Range["AH4"].Value = "00.00";

                        }
                        else x.Range["AJ" + j.ToString()].Value = dataGridViewY2s2_n.Rows[i].Cells[3].Value;
                    }
                }

    /*  /*    */      //y3s1 subject
                if (dataGridViewY3s1_n.RowCount != 0)
                {
                    x.Range["N17"].Value = txtavg3_n.Text;
                    x.Range["D17"].Value = Convert.ToString(dateEnter + 2) + "-" + Convert.ToString(dateEnter + 3);
                    for (int j = 21, i = 0; i < dataGridViewY3s1_n.RowCount; j++, i++)
                    { x.Range["M" + j.ToString()].Value = dataGridViewY3s1_n.Rows[i].Cells[0].Value;
                        x.Range["T" + j.ToString()].Value = dataGridViewY3s1_n.Rows[i].Cells[4].Value;
                        x.Range["S" + j.ToString()].Value = dataGridViewY3s1_n.Rows[i].Cells[5].Value;
                    }

                    for (int j = 21, i = 0; i < dataGridViewY3s1_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY3s1_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["P" + j.ToString()].Value = dataGridViewY3s1_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY3s1_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["Q" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["P" + j.ToString()].Value += "/30";
                            }
                            x.Range["N17"].Value = "00.00";

                        }
                        else x.Range["P" + j.ToString()].Value = dataGridViewY3s1_n.Rows[i].Cells[3].Value;
                    }
                }

                //y3s2 subject
                if (dataGridViewY3s2_n.RowCount != 0)
                {

                    for (int j = 21, i = 0; i < dataGridViewY3s2_n.RowCount; j++, i++)
                    { x.Range["M" + j.ToString()].Value = dataGridViewY3s2_n.Rows[i].Cells[0].Value;
                        x.Range["T" + j.ToString()].Value = dataGridViewY3s2_n.Rows[i].Cells[4].Value;
                        x.Range["S" + j.ToString()].Value = dataGridViewY3s2_n.Rows[i].Cells[5].Value;
                    }
                    for (int j = 21, i = 0; i < dataGridViewY3s2_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY3s2_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["F" + j.ToString()].Value = dataGridViewY3s2_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY3s2_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["G" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["F" + j.ToString()].Value += "/30";
                            }
                            x.Range["N17"].Value = "00.00";
                        }
                        else x.Range["F" + j.ToString()].Value = dataGridViewY3s2_n.Rows[i].Cells[3].Value;
                    }

                }

                //y4s1 subject
                if (dataGridViewY4s1_n.RowCount != 0)
                {
                    x.Range["AH17"].Value = txtavg4_n.Text;
                    x.Range["X17"].Value = Convert.ToString(dateEnter + 3) + "-" + Convert.ToString(dateEnter + 4);
                    for (int j = 21, i = 0; i < dataGridViewY4s1_n.RowCount; j++, i++)
                    { x.Range["W" + j.ToString()].Value = dataGridViewY4s1_n.Rows[i].Cells[0].Value;
                      x.Range["AD" + j.ToString()].Value = dataGridViewY4s1_n.Rows[i].Cells[4].Value;
                      x.Range["AC" + j.ToString()].Value = dataGridViewY4s1_n.Rows[i].Cells[5].Value;
                    }

                    for (int j = 21, i = 0; i < dataGridViewY4s1_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY4s1_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["Z" + j.ToString()].Value = dataGridViewY4s1_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY4s1_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["AA " + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["Z" + j.ToString()].Value += "/30";
                            }
                            x.Range["AH17"].Value = "00.00";
                        }
                        else x.Range["Z" + j.ToString()].Value = dataGridViewY4s1_n.Rows[i].Cells[3].Value;
                    }
                }
  
                //y4s2 subject
                if (dataGridViewY4s2_n.RowCount != 0)
                {
                    for (int j = 21, i = 0; i < dataGridViewY4s2_n.RowCount; j++, i++)
                    { x.Range["AG" + j.ToString()].Value = dataGridViewY4s2_n.Rows[i].Cells[0].Value;
                        x.Range["AN" + j.ToString()].Value = dataGridViewY4s2_n.Rows[i].Cells[4].Value;
                        x.Range["AM" + j.ToString()].Value = dataGridViewY4s2_n.Rows[i].Cells[5].Value; }

                    for (int j = 21, i = 0; i < dataGridViewY4s2_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY4s2_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["AJ" + j.ToString()].Value = dataGridViewY4s2_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY4s2_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["AK" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["AJ" + j.ToString()].Value += "/30";
                            }
                            x.Range["AH17"].Value = "00.00";
                        }
                        else x.Range["AJ" + j.ToString()].Value = dataGridViewY4s2_n.Rows[i].Cells[3].Value;
                    }
                }

                //y5s1 subject
                if (dataGridViewY5s1_n.RowCount != 0)
                {
                    x.Range["N42"].Value = txtavg5_n.Text;
                    x.Range["D42"].Value = Convert.ToString(dateEnter + 4) + "-" + Convert.ToString(dateEnter + 5);
                    for (int j = 46, i = 0; i < dataGridViewY5s1_n.RowCount; j++, i++)
                    {
                        x.Range["C" + j.ToString()].Value = dataGridViewY5s1_n.Rows[i].Cells[0].Value;
                        x.Range["J" + j.ToString()].Value = dataGridViewY5s1_n.Rows[i].Cells[4].Value;
                        x.Range["I" + j.ToString()].Value = dataGridViewY5s1_n.Rows[i].Cells[5].Value;
                    }

                    for (int j = 46, i = 0; i < dataGridViewY5s1_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY5s1_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["F" + j.ToString()].Value = dataGridViewY5s1_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY5s1_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["G" + j.ToString()].Value += " (عملي فقط) ";
                                x.Range["F" + j.ToString()].Value += "/30";
                            }
                            x.Range["N42"].Value = "00.00";
                        }
                        else x.Range["F" + j.ToString()].Value = dataGridViewY4s1_n.Rows[i].Cells[3].Value;
                    }
                }

                //y5s2 subject
                if (dataGridViewY5s2_n.RowCount != 0)
                {
                    for (int j = 46, i = 0; i < dataGridViewY5s2_n.RowCount; j++, i++)
                    {
                        x.Range["M" + j.ToString()].Value = dataGridViewY5s2_n.Rows[i].Cells[0].Value;
                        x.Range["T" + j.ToString()].Value = dataGridViewY5s2_n.Rows[i].Cells[4].Value;
                        x.Range["S" + j.ToString()].Value = dataGridViewY5s2_n.Rows[i].Cells[5].Value;
                    }

                    for (int j = 46, i = 0; i < dataGridViewY5s2_n.RowCount; j++, i++)
                    {
                        if (Convert.ToInt16(dataGridViewY5s2_n.Rows[i].Cells[3].Value) < 60)
                        {
                            x.Range["P" + j.ToString()].Value = dataGridViewY5s2_n.Rows[i].Cells[1].Value;
                            if (Convert.ToInt16(dataGridViewY5s2_n.Rows[i].Cells[1].Value) > 0)
                            {
                                x.Range["Q" + j.ToString()].Value += " (عملي فقط) ";
                                     x.Range["P" + j.ToString()].Value += "/30";
                            }
                            x.Range["N42"].Value = "00.00";
                        }
                        else x.Range["P" + j.ToString()].Value = dataGridViewY5s2_n.Rows[i].Cells[3].Value;
                    }
                }

                //     التصدير كملف pdf
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
               Environment.SpecialFolder.MyDocuments), "أرشيف كشف العلامات\\");
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف كشف العلامات\\" + "صحيفة الطالب" + "_" + txtName.Text);
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف كشف العلامات\\" + "صحيفة الطالب" + "_" + txtName.Text);
                }
                //  work1.SaveAs(path_excel);
                //  work1.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                x.SaveAs(path_excel);
                x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                this.Cursor = Cursors.Default;
                textBox2.Text = "pdf تم تصدير صحيفة الطالب إلى ملف";
                System.Diagnostics.Process.Start(path_excel + ".pdf");
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            x1();
        }
        private void x1()
        {
            if (button9.BackColor.ToString() == "Color [Highlight]")
            {
                button9.BackColor = Color.Green;
                button8.BackColor = Color.FromName("Highlight");
                panel_score.Visible = true; panel_newspaper.Visible = false;
                panel_score.Location = new System.Drawing.Point(7, 142);
                if (Convert.ToInt16(dataGridView_detils.Rows[0].Cells[5].Value) >= 5)
                {     panel_score.Size = new Size(1147, 700); }
                else { panel_score.Size = new Size(1147, 527); }
 
            }
            else
            {
                button9.BackColor = Color.FromName("Highlight");
                panel_score.Visible = false;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView_mat_year.Rows.Count > 0)
            {
                this.Enabled = false;
                PL.FRM_MAIN.getMainForm.panelleft.Enabled = false;
                export = "partical";
                f = "كلية " + cmb_facluty_lot.SelectedItem.ToString();
                y = cmbyear.SelectedItem.ToString();
                m = txtmat.Text;
                n = "قائمة درجات النظري لمقرر: " + txtmat_name.Text;
                n1 = "قائمة درجات العملي لمقرر: " + txtmat_name.Text;
                s = "الفصل الدراسي: " + cmbSeson.SelectedItem.ToString();
                ty = Convert.ToInt32(txt_year.Text) - 1; // العام الدراسي
                                                         //     string bbb = Convert.ToString(nnn);
                                                         //     = txt_year.Text + " / " + bbb;
                backgroundWorker1.RunWorkerAsync();

                progressBar1.Visible = true;
                lb_pp.Visible = true;
            }
            else
            { MessageBox.Show("الرجاء اختيار المادة والسنة لتعبئة الجدول"); }

        }

        public void degree_particla(string f, string y, string m, string n, string s, int ty)
        {
            try
            {
                string rr = System.IO.Path.GetFullPath("إصدار العلامات.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(rr);
              //  this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\إصدار العلامات.xlsx");
                Excel.Worksheet r = app1.Sheets[1];
                //اااااااااااااااااااااااااااااااااااااااااااااااااااااااااا
                  r.Range["A2"].Value = f;//"كلية " + cmb_facluty_lot.SelectedItem.ToString();
            r.Range["C8"].Value = y;//cmbyear.SelectedItem.ToString();
            r.Range["G7"].Value = m; //txtmat.Text;
            r.Range["A7"].Value =  "قائمة درجات العملي لمقرر: " + txtmat_name.Text;
            r.Range["H7"].Value = s;// "الفصل الدراسي: " + cmbSeson.SelectedItem.ToString();
            int nnn = ty;// Convert.ToInt32(txt_year.Text) - 1; // العام الدراسي
                string bbb = Convert.ToString(nnn);
            r.Range["G8"].Value = (ty+1).ToString () + " / " + bbb ;// txt_year.Text + " / " + bbb;
                int k = 0;
                //اااااااااااااااااااااااااااااااااااااااااااااااااااااااااا
                for (int i = 0, j = 11; i < dataGridView_mat_year.RowCount; i++, j++)
                {

                    r.Range["A" + j.ToString()].Value = dataGridView_mat_year.Rows[i].Cells[0].Value;
                    r.Range["B" + j.ToString()].Value = dataGridView_mat_year.Rows[i].Cells[1].Value;
                    r.Range["C" + j.ToString()].Value = dataGridView_mat_year.Rows[i].Cells[2].Value;
                    r.Range["D" + j.ToString()].Value = dataGridView_mat_year.Rows[i].Cells[3].Value;
                    r.Range["E" + j.ToString()].Value = "-";
                    r.Range["F" + j.ToString()].Value = dataGridView_mat_year.Rows[i].Cells[4].Value;
                    r.Range["G" + j.ToString()].Value = dataGridView_mat_year.Rows[i].Cells[4].Value;
                    k++;
                    backgroundWorker1.ReportProgress((k * 100) / dataGridView_mat_year.Rows.Count);
                }
                k = 0;
                //for (int i = dataGridView_mat_year.RowCount + 1, j = 11 + dataGridView_mat_year.RowCount; i < 136; i++, j++)
                Parallel.For(dataGridView_mat_year.RowCount + 1, 136, i =>
                {
                    r.Range["H" + (i+10).ToString()].Value = null;
                    if (i > 42 && (dataGridView_mat_year.RowCount) <= 42)
                    {
                        r.Rows[i+10].ClearFormats();
                    }
                    else if (i > 94 && (dataGridView_mat_year.RowCount) <= 94)
                    {
                        r.Rows[i+10].ClearFormats();
                    }
                    backgroundWorker1.ReportProgress((k * 100) / 114);                 
                    k++;
                });


                //اااااااااااااااااااااااااااااااااااااااااااااااااااااااااا
                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
              Environment.SpecialFolder.MyDocuments), "أرشيف علامات المواد\\");
                string mat_name = txtmat_name.Text.Replace('/', ' ');
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف علامات المواد\\" + " علامات العملي لمادة" + mat_name);
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف علامات المواد\\" + " علامات العملي لمادة" + mat_name);
                }

                r.SaveAs(path_excel);
                r.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
             //   this.Cursor = Cursors.Default;
              //  textBox2.Text = "pdf تم تصدير قائمة الدرجات إلى ملف";
                System.Diagnostics.Process.Start(path_excel + ".pdf");
                work1.Close();
                app1.Quit();
             //   System.IO.File.Delete(path_excel + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string export, f, y, m, n,n1, s;public int ty;
        private void button10_Click_1(object sender, EventArgs e)
        {
            if (dataGridView_mat_year.Rows.Count > 0)
            {
                this.Enabled = false;
                PL.FRM_MAIN.getMainForm.panelleft.Enabled = false;
                export = "final";
                f = "كلية " + cmb_facluty_lot.SelectedItem.ToString();
                y = cmbyear.SelectedItem.ToString();
                m = txtmat.Text;
                n = "قائمة درجات النظري لمقرر: " + txtmat_name.Text;
                n1 = "قائمة درجات العملي لمقرر: " + txtmat_name.Text;
                s = "الفصل الدراسي: " + cmbSeson.SelectedItem.ToString();
                ty = Convert.ToInt32(txt_year.Text) - 1; // العام الدراسي
                                                         //     string bbb = Convert.ToString(nnn);
                                                         //     = txt_year.Text + " / " + bbb;
                backgroundWorker1.RunWorkerAsync();

                progressBar1.Visible = true;

                lb_pp.Visible = true;
                // degree_final();
            }
            else
            { MessageBox.Show("الرجاء اختيار المادة والسنة لتعبئة الجدول"); }
        }

        public void degree_final(string f, string y ,string m ,string n,string s,int ty)
        {
            try
            {
                string rr = System.IO.Path.GetFullPath("إصدار العلامات.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(rr);
             //   this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\إصدار العلامات.xlsx");
                Excel.Worksheet r = app1.Sheets[2];

                //اااااااااااااااااااااااااااااااااااااااااااااااااااااااااا
              //  string f = "كلية " + cmb_facluty_lot.SelectedItem.ToString();
            r.Range["A2"].Value = f;//"كلية " + cmb_facluty_lot.SelectedItem.ToString();
            r.Range["C8"].Value = y;//cmbyear.SelectedItem.ToString();
            r.Range["G7"].Value = m; //txtmat.Text;
            r.Range["A7"].Value = n;// "قائمة درجات النظري لمقرر: " + txtmat_name.Text;
            r.Range["H7"].Value = s;// "الفصل الدراسي: " + cmbSeson.SelectedItem.ToString();

            r.Range["A6"].Value = txt_takers.Text;
            r.Range["D6"].Value = txt_succ_rate.Text;
            r.Range["C6"].Value = txt_succ_num.Text;
            r.Range["G6"].Value = txt_fail_num.Text;
            r.Range["H6"].Value = txt_fail_rate.Text;
            int nnn = ty;// Convert.ToInt32(txt_year.Text) - 1; // العام الدراسي
                string bbb = Convert.ToString(nnn);
            r.Range["G8"].Value = (ty+1).ToString () + " / " + bbb ;// txt_year.Text + " / " + bbb;

            //اااااااااااااااااااااااااااااااااااااااااااااااااااااااااا
            int k = 0;//, j = 11;
               // Parallel.For(0, dataGridView_mat_year.Rows.Count, i =>
                                for (int i = 0, j = 11; i < dataGridView_mat_year.RowCount; i++, j++)
                {
                    
                    r.Range["A" + (i+11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[0].Value;
                    r.Range["B" + (i + 11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[1].Value;
                    r.Range["C" + (i + 11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[2].Value;
                    r.Range["D" + (i + 11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[3].Value;
                    r.Range["E" + (i + 11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[4].Value;
                    r.Range["F" + (i + 11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[5].Value;
                    r.Range["G" + (i + 11).ToString()].Value = dataGridView_mat_year.Rows[i].Cells[6].Value;
                    k++;
                     backgroundWorker1.ReportProgress((k * 100) / dataGridView_mat_year.Rows.Count);
                  
                }//);
            k = 0;
           //      for (int i = dataGridView_mat_year.RowCount + 1, jn = 11 + dataGridView_mat_year.RowCount; i < 136; i++, jn++)
            Parallel.For(dataGridView_mat_year.RowCount + 1, 133, i =>
            {
               
                r.Range["H" + (i+10).ToString()].Value = null;
                if (i > 41 && (dataGridView_mat_year.RowCount) <= 41)
                {
                    r.Rows[i + 10].ClearFormats();
                                        
                }
                else if (i > 92 && (dataGridView_mat_year.RowCount) <= 92)
                {
                    r.Rows[i + 10].ClearFormats();
                }
                backgroundWorker1.ReportProgress((k * 100) / 114);
 //               jn++;
                k++;
            });
            //اااااااااااااااااااااااااااااااااااااااااااااااااااااااااا
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
              Environment.SpecialFolder.MyDocuments), "أرشيف علامات المواد\\");
                string mat_name = txtmat_name.Text.Replace('/', ' ');
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف علامات المواد\\" + "علامات النظري لمادة " + mat_name);
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف علامات المواد\\" + "علامات النظري لمادة " + mat_name);
                }

                r.SaveAs(path_excel);
                r.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
             //   this.Cursor = Cursors.Default;
             //   textBox2.Text = "pdf تم تصدير قائمة الدرجات إلى ملف";
                System.Diagnostics.Process.Start(path_excel + ".pdf");
                work1.Close();
                app1.Quit();
                //  System.IO.File.Delete(path_excel + ".xlsx");
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExport_n_Click(object sender, EventArgs e)
        {
            newspaper_student();
        }

        private void btn_exam_record_Click(object sender, EventArgs e)
        {
            if (cmb_year_mat.SelectedIndex == -1)
            {
                txt_year_deg.Enabled = false;
            }
            groupBox_mat_year.Visible = false;
            panel_exam_record.Visible = true;
            panel_exam_record.Size = new Size(880, 573);
            panel_exam_record.Location = new System.Drawing.Point(290,74);
            btn_exam_record.Enabled = false;
         //   btn_top10.Enabled = false;
            button7.Enabled = true;
            cmb_fac.SelectedIndex = 3;
        }

        private void cmb_year_mat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_year_mat.SelectedIndex != -1)
            {
                txt_year_deg.Enabled = true;
                export_exam_rec();
                export_exam_rec_n();
            }
            else
            {
               
                MessageBox.Show("الرجاء إدخال سنة المادة");
            }
        }
        private void export_exam_rec()
        {
            try
            {
                if (cmb_year_mat.SelectedIndex == 0)
                    dt_exam_rec.DataSource = cost.exam_record(1, Convert.ToInt16(txt_year_deg.Text));
                else if (cmb_year_mat.SelectedIndex == 1)
                    dt_exam_rec.DataSource = cost.exam_record(2, Convert.ToInt16(txt_year_deg.Text));
                else if (cmb_year_mat.SelectedIndex == 2)
                    dt_exam_rec.DataSource = cost.exam_record(3, Convert.ToInt16(txt_year_deg.Text));
                else if (cmb_year_mat.SelectedIndex == 3)
                    dt_exam_rec.DataSource = cost.exam_record(4, Convert.ToInt16(txt_year_deg.Text));
                else if (cmb_year_mat.SelectedIndex == 4)
                    dt_exam_rec.DataSource = cost.exam_record(5, Convert.ToInt16(txt_year_deg.Text));
                else
                    dt_exam_rec.DataSource = cost.exam_record(6, Convert.ToInt16(txt_year_deg.Text));

            }
            catch (Exception) { }
        }

        private void export_exam_rec_n()
        {
            try
            {
                dt_exam_rec_p.DataSource = cost.exam_record_p(4, cmb_year_mat.SelectedIndex + 1, Convert.ToInt16(txt_year_deg.Text));
                dt_exam_rec_t.DataSource = cost.exam_record_t(4, cmb_year_mat.SelectedIndex + 1, Convert.ToInt16(txt_year_deg.Text));
                dt_exam_rec_f.DataSource = cost.exam_record_f(4, cmb_year_mat.SelectedIndex + 1, Convert.ToInt16(txt_year_deg.Text));

                dt_exam_rec2.DataSource=cost.exam_record_by_mat(4, cmb_year_mat.SelectedIndex + 1, Convert.ToInt16(txt_year_deg.Text)); 

            }
            catch (Exception) { }
        }


        private void txt_year_deg_TextChanged(object sender, EventArgs e)
        {

           
            if (cmb_year_mat.SelectedIndex != -1)
            {
               export_exam_rec();
               export_exam_rec_n();

            }
            else
            {
                
                MessageBox.Show("الرجاء إدخال سنة المادة");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel_exam_record.Visible = false;
        }


        private void exam_record1()
        {
            // التصدير الى السجل السنوي
            try
            {

            string xx = System.IO.Path.GetFullPath("سجل سنوي معلوماتية.xlsx");
            string path2 = System.IO.Path.GetDirectoryName(xx);
            this.Cursor = Cursors.WaitCursor;
            Excel.Application app1 = new Excel.Application();
            Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
            int y = cmb_year_mat.SelectedIndex;
            int s = dt_exam_rec_p.Rows.Count;
            //int count = 0;
            int num = 0;
            int ind = 0;
            int id33 = 6, jd33 = 7, jd3333 = 8, iid33 = 10, js33 = 5;
            if (y == 0)
            {
                Excel.Worksheet x = app1.Sheets[1];

                //  x.Range["AL2"].Value = txtid.Text;
                x.Range["C5"].Value = dt_exam_rec_p.Rows[0].Cells[1].Value.ToString();
                x.Range["D5"].Value = dt_exam_rec_p.Rows[0].Cells[2].Value.ToString();
                x.Range["E5"].Value = dt_exam_rec_p.Rows[0].Cells[0].Value.ToString();

                for (int is3 = 0; is3 < s; is3 += 1)
                {
                    ind = dt_exam_rec_p.Rows[is3].Index;

                    if (is3 != 0)
                    {
                        for (int js3 = js33; js33 < 25; js3 += 6)
                        {
                            x.Range["C" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[1].Value.ToString();
                            x.Range["D" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[2].Value.ToString();
                            x.Range["E" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[0].Value.ToString();
                            break;
                        }
                    }
                    //}
                    //علامات العملي
                    for (int id3 = id33; id33 < 25; id3 += 6)
                    {

                        x.Range["M" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[3].Value.ToString();
                        x.Range["L" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[4].Value.ToString();
                        x.Range["T" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[5].Value.ToString();
                        x.Range["J" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[6].Value.ToString();
                        x.Range["I" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[7].Value.ToString();
                        x.Range["G" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[8].Value.ToString();
                        x.Range["H" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[9].Value.ToString();
                        x.Range["S" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[10].Value.ToString();
                        x.Range["R" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[12].Value.ToString();
                        x.Range["N" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[14].Value.ToString();
                        x.Range["Q" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[15].Value.ToString();
                        x.Range["K" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[16].Value.ToString();
                        break;
                    }

                    //علامات النظري
                    //دورة 1

                    for (int jd3 = jd33; jd33 < 26; jd3 += 6)
                    {
                        x.Range["M" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[3].Value.ToString();
                        x.Range["L" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[4].Value.ToString();
                        x.Range["J" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[6].Value.ToString();
                        x.Range["I" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[7].Value.ToString();
                        x.Range["H" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[9].Value.ToString();
                        x.Range["G" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[8].Value.ToString();
                        x.Range["K" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[16].Value.ToString();
                        break;
                    }
                    //دورة 2

                    for (int jd333 = jd3333; jd3333 < 27; jd333 += 6)
                    {
                        x.Range["T" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[5].Value.ToString();
                        x.Range["S" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[10].Value.ToString();
                        x.Range["R" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[11].Value.ToString();
                        x.Range["Q" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[15].Value.ToString();
                        x.Range["P" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[12].Value.ToString();
                        x.Range["O" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[14].Value.ToString();
                        x.Range["N" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[13].Value.ToString();
                        break;

                    }

                    //مجموع
                    for (int iid3 = iid33; iid33 < 29; iid3 += 6)
                    {

                        x.Range["M" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[3].Value.ToString();
                        x.Range["L" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[4].Value.ToString();
                        x.Range["T" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[5].Value.ToString();
                        x.Range["J" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[6].Value.ToString();
                        x.Range["I" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[7].Value.ToString();
                        x.Range["G" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[8].Value.ToString();
                        x.Range["H" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[9].Value.ToString();
                        x.Range["S" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[10].Value.ToString();
                        x.Range["R" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[12].Value.ToString();
                        x.Range["N" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[14].Value.ToString();
                        x.Range["Q" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[15].Value.ToString();
                        x.Range["K" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[16].Value.ToString();
                        break;

                    }
                    if (js33 < 23) js33 += 6; else js33 = 5;
                    if (id33 < 24) id33 += 6; else id33 = 6;
                    if (jd33 < 25) jd33 += 6; else jd33 = 7;
                    if (jd3333 < 26) jd3333 += 6; else jd3333 = 8;
                    if (iid33 < 28) iid33 += 6; else iid33 = 10;

                    if (((is3 + 1) % 4 == 0) || (((is3 + 1) % 4 != 0) && ind == s - 1))
                    {

                        //pdf التصدير كملف 
                        num++;

                        //العام الدراسي
                        x.Range["AE2"].Value = ((Convert.ToInt16(txt_year_deg.Text) - 1)).ToString();
                        x.Range["AH2"].Value = txt_year_deg.Text;


                        //رقم الصفحة
                        x.Range["AB1"].Value = "/   " + num + "  /" + ":رقم الصفحة";

                        path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
                        if (!System.IO.Directory.Exists(path_excel))
                        {
                            System.IO.Directory.CreateDirectory(path_excel);
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        else
                        {
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                               Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        x.SaveAs(path_excel);
                        x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                        System.Diagnostics.Process.Start(path_excel + ".pdf");
                        //count = 0;
                        work1.Close();
                        app1.Quit();
                        System.IO.File.Delete(path_excel + ".xlsx");
                        app1 = new Excel.Application();
                        work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
                        x = app1.Sheets[1];
                    }
                }
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");


                this.Cursor = Cursors.Default;
                MessageBox.Show("تم تصدير ملفات السجل الامتحاني بنجاح","تصدير السجل الامتحاني",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Cursor = Cursors.Default;
            }


        }
        private void exam_record2()
        {
            // التصدير الى السجل السنوي
            try
            {

            string xx = System.IO.Path.GetFullPath("سجل سنوي معلوماتية.xlsx");
            string path2 = System.IO.Path.GetDirectoryName(xx);
            this.Cursor = Cursors.WaitCursor;
            Excel.Application app1 = new Excel.Application();
            Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
            int y = cmb_year_mat.SelectedIndex;
            int s = dt_exam_rec_p.Rows.Count;
            //int count = 0;
            int num = 0;
            int ind = 0;
            int id33 = 6, jd33 = 7, jd3333 = 8, iid33 = 10, js33 = 5;
            if (y == 1)
            {
                Excel.Worksheet x = app1.Sheets[2];

                //  x.Range["AL2"].Value = txtid.Text;
                x.Range["C5"].Value = dt_exam_rec_p.Rows[0].Cells[1].Value.ToString();
                x.Range["D5"].Value = dt_exam_rec_p.Rows[0].Cells[2].Value.ToString();
                x.Range["E5"].Value = dt_exam_rec_p.Rows[0].Cells[0].Value.ToString();

                for (int is3 = 0; is3 < s; is3 += 1)
                {
                    ind = dt_exam_rec_p.Rows[is3].Index;

                    if (is3 != 0)
                    {
                        for (int js3 = js33; js33 < 25; js3 += 6)
                        {
                            x.Range["C" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[1].Value.ToString();
                            x.Range["D" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[2].Value.ToString();
                            x.Range["E" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[0].Value.ToString();
                            break;
                        }
                    }
                    //}
                    //علامات العملي
                    for (int id3 = id33; id33 < 25; id3 += 6)
                    {

                        x.Range["L" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[3].Value.ToString();
                        x.Range["G" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[4].Value.ToString();
                        x.Range["M" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[5].Value.ToString();
                        x.Range["I" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[6].Value.ToString();
                        x.Range["K" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[7].Value.ToString();
                        x.Range["J" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[8].Value.ToString();
                        x.Range["H" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[9].Value.ToString();
                        x.Range["Q" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[10].Value.ToString();
                        x.Range["N" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[12].Value.ToString();
                        x.Range["R" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[14].Value.ToString();
                        x.Range["S" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[15].Value.ToString();
                        x.Range["T" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[16].Value.ToString();
                        break;
                    }

                    //علامات النظري
                    //دورة 1

                    for (int jd3 = jd33; jd33 < 26; jd3 += 6)
                    {
                        x.Range["L" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[3].Value.ToString();
                        x.Range["G" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[4].Value.ToString();
                        x.Range["M" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[5].Value.ToString();
                        x.Range["I" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[6].Value.ToString();
                        x.Range["K" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[7].Value.ToString();
                        x.Range["J" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[8].Value.ToString();
                        x.Range["H" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[9].Value.ToString();
                        break;
                    }
                    //دورة 2

                    for (int jd333 = jd3333; jd3333 < 27; jd333 += 6)
                    {
                        x.Range["Q" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[10].Value.ToString();
                        x.Range["N" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[12].Value.ToString();
                        x.Range["R" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[14].Value.ToString();
                        x.Range["S" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[15].Value.ToString();
                        x.Range["T" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[16].Value.ToString();
                        break;

                    }

                    //مجموع
                    for (int iid3 = iid33; iid33 < 29; iid3 += 6)
                    {

                        x.Range["L" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[3].Value.ToString();
                        x.Range["G" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[4].Value.ToString();
                        x.Range["M" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[5].Value.ToString();
                        x.Range["I" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[6].Value.ToString();
                        x.Range["K" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[7].Value.ToString();
                        x.Range["J" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[8].Value.ToString();
                        x.Range["H" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[9].Value.ToString();
                        x.Range["Q" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[10].Value.ToString();
                        x.Range["N" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[12].Value.ToString();
                        x.Range["R" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[14].Value.ToString();
                        x.Range["S" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[15].Value.ToString();
                        x.Range["T" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[16].Value.ToString();
                        break;

                    }
                    if (js33 < 23) js33 += 6; else js33 = 5;
                    if (id33 < 24) id33 += 6; else id33 = 6;
                    if (jd33 < 25) jd33 += 6; else jd33 = 7;
                    if (jd3333 < 26) jd3333 += 6; else jd3333 = 8;
                    if (iid33 < 28) iid33 += 6; else iid33 = 10;

                    if (((is3 + 1) % 4 == 0) || (((is3 + 1) % 4 != 0) && ind == s - 1))
                    {

                        //pdf التصدير كملف 
                        num++;

                        //العام الدراسي
                        x.Range["AE2"].Value = ((Convert.ToInt16(txt_year_deg.Text) - 1)).ToString();
                        x.Range["AH2"].Value = txt_year_deg.Text;


                        //رقم الصفحة
                        x.Range["AB1"].Value = "/   " + num + "  /" + ":رقم الصفحة";

                        path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
                        if (!System.IO.Directory.Exists(path_excel))
                        {
                            System.IO.Directory.CreateDirectory(path_excel);
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        else
                        {
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                               Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        x.SaveAs(path_excel);
                        x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                        System.Diagnostics.Process.Start(path_excel + ".pdf");
                        //  count = 0;
                        work1.Close();
                        app1.Quit();
                        System.IO.File.Delete(path_excel + ".xlsx");
                        app1 = new Excel.Application();
                        work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
                        x = app1.Sheets[2];
                    }
                }
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");


                this.Cursor = Cursors.Default;
                MessageBox.Show("تم تصدير ملفات السجل الامتحاني بنجاح", "تصدير السجل الامتحاني", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Cursor = Cursors.Default;
            }


        }
        private void exam_record3()
        {
            // التصدير الى السجل السنوي
            try
            {

            string xx = System.IO.Path.GetFullPath("سجل سنوي معلوماتية.xlsx");
            string path2 = System.IO.Path.GetDirectoryName(xx);
            this.Cursor = Cursors.WaitCursor;
            Excel.Application app1 = new Excel.Application();
            Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
            int y = cmb_year_mat.SelectedIndex;
            int s = dt_exam_rec_p.Rows.Count;
            //int count = 0;
            int num = 0;
            int ind = 0;
            int id33 = 6, jd33 = 7, jd3333 = 8, iid33 = 10, js33 = 5;
            if (y == 2)
            {
                Excel.Worksheet x = app1.Sheets[3];

                //  x.Range["AL2"].Value = txtid.Text;
                x.Range["C5"].Value = dt_exam_rec_p.Rows[0].Cells[1].Value.ToString();
                x.Range["D5"].Value = dt_exam_rec_p.Rows[0].Cells[2].Value.ToString();
                x.Range["E5"].Value = dt_exam_rec_p.Rows[0].Cells[0].Value.ToString();

                for (int is3 = 0; is3 < s; is3 += 1)
                {
                    ind = dt_exam_rec_p.Rows[is3].Index;

                    if (is3 != 0)
                    {
                        for (int js3 = js33; js33 < 25; js3 += 6)
                        {
                            x.Range["C" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[1].Value.ToString();
                            x.Range["D" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[2].Value.ToString();
                            x.Range["E" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[0].Value.ToString();
                            break;
                        }
                    }
                    //}
                    //علامات العملي
                    for (int id3 = id33; id33 < 25; id3 += 6)
                    {

                        x.Range["L" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[3].Value.ToString();
                        x.Range["G" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[4].Value.ToString();
                        x.Range["I" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[5].Value.ToString();
                        x.Range["J" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[6].Value.ToString();
                        x.Range["H" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[7].Value.ToString();
                        x.Range["K" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[8].Value.ToString();
                        x.Range["S" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[16].Value.ToString();
                        x.Range["T" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[10].Value.ToString();
                        x.Range["O" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[12].Value.ToString();
                        x.Range["Q" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[13].Value.ToString();
                        x.Range["N" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[14].Value.ToString();
                        x.Range["R" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[15].Value.ToString();
                        x.Range["M" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[9].Value.ToString();
                        break;
                    }

                    //علامات النظري
                    //دورة 1

                    for (int jd3 = jd33; jd33 < 26; jd3 += 6)
                    {
                        x.Range["L" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[3].Value.ToString();
                        x.Range["G" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[4].Value.ToString();
                        x.Range["I" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[5].Value.ToString();
                        x.Range["J" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[6].Value.ToString();
                        x.Range["H" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[7].Value.ToString();
                        x.Range["K" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[8].Value.ToString();
                        x.Range["M" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[9].Value.ToString();
                        break;
                    }
                    //دورة 2

                    for (int jd333 = jd3333; jd3333 < 27; jd333 += 6)
                    {
                        x.Range["T" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[10].Value.ToString();
                        x.Range["O" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[12].Value.ToString();
                        x.Range["Q" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[13].Value.ToString();
                        x.Range["N" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[14].Value.ToString();
                        x.Range["R" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[15].Value.ToString();
                        x.Range["S" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[16].Value.ToString();
                        break;

                    }

                    //مجموع
                    for (int iid3 = iid33; iid33 < 29; iid3 += 6)
                    {

                        x.Range["L" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[3].Value.ToString();
                        x.Range["G" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[4].Value.ToString();
                        x.Range["I" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[5].Value.ToString();
                        x.Range["J" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[6].Value.ToString();
                        x.Range["H" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[7].Value.ToString();
                        x.Range["K" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[8].Value.ToString();
                        x.Range["S" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[16].Value.ToString();
                        x.Range["T" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[10].Value.ToString();
                        x.Range["O" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[11].Value.ToString();
                        x.Range["P" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[12].Value.ToString();
                        x.Range["Q" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[13].Value.ToString();
                        x.Range["N" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[14].Value.ToString();
                        x.Range["R" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[15].Value.ToString();
                        x.Range["M" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[9].Value.ToString();
                        break;

                    }
                    if (js33 < 23) js33 += 6; else js33 = 5;
                    if (id33 < 24) id33 += 6; else id33 = 6;
                    if (jd33 < 25) jd33 += 6; else jd33 = 7;
                    if (jd3333 < 26) jd3333 += 6; else jd3333 = 8;
                    if (iid33 < 28) iid33 += 6; else iid33 = 10;

                    if (((is3 + 1) % 4 == 0) || (((is3 + 1) % 4 != 0) && ind == s - 1))
                    {
                        //pdf التصدير كملف 
                        num++;

                        //العام الدراسي
                        x.Range["AE2"].Value = ((Convert.ToInt16(txt_year_deg.Text) - 1)).ToString();
                        x.Range["AH2"].Value = txt_year_deg.Text;


                        //رقم الصفحة
                        x.Range["AB1"].Value = "/   " + num + "  /" + ":رقم الصفحة";

                        path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
                        if (!System.IO.Directory.Exists(path_excel))
                        {
                            System.IO.Directory.CreateDirectory(path_excel);
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        else
                        {
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                               Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        x.SaveAs(path_excel);
                        x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                        System.Diagnostics.Process.Start(path_excel + ".pdf");
                        //  count = 0;
                        work1.Close();
                        app1.Quit();
                        System.IO.File.Delete(path_excel + ".xlsx");
                        app1 = new Excel.Application();
                        work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
                        x = app1.Sheets[3];
                    }
                }
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");


                this.Cursor = Cursors.Default;
                MessageBox.Show("تم تصدير ملفات السجل الامتحاني بنجاح", "تصدير السجل الامتحاني", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Cursor = Cursors.Default;
            }


        }
        private void exam_record4()
        {
            // التصدير الى السجل السنوي
            try
            {

            string xx = System.IO.Path.GetFullPath("سجل سنوي معلوماتية.xlsx");
            string path2 = System.IO.Path.GetDirectoryName(xx);
            this.Cursor = Cursors.WaitCursor;
            Excel.Application app1 = new Excel.Application();
            Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
            int y = cmb_year_mat.SelectedIndex;
            int s = dt_exam_rec_p.Rows.Count;
            //int count = 0;
            int num = 0;
            int ind = 0;
            int id33 = 6, jd33 = 7, jd3333 = 8, iid33 = 10, js33 = 5;
            if (y == 3)
            {
                Excel.Worksheet x = app1.Sheets[4];

                //  x.Range["AL2"].Value = txtid.Text;
                x.Range["C5"].Value = dt_exam_rec_p.Rows[0].Cells[1].Value.ToString();
                x.Range["D5"].Value = dt_exam_rec_p.Rows[0].Cells[2].Value.ToString();
                x.Range["E5"].Value = dt_exam_rec_p.Rows[0].Cells[0].Value.ToString();

                for (int is3 = 0; is3 < s; is3 += 1)
                {
                    ind = dt_exam_rec_p.Rows[is3].Index;

                    if (is3 != 0)
                    {
                        for (int js3 = js33; js33 < 25; js3 += 6)
                        {
                            x.Range["C" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[1].Value.ToString();
                            x.Range["D" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[2].Value.ToString();
                            x.Range["E" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[0].Value.ToString();
                            break;
                        }
                    }
                    //}
                    //علامات العملي
                    for (int id3 = id33; id33 < 25; id3 += 6)
                    {

                        x.Range["K" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[3].Value.ToString();
                        x.Range["I" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[4].Value.ToString();
                        x.Range["J" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[5].Value.ToString();
                        x.Range["L" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[6].Value.ToString();
                        x.Range["H" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[7].Value.ToString();
                        x.Range["G" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[8].Value.ToString();
                        x.Range["M" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[9].Value.ToString();
                        x.Range["T" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[10].Value.ToString();
                        x.Range["S" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[11].Value.ToString();
                        x.Range["R" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[12].Value.ToString();
                        x.Range["N" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[14].Value.ToString();
                        x.Range["P" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[15].Value.ToString();
                        x.Range["Q" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[16].Value.ToString();
                        break;
                    }

                    //علامات النظري
                    //دورة 1

                    for (int jd3 = jd33; jd33 < 26; jd3 += 6)
                    {
                        x.Range["K" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[3].Value.ToString();
                        x.Range["I" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[4].Value.ToString();
                        x.Range["J" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[5].Value.ToString();
                        x.Range["L" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[6].Value.ToString();
                        x.Range["H" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[7].Value.ToString();
                        x.Range["G" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[8].Value.ToString();
                        x.Range["M" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[9].Value.ToString();
                        break;
                    }
                    //دورة 2

                    for (int jd333 = jd3333; jd3333 < 27; jd333 += 6)
                    {
                        x.Range["T" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[10].Value.ToString();
                        x.Range["S" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[11].Value.ToString();
                        x.Range["R" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[12].Value.ToString();
                        x.Range["N" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[14].Value.ToString();
                        x.Range["P" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[15].Value.ToString();
                        x.Range["Q" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[16].Value.ToString();
                        break;

                    }

                    //مجموع
                    for (int iid3 = iid33; iid33 < 29; iid3 += 6)
                    {

                        x.Range["K" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[3].Value.ToString();
                        x.Range["I" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[4].Value.ToString();
                        x.Range["J" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[5].Value.ToString();
                        x.Range["L" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[6].Value.ToString();
                        x.Range["H" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[7].Value.ToString();
                        x.Range["G" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[8].Value.ToString();
                        x.Range["M" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[9].Value.ToString();
                        x.Range["T" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[10].Value.ToString();
                        x.Range["S" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[11].Value.ToString();
                        x.Range["R" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[12].Value.ToString();
                        x.Range["N" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[13].Value.ToString();
                        x.Range["O" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[14].Value.ToString();
                        x.Range["P" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[15].Value.ToString();
                        x.Range["Q" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[16].Value.ToString();
                        break;

                    }
                    if (js33 < 23) js33 += 6; else js33 = 5;
                    if (id33 < 24) id33 += 6; else id33 = 6;
                    if (jd33 < 25) jd33 += 6; else jd33 = 7;
                    if (jd3333 < 26) jd3333 += 6; else jd3333 = 8;
                    if (iid33 < 28) iid33 += 6; else iid33 = 10;

                    if (((is3 + 1) % 4 == 0) || (((is3 + 1) % 4 != 0) && ind == s - 1))
                    {


                        //pdf التصدير كملف 
                        num++;

                        //العام الدراسي
                        x.Range["AE2"].Value = ((Convert.ToInt16(txt_year_deg.Text) - 1)).ToString();
                        x.Range["AH2"].Value = txt_year_deg.Text;

                        //رقم الصفحة
                        x.Range["AB1"].Value = "/   " + num + "  /" + ":رقم الصفحة";

                        path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
                        if (!System.IO.Directory.Exists(path_excel))
                        {
                            System.IO.Directory.CreateDirectory(path_excel);
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        else
                        {
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                               Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        x.SaveAs(path_excel);
                        x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                        System.Diagnostics.Process.Start(path_excel + ".pdf");
                        //  count = 0;
                        work1.Close();
                        app1.Quit();
                        System.IO.File.Delete(path_excel + ".xlsx");
                        app1 = new Excel.Application();
                        work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
                        x = app1.Sheets[4];
                    }
                }
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");


                this.Cursor = Cursors.Default;
                MessageBox.Show("تم تصدير ملفات السجل الامتحاني بنجاح", "تصدير السجل الامتحاني", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Cursor = Cursors.Default;
            }


        }
        private void exam_record5()
        {
            // التصدير الى السجل السنوي
            try
            {

            string xx = System.IO.Path.GetFullPath("سجل سنوي معلوماتية.xlsx");
            string path2 = System.IO.Path.GetDirectoryName(xx);
            this.Cursor = Cursors.WaitCursor;
            Excel.Application app1 = new Excel.Application();
            Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
            string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
            int y = cmb_year_mat.SelectedIndex;
            int s = dt_exam_rec_p.Rows.Count;
            //int count = 0;
            int num = 0;
            int ind = 0;
            int id33 = 6, jd33 = 7, jd3333 = 8, iid33 = 10, js33 = 5;
            if (y == 4)
            {
                Excel.Worksheet x = app1.Sheets[5];

                //  x.Range["AL2"].Value = txtid.Text;
                x.Range["C5"].Value = dt_exam_rec_p.Rows[0].Cells[1].Value.ToString();
                x.Range["D5"].Value = dt_exam_rec_p.Rows[0].Cells[2].Value.ToString();
                x.Range["E5"].Value = dt_exam_rec_p.Rows[0].Cells[0].Value.ToString();

                for (int is3 = 0; is3 < s; is3 += 1)
                {
                    ind = dt_exam_rec_p.Rows[is3].Index;

                    if (is3 != 0)
                    {
                        for (int js3 = js33; js33 < 25; js3 += 6)
                        {
                            x.Range["C" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[1].Value.ToString();
                            x.Range["D" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[2].Value.ToString();
                            x.Range["E" + js3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[0].Value.ToString();
                            break;
                        }
                    }
                    //}
                    //علامات العملي
                    for (int id3 = id33; id33 < 25; id3 += 6)
                    {

                        x.Range["I" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[3].Value.ToString();
                        x.Range["K" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[4].Value.ToString();
                        x.Range["G" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[5].Value.ToString();
                        x.Range["H" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[6].Value.ToString();
                        x.Range["J" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[7].Value.ToString();
                        x.Range["Q" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[8].Value.ToString();
                        x.Range["N" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[9].Value.ToString();
                        x.Range["O" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[10].Value.ToString();
                        x.Range["P" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[11].Value.ToString();
                        x.Range["R" + id3.ToString()].Value = dt_exam_rec_p.Rows[is3].Cells[12].Value.ToString();
                        break;
                    }

                    //علامات النظري
                    //دورة 1

                    for (int jd3 = jd33; jd33 < 26; jd3 += 6)
                    {
                        x.Range["I" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[3].Value.ToString();
                        x.Range["K" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[4].Value.ToString();
                        x.Range["G" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[5].Value.ToString();
                        x.Range["H" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[6].Value.ToString();
                        x.Range["J" + jd3.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[7].Value.ToString();
                        break;
                    }
                    //دورة 2

                    for (int jd333 = jd3333; jd3333 < 27; jd333 += 6)
                    {
                        x.Range["N" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[9].Value.ToString();
                        x.Range["O" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[10].Value.ToString();
                        x.Range["P" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[11].Value.ToString();
                        x.Range["R" + jd333.ToString()].Value = dt_exam_rec_t.Rows[is3].Cells[12].Value.ToString();
                        break;

                    }

                    //مجموع
                    for (int iid3 = iid33; iid33 < 29; iid3 += 6)
                    {

                        x.Range["I" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[3].Value.ToString();
                        x.Range["K" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[4].Value.ToString();
                        x.Range["G" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[5].Value.ToString();
                        x.Range["H" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[6].Value.ToString();
                        x.Range["J" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[7].Value.ToString();
                        x.Range["Q" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[8].Value.ToString();
                        x.Range["N" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[9].Value.ToString();
                        x.Range["O" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[10].Value.ToString();
                        x.Range["P" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[11].Value.ToString();
                        x.Range["R" + iid3.ToString()].Value = dt_exam_rec_f.Rows[is3].Cells[12].Value.ToString();
                        break;

                    }
                    if (js33 < 23) js33 += 6; else js33 = 5;
                    if (id33 < 24) id33 += 6; else id33 = 6;
                    if (jd33 < 25) jd33 += 6; else jd33 = 7;
                    if (jd3333 < 26) jd3333 += 6; else jd3333 = 8;
                    if (iid33 < 28) iid33 += 6; else iid33 = 10;

                    if (((is3 + 1) % 4 == 0) || (((is3 + 1) % 4 != 0) && ind == s - 1))
                    {

                        //pdf التصدير كملف 
                        num++;

                        //العام الدراسي
                        x.Range["AE2"].Value = ((Convert.ToInt16(txt_year_deg.Text) - 1)).ToString();
                        x.Range["AH2"].Value = txt_year_deg.Text;


                        //رقم الصفحة
                        x.Range["AB1"].Value = "/   " + num + "  /" + ":رقم الصفحة";

                        path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                     Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\");
                        if (!System.IO.Directory.Exists(path_excel))
                        {
                            System.IO.Directory.CreateDirectory(path_excel);
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        else
                        {
                            path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                               Environment.SpecialFolder.MyDocuments), "أرشيف السجل السنوي\\" + "أرشيف س" + (y + 1) + " رقم" + num);
                        }
                        x.SaveAs(path_excel);
                        x.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                        System.Diagnostics.Process.Start(path_excel + ".pdf");
                        //  count = 0;
                        work1.Close();
                        app1.Quit();
                        System.IO.File.Delete(path_excel + ".xlsx");
                        app1 = new Excel.Application();
                        work1 = app1.Workbooks.Open(path2 + @"\سجل سنوي معلوماتية.xlsx");
                        x = app1.Sheets[5];
                    }
                }
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");

                this.Cursor = Cursors.Default;
                MessageBox.Show("تم تصدير ملفات السجل الامتحاني بنجاح", "تصدير السجل الامتحاني", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Cursor = Cursors.Default;
            }


        }


        private void export_rec_Click(object sender, EventArgs e)
        {
            int y = cmb_year_mat.SelectedIndex;
            if (y == 0) { exam_record1(); }
            if (y == 1) { exam_record2(); }
            if (y == 2) { exam_record3(); }
            if (y == 3) { exam_record4(); }
            if (y == 4) { exam_record5(); }
        }

        private void button6_MouseMove_1(object sender, MouseEventArgs e)
        {
            failon();
        }

        private void button6_MouseLeave_1(object sender, EventArgs e)
        {
            failoff();
        }

        private void كشفالعلاماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (button9.Enabled == true)
            {
                button9_Click(sender, e);
            }
        }

        private void صحيفةالطالبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (button8.Enabled == true)
            {
                button8_Click(sender, e);
            }
        }

        private void السجلالامتحانيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_exam_record_Click(sender, e);
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button7_Click(sender,e);
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_top10_Click(sender, e);
        }

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(sender,e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            button4_Click(sender,e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (export == "final")
            {
                   degree_final(f, y, m, n, s, ty);              
            }
            else if (export == "partical")
            {
                degree_particla(f, y, m, n, s, ty);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lb_pp.Text = e.ProgressPercentage.ToString();
        }

        private void txt_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_year_deg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PL.FRM_MAIN.getMainForm.panelleft.Enabled = true;
           // dataGridView_mat_year.DataSource = null;
            progressBar1.Value = 0;
            lb_pp.Text = null;
            progressBar1.Visible = false;
            lb_pp.Visible = false;
            this.Enabled = true;
        }

        private void txt_year_TextChanged_1(object sender, EventArgs e)
        {
            export_mat_lot();
        }

        void exam_statistics()
        {
            if (cmb_std.SelectedIndex == 0 && txtmat.Text != "")
            {
                dt_takers.DataSource = cost.exam_takers(txtmat.Text, Convert.ToInt16(txt_year.Text));
                dt_succ.DataSource = cost.success_num(txtmat.Text, Convert.ToInt16(txt_year.Text));
                dt_fail.DataSource = cost.fail_num(txtmat.Text, Convert.ToInt16(txt_year.Text));
            }
            txt_takers.Text = dt_takers.CurrentRow.Cells[0].Value.ToString();
            txt_succ_num.Text = dt_succ.CurrentRow.Cells[0].Value.ToString();
            txt_fail_num.Text = dt_fail.CurrentRow.Cells[0].Value.ToString();
            double s = Convert.ToDouble(txt_succ_num.Text);
            double f = Convert.ToDouble(txt_fail_num.Text);
            double t = Convert.ToDouble(txt_takers.Text);
            txt_succ_rate.Text = (Math.Round(((s / t) * 100), 2)).ToString() + "%";
            txt_fail_rate.Text = (Math.Round(((f / t) * 100), 2)).ToString() + "%";

        }

        void clear_statistics()
        {
            txt_takers.Clear();
            txt_succ_num.Clear();
            txt_fail_num.Clear();
            txt_succ_rate.Clear();
            txt_fail_rate.Clear();
        }

        public void export_top10()
        {
            try
            {
                string rr = System.IO.Path.GetFullPath("الطلاب الأوائل.xlsx");
                string path2 = System.IO.Path.GetDirectoryName(rr);
                this.Cursor = Cursors.WaitCursor;
                Excel.Application app1 = new Excel.Application();
                Excel.Workbook work1 = app1.Workbooks.Open(path2 + @"\الطلاب الأوائل.xlsx");
                Excel.Worksheet r = app1.Sheets[1];
                string year;
                if (txt_top10.Text=="6")  year = "السادسة";
                else if (txt_top10.Text == "5") year = "الخامسة";
                else if (txt_top10.Text == "4") year = "الرابعة";
                else if (txt_top10.Text == "3") year = "الثالثة";
                else if (txt_top10.Text == "2") year = "الثانية";
                else year = "الأولى";
                r.Range["A1"].Value += " " + year; 

                for (int i = 0, j = 3; i < dataGridView_top10.RowCount; i++, j++)
                {

                    r.Range["A" + j.ToString()].Value = dataGridView_top10.Rows[i].Cells[2].Value;
                    r.Range["B" + j.ToString()].Value = dataGridView_top10.Rows[i].Cells[1].Value;
                    r.Range["C" + j.ToString()].Value = dataGridView_top10.Rows[i].Cells[0].Value;
                }



                string path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
              Environment.SpecialFolder.MyDocuments), "أرشيف\\");
                if (!System.IO.Directory.Exists(path_excel))
                {
                    System.IO.Directory.CreateDirectory(path_excel);
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + " الطلاب الأوائل س" + " " + txt_top10.Text);
                }
                else
                {
                    path_excel = System.IO.Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments), "أرشيف\\" + " الطلاب الأوائل س" + " " + txt_top10.Text);
                }

                r.SaveAs(path_excel);
                r.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path_excel);
                   this.Cursor = Cursors.Default;
                System.Diagnostics.Process.Start(path_excel + ".pdf");
                work1.Close();
                app1.Quit();
                System.IO.File.Delete(path_excel + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {

            export_top10();
        }

        private void cmb_fac_SelectedIndexChanged(object sender, EventArgs e)
        {
            export_exam_rec_n();

        }
    }
}