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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            foreach(string commercial in item.commercials)
            {
                while(commercial!="")
                    richTextBox1.AppendText(commercial + "\n");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string[]arr = richTextBox1.Text.Split('\n');
            item.commercials = arr.ToList();
            using (StreamWriter write = new StreamWriter("commercial.txt"))
            {
                foreach (string commercial in item.commercials)
                {
                    write.WriteLine(commercial);
                }
            }
        }
    }
}
