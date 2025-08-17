<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="EmpMedicalHistory.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.EmpMedicalHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript" src="/Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ViewMedical.aspx?Id=<%=GetEmpId().ToString()%>">List Medical</a> &raquo; Manage Medical
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl">Please enter valid data!</span><br/>              
            <span class="required"> (* Required Fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
            <div class="row">
                 <asp:HiddenField ID="hdnEmpId" runat="server" />
                <div class="col-md-6 form-group">
                    <label>
                         Problem: <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Required!" ControlToValidate="txtproblem" Display="Dynamic" 
                ValidationGroup="Medical" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="txtproblem" runat="server" CssClass="form-control" 
                TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-md-6 form-group">
                    <label>
                         Diagnosis: <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator 
                  ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtdignosis" Display="Dynamic" 
                  ErrorMessage="Required!" ValidationGroup="Medical" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="txtdignosis" runat="server" CssClass="form-control" 
                  TextMode="MultiLine"></asp:TextBox>
                </div>
                </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                    Doctor:
                    </label>
                   
            <asp:TextBox ID="txtdoctor" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            
                <div class="col-md-6 form-group">
                    <label>
                          Hospital:
                    </label>
                  
            <asp:TextBox ID="txthospital" runat="server" CssClass="form-control" 
                   TextMode="MultiLine"></asp:TextBox>
                </div>
                </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                          Checked Date:
                    </label>
                 
            <asp:TextBox ID="txtcheckeddate" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
            TargetControlID="txtcheckeddate">
         </cc1:CalendarExtender>
                </div>
                <div class="col-md-6 form-group">
                    <label>
                        Disease:
                    </label>
            <asp:TextBox ID="txtdesease" runat="server" CssClass="form-control" 
                  TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="BtnSaveMedical" runat="server" CssClass="btn btn-primary" 
                  Text="Save" onclick="BtnSaveMedical_Click" UseSubmitBehavior="False" 
                  ValidationGroup="Medical" />
              <cc1:ConfirmButtonExtender ID="BtnSaveMedical_ConfirmButtonExtender" 
                  runat="server" ConfirmText="Confirm To Save?" Enabled="True" 
                  TargetControlID="BtnSaveMedical">
              </cc1:ConfirmButtonExtender>
              <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                  onclick="BtnDelete_Click" Text="Delete"  />
              <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                  ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
              </cc1:ConfirmButtonExtender>
              <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                  onclick="BtnBack_Click" Text="Back"/>
        </div>
    </div>

</asp:Content>


