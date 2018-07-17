using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hangmanGameEmpty
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static string[] randomWords = { "greenr", "blueer", "yellow", "redred", "orange", "indigo", "violet" };
        static Random rnd = new Random();
        static int randNum = rnd.Next(0, 7);
        static string answer = randomWords[randNum];
        static int wordLength = answer.Length;
        static char[] answerChars = answer.ToCharArray();
        static string[] guessDisplay = new string[wordLength];
        static char[] answerCheck = new char[wordLength];
        static int lives = 0;
        static bool guessCheck = false;
        static bool dupeCheck = false;
        char userGuess = ' ';
        string answerMatch = "";

        static string CheckAnswer(char[] answerCheck)
        {
            string answerMatch = new string(answerCheck);
            return answerMatch;
        }

        static bool CheckDupe(string guesses, string guess)
        {
            bool output = guesses.Contains(guess);
            return output;
        }

        protected void startButton_Click(object sender, EventArgs e)
        {

            Panel1.Visible = true;
            Panel2.Visible = true;


            for (int i = 0; i < wordLength; i += 1)
            {
                guessDisplay[i] = "_     ";
                guessedLetters.Text += guessDisplay[i];
            }
        }

        protected void guessButton_Click(object sender, EventArgs e)
        {
            userGuess = Convert.ToChar(guess.Text);

            for (int i = 0; i < wordLength; i += 1)
            {
                if (userGuess == answerChars[i])
                {
                    guessCheck = true;

                    if (userGuess == answerCheck[i])
                    {
                        dupeCheck = true;
                    }

                    else
                    {

                        answerCheck[i] = answerChars[i];
                        guessDisplay[i] = guess.Text + "     ";
                        guessedLetters.Text = Convert.ToString(guessDisplay);

                    }
                }
            }
            if (guessCheck == true)
            {
                answerMatch = CheckAnswer(answerCheck);

                if (answerMatch == answer)
                {
                    guessResponse.Text = "You got it! The word was " + answer;
                    //feedback.ForeColor = Color.Green;
                    //feedback.Text = "\u00fc";
                    guessCheck = false;
                    //guessButton.Enabled = false;
                    //startButton.Visible = false;
                    //closeButton.Visible = true;

                }
                else if (dupeCheck)
                {
                    guessResponse.Text = "You already guessed that one";
                    dupeCheck = false;
                }

                else
                {
                    guessResponse.Text = "Well Done! Keep Guessing";
                    //feedback.ForeColor = Color.Green;
                    //feedback.Text = "\u00fc";
                    guessCheck = false;
                }
            }

            else
            {

                dupeCheck = CheckDupe(guessedLetters.Text, guess.Text);
                if (dupeCheck)
                {
                    guessResponse.Text = "You already guessed that one";

                }

                else
                {
                    lives += 1;

                    guessedLetters.Text += guess.Text + " ";

                    if (lives == 1)
                    {
                        gallows.Visible = false;
                        lifeOne.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        //feedback.Text = "\u00fb";
                    }
                    else if (lives == 2)
                    {
                        lifeOne.Visible = false;
                        lifeTwo.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        //feedback.Text = "\u00fb";
                    }
                    else if (lives == 3)
                    {
                        lifeTwo.Visible = false;
                        lifeThree.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        //feedback.Text = "\u00fb";
                    }
                    else if (lives == 4)
                    {
                        lifeThree.Visible = false;
                        lifeFour.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        //feedback.Text = "\u00fb";
                    }

                    else if (lives == 5)
                    {
                        lifeFour.Visible = false;
                        lifeFive.Visible = true;
                        guessButton.Enabled = false;
                        guessResponse.Text = "You lost, the word was " + answer;
                        //feedback.ForeColor = Color.PaleVioletRed;
                        //feedback.Text = "\u00fb";
                        //startButton.Visible = false;
                        //closeButton.Visible = true;
                    }
                    else
                    {
                        guessResponse.Text = "ERROR";
                    }
                }
            }

        }



    }
}