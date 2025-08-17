<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master"  AutoEventWireup="true" CodeBehind="AddRelative.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.AddRelative" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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

    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" onclick="btnDeleteRecord_Click" style="display:none;"/>
     <div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  Relative Entry
        </header>
        <div class="panel-body">
            <asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID = "rambo" Value = "lkch" runat ="server" />
            <div class="row">
                <div class="col-md-4 form-group autocomplete-form">
                    <asp:Label ID="lblmsg" runat="server" CssClass="txtlbl"></asp:Label>
                    <input type = "hidden" name = "hddEmpId" id =  "hddEmpId" />
                    <label>Relative Name:<span class="required">*</span></label>
                    <asp:TextBox ID="txtRelative" runat="server"
                    CssClass="form-control" AutoPostBack="false" AutoComplete="off"></asp:TextBox>                     
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                    DelimiterCharacters="" Enabled="true" 
                    ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                    TargetControlID="txtRelative" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                    OnClientItemSelected="GetEmpID">
                    </cc1:AutoCompleteExtender>
                    <cc1:TextBoxWatermarkExtender ID="txtemployee_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtRelative" 
                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                    </cc1:TextBoxWatermarkExtender>                     
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtRelative" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="relative"></asp:RequiredFieldValidator> 
                </div>
                <div class="col-md-4 form-group">
                    <label>Relation:<span class="required">*</span></label>
                    <asp:DropDownList ID="ddlRelation" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlRelation" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="relative"></asp:RequiredFieldValidator>   
                </div>                
            </div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="relative" 
                        onclick="btnSave_Click"/>
                    <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                    </cc1:ConfirmButtonExtender>
        <div runat="server" id="rpt"></div>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</div>
</asp:Content>
