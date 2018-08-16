<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hangManGame.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hangman Game</title>
    <meta charset="utf-8" />
    <link href="https://fonts.googleapis.com/css?family=Pirata+One" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
    <link rel="stylesheet" type="text/css" href="Content/main.css" />
    <link rel="shortcut icon" href="Content/hFaviconsml.png" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="background">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <header id="navigation">
                        <asp:Button ID="startButton" CssClass="allButton" runat="server" Text="Start" OnClick="startButton_Click" />
                        <asp:Button ID="aboutButton" CssClass="allButton" runat="server" Text="About" />
                        <ajaxtoolkit:modalpopupextender id="mpe" runat="server" targetcontrolid="aboutButton" popupcontrolid="Panel3" okcontrolid="closeAboutButton" />
                        <asp:Button ID="quitButton" CssClass="allButton" runat="server" Text="Quit" OnClick="Quit_Click" />
                        <asp:DropDownList ID="catSelector" runat="server">
                            <asp:ListItem>Select a category:</asp:ListItem>
                            <asp:ListItem>Bands</asp:ListItem>
                            <asp:ListItem>Historical Figures</asp:ListItem>
                            <asp:ListItem>Owl Species</asp:ListItem>
                            <asp:ListItem>NFL Teams</asp:ListItem>
                            <asp:ListItem>Cooking Herbs</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="title" runat="server" Text="Hangman Game"></asp:Label>
                    </header>
                    <asp:Panel ID="errorPanel" runat="server" Visible="False">
                        <asp:Label ID="errorDisplay" runat="server" Text=""></asp:Label>
                    </asp:Panel>

                    <asp:Panel ID="Panel3" runat="server">

                        <h2>About this project</h2>
                        <p>This is a classic Hangman game built to demonstrate understanding of ASP.NET Webforms, HTML, C# and CSS.</p>
                        <p>To play the game:</p>
                        <ul>
                            <li>Choose a category and click Start!</li>
                            <li>Guess a letter and click the button to see if you are right.</li>
                            <li>If you guess 5 incorrect letters you lose.</li>
                            <li>Please enter letters only, there are no numbers or punctuation.</li>
                            <li>If you're struggling click the Hint button to get some help.</li>
                            <li>Click the Quit button to give up.</li>
                        </ul>
                        <asp:Button ID="closeAboutButton" runat="server" CssClass="allButton" Text="Close" />

                        <br />
                        <br />
                        <footer>Copyright &#169; Archibald Owen 2018 </footer>
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <div id="imageStack">
                            <asp:Image ID="gallows" CssClass="hangImg" src="Content/gallows.png" runat="server" Visible="True" />
                            <asp:Image ID="lifeOne" CssClass="hangImg" src="Content/lifeOne.png" runat="server" Visible="False" />
                            <asp:Image ID="lifeTwo" CssClass="hangImg" src="Content/lifeTwo.png" runat="server" Visible="False" />
                            <asp:Image ID="lifeThree" CssClass="hangImg" src="Content/lifeThree.png" runat="server" Visible="False" />
                            <asp:Image ID="lifeFour" CssClass="hangImg" src="Content/lifeFour.png" runat="server" Visible="False" />
                            <asp:Image ID="lifeFive" CssClass="hangImg" src="Content/HangGif.gif" runat="server" Visible="False" />
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panel2" runat="server" Visible="False">

                        <asp:Panel ID="visualiserLabels" runat="server">
                            <ul id="visLabels">
                                <asp:Label ID="letter0" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space1" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter1" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space2" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter2" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space3" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter3" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space4" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter4" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space5" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter5" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space6" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter6" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space7" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter7" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space8" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter8" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space9" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter9" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space10" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter10" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space11" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter11" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space12" CssClass="visLabelHidden" runat="server" Text=" "></asp:Label>
                                <asp:Label ID="letter12" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                            </ul>
                        </asp:Panel>
                        <div id="guessItems">
                            <ul id="guessLine">
                                <asp:Label ID="userInstruction" runat="server" Text="Guess a letter: "></asp:Label>
                                <asp:TextBox ID="guess" runat="server" AutoCompleteType="Disabled" MaxLength="1"></asp:TextBox>
                                <asp:Button ID="guessButton" CssClass="allButton" runat="server" Text="Guess" OnClick="guessButton_Click" />
                                <asp:Label ID="feedbackThumb" runat="server" Text="" Font-Bold="True"></asp:Label>
                            </ul>
                        </div>
                        <div>
                            <ul id="guessResponseC">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" EnableClientScript="False" ErrorMessage="Only Letters Allowed," ControlToValidate="guess" Display="Static" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                                <asp:Label ID="guessResponse" runat="server" Text=" "></asp:Label>
                                <asp:Button ID="hintButton" CssClass="allButton" runat="server" Text="Hint" OnClick="hintButton_Click" Visible="False" />
                            </ul>
                        </div>

                        <div>
                            <ul id="guessedLettersC">
                                <asp:Label ID="guessedLettersTitle" runat="server" Text="Incorrect Guesses: " Visible="false"></asp:Label>
                                <asp:Label ID="guessedLetters" runat="server" Text=""></asp:Label>
                            </ul>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </form>
</body>
</html>
