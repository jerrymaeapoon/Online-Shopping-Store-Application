namespace OnlineShoppingStore
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.descripTable = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.descPanel = new System.Windows.Forms.Panel();
            this.addRow = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.quantityNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picPathTb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cancelEditItem = new System.Windows.Forms.Button();
            this.errorName = new System.Windows.Forms.Label();
            this.errorPrice = new System.Windows.Forms.Label();
            this.errorCategory = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picBoxPath = new System.Windows.Forms.PictureBox();
            this.descPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPath)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.nameTextBox.Location = new System.Drawing.Point(268, 62);
            this.nameTextBox.MaxLength = 15;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(203, 27);
            this.nameTextBox.TabIndex = 1;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.priceTextBox.Location = new System.Drawing.Point(519, 62);
            this.priceTextBox.MaxLength = 15;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(182, 27);
            this.priceTextBox.TabIndex = 2;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.categoryTextBox.Location = new System.Drawing.Point(268, 125);
            this.categoryTextBox.MaxLength = 15;
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(203, 27);
            this.categoryTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(504, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(254, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category";
            // 
            // descripTable
            // 
            this.descripTable.AutoSize = true;
            this.descripTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.descripTable.ColumnCount = 3;
            this.descripTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.descripTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 322F));
            this.descripTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.descripTable.Location = new System.Drawing.Point(3, 3);
            this.descripTable.Name = "descripTable";
            this.descripTable.RowCount = 1;
            this.descripTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.descripTable.Size = new System.Drawing.Size(526, 48);
            this.descripTable.TabIndex = 7;
            this.descripTable.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description";
            // 
            // descPanel
            // 
            this.descPanel.AutoScroll = true;
            this.descPanel.Controls.Add(this.descripTable);
            this.descPanel.Location = new System.Drawing.Point(12, 274);
            this.descPanel.Name = "descPanel";
            this.descPanel.Size = new System.Drawing.Size(723, 138);
            this.descPanel.TabIndex = 9;
            // 
            // addRow
            // 
            this.addRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.addRow.FlatAppearance.BorderSize = 0;
            this.addRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRow.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRow.ForeColor = System.Drawing.SystemColors.Control;
            this.addRow.Location = new System.Drawing.Point(346, 442);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(117, 40);
            this.addRow.TabIndex = 6;
            this.addRow.Text = "Add Row";
            this.addRow.UseVisualStyleBackColor = false;
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.SystemColors.Control;
            this.save.Location = new System.Drawing.Point(631, 442);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(117, 40);
            this.save.TabIndex = 5;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // quantityNumUpDown
            // 
            this.quantityNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityNumUpDown.Location = new System.Drawing.Point(519, 125);
            this.quantityNumUpDown.Name = "quantityNumUpDown";
            this.quantityNumUpDown.Size = new System.Drawing.Size(203, 29);
            this.quantityNumUpDown.TabIndex = 4;
            this.quantityNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(504, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(254, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Picture Path";
            // 
            // picPathTb
            // 
            this.picPathTb.BackColor = System.Drawing.SystemColors.Control;
            this.picPathTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.picPathTb.Enabled = false;
            this.picPathTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.picPathTb.Location = new System.Drawing.Point(267, 187);
            this.picPathTb.MaxLength = 15;
            this.picPathTb.Name = "picPathTb";
            this.picPathTb.Size = new System.Drawing.Size(203, 20);
            this.picPathTb.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.panel1.Location = new System.Drawing.Point(259, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 28);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.panel2.Location = new System.Drawing.Point(259, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 28);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.panel3.Location = new System.Drawing.Point(509, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 30);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.panel4.Location = new System.Drawing.Point(509, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 30);
            this.panel4.TabIndex = 17;
            // 
            // cancelEditItem
            // 
            this.cancelEditItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.cancelEditItem.FlatAppearance.BorderSize = 0;
            this.cancelEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelEditItem.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelEditItem.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelEditItem.Location = new System.Drawing.Point(35, 442);
            this.cancelEditItem.Name = "cancelEditItem";
            this.cancelEditItem.Size = new System.Drawing.Size(117, 40);
            this.cancelEditItem.TabIndex = 7;
            this.cancelEditItem.Text = "Cancel";
            this.cancelEditItem.UseVisualStyleBackColor = false;
            this.cancelEditItem.Click += new System.EventHandler(this.cancelEditItem_Click);
            // 
            // errorName
            // 
            this.errorName.AutoSize = true;
            this.errorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorName.Location = new System.Drawing.Point(317, 43);
            this.errorName.Name = "errorName";
            this.errorName.Size = new System.Drawing.Size(29, 13);
            this.errorName.TabIndex = 19;
            this.errorName.Text = "Error";
            this.errorName.Visible = false;
            // 
            // errorPrice
            // 
            this.errorPrice.AutoSize = true;
            this.errorPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorPrice.Location = new System.Drawing.Point(564, 43);
            this.errorPrice.Name = "errorPrice";
            this.errorPrice.Size = new System.Drawing.Size(29, 13);
            this.errorPrice.TabIndex = 20;
            this.errorPrice.Text = "Error";
            this.errorPrice.Visible = false;
            // 
            // errorCategory
            // 
            this.errorCategory.AutoSize = true;
            this.errorCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorCategory.Location = new System.Drawing.Point(348, 106);
            this.errorCategory.Name = "errorCategory";
            this.errorCategory.Size = new System.Drawing.Size(29, 13);
            this.errorCategory.TabIndex = 21;
            this.errorCategory.Text = "Error";
            this.errorCategory.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(702, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "$";
            // 
            // picBoxPath
            // 
            this.picBoxPath.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picBoxPath.BackgroundImage = global::OnlineShoppingStore.Properties.Resources.addPic;
            this.picBoxPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxPath.Location = new System.Drawing.Point(17, 12);
            this.picBoxPath.Name = "picBoxPath";
            this.picBoxPath.Size = new System.Drawing.Size(194, 195);
            this.picBoxPath.TabIndex = 0;
            this.picBoxPath.TabStop = false;
            this.picBoxPath.Click += new System.EventHandler(this.picBoxPath_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(779, 496);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.errorCategory);
            this.Controls.Add(this.errorPrice);
            this.Controls.Add(this.errorName);
            this.Controls.Add(this.cancelEditItem);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picPathTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.quantityNumUpDown);
            this.Controls.Add(this.save);
            this.Controls.Add(this.addRow);
            this.Controls.Add(this.descPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.picBoxPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Items";
            this.descPanel.ResumeLayout(false);
            this.descPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxPath;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel descripTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel descPanel;
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.NumericUpDown quantityNumUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox picPathTb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button cancelEditItem;
        private System.Windows.Forms.Label errorName;
        private System.Windows.Forms.Label errorPrice;
        private System.Windows.Forms.Label errorCategory;
        private System.Windows.Forms.Label label7;
    }
}