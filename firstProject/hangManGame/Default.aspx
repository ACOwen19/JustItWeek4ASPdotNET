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
                    <header id="navigation">

                        <asp:Button ID="startButton" CssClass="allButton" runat="server" Text="Start" OnClick="startButton_Click" />
                        <%-- Modify display when the button is disabled --%>
                        <asp:Button ID="scoreButton" CssClass="allButton" runat="server" Text="Scores" />
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
                        <%-- Move into center of panel 1 --%>
                        <asp:Label ID="errorDisplay" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <asp:Image ID="gallows" CssClass="hangImg" src="Content/gallowsTrans.png" runat="server" Visible="True" />
                        <asp:Image ID="lifeOne" CssClass="hangImg" src="Content/lifeOneTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeTwo" CssClass="hangImg" src="Content/lifeTwoTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeThree" CssClass="hangImg" src="Content/lifeThreeTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeFour" CssClass="hangImg" src="Content/lifeFourTrans.png" runat="server" Visible="False" />
                        <asp:Image ID="lifeFive" CssClass="hangImg" src="Content/testGifTwo.gif" runat="server" Visible="False" />
                    </asp:Panel>
                         
                    <asp:Panel ID="Panel2" runat="server" Visible="False">

                        <%--<div id="visualiser">
                            <asp:Label ID="wordLengthVisualiser" runat="server" Text=""></asp:Label></div>--%>

                        <asp:Panel ID="visualiserLabels" runat="server">
                            <ul id="visLabels">
                                <asp:Label ID="letter0" CssClass="visLabelHidden" runat="server" Text=""></asp:Label>
                                <asp:Label ID="space1" runat="server" CssClass="visLabelHidden" Text=" "></asp:Label>
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
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="only characters allowed" ControlToValidate="guess" ValidationExpression="^[A-Za-z]*$" ></asp:RegularExpressionValidator>--%>
                                <asp:Button ID="guessButton" CssClass="allButton" runat="server" Text="Guess" OnClick="guessButton_Click" />
                                 <asp:Button ID="hintButton" CssClass="allButton" runat="server" Text="Hint" OnClick="hintButton_Click" Visible="False"  />
                                <asp:Label ID="feedbackThumb" runat="server" Text=""></asp:Label>
                            </ul>
                        </div>
                        <div>
                            <ul id="guessResponseC">
                            <asp:Label ID="guessResponse" runat="server" Text=" "></asp:Label>
                           </ul>
                        </div>
                        <%-- Find Some Way of stopping this from jumping the text around --%>
                        <div >
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
