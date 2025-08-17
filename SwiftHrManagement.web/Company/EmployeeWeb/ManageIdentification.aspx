<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageIdentification.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageIdentification" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
               <i class="fa fa-caret-right"></i><a href="ListIdentification.aspx?Id=<%=GetEmpId().ToString()%>">List Identification  </a> &raquo; Manage Identification
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl"> Plese enter valid data!</span><br/>                  
            <span class="required"> (* Required Fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
            <div class="row">
                 <asp:HiddenField ID="hdnEmpId" runat="server" />
                <div class="col-md-4 form-group">
                    <label>
                        Card Type: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="DdlCardType" Display="Dynamic" 
                                    ErrorMessage="Required!" ValidationGroup="id" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                <asp:DropDownList ID="DdlCardType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Card Number: <span class="errormsg">*</span>
                    </label>
                    
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtCardNo" Display="Dynamic" ErrorMessage="Required!" 
                                    ValidationGroup="id" SetFocusOnError="True"></asp:RequiredFieldValidator>                               
                                <br />                               
                                <asp:TextBox ID="txtCardNo" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Issue Place: 
                    </label>
                <asp:TextBox ID="txtIssuePlace" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Issue Date: <span class="errormsg">*</span>
                    </label>
                      <asp:RequiredFieldValidator 
                                  ID="RequiredFieldValidator2" runat="server" 
                                  ControlToValidate="txtIssueDate" Display="Dynamic" 
                                  ErrorMessage="Required!" ValidationGroup="id" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                              <asp:TextBox ID="txtIssueDate" runat="server"  CssClass="form-control"></asp:TextBox>
                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                  Enabled="True" TargetControlID="txtIssueDate">
                              </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Expiry Date: 
                    </label>
                                <asp:TextBox ID="txtExpiryDate" runat="server"  CssClass="form-control"></asp:TextBox>
                               
                               <cc1:CalendarExtender ID="txtExpiryDate_CalendarExtender" runat="server" 
                                   Enabled="True" TargetControlID="txtExpiryDate">
                               </cc1:CalendarExtender>
                </div>
                
            </div>
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                                  ValidationGroup="id" onclick="BtnSave_Click" />
                              
                              <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                              </cc1:ConfirmButtonExtender>
                              
                              <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                                  onclick="BtnDelete_Click" Text="Delete" />
                              <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                              </cc1:ConfirmButtonExtender>
                              <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                  onclick="BtnBack_Click" Text="Back"  />
        </div>
    </div>


</asp:Content>
