<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageOtRateSetUp.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.OverTimeDataSetup.ManageOtRateSetUp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style10
        {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    

<div class="row">
    <div class="col-md-4 col-md-offset-3">
        <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Over Time Rate SetUp
            </header>
            <div class="panel-body">

                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Description:<span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Required!" ControlToValidate="txtDescription" AutoComplete="Off"
                        Display="Dynamic" ValidationGroup="Ot" BorderColor="#FFFF66"
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        
                </div>
                <div class="form-group">
                    <label>Rate Type:<span class="errormsg">*</span></label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Required!" ControlToValidate="DdlRateType" AutoComplete="Off"
                        Display="Dynamic" ValidationGroup="Ot" BorderColor="#FFFF66"
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlRateType" runat="server" CssClass="form-control" Width="100%" onselectedindexchanged="DdlRateType_SelectedIndexChanged" AutoPostBack="true"> 
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="h">Hourly</asp:ListItem>
                        <asp:ListItem Value="d">Daily</asp:ListItem>
                        <asp:ListItem Value="f">Flat</asp:ListItem>
                    </asp:DropDownList>
                       
                </div>
                <div class="form-group">
                    <label>OverTime On:</label>
                    <asp:DropDownList ID="DdlOverTimeON" runat="server" CssClass="form-control" Width="100%"> 
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="36">Basic</asp:ListItem>
                        <asp:ListItem Value="36,37">Basic & Grade</asp:ListItem>
                        <asp:ListItem Value="36,37,38">Gross</asp:ListItem>
                    </asp:DropDownList>
                       
                </div>
                            
                <div class="form-group">
                    <label>Amount:<span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Required!" ControlToValidate="txtAmount" AutoComplete="Off"
                        Display="Dynamic" ValidationGroup="Ot" BorderColor="#FFFF66" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        
                </div>
                
                 <div class="form-group">
                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary"  ValidationGroup="Ot" onclick="BtnSave_Click1" />
                    <asp:Button ID="Btn_delete" runat="server" Text="Delete" CssClass="btn btn-primary" onclick="Btn_delete_Click" />         
                    <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary" onclick="BtnBack_Click"  />
                        
                </div>
            </div>
        </section>
    </div>
</div>



</asp:Content>