<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hangManGame.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hangman Game</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="Content/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        

        <div id="background">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

            <header id="navigation">

                <asp:Button ID="startButton" CssClass="allButton" runat="server" Text="Start" OnClick="startButton_Click" />
                <%-- Modify display when the button is disabled --%>
                <asp:Button ID="aboutButton" CssClass="allButton" runat="server" Text="About" OnClick="aboutButton_Click" />
                <asp:Button ID="quitButton" CssClass="allButton" runat="server" Text="Quit" OnClick="Quit_Click" />
                <asp:DropDownList ID="lengthSelector" runat="server">
                    <asp:ListItem>Select a length:</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="title" runat="server" Text="Hangman Game"></asp:Label>
            </header>
            <asp:Panel ID="errorPanel" runat="server" Visible="False">
                <asp:Label ID="errorDisplay" runat="server" Text=""></asp:Label>
            </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <h2>About this project</h2>
                        <p>This is a classic Hangman game built to demonstrate understanding of ASP.NET Webforms, HTML, C# & CSS.</p>
                        <p>To play the game:</p>
                        <ul>
                           <li>Choose a subject and click start!</li>
                            <li>Guess a letter and click the button to see if you are right.</li>
                            <li>You can guess 5 incorrect letters before you lose.</li>
                          <li>If you're struggling click the hint button to get some help.</li>
                          <li>Click the quit button to give up.</li>
                        </ul>
                        <asp:Button ID="closeAboutButton" runat="server" CssClass="allButton" Text="Close" OnClick="closeAboutButton_Click" />
                        <footer> Copyright &#169; Archibald Owen 2018 </footer>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:Image ID="gallows" CssClass="hangImg" src="Content/gallowsTrans.png" runat="server" Visible="True" />
                        <asp:Image ID="lifeOne" CssClass="hangImg" src="Content/lifeOneTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeTwo" CssClass="hangImg" src="Content/lifeTwoTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeThree" CssClass="hangImg" src="Content/lifeThreeTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeFour" CssClass="hangImg" src="Content/lifeFourTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeFive" CssClass="hangImg" src="Content/testGifTwo.gif" runat="server" Visible="False" />
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
                            </ul>
                        </asp:Panel>
                        <div>
                            <ul id="guessLine">
                                <asp:Label ID="userInstruction" runat="server" Text="Guess a letter: "></asp:Label>
                                <asp:TextBox ID="guess" runat="server" AutoCompleteType="Disabled" MaxLength="1"></asp:TextBox>
                                <asp:Button ID="guessButton" CssClass="allButton" runat="server" Text="Guess" OnClick="guessButton_Click" />
                                <asp:Label ID="feedbackThumb" runat="server" Text="" Font-Bold="True"></asp:Label>
                            </ul>
                        </div>
                        <div>
                            <ul id="guessResponseC">
                                <asp:Label ID="guessResponse" runat="server" Text=" "></asp:Label>
                                <asp:Button ID="hintButton" CssClass="allButton" runat="server" Text="Hint" OnClick="hintButton_Click" Visible="False" />
                            </ul>
                        </div>
                        <%-- Find Some Way of stopping this from jumping the text around --%>
                        <div>
                            <ul id="guessedLettersC">
                                <asp:Label ID="guessedLettersTitle" runat="server" Text="Incorrect Letters: "></asp:Label>
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
