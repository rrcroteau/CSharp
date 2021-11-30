namespace Week7_Sample3_WindowsVersion
{
    partial class Form1
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtBookmarkPage = new System.Windows.Forms.TextBox();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAuthorLast = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthorFirst = new System.Windows.Forms.TextBox();
            this.dtpDatePublished = new System.Windows.Forms.DateTimePicker();
            this.dtpDateRentalExpires = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEBook_ID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(312, 385);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(178, 23);
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "Insert Book";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtBookmarkPage
            // 
            this.txtBookmarkPage.Location = new System.Drawing.Point(312, 317);
            this.txtBookmarkPage.Name = "txtBookmarkPage";
            this.txtBookmarkPage.Size = new System.Drawing.Size(100, 20);
            this.txtBookmarkPage.TabIndex = 7;
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(312, 222);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(79, 20);
            this.txtPages.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(312, 174);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(234, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtAuthorLast
            // 
            this.txtAuthorLast.Location = new System.Drawing.Point(312, 129);
            this.txtAuthorLast.Name = "txtAuthorLast";
            this.txtAuthorLast.Size = new System.Drawing.Size(234, 20);
            this.txtAuthorLast.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(312, 35);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(343, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // txtAuthorFirst
            // 
            this.txtAuthorFirst.Location = new System.Drawing.Point(312, 82);
            this.txtAuthorFirst.Name = "txtAuthorFirst";
            this.txtAuthorFirst.Size = new System.Drawing.Size(234, 20);
            this.txtAuthorFirst.TabIndex = 1;
            // 
            // dtpDatePublished
            // 
            this.dtpDatePublished.Location = new System.Drawing.Point(312, 275);
            this.dtpDatePublished.Name = "dtpDatePublished";
            this.dtpDatePublished.Size = new System.Drawing.Size(200, 20);
            this.dtpDatePublished.TabIndex = 5;
            // 
            // dtpDateRentalExpires
            // 
            this.dtpDateRentalExpires.Location = new System.Drawing.Point(714, 275);
            this.dtpDateRentalExpires.Name = "dtpDateRentalExpires";
            this.dtpDateRentalExpires.Size = new System.Drawing.Size(200, 20);
            this.dtpDateRentalExpires.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Author\'s First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bookmark Page #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date Published";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "# of Pages";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Author\'s Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Author\'s Last Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(608, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Return Date";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(309, 429);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(0, 13);
            this.lblFeedback.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "EBook ID:";
            // 
            // lblEBook_ID
            // 
            this.lblEBook_ID.AutoSize = true;
            this.lblEBook_ID.Location = new System.Drawing.Point(74, 21);
            this.lblEBook_ID.Name = "lblEBook_ID";
            this.lblEBook_ID.Size = new System.Drawing.Size(0, 13);
            this.lblEBook_ID.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 475);
            this.Controls.Add(this.lblEBook_ID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateRentalExpires);
            this.Controls.Add(this.dtpDatePublished);
            this.Controls.Add(this.txtAuthorFirst);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAuthorLast);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.txtBookmarkPage);
            this.Controls.Add(this.btnInsert);
            this.Name = "Form1";
            this.Text = "Books DataBase";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtBookmarkPage;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAuthorLast;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthorFirst;
        private System.Windows.Forms.DateTimePicker dtpDatePublished;
        private System.Windows.Forms.DateTimePicker dtpDateRentalExpires;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEBook_ID;
    }
}

