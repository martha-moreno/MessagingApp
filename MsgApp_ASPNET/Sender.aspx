<%@ Page Title="Sender" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sender.aspx.cs" Inherits="MsgApp_ASPNET.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Sender Page</h3>
    <br />

    <asp:Label ID="lblReceiverID" runat="server" Text="Receiver ID:"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReceiverID" runat="server" Width="190px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblSenderID" runat="server" Text="Sender ID:"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSenderID" runat="server" Width="190px"></asp:TextBox>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="Message:"></asp:Label> &nbsp;&nbsp;&nbsp;<br />
    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" overflow=scroll; width="500px" Height="100"></asp:TextBox>
    <br />
    <asp:Label ID="lblWarning" runat="server" ForeColor="Red" Text="lblWarning" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="btnSendMessage" runat="server" class="btn btn-primary" Height="44px" Text="Send" Width="100px" OnClick="btnSendMessage_Click" />
    <br />
    <asp:Label ID="lblConfirmation" runat="server" Text="Your message has been sent" Visible="false" ForeColor="Green"></asp:Label> &nbsp;&nbsp;&nbsp;<br />
    <br />
 
</asp:Content>
