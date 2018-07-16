using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace staticVsDynamicDemo
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dateTimeResponse.Text = "The date and time is: " + DateTime.Now.ToString();

        }

        protected void nameButton_Click(object sender, EventArgs e)
        {
            nameDisplay.Text = "Hello " + nameEntry.Text;
        }

        protected void checkButton_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                checkBoxDisplay.Text = "The box is checked";
            }
            else
            {
                checkBoxDisplay.Text = "The box is not checked";
            }
        }

        protected void radioButton_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                radioDisplay.Text = "The button is clicked";
            }
            else
            {
                radioDisplay.Text = "The button is not clicked";
            }
        }


        protected void radioButtonTwo_Click(object sender, EventArgs e)
        {
            radioDisplayTwo.Text = "You chose " + RadioButtonList.SelectedItem + ".";

            //Alternate method

            //string radValue = RadioButtonList.SelectedValue;

            //if (radValue == "radioButOne")
            //{
            //    radioDisplayTwo.Text = "You selected button One";
            //}
            //else if (radValue == "radioButTwo")
            //{
            //    radioDisplayTwo.Text = "You selected button Two";
            //}
            //else if (radValue == "radioButThree")
            //{
            //    radioDisplayTwo.Text = "You selected button Three";
            //}
            //else
            //{
            //    radioDisplayTwo.Text = "You didn't select a button";
            //}
        }

        protected void multiTextButton_Click(object sender, EventArgs e)
        {
            // multiTextDisplay.Text = multilineBox.Text;
            string entry = multilineBox.Text;
            multiTextDisplay.Text = "You typed " + entry.Length + " characters into this box";
        }

        protected void Image1_DataBinding(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("https://www.nfl.com");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void emailButton_Click(object sender, EventArgs e)
        {
            emailDisplay.Text = "You entered a valid e-mail address";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            calenderDisplay.Text = calendarOne.SelectedDate.ToString();
        }

        protected void dropDownButton_Click(object sender, EventArgs e)
        {
            dropDownDisplay.Text = "You chose: " + DropDownList1.Text;
        }

        protected void checkBoxListButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem flavors in CheckBoxList1.Items)

                if (flavors.Selected == true)
                {
                    checkBoxListDisplay.Text += "You chose: " + flavors.Text + ".<br />";
                }
        }

        protected void listBoxButton_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string selectedColors = "";
            foreach (ListItem colors in ListBox1.Items)
            {
                if (colors.Selected == true)
                {
                    if (counter < 1)
                    {
                        selectedColors += colors.Text + " ";
                        counter += 1;
                    }
                    else
                    {
                        selectedColors += "and " + colors.Text + " ";
                    }
                }
            }
            listBoxDisplay.Text = "You chose: " + selectedColors + "as your colors.";
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (hiddenCheckbox.Checked == true)
            {
                hiddenPanel.Visible = true;
                hiddenCheckbox.Text = "Hide the Panel";
            }
            else if(hiddenCheckbox.Checked == false)
            {
                hiddenPanel.Visible = false;
                hiddenCheckbox.Text = "Unhide the Panel";
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            wizardDisplay.Text += "Deck name: "+ deckName.Text;
            int counter = 0;
            string selectedColors = "";
            foreach (ListItem colors in deckColor.Items)
            {
                if (colors.Selected == true)
                {
                    if (counter < 1)
                    {
                        selectedColors += colors.Text;
                        counter += 1;
                    }
                    else
                    {
                        selectedColors += "/" + colors.Text;
                    }
                }
            }
            wizardDisplay.Text += "<br />Deck color(s): " + selectedColors;

            wizardDisplay.Text += "<br />Deck Speed: " + deckSpeed.SelectedItem;

            Wizard1.Visible = false;

        }

        protected void Circle_Click(object sender, ImageMapEventArgs e)
        {
            string selection = e.PostBackValue;

            if (selection == "circle") {
                imageMapDisplay.Text = "This is the circle";

            }
            else if(selection == "rectangle"){
                imageMapDisplay.Text = "This is the rectangle";
            }
            else if (selection == "triangle")
            {
                imageMapDisplay.Text = "This is the triangle";
            }


        }

       
    }
}