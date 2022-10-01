using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace OnlineShoppingStore
{

    public class item
    {
        public string category, PicPath, description;
        public float price;
        public int quantity;
        public static float total;

        public static Dictionary<string, item> items = new Dictionary<string, item>();
        public static List<string> commercials = new List<string>();
        public static List<string> categoryList = new List<string>();
        public static Dictionary<string, item> bought = new Dictionary<string, item>();
        public static Dictionary<string, item> usercart = new Dictionary<string, item>();
        public static int adsCounter = 0;
        public static bool isadmin = false;
        public static bool isuser = false;


        //________________________Reading and writing from files____________________
        public static void ads(int adsCounter, PictureBox commercialPanel)//Reading Commercials.
        {
            try
            {
                commercials = File.ReadLines("commercial.txt").ToList();
                commercialPanel.BackgroundImage = Image.FromFile(commercials[adsCounter % commercials.Count]);
            }
            catch { MessageBox.Show("There was an error craeting categories"); }
        }
        public static void readItems()
        {
            string[] arr;
            try
            {
                List<string> lines = File.ReadAllLines("item.txt").ToList();
                foreach (string line in lines)
                {
                    item objItem = new item();
                    arr = line.Split(',');
                    objItem.price = float.Parse(arr[1]);
                    objItem.category = arr[2];
                    objItem.PicPath = arr[3];
                    objItem.quantity = int.Parse(arr[4]);
                    objItem.description = arr[5];
                    items[arr[0]] = objItem;
                }
            }
            catch { MessageBox.Show("Please check your items input.", "Error, sorry!"); }

        }
        public static void appendCategory(string sCategory)
        {
            using (StreamWriter write = File.AppendText("category.txt"))
            {
                write.WriteLine(sCategory);
            }
        }
        public static void reWriteCategory()
        {
            using (StreamWriter write = new StreamWriter("category.txt"))
            {
                foreach(string s in categoryList)
                {
                    write.WriteLine(s);
                }
            }

        }
        //
        //__________________Handling Commercials___________________________
        public static void commercial(PictureBox commercialPanel, int adsCounter)
        {
            if (commercials.Count != 0)
            {
                try
                {
                    commercialPanel.BackgroundImage = Image.FromFile(commercials[adsCounter % commercials.Count]); //To make it circluar.
                }
                catch
                { }
            }
        }
        //___________________Creating____________________________________________
        //Create Items
        public static void add(FlowLayoutPanel categoryFlp, FlowLayoutPanel itemFlp, TabControl tabControl1, TabPage descriptionPage,
            Panel descPanel, Label descName, Label LabeldescName, Label descPrice, PictureBox descPicture, Dictionary<string, item> it,
            Label cartLabel, FlowLayoutPanel cartFlp, TextBox searchTextBox,Panel panel1, Label totalPriceLabel)
        {
            int size = items.Count;
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (items.Count > size)//To make sure an item is added.
            {
                string s = it.Keys.Last();
                item obj = it.Values.Last();
                if(!categoryList.Contains(obj.category))//If category does not exist, create one.
                {
                    categoryList.Add(obj.category);
                    finalCreateCategory(obj.category, categoryFlp, searchTextBox, itemFlp, panel1, it);
                    appendCategory(obj.category);
                }
                create(s, obj.price.ToString(), obj.category, obj.PicPath, categoryFlp, itemFlp, tabControl1, descriptionPage, descPanel, descName, descPrice, descPicture, it, cartLabel, cartFlp, searchTextBox, obj.category, totalPriceLabel, panel1);
                Button b = null;
                foreach (Button btn in categoryFlp.Controls)
                {
                    if (btn.BackColor == Color.SteelBlue)
                        b = btn;
                }
            }
        }
        public static void create(string name, string price, string category, string PicPath, FlowLayoutPanel categoryFlp, FlowLayoutPanel itemFlp, 
            TabControl tabControl1, TabPage descriptionPage, Panel descPanel, Label descName, Label descPrice, PictureBox descPicture, Dictionary<string, item> it
            , Label cartLabel, FlowLayoutPanel cartFlp, TextBox searchTextBox, string c, Label totalPriceLabel, Panel panel1)
        {
            // panel 
            Panel p = new Panel();
            p.Margin = new Padding(2, 2, 2, 2);
            p.BackColor = Color.LightGray; ;
            p.Size = new Size(342, 186);
            p.Name = name;
            p.Click += delegate
            {
                if(!isadmin)
                {
                    tabControl1.SelectTab(descriptionPage);
                    createDescription(p.Name, descPanel, descName, descPrice, descPicture, it);
                }
            };
            itemFlp.Controls.Add(p);
            Button B = new Button();//Zy int x
            foreach (Button btn in categoryFlp.Controls)
            {
                if (btn.BackColor == Color.SteelBlue)
                B = btn;
            }
            if ((B.Text == c|| B.Text == "All") && (p.Name.Contains(searchTextBox.Text)|| searchTextBox.Text == "Search..."))
            {
                p.Visible = true;
            }
            else
                p.Visible = false;

            //picture box
            PictureBox pb = new PictureBox();
            pb.Size = new Size(174, 156);
            pb.Location = new Point(13, 15);
            //pb.BackgroundImage = Image.FromFile(PicPath);
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.Click += delegate
            {
                if (!isadmin)
                {
                    tabControl1.SelectTab(descriptionPage);
                    createDescription(p.Name, descPanel, descName, descPrice, descPicture, it);
                }
            };
            p.Controls.Add(pb);

            //label of name
            Label lName;
            lName = new Label();
            lName.Text = name;
            lName.Font = new Font("Microsoft Sans Serif", 16);
            lName.AutoSize = true;
            lName.Location = new Point(202, 50);
            p.Controls.Add(lName);


            //label of price
            Label lPrice;
            lPrice = new Label();
            lPrice.Text = price + '$';
            lPrice.Font = new Font("Microsoft Sans Serif", 12);
            lPrice.AutoSize = true;
            lPrice.Location = new Point(202, 84);
            p.Controls.Add(lPrice);

            //button add to cart
            Button buttoncart = new Button();
            buttoncart.Font = new Font("Cambria", 12);
            buttoncart.Size = new Size(127, 36);
            buttoncart.Location = new Point(198, 126);
            buttoncart.Text = "Add To Cart";
            buttoncart.Font = new Font(buttoncart.Font, FontStyle.Bold);
            buttoncart.FlatAppearance.MouseOverBackColor = Color.Tomato;
            buttoncart.FlatAppearance.MouseDownBackColor = Color.Salmon;
            buttoncart.BackColor = Color.OrangeRed;
            buttoncart.FlatAppearance.BorderSize = 0;
            buttoncart.FlatStyle = FlatStyle.Flat;
            buttoncart.ForeColor = SystemColors.ControlLightLight;
            buttoncart.Cursor = Cursors.Hand;
            buttoncart.Click += delegate
             {
                 if (isuser)
                 {
                     if(buttoncart.Text == "Add To Cart")
                     {
                         int x = int.Parse(cartLabel.Text);
                         x++;
                         cartLabel.Text = x.ToString();
                         //Cart Edit
                         addToCart(cartFlp, buttoncart, totalPriceLabel, cartLabel, itemFlp);
                         buttoncart.Text = "Is Added";
                     }
                 }
             };

            p.Controls.Add(buttoncart);


            Button deleteButton = new Button();
            deleteButton.Font = new Font("Cambria", 6);
            deleteButton.Size = new Size(28, 16);
            deleteButton.Location = new Point(311, 2);
            deleteButton.Text = "X";
            deleteButton.BackColor = Color.FromArgb(29, 28, 29);
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.ForeColor = SystemColors.ControlLightLight;
            deleteButton.Cursor = Cursors.Hand;
            if (isadmin)
                deleteButton.Visible = true;
            else
                deleteButton.Visible = false;
            deleteButton.Click += delegate
            {
                            items.Remove(deleteButton.Parent.Name);
                            itemFlp.Controls.Remove(deleteButton.Parent);
                            using (StreamWriter write = new StreamWriter("item.txt"))
                            {
                                foreach (KeyValuePair<string, item> kvp in it)
                                {
                                    write.WriteLine(kvp.Key + "," + kvp.Value.price.ToString() + "," + kvp.Value.category + "," + kvp.Value.PicPath + "," + kvp.Value.quantity.ToString() + "," + kvp.Value.description);
                                }
                            }
            };
            p.Controls.Add(deleteButton);

            Button editButton = new Button();
            editButton.Font = new Font("Cambria", 6);
            editButton.Size = new Size(28, 16);
            editButton.Location = new Point(281, 2);
            editButton.Text = "E";
            editButton.BackColor = Color.FromArgb(29, 28, 29);
            editButton.FlatAppearance.BorderSize = 0;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.ForeColor = SystemColors.ControlLightLight;
            editButton.Cursor = Cursors.Hand;
            editButton.Click += delegate
             {
                     editButton.Parent.Name = name;
                     string s = editButton.Parent.Name;
                     Form2 f2 = new Form2(editButton.Parent);
                     f2.ShowDialog();
                     editButton.Parent.Name = Form2.k;
                     name = Form2.k;
                     item obj = items[editButton.Parent.Name];
                     if (!categoryList.Contains(obj.category))
                     {
                         categoryList.Add(obj.category);
                        finalCreateCategory(obj.category, categoryFlp, searchTextBox, itemFlp, panel1, it);
                        appendCategory(obj.category);
                     }
                    Point pPB = new Point(13, 15);//Point pictureBox on the item itself
                     Point pNL = new Point(202, 50);//Point Name Label on the item itself
                     Point pPL = new Point(202, 84);//Point Price Label on the item itself
                     editButton.Parent.GetChildAtPoint(pPB).BackgroundImage = Image.FromFile(obj.PicPath);
                     editButton.Parent.GetChildAtPoint(pPL).Text = obj.price.ToString() + "$";
                     editButton.Parent.GetChildAtPoint(pNL).Text = Form2.k;

                     Button B2 = new Button();//Zy int x
                     foreach (Button btn in categoryFlp.Controls)
                     {
                         if (btn.BackColor == Color.SteelBlue)
                            B2 = btn;
                     }
                 if ((B2.Text == obj.category|| B2.Text == "All") && (editButton.Parent.Name.Contains(searchTextBox.Text)|| searchTextBox.Text == "Search..."))
                 {
                     editButton.Parent.Visible = true;
                 }
                 else
                     editButton.Parent.Visible = false;
                 //chooseCateg(itemFlp, B, Form1.items);
             };
            if (isadmin)
                editButton.Visible = true;
            else
                editButton.Visible = false;
            p.Controls.Add(editButton);
        }

        //
        //
        public static void createCategory(FlowLayoutPanel categoryFlp, TextBox searchTextBox, FlowLayoutPanel itemFlp, Panel panel1, Dictionary<string, item> it)
        {
            try
            {
                categoryList = File.ReadAllLines("category.txt").ToList();
                foreach (string line in categoryList)
                {
                    finalCreateCategory(line, categoryFlp, searchTextBox, itemFlp, panel1, it);
                }
            }
            catch { MessageBox.Show("There was an error reading categories."); }
        }
        public static void finalCreateCategory(string line, FlowLayoutPanel categoryFlp, TextBox searchTextBox, FlowLayoutPanel itemFlp, Panel panel1, Dictionary<string, item> it)
        {
            Button b = new Button();
            b.Text = line;
            b.ForeColor = Color.WhiteSmoke;
            b.Font = new Font("Cambria", 24);
            b.Size = new Size(224, 58);
            b.BackColor = Color.FromArgb(29, 28, 29);
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 45, 49);
            b.FlatStyle = FlatStyle.Flat;
            b.Cursor = Cursors.Hand;
            b.Click += delegate
            {
                categoryFlp.Focus();
                searchTextBox.Text = "Search...";
                searchTextBox.ForeColor = Color.Silver;
                foreach (Button btn in categoryFlp.Controls)
                {
                    btn.BackColor = Color.FromArgb(29, 28, 29);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 45, 49);
                }
                b.BackColor = Color.SteelBlue;
                b.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
                chooseCateg(itemFlp, b, it);
            };
            b.MouseEnter += delegate
            {
                categoryFlp.Focus();
            };
            categoryFlp.Controls.Add(b);
        }
        public static void deleteCategory(FlowLayoutPanel categoryFlp, FlowLayoutPanel itemFlp, string s, Dictionary<string, item> it)
        {
            List<string> l = new List<string>();
            foreach (Button b in categoryFlp.Controls)
            {
                if (b.Text == s)
                {
                    categoryFlp.Controls.Remove(b);
                }
            }
            foreach (KeyValuePair<string, item> kvp in it)
            {
                if (kvp.Value.category == s)
                    l.Add(kvp.Key);
            }
            foreach (Panel p in itemFlp.Controls)
            {
                if (l.Contains(p.Name))
                    itemFlp.Controls.Remove(p);
            }
        }
        //
        //
        public static void createDescription(string n, Panel descPanel, Label descName, Label descPrice, PictureBox descPicture, Dictionary<string, item> it)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnCount = 2;
            tlp.RowCount = 1;
            //tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tlp.AutoSize = true;
            tlp.Location = new Point(3, 3);
            descPanel.Controls.Add(tlp);
            descName.Text = n;
            descPrice.Text = it[n].price.ToString() + "$";
            descPicture.BackgroundImage = Image.FromFile(it[n].PicPath);
            string[] token = it[n].description.Split('^');
            for (int i = 0; i < token.Length; i++)
            {
                string[] dtoken = token[i].Split('%');
                for (int j = 0; j < dtoken.Length; j++)
                {
                    Label l = new Label();
                    l.Text = dtoken[j];
                    l.Size = new Size(203, 27);
                    l.Font = new Font("Cambria", 14);
                    tlp.Controls.Add(l);
                }
            }

        }
        //Handling 'All' Category Button, same as 'chooseCateg' function
        public static void handlingAll(Button all, FlowLayoutPanel categoryFlp, TextBox searchTextBox, FlowLayoutPanel itemFlp, Panel panel1, Dictionary<string, item> it)
        {
            all.Click += delegate
            {
                itemFlp.Focus();
                searchTextBox.Text = "Search...";
                searchTextBox.ForeColor = Color.Silver;
                foreach (Button btn in categoryFlp.Controls)
                {
                    btn.BackColor = Color.FromArgb(29, 28, 29);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 45, 49);
                }
                all.BackColor = Color.SteelBlue;
                all.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
                chooseCateg(itemFlp, all, it);
            };
        }
        //What happens when a cetogory button is chosen
        public static void chooseCateg(FlowLayoutPanel flp, Control b, Dictionary<string, item> it)
        {//flp = itemFlp        b = Category button Clicked         it = items Dictionary

            if (b.Text == "All")
            {
                foreach (Panel p in flp.Controls)//Show all items.
                    if (p.BackColor == Color.LightGray)
                        p.Visible = true;
            }
            else
            {
                List<string> extra = new List<string>();//To hold the names of the items in this category.
                foreach (KeyValuePair<string, item> kvp in it)//Looping through dictionary.
                {
                    if (kvp.Value.category.ToLower() == b.Text.ToLower())
                    {
                        extra.Add(kvp.Key.ToLower());
                    }
                }
                foreach (Panel p in flp.Controls)//Looping through items
                {
                    if (p.BackColor == Color.LightGray)//Checking if I'm holding an item.
                    {
                        if (extra.Contains(p.Name.ToLower()))
                            p.Visible = true;
                        else
                            p.Visible = false;
                    }
                }
            }
        }

        //Handling Search
        public static void search(TextBox tb, FlowLayoutPanel flp, FlowLayoutPanel categoryFlp, Panel panel1, Dictionary<string, item> it)
        {
            Button b = null;
            foreach (Button btn in categoryFlp.Controls)
            {
                if (btn.BackColor == Color.SteelBlue)
                    b = btn;
            }
            if ((tb.Text == "Search..." && tb.ForeColor == Color.Silver) || tb.Text == "")
            {
                chooseCateg(flp, b, it);
            }
            else
            {
                panel1.VerticalScroll.Value = 300;
                List<string> extra = new List<string>();//To hold the names of the items in this category.
                foreach (KeyValuePair<string, item> kvp in it)
                {
                    if (kvp.Value.category.ToLower() == b.Text.ToLower() && kvp.Key.ToLower().Contains(tb.Text.ToLower()) && b.Text != "All")
                    {
                        extra.Add(kvp.Key.ToLower());
                    }
                    else if (b.Text == "All" && kvp.Key.ToLower().Contains(tb.Text.ToLower()))
                        extra.Add(kvp.Key.ToLower());
                }
                foreach (Panel p in flp.Controls)
                {
                    if (p.BackColor == Color.LightGray)
                    {
                        if (extra.Contains(p.Name.ToLower()))
                            p.Visible = true;
                        else
                            p.Visible = false;
                    }
                }
            }
        }
        public static void search_Enter(TextBox searchTextBox)
        {
            if (searchTextBox.Text == "Search...")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = Color.Black;
            }
        }
        public static void search_Leave(TextBox searchTextBox)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.ForeColor = Color.Silver;
                searchTextBox.Text = "Search...";
            }
        }


        //Adding or Editing an item
        //Form2
        //Copies data of the item to Form2
        public static void EditLoad(bool isEdit, Control p, TableLayoutPanel descripTable, TextBox nameTb, TextBox priceTextBox, TextBox categoryTextBox, PictureBox picBoxPath, NumericUpDown quantityNumUpDown, TextBox picPathTb)
        {
            Form2.k = p.Name;
            isEdit = true;
            nameTb.Text = p.Name;
            priceTextBox.Text = items[p.Name].price.ToString();
            categoryTextBox.Text = items[p.Name].category;
            picBoxPath.BackgroundImage = Image.FromFile(items[p.Name].PicPath);
            quantityNumUpDown.Value = items[p.Name].quantity;
            picPathTb.Text = items[p.Name].PicPath;
            string[] token = items[p.Name].description.Split('^');
            for (int i = 0; i < token.Length; i++)
            {
                string[] dtoken = token[i].Split('%');
                if(dtoken[0]!="")
                {
                    descripTable.Visible = true;
                    for (int j = 0; j < dtoken.Length; j++)
                    {
                        TextBox tb = new TextBox();
                        tb.Text = dtoken[j];
                        tb.Size = new Size(203, 27);
                        tb.Font = new Font("Cambria", 14);
                        descripTable.Controls.Add(tb);
                    }
                    Button b = new Button();
                    b.Text = "X";
                    b.Click += delegate
                    {
                        Form2.rows--;
                        int cell = descripTable.GetPositionFromControl(b).Row;
                        for (int m = 0; m < descripTable.ColumnCount; m++)
                        {
                            descripTable.Controls.RemoveAt(cell);
                        }
                        if (!descripTable.HasChildren)
                            descripTable.Visible = false;
                    };
                    descripTable.Controls.Add(b);
                    Form2.rows++;
                }
            }
        }
        //Adds a row for description in Form2
        public static void addRow(int rows, TableLayoutPanel descripTable)
        {
            Form2.rows++;
            for (int i = 0; i < 2; i++)
            {
                descripTable.Visible = true;
                TextBox tb = new TextBox();
                tb.Size = new Size(203, 27);
                tb.Font = new Font("Microsoft Sans Serif", 11);
                descripTable.Controls.Add(tb);
            }
            Button b = new Button();
            b.Text = "X";
            b.Click += delegate
            {
                Form2.rows--;
                int cell = descripTable.GetPositionFromControl(b).Row;
                for (int m = 0; m < descripTable.ColumnCount; m++)
                {
                    descripTable.Controls.RemoveAt(cell);
                }
                if (!descripTable.HasChildren)
                    descripTable.Visible = false;
            };
            descripTable.Controls.Add(b);
        }
        //Button Save in Form2 is Clicked______When adding or Editing an item
        public static void saveChange(bool isEdit, TableLayoutPanel descripTable, TextBox nameTb, TextBox priceTextBox, TextBox categoryTextBox,PictureBox picBoxPath, NumericUpDown quantityNumUpDown, TextBox nameTextBox, TextBox picPathTb)
        {

            string s = "";
            item obj = new item();
            obj.price = float.Parse(priceTextBox.Text);
            obj.category = categoryTextBox.Text;
            obj.PicPath = picPathTb.Text;
            obj.quantity = int.Parse(quantityNumUpDown.Value.ToString());
            for (int i = 0; i <Form2.rows; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Control c = descripTable.GetControlFromPosition(j, i);
                    if (c is TextBox)
                    {
                        if (c.Text != "")
                            s += c.Text;
                        if (j == 0)
                            s += "%";
                    }
                }
                if (i != Form2.rows - 1)
                    s += "^";
            }
            obj.description = s;
            if (isEdit)
            {
               if(Form2.k == nameTb.Text)
                    items[nameTb.Text] = obj;
               else
                {
                    items.Remove(Form2.k);
                    Form2.k = nameTb.Text;
                    items[nameTb.Text] = obj;
                }
                using (StreamWriter write = new StreamWriter("item.txt"))
                {
                    foreach (KeyValuePair<string, item> kvp in items)
                    {
                        write.WriteLine(kvp.Key + "," + kvp.Value.price.ToString() + "," + kvp.Value.category + "," + kvp.Value.PicPath + "," + kvp.Value.quantity.ToString() + "," + kvp.Value.description);
                    }
                }
            }
            else
            {
                using (StreamWriter write = File.AppendText("item.txt"))
                {
                    items.Add(nameTb.Text, obj);
                    write.WriteLine(nameTb.Text + "," + priceTextBox.Text + "," + categoryTextBox.Text + "," + obj.PicPath + "," + quantityNumUpDown.Value.ToString() + "," + s);
                }
            }
        }
        //The picture box adds a picture for the item by clicking on it.
        public static void picBoxPath(PictureBox pb, TextBox tb)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pb.BackgroundImage = Image.FromFile(dialog.FileName);
                tb.Text = dialog.FileName;
            }
        }


        //Handling Cart

        public static void addToCart(FlowLayoutPanel cartFlp, Button b, Label totalPriceLabel, Label cartLabel, FlowLayoutPanel itemFlp)
        {
            item itm;
            Control p = b.Parent;
            string nameofitem = p.Name;
            items.TryGetValue(nameofitem, out itm);
            Label n = new Label();
            Label prc = new Label();
            PictureBox picbox = new PictureBox();
            Button del = new Button();
            NumericUpDown numberofitems = new NumericUpDown();

            n.Text = p.Name;
            prc.Text = itm.price.ToString();
            total += float.Parse(prc.Text);
            totalPriceLabel.Text = total.ToString();
            picbox.Size = new Size(174, 156);
            picbox.BackgroundImage = Image.FromFile(itm.PicPath);
            picbox.BackgroundImageLayout = ImageLayout.Stretch;
            n.Location = new Point(250, 51);
            n.Font = new Font("Microsoft Sans Serif", 18);
            prc.Font = new Font("Microsoft Sans Serif", 18);

            prc.Location = new Point(380, 49);
            picbox.Location = new Point(3, 3);
            picbox.Size = new Size(210, 109);
            del.Location = new Point(694, 50);
            numberofitems.Location = new Point(538, 58);
            itm.quantity = (int)numberofitems.Value;
            numberofitems.Value = 1;
            int before, after;
            before = (int)numberofitems.Value;
            numberofitems.Click += delegate
            {
                after = (int)numberofitems.Value;
                if(before<after)
                {
                    int number = (int)numberofitems.Value;

                    total += float.Parse((itm.price).ToString());
                    totalPriceLabel.Text = total.ToString();
                }
                else if(after<before)
                {
                    int number = (int)numberofitems.Value;

                    total -= float.Parse((itm.price).ToString());
                    totalPriceLabel.Text = total.ToString();
                }
                before = after;
            };

            del.Size = new Size(40, 29);
            del.Text = "X";
            del.Click += delegate
            {
                delete(totalPriceLabel, del, cartFlp, prc, cartLabel, itemFlp, numberofitems);
                total -= itm.price;
                totalPriceLabel.Text = total.ToString();

            };


            Panel panelcart;
            panelcart = new Panel();
            panelcart.Name = p.Name;
            panelcart.Margin = new Padding(3, 3, 3, 3);
            panelcart.BackColor = Color.LightGray; ;
            panelcart.Size = new Size(757, 124);
            panelcart.Location = new Point(3, 3);


            panelcart.Controls.Add(n);
            panelcart.Controls.Add(prc);
            panelcart.Controls.Add(picbox);
            panelcart.Controls.Add(del);
            panelcart.Controls.Add(numberofitems);
            cartFlp.Controls.Add(panelcart);
            bought[p.Name] = itm;
        }

        public static void delete(Label totalPrice, Button b, FlowLayoutPanel flp, Label priceLabel, Label cartLabel, FlowLayoutPanel itemFlp, NumericUpDown numberOfItems)
        {
            item itm;
            Control p = b.Parent;
            string nameofitem = p.Name;
            items.TryGetValue(nameofitem, out itm);
            flp.Controls.Remove(p);
            bought.Remove(p.Name);
            foreach(Panel i in itemFlp.Controls)
            {
                if(i.Name == p.Name)
                {
                    Point pt = new Point(198, 126);
                    i.GetChildAtPoint(pt).Text = "Add To Cart";
                }
            }
             totalPrice.Text = (Convert.ToInt32(totalPrice.Text)-(Convert.ToInt32(priceLabel.Text)*Convert.ToInt32(numberOfItems.Value))).ToString();//to decremet cart label

            int decrement = int.Parse(cartLabel.Text);
            decrement--;
            cartLabel.Text = decrement.ToString();
        }

        public static void decrementing_quantitiy(Dictionary<string, item> items, Dictionary<string, item> usercart) //check this dina
        {
            foreach (string k in usercart.Keys) //compare two keys
                if (items.ContainsKey(k))
                {
                    items[k].quantity -= usercart[k].quantity;
                }
            using (StreamWriter write = new StreamWriter("item.txt"))
            {
                foreach (KeyValuePair<string, item> kvp in items)
                {
                    write.WriteLine(kvp.Key + "," + kvp.Value.price.ToString() + "," + kvp.Value.category + "," + kvp.Value.PicPath + "," + kvp.Value.quantity.ToString() + "," + kvp.Value.description);
                }
            }
        }

        public static void buy(FlowLayoutPanel cartFlp, string username, Label cartLabel, Label totalPriceLabel, FlowLayoutPanel profileFlp)
        {
            //Yn2s mn el-quantity

            try
            {
                StreamWriter writer = new StreamWriter("Cart.txt");
                writer.Write(username);
                writer.Write(",");

                foreach (var map in bought) //check this
                {
                    writer.WriteLine(map.Key + "," + map.Value.price.ToString() + "," + map.Value.quantity.ToString() + "," + map.Value.PicPath + "," + map.Value.category);
                }
                writer.Close();
                user.display_profile(profileFlp);
                delete_cart(cartFlp, cartLabel, totalPriceLabel);//Changed
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }
        public static void delete_cart(FlowLayoutPanel cartFlp, Label cartLabel, Label totalPriceLabel)
        {
            foreach(Control p in cartFlp.Controls)//delete the cart.
            {
                if(p is Panel)
                    cartFlp.Controls.Remove(p);
            }
            cartLabel.Text = "0";
            totalPriceLabel.Text = "0";
        }




        //Moving Through Pages
        public static void loginButton(TabPage loginPage, TabControl tabControl1)
        {
            tabControl1.SelectTab(loginPage);
        }
        public static void signUpButton(TabPage signUpPage, TabControl tabControl1)
        {
            tabControl1.SelectTab(signUpPage);
        }
        public static void signUpLabel(TabPage signUpPage, TabControl tabControl1)
        {
            tabControl1.SelectTab(signUpPage);
        }
        public static void finalSignUp(TabPage loginPage, TabControl tabControl1, Panel panel1)
        {
            tabControl1.SelectTab(loginPage);
            panel1.Focus();
        }
        public static void finalLoginButton(TabPage homePage, TabControl tabControl1)
        {
            tabControl1.SelectTab(homePage);
        }
        public static void backFromDescription(TabPage homePage, TabControl tabControl1, Panel descPanel)
        {
            tabControl1.SelectTab(homePage);
            Point pt = new Point(3, 3);
            Control c = descPanel.GetChildAtPoint(pt);//Removing table.
            descPanel.Controls.Remove(c);
        }

    }
}
