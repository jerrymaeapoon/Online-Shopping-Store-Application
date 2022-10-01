using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShoppingStore
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void save_Click(object sender, EventArgs e)
        {
            string arr = "";
            for(int i =0; i<categoryTextBox.Text.Length; i++)
            {
                arr += " ";
            }
            if (categoryTextBox.Text == "")
            {
                errorNameCategory.Text = "Category item cannot be left empty!";
                errorNameCategory.Visible = true;
            }
            else if(categoryTextBox.Text.Substring(0) == arr)
            {
                errorNameCategory.Text = "Category item cannot be all spaces!";
                errorNameCategory.Visible = true;
            }
            else if(item.categoryList.Contains(categoryTextBox.Text))
            {
                errorNameCategory.Text = "Category already exists!";
                errorNameCategory.Visible = true;
            }
            else
            {
                item.categoryList.Add(categoryTextBox.Text);
                item.appendCategory(categoryTextBox.Text);
                errorNameCategory.Visible = false;
                Close();
            }
        }
        public static string categoryRemove;
        private void deleteCategory_Click(object sender, EventArgs e)
        {
            if(!item.categoryList.Contains(categoryTextBox.Text))
            {
                errorNameCategory.Text = "Category does not exist!";
                errorNameCategory.Visible = true;
            }
            else
            {
                item.categoryList.Remove(categoryTextBox.Text);
                categoryRemove = categoryTextBox.Text;
                item.reWriteCategory();
                Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
