
namespace WinBook_Croteau
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
            System.Windows.Forms.Button btnAdd;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.dtpDatePublished = new System.Windows.Forms.DateTimePicker();
            this.btnFillInForm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.dtpDateRentalExpires = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBookmarkPage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkMembership = new System.Windows.Forms.CheckBox();
            this.lblFeedback = new System.Windows.Forms.Label();
            btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.Black;
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(409, 401);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(100, 50);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add A Book";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author\'s First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Author\'s Last Name:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(241, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(468, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(109, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date Published:";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(241, 73);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(278, 20);
            this.txtFName.TabIndex = 5;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(241, 127);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(278, 20);
            this.txtLName.TabIndex = 6;
            // 
            // dtpDatePublished
            // 
            this.dtpDatePublished.Location = new System.Drawing.Point(241, 273);
            this.dtpDatePublished.Name = "dtpDatePublished";
            this.dtpDatePublished.Size = new System.Drawing.Size(200, 20);
            this.dtpDatePublished.TabIndex = 9;
            // 
            // btnFillInForm
            // 
            this.btnFillInForm.BackColor = System.Drawing.Color.Black;
            this.btnFillInForm.ForeColor = System.Drawing.Color.Crimson;
            this.btnFillInForm.Location = new System.Drawing.Point(241, 415);
            this.btnFillInForm.Name = "btnFillInForm";
            this.btnFillInForm.Size = new System.Drawing.Size(75, 23);
            this.btnFillInForm.TabIndex = 8;
            this.btnFillInForm.Text = "Fill In Form";
            this.btnFillInForm.UseVisualStyleBackColor = false;
            this.btnFillInForm.Click += new System.EventHandler(this.btnFillInForm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(115, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Author\'s Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(241, 177);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(159, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "# Pages:";
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(241, 223);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(75, 20);
            this.txtPages.TabIndex = 8;
            // 
            // dtpDateRentalExpires
            // 
            this.dtpDateRentalExpires.Location = new System.Drawing.Point(737, 273);
            this.dtpDateRentalExpires.Name = "dtpDateRentalExpires";
            this.dtpDateRentalExpires.Size = new System.Drawing.Size(200, 20);
            this.dtpDateRentalExpires.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(605, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Return Date:";
            // 
            // txtBookmarkPage
            // 
            this.txtBookmarkPage.Location = new System.Drawing.Point(241, 323);
            this.txtBookmarkPage.Name = "txtBookmarkPage";
            this.txtBookmarkPage.Size = new System.Drawing.Size(75, 20);
            this.txtBookmarkPage.TabIndex = 10;
            this.txtBookmarkPage.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(91, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Bookmark Page #:";
            // 
            // chkMembership
            // 
            this.chkMembership.AutoSize = true;
            this.chkMembership.Location = new System.Drawing.Point(737, 323);
            this.chkMembership.Name = "chkMembership";
            this.chkMembership.Size = new System.Drawing.Size(124, 17);
            this.chkMembership.TabIndex = 12;
            this.chkMembership.Text = "Currently A Member?";
            this.chkMembership.UseVisualStyleBackColor = true;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedback.Location = new System.Drawing.Point(91, 459);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(0, 20);
            this.lblFeedback.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 689);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.chkMembership);
            this.Controls.Add(this.txtBookmarkPage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDateRentalExpires);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(btnAdd);
            this.Controls.Add(this.btnFillInForm);
            this.Controls.Add(this.dtpDatePublished);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.DateTimePicker dtpDatePublished;
        private System.Windows.Forms.Button btnFillInForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.DateTimePicker dtpDateRentalExpires;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBookmarkPage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkMembership;
        private System.Windows.Forms.Label lblFeedback;
    }
}

