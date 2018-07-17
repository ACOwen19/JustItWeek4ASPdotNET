using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hangManGame
{
    public partial class WebForm1 : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }



        static List<string> ranWords = new List<string>();
        static int randNum = 0;
        static string answer = "";
        static int wordLength = 0;
        static char[] answerChars = new char[0];
        static string[] guessDisplay = new string[0];
        static char[] answerCheck = new char[0];
        static int lives = 0;
        static bool guessCheck = false;
        static bool dupeCheck = false;
        char userGuess = ' ';
        string answerMatch = "";
        
        public void resetQuiz(){
            ranWords.Clear();
            generateWords();
            Random rnd = new Random();
            randNum = rnd.Next(0, wordLength+1);
            answer = ranWords[randNum];
            answerChars = answer.ToCharArray();
            guessDisplay = new string[wordLength];
            answerCheck = new char[wordLength];
            answerMatch = "";
            userGuess = ' ';
            gallows.Visible = true;
            lifeOne.Visible = false;
            lifeTwo.Visible = false;
            lifeThree.Visible = false;
            lifeFour.Visible = false;
            lifeFive.Visible = false;
            lives = 0;
            
        }

        public string resetResponse()
        {
            string output = " ";
                return output;
        }

        public void generateWords()
        {
            if (lengthSelector.Text == "Select a length:")
            {
                
                ranWords.InsertRange(ranWords.Count, new string[] { "x" });
                wordLength = 1;
            }
            else if (lengthSelector.SelectedIndex == 1)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol" });
                wordLength = 4;
            }
            else if (lengthSelector.SelectedIndex == 2)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "green", "bluee", "yello", "redre", "orang", "indig", "viole" });
                wordLength = 5;
            }
            else if (lengthSelector.SelectedIndex == 3)
            {
               ranWords.InsertRange(ranWords.Count, new string[] { "greenr", "blueer", "yellow", "redred", "orange", "indigo", "violet" });
               wordLength = 6;
            }
            else if (lengthSelector.SelectedIndex == 4)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenrr", "blueerr", "yellowr", "redredr", "oranger", "indigor", "violetr" });
                wordLength = 7;
            }
            else if (lengthSelector.SelectedIndex == 5)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenerr", "blueerrr", "yellower", "redreder", "orangerr", "indigoer", "violeter" });
                wordLength = 8;
            }

        }

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

        private string updateGuessDisplay(string[] guessDisplayArray, int inputIndex, char[] answerArray)
        {
            string guessDisplayOutput = "";
            
            for (int i = 0; i < wordLength; i += 1)
            {


                if (i == inputIndex)
                {
                    guessDisplayArray[i] = answerArray[i].ToString() + "     ";
                }

                else if (inputIndex == 99)
                {
                    guessDisplayArray[i] = "_     ";
                    
                }

                guessDisplayOutput += guessDisplayArray[i];

            }

            return guessDisplayOutput;
        }

        protected void startButton_Click(object sender, EventArgs e)
        {
            guessResponse.Text = resetResponse();
            guessedLetters.Text = resetResponse();
            feedbackThumb.Text = resetResponse();
            resetQuiz();
            if (lengthSelector.Text == "Select a length:")
            {
                errorDisplay.Text = "Please select a word length";
                Panel3.Visible = true;
            }
            else
            {
                startButton.Enabled = false;
                guessButton.Enabled = true;
                Panel1.Visible = true;
                Panel2.Visible = true;
                wordLengthVisualiser.Text = updateGuessDisplay(guessDisplay, 99, answerChars);
                errorDisplay.Text = "";
                Panel3.Visible = false;
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
                        wordLengthVisualiser.Text = updateGuessDisplay(guessDisplay, i, answerChars);


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
                    feedbackThumb.Text = "&#128402";
                    guessCheck = false;
                    guessButton.Enabled = false;
                    
                    startButton.Enabled = true;
                    startButton.Text = "Try another";
                   
                }
                else if (dupeCheck == true)
                {
                    guessResponse.Text = "You already guessed that one";
                    feedbackThumb.Text = "&#128401";
                    dupeCheck = false;
                    guessCheck = false;
                }

                else
                {
                    guessResponse.Text = "Well Done! Keep Guessing";
                    //feedback.ForeColor = Color.Green;
                    feedbackThumb.Text = "&#128402";
                    guessCheck = false;
                }
            }

            else
            {

                dupeCheck = CheckDupe(guessedLetters.Text, guess.Text);
                if (dupeCheck)
                {
                    guessResponse.Text = "You already guessed that one";
                    feedbackThumb.Text = "&#128401";

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
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 2)
                    {
                        lifeOne.Visible = false;
                        lifeTwo.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 3)
                    {
                        lifeTwo.Visible = false;
                        lifeThree.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 4)
                    {
                        lifeThree.Visible = false;
                        lifeFour.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        //feedback.ForeColor = Color.Red;
                        feedbackThumb.Text = "&#128403";
                    }

                    else if (lives == 5)
                    {
                        lifeFour.Visible = false;
                        lifeFive.Visible = true;
                        guessButton.Enabled = false;
                        guessResponse.Text = "You lost, the word was " + answer;
                        //feedback.ForeColor = Color.PaleVioletRed;
                        feedbackThumb.Text = "&#128403";

                        startButton.Enabled = true;
                        startButton.Text = "Try again";
                        
                    }
                    else
                    {
                        guessResponse.Text = "ERROR";
                    }
                }
            }
            guess.Text = "";
        }

        protected void Quit_Click(object sender, EventArgs e)
        {
          
            gallows.Visible = false;
            lifeOne.Visible = false;
            lifeTwo.Visible = false;
            lifeThree.Visible = false;
            lifeFour.Visible = false;
            lifeFive.Visible = true;
            guessButton.Enabled = false;
            guessResponse.Text = "You quit, the word was " + answer;
            startButton.Enabled = true;
            startButton.Text = "Try again";
        }
    }
}