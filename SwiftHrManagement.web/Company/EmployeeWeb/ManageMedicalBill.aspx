<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageMedicalBill.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageMedicalBill" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" type="text/css" />  
    <script type="text/javascript" src="/Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ListMedicalBill.aspx?Id=<%=GetEmpId().ToString()%>">List Medical Bill </a> &raquo; Manage Medical Bill
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl">Please enter valid data!</span></br>              
            <span class="required"> (* Required Fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>  
            <div class="row">
                <asp:HiddenField ID="hdnEmpId" runat="server" />
                <div class="col-md-4 form-group">
                    <label>
  Bill Date: <span class="errormsg">*</span> 
                    </label>
                  
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                TargetControlID="txtBillDate"></cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Required!" ControlToValidate="txtBillDate" Display="Dynamic" 
                ValidationGroup="Medical" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" ></asp:TextBox>
           
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Bill Amount:<span class="errormsg">*</span>
                    </label>
                   
            <asp:CompareValidator 
                ID="cv2" runat="server" ControlToValidate="txtBillAmount" Display="Dynamic" 
                ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                ValidationGroup="Medical"></asp:CompareValidator>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Required!" ControlToValidate="txtBillAmount" Display="Dynamic" 
                ValidationGroup="Medical" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtBillAmount" runat="server" CssClass="form-control"  ></asp:TextBox>
                </div>
                <div class="col-md-6 form-group">
                    <label>
  Narration:
                    </label>
                  
            <asp:TextBox ID="txtNarration" runat="server" CssClass="form-control" 
                TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>
            <br/>
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
            Text="Save" onclick="BtnSaveMedical_Click" UseSubmitBehavior="False" 
            ValidationGroup="Medical" />
            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" 
            runat="server" ConfirmText="Confirm To Save?" Enabled="True" 
            TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
            onclick="BtnDelete_Click" Text="Delete"  />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
            onclick="BtnBack_Click" Text="Back" />
        </div>
    </div>
</asp:Content>
