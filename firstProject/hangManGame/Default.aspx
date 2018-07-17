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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="background">
                    <header id="navigation">
                        
                        <asp:Button ID="startButton" CssClass="navButton" runat="server" Text="Start" OnClick="startButton_Click" />
                        <%-- Modify display when the button is disabled --%>
                       <asp:Button ID="scoreButton" CssClass="navButton" runat="server" Text="Scores" />
                        <asp:Button ID="quitButton" CssClass="navButton" runat="server" Text="Quit" OnClick="Quit_Click" />
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
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                   <asp:Label ID="errorDisplay" runat="server" Text=""></asp:Label>
                         </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:Image ID="gallows" CssClass="hangImg" src="Content/testOne.png" runat="server" Visible="True" />
                        <asp:Image ID="lifeOne" CssClass="hangImg" src="Content/testTwo.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeTwo" CssClass="hangImg" src="Content/testThree.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeThree" CssClass="hangImg" src="Content/testFour.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeFour" CssClass="hangImg" src="Content/testFive.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeFive" CssClass="hangImg" src="Content/testSix.png" runat="server" Visible="False" />
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="False">

                        <div id="visualiser"><asp:Label ID="wordLengthVisualiser" runat="server" Text=""></asp:Label></div>
                        <%-- Convert this into 8 labels & adjust for word length? --%>
                        <div ><ul id="guessLine"><asp:Label ID="userInstruction" runat="server" Text="Guess a letter: "></asp:Label>
                        <asp:TextBox ID="guess" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:Button ID="guessButton" runat="server" Text="Guess" OnClick="guessButton_Click" />
                        <asp:Label ID="feedbackThumb" runat="server" Text=""></asp:Label></ul></div>
                        <div><asp:Label ID="guessResponse" runat="server" Text=""></asp:Label></div>
                        <%-- Find Some Way of stopping this from jumping the background around --%>
                        <div id="guessedLettersC"><asp:Label ID="guessedLettersTitle" runat="server" Text="Incorrect Letters: "></asp:Label>
                        <asp:Label ID="guessedLetters" runat="server" Text=""></asp:Label></div>
                        </asp:Panel>
                     
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
