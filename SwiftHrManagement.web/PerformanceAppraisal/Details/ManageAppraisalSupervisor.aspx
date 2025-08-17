<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageAppraisalSupervisor.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.Details.ManageAppraisalSupervisor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Appraisal Supervisor Assignment
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        <label>Rater Type:<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="ddlRaterType" runat="server" CssClass="form-control"> 
                            <asp:ListItem Value="">Select</asp:ListItem>  
                            <asp:ListItem Value="sf">Appraisee</asp:ListItem>    
                            <asp:ListItem Value="s">Supervisor</asp:ListItem> 
                            <asp:ListItem Value="r">Reviewer</asp:ListItem> 
                            <asp:ListItem Value="rc">Review  Committee</asp:ListItem> 
                            <asp:ListItem Value="h">HR Department</asp:ListItem>                        
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRaterType" 
                            Display="Dynamic" ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group autocomplete-form">
                        <label>Rater Name:<span class="errormsg">*</span></label>
                        <asp:TextBox ID="txtRaterName" runat="server" CssClass="form-control" AutoComplete="Off">              
                        </asp:TextBox>               
                        <cc1:textboxwatermarkextender ID="wm1" 
                            runat="server" Enabled="True" TargetControlID="txtRaterName"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:textboxwatermarkextender>                  
                        <cc1:autocompleteextender ID="ac1" runat="server" 
                            DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx" 
                            ServiceMethod="GetEmployeeList" TargetControlID="txtRaterName"
                            MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                        </cc1:autocompleteextender>                
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRaterName" 
                            Display="Dynamic" ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Status:<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">  
                            <asp:ListItem Value="y">Active</asp:ListItem>    
                            <asp:ListItem Value="n">Inactive</asp:ListItem>         
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlStatus" 
                            Display="Dynamic" ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Panel ID="pnlAppraisee" runat="server" Visible="true">
                        <div class="form-group">
                            <label>Appraisee Name:</label>
                            <asp:TextBox ID="txtAppraiseeName" runat="server" CssClass="form-control"></asp:TextBox>                
                            <cc1:TextBoxWatermarkExtender ID="wm2" runat="server" Enabled="True" TargetControlID="txtAppraiseeName"
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>                  
                            <cc1:AutoCompleteExtender ID="ac2" runat="server" DelimiterCharacters="" Enabled="True" 
                                ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList" TargetControlID="txtAppraiseeName"
                                MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                CompletionListCssClass="autocompleteTextBoxLP">
                            </cc1:AutoCompleteExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                            runat="server" ControlToValidate="txtAppraiseeName" Display="Dynamic" 
                            ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Appraisal From Date:</label>
                            <asp:TextBox ID="txtAppFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAppFromDate"
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Appraisal To Date:</label>
                             <asp:TextBox ID="txtAppToDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAppToDate" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Appraisal Target Days:</label>
                            <asp:TextBox ID="txtAppTargetDays" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAppTargetDays" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="sup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text=" Save " onclick="btnSave_Click"/>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" onclick="btnUpdate_Click" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete " onclick="btnDelete_Click" />
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" onclick="btnBack_Click"/>
                        </div>
                    </asp:Panel>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
