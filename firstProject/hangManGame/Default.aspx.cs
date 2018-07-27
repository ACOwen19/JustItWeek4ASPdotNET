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
        static bool quizStarted = false;

        public void resetQuiz()
        {
            ranWords.Clear();
            generateWords();
            Random rnd = new Random();
            randNum = rnd.Next(0, 10);
            answer = ranWords[randNum];
            hint = wordHints[randNum];
            answerChars = answer.ToCharArray();
            wordLength = answerChars.Length;
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
            quizStarted = false;
            
        }

        public string resetResponse()
        {
            string output = "";
            return output;
        }

        public void resetFeedback()
        {
            feedbackThumb.Attributes["class"] = "fas fa-hand-point-left";
        }


        public void generateWords()
        {
            if (catSelector.Text == "Select a category:")
            {

                ranWords.InsertRange(ranWords.Count, new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" });
                wordHints.InsertRange(wordHints.Count, new string[] { "k", "l", "m", "n", "o", "p", "q", "r", "s", "t" });
                
            }
            else if (catSelector.SelectedIndex == 1)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "queen", "fleetwood mac", "nirvana", "pink floyd", "the who", "led zeppelin", "alphaville", "smash mouth", "the doors", "the police" });
                wordHints.InsertRange(wordHints.Count, new string[] { "This band's lead singer tragically died in 1991.", "This band's album Rumors was top of the US charts for 31 weeks.", "This Seattle band helped found the Grunge movement.", "This British band, founded in 1965, have sold more than 250 Million records worldwide.", "This rock band are famous for destroying their instruments at the end of shows.", "This band were originally know as the Yardbirds.", "This german band first achived success with the single 'Big in Japan'", "This band's hit All-Star has become a popular track for re-mixes and mash-ups.", "This band's hit 'Riders on the Storm' was covered by Snoop Dog.", "This bands lead singer Sting had a successful career after they split in 1986." });
            // Bands
            }
            else if (catSelector.SelectedIndex == 2)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "green", "bluee", "yello", "redre", "orang", "indig", "viole", "orang", "indig", "viole" });
                wordHints.InsertRange(wordHints.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "orang", "indig", "viole" });
            // Historical Figures
            }
            else if (catSelector.SelectedIndex == 3)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenr", "blueer", "yellow", "redred", "orange", "indigo", "violet", "orange", "indigo", "violet" });
                wordHints.InsertRange(wordHints.Count, new string[] { "gree", "blue", "yell", "redr", "oran", "indi", "viol", "orange", "indigo", "violet" });
            // Owls   
            }
            else if (catSelector.SelectedIndex == 4)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "broncos", "raiders", "packers", "steelers", "seahawks", "saints", "redskins", "falcons", "dolphins", "jaguars" });
                wordHints.InsertRange(wordHints.Count, new string[] { "This team play at Mile High Stadium.", "This team famously played in the 'Black Hole'.", "This team won the very first Super Bowl.", "This team have won more Super Bowls than any other.", "This expansion team's 'Legion of Boom' secondary helped them win Super Bowl 48.", "This team's Super Bowl Victory in 2009 came soon after their city was devastated by Hurricane Katrina.", "This team have come under pressure to change their name in recent years.", "This team's nickname is the 'Dirty Birds'.", "This team are the only franchise to have recorded an undefeated season in the Super Bowl era.", "This Florida team's quarterback is Blake Bortles." });
            // NFL Teams 
            }
            else if (catSelector.SelectedIndex == 5)
            {
                ranWords.InsertRange(ranWords.Count, new string[] { "greenerr", "blueerrr", "yellower", "redreder", "orangerr", "indigoer", "violeter", "orangerr", "indigoer", "violeter" });
                wordHints.InsertRange(wordHints.Count, new string[] { "grese", "brlue", "yelal", "redsr", "toran", "iandi", "viaol", "orangerr", "indigoer", "violeter" });
            // Something Else
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
                                if (answerArray[i].ToString() == " ")
                                {
                                    (wordVis as Label).Text = "";
                                    answerCheck[i] = answerArray[i];
                                    (wordVis as Label).CssClass = "visLabel";
                                }
                                else
                                {
                                    (wordVis as Label).Text = "_";
                                    (wordVis as Label).CssClass = "visLabel";
                                }
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
            resetFeedback();
            resetQuiz();
            if (catSelector.Text == "Select a category:")
            {
                errorDisplay.Text = "Please select a category";
                errorPanel.Visible = true;
            }
            else
            {
                quizStarted = true;
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
            userGuess = Convert.ToChar((guess.Text).ToLower());
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
                    guessResponse.Text = "You got it! The answer was " + answer.ToUpper();
                    feedbackThumb.Attributes["class"] = "fas fa-thumbs-up";
                    guessCheck = false;
                    guessButton.Enabled = false;
                    startButton.Enabled = true;
                    startButton.Text = "Try another";

                }
                else if (dupeCheck == true)
                {
                    guessResponse.Text = "You already guessed that one";
                    feedbackThumb.Attributes["class"] = "fas fa-hand-point-left";
                    dupeCheck = false;
                    guessCheck = false;
                }
                else
                {
                    guessResponse.Text = "Well Done! Keep Guessing";
                    feedbackThumb.Attributes["class"] = "fas fa-thumbs-up";
                    guessCheck = false;
                }
            }
            else
            {
                
                dupeCheck = CheckDupe(guessedLetters.Text, guess.Text);
                if (dupeCheck)
                {
                    guessResponse.Text = "You already guessed that one";
                    feedbackThumb.Attributes["class"] = "fas fa-hand-point-left";
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
                        feedbackThumb.Attributes["class"] = "fas fa-thumbs-down"; 
                    }
                    else if (lives == 2)
                    {
                        lifeOne.Visible = false;
                        lifeTwo.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Attributes["class"] = "fas fa-thumbs-down";
                    }
                    else if (lives == 3)
                    {
                        lifeTwo.Visible = false;
                        lifeThree.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Attributes["class"] = "fas fa-thumbs-down";
                    }
                    else if (lives == 4)
                    {
                        lifeThree.Visible = false;
                        lifeFour.Visible = true;
                        guessResponse.Text = "Incorrect, guess again";
                        feedbackThumb.Attributes["class"] = "fas fa-thumbs-down";
                    }
                    else if (lives == 5)
                    {
                        lifeFour.Visible = false;
                        lifeFive.Visible = true;
                        guessButton.Enabled = false;
                        guessResponse.Text = "You lost, The answer was " + answer.ToUpper();
                        feedbackThumb.Attributes["class"] = "fas fa-thumbs-down";
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
            guessResponse.Text = "You quit, The answer was " + answer;
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
            errorPanel.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;            
        }

        protected void closeAboutButton_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            if (quizStarted == true)
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
            }
        }
    }
}