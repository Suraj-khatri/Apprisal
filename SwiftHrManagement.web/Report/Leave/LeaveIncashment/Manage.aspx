<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.Leave_Incashment.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate> 
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Leave End Report
                </header>
                <div class="panel-body">
                <div class="form-group">
                    <label>BS Year :</label>
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList> 
                    <span class="errormsg"><asp:Label ID="lblyear" runat="server" Text="">
                    </asp:Label></span>
                </div>
                <div class="form-group">               
                    <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" CssClass="btn btn-primary" 
                        onclick="btnExportToExcel_Click" /> &nbsp;&nbsp;&nbsp;</td>       
               </div>
            </div>
        </section>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

