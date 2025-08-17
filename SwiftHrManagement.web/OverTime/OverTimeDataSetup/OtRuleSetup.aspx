<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="OtRuleSetup.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.OverTimeDataSetup.OtRuleSetup" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <section class="panel">     
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>
                        Over Time Rule Setup
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            Please enter valid data!<span class="required"> (* Required fields!)</span>
                        </div>
                        <div class="form-group">       
                            <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
                        </div>
                        <div class="form-group">      
                            <label>No. Of Days in Month:<span class="required">*</span></label> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDaysInMonth" 
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="Rule">
                            </asp:RequiredFieldValidator> 
                            <asp:TextBox ID="txtDaysInMonth" runat="server" CssClass="form-control"></asp:TextBox>
                            
                        </div>
                        <div class="form-group">      
                            <label>No. Of Hour in Day:<span class="required">*</span></label> 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHourInDay" 
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="Rule">
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtHourInDay" runat="server" CssClass="form-control"></asp:TextBox>  
                            
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="Rule" 
                                onclick="BtnSave_Click1" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
</asp:Content>