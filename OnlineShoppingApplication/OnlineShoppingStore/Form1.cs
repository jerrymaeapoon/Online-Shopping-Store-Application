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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Focus();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            //______________________Reading Ads__________________________
            item.ads(item.adsCounter, commercialPb);
            item.adsCounter++;

            //_______________Reading Categories and Creating Buttons______
            item.createCategory(categoryFlp, searchTextBox,itemFlp, panel1, item.items);
            //________________________Reading Items________________________
            item.readItems();
            foreach (KeyValuePair<string, item> kvp in item.items)
            {
                item.create(kvp.Key, kvp.Value.price.ToString(), kvp.Value.category, kvp.Value.PicPath,categoryFlp,
                    itemFlp, tabControl1, descriptionPage,  descPanel,  descName,  descPrice,  descPicture, item.items, 
                    cartLabel, cartFlp, searchTextBox, kvp.Value.category, totalPriceLabel, panel1);
            }
            //_______________________Reading Users______________________
            user.readUsers();
        }

        //___________________Handling commercials____________________
        private void showNextCommercial_Tick(object sender, EventArgs e)
        {
            item.commercial(commercialPb, item.adsCounter);
            item.adsCounter++;
        }
        //___________Handling category button All__________________
        private void allCategoryClicked(object sender, EventArgs e)
        {
            item.handlingAll(All, categoryFlp, searchTextBox, itemFlp, panel1, item.items);

        }
        //_______________________________Handling SearchTextBox_______________________________
        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            item.search_Leave(searchTextBox);
        }
        private void seacrhTextBox_Enter(object sender, EventArgs e)
        {
            item.search_Enter(searchTextBox);
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            item.search(searchTextBox, itemFlp, categoryFlp, panel1, item.items);
        }
        //___________Handling Cart___________
        private void totalPriceLabel_Click(object sender, EventArgs e)
        {
            totalPriceLabel.Text = item.total.ToString();
        }
        //____________________________Moving through pages____________________________
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginButton.Text == "Log In")
                item.loginButton(loginPage, tabControl1);
            else
                tabControl1.SelectTab(profilePage);
        }
        private void singupButton_Click(object sender, EventArgs e)
        {
            if(signupButton.Text == "Sign Up")
                item.signUpButton(signUpPage, tabControl1);
            else if(signupButton.Text =="Log Out")
            {
                user.logout(cartButton, itemFlp, addItemButton, editCategory, signupButton, loginButton,
                    tabControl1, loginPage, showNextCommercial, commercialPb, cartLabel, totalPriceLabel);

            }

        }
        private void signUpLabel_Click(object sender, EventArgs e)
        {
            item.signUpLabel(signUpPage, tabControl1);
        }
        private void finalSignUp_Click(object sender, EventArgs e)
        {
            user.signup(signupname, signupcreditcardnumber, signupmobilenumber, signupemail, signupmobilenumber, signuppassword, signupcountry,
                signupmobilecb, errorName, errorPassword, errorEmail, errorMobile, errorCreditCardNumber, errorCountry, loginPage, tabControl1, panel1);
        }
        private void finalLoginButton_Click(object sender, EventArgs e)
        {
            user.signin(signinname, signinpassword, errorLogin, profileName, profileCreditCard, profileMobile, profileEmail, profilePassword, 
                profileCountry, cartButton, itemFlp, addItemButton, editCategory, signupButton, loginButton, homePage, tabControl1,showNextCommercial,commercialPb);
        }
        private void backFromDesc_Click(object sender, EventArgs e)
        {
            item.backFromDescription(homePage, tabControl1, descPanel);
        }
        private void homePageButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(homePage);
        }
        private void cartButton_Click(object sender, EventArgs e)
        {
            if(item.isuser)
                tabControl1.SelectTab(cartPage);
        }
        //____________________________Handling MouseWheel________________________________
        private void itemMouseEnter(object sender, EventArgs e)
        {
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }
        private void itemFlp_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }
        private void categoryFlp_Enter(object sender, EventArgs e)
        {
            categoryFlp.Focus();
        }
        private void All_MouseEnter(object sender, EventArgs e)
        {
            categoryFlp.Focus();
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (categoryFlp.Focus())
            {
                categoryFlp.Focus();
            }
            else if (panel1.Focus())
            {
                panel1.Focus();
            }
            else if (itemFlp.Focus())
            {
                panel1.Focus();
            }
        }
        //__________________________Handling Cart__________________
        private void buy_Click(object sender, EventArgs e)
        {
            item.buy(cartFlp, loginButton.Text, cartLabel, totalPriceLabel, profileflp); //loginButton holds the username when he/she signs in.
        }
        //________________________Admin Change________________________________
        private void add_Click(object sender, EventArgs e)
        {
            item.add(categoryFlp, itemFlp, tabControl1, descriptionPage, descPanel, descName, descName, descPrice ,descPicture,
                item.items, cartLabel, cartFlp, searchTextBox,panel1, totalPriceLabel);
        }
        private void editCategory_Click(object sender, EventArgs e)
        {
            int size = item.categoryList.Count;
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if(item.categoryList.Count>size)//Category is added.
            {
                item.finalCreateCategory(item.categoryList.Last(), categoryFlp, searchTextBox, itemFlp, panel1, item.items);
            }
            else if(item.categoryList.Count<size)//Category is removed.
            {
                item.deleteCategory(categoryFlp, itemFlp, Form3.categoryRemove, item.items);
            }
        }

        private void addCategory_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
           // createCategory(category.Last());
        }

        private void editProfile_Click(object sender, EventArgs e)
        {
            if (editProfile.Text == "Edit")
            {
                user.edit(profilePage);
                editProfile.Text = "Save";
            }
            else if (editProfile.Text == "Save")
            {
                user.saveProfile(profileName, profileCreditCard, profileMobile, profileEmail,
                     profilePassword, profileCountry, profileMobileCb, profileErrorName, profileErrorPassword, profileErrorEmail,
                        profileErrorMobile, profileErrorCreditCard, profileErrorCountry, tabControl1, panel1, profilePage,editProfile);
            }
        }

        private void commercialPb_DoubleClick(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void cartFlp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void categoryFlp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
