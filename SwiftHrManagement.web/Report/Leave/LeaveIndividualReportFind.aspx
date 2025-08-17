<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveIndividualReportFind.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveIndividualReportFind" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">     
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                             Individual Leave Report
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                Please enter valid data!<span class="required"> (* Required fields!)</span>
                                <asp:HiddenField ID="Hdnempid" runat="server"/>
                            </div>     
                            <div class="form-group">
                                <label>Employee :<span class="errormsg">*</span></label>
                                <asp:TextBox ID="txtemployee" runat="server" CssClass="form-control" AutoPostBack="true" 
                                    AutoComplete="off"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10" 
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                                    Enabled="true" MinimumPrefixLength="1" OnClientItemSelected="GetEmpID" ServiceMethod="GetEmployeeList"
                                     ServicePath="~/Autocomplete.asmx" TargetControlID="txtemployee">
                                </cc1:AutoCompleteExtender>
                                <cc1:TextBoxWatermarkExtender ID="txtemployee_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                    TargetControlID="txtemployee" WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                </div>
                                <div class="form-group">
                                    <label>Year :</label>
                                    <asp:DropDownList ID="DdlYearIndividual" runat="server" CssClass="form-control" 
                                        AutoPostBack="true"></asp:DropDownList>
                                </div>
                                 <div class="form-group">
                                     <asp:Button ID="btnCurrent" runat="server" Text="Present Report" CssClass="btn btn-primary" 
                                         onclick="btnCurrent_Click"/>
                                     <asp:Button ID="btnHistory" runat="server" Text="History Report" CssClass="btn btn-primary"
                                         onclick="btnHistory_Click"/>
                                 </div>
                                 <div class="form-group">
                                     <asp:Label ID="LblMsg" runat="server" CssClass="errormsg" Text=""></asp:Label>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <script type="text/javascript" language="javascript">
            function GetEmpID(sender, e) {
                var customerValueArray = (e._value).split("|");
                document.getElementById("<%=Hdnempid.ClientID%>").Value = customerValueArray[1];
               }
        </script>
</asp:Content>




