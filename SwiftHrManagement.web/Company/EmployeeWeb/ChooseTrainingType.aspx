<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ChooseTrainingType.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ChooseTrainingType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>   Training Type selection
        </header>
        <div class="panel-body">
            <asp:HiddenField ID="hdnEmpId" runat="server" />   
            <div class="row">
                <div class="col-md-6 form-group text-right">
                    <label>
                        <asp:LinkButton ID="selfTraining" runat="server" 
                     CssClass="linkButton" onclick="selfTraining_Click">Previous Training</asp:LinkButton>
                    </label> &nbsp;|&nbsp; <label><asp:LinkButton ID="bankTraining" runat="server" 
                    CssClass="linkButton" onclick="bankTraining_Click">In-House Training</asp:LinkButton>
                    </label>
                </div>
               <%-- <div class="col-md-6 form-group text-left">
                    <label>
 
                </div>--%>
               
            </div>
        </div>
    </div>

</asp:Content>
