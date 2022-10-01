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
    public class user
    {
        public string password, mobilenumber, creditcardnumb, country, email;
        public static Dictionary<string, user> users = new Dictionary<string, user>();
        public static Dictionary<string, List<string>> boughtdata = new Dictionary<string, List<string>>();//key=user mail,list of sturct (bought)
        //Reading  and Writing users
        public static void readUsers()
        {
            user obj = new user();
            List<string> extra= File.ReadLines("us.txt").ToList();//The whole file is copied to this extra list.
            foreach (string line in extra)//Dividng 'users' list to Lines.
            {
                string[] token = line.Split(',');//Dividing each line.
                obj.password = token[1];
                obj.email = token[2];
                obj.creditcardnumb = token[3];
                obj.country = token[4];
                obj.mobilenumber = token[5];
                users[token[0]] = obj;
            }
        }
        //
        //
        //
        public static void appendUser(string s, user obj)
        {
            using (StreamWriter write = File.AppendText("us.txt"))
            {
                write.WriteLine(s + "," + obj.password + "," + obj.email + "," + obj.creditcardnumb + "," + obj.country + "," + obj.mobilenumber);
            }
        }
        //
        //
        //
        public static void writeAllUsers()
        {
            using (StreamWriter write = new StreamWriter("us.txt"))
            {
                foreach (KeyValuePair<string, user> kvp in users)
                {
                    write.WriteLine(kvp.Key + "," + kvp.Value.password + "," + kvp.Value.email + "," + kvp.Value.creditcardnumb + "," + kvp.Value.country + "," + kvp.Value.mobilenumber);

                }
            }
        }
        //Handling Sign in
        public static void signin(TextBox signinname, TextBox signinpassword, Label errorLogin, TextBox profilename, 
            TextBox profilecreditcard, TextBox profilemobile, TextBox profileemail, TextBox profilepassword, ComboBox profilecountry,
            PictureBox cartButton, FlowLayoutPanel itemFlp, Button addButton, Button editCategory, Button signupButton, Button signinButton,
            TabPage homePage, TabControl tabControl1, Timer timer, PictureBox commercialPb)
        {
            {
                user getObj;
                if (signinname.Text == "Admin" && signinpassword.Text == "Admin")
                {
                    item.isuser = false;
                    item.isadmin = true;
                    signinname.Text = "";
                    signinpassword.Text = "";
                    loadAdmin(cartButton, itemFlp, addButton, editCategory, signupButton, signinButton, timer, commercialPb);
                    item.finalLoginButton(homePage, tabControl1);
                    errorLogin.Visible = false;
                }

                else if (users.TryGetValue(signinname.Text, out getObj))
                {
                    if (signinpassword.Text == getObj.password)
                    {
                        createprofile(signinname.Text, profilename, profilecreditcard, profileemail, profilemobile, profilepassword, profilecountry);
                        item.isuser = true;
                        item.isadmin = false;
                        loadUser(cartButton, itemFlp, addButton, editCategory, signupButton, signinButton,signinname.Text, timer, commercialPb);
                        item.finalLoginButton(homePage, tabControl1);
                        signinname.Text = "";
                        signinpassword.Text = "";
                        errorLogin.Visible = false;

                    }
                    else
                    {
                        errorLogin.Visible = true;
                        errorLogin.Text = "Please check username or password!";
                    }
                }
                else
                {
                    errorLogin.Visible = true;
                    errorLogin.Text = "Please check username or password!";
                }
            }
        }
        //______________Handling SignUp________________

        //_________________Checking if Valid input_____________________
        public static bool checkUser(TextBox name, TextBox creditcard, TextBox mobilenumber, TextBox email, TextBox password,
            ComboBox country, ComboBox mobilecb, Label errorName, Label errorPassword, Label errorEmail, Label errorMobile, Label errorCreditCardNumber,
            Label errorCountry, TabPage loginPage, TabControl tabControl1, Panel panel1, bool isAdd)
        {
            user obj = new user();
            string s = email.Text;
            if (isAdd)
            {
                if (name.Text == "")
                {
                    errorName.Text = "You must have a name!";
                    errorName.Visible = true;
                }
                else
                {
                    if (users.ContainsKey(name.Text))
                    {
                        errorName.Text = "This name is already taken!";
                        errorName.Visible = true;
                    }
                    else
                        errorName.Visible = false;
                }
            }

            if (password.Text == "")
            {
                errorPassword.Text = "You must write a password!";
                errorPassword.Visible = true;
            }
            else
                errorPassword.Visible = false;


            if (email.Text == "")
            {
                errorEmail.Text = "You must provide your email!";
                errorEmail.Visible = true;
            }
            else if (email.Text.Length <= 10)
            {
                errorEmail.Text = "Unacceptatble E-mail";
                errorEmail.Visible = true;
            }
            else if (email.Text.Length >= 12)
            {
                if (email.Text.Substring(email.Text.Length - 12).ToLower() == "@outlook.com" || email.Text.Substring(email.Text.Length - 12).ToLower() == "@hotmail.com"
                    || email.Text.Substring(email.Text.Length - 10).ToLower() == "@gmail.com" || email.Text.Substring(email.Text.Length - 10).ToLower() == "@yahoo.com")
                { errorEmail.Visible = false; }
                else
                {
                    errorEmail.Text = "Unacceptatble E-mail";
                    errorEmail.Visible = true;
                }
            }
            else if (email.Text.Length > 10)
            {
                if (email.Text.Substring(email.Text.Length - 10).ToLower() == "@gmail.com" || email.Text.Substring(email.Text.Length - 10).ToLower() == "@yahoo.com")
                { errorEmail.Visible = false; }
                else
                {
                    errorEmail.Text = "Unacceptatble E-mail";
                    errorEmail.Visible = true;
                }
            }
            if (mobilenumber.Text == "")
            {
                errorMobile.Text = "Missing phone number!";
                errorMobile.Visible = true;
            }
            else if (mobilenumber.Text.Length < 9 || mobilenumber.Text.Length > 9)
            {
                errorMobile.Text = "Unacceptable phone number!";
                errorMobile.Visible = true;
            }
            else
                errorMobile.Visible = false;
            if (creditcard.Text == "")
            {
                errorCreditCardNumber.Text = "You must provide credit card number";
                errorCreditCardNumber.Visible = true;
            }
            else if (true)//Edit
            {

            }
            else
                errorCreditCardNumber.Visible = false;
            if (country.Text == "")
            {
                errorCountry.Text = "You must provide Country!";
                errorCountry.Visible = true;
            }
            else
                errorCountry.Visible = false;
            if (!errorName.Visible && !errorPassword.Visible && !errorMobile.Visible && !errorCreditCardNumber.Visible && !errorCountry.Visible && !errorEmail.Visible)
            {
                //Form1.users[name.Text] = obj;
                return true;
            }
            else
                return false;
        }
        //
        //If Valid Input
        //
        public static bool isAdd = false;
        public static void signup(TextBox signupname, TextBox signupcreditcard, TextBox signupmobilenumber, TextBox signupemail,
            TextBox signupmobile, TextBox signuppassword, ComboBox signupcountry, ComboBox signupmobilecb, Label errorName, Label errorPassword,
            Label errorEmail, Label errorMobile, Label errorCreditCardNumber, Label errorCountry, TabPage loginPage, TabControl tabControl1, Panel panel1)
        {
            isAdd = true;
            user obj = new user();
            if (checkUser(signupname, signupcreditcard, signupmobilenumber, signupemail,
                signuppassword, signupcountry, signupmobilecb, errorName, errorPassword,
                errorEmail, errorMobile, errorCreditCardNumber, errorCountry, loginPage, tabControl1, panel1, isAdd))
            {
                obj.password = signuppassword.Text;
                obj.mobilenumber = signupmobilecb.Text + signupmobile.Text;
                obj.country = signupcountry.Text;
                obj.creditcardnumb = signupcreditcard.Text;
                obj.email = signupemail.Text;

                users.Add(signupname.Text, obj);
                appendUser(signupname.Text, obj);
                item.finalSignUp(loginPage, tabControl1, panel1);

                signuppassword.Text = "";
                signupmobilecb.Text = "";
                signupmobile.Text = "";
                signupcountry.Text = "";
                signupcreditcard.Text = "";
                signupemail.Text = "";
                signupname.Text = "";
            }
        }
        //______________Handling Profile_______________________
        public static void createprofile(string s, TextBox profilename, TextBox profilecreditcard, TextBox profileemail, TextBox profilemobile, 
            TextBox profilepassword, ComboBox profilecountry )
        {
            profilename.Text = s;
            user objUser = new user();
            objUser = users[s];
            profilecountry.Text = objUser.country;
            profilecreditcard.Text = objUser.creditcardnumb;
            profileemail.Text = objUser.email;
            profilemobile.Text = objUser.mobilenumber;
            profilepassword.Text = objUser.password;
        }
        public static void display_profile(FlowLayoutPanel profileflp)
        {
            string name = null;
            string[] arr;
            try
            {
                List<string> lines = File.ReadAllLines("Cart.txt").ToList();
                List<string> extra = new List<string>();
                foreach (string line in lines)
                {
                    item objItem = new item();

                    arr = line.Split(',');
                    name = arr[0];
                    for(int i =1; i< arr.Length; i++)
                    {
                        extra.Add(arr[i]);
                    }
                    boughtdata[name] = extra;
                }
            }
            catch { MessageBox.Show("Error"); }

            foreach(KeyValuePair <string, item> kvp in item.usercart)
            {

                Label n = new Label();
                Label prc = new Label();
                PictureBox picbox = new PictureBox();

                n.Text = kvp.Key;
                prc.Text = item.usercart[name].price.ToString();
                picbox.Size = new Size(174, 156);
                picbox.BackgroundImage = Image.FromFile(item.usercart[name].PicPath);
                picbox.BackgroundImageLayout = ImageLayout.Stretch;

                n.Location = new Point(250, 51);
                n.Font = new Font("Microsoft Sans Serif", 18);
                prc.Font = new Font("Microsoft Sans Serif", 18);
                prc.Location = new Point(380, 49);
                picbox.Location = new Point(3, 3);
                picbox.Size = new Size(210, 109);

                Panel panelcart;
                panelcart = new Panel();
                panelcart.Margin = new Padding(3, 3, 3, 3);
                panelcart.BackColor = Color.LightGray;
                panelcart.Size = new Size(639, 124);
                panelcart.Location = new Point(3, 3);

                panelcart.Controls.Add(n);
                panelcart.Controls.Add(prc);
                panelcart.Controls.Add(picbox);
                profileflp.Controls.Add(panelcart);

            }

        }

    
        //To make profile ready to be edited__________Enabling the textboxes to be written on it________
        public static void edit(TabPage profilePage)
        {
            foreach (Control c in profilePage.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Name != "profileName")
                        c.Enabled = true;
                }
                else if (c is Panel && c.BackColor == Color.FromArgb(0, 96, 213))
                {
                    if (c.Name != "panelName")
                        c.Visible = true;
                }
                else if (c is ComboBox)
                    c.Enabled = true;
            }
        }
        //___________Saving profile after editing on it at the profile page___________________
        public static void saveProfile(TextBox profilename, TextBox profilecreditcard, TextBox profilemobilenumber, TextBox profileemail,
            TextBox profilepassword, ComboBox profilecountry, ComboBox profilemobilecb, Label errorName, Label errorPassword, Label errorEmail,
            Label errorMobile, Label errorCreditCardNumber, Label errorCountry, TabControl tabControl1, Panel panel1, TabPage profilePage, Button b)
        {
            isAdd = false;
            user objUser = new user();
            if (checkUser(profilename, profilecreditcard, profilemobilenumber, profileemail,
                profilepassword, profilecountry, profilemobilecb, errorName, errorPassword,
                 errorEmail, errorMobile, errorCreditCardNumber, errorCountry, profilePage, tabControl1, panel1, isAdd))
            {
                objUser.password = profilepassword.Text;
                objUser.mobilenumber = profilemobilenumber.Text;
                objUser.email = profileemail.Text;
                objUser.country = profilecountry.Text;
                objUser.creditcardnumb = profilecreditcard.Text;
                users[profilename.Text] = objUser;
                writeAllUsers();
                foreach (Control c in profilePage.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c.Name != "profileName")
                            c.Enabled = false;
                    }
                    else if (c is Panel && c.BackColor == Color.FromArgb(0, 96, 213))
                    {
                        if (c.Name != "panelName")
                            c.Visible = false;
                    }
                    else if(c is ComboBox)
                    {
                        c.Enabled = false;
                    }
                }
                b.Text = "Edit";
            }
        }
        //________If User, then make the program to be ready for a user_____________
        public static void loadUser(PictureBox cartButton, FlowLayoutPanel itemFlp, Button addButton,
            Button editCategory, Button signupButton, Button signinButton, string userName, Timer timer,
            PictureBox commercialPb)
        {
            cartButton.Enabled = true;
            addButton.Visible = false;
            editCategory.Visible = false;
            foreach (Control p in itemFlp.Controls)
            {
                if (p.BackColor == Color.LightGray)
                {
                    foreach(Control c in p.Controls)
                    {
                        if(c is Button)
                        {
                            if (c.Text == "E")
                                c.Visible = false;
                            else if (c.Text == "X")
                                c.Visible = false;
                        }
                    }
                }
            }
            signinButton.Enabled = true;
            //timer.Enabled = true;
            commercialPb.Enabled = false;
            signupButton.Text = "Log Out";
            signinButton.Text = userName;
            signinButton.BackColor = Color.FromArgb(29, 28, 29);
            signinButton.ForeColor = Color.White;
        }
        //_____________If Admin, then make the program be ready for an admin____________
        public static void loadAdmin(PictureBox cartButton, FlowLayoutPanel itemFlp, Button addButton,
            Button editCategory, Button signupButton, Button signinButton, Timer timer, PictureBox commercialPb)
        {
            cartButton.Enabled = false;
            addButton.Visible = true;
            editCategory.Visible = true;
            foreach (Control p in itemFlp.Controls)
            {
                foreach (Control c in p.Controls)
                {
                    if (c is Button)
                    {
                        if (c.Text == "E")
                            c.Visible = true;
                        else if (c.Text == "X")
                            c.Visible = true;
                    }
                }
            }
            timer.Enabled = false;
            commercialPb.Enabled = true;
         //   commercialPb.BackgroundImage = Image.FromFile(@"C:\Users\Dina\Pictures\Snipping Tool\addComercial.png");
            signupButton.Text = "Log Out";
            signinButton.BackColor = Color.FromArgb(255, 192, 192);
            signinButton.Text = "Admin";
            signinButton.Enabled = false; //Edit
        }
        //___________Logging out makes the program ready to be on the default mode___________
        public static void logout(PictureBox cartButton, FlowLayoutPanel itemFlp, Button addButton, Button editCategory, Button signupButton,
            Button signinButton, TabControl tabControl1, TabPage loginPage, Timer timer, PictureBox commercialPb, Label cartLabel, Label totalPriceLabel)
        {
            cartButton.Enabled = true;
            addButton.Visible = false;
            editCategory.Visible = false;
            foreach (Control p in itemFlp.Controls)
            {
                if (p.BackColor == Color.LightGray)
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is Button)
                        {
                            if (c.Text == "E")
                                c.Visible = false;
                            else if (c.Text == "X")
                                c.Visible = false;
                        }
                    }
                }
            }
            timer.Enabled = true;
            commercialPb.Enabled = false;
            commercialPb.BackgroundImage = Image.FromFile(item.commercials[0]);
            item.isadmin = false;
            item.isuser = false;
            signupButton.Text = "Sign Up";
            signinButton.Text = "Log In";
            signinButton.BackColor = Color.FromArgb(29, 28, 29);
            signinButton.Enabled = true;
            tabControl1.SelectTab(loginPage);
            cartLabel.Text = "0";
            totalPriceLabel.Text = "0";
        }
    }
    
}
