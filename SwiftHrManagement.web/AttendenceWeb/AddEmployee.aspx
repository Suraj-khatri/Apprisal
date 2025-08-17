<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.AddEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function AutocompleteOnSelectedEmp(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpId.ClientID%>").Value = EmpIdArray[1];
            }
    </script>

    <%
        string url = GetURL().ToString();    
    %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Add Employee
                </header>
                <div class="panel-body">
                    <asp:HiddenField ID="hdnGroupId" runat="server" />
                    <asp:HiddenField ID="hdnEmpId" runat="server" />
                    <div class="form-group">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <label>Group Name:</label>
                        <asp:Label ID="lblGroupName" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                       <label>Employee Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtEmployeeName" ErrorMessage="Required!" 
                                        SetFocusOnError="True" ValidationGroup="add"> 
                        </asp:RequiredFieldValidator> 
                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" AutoComplete="off">
                        </asp:TextBox>                                           
                        <cc1:TextBoxWatermarkExtender ID="txtEmployeeName_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                            TargetControlID="txtEmployeeName" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>                            
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                            MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelectedEmp" 
                            ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                            TargetControlID="txtEmployeeName">
                        </cc1:AutoCompleteExtender>       
                    </div>
                    <div class="form-group">
                        <label>Status:</label>
                        <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="form-control">
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                        </asp:DropDownList>  
                     </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" ValidationGroup="add"  runat="server" CssClass="btn btn-primary" Text="Save" 
                            onclick="btnSave_Click"  />&nbsp;
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete " 
                            onclick="btnDelete_Click"  />&nbsp;
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="btnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
                     </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
