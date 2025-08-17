<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageAdhocContbution.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageAdhocContbution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="pnladhoccontribution" runat="server">
        <ContentTemplate>
            <div class="panel">
                <header class="panel-heading">
           <i class="fa fa-caret-right"></i>   <a href="chooseContributionType.aspx?Id=<%=GetEmpId().ToString()%> ">Selection Contribution</a> &raquo;
						        <a href="ListAdhocContbution.aspx?Id=<%=GetEmpId().ToString()%> ">List Adhoc Contribution  </a> &raquo;Manage Adhoc Contribution
                                    <asp:Label ID="LblEmpName" runat="server"></asp:Label> 
        </header>
                <div class="panel-body">
                    Plese enter valid data!
                    <span class="required">(* Required fields)<br />
                    </span>
                    <asp:HiddenField ID="hdnempid" runat="server" />
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                Contribution Code <span class="errormsg">*</span>
                            </label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="TxtContbCode" Display="None"
                                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                                ValidationGroup="ac"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="TxtContbCode" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Contribution To <span class="errormsg">*</span>
                            </label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlContbOn"
                                Display="None" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                                ValidationGroup="ac"></asp:RequiredFieldValidator><br />
                            <asp:DropDownList ID="DdlContbOn" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Contribution Amount Employer 
                            </label>

                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ControlToValidate="TxtAmountEmployer" Display="Dynamic"
                                ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double"
                                ValidationGroup="ac"></asp:CompareValidator>
                            <br />
                            <asp:TextBox ID="TxtAmountEmployer" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                Contribution Amount Employee
                            </label>
                            <asp:CompareValidator ID="CompareValidator2" runat="server"
                                ControlToValidate="TxtAmtEmployee" Display="Dynamic"
                                ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double"
                                ValidationGroup="ac"></asp:CompareValidator>
                            <br />
                            <asp:TextBox ID="TxtAmtEmployee" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <br/>
                            <label>
                                Is Applied?
                            </label>
                            <asp:CheckBox ID="ChkPaid" runat="server" 
                                AutoPostBack="True" OnCheckedChanged="ChkPaid_CheckedChanged" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Contribution Date <span class="errormsg">*</span></label>
                            <%--<asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDate" 
                    Display="None" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                    ValidationGroup="ac"></asp:RequiredFieldValidator>--%><br />
                            <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="TxtDate">
                            </cc1:CalendarExtender>

                        </div>
                        <div class="col-md-6 form-group">
                            <label>Narration</label>
                            <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control"
                                 TextMode="MultiLine"></asp:TextBox>
                        </div>
                        </div>
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                            OnClick="BtnSave_Click" ValidationGroup="ac" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                            OnClick="BtnDelete_Click1" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary"
                            Text="Back" />
                     </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
