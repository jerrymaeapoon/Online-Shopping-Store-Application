using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace OnlineShoppingStore
{
    public partial class Form2 : Form
    {
       public static int rows = 0;
        bool isEdit = false;
        public Form2()
        {
            InitializeComponent();
        }
        public static string k;

        public Form2(Control p)//Parent of the edit button, The item we want to edit on.
        {
            InitializeComponent();
            isEdit = true;
            item.EditLoad(isEdit,p, descripTable, nameTextBox, priceTextBox, categoryTextBox, picBoxPath, quantityNumUpDown, picPathTb);
        }
        private void addRow_Click(object sender, EventArgs e)
        {
            item.addRow(rows, descripTable);
        }

        private void save_Click(object sender, EventArgs e)
        {
           /* string arr = "";
            for (int i = 0; i < nameTextBox.Text.Length; i++)
            {
                arr += " ";
            }
            if (nameTextBox.Text == "")
            {
                errorNameCategory.Text = "Category item cannot be left empty!";
                errorNameCategory.Visible = true;
            }
            else if (nameTextBox.Text.Substring(0) == arr)
            {
                errorNameCategory.Text = "Category item cannot be all spaces!";
                errorNameCategory.Visible = true;
            }
            else if (Form1.category.Contains(textBox1.Text))
            {
                errorNameCategory.Text = "Category already exists!";
                errorNameCategory.Visible = true;
            }
            else
            {
                Form1.category.Add(textBox1.Text);
                item.appendCategory(textBox1.Text);
                errorNameCategory.Visible = false;
                Close();
            }*/
            item.saveChange(isEdit, descripTable,  nameTextBox,  priceTextBox,  categoryTextBox,  picBoxPath, quantityNumUpDown,  nameTextBox, picPathTb);
            Close();
        }

        private void picBoxPath_Click(object sender, EventArgs e)
        {
            item.picBoxPath(picBoxPath,picPathTb);
        }

        private void cancelEditItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
