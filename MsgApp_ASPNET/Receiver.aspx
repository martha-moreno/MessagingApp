<%@ Page Title="Receiver" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receiver.aspx.cs" Inherits="MsgApp_ASPNET.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h3>Receiver Page</h3>
    <br />

    <asp:Label ID="lblReceiverID" runat="server" Text="Receiver ID:"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReceiverID" runat="server" Width="190px"></asp:TextBox>
    <asp:Button ID="btnReceiveMessage" runat="server" class="btn btn-primary" Height="44px" Text="Receive" Width="100px" OnClick="btnReceiveMessage_Click" />
    <br />
    <asp:CheckBox id="Purge" runat="server" Text="Purge" TextAlign="Right" Checked="False" />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="Message:"></asp:Label> &nbsp;&nbsp;&nbsp;<br />
    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" width="300px" Height="100px"></asp:TextBox>
    <br />
    <asp:Label ID="lblWarning" runat="server" ForeColor="Red" Text="lblWarning" Visible="False"></asp:Label>
</asp:Content>
