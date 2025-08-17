<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManagePastExperience.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManagePastExperience" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
     <script type="text/javascript" src="/Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ListPastExperience.aspx?Id=<%=GetEmpId().ToString()%>">List Experience  </a> &raquo; Manage Experience 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl"> Plese enter valid data!</span>                  
            <span class="required"> (* Required Fields)</span><br />
             <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                             Company Name: <span class="errormsg">*</span>
                    </label>
                <asp:RequiredFieldValidator 
                                  ID="RequiredFieldValidator8" runat="server" 
                                  ControlToValidate="txtCompanyName" Display="Dynamic" 
                                  ErrorMessage="Required!" ValidationGroup="education" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                  <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Location: <span class="errormsg">*</span>
                    </label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                  ControlToValidate="txtLocation" Display="Dynamic" ErrorMessage="Required!" 
                                  ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;<br />
                              <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Last Designation:<span class="errormsg">*</span>
                    </label>
                     
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                   ControlToValidate="txtLastdesigation" Display="Dynamic" ErrorMessage="Required!" 
                                   ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="txtLastdesigation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                             Last Salary:
                    </label>
                
                              <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                  ControlToValidate="txtLastSalary" Display="None" ErrorMessage=" " 
                                  ValidationGroup="education" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;
                                  <asp:Label ID="Label7" runat="server" CssClass="required" Text="*"></asp:Label>--%><br />
                              <asp:TextBox ID="txtLastSalary" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Service From:<span class="errormsg">*</span>
                    </label>
                    
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtServiceFrom" Display="Dynamic" ErrorMessage="Required!" 
                                   ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>
                              
                              <asp:TextBox ID="txtServiceFrom" runat="server" CssClass="form-control"></asp:TextBox>
                              <cc1:CalendarExtender ID="txtServiceFrom_CalendarExtender" runat="server" 
                                  Enabled="True" TargetControlID="txtServiceFrom">
                              </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Service To:<span class="errormsg">*</span>
                    </label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                  ControlToValidate="txtServiceTo" Display="Dynamic" ErrorMessage="Required!" 
                                  ValidationGroup="education" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;
                              <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                  ErrorMessage="Invalid Date!" Display="Dynamic" Operator="GreaterThan" 
                                  SetFocusOnError="True" Type="Date"  ValidationGroup="education" 
                                  ControlToCompare="txtServiceFrom" ControlToValidate="txtServiceTo"></asp:CompareValidator>
                              <asp:TextBox ID="txtServiceTo" runat="server" CssClass="form-control"></asp:TextBox>
                              <cc1:CalendarExtender ID="txtServiceTo_CalendarExtender" runat="server" 
                                  Enabled="True" TargetControlID="txtServiceTo">
                              </cc1:CalendarExtender>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
Remarks:
                    </label>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" 
                                   MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                   
                            <asp:HiddenField ID="txtempid" runat="server" />
                </div>
            </div>
             <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                                   Text="Save" ValidationGroup="education" 
                                  Width="75px" onclick="btnSave_Click" />
                              
                              <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                              </cc1:ConfirmButtonExtender>
                              
                              <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                               Text="Delete"  onclick="BtnDelete_Click"  />
                              <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                              </cc1:ConfirmButtonExtender>
                              <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                  Text="Back"  onclick="BtnBack_Click"  />
        </div>
    </div>

</asp:Content>