<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageGroup.aspx.cs" Inherits="SwiftHrManagement.web.MessagingPortal.ManageGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../js/listBoxMovement.js" type="text/javascript"></script>
    <script type="text/javascript">
        function add() {

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
    <div class="row">
        <div class="col-lg-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Manage Group
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Group Name:</label>
                    </div>
                    <div class="row">
                        <div class="col-md-10">
                            <div class="form-group">
                                <asp:TextBox ID="groupName" CssClass="form-control" runat="server" ValidationGroup="group"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="grpNameRFV" runat="server" ControlToValidate="groupName" ValidationGroup="group"
                                    SetFocusOnError="true" ForeColor="Red" ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Button ID="addGroup" runat="server" Text="Add" OnClick="addGroup_Click" CssClass="btn btn-primary" ValidationGroup="group" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-10">
                            <div class="form-group">
                                <label>Select Group:</label>
                                <asp:DropDownList ID="groupDDL" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="groupDDL_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Employee Name:</label>
                            </div>
                        </div>
                        <div class="col-md-10">
                            <div class="form-group autocomplete-form">
                                <asp:Label ID="lblEmpName" runat="server" Font-Bold="true"/>
                                
                                <asp:TextBox ID="empName" runat="server" CssClass="form-control" AutoPostBack="true" ValidationGroup="emp"/>
                                <cc1:AutoCompleteExtender ID="aceEmpName" runat="server"
                                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                    DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                    ServicePath="~/Autocomplete.asmx" TargetControlID="empName" />
                                <cc1:TextBoxWatermarkExtender ID="wmeEmpName"
                                    runat="server" Enabled="True" TargetControlID="empName"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete" />
                                <asp:RequiredFieldValidator ID="empRFV" runat="server" SetFocusOnError="true" 
                                    ControlToValidate="empName" ValidationGroup="emp"
                                    ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Button ID="addEmp" runat="server" Text="Add" OnClick="addEmp_Click" CssClass="btn btn-primary" ValidationGroup="emp" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="form-group">
                                <label>Employees Not in Group:</label>
                                <asp:DropDownList ID="groupMemberDDL1" runat="server" CssClass="form-control" size="30" multiple="multiple">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div align="center" class="btn btn-primary" onclick="return  listbox_moveacross('<%=groupMemberDDL1.ClientID %>', '<%=groupMemberDDL2.ClientID %>');"><i class="fa fa-arrow-right" aria-hidden="true"></i></div>
	                            <div align="center"  class="btn btn-primary" onclick="return listbox_moveacross('<%=groupMemberDDL2.ClientID %>', '<%=groupMemberDDL1.ClientID %>');"><i class="fa fa-arrow-left" aria-hidden="true"></i></div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <label>Employees in Group:</label>
                                <asp:DropDownList ID="groupMemberDDL2" runat="server" CssClass="form-control" size="30" multiple="multiple">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="saveButton" runat="server" Text="Save Group" CssClass="btn btn-primary" OnClick="saveButton_Click" />
                        <asp:Button ID="removeButton" runat="server" Text="Remove Selected" CssClass="btn btn-primary" OnClick="removeButton_Click" />
                    </div>
                </div>
            </section>
        </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
