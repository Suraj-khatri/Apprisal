<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageEmployeeReference.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageEmployeeReference" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/Jsfunc.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ListEmployeeReferience.aspx?Id=<%=GetEmpId().ToString()%>">List Reference  </a> &raquo; Manage Reference 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
            <asp:HiddenField ID="txtempid" runat="server" />
                          
        <div class="panel-body">
            <span class="txtlbl"> Plese enter valid data!</span><br/>                  
            <span class="required"> (* Required Fields)</span><br />
                                                                    <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Full Name: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator 
                                  ID="RequiredFieldValidator8" runat="server" 
                                  ControlToValidate="txtFullName" Display="Dynamic" 
                                  ErrorMessage="Required!" ValidationGroup="Ref" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                  <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Address:
                    </label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                  ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Required!" 
                                  ValidationGroup="Ref" SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;
                                  <asp:Label ID="Label5" runat="server" CssClass="required" Text="*"></asp:Label><br />
                              <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Home Phone No:
                    </label>
                  
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                   ControlToValidate="txtHomepne" Display="Dynamic" ErrorMessage="Required!" 
                                   ValidationGroup="Ref" SetFocusOnError="True"></asp:RequiredFieldValidator>
                               &nbsp;<asp:Label ID="Label6" runat="server" CssClass="required" 
                                   Text="*"></asp:Label><br />
                              <asp:TextBox ID="txtHomepne" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Office Phone No:
                    </label>
                              <asp:TextBox ID="txtOfficepne" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Mobile No: 
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Required!" 
                                   ValidationGroup="Ref" SetFocusOnError="True"></asp:RequiredFieldValidator>
                               &nbsp;<asp:Label ID="Label1" runat="server" CssClass="required" 
                                   Text="*"></asp:Label><br />
                              <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Fax No:
                    </label>
                   
                              <asp:TextBox ID="txtfaxNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Email:
                    </label>
                 
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" 
                                   ></asp:TextBox>
                                    <asp:RegularExpressionValidator 
                                                ID="RegularExpressionValidator1" runat="server" 
                                                ControlToValidate="txtEmail" ErrorMessage="Invalid Email!" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                SetFocusOnError="True" ValidationGroup="Ref"></asp:RegularExpressionValidator>
                </div>
               
            </div>
             <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                                   Text="Save" ValidationGroup="Ref" 
                                  Width="75px" onclick="btnSave_Click"  />
                              
                              <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                              </cc1:ConfirmButtonExtender>
                              
                              <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                               Text="Delete" Width="75px" onclick="BtnDelete_Click"   />
                              <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                              </cc1:ConfirmButtonExtender>
                              <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                  Text="Back"  onclick="BtnBack_Click"   />
        </div>
    </div>

</asp:Content>
