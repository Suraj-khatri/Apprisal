<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="chooseContributionType.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.chooseContributionType" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>   Select Contribution Type For : <span class="subheading"><asp:Label ID="LblEmpName" runat="server"></asp:Label></span>
        </header>
        <asp:HiddenField ID="hdnEmpId" runat="server" />   
        <div class="panel-body">
            
          
            <div class="row">
                <div class="col-md-12 form-group " >
                  <center>
                       <label>
                        <asp:LinkButton ID="regularContribution" runat="server" 
                    onclick="regularContribution_Click" CssClass="linkButton">Regular Contribution</asp:LinkButton>
                    </label>
                    |
                    <label>
<asp:LinkButton ID="adhocContribution" runat="server" 
                    onclick="adhocContribution_Click" CssClass="linkButton">Adhoc Contribution</asp:LinkButton>
                    </label>
                      </center> 
                </div>
            </div>
        </div>
    </div>

</asp:Content>
