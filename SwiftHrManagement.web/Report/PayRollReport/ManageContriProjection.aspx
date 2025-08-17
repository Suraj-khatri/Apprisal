<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageContriProjection.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.ManageContriProjection" Title="SWIFT HR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Contribution Projection for Tax
                        </header>
                        <div class="panel-body">
                            <label>Employee wise contribution projection</label>
                            <div class="form-group">
                                <label>Fiscal Year : <span class="errormsg">*</span>  </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                    runat="server" ControlToValidate="DdlYear" Display="Dynamic" 
                                    ErrorMessage="Required!" ValidationGroup="projection" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                 <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                              <div class="form-group autocomplete-form">
                                    <label>Employee Name : <span class="errormsg">*</span>  </label>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                        TargetControlID="txtEmpId" MinimumPrefixLength="1" CompletionInterval="20"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" >
                                    </cc1:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="rfc" runat="server" 
                                        ControlToValidate="txtEmpId" Display="Dynamic" ErrorMessage="Required!" 
                                        SetFocusOnError="True" ValidationGroup="projection">
                                    </asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtEmpId" runat="server" CssClass="form-control" AutoComplete="Off"></asp:TextBox>                                      
                                </div>
                                <br/>
                                <label>Additional Monthly Contribution Amount:</label>
                                <div class="form-group">
                                    <label>Option-1 : <span class="errormsg">*</span>  </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                                    runat="server" ControlToValidate="txtAmount1" Display="Dynamic" 
                                                    ErrorMessage="Required!" ValidationGroup="projection" SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>    
                                        <asp:TextBox ID="txtAmount1" runat="server" CssClass="form-control"></asp:TextBox>                                    
                                </div>
                                <div class="form-group">
                                    <label>Option-1 :</label>
                                    <asp:TextBox ID="txtAmount2" runat="server" CssClass="form-control"></asp:TextBox>
                                </div> 
                                <div class="form-group">
                                    <label>Option-1 :</label>
                                    <asp:TextBox ID="txtAmount3" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search Projection" 
                                        onclick="Btn_Search_Click" ValidationGroup="projection" />         
                                </div>
                            </div>
                    </section>
                </div>
            </div>
</asp:Content>
