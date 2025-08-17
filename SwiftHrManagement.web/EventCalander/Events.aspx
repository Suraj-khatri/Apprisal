<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="SwiftHrManagement.web.EventCalander.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<div class="panel">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group" align="center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label></font></strong><br />
                                        <font size="-1"><strong>
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font><br />
                                <font size="-1"><strong>
                                    <strong>Event/Holiday Detail For the Date : <asp:Label ID="ondate"  Text="test it " runat="server"></asp:Label></strong>
                                </strong></font>
                            </div>
                            <div id = "divEvents" runat = "server"  align="center"></div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
