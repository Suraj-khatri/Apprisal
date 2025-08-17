<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageSalarySet.aspx.cs" Inherits="SwiftHrManagement.web.SalarySet.ManageSalarySet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <%--<link href="../Css/style.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:Label ID="abc" runat="server"></asp:Label>
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                             Salary Set Setup
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label>Salary Title:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="ddlSalaryTitle" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="salaryset" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddlSalaryTitle" runat="server" CssClass="form-control" Width="100%"> 
                                </asp:DropDownList>
                                    
                            </div>
                            
                            <div class="form-group">
                                <label>Description:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="txtDescription" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="salaryset" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    
                            </div>
                            
                             <div class="form-group">
                                <label>No of Grades:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="txtGrades" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="salaryset" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtGrades" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    
                            </div>

                           
                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="salaryset"
                                    Width="75px" />
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                    OnClick="BtnDelete_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Delete ?" Enabled="True"
                                    TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_OnClick" Text=" Back" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
