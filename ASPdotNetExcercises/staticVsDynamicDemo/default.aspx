<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="staticVsDynamicDemo._default" %>

<%-- NB no master page here so html header is in the default page --%><%-- Webforms must be in an HTML form with an id and runat="server" otherwise they wont work --%><%-- Infact all controls (label, button etc)must have and id and runat="server". 
    Dragging and dropping controls will add these automatically --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <h2>Hello, World!</h2>
                    <div>
                        <asp:Label ID="dateTimeResponse" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Please type in your name: " Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="nameEntry" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameValidator" Display="Dynamic" Text="*Required Field" ValidationGroup="AllValidators" runat="server" ErrorMessage="Please enter a name." ControlToValidate="nameEntry"></asp:RequiredFieldValidator>
                        <asp:Label ID="Label4" runat="server" Text="  "></asp:Label>
                        <asp:Button ID="nameButton" runat="server" Text="Click Me!" OnClick="nameButton_Click" ValidationGroup="AllValidators" />
                        <br />
                        <br />
                        <asp:Label ID="nameDisplay" runat="server" Text=""></asp:Label><br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Please check or uncheck the box" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:CheckBox ID="CheckBox1" runat="server" /><br />
                        <br />
                        <asp:Button ID="checkButton" runat="server" Text="CheckBox Button" OnClick="checkButton_Click" />
                        <br />
                        <br />
                        <asp:Label ID="checkBoxDisplay" runat="server" Text=""></asp:Label><br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Please click the Radio Button" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:RadioButton ID="RadioButton1" runat="server" />
                        <asp:Button ID="radioButtonOne" runat="server" Text="RadioButton Button" OnClick="radioButton_Click" />
                        <br />
                        <br />
                        <asp:Label ID="radioDisplay" runat="server" Text=""></asp:Label><br />
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label5" runat="server" Text="Please click a Radio Button" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:RadioButtonList ID="RadioButtonList" runat="server">
                            <asp:ListItem Value="radioButOne">Radio Button One</asp:ListItem>
                            <asp:ListItem Value="radioButTwo">Radio Button Two</asp:ListItem>
                            <asp:ListItem Value="radioButThree">Radio Button Three</asp:ListItem>
                        </asp:RadioButtonList><br />
                        <br />
                        <asp:Button ID="radioButtonTwo" runat="server" Text="RadioButton List Button" OnClick="radioButtonTwo_Click" />
                        <br />
                        <br />
                        <asp:Label ID="radioDisplayTwo" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Text="Image Test" Font-Bold="True"></asp:Label><br />
                        <asp:HyperLink ID="HyperLink2" href="https://www.justit.co.uk/" runat="server">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Content/imageMapTest.png" />
                        </asp:HyperLink><br />
                        <br />
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Linkbutton Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:LinkButton ID="LinkButton1" PostBackUrl="https://www.justit.co.uk/" runat="server">Just IT Link Button</asp:LinkButton>
                    </div>

                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="HyperLink Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:HyperLink ID="HyperLink1"  runat="server"><a href="https://www.justit.co.uk/">Just IT</a> HyperLink</asp:HyperLink>
                    
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Multi-Line Textbox Test" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="multilineBox" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                        <asp:Button ID="multiTextButton" runat="server" Text="MultiText Button" OnClick="multiTextButton_Click" /><br />
                        <br />
                        <asp:Label ID="multiTextDisplay" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="eMail Textbox Test" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="emailBox" runat="server" TextMode="Email"></asp:TextBox><br />
                        <asp:Button ID="emailButton" runat="server" Text="eMail Button" OnClick="emailButton_Click" /><br />
                        <br />
                        <asp:Label ID="emailDisplay" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Calender Test" Font-Bold="True"></asp:Label><br />
                        <asp:Calendar ID="calendarOne" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                        <br />
                        <br />
                        <asp:Label ID="calenderDisplay" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="DropDown Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Choose a breakfast:"></asp:Label><br />
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Bacon and Eggs</asp:ListItem>
                            <asp:ListItem>Pancakes</asp:ListItem>
                        </asp:DropDownList><br />
                        <br />
                        <asp:Button ID="dropDownButton" runat="server" Text="Confirm Selection" OnClick="dropDownButton_Click" /><br />
                        <br />
                        <asp:Label ID="dropDownDisplay" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="Checkbox List Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label15" runat="server" Text="Choose some flavours:"></asp:Label><br />
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            <asp:ListItem Value="vanilla">Vanilla</asp:ListItem>
                            <asp:ListItem Value="strawberry">Strawberry</asp:ListItem>
                            <asp:ListItem Value="chocolate">Chocolate</asp:ListItem>
                            <asp:ListItem Value="lemon">Lemon</asp:ListItem>
                        </asp:CheckBoxList><br />
                        <br />
                        <asp:Button ID="checkBoxListButton" runat="server" Text="Confirm Selection" OnClick="checkBoxListButton_Click" /><br />
                        <br />
                        <asp:Label ID="checkBoxListDisplay" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label16" runat="server" Text="Bulleted List Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:BulletedList ID="BulletedList1" BulletStyle="CustomImage" BulletImageUrl="Content/russelWilsonBullet.png" runat="server">
                            <asp:ListItem>Item One</asp:ListItem>
                            <asp:ListItem>Item Two</asp:ListItem>
                            <asp:ListItem>Item Three</asp:ListItem>
                            <asp:ListItem>Item Four</asp:ListItem>
                        </asp:BulletedList>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label17" runat="server" Text="List Box Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="Choose one or more(hold ctrl and click):"></asp:Label><br />
                        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>Red</asp:ListItem>
                            <asp:ListItem>Yellow</asp:ListItem>
                            <asp:ListItem>Green</asp:ListItem>
                            <asp:ListItem>Blue</asp:ListItem>
                        </asp:ListBox><br />
                        <br />
                        <asp:Button ID="listBoxButton" runat="server" Text="Confirm Selection" OnClick="listBoxButton_Click" /><br />
                        <br />
                        <asp:Label ID="listBoxDisplay" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label19" runat="server" Text="Panel Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:Panel ID="hiddenPanel" runat="server" Visible="False">
                            <asp:Label ID="Label20" runat="server" Text="This text was hidden!"></asp:Label>
                        </asp:Panel>
                        <asp:CheckBox ID="hiddenCheckbox" runat="server" Text="Unhide the Panel" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="True" /><br />
                        <br />
                    </div>
                    <div>
                        <br />
                        <br />
                        <asp:Label ID="Label21" runat="server" Text="Wizard Test" Font-Bold="True"></asp:Label><br />
                        <br />
                        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick">
                            <WizardSteps>
                                <asp:WizardStep ID="WizardStep1" runat="server" Title="Name">
                                    <asp:TextBox ID="deckName" runat="server"></asp:TextBox>

                                </asp:WizardStep>
                                <asp:WizardStep ID="WizardStep2" runat="server" Title="Color(s)">
                                    <asp:ListBox ID="deckColor" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem>White</asp:ListItem>
                                        <asp:ListItem>Blue</asp:ListItem>
                                        <asp:ListItem>Black</asp:ListItem>
                                        <asp:ListItem>Red</asp:ListItem>
                                        <asp:ListItem>Green</asp:ListItem>
                                    </asp:ListBox>
                                </asp:WizardStep>
                                <asp:WizardStep ID="WizardStep3" runat="server" Title="Speed">
                                    <asp:RadioButtonList ID="deckSpeed" runat="server">
                                        <asp:ListItem>Aggro</asp:ListItem>
                                        <asp:ListItem>Midrange</asp:ListItem>
                                        <asp:ListItem>Contol</asp:ListItem>
                                        <asp:ListItem>Combo</asp:ListItem>
                                    </asp:RadioButtonList>
                                </asp:WizardStep>

                            </WizardSteps>

                        </asp:Wizard>

                        <asp:Label ID="wizardDisplay" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                    <div>
                        <asp:Label ID="Label22" runat="server" Text="Image Map Test" Font-Bold="True"></asp:Label><br />
                        <asp:ImageMap ID="Circle" ImageUrl="Content/imageMapTest.png" runat="server" HotSpotMode="PostBack" OnClick="Circle_Click">
                            <asp:CircleHotSpot Radius="62" X="122" Y="112" PostBackValue="circle" HotSpotMode="PostBack" />
                            <asp:RectangleHotSpot PostBackValue="rectangle" HotSpotMode="PostBack" Top="7" Bottom="60" Left="186" Right="243" />
                            <asp:PolygonHotSpot PostBackValue="triangle" HotSpotMode="PostBack" Coordinates="17,154,17,215,78,215" />
                        </asp:ImageMap>
                        <br />
                        <asp:Label ID="imageMapDisplay" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>

                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
    </form>
</body>
</html>
