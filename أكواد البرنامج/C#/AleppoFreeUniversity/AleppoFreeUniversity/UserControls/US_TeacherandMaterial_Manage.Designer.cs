namespace AleppoFreeUniversity.UserControls
{
    partial class US_TeacherandMaterial_Manage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_material = new System.Windows.Forms.Button();
            this.btn_teacher = new System.Windows.Forms.Button();
            this.panel_teach = new System.Windows.Forms.Panel();
            this.dt_teach = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_can_t = new System.Windows.Forms.Button();
            this.btn_add_t = new System.Windows.Forms.Button();
            this.cmbscien_rank = new System.Windows.Forms.ComboBox();
            this.txt_teachid = new System.Windows.Forms.TextBox();
            this.lbl_teachid = new System.Windows.Forms.Label();
            this.txt_num_mat = new System.Windows.Forms.TextBox();
            this.lblnum_mat = new System.Windows.Forms.Label();
            this.lblscien_rank = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_serch = new System.Windows.Forms.TextBox();
            this.panel_material = new System.Windows.Forms.Panel();
            this.dt_material = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_can_m = new System.Windows.Forms.Button();
            this.btn_add_m = new System.Windows.Forms.Button();
            this.cmb_matyear = new System.Windows.Forms.ComboBox();
            this.cmb_season = new System.Windows.Forms.ComboBox();
            this.cmb_faculty = new System.Windows.Forms.ComboBox();
            this.txt_matid = new System.Windows.Forms.TextBox();
            this.lbl_matid = new System.Windows.Forms.Label();
            this.lbl_matyear = new System.Windows.Forms.Label();
            this.lbl_season = new System.Windows.Forms.Label();
            this.lbl_faculty = new System.Windows.Forms.Label();
            this.lbl_matname = new System.Windows.Forms.Label();
            this.txt_matname = new System.Windows.Forms.TextBox();
            this.btn_editmat = new System.Windows.Forms.Button();
            this.btn_addmat = new System.Windows.Forms.Button();
            this.btn_delmat = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ادارةالموادToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالمدرسينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel_teach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_teach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel_material.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_material)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.btn_material);
            this.panel1.Controls.Add(this.btn_teacher);
            this.panel1.Location = new System.Drawing.Point(640, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 51);
            this.panel1.TabIndex = 206;
            // 
            // btn_material
            // 
            this.btn_material.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_material.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_material.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_material.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_material.Location = new System.Drawing.Point(225, 6);
            this.btn_material.Name = "btn_material";
            this.btn_material.Size = new System.Drawing.Size(125, 42);
            this.btn_material.TabIndex = 201;
            this.btn_material.Text = "إدراة المواد";
            this.btn_material.UseVisualStyleBackColor = false;
            this.btn_material.Click += new System.EventHandler(this.btn_material_Click);
            // 
            // btn_teacher
            // 
            this.btn_teacher.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_teacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_teacher.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_teacher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_teacher.Location = new System.Drawing.Point(81, 6);
            this.btn_teacher.Name = "btn_teacher";
            this.btn_teacher.Size = new System.Drawing.Size(125, 42);
            this.btn_teacher.TabIndex = 200;
            this.btn_teacher.Text = "إدارة المدرسين";
            this.btn_teacher.UseVisualStyleBackColor = false;
            this.btn_teacher.Click += new System.EventHandler(this.btn_teacher_Click);
            // 
            // panel_teach
            // 
            this.panel_teach.Controls.Add(this.dt_teach);
            this.panel_teach.Controls.Add(this.groupBox1);
            this.panel_teach.Controls.Add(this.btnedit);
            this.panel_teach.Controls.Add(this.btnadd);
            this.panel_teach.Controls.Add(this.btndel);
            this.panel_teach.Location = new System.Drawing.Point(64, 34);
            this.panel_teach.Name = "panel_teach";
            this.panel_teach.Size = new System.Drawing.Size(40, 35);
            this.panel_teach.TabIndex = 208;
            this.panel_teach.Visible = false;
            // 
            // dt_teach
            // 
            this.dt_teach.AllowUserToAddRows = false;
            this.dt_teach.AllowUserToDeleteRows = false;
            this.dt_teach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_teach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_teach.Location = new System.Drawing.Point(35, 223);
            this.dt_teach.Name = "dt_teach";
            this.dt_teach.ReadOnly = true;
            this.dt_teach.Size = new System.Drawing.Size(40, 45);
            this.dt_teach.TabIndex = 207;
            this.dt_teach.Visible = false;
            this.dt_teach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_teach_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_can_t);
            this.groupBox1.Controls.Add(this.btn_add_t);
            this.groupBox1.Controls.Add(this.cmbscien_rank);
            this.groupBox1.Controls.Add(this.txt_teachid);
            this.groupBox1.Controls.Add(this.lbl_teachid);
            this.groupBox1.Controls.Add(this.txt_num_mat);
            this.groupBox1.Controls.Add(this.lblnum_mat);
            this.groupBox1.Controls.Add(this.lblscien_rank);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(18, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 195);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات المدرس";
            // 
            // btn_can_t
            // 
            this.btn_can_t.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_can_t.BackColor = System.Drawing.Color.Peru;
            this.btn_can_t.FlatAppearance.BorderSize = 0;
            this.btn_can_t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_can_t.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_can_t.ForeColor = System.Drawing.Color.White;
            this.btn_can_t.Location = new System.Drawing.Point(233, 137);
            this.btn_can_t.Name = "btn_can_t";
            this.btn_can_t.Size = new System.Drawing.Size(99, 40);
            this.btn_can_t.TabIndex = 5;
            this.btn_can_t.Text = "إلغاء";
            this.btn_can_t.UseVisualStyleBackColor = false;
            this.btn_can_t.Click += new System.EventHandler(this.btn_can_t_Click);
            // 
            // btn_add_t
            // 
            this.btn_add_t.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_t.BackColor = System.Drawing.Color.DimGray;
            this.btn_add_t.FlatAppearance.BorderSize = 0;
            this.btn_add_t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_t.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_t.ForeColor = System.Drawing.Color.White;
            this.btn_add_t.Location = new System.Drawing.Point(367, 137);
            this.btn_add_t.Name = "btn_add_t";
            this.btn_add_t.Size = new System.Drawing.Size(99, 40);
            this.btn_add_t.TabIndex = 4;
            this.btn_add_t.Text = "إضافة";
            this.btn_add_t.UseVisualStyleBackColor = false;
            this.btn_add_t.Click += new System.EventHandler(this.btn_add_t_Click);
            // 
            // cmbscien_rank
            // 
            this.cmbscien_rank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbscien_rank.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbscien_rank.FormattingEnabled = true;
            this.cmbscien_rank.Items.AddRange(new object[] {
            "مدرس",
            "معيد",
            "ماجستير",
            "دكتوراة",
            "أستاذ دكتور"});
            this.cmbscien_rank.Location = new System.Drawing.Point(405, 84);
            this.cmbscien_rank.Name = "cmbscien_rank";
            this.cmbscien_rank.Size = new System.Drawing.Size(208, 24);
            this.cmbscien_rank.TabIndex = 2;
            // 
            // txt_teachid
            // 
            this.txt_teachid.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txt_teachid.Location = new System.Drawing.Point(405, 36);
            this.txt_teachid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_teachid.Multiline = true;
            this.txt_teachid.Name = "txt_teachid";
            this.txt_teachid.Size = new System.Drawing.Size(208, 32);
            this.txt_teachid.TabIndex = 0;
            this.txt_teachid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_teachid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_teachid_KeyPress);
            // 
            // lbl_teachid
            // 
            this.lbl_teachid.AutoSize = true;
            this.lbl_teachid.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_teachid.ForeColor = System.Drawing.Color.Black;
            this.lbl_teachid.Location = new System.Drawing.Point(629, 39);
            this.lbl_teachid.Name = "lbl_teachid";
            this.lbl_teachid.Size = new System.Drawing.Size(89, 22);
            this.lbl_teachid.TabIndex = 181;
            this.lbl_teachid.Text = "رقم المدرس:";
            // 
            // txt_num_mat
            // 
            this.txt_num_mat.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txt_num_mat.Location = new System.Drawing.Point(16, 80);
            this.txt_num_mat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_num_mat.Multiline = true;
            this.txt_num_mat.Name = "txt_num_mat";
            this.txt_num_mat.Size = new System.Drawing.Size(208, 32);
            this.txt_num_mat.TabIndex = 3;
            this.txt_num_mat.Text = "0";
            this.txt_num_mat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblnum_mat
            // 
            this.lblnum_mat.AutoSize = true;
            this.lblnum_mat.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblnum_mat.ForeColor = System.Drawing.Color.Black;
            this.lblnum_mat.Location = new System.Drawing.Point(239, 83);
            this.lblnum_mat.Name = "lblnum_mat";
            this.lblnum_mat.Size = new System.Drawing.Size(125, 22);
            this.lblnum_mat.TabIndex = 173;
            this.lblnum_mat.Text = "عدد مواد المدرس:";
            // 
            // lblscien_rank
            // 
            this.lblscien_rank.AutoSize = true;
            this.lblscien_rank.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblscien_rank.ForeColor = System.Drawing.Color.Black;
            this.lblscien_rank.Location = new System.Drawing.Point(629, 83);
            this.lblscien_rank.Name = "lblscien_rank";
            this.lblscien_rank.Size = new System.Drawing.Size(94, 22);
            this.lblscien_rank.TabIndex = 173;
            this.lblscien_rank.Text = "الرتبة العلمية:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblname.ForeColor = System.Drawing.Color.Black;
            this.lblname.Location = new System.Drawing.Point(241, 36);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(91, 22);
            this.lblname.TabIndex = 175;
            this.lblname.Text = "اسم المدرس:";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txtname.Location = new System.Drawing.Point(16, 33);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(208, 32);
            this.txtname.TabIndex = 1;
            this.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.Blue;
            this.btnedit.FlatAppearance.BorderSize = 0;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(339, 224);
            this.btnedit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(145, 44);
            this.btnedit.TabIndex = 7;
            this.btnedit.Text = "تعديل بيانات مدرس";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Crimson;
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(507, 225);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(125, 43);
            this.btnadd.TabIndex = 6;
            this.btnadd.Text = "إضافة مدرس";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.Orange;
            this.btndel.FlatAppearance.BorderSize = 0;
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.Location = new System.Drawing.Point(195, 223);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(125, 45);
            this.btndel.TabIndex = 8;
            this.btndel.Text = "حذف مدرس";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(461, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 19);
            this.label3.TabIndex = 196;
            this.label3.Text = "البحث حسب الرقم أو الاسم:";
            this.label3.Visible = false;
            // 
            // txt_serch
            // 
            this.txt_serch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txt_serch.Location = new System.Drawing.Point(298, 34);
            this.txt_serch.Multiline = true;
            this.txt_serch.Name = "txt_serch";
            this.txt_serch.Size = new System.Drawing.Size(157, 26);
            this.txt_serch.TabIndex = 195;
            this.txt_serch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_serch.Visible = false;
            this.txt_serch.TextChanged += new System.EventHandler(this.txt_serch_TextChanged);
            // 
            // panel_material
            // 
            this.panel_material.Controls.Add(this.dt_material);
            this.panel_material.Controls.Add(this.groupBox2);
            this.panel_material.Controls.Add(this.btn_editmat);
            this.panel_material.Controls.Add(this.btn_addmat);
            this.panel_material.Controls.Add(this.btn_delmat);
            this.panel_material.Location = new System.Drawing.Point(225, 42);
            this.panel_material.Name = "panel_material";
            this.panel_material.Size = new System.Drawing.Size(720, 375);
            this.panel_material.TabIndex = 210;
            this.panel_material.Visible = false;
            // 
            // dt_material
            // 
            this.dt_material.AllowUserToAddRows = false;
            this.dt_material.AllowUserToDeleteRows = false;
            this.dt_material.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_material.Location = new System.Drawing.Point(34, 247);
            this.dt_material.Name = "dt_material";
            this.dt_material.ReadOnly = true;
            this.dt_material.Size = new System.Drawing.Size(40, 45);
            this.dt_material.TabIndex = 207;
            this.dt_material.Visible = false;
            this.dt_material.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_material_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_can_m);
            this.groupBox2.Controls.Add(this.btn_add_m);
            this.groupBox2.Controls.Add(this.cmb_matyear);
            this.groupBox2.Controls.Add(this.cmb_season);
            this.groupBox2.Controls.Add(this.cmb_faculty);
            this.groupBox2.Controls.Add(this.txt_matid);
            this.groupBox2.Controls.Add(this.lbl_matid);
            this.groupBox2.Controls.Add(this.lbl_matyear);
            this.groupBox2.Controls.Add(this.lbl_season);
            this.groupBox2.Controls.Add(this.lbl_faculty);
            this.groupBox2.Controls.Add(this.lbl_matname);
            this.groupBox2.Controls.Add(this.txt_matname);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(18, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 220);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بيانات المادة:";
            // 
            // btn_can_m
            // 
            this.btn_can_m.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_can_m.BackColor = System.Drawing.Color.Peru;
            this.btn_can_m.FlatAppearance.BorderSize = 0;
            this.btn_can_m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_can_m.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_can_m.ForeColor = System.Drawing.Color.White;
            this.btn_can_m.Location = new System.Drawing.Point(209, 163);
            this.btn_can_m.Name = "btn_can_m";
            this.btn_can_m.Size = new System.Drawing.Size(99, 40);
            this.btn_can_m.TabIndex = 6;
            this.btn_can_m.Text = "إلغاء";
            this.btn_can_m.UseVisualStyleBackColor = false;
            this.btn_can_m.Click += new System.EventHandler(this.btn_can_m_Click_1);
            // 
            // btn_add_m
            // 
            this.btn_add_m.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add_m.BackColor = System.Drawing.Color.DimGray;
            this.btn_add_m.FlatAppearance.BorderSize = 0;
            this.btn_add_m.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_m.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_m.ForeColor = System.Drawing.Color.White;
            this.btn_add_m.Location = new System.Drawing.Point(355, 163);
            this.btn_add_m.Name = "btn_add_m";
            this.btn_add_m.Size = new System.Drawing.Size(99, 40);
            this.btn_add_m.TabIndex = 5;
            this.btn_add_m.Text = "إضافة";
            this.btn_add_m.UseVisualStyleBackColor = false;
            this.btn_add_m.Click += new System.EventHandler(this.btn_add_m_Click);
            // 
            // cmb_matyear
            // 
            this.cmb_matyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_matyear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_matyear.FormattingEnabled = true;
            this.cmb_matyear.Items.AddRange(new object[] {
            "الأولى",
            "الثانية",
            "الثالثة",
            "الرابعة",
            "الخامسة",
            "السادسة"});
            this.cmb_matyear.Location = new System.Drawing.Point(17, 81);
            this.cmb_matyear.Name = "cmb_matyear";
            this.cmb_matyear.Size = new System.Drawing.Size(208, 24);
            this.cmb_matyear.TabIndex = 3;
            // 
            // cmb_season
            // 
            this.cmb_season.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_season.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_season.FormattingEnabled = true;
            this.cmb_season.Items.AddRange(new object[] {
            "الفصل الأول",
            "الفصل الثاني"});
            this.cmb_season.Location = new System.Drawing.Point(378, 123);
            this.cmb_season.Name = "cmb_season";
            this.cmb_season.Size = new System.Drawing.Size(208, 24);
            this.cmb_season.TabIndex = 4;
            // 
            // cmb_faculty
            // 
            this.cmb_faculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_faculty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_faculty.FormattingEnabled = true;
            this.cmb_faculty.Items.AddRange(new object[] {
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
            this.cmb_faculty.Location = new System.Drawing.Point(378, 80);
            this.cmb_faculty.Name = "cmb_faculty";
            this.cmb_faculty.Size = new System.Drawing.Size(208, 24);
            this.cmb_faculty.TabIndex = 2;
            // 
            // txt_matid
            // 
            this.txt_matid.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txt_matid.Location = new System.Drawing.Point(378, 36);
            this.txt_matid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_matid.Multiline = true;
            this.txt_matid.Name = "txt_matid";
            this.txt_matid.Size = new System.Drawing.Size(208, 29);
            this.txt_matid.TabIndex = 0;
            this.txt_matid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_matid
            // 
            this.lbl_matid.AutoSize = true;
            this.lbl_matid.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_matid.ForeColor = System.Drawing.Color.Black;
            this.lbl_matid.Location = new System.Drawing.Point(594, 39);
            this.lbl_matid.Name = "lbl_matid";
            this.lbl_matid.Size = new System.Drawing.Size(78, 22);
            this.lbl_matid.TabIndex = 181;
            this.lbl_matid.Text = "رمز المادة:";
            // 
            // lbl_matyear
            // 
            this.lbl_matyear.AutoSize = true;
            this.lbl_matyear.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_matyear.ForeColor = System.Drawing.Color.Black;
            this.lbl_matyear.Location = new System.Drawing.Point(232, 83);
            this.lbl_matyear.Name = "lbl_matyear";
            this.lbl_matyear.Size = new System.Drawing.Size(79, 22);
            this.lbl_matyear.TabIndex = 173;
            this.lbl_matyear.Text = "سنة المادة:";
            // 
            // lbl_season
            // 
            this.lbl_season.AutoSize = true;
            this.lbl_season.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_season.ForeColor = System.Drawing.Color.Black;
            this.lbl_season.Location = new System.Drawing.Point(592, 123);
            this.lbl_season.Name = "lbl_season";
            this.lbl_season.Size = new System.Drawing.Size(147, 22);
            this.lbl_season.TabIndex = 173;
            this.lbl_season.Text = "الفصل الدراسي للمادة:";
            // 
            // lbl_faculty
            // 
            this.lbl_faculty.AutoSize = true;
            this.lbl_faculty.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_faculty.ForeColor = System.Drawing.Color.Black;
            this.lbl_faculty.Location = new System.Drawing.Point(594, 84);
            this.lbl_faculty.Name = "lbl_faculty";
            this.lbl_faculty.Size = new System.Drawing.Size(47, 22);
            this.lbl_faculty.TabIndex = 173;
            this.lbl_faculty.Text = "الكلية:";
            // 
            // lbl_matname
            // 
            this.lbl_matname.AutoSize = true;
            this.lbl_matname.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_matname.ForeColor = System.Drawing.Color.Black;
            this.lbl_matname.Location = new System.Drawing.Point(234, 36);
            this.lbl_matname.Name = "lbl_matname";
            this.lbl_matname.Size = new System.Drawing.Size(77, 22);
            this.lbl_matname.TabIndex = 175;
            this.lbl_matname.Text = "اسم المادة:";
            // 
            // txt_matname
            // 
            this.txt_matname.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txt_matname.Location = new System.Drawing.Point(16, 36);
            this.txt_matname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_matname.Multiline = true;
            this.txt_matname.Name = "txt_matname";
            this.txt_matname.Size = new System.Drawing.Size(208, 29);
            this.txt_matname.TabIndex = 1;
            this.txt_matname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_editmat
            // 
            this.btn_editmat.BackColor = System.Drawing.Color.Blue;
            this.btn_editmat.FlatAppearance.BorderSize = 0;
            this.btn_editmat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editmat.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_editmat.ForeColor = System.Drawing.Color.White;
            this.btn_editmat.Location = new System.Drawing.Point(312, 248);
            this.btn_editmat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_editmat.Name = "btn_editmat";
            this.btn_editmat.Size = new System.Drawing.Size(145, 44);
            this.btn_editmat.TabIndex = 8;
            this.btn_editmat.Text = "تعديل بيانات مادة";
            this.btn_editmat.UseVisualStyleBackColor = false;
            this.btn_editmat.Click += new System.EventHandler(this.btn_editmat_Click);
            // 
            // btn_addmat
            // 
            this.btn_addmat.BackColor = System.Drawing.Color.Crimson;
            this.btn_addmat.FlatAppearance.BorderSize = 0;
            this.btn_addmat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addmat.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_addmat.ForeColor = System.Drawing.Color.White;
            this.btn_addmat.Location = new System.Drawing.Point(480, 249);
            this.btn_addmat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_addmat.Name = "btn_addmat";
            this.btn_addmat.Size = new System.Drawing.Size(125, 43);
            this.btn_addmat.TabIndex = 7;
            this.btn_addmat.Text = "إضافة مادة";
            this.btn_addmat.UseVisualStyleBackColor = false;
            this.btn_addmat.Click += new System.EventHandler(this.btn_addmat_Click);
            // 
            // btn_delmat
            // 
            this.btn_delmat.BackColor = System.Drawing.Color.Orange;
            this.btn_delmat.FlatAppearance.BorderSize = 0;
            this.btn_delmat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delmat.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.btn_delmat.ForeColor = System.Drawing.Color.White;
            this.btn_delmat.Location = new System.Drawing.Point(168, 247);
            this.btn_delmat.Name = "btn_delmat";
            this.btn_delmat.Size = new System.Drawing.Size(125, 45);
            this.btn_delmat.TabIndex = 9;
            this.btn_delmat.Text = "حذف مادة";
            this.btn_delmat.UseVisualStyleBackColor = false;
            this.btn_delmat.Click += new System.EventHandler(this.btn_delmat_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ادارةالموادToolStripMenuItem,
            this.ادارةالمدرسينToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 211;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // ادارةالموادToolStripMenuItem
            // 
            this.ادارةالموادToolStripMenuItem.Name = "ادارةالموادToolStripMenuItem";
            this.ادارةالموادToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.ادارةالموادToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.ادارةالموادToolStripMenuItem.Text = "ادارة المواد";
            this.ادارةالموادToolStripMenuItem.Click += new System.EventHandler(this.ادارةالموادToolStripMenuItem_Click);
            // 
            // ادارةالمدرسينToolStripMenuItem
            // 
            this.ادارةالمدرسينToolStripMenuItem.Name = "ادارةالمدرسينToolStripMenuItem";
            this.ادارةالمدرسينToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.ادارةالمدرسينToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.ادارةالمدرسينToolStripMenuItem.Text = "ادارة المدرسين";
            this.ادارةالمدرسينToolStripMenuItem.Click += new System.EventHandler(this.ادارةالمدرسينToolStripMenuItem_Click);
            // 
            // US_TeacherandMaterial_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel_material);
            this.Controls.Add(this.txt_serch);
            this.Controls.Add(this.panel_teach);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.3F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "US_TeacherandMaterial_Manage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1302, 664);
            this.Load += new System.EventHandler(this.US_TeacherandMaterial_Manage_Load);
            this.panel1.ResumeLayout(false);
            this.panel_teach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_teach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_material.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_material)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_material;
        private System.Windows.Forms.Button btn_teacher;
        private System.Windows.Forms.Panel panel_teach;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_teachid;
        public System.Windows.Forms.Label lbl_teachid;
        public System.Windows.Forms.TextBox txt_num_mat;
        public System.Windows.Forms.Label lblnum_mat;
        public System.Windows.Forms.Label lblscien_rank;
        public System.Windows.Forms.Label lblname;
        public System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.Button btnedit;
        public System.Windows.Forms.Button btnadd;
        public System.Windows.Forms.Button btndel;
        private System.Windows.Forms.ComboBox cmbscien_rank;
        private System.Windows.Forms.DataGridView dt_teach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_serch;
        public System.Windows.Forms.Button btn_can_t;
        public System.Windows.Forms.Button btn_add_t;
        private System.Windows.Forms.Panel panel_material;
        private System.Windows.Forms.DataGridView dt_material;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btn_can_m;
        private System.Windows.Forms.ComboBox cmb_faculty;
        public System.Windows.Forms.TextBox txt_matid;
        public System.Windows.Forms.Label lbl_matid;
        public System.Windows.Forms.Label lbl_matyear;
        public System.Windows.Forms.Label lbl_faculty;
        public System.Windows.Forms.Label lbl_matname;
        public System.Windows.Forms.TextBox txt_matname;
        public System.Windows.Forms.Button btn_editmat;
        public System.Windows.Forms.Button btn_addmat;
        public System.Windows.Forms.Button btn_delmat;
        private System.Windows.Forms.ComboBox cmb_matyear;
        private System.Windows.Forms.ComboBox cmb_season;
        public System.Windows.Forms.Label lbl_season;
        public System.Windows.Forms.Button btn_add_m;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ادارةالموادToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالمدرسينToolStripMenuItem;
    }
}
