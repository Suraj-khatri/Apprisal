<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageTadaReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.TADAReport.ManageTadaReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
             <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Travel Order Report
                        </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12 form-group autocomplete-form">
                                    <label>Employee Name:</label>
                                    <asp:Label ID="lblEmpName" runat="server" Font-Bold="true"
                                            Font-Size="13px"></asp:Label><br />
                                    <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control"
                                            AutoPostBack="true" ontextchanged="txtEmpName_TextChanged"></asp:TextBox>

                                    <cc1:AutoCompleteExtender ID="aceEmpName" runat="server" 
                                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName">
                                    </cc1:AutoCompleteExtender>

                                    <cc1:TextBoxWatermarkExtender ID="wmeEmpName" 
                                    runat="server" Enabled="True" TargetControlID="txtEmpName" 
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>Branch:</label>
                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" 
                                        onselectedindexchanged="ddlBranch_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList> 
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Department:</label>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>Destination Country:</label>
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                                    </asp:DropDownList>  
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Reason For Travel:</label>
                                    <asp:DropDownList ID="ddlTravel" runat="server" CssClass="form-control">
                                    </asp:DropDownList> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>Status:</label>
                                    <asp:DropDownList ID="DdlStatus" runat="server" CssClass="form-control">
                                    </asp:DropDownList> 
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Reimbursement Status:</label>
                                    <asp:DropDownList ID="DdlreimStatus" runat="server" CssClass="form-control">
                                    </asp:DropDownList> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>From Date:</label>
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfromdate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>To Date:</label>
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group">
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnView_Report" Text=" View Report " />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group">
                                    <div runat="server" id="rpt"></div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnempId" runat="server" />
</asp:Content>
