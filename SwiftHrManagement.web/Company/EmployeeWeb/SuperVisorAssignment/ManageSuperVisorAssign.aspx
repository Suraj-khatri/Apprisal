<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="ManageSuperVisorAssign.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment.ManageSuperVisorAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function GetEmpID(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("hddEmpId").Value = customerValueArray[1];
        }
        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
            }
        }
    </script>
    <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/";
    </script>

    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>

    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="display: none;" />

    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    SuperVisor Assignment form
                </header>
                <div class="panel-body">
                    <div class="col-md-10">
                        <span class="txtlbl">Plese enter valid data! </span>
                        <span class="required">(* Required Fields)</span><br />
                        <asp:Label ID="lblmsg" runat="server" Style="font-weight: 700"></asp:Label>
                        <input type="hidden" name="hddEmpId" id="hddEmpId" />
                    </div>
                    <div class="col-md-12 form-group autocomplete-form">
                        <label>Employee:</label>
                        <asp:Label ID="lblEmpName" runat="server" Font-Bold="true"
                            Font-Size="13px" />
                        <asp:HiddenField ID="hfEmpName" runat="server" />
                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" Width="90%"
                            AutoPostBack="true" OnTextChanged="txtEmpName_TextChanged" />
                        <cc1:AutoCompleteExtender ID="aceEmpName" runat="server"
                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName" />
                        <cc1:TextBoxWatermarkExtender ID="wmeEmpName"
                            runat="server" Enabled="True" TargetControlID="txtEmpName"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete" />
                    </div>
                    <div class="col-md-12 form-group">
                        <div runat="server" id="rpt"></div>
                    </div>
                    <div class="col-md-12 form-group autocomplete-form">
                        <label>Supervisor Name:<span class="required">*</span></label>
                        <asp:TextBox ID="txtSuperVisor" runat="server" Width="90%"
                            CssClass="form-control" AutoPostBack="false" AutoComplete="off">
                        </asp:TextBox> 
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                            DelimiterCharacters="" Enabled="true"
                            ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                            TargetControlID="txtSuperVisor" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                            OnClientItemSelected="GetEmpID" />
                        <cc1:TextBoxWatermarkExtender ID="txtemployee_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtSuperVisor"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtSuperVisor" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="Supervisor" />
                    </div>
                    <div class="col-md-12 form-group">
                        <label>Supervisor Type:<span class="required">*</span></label>
                        <asp:DropDownList ID="DdlSuperVisorType" runat="server" Width="90%" CssClass="form-control">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="i">Immediate SuperVisor 1</asp:ListItem>
                        <asp:ListItem Value="s">Immediate SuperVisor 2</asp:ListItem>
                        <%--   <asp:ListItem Value="h">HR Committe</asp:ListItem>
                        <asp:ListItem Value="r">Reviewer Committe</asp:ListItem>
                        <asp:ListItem Value="in">Incharge</asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="DdlSuperVisorType" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="Supervisor"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-12 form-group">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                            Text="Save" ValidationGroup="Supervisor" OnClick="btnSave_Click" />
                        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>
                    </div>
                   </div>


                <ul class="list-group" style="list-style-type:none;padding:10px">
                 <li class="list-group-item-danger" style="line-height:25px"> Please assign your immediate supervisor only as "Immediate Supervisor 1" in Supervisor Type. </b></li>
                <li class="list-group-item-danger" style="line-height:25px"> "Immediate Supervisor 2" is only for Branch Manager Function having dual reporting line of Business and Operations. </li>
                <li class="list-group-item-danger" style="line-height:25px"> For all other functions "Immediate Supervisor 1" to be assigned. </li>
                </ul>
                
            </section>

           
        </div>
    </div>
</asp:Content>
