<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="PrintExitInterview.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.ExitInterview.PrintExitInterview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
         <div class="printheader"><asp:Label ID="compInfo" runat="server" ></asp:Label></div>
        <header class="panel-heading">
         <i class="fa fa-caret-right"></i>      Exit Interview
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 form-group">
                    <label>
                        Name:
                    </label>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </div>
                <div class="col-md-12 form-group">
                    <label>
                        Designation
                    </label>
                    <asp:Label ID="lblPost" runat="server" ></asp:Label>
                </div>
                <div class="col-md-12 form-group">
                    <label>
                        Branch
                    </label>
                    <asp:Label ID="lblBranch" runat="server"></asp:Label>
                </div>
                <div class="col-md-12 form-group">
                   <label>Department</label>
                    <asp:Label ID="lblDept" runat="server"></asp:Label> 
                </div>
                <div class="col-md-12 form-group">
                     <label>Exit Reason</label> 
                    <asp:Label ID="lblReason" runat="server" ></asp:Label>
                </div>
                <div class="col-md-12 form-group">
                    <label>Comments</label> 
                    <asp:Label ID="lblComments" runat="server" ></asp:Label> 
                </div>
            </div>
            <div id="exitInterview" runat="server"></div>
        </div>
    </div>

</asp:Content>
