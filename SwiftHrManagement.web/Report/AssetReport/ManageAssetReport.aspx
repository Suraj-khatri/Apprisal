<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageAssetReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.ManageAssetReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../js/functions.js" type="text/javascript"></script>
    <style type="text/css">
        .form-group {
            margin-bottom: 3px !important;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function LoadCalendars() {
            ShowCalFromTo("#<% =txtFromDate_D.ClientID%>", "#<% =txtToDate_D.ClientID%>", 1);
        }
        LoadCalendars();
        function showDetailReport() {
            if (!Page_ClientValidate('rpt'))
                return false;

            var branchId = GetValue("<% =DdlBranchName.ClientID%>");
            var deptId = GetValue("<% =DdlDeptName.ClientID%>");
            var groupId = GetValue("<% =DdlAssetGroupName.ClientID%>");
            var assetId = GetValue("<% =DdlAssetType.ClientID%>");
            var oldNew = GetValue("<% =oldNewNo.ClientID%>");
            var assetNo = GetValue("<% =hdnAssetNumber.ClientID%>"); // oldNew.Split("|",1);
            // alert(assetNo);

            var url = "../Report.aspx?reportName=fa_detail" +
                "&branchId=" + branchId +
                    "&deptId=" + deptId +
                        "&groupId=" + groupId +
                            "&assetType=" + assetId +
                                "&assetNumber=" + assetNo;


            OpenInNewWindow(url);
            return false;
        }
        function showSummaryReport() {
            var branchId = GetValue("<% =DdlBranchName2.ClientID%>");
            var rptType = GetValue("<% =rptType.ClientID%>");
            var url = "../Report.aspx?reportName=fa_summary" +
                "&branchId=" + branchId +
                "&rptType=" + rptType;

            OpenInNewWindow(url);
            return false;
        }

        function AutocompleteOnSelected(sender, e) {
            var oldNewAssetNumber = (e._value).split("|");
            document.getElementById("<%=hdnAssetNumber.ClientID %>").value = oldNewAssetNumber[0];
        }

        function showBranchWiseReport() {
            var branchId = GetValue("<% =DdlBranchName2.ClientID%>");
            var url = "../Report.aspx?reportName=fa_branchwise" +
                "&branchId=" + branchId;

            OpenInNewWindow(url);
            return false;
        }
        function ShowDepDetail() {
            if (!Page_ClientValidate('dep'))
                return false;

            var fy = GetValue("<% =ddlFY.ClientID%>");
            var month = GetValue("<% =ddlMonth.ClientID%>");
            var branchId = GetValue("<% =branchName.ClientID%>");

            var url = "../Report.aspx?reportName=fa_dep_detail" +
                 "&fy=" + fy +
                     "&month=" + month +
                         "&branchId=" + branchId;
            OpenInNewWindow(url);
            return false;
        }

        function ShowDepGrpWise() {
            if (!Page_ClientValidate('dep'))
                return false;

            var fy = GetValue("<% =ddlFY.ClientID%>");
            var month = GetValue("<% =ddlMonth.ClientID%>");
            var branchId = GetValue("<% =branchName.ClientID%>");

            var url = "../Report.aspx?reportName=fa_dep_groupwise" +
                 "&fy=" + fy +
                     "&month=" + month +
                         "&branchId=" + branchId;
            OpenInNewWindow(url);
            return false;
        }
        function ShowDepSummary() {
            if (!Page_ClientValidate('dep'))
                return false;

            var fy = GetValue("<% =ddlFY.ClientID%>");
            var month = GetValue("<% =ddlMonth.ClientID%>");
            var branchId = GetValue("<% =branchName.ClientID%>");
            if (month != "") {
                alert("Yearly Summary Report, Month is not required.");
                return false;
            }
            if (branchId != "") {
                alert("Yearly Summary Report, Branch is not required.");
                return false;
            }
            var url = "../Report.aspx?reportName=fa_dep_summary" +
                 "&fy=" + fy +
                     "&month=" + month +
                         "&branchId=" + branchId;
            OpenInNewWindow(url);
            return false;
        }
        function showDatawise() {
            if (!Page_ClientValidate('date'))
                return false;
            var fromDate = GetDateValue("<% =txtFromDate_D.ClientID%>");
            var toDate = GetDateValue("<% =txtToDate_D.ClientID%>");
            var group = GetValue("<% =ddlGroupName_D.ClientID %>");
            var assetType = GetValue("<% =ddlAssetName_D.ClientID%>");
            var branch = GetValue("<% =ddlBranchName_D.ClientID%>");
            var rptType = GetValue("<% =rptType_D.ClientID%>");
            var url = "../Report.aspx?reportName=datewise_fa&fromDate=" + fromDate +
            "&toDate=" + toDate +
                "&rptType=" + rptType +
                    "&group=" + group +
                        "&branch=" + branch +
                            "&assetType=" + assetType;

            OpenInNewWindow(url);
            return false;
        }
        function ShowAssetGrpWise() {
            var fromDate = GetDateValue("<% =fDate.ClientID%>");
            var toDate = GetDateValue("<% =tDate.ClientID%>");
            var groupId = GetValue("<% =aGroup.ClientID %>");
            var branchId = GetValue("<% =bName.ClientID%>");
            var url = "../Report.aspx?reportName=grpwise_fa&fromDate=" + fromDate +
                "&toDate=" + toDate +
                    "&groupId=" + groupId +
                        "&branchId=" + branchId;

            OpenInNewWindow(url);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Asset Reporting
                </header>
            </div>
            <form class="form-inline">
                <div class="panel panel-default">
                    <header class="panel-heading">
                    Asset Detailed Report
                </header>

                    <div class="panel-body">
                        <asp:HiddenField ID="hdnAssetTypeId" runat="server" />
                        <asp:HiddenField ID="hdnAssetNumber" runat="server" />
                        <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>Branch Name:</label>
                                    <asp:DropDownList ID="DdlBranchName" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DdlBranchName_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                    <label>Department Name:</label>
                                    <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                        </div>
                            <div class="col-md-4 form-group">
                               
                                    <label>Asset Group Name:</label>
                                    <asp:DropDownList ID="DdlAssetGroupName" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DdlAssetGroupName_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>Asset Type:</label>
                                    <asp:DropDownList ID="DdlAssetType" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DdlAssetType_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                    <label>Brand Name:</label>
                               
                                    <asp:TextBox ID="brandName" runat="server" AutoComplete="off"
                                        AutoPostBack="true" CssClass="form-control" Width="100%">
                                    </asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                        Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetBrandName"
                                        TargetControlID="brandName" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true"
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                                    </cc1:AutoCompleteExtender>
                                
                            </div>
                            <div class="col-md-4 form-group">
                                    <label>Asset Number(Old/New):<span class="errormsg"> *</span></label>
                                
                                    <asp:TextBox ID="oldNewNo" runat="server" AutoComplete="off" CssClass="form-control" Width="100%">
                                    </asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                        Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetOldNewAssetNumber"
                                        TargetControlID="oldNewNo" MinimumPrefixLength="1" CompletionInterval="10" UseContextKey="true"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                                    </cc1:AutoCompleteExtender>
                                    <%--<asp:DropDownList ID="DdlAssetNumber" runat="server" CssClass="CMBDesign" Width="300px"></asp:DropDownList>--%>
                                    <asp:RequiredFieldValidator ControlToValidate="oldNewNo" ID="RequiredFieldValidator2"
                                        runat="server" ErrorMessage="Required" ValidationGroup="indi"></asp:RequiredFieldValidator>
                               
                            </div>
                        </div>
                        <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="View Report" ValidationGroup="rpt"
                            OnClientClick="return showDetailReport();" />
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Individual Report"
                            ValidationGroup="indi" OnClick="Button2_Click" />

                    </div>
                </div>
                <%--Asset Detailed Report--%>

                <div class="panel panel-default">
                    <header class="panel-heading">
                    Asset Summary report
                </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>Branch Name:</label>
                              
                                    <asp:DropDownList ID="DdlBranchName2" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            <div class="col-md-4 form-group">
                                    <label>Report Type:</label>
                                    <asp:DropDownList ID="rptType" runat="server" CssClass="form-control" Width="100%">
                                        <asp:ListItem Value="cost">Group Vs Branch -Cost Wise</asp:ListItem>
                                        <asp:ListItem Value="accDep">Group Vs Branch -Acc. Dep. Wise</asp:ListItem>
                                        <asp:ListItem Value="netValue">Group Vs Branch -Net Value Wise</asp:ListItem>
                                        <asp:ListItem Value="grpWise">Group Wise -Summary</asp:ListItem>
                                        <asp:ListItem Value="branchWise">Branch Wise -Summary</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        <br />
                        <asp:Button ID="BtnViewReport" runat="server" CssClass="btn btn-primary" OnClientClick="return showSummaryReport();"
                            Text="View Report" />
                    </div>
                </div>

                <div class="panel panel-default">
                    <header class="panel-heading">
                    Depreciation Summary report
                </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>Fiscal Year:<span class="required">*</span></label>
                              
                                    <asp:DropDownList ID="ddlFY" runat="server" AutoPostBack="True" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFY"
                                        Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                                </div>
                           
                            <div class="col-md-4 form-group">
                               
                                    <label>Month:</label>
                               
                                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            
                            <div class="col-md-4 form-group">
                               
                                    <label>Branch Name:</label>
                               
                                    <asp:DropDownList ID="branchName" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                       <br />
                        <asp:Button ID="BtnDepDetailRpt" runat="server" CssClass="btn btn-primary" Text="Dep. Detail Report"
                            ValidationGroup="dep" OnClientClick="return ShowDepDetail();" />
                        <asp:Button ID="BtnDepRpt" runat="server" CssClass="btn btn-primary" Text="Dep. Groupwise Report"
                            ValidationGroup="dep" OnClientClick="return ShowDepGrpWise();" />
                        <asp:Button ID="BtnDetailRpt" runat="server" CssClass="btn btn-primary" Text="Yearly Summary Report" />
                    </div>
                </div>

                <div class="panel panel-default">
                    <header class="panel-heading">
                    Asset Date Wise Report
                </header>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>From Date:<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="txtFromDate_D" runat="server" CssClass="form-control" Width="100%"> 
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required!"
                                        ControlToValidate="txtFromDate_D" Display="Dynamic" ValidationGroup="date"></asp:RequiredFieldValidator>
                                    <cc1:CalendarExtender ID="txtFromDate_D_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtFromDate_D">
                                    </cc1:CalendarExtender>
                                </div>
                            
                            <div class="col-md-4 form-group">
                                    <label>To Date:<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="txtToDate_D" runat="server" CssClass="form-control" Width="100%"> 
                                    </asp:TextBox>
                                    <cc1:CalendarExtender ID="txtToDate_D_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtToDate_D">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required!"
                                        ControlToValidate="txtToDate_D" Display="Dynamic" ValidationGroup="date"></asp:RequiredFieldValidator>
                                </div>
                            
                            <div class="col-md-4 form-group">
                                    <label>Report Type:</label>
                                    <asp:DropDownList ID="rptType_D" runat="server" CssClass="form-control" Width="100%">
                                        <asp:ListItem Value="book">Booking</asp:ListItem>
                                        <asp:ListItem Value="sales">Sales</asp:ListItem>
                                        <asp:ListItem Value="writeoff">WriteOff</asp:ListItem>
                                        <asp:ListItem Value="transfer">Transfer</asp:ListItem>
                                        <asp:ListItem Value="maintenance">Maintenance</asp:ListItem>
                                        <asp:ListItem Value="capitalization">Capitalization</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        
                        <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>Branch Name:</label>
                                
                                    <asp:DropDownList ID="ddlBranchName_D" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                         
                            <div class="col-md-4 form-group">
                                    <label>Asset Group:</label>
                                    <asp:DropDownList ID="ddlGroupName_D" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlGroupName_D_SelectedIndexChanged" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                          
                            <div class="col-md-4 form-group">
                                    <label>Asset Type:</label>
                                    <asp:DropDownList ID="ddlAssetName_D" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        <br />
                        <asp:Button ID="btnView_D" runat="server" CssClass="btn btn-primary" Text="View Report" ValidationGroup="date"
                            OnClientClick="return showDatawise();" />
                    </div>
                </div>

                <div class="panel panel-default">
                    <header class="panel-heading">
                      Assert Group wise summary
                </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                    <label>From Date:</label>
                                    <asp:TextBox ID="fDate" runat="server" CssClass="form-control" Width="100%"> 
                                    </asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="fDate">
                                    </cc1:CalendarExtender>
                                </div>
                           
                            <div class="col-md-4 form-group">
                                    <label>To Date:</label>
                                    <asp:TextBox ID="tDate" runat="server" CssClass="form-control" Width="100%"> 
                                    </asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="tDate">
                                    </cc1:CalendarExtender>
                                </div>
                           
                        
                            <div class="col-md-4 form-group">
                                    <label>Branch:</label>
                                    <asp:DropDownList ID="bName" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                           
                            <div class="col-md-4 form-group">
                                    <label>Group:</label>
                               
                                    <asp:DropDownList ID="aGroup" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </div>
                        </div>
                <br />
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="View Report" ValidationGroup="date"
                            OnClientClick="return ShowAssetGrpWise();" />
                    </div>
                </div>
                   </form>
                </div>  

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
