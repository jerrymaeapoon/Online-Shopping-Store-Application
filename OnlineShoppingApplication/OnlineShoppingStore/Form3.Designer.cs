namespace OnlineShoppingStore
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addCategory = new System.Windows.Forms.Button();
            this.deleteCategory = new System.Windows.Forms.Button();
            this.errorNameCategory = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryTextBox.Location = new System.Drawing.Point(38, 52);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(216, 29);
            this.categoryTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // addCategory
            // 
            this.addCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.addCategory.FlatAppearance.BorderSize = 0;
            this.addCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategory.ForeColor = System.Drawing.SystemColors.Control;
            this.addCategory.Location = new System.Drawing.Point(212, 119);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(89, 40);
            this.addCategory.TabIndex = 2;
            this.addCategory.Text = "Add";
            this.addCategory.UseVisualStyleBackColor = false;
            this.addCategory.Click += new System.EventHandler(this.save_Click);
            // 
            // deleteCategory
            // 
            this.deleteCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.deleteCategory.FlatAppearance.BorderSize = 0;
            this.deleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCategory.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteCategory.Location = new System.Drawing.Point(111, 119);
            this.deleteCategory.Name = "deleteCategory";
            this.deleteCategory.Size = new System.Drawing.Size(89, 40);
            this.deleteCategory.TabIndex = 3;
            this.deleteCategory.Text = "Delete";
            this.deleteCategory.UseVisualStyleBackColor = false;
            this.deleteCategory.Click += new System.EventHandler(this.deleteCategory_Click);
            // 
            // errorNameCategory
            // 
            this.errorNameCategory.AutoSize = true;
            this.errorNameCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorNameCategory.Location = new System.Drawing.Point(89, 33);
            this.errorNameCategory.Name = "errorNameCategory";
            this.errorNameCategory.Size = new System.Drawing.Size(29, 13);
            this.errorNameCategory.TabIndex = 4;
            this.errorNameCategory.Text = "Error";
            this.errorNameCategory.Visible = false;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.cancel.FlatAppearance.BorderSize = 0;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.cancel.Location = new System.Drawing.Point(10, 119);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(89, 40);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.panel2.Location = new System.Drawing.Point(29, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 28);
            this.panel2.TabIndex = 18;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(312, 171);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.errorNameCategory);
            this.Controls.Add(this.deleteCategory);
            this.Controls.Add(this.addCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addCategory;
        private System.Windows.Forms.Button deleteCategory;
        private System.Windows.Forms.Label errorNameCategory;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Panel panel2;
    }
}