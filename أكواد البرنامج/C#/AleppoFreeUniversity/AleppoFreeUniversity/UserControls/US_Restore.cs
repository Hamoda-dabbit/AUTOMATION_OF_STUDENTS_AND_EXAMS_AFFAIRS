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
    public partial class US_Restore : UserControl
    {
      //  BL.Cls_student std = new BL.Cls_student();
      //  BL.Cls_degree dg = new BL.Cls_degree();
        BL.ClsLogin log = new BL.ClsLogin();
        public US_Restore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bakup|*bak";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_Restore.Text = openFileDialog1.FileName;
            }
        }

        private void Btn_Restore_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Restore.Text == "")
                {
                    MessageBox.Show("يرجى اختيار مكان تواجد النسخة الاحتياطية أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    log.Restore_database(txt_Restore.Text);
                    MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح", "استعادة النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Restore.Clear();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {

                // 

                //if (ex.Message == "Cannot open backup device 'C:\\Users\\albayan\\Documents\\أرشيف\\ملفات قاعدة البيا'. Operating system error 2(The system cannot find the file specified.).\r\nRESTORE DATABASE is terminating abnormally.")
                //{
                    // MessageBox.Show(ex.Message);
                    string filename = "C:\\backup\\AleppoFreeUniversity.bak";
                    if (!File.Exists("C:\\backup"))
                    {
                        Directory.CreateDirectory("C:\\backup");
                    }
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                    File.Copy(txt_Restore.Text, filename);
                    log.Restore_database(filename);
                    File.Delete(filename);
                    MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح", "استعادة النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Restore.Clear();
                    this.Cursor = Cursors.Default;
                //}
                //else
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }
    }
}