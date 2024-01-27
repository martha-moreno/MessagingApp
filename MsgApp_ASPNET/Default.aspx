<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MsgApp_ASPNET._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Messaging App</h1>
        <p class="lead">This is a web application developed in ASP .Net that uses a RESTful service to buffer messages before the receivers can fetch the messages </p>
       
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Send a Message</h2>
            <p>
                <a class="btn btn-default" href="Sender">Sender Page &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Retrieve your Message(s)</h2>
            <p>
                <a class="btn btn-default" href="Receiver">Receiver Page &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
