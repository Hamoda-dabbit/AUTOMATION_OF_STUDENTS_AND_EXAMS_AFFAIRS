namespace AleppoFreeUniversity.UserControls
{
    partial class US_USER
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
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_newUsername = new System.Windows.Forms.Label();
            this.txt_newUsername = new System.Windows.Forms.TextBox();
            this.cmbrole = new System.Windows.Forms.ComboBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblrole = new System.Windows.Forms.Label();
            this.lbl_conPass = new System.Windows.Forms.Label();
            this.lblpass = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txt_conPass = new System.Windows.Forms.TextBox();
            this.lbl_oldUsername = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txt_oldUsername = new System.Windows.Forms.TextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btn_adduser = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(50, 21);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.Size = new System.Drawing.Size(772, 313);
            this.dataGridViewUser.TabIndex = 0;
            this.dataGridViewUser.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUser_RowHeaderMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.dataGridViewUser);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(139, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(858, 355);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لائحة المستخدمين:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_newUsername);
            this.panel1.Controls.Add(this.txt_newUsername);
            this.panel1.Controls.Add(this.cmbrole);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.lblrole);
            this.panel1.Controls.Add(this.lbl_conPass);
            this.panel1.Controls.Add(this.lblpass);
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Controls.Add(this.txt_conPass);
            this.panel1.Controls.Add(this.lbl_oldUsername);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.txtpass);
            this.panel1.Controls.Add(this.txt_oldUsername);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.panel1.Location = new System.Drawing.Point(51, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 311);
            this.panel1.TabIndex = 171;
            this.panel1.Visible = false;
            // 
            // lbl_newUsername
            // 
            this.lbl_newUsername.AutoSize = true;
            this.lbl_newUsername.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_newUsername.Location = new System.Drawing.Point(589, 74);
            this.lbl_newUsername.Name = "lbl_newUsername";
            this.lbl_newUsername.Size = new System.Drawing.Size(158, 17);
            this.lbl_newUsername.TabIndex = 171;
            this.lbl_newUsername.Text = "اسم المستخدم الجديد:";
            this.lbl_newUsername.Visible = false;
            // 
            // txt_newUsername
            // 
            this.txt_newUsername.Location = new System.Drawing.Point(405, 74);
            this.txt_newUsername.Name = "txt_newUsername";
            this.txt_newUsername.Size = new System.Drawing.Size(175, 22);
            this.txt_newUsername.TabIndex = 3;
            this.txt_newUsername.Tag = "0";
            this.txt_newUsername.Visible = false;
            // 
            // cmbrole
            // 
            this.cmbrole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbrole.FormattingEnabled = true;
            this.cmbrole.Items.AddRange(new object[] {
            "مدير",
            "عادي"});
            this.cmbrole.Location = new System.Drawing.Point(403, 152);
            this.cmbrole.Name = "cmbrole";
            this.cmbrole.Size = new System.Drawing.Size(175, 22);
            this.cmbrole.TabIndex = 6;
            this.cmbrole.Tag = "4";
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(212, 205);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(120, 39);
            this.btncancel.TabIndex = 8;
            this.btncancel.Tag = "6";
            this.btncancel.Text = "إلغاء";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(387, 205);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 39);
            this.button4.TabIndex = 7;
            this.button4.Tag = "5";
            this.button4.Text = "إضافة";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblrole
            // 
            this.lblrole.AutoSize = true;
            this.lblrole.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrole.Location = new System.Drawing.Point(586, 154);
            this.lblrole.Name = "lblrole";
            this.lblrole.Size = new System.Drawing.Size(105, 17);
            this.lblrole.TabIndex = 17;
            this.lblrole.Text = "دور المستخدم:";
            // 
            // lbl_conPass
            // 
            this.lbl_conPass.AutoSize = true;
            this.lbl_conPass.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_conPass.Location = new System.Drawing.Point(257, 109);
            this.lbl_conPass.Name = "lbl_conPass";
            this.lbl_conPass.Size = new System.Drawing.Size(121, 17);
            this.lbl_conPass.TabIndex = 17;
            this.lbl_conPass.Text = "تأكيد كلمة المرور:";
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpass.Location = new System.Drawing.Point(589, 107);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(86, 17);
            this.lblpass.TabIndex = 17;
            this.lblpass.Text = "كلمة المرور:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(258, 44);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(103, 17);
            this.lblname.TabIndex = 17;
            this.lblname.Text = "اسم الشخص:";
            // 
            // txt_conPass
            // 
            this.txt_conPass.Location = new System.Drawing.Point(75, 107);
            this.txt_conPass.Name = "txt_conPass";
            this.txt_conPass.PasswordChar = '*';
            this.txt_conPass.Size = new System.Drawing.Size(175, 22);
            this.txt_conPass.TabIndex = 5;
            this.txt_conPass.Tag = "3";
            this.txt_conPass.Validated += new System.EventHandler(this.txt_conPass_Validated);
            // 
            // lbl_oldUsername
            // 
            this.lbl_oldUsername.AutoSize = true;
            this.lbl_oldUsername.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_oldUsername.Location = new System.Drawing.Point(590, 44);
            this.lbl_oldUsername.Name = "lbl_oldUsername";
            this.lbl_oldUsername.Size = new System.Drawing.Size(157, 17);
            this.lbl_oldUsername.TabIndex = 17;
            this.lbl_oldUsername.Text = "اسم المستخدم القديم:";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(75, 44);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(175, 22);
            this.txtname.TabIndex = 1;
            this.txtname.Tag = "1";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(405, 107);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(175, 22);
            this.txtpass.TabIndex = 4;
            this.txtpass.Tag = "2";
            // 
            // txt_oldUsername
            // 
            this.txt_oldUsername.Location = new System.Drawing.Point(405, 44);
            this.txt_oldUsername.Name = "txt_oldUsername";
            this.txt_oldUsername.Size = new System.Drawing.Size(175, 22);
            this.txt_oldUsername.TabIndex = 0;
            this.txt_oldUsername.Tag = "0";
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnedit.FlatAppearance.BorderSize = 0;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(497, 417);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(198, 39);
            this.btnedit.TabIndex = 1;
            this.btnedit.Text = "تعديل المستخدم المحدد";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btn_adduser
            // 
            this.btn_adduser.BackColor = System.Drawing.Color.Crimson;
            this.btn_adduser.FlatAppearance.BorderSize = 0;
            this.btn_adduser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adduser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adduser.ForeColor = System.Drawing.Color.White;
            this.btn_adduser.Location = new System.Drawing.Point(716, 417);
            this.btn_adduser.Name = "btn_adduser";
            this.btn_adduser.Size = new System.Drawing.Size(198, 39);
            this.btn_adduser.TabIndex = 0;
            this.btn_adduser.Text = "إضافة مستخدم";
            this.btn_adduser.UseVisualStyleBackColor = false;
            this.btn_adduser.Click += new System.EventHandler(this.btn_adduser_Click);
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.DeepPink;
            this.btndel.FlatAppearance.BorderSize = 0;
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.Location = new System.Drawing.Point(280, 417);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(198, 39);
            this.btndel.TabIndex = 2;
            this.btndel.Text = "حذف المستخدم المحدد";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // US_USER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btn_adduser);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "US_USER";
            this.Size = new System.Drawing.Size(1025, 505);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnedit;
        public System.Windows.Forms.Button btn_adduser;
        public System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lbl_oldUsername;
        public System.Windows.Forms.TextBox txt_oldUsername;
        private System.Windows.Forms.Label lbl_conPass;
        private System.Windows.Forms.Label lblname;
        public System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.TextBox txtpass;
        public System.Windows.Forms.TextBox txt_conPass;
        private System.Windows.Forms.Label lblrole;
        private System.Windows.Forms.ComboBox cmbrole;
        public System.Windows.Forms.Button btncancel;
        public System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_newUsername;
        public System.Windows.Forms.TextBox txt_newUsername;

    }
}
