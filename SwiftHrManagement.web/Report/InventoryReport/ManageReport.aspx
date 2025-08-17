<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ManageReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style type="text/css">
        .form-group {
            margin-bottom: 3px !important;
        }
    </style>--%>
    <script type="text/javascript" src="../../js/functions.js"></script>
    <script src="../../js/functions.js" type="text/javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UP" runat="server">
        <ContentTemplate>
              <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                   Inventory Summary Report-Group Wise
                </header>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                    Inventory Stock in Hand Report
                </header>

                <div class="panel-body">
                    <asp:HiddenField ID="hdnAssetTypeId" runat="server" />
                    <asp:HiddenField ID="hdnAssetNumber" runat="server" />
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Product Group Name:</label>
                                <asp:DropDownList ID="DdlGroupName" runat="server" CssClass="form-control"
                                    OnSelectedIndexChanged="DdlGroupName_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="DdlGroupName" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="stock"> </asp:RequiredFieldValidator>
                            </div>
                       
                        <div class="col-md-4 form-group">
                                <label>Product Name:</label>
                                <asp:DropDownList ID="DdlProductName" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                   
                        <div class="col-md-4 form-group">
                                <label>Branch Name:</label>
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                    <asp:Button ID="BtnSearch" ValidationGroup="stock" runat="server"
                        CssClass="btn btn-primary" Text=" Search " OnClick="BtnSearch_Click" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                   Inventory Summary Report
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>From Date:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"
                                    ValidationGroup="summary" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                            </div>
                        <div class="col-md-4 form-group">
                                <label>To Date:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"
                                    ValidationGroup="summary" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtToDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                            </div>
                     
                        <div class="col-md-4 form-group">
                                <label>Product Group Name:<span class="errormsg">*</span></label>
                                <asp:DropDownList ID="DdlGroupName1" runat="server" CssClass="form-control"
                                    OnSelectedIndexChanged="DdlGroupName1_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="DdlGroupName1" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="summary"> </asp:RequiredFieldValidator>
                            </div>
                        </div>
                  
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Branch Name:<span class="errormsg">*</span></label>
                                <asp:DropDownList ID="DdlBranchName1" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="DdlBranchName1" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="summary"> </asp:RequiredFieldValidator>
                            </div>
                        
                        <div class="col-md-4 form-group">
                                <label>Product Name:</label>
                                <asp:DropDownList ID="DdlProductName1" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                 
                    <asp:Button ID="BtnSummaryRpt" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnSummaryRpt_Click" Text="View " ValidationGroup="summary" />
                  <asp:Button ID="BtnExportSummaryRpt" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnExportSummaryRpt_Click" Text="Export To Excel" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                   Inventory Expenses Report 
        Group Wise
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                         
                                <label>From Date:<span class="errormsg">*</span></label>
                        
                                <asp:TextBox ID="txtFromDate1" runat="server" CssClass="form-control"
                                    ValidationGroup="summary" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtFromDate1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="txtFromDate1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date_wise"></asp:RequiredFieldValidator>
                            </div>
                      
                        <div class="col-md-4 form-group">
                                <label>To Date:<span class="errormsg">*</span></label>
                           
                                <asp:TextBox ID="txtToDate1" runat="server" CssClass="form-control"
                                    ValidationGroup="summary" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                    Enabled="True" TargetControlID="txtToDate1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="txtToDate1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date_wise"></asp:RequiredFieldValidator>
                            </div>
                      
                        <div class="col-md-4 form-group">
                                <label>Produc Group Name:</label>
                                <asp:DropDownList ID="DdlGroupName2" runat="server" CssClass="form-control"
                                    OnSelectedIndexChanged="DdlGroupName2_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                    ControlToValidate="DdlGroupName2" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date_wise"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Product Name:</label>
                                <asp:DropDownList ID="DdlProductName2" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        
                        <div class="col-md-4 form-group">
                                <label>Branch Name:</label>
                                <asp:DropDownList ID="DdlBranchName2" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                    <br/>
                    <asp:Button ID="Btn_Search_Exp" runat="server"
                        CssClass="btn btn-primary" Text=" Search " OnClick="Btn_Search_Exp_Click"
                        ValidationGroup="date_wise" />
                </div>
            </div>
</div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
