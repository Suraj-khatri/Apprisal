<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageContribution.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageContribution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <a href="chooseContributionType.aspx?Id=<%=GetEmpId().ToString()%> ">Selection Page</a> &raquo;
			   <i class="fa fa-caret-right"></i>			<a href="ListContribution.aspx?Id=<%=GetEmpId().ToString()%> ">List Regular Contribution  </a> &raquo;Manage Regular Contribution
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            Please enter valid data!
            
            <span class="required">(* Required fields)</span><br />
            <asp:Label ID="lblTransactionMessage" runat="server" Text=""></asp:Label><br />
            <asp:HiddenField ID="hdnempid" runat="server" />
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Contribution Code <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="RequiredFieldValidator"
                        ControlToValidate="TxtContributionCode" Display="None"
                        ValidationGroup="contribution"></asp:RequiredFieldValidator><br />
                    <asp:TextBox ID="TxtContributionCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Contribution To <span class="errormsg">*</span>
                    </label>
                    <asp:DropDownList ID="DdlContributedTo" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                </div>

                <div class="row">
                   
                    <div class="col-md-6 form-group">
                        <div class="row">
                            <div class="col-md-12">
                              <b>EMPLOYEE'S CONTRIBUTION DETAILS</b>  
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contribution Basis
                                </label>

                                <asp:DropDownList ID="DdlContbonEmpl" runat="server"
                                    CssClass="form-control"
                                    OnSelectedIndexChanged="DdlContbonEmpl_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="F">Flat</asp:ListItem>
                                    <asp:ListItem Value="P">Percentage</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contr. Rate/Amount 
                                </label>

                                <asp:CompareValidator ID="cv" runat="server"
                                    ControlToValidate="TxtContributionRateEmployee" Display="Dynamic"
                                    ErrorMessage="Invalid Rate/Amt!" SetFocusOnError="True" Type="Double"
                                    ValidationGroup="contribution"></asp:CompareValidator>
                                <br />
                                <asp:TextBox ID="TxtContributionRateEmployee" runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contribution on 
                                </label>

                                <asp:DropDownList ID="DdlcontbBasisEmployee" runat="server"
                                    CssClass="form-control">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="36">Basic Salary</asp:ListItem>
                                    <asp:ListItem Value="36,37">Basic Salary and Grade</asp:ListItem>
                                    <asp:ListItem Value="36,37,38">Gross Salary</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contribution Start Date 
                                </label>
                                <asp:TextBox ID="TxtContributionFromDateEmployee" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtContributionFromDateEmployee_CalendarExtender"
                                    runat="server" Enabled="True" TargetControlID="TxtContributionFromDateEmployee">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                   </div>
                    <div class="col-md-6 form-group">
                        <div class="row">
                            <div class="col-md-12">
                               <b>EMPLOYER'S CONTRIBUTION DETAILS</b> 
                            </div>
                            <div class="col-md-12 form-group">
                                
                                <label>
                                    Contribution Basis
                                </label>

                                <asp:DropDownList ID="DdlContbonEmplr" runat="server"
                                    CssClass="form-control"
                                    OnSelectedIndexChanged="DdlContbonEmplr_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="F">Flat</asp:ListItem>
                                    <asp:ListItem Value="P">Percentage</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contr. Rate/Amount 
                                </label>

                                <asp:CompareValidator ID="cv2" runat="server"
                                    ControlToValidate="TxtContributionRateEmployer" Display="Dynamic"
                                    ErrorMessage="Invalid Rate/Amt!" SetFocusOnError="True"
                                    ValidationGroup="contribution" Type="Double"></asp:CompareValidator>
                                <br />
                                <asp:TextBox ID="TxtContributionRateEmployer" runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contribution on
                                </label>

                                <asp:DropDownList ID="DdlcontbBasisEmployer" runat="server"
                                    CssClass="form-control">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="36">Basic Salary</asp:ListItem>
                                    <asp:ListItem Value="36,37">Basic Salary and Grade</asp:ListItem>
                                    <asp:ListItem Value="36,37,38">Gross Salary</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>
                                    Contribution Start Date 
                                </label>
                                <asp:TextBox ID="TxtContributionFromDateEmployer" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtContributionFromDateEmployer_CalendarExtender"
                                    runat="server" Enabled="True" TargetControlID="TxtContributionFromDateEmployer">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                    OnClick="BtnSave_Click" ValidationGroup="contribution" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                    OnClick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back"
                    OnClick="BtnCancel_Click" />
            </div>
        </div>
    </div>

</asp:Content>

