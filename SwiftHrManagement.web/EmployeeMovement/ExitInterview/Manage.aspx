<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.Exit_Interview.Manage" Title="Swift HRM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function DeleteNotification(TOID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =hdnExitId.ClientID %>").value = TOID;
                document.getElementById("<% =BtnDelete1.ClientID %>").click();
            }
        }
        function EditNotification(RowID) {
            if (confirm("Are you sure to Edit this message?")) {
                document.getElementById("<% =hdnExitEditId.ClientID %>").value = RowID;
            document.getElementById("<% =BtnEdit.ClientID %>").click();
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">

                    <div class="panel">
                        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> Exit Interview Entry Details
        </header>
                        <div class="panel-body">
                            Please enter valid  data! &nbsp;<span class="required">(* are required fields)</span>
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnExitId" runat="server" />
                            <asp:HiddenField ID="hdnExitEditId" runat="server" />
                            <asp:Panel ID="downPanel" runat="server" GroupingText="Employee Information" CssClass="">
                                <div class="row">
                                    <div class="col-md-12 form-group">
                                        <div id="EmployeeName" runat="server" class="txtlbl">Employee Name :</div>
                                        <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-12 form-group">
                                        <div id="Branch" runat="server" class="txtlbl">Branch :</div>
                                        <asp:Label ID="lblBranch" runat="server" CssClass="label"></asp:Label>
                                    </div>
                                    <div class="col-md-12 form-group">
                                        <div id="Department" runat="server" class="txtlbl">Department :</div>

                                        <asp:Label ID="lblDept" runat="server" CssClass="label"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>


                            <asp:Panel ID="Panel1" runat="server" GroupingText="Exit Reasons" CssClass="">
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <asp:CheckBoxList ID="chk1" runat="server" RepeatDirection="vertical" CellSpacing="3" CellPadding="3">
                                            <asp:ListItem Value="AnotherOrganization">Another Organization </asp:ListItem>
                                            <asp:ListItem Value="PersonalReasons">Personal Reasons</asp:ListItem>
                                            <asp:ListItem Value="Relocation">Relocation</asp:ListItem>
                                            <asp:ListItem Value="Retirement">Retirement</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <asp:CheckBoxList ID="chk2" runat="server" RepeatDirection="vertical" CellSpacing="3" CellPadding="3">
                                            <asp:ListItem Value="Reorganization">Reorganization</asp:ListItem>
                                            <asp:ListItem Value="PositionEliminatedRedundant">Position Eliminated - Redundant</asp:ListItem>
                                            <asp:ListItem Value="ReturntoSchool">Return to School</asp:ListItem>
                                            <asp:ListItem Value="Outstanding">Other</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label>Employee Comments:</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txtComments" Display="dynamic"
                                            ErrorMessage="Required" SetFocusOnError="True"
                                            ValidationGroup="exit">
                                        </asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="Panel3" runat="server" GroupingText="Question Answer Info" CssClass="">
                                <asp:Label ID="lblQueMsg" runat="server" Text=""></asp:Label>
                                <div class="row">
                                    <div class="col-md-4 form-group">
                                        <label>
                                            Question Type: <span class="errormsg">*</span>
                                        </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                            ControlToValidate="DdlQuestionType" Display="dynamic"
                                            ErrorMessage="Required" SetFocusOnError="True"
                                            ValidationGroup="save"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:DropDownList ID="DdlQuestionType" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label>
                                            Answer For the Question: <span class="errormsg">*</span>
                                        </label>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                            ControlToValidate="txtAnswer" Display="dynamic"
                                            ErrorMessage="Required" SetFocusOnError="True"
                                            ValidationGroup="save"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                                    OnClick="BtnSave_Click1" ValidationGroup="save" />
                                <asp:Button ID="BtnDelete1" runat="server" Text="Delete" OnClick="BtnDelete1_Click" Style="display: none" />
                                <asp:Button ID="BtnEdit" runat="server" Text="Edit" OnClick="BtnEdit_Click" Style="display: none" />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="rpt" runat="server"></div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Button ID="BtnFinalSubmit" runat="server" CssClass="btn btn-primary"
                                Text="Final Submit" ValidationGroup="exit"
                                OnClick="BtnFinalSubmit_Click" />
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                                OnClick="BtnDelete_Click" Text="Delete" Style="display: none" />
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                OnClick="BtnBack_Click" Text="Back" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
