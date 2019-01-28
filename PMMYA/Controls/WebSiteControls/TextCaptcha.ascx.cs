using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class TextCaptcha : System.Web.UI.UserControl
    {
        public static string ntextanswer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (IsEven() == true)
                {
                    lblRandomNo.Text = questiongenerate2();
                    lblRandomNo2.Text = genstring1() + ", " + genstring2() + ", " + genstring3();
                    Label1.Text = genstring1();
                    Label2.Text = genstring2();
                    Label3.Text = genstring3();
                }

                else if (IsEven() == false)
                {
                    lblRandomNo.Text = questiongenerate1();
                    lblRandomNo2.Text = gen() + ", " + gen1() + ", " + gen2();
                    Label1.Text = gen();
                    Label2.Text = gen1();
                    Label3.Text = gen2();
                }

                else
                {
                    lblRandomNo.Text = questiongenerate1();
                    lblRandomNo2.Text = gen() + ", " + gen1() + ", " + gen2();
                    Label1.Text = gen();
                    Label2.Text = gen1();
                    Label3.Text = gen2();
                }


            }
        }

        public void RefreshQuestion()
        {
            if (IsEven() == true)
            {
                lblRandomNo.Text = questiongenerate2();
                ViewState["lblRandom"] = lblRandomNo.Text;
                lblRandomNo2.Text = genstring1() + ", " + genstring2() + ", " + genstring3();
                Label1.Text = genstring1();
                Label2.Text = genstring2();
                Label3.Text = genstring3();

            }
            else if (IsEven() == false)
            {
                lblRandomNo.Text = questiongenerate1();
                ViewState["lblRandom"] = lblRandomNo.Text;
                lblRandomNo2.Text = gen() + ", " + gen1() + ", " + gen2();
                Label1.Text = gen();
                Label2.Text = gen1();
                Label3.Text = gen2();
            }
            else
            {
                lblRandomNo.Text = questiongenerate1();
                ViewState["lblRandom"] = lblRandomNo.Text;
                lblRandomNo2.Text = gen() + ", " + gen1() + ", " + gen2();
                Label1.Text = gen();
                Label2.Text = gen1();
                Label3.Text = gen2();
            }
            ntextanswer = lblRandomNo2.Text;
        }
        private bool IsEven()
        {
            int[] words = new int[] { 8, 9, 2, 3, 4, 5 };
            Random random = new Random();
            int firstRandomWord = words[random.Next(0, words.Length)];

            if (firstRandomWord % 2 == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public string genstring1()
        {
            string[] words = new string[] { "g56", "wfjn", "ihe", "dg0" };
            Random random = new Random();
            string firstRandomWord = words[random.Next(0, words.Length)];
            string secondRandomWord;
            do
            {
                secondRandomWord = words[random.Next(0, words.Length)];
            }
            while (secondRandomWord == firstRandomWord);
            string randomNumber = random.Next(0, 10).ToString().PadLeft(2, '0');
            string magicWord = String.Concat(firstRandomWord, secondRandomWord, randomNumber);
            return magicWord;
        }


        public string genstring2()
        {
            string[] words = new string[] { "uc", "w8r", "u657", "56c" };
            Random random = new Random();
            string firstRandomWord = words[random.Next(0, words.Length)];
            string secondRandomWord;
            do
            {
                secondRandomWord = words[random.Next(0, words.Length)];
            }
            while (secondRandomWord == firstRandomWord);
            string randomNumber = random.Next(0, 30).ToString().PadLeft(2, '0');
            string magicWord = String.Concat(firstRandomWord, secondRandomWord, randomNumber);
            return magicWord;
        }

        public string genstring3()
        {
            string[] words = new string[] { "su6", "w4r", "icmp" };
            Random random = new Random();
            string firstRandomWord = words[random.Next(0, words.Length)];
            string secondRandomWord;
            do
            {
                secondRandomWord = words[random.Next(0, words.Length)];
            }
            while (secondRandomWord == firstRandomWord);
            string randomNumber = random.Next(0, 99).ToString().PadLeft(2, '0');
            string magicWord = String.Concat(firstRandomWord, secondRandomWord, randomNumber);
            return magicWord;
        }


        public string gen()
        {
            int[] words = new int[] { 729, 599, 307, 688, 885, 436, 83, 402, 791, 009 };
            Random random = new Random();
            int firstRandomWord = words[random.Next(0, words.Length)];
            int secondRandomWord;
            do
            {
                secondRandomWord = words[random.Next(0, words.Length)];
            }
            while (secondRandomWord == firstRandomWord);
            // string randomNumber = random.Next(0, 99).ToString().PadLeft(2, '0');
            string magicWord = String.Concat(firstRandomWord, secondRandomWord);
            return magicWord;
        }

        public string gen1()
        {
            int[] words = new int[] { 109, 110, 674, 702, 809, 987, 284, 398, 481, 532 };
            Random random = new Random();
            int firstRandomWord = words[random.Next(0, words.Length)];
            int secondRandomWord;
            do
            {
                secondRandomWord = words[random.Next(0, words.Length)];
            }
            while (secondRandomWord == firstRandomWord);
            // string randomNumber = random.Next(0, 99).ToString().PadLeft(2, '0');
            string magicWord = String.Concat(firstRandomWord, secondRandomWord);
            return magicWord;
        }
        public string gen2()
        {
            int[] words = new int[] { 507, 519, 802, 833, 994, 051, 660, 749, 680, 490 };
            Random random = new Random();
            int firstRandomWord = words[random.Next(0, words.Length)];
            int secondRandomWord;
            do
            {
                secondRandomWord = words[random.Next(0, words.Length)];
            }
            while (secondRandomWord == firstRandomWord);
            // string randomNumber = random.Next(0, 99).ToString().PadLeft(2, '0');
            string magicWord = String.Concat(firstRandomWord, secondRandomWord);
            return magicWord;
        }
        public string questiongenerate1()
        {
            //string[] words = new string[] { "What is First Number among Following List", "What is Second Number among Following List", "What is Third Number among Following List",  "What is Min Number among Following List", "What is Max Number among Following List" };

            string[] words = new string[] { "Re-Type the First Number among Following List", "Re-Type the Second Number among Following List", "Re-Type the is Third Number among Following List" };
            Random random = new Random();
            string firstRandomWord = words[random.Next(0, words.Length)];

            string magicWord = String.Concat(firstRandomWord);

            return magicWord;


        }

        public string questiongenerate2()
        {
            //string[] words = new string[] { "What is First Number among Following List", "What is Second Number among Following List", "What is Third Number among Following List",  "What is Min Number among Following List", "What is Max Number among Following List" };

            string[] words = new string[] { "Re-Type the First word among Following List", "Re-Type the Second word among Following List", "Re-Type the Third word among Following List" };
            Random random = new Random();
            string firstRandomWord = words[random.Next(0, words.Length)];

            string magicWord = String.Concat(firstRandomWord);

            return magicWord;


        }
        public int getresult1()
        {
            string[] words = new string[] { "Re-Type the First Number among Following List", "Re-Type the Second Number among Following List", "Re-Type the Third Number among Following List" };
            int index2 = Array.IndexOf(words, lblRandomNo.Text);
            return index2;
        }
        public int getresult2()
        {
            string[] words = new string[] { "Re-Type the First word among Following List", "Re-Type the Second word among Following List", "Re-Type the Third word among Following List" };
            int index2 = Array.IndexOf(words, lblRandomNo.Text);
            return index2;
        }
        public bool ISCorrect()
        {
            if (getresult1() == 0)
            {
                if (Label1.Text == txtCaptchAnswer.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            else if (getresult1() == 1)
            {
                if (Label2.Text == txtCaptchAnswer.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (getresult1() == 2)
            {
                if (Label3.Text == txtCaptchAnswer.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (getresult2() == 0)
            {
                if (Label1.Text == txtCaptchAnswer.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (getresult2() == 1)
            {
                if (Label2.Text == txtCaptchAnswer.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (getresult2() == 2)
            {
                if (Label3.Text == txtCaptchAnswer.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
                return false;
        }




        protected void btnSubmittt_Click(object sender, EventArgs e)
        {
            // btnSubmittt_ClicktectCapcha(sender, e);
            Insert();

        }





        public bool Insert()
        {
            if (ISCorrect() == true)
            {
                //lbl_msg.Text = "Success";
                lbl_msg.ForeColor = System.Drawing.Color.Green;
                return true;
            }

            else
            {
                lbl_msg.Text = "Please Enter Correct Answer";
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ISCorrect();
            //Insert();
        }

        protected void btnRefreshCaptcha_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

        }
    }
}