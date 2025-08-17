<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageOtherInfo.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageOtherInfo" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UPDATEPANEL" runat="server">
<ContentTemplate>
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>   <a href="ListOtherInfo.aspx?Id=<%=GetEmpID().ToString()%>">Other List </a> &raquo; Employee Other Details Entry
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl"> Plese enter valid data!</span>                
            <span class="required"> (* Required Fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
            <div class="row">
                 <asp:TextBox ID="txtEmpId" runat="server" Visible="false"></asp:TextBox>
                <div class="col-md-4 form-group">
                    <label>
Marital Status For Tax:<span class="errormsg">*</span>
                    </label>
                    <asp:DropDownList ID="DdlMaritalStatus" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Select</asp:ListItem>
                <asp:ListItem Value="M">Married</asp:ListItem>
                <asp:ListItem Value="U">Unmarried</asp:ListItem>
                 </asp:DropDownList> <asp:RequiredFieldValidator 
                    ID="rfv" runat="server" ControlToValidate="DdlMaritalStatus" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="other"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Is Nepali Residence?
                    </label>
                    <asp:DropDownList ID="DdlResidence" runat="server"  CssClass="form-control">                
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Value="N">No</asp:ListItem>
                 </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Remote Location Group:
                    </label>
                    <asp:DropDownList ID="DdlRlGroup" runat="server"  CssClass="form-control"> 
                <asp:ListItem Value="">Select</asp:ListItem>               
                <asp:ListItem Value="A">A</asp:ListItem>
                <asp:ListItem Value="B">B</asp:ListItem>
                <asp:ListItem Value="C">C</asp:ListItem>
                <asp:ListItem Value="D">D</asp:ListItem>
                <asp:ListItem Value="E">E</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Vehicle Facility Availed?
                    </label>
                    <asp:CheckBox ID="checkVehicle" runat="server" />
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        House Facility Availed?
                    </label>
                     <asp:CheckBox ID="checkHouse" runat="server" />
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Differently Able:
                    </label>
                    <asp:CheckBox ID="checkDisabled" runat="server" 
                    AutoPostBack="True" oncheckedchanged="checkDisabled_CheckedChanged" />
            <asp:TextBox ID="txtDisabledID" runat="server" CssClass="form-control" ></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtDisabledID_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtDisabledID">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="txtDisabledID_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtDisabledID" 
                    WatermarkText="Disabled ID">
                </cc1:TextBoxWatermarkExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>Is Pension Holder?</label>
                    <asp:CheckBox ID="checkPensionHolder" 
                    runat="server" AutoPostBack="True" 
                    oncheckedchanged="checkPensionHolder_CheckedChanged" />
            <asp:TextBox ID="txtPensionAmt" runat="server" watermark="Pension Amount" CssClass="form-control"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtPensionAmt_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtPensionAmt">
                </cc1:FilteredTextBoxExtender>
                <cc1:TextBoxWatermarkExtender ID="txtPensionAmt_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtPensionAmt" 
                    WatermarkText="Annual Pension Amt">
                </cc1:TextBoxWatermarkExtender>
                    </div>
            </div>
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                  OnClick="btnSave_Click" Text="Save" ValidationGroup="other" />
              
              <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                  ConfirmText="Are you sure to update?" Enabled="True" TargetControlID="btnSave">
              </cc1:ConfirmButtonExtender>
              
              <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                  onclick="BtnBack_Click" Text="Back" />
        </div>
    </div>

            
</ContentTemplate>
</asp:UpdatePanel>  
</asp:Content>
