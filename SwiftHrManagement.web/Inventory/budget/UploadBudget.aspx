<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadBudget.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.budget.UploadBudget" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Upload Budget
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <a target='_blank' href="../../doc/IN_Budget/BUDGET_CSV.csv" alt="Sample File">Sample Upload File</a>
                        <br />
                        <span >Please enter valid data! <span class="required">(* are required fields)</span></span><br />
                        <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label>
                    </div>
                    <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Fiscal Year:</label><span class="errormsg">*</span>
                        <asp:DropDownList ID="ddlFY" runat="server" CssClass="form-control"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Required!" ControlToValidate="ddlFY" 
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="upload">
                        </asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="col-md-4 form-group">
                        <label>Branch Name:</label><span class="errormsg">*</span>
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                            ErrorMessage="Required!" ControlToValidate="ddlBranch" 
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="upload">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Select CSV File:</label><span class="errormsg">*</span> 
                        <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" CssClass="btn btn-primary" />
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                            ValidationGroup="upload" ControlToValidate="fileUpload" Display="Dynamic" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                   </div>
                        <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="btn btn-primary" 
                        onclick="BtnUpload_Click" ValidationGroup="upload"/>
                        <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                        </cc1:ConfirmButtonExtender>&nbsp;

                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" 
                        onclick="btnBack_Click"/>
                   
                </div>
            </section>
        </div>
    </div>



</asp:Content>
