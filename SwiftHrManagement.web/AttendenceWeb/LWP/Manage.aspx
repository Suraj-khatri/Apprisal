<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.LWP.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            height: 26px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Absent LWP
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:HiddenField ID="HiddenFieldEmpID" runat="server" />
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Form Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Required" ControlToValidate="txtFromDate" ValidationGroup="LFA"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtFromDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label>To Date:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"  ControlToValidate="TxtToDate" ValidationGroup="LFA">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtToDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group autocomplete-form">
                        <label>Employee:</label>
                        <asp:TextBox ID="txtEmpId" runat="server" CssClass="form-control" AutoPostBack="true" AutoComplete="Off" ></asp:TextBox>             
                        <cc1:TextBoxWatermarkExtender ID="txtEmpId_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtEmpId" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:AutoCompleteExtender ID="txtEmpId_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                            ServicePath="~/Autocomplete.asmx" 
                            TargetControlID="txtEmpId"  OnClientItemSelected="AutocompleteOnSelected" >
                        </cc1:AutoCompleteExtender>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="ButtonSearch" runat="server" CssClass="btn btn-primary" Text="Search" 
                            onclick="ButtonSearch_Click" ValidationGroup="LFA"/>
                    </div>
                </div>
            </section>
        </div>
    </div>

<script language=javascript>


    function AutocompleteOnSelected(sender, e) {
        var CustodianValueArray = (e._value).split("|");
        var HiddenFieldEmpID = document.getElementById("<%=HiddenFieldEmpID.ClientID %>");

        HiddenFieldEmpID.value = CustodianValueArray[1];
        //alert(HiddenFieldEmpID.value);
    }
</script>

</asp:Content>
