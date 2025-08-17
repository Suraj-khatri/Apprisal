<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageStatement.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ManageStatement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../../js/functions.js"></script>
    <script src="../../js/functions.js" type="text/javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UP" runat="server">
        <ContentTemplate>
            <style type="text/css">
                .form-inline .form-control {
                    margin-bottom: 3px !important;
                }
            </style>
              <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
            Stock Statement
        </header>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
              Stock Statement
        Report      
        </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                <label>From Date:<span class="required">*</span></label>
                                <asp:TextBox ID="fromDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                    Enabled="True" TargetControlID="fromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="fromDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="rpt">
                                </asp:RequiredFieldValidator>
                            </div>
                      

                        <div class="col-md-4 form-group">
                                <label>To Date:<span class="required">*</span></label>
                                <asp:TextBox ID="toDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>

                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                    Enabled="True" TargetControlID="toDate">
                                </cc1:CalendarExtender>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="toDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="rpt">
                                </asp:RequiredFieldValidator>
                            </div>
                       
                        <div class="col-md-4 form-group">
                                <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                <label>Product Name:<span class="required">*</span></label>

                                <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" Width="100%"
                                    AutoComplete="off" OnTextChanged="txtProduct_TextChanged"
                                    AutoPostBack="True"></asp:TextBox>

                                <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="txtProduct"
                                    WatermarkText="Auto Complete" WatermarkCssClass="form-control">
                                </cc1:TextBoxWatermarkExtender>

                                <cc1:AutoCompleteExtender ID="ACproduct" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx"
                                    ServiceMethod="GetProductList" TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                                </cc1:AutoCompleteExtender>
                        </div>
                        <div class="col-md-4 form-group">
                                <label>Branch Name:<span class="required">*</span></label>
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="DdlBranchName" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="rpt">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    <br />
                    <asp:Button ID="BtnSearch" ValidationGroup="rpt" runat="server"
                        CssClass="btn btn-primary" Text=" Search " OnClick="BtnSearch_Click" />
                </div>
            </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

