<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="CEAAdhocPayment.aspx.cs" Inherits="SwiftHrManagement.web.CEA.CEAAdhocPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
       <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-user"></i>
           Payment of CEA 
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                             <div>
                                    <div id="rpt" runat="server"></div>                                    
                                </div>
                            <div id = "res" align="center"></div>
                            <asp:Button ID="BtnApprove" runat="server" Text="Post All As Adhoc" 
                                    CssClass="btn btn-primary" onclick="BtnApprove_Click" />
                                <asp:HiddenField ID="hdnID" runat="server" />
      
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>