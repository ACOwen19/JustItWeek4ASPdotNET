<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hangManGame.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <header>

                <asp:Button ID="startButton" runat="server" Text="Start" OnClick="startButton_Click" />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server" Text="Hangman Game"></asp:Label>
                <asp:Button ID="Button2" runat="server" Text="Scores" />
                <asp:Button ID="Button3" runat="server" Text="Give Up" />

            </header>

            <asp:Panel ID="Panel1" runat="server" Height="234px" Width="868px" Visible="False">
                <asp:Image ID="gallows" src="Content/testOne.png" runat="server" Visible="True" />
                <asp:Image ID="lifeOne" src="Content/testTwo.png" runat="server" Visible="False" />
                <asp:Image ID="lifeTwo" src="Content/testThree.png" runat="server" Visible="False" />
                <asp:Image ID="lifeThree" src="Content/testFour.png" runat="server" Visible="False" />
                <asp:Image ID="lifeFour" src="Content/testFive.png" runat="server" Visible="False" />
                <asp:Image ID="lifeFive" src="Content/testSix.png" runat="server" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                Guess a letter:

                <asp:Label ID="guessedLettersTitle" runat="server" Text="Guessed Letters: "></asp:Label>
                <asp:Label ID="guessedLetters" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="guess" runat="server"></asp:TextBox>
                <asp:Button ID="guessButton" runat="server" Text="Guess" OnClick="guessButton_Click" />
                <asp:Image ID="Image1" runat="server" />
                 <asp:Label ID="guessResponse" runat="server" Text=""></asp:Label>
            </asp:Panel>
    </div>
    </form>
</body>
</html>
