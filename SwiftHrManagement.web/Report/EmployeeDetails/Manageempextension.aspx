<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manageempextension.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.Manageempextension" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function GetEmpID(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=Hdnempid.ClientID%>").Value = customerValueArray[1];
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <div class="panel">     
                            <header class="panel-heading">
                                <i class="fa fa-caret-right"></i>
                                Employee Extension Report
                            </header>
                        </div>
                        <div class="panel panel-default">
                            <header class="panel-heading">
                                Employee extension Report
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>Branch :</label>
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" AutoPostBack="True" 
                                        onselectedindexchanged="DdlBranch_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                    <div class="form-group">
                                        <label>Department :</label>
                                        <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                    <div class="form-group">
                                            <asp:Button ID="BtnViewRpt" runat="server" CssClass="btn btn-primary" onclick="BtnViewRpt_Click" Text="View Report" />
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <header class="panel-heading">
                                    View employee extension
                            </header>
                            <div class="panel-body">
                                <div class="form-group autocomplete-form">
                                        <label>Employee :</label>
                                    <asp:TextBox ID="txtemployee" runat="server" CssClass="form-control" AutoPostBack="True" AutoComplete="off"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" 
                                            ServiceMethod="GetEmployeeExtensionList" TargetControlID="txtemployee" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                            CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="GetEmpID"></cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="txtemployee_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtemployee" 
                                            WatermarkCssClass="form-control"  WatermarkText="Auto Complete"></cc1:TextBoxWatermarkExtender>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="BtnViewRptEW" runat="server" CssClass="btn btn-primary" Text="View Report" onclick="BtnViewRptEW_Click" Visible="False" />
                                    <asp:HiddenField ID="Hdnempid" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>