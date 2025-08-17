<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageDepRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.ManageDepRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/functions.js" type="text/javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <title>Depreciation Reporting </title>

    <style type="text/css">
        .form-group {
            margin-bottom: 3px !important;
        }
    </style>

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
              <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    Depreciation Reporting
                </header>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Depreciation group wise Summary report
                </header>

                <div class="panel-body">
                    <asp:HiddenField ID="hdnAssetTypeId" runat="server" />
                    <asp:HiddenField ID="hdnAssetNumber" runat="server" />

                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Fiscal Year:</label>
                                <asp:DropDownList ID="ddlFY" runat="server" CssClass="form-control" AutoPostBack="True" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="ddlFY" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                            </div>
                    
                        <div class="col-md-4 form-group">
                                <label>Month:<span class="required">*</span></label>
                            
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="ddlMonth" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                            </div>
                        <div class="col-md-4 form-group">
                                <label>Branch Name:<span class="required">*</span></label>
                         
                                <asp:DropDownList ID="DdlBranchName2" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="DdlBranchName2" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    <br />
                    <asp:Button ID="BtnDepRpt" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnDepRpt_Click" Text="View Report" ValidationGroup="dep" />

                    <asp:Button ID="BtnDetailRpt" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnDetailRpt_Click" Text="Summary Report" ValidationGroup="dep" />
                    <asp:Button ID="BtnExport" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnExport_Click" Text="Export Summary Rpt To Excel "
                        ValidationGroup="dep" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">Depreciation monthly asset wise report</header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>
                                    Fiscal Year:<span class="required">*</span>
                                </label>
                                <asp:DropDownList ID="ddlFY1" runat="server" CssClass="form-control" AutoPostBack="True" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="ddlFY1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="dep1"></asp:RequiredFieldValidator>
                            </div>
                       
                        <div class="col-md-4 form-group">
                                <label>
                                    Group Name:<span class="required">*</span>
                                </label>
                           
                                <asp:DropDownList ID="ddlGroupName" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                    ControlToValidate="ddlGroupName" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="dep1"></asp:RequiredFieldValidator>
                            </div>
                        <div class="col-md-4 form-group">
                                <label>
                                    Branch Name:
                                </label>
                                <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            
                        </div>
                    </div>
                        <br />
                    <asp:Button ID="BtnSearchRpt" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnSearchRpt_Click" Text="View Report" ValidationGroup="dep1" />
                    <asp:Button ID="BtnExportExcel" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnExportExcel_Click" Text="Export To Excel" ValidationGroup="dep1" />

                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                  Depreciation group wise monthly report
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Fiscal Year:<span class="required">*</span></label>
                                <asp:DropDownList ID="ddlFY2" runat="server" CssClass="form-control" AutoPostBack="True" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="ddlFY2" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="dep2"></asp:RequiredFieldValidator>
                            </div>
                      
                        <div class="col-md-4 form-group">
                                <label>Branch Name:</label>
                                <asp:DropDownList ID="DdlBranchName1" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                   
                    <br />
                    <asp:Button ID="BtnSearchRptGrp" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnSearchRptGrp_Click" Text="View Report" ValidationGroup="dep2" />

                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                   Asset Summary Report
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Branch Name:</label>
                     
                            <asp:DropDownList ID="DdlBranchName3" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <asp:Button ID="BtnSearchTot" runat="server" CssClass="btn btn-primary"
                        Text="View Report" OnClick="BtnSearchTot_Click" />
                </div>
            </div>
</div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
