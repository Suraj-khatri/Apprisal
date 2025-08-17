<%--<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="TrainingDetails.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.TrainingDetails" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="TrainingDetails.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.TrainingDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  <a href="ListTrainingItems.aspx?Id=<%=GetEmpId().ToString()%>">List Training  </a> &raquo; Manage Training 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl">Plese enter valid data!</span><br />
            <span class="required">(* Required Fields)</span><br />
            <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Training Type: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator8" runat="server"
                        ControlToValidate="ddlfecaulty" Display="Dynamic"
                        ErrorMessage="Required!" ValidationGroup="education"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlfecaulty" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <div class="row">
                        <div class="col-md-8">
                            <label>
                                Duration:<span class="errormsg">*</span>
                            </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtDuration" Display="Dynamic" ErrorMessage="Required!"
                                ValidationGroup="education" SetFocusOnError="True" ></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control"></asp:TextBox> 
                        </div>
                        <div class="col-md-4">
                             <br/><br/>days
                        </div>
                    </div>
                   
                   
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Name of Institution: <span class="errormsg">*</span>
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="txtnameofinstitution" Display="Dynamic" ErrorMessage="Required!"
                        ValidationGroup="education" SetFocusOnError="True" CssClass="form-control"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtnameofinstitution" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Address: <span class="errormsg">*</span>
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Required!"
                        ValidationGroup="education" CssClass="form-control"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Training Description: <span class="errormsg">*</span>
                    </label>
                    <asp:TextBox ID="txtTrndescription" runat="server" CssClass="form-control"
                        MaxLength="200" TextMode="MultiLine"></asp:TextBox>

                    <asp:HiddenField ID="txtempid" runat="server" />
                </div>
            </div>

            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary"
                Text="Save" ValidationGroup="education"
                OnClick="btnSave_Click" />

            <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
            </cc1:ConfirmButtonExtender>

            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                Text="Delete" Width="75px" OnClick="BtnDelete_Click" />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                Text="Back" OnClick="BtnBack_Click" />
        </div>
    </div>

</asp:Content>
