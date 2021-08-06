<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="Guestbook2.Page" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <link href="page.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-lg-4 offset-lg-0 col-sm-8 offset-sm-2">
                <form id="contact" runat="server" class="align-content-center">
                    <h3>Welcome!</h3>
                    <h4>What's on your mind?</h4>
                    <fieldset>
                        <asp:TextBox ID="name" runat="server" placeholder="Your name" type="text" TabIndex="1" required="true" autofocus="true" MaxLength="35"></asp:TextBox>
                    </fieldset>
                    <fieldset>
                        <asp:TextBox ID="email" runat="server" placeholder="Your email" type="email" TabIndex="2" MaxLength="254"></asp:TextBox>
                    </fieldset>
                    <%--<fieldset>--%>
<%--                        What corner of the world are you from?
                        <asp:DropDownList ID="continent" runat="server" TabIndex="3" Selected="True">
                            <asp:ListItem Value="0">I am from everywhere.</asp:ListItem>
                            <asp:ListItem Value="1">Asia</asp:ListItem>
                            <asp:ListItem Value="2">Africa</asp:ListItem>
                            <asp:ListItem Value="3">North America</asp:ListItem>
                            <asp:ListItem Value="4">South America</asp:ListItem>
                            <asp:ListItem Value="5">Antarctica</asp:ListItem>
                            <asp:ListItem Value="6">Europe</asp:ListItem>
                            <asp:ListItem Value="7">Australia</asp:ListItem>
                        </asp:DropDownList>
                    </fieldset>--%>
                    <fieldset>
                        <asp:TextBox ID="message" TextMode="multiline" Columns="20" Rows="2" runat="server" placeholder="Type your message here...." tabindex="4" required="true" maxlength="200" />
                    </fieldset>
                    <fieldset>
                        <asp:Button ID="submitBtn" runat="server" type="submit" Text="Button" OnClick="Button1_Click" />
                    </fieldset>
                </form>
            </div>


            <div class="col-lg-8 offset-lg-0 col-sm-8 offset-sm-2">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="commentsGrid" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="Id" OnPageIndexChanging="OnPaging" PageSize="5" style="margin: 150px 0;" OnRowDeleting="commentsGrid_RowDeleting" OnRowEditing="commentsGrid_RowEditing" OnRowUpdating="commentsGrid_RowUpdating" OnRowCancelingEdit="commentsGrid_RowCancelingEdit"  >
                            <%--OnRowEditing="commentsGrid_RowEditing">--%>
                            <Columns>
                                <asp:BoundField DataField="id" ItemStyle-Width="30" HeaderText="No." ReadOnly="True" />
                                <asp:BoundField DataField="name" ItemStyle-Width="80" HeaderText="Name" ReadOnly="True" />
                                <asp:BoundField DataField="email" ItemStyle-Width="150" HeaderText="Email" ReadOnly="True" />
                                <asp:BoundField DataField="message" ItemStyle-Width="100%" HeaderText="Message" ItemStyle-CssClass="text-break" />
                                <asp:BoundField DataField="edited" ItemStyle-Width="55" HeaderText="Edited" ReadOnly="True" />
                                <asp:BoundField DataField="date" ItemStyle-Width="55" HeaderText="Date" ReadOnly="True" />
                                <asp:CommandField ShowEditButton="true"  ItemStyle-CssClass="text-center" />  
                                <asp:CommandField ShowDeleteButton="true"  ItemStyle-CssClass="text-center" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
