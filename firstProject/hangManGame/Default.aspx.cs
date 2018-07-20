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
        static List<string> wordHints = new List<string>();
        static int randNum = 0;
        static string answer = "";
        static string hint = "";
        static int wordLength = 0;
        static char[] answerChars = new char[0];
        static string[] guessDisplay = new string[0];
        static char[] answerCheck = new char[0];
        static int lives = 0;
        static bool guessCheck = false;
        static bool dupeCheck = false;
        char userGuess = ' ';
        string answerMatch = "";

        public void resetQuiz()
        {
            ranWords.Clear();
            generateWords();
            Random rnd = new Random();
            randNum = rnd.Next(0, 10);
            answer = ranWords[randNum];
            hint = wordHints[randNum];
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
            hintButton.Visible = false;

        }

        public string resetResponse()
        {
            string output = "";
            return output;
        }

        public string resetFeedback()
        {
            string output = "&#128408";
            return output;
        }

       
        public void generateWords()
        {
            if (lengthSelector.Text == "Select a length:")
            {

                ranWords.InsertRange(ranWords.Count, new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" });
                wordHints.InsertRange(wordHints.Count, new string[] { "k", "l", "m", "n", "o", "p", "q", "r", "s", "t" });
                wordLength = 1;
            }
            else if (lengthSelector.SelectedIndex == 1)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "oran", "indi", "viol" });
                wordHints.InsertRange(wordHints.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "oran", "indi", "viol" });
                wordLength = 4;
            }
            else if (lengthSelector.SelectedIndex == 2)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "green", "bluee", "yello", "redre", "orang", "indig", "viole", "orang", "indig", "viole" });
                wordHints.InsertRange(wordHints.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "orang", "indig", "viole" });
                wordLength = 5;
            }
            else if (lengthSelector.SelectedIndex == 3)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenr", "blueer", "yellow", "redred", "orange", "indigo", "violet", "orange", "indigo", "violet" });
                wordHints.InsertRange(wordHints.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "orange", "indigo", "violet" });
                wordLength = 6;
            }
            else if (lengthSelector.SelectedIndex == 4)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenrr", "blueerr", "yellowr", "redredr", "oranger", "indigor", "violetr" });
                wordHints.InsertRange(wordHints.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "oranger", "indigor", "violetr" });
                wordLength = 7;
            }
            else if (lengthSelector.SelectedIndex == 5)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenerr", "blueerrr", "yellower", "redreder", "orangerr", "indigoer", "violeter", "orangerr", "indigoer", "violeter" });
                wordHints.InsertRange(wordHints.Count, new string[] { "grese", "brlue", "yelal", "redsr", "toran", "iandi", "viaol", "orangerr", "indigoer", "violeter" });
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

        public void UpdateVisLabels(int inputIndex, char[] answerArray)
        {
            foreach (Control wordVis in visualiserLabels.Controls)
            {

                string iCon = "letter" + Convert.ToString(inputIndex);

                if (wordVis is Label)
                {

                    if ((wordVis as Label).ID == iCon)
                    {
                        (wordVis as Label).Text = answerArray[inputIndex].ToString();
                    }
                    if (inputIndex == 99)
                    {
                        (wordVis as Label).CssClass = "visLabelHidden";
                        (wordVis as Label).Text = "";
                        for (int i = 0; i < wordLength; i += 1)
                        {
                            string iConLetter = "letter" + Convert.ToString(i);

                            if ((wordVis as Label).ID == iConLetter)
                            {
                                (wordVis as Label).Text = "_";
                                (wordVis as Label).CssClass = "visLabel";
                            }
                        }
                        for (int j = 1; j < wordLength; j += 1)
                        {
                            string iConSpace = "space" + Convert.ToString(j);

                            if ((wordVis as Label).ID == iConSpace)
                            {
                                (wordVis as Label).Text = " ";
                                (wordVis as Label).CssClass = "visLabel";
                            }
                        }
                    }
                    if ((wordVis as Label).CssClass == "visLabelHidden")
                    {
                        (wordVis as Label).Visible = false;
                    }
                    else if ((wordVis as Label).CssClass == "visLabel")
                    {
                        (wordVis as Label).Visible = true;

                    }
                }
            }
        }

        protected void startButton_Click(object sender, EventArgs e)
        {
            guessResponse.Text = resetResponse();
            guessedLetters.Text = resetResponse();
            feedbackThumb.Text = resetFeedback();
            resetQuiz();
            if (lengthSelector.Text == "Select a length:")
            {
                errorDisplay.Text = "Please select a word length";
                errorPanel.Visible = true;
            }
            else
            {
                startButton.Enabled = false;
                guessButton.Enabled = true;
                Panel1.Visible = true;
                Panel2.Visible = true;
                UpdateVisLabels(99, answerChars);
                errorDisplay.Text = "";
                errorPanel.Visible = false;
                guessResponse.Text = " ";
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
                        UpdateVisLabels(i, answerChars);
                    }
                }
            }
            if (guessCheck == true)
            {
                answerMatch = CheckAnswer(answerCheck);
                hintButton.Visible = false;
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
                    guessedLetters.Text += " " + guess.Text;
                    hintButton.Visible = true;
                    if (lives == 1)
                    {
                        gallows.Visible = false;
                        lifeOne.Visible = true;
                        
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 2)
                    {
                        lifeOne.Visible = false;
                        lifeTwo.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 3)
                    {
                        lifeTwo.Visible = false;
                        lifeThree.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 4)
                    {
                        lifeThree.Visible = false;
                        lifeFour.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Text = "&#128403";
                    }
                    else if (lives == 5)
                    {
                        lifeFour.Visible = false;
                        lifeFive.Visible = true;
                        guessButton.Enabled = false;
                        guessResponse.Text = "You lost, the word was " + answer;
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

        protected void hintButton_Click(object sender, EventArgs e)
        {
            hintButton.Visible = false;
            guessResponse.Text = hint;
        }

        protected void aboutButton_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            // if panel1/2 was visible is true then hide them but ensure that close button unhides them
        }

        protected void closeAboutButton_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
        }
    }
}