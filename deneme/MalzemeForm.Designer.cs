namespace deneme
{
    partial class MalzemeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MK = new System.Windows.Forms.TextBox();
            this.KDV = new System.Windows.Forms.TextBox();
            this.BS = new System.Windows.Forms.TextBox();
            this.MA = new System.Windows.Forms.TextBox();
            this.SAT = new System.Windows.Forms.TextBox();
            this.SAF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MK
            // 
            this.MK.Location = new System.Drawing.Point(25, 46);
            this.MK.Name = "MK";
            this.MK.Size = new System.Drawing.Size(118, 22);
            this.MK.TabIndex = 0;
            // 
            // KDV
            // 
            this.KDV.Location = new System.Drawing.Point(475, 46);
            this.KDV.Name = "KDV";
            this.KDV.Size = new System.Drawing.Size(100, 22);
            this.KDV.TabIndex = 1;
            // 
            // BS
            // 
            this.BS.Location = new System.Drawing.Point(327, 46);
            this.BS.Name = "BS";
            this.BS.Size = new System.Drawing.Size(100, 22);
            this.BS.TabIndex = 2;
            // 
            // MA
            // 
            this.MA.Location = new System.Drawing.Point(180, 46);
            this.MA.Name = "MA";
            this.MA.Size = new System.Drawing.Size(117, 22);
            this.MA.TabIndex = 3;
            // 
            // SAT
            // 
            this.SAT.Location = new System.Drawing.Point(625, 46);
            this.SAT.Name = "SAT";
            this.SAT.Size = new System.Drawing.Size(100, 22);
            this.SAT.TabIndex = 4;
            // 
            // SAF
            // 
            this.SAF.Location = new System.Drawing.Point(770, 46);
            this.SAF.Name = "SAF";
            this.SAF.Size = new System.Drawing.Size(100, 22);
            this.SAF.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Malzeme kodu ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Malzeme adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Birim set";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "KDV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(618, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Satın alma fiyatı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(779, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Satış fiyatı";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(257, 94);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(141, 36);
            this.save.TabIndex = 12;
            this.save.Text = "Kaydet";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(504, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Vazgeç";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancel_Click);
            // 
            // MalzemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 167);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SAF);
            this.Controls.Add(this.SAT);
            this.Controls.Add(this.MA);
            this.Controls.Add(this.BS);
            this.Controls.Add(this.KDV);
            this.Controls.Add(this.MK);
            this.Name = "MalzemeForm";
            this.Text = "Form3";
            this.Shown += new System.EventHandler(this.MalzemeForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MK;
        private System.Windows.Forms.TextBox KDV;
        private System.Windows.Forms.TextBox BS;
        private System.Windows.Forms.TextBox MA;
        private System.Windows.Forms.TextBox SAT;
        private System.Windows.Forms.TextBox SAF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button2;
    }
}