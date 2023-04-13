namespace AleppoFreeUniversity.UserControls
{
    partial class US_Backup
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_list = new System.Windows.Forms.Button();
            this.dataGridViewAll_Std = new System.Windows.Forms.DataGridView();
            this.BtnExport_n = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lb_pp = new System.Windows.Forms.Label();
            this.panel_backup = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_backup = new System.Windows.Forms.TextBox();
            this.btn_list_degrees = new System.Windows.Forms.Button();
            this.btn_list_mat = new System.Windows.Forms.Button();
            this.btn_list_stu_degree = new System.Windows.Forms.Button();
            this.pnl_list_withFaculty = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbfaculty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll_Std)).BeginInit();
            this.panel_backup.SuspendLayout();
            this.pnl_list_withFaculty.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_list
            // 
            this.btn_list.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_list.FlatAppearance.BorderSize = 0;
            this.btn_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_list.ForeColor = System.Drawing.Color.White;
            this.btn_list.Location = new System.Drawing.Point(252, 9);
            this.btn_list.Margin = new System.Windows.Forms.Padding(0);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(125, 42);
            this.btn_list.TabIndex = 197;
            this.btn_list.Text = "قائمة الطلاب";
            this.btn_list.UseVisualStyleBackColor = false;
            this.btn_list.Click += new System.EventHandler(this.btn_list_Click);
            // 
            // dataGridViewAll_Std
            // 
            this.dataGridViewAll_Std.AllowUserToAddRows = false;
            this.dataGridViewAll_Std.AllowUserToDeleteRows = false;
            this.dataGridViewAll_Std.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewAll_Std.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAll_Std.Location = new System.Drawing.Point(40, 114);
            this.dataGridViewAll_Std.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewAll_Std.Name = "dataGridViewAll_Std";
            this.dataGridViewAll_Std.ReadOnly = true;
            this.dataGridViewAll_Std.Size = new System.Drawing.Size(90, 66);
            this.dataGridViewAll_Std.TabIndex = 198;
            this.dataGridViewAll_Std.Visible = false;
            // 
            // BtnExport_n
            // 
            this.BtnExport_n.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BtnExport_n.Enabled = false;
            this.BtnExport_n.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExport_n.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.BtnExport_n.ForeColor = System.Drawing.Color.Black;
            this.BtnExport_n.Location = new System.Drawing.Point(13, 9);
            this.BtnExport_n.Margin = new System.Windows.Forms.Padding(0);
            this.BtnExport_n.Name = "BtnExport_n";
            this.BtnExport_n.Size = new System.Drawing.Size(226, 41);
            this.BtnExport_n.TabIndex = 199;
            this.BtnExport_n.Text = "تصدير البيانات إلى ملف إكسل";
            this.BtnExport_n.UseVisualStyleBackColor = false;
            this.BtnExport_n.Click += new System.EventHandler(this.BtnExport_n_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(226, 526);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(690, 28);
            this.progressBar1.TabIndex = 200;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lb_pp
            // 
            this.lb_pp.AutoSize = true;
            this.lb_pp.Location = new System.Drawing.Point(933, 534);
            this.lb_pp.Margin = new System.Windows.Forms.Padding(0);
            this.lb_pp.Name = "lb_pp";
            this.lb_pp.Size = new System.Drawing.Size(19, 20);
            this.lb_pp.TabIndex = 201;
            this.lb_pp.Text = "..";
            // 
            // panel_backup
            // 
            this.panel_backup.Controls.Add(this.btnBrowse);
            this.panel_backup.Controls.Add(this.btn_Create);
            this.panel_backup.Controls.Add(this.label1);
            this.panel_backup.Controls.Add(this.txt_backup);
            this.panel_backup.Location = new System.Drawing.Point(190, 130);
            this.panel_backup.Margin = new System.Windows.Forms.Padding(0);
            this.panel_backup.Name = "panel_backup";
            this.panel_backup.Size = new System.Drawing.Size(762, 347);
            this.panel_backup.TabIndex = 202;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowse.BackColor = System.Drawing.Color.DarkOrange;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(36, 158);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(63, 34);
            this.btnBrowse.TabIndex = 76;
            this.btnBrowse.Text = "....";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Create.BackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Create.FlatAppearance.BorderSize = 0;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.btn_Create.ForeColor = System.Drawing.Color.White;
            this.btn_Create.Location = new System.Drawing.Point(306, 208);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(173, 54);
            this.btn_Create.TabIndex = 76;
            this.btn_Create.Text = "إنشاء نسخة إحتياطية لقاعدة البيانات";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(258, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(289, 22);
            this.label1.TabIndex = 77;
            this.label1.Text = "رجاءً قم بتحديد مسار حفظ النسخة الاحتياطية:";
            // 
            // txt_backup
            // 
            this.txt_backup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_backup.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txt_backup.Location = new System.Drawing.Point(125, 158);
            this.txt_backup.Margin = new System.Windows.Forms.Padding(0);
            this.txt_backup.Multiline = true;
            this.txt_backup.Name = "txt_backup";
            this.txt_backup.ReadOnly = true;
            this.txt_backup.Size = new System.Drawing.Size(535, 34);
            this.txt_backup.TabIndex = 78;
            // 
            // btn_list_degrees
            // 
            this.btn_list_degrees.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_list_degrees.FlatAppearance.BorderSize = 0;
            this.btn_list_degrees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list_degrees.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_list_degrees.ForeColor = System.Drawing.Color.White;
            this.btn_list_degrees.Location = new System.Drawing.Point(389, 9);
            this.btn_list_degrees.Margin = new System.Windows.Forms.Padding(0);
            this.btn_list_degrees.Name = "btn_list_degrees";
            this.btn_list_degrees.Size = new System.Drawing.Size(125, 42);
            this.btn_list_degrees.TabIndex = 204;
            this.btn_list_degrees.Text = "قائمة الدرجات";
            this.btn_list_degrees.UseVisualStyleBackColor = false;
            this.btn_list_degrees.Click += new System.EventHandler(this.btn_list_degrees_Click);
            // 
            // btn_list_mat
            // 
            this.btn_list_mat.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_list_mat.FlatAppearance.BorderSize = 0;
            this.btn_list_mat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list_mat.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_list_mat.ForeColor = System.Drawing.Color.White;
            this.btn_list_mat.Location = new System.Drawing.Point(9, 9);
            this.btn_list_mat.Margin = new System.Windows.Forms.Padding(0);
            this.btn_list_mat.Name = "btn_list_mat";
            this.btn_list_mat.Size = new System.Drawing.Size(125, 41);
            this.btn_list_mat.TabIndex = 205;
            this.btn_list_mat.Text = "قائمة المواد";
            this.btn_list_mat.UseVisualStyleBackColor = false;
            this.btn_list_mat.Click += new System.EventHandler(this.btn_list_mat_Click);
            // 
            // btn_list_stu_degree
            // 
            this.btn_list_stu_degree.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_list_stu_degree.FlatAppearance.BorderSize = 0;
            this.btn_list_stu_degree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list_stu_degree.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_list_stu_degree.ForeColor = System.Drawing.Color.White;
            this.btn_list_stu_degree.Location = new System.Drawing.Point(143, 9);
            this.btn_list_stu_degree.Margin = new System.Windows.Forms.Padding(0);
            this.btn_list_stu_degree.Name = "btn_list_stu_degree";
            this.btn_list_stu_degree.Size = new System.Drawing.Size(173, 41);
            this.btn_list_stu_degree.TabIndex = 207;
            this.btn_list_stu_degree.Text = "قائمة العلامات والطلاب";
            this.btn_list_stu_degree.UseVisualStyleBackColor = false;
            this.btn_list_stu_degree.Click += new System.EventHandler(this.btn_list_stu_degree_Click);
            // 
            // pnl_list_withFaculty
            // 
            this.pnl_list_withFaculty.Controls.Add(this.label11);
            this.pnl_list_withFaculty.Controls.Add(this.cmbfaculty);
            this.pnl_list_withFaculty.Controls.Add(this.btn_list_stu_degree);
            this.pnl_list_withFaculty.Controls.Add(this.btn_list_mat);
            this.pnl_list_withFaculty.Location = new System.Drawing.Point(520, 0);
            this.pnl_list_withFaculty.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_list_withFaculty.Name = "pnl_list_withFaculty";
            this.pnl_list_withFaculty.Size = new System.Drawing.Size(661, 57);
            this.pnl_list_withFaculty.TabIndex = 209;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(599, 19);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(47, 22);
            this.label11.TabIndex = 188;
            this.label11.Text = "الكلية:";
            // 
            // cmbfaculty
            // 
            this.cmbfaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfaculty.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.cmbfaculty.FormattingEnabled = true;
            this.cmbfaculty.Items.AddRange(new object[] {
            "الطب البشري",
            "طب الاسنان",
            "الصيدلة",
            "الهندسة المعلوماتية",
            "هندسة الميكاترونيك",
            "الهندسة الزراعية",
            "الاقتصاد",
            "الحقوق",
            "العلوم السياسية",
            "التربية",
            "الشريعة",
            "العلوم",
            "الآداب والعلوم الإنسانية",
            "المعهد الطبي",
            "المعهد التقاني للحاسوب",
            "المعهد التقاني لإدارة الأعمال",
            "المعهد التقاني للإعلام"});
            this.cmbfaculty.Location = new System.Drawing.Point(337, 16);
            this.cmbfaculty.Margin = new System.Windows.Forms.Padding(0);
            this.cmbfaculty.Name = "cmbfaculty";
            this.cmbfaculty.Size = new System.Drawing.Size(253, 30);
            this.cmbfaculty.TabIndex = 187;
            this.cmbfaculty.SelectedIndexChanged += new System.EventHandler(this.cmbfaculty_SelectedIndexChanged);
            // 
            // US_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.pnl_list_withFaculty);
            this.Controls.Add(this.btn_list_degrees);
            this.Controls.Add(this.panel_backup);
            this.Controls.Add(this.dataGridViewAll_Std);
            this.Controls.Add(this.lb_pp);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnExport_n);
            this.Controls.Add(this.btn_list);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "US_Backup";
            this.Size = new System.Drawing.Size(1225, 749);
            this.Load += new System.EventHandler(this.US_Backup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll_Std)).EndInit();
            this.panel_backup.ResumeLayout(false);
            this.panel_backup.PerformLayout();
            this.pnl_list_withFaculty.ResumeLayout(false);
            this.pnl_list_withFaculty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Button btn_list;
        private System.Windows.Forms.DataGridView dataGridViewAll_Std;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lb_pp;
        public System.Windows.Forms.Button BtnExport_n;
        private System.Windows.Forms.Panel panel_backup;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_backup;
        public System.Windows.Forms.Button btn_list_degrees;
        public System.Windows.Forms.Button btn_list_mat;
        public System.Windows.Forms.Button btn_list_stu_degree;
        private System.Windows.Forms.Panel pnl_list_withFaculty;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbfaculty;
    }
}
