namespace AleppoFreeUniversity.UserControls
{
    partial class US_Restore
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
            this.txt_Restore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.Btn_Restore = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnl_restor = new System.Windows.Forms.Panel();
            this.pnl_restor.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Restore
            // 
            this.txt_Restore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Restore.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.txt_Restore.Location = new System.Drawing.Point(125, 158);
            this.txt_Restore.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Restore.Multiline = true;
            this.txt_Restore.Name = "txt_Restore";
            this.txt_Restore.ReadOnly = true;
            this.txt_Restore.Size = new System.Drawing.Size(535, 34);
            this.txt_Restore.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(258, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(279, 20);
            this.label1.TabIndex = 81;
            this.label1.Text = "رجاءً قم بتحديد مسار تواجد النسخة الاحتياطية:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(36, 158);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(63, 34);
            this.btnBrowse.TabIndex = 79;
            this.btnBrowse.Text = "....";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Btn_Restore
            // 
            this.Btn_Restore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Restore.BackColor = System.Drawing.Color.Purple;
            this.Btn_Restore.FlatAppearance.BorderSize = 0;
            this.Btn_Restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Restore.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_Restore.ForeColor = System.Drawing.Color.White;
            this.Btn_Restore.Location = new System.Drawing.Point(306, 208);
            this.Btn_Restore.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Restore.Name = "Btn_Restore";
            this.Btn_Restore.Size = new System.Drawing.Size(173, 54);
            this.Btn_Restore.TabIndex = 80;
            this.Btn_Restore.Text = "استعادة نسخة إحتياطية لقاعدة البيانات";
            this.Btn_Restore.UseVisualStyleBackColor = false;
            this.Btn_Restore.Click += new System.EventHandler(this.Btn_Restore_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pnl_restor
            // 
            this.pnl_restor.Controls.Add(this.label1);
            this.pnl_restor.Controls.Add(this.txt_Restore);
            this.pnl_restor.Controls.Add(this.Btn_Restore);
            this.pnl_restor.Controls.Add(this.btnBrowse);
            this.pnl_restor.Location = new System.Drawing.Point(190, 130);
            this.pnl_restor.Name = "pnl_restor";
            this.pnl_restor.Size = new System.Drawing.Size(762, 347);
            this.pnl_restor.TabIndex = 83;
            // 
            // US_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.pnl_restor);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "US_Restore";
            this.Size = new System.Drawing.Size(1344, 628);
            this.pnl_restor.ResumeLayout(false);
            this.pnl_restor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Restore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button Btn_Restore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnl_restor;
    }
}
