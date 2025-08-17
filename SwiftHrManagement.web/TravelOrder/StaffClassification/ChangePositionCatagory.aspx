<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ChangePositionCatagory.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.StaffClassification.ChangePositionCatagory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                        Change Category Of Position
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                    
                    <div class="form-group">
                        <label>Category For:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Required!" ControlToValidate="DdlCatagoryFor" AutoComplete="Off"
                            Display="Dynamic" ValidationGroup="category" BorderColor="#FFFF66"
                            SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DdlCatagoryFor" runat="server" CssClass="form-control" Width="100%"> 
                        </asp:DropDownList>
                            
                    </div>
                            
                    <div class="form-group">
                        <label>Category Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Required!" ControlToValidate="DdlCatagory" AutoComplete="Off"
                            Display="Dynamic" ValidationGroup="category" BorderColor="#FFFF66"
                            SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                             <asp:DropDownList ID="DdlCatagory" runat="server" CssClass="form-control" Width="100%"> 
                        </asp:DropDownList>
                            
                    </div>
                            
                        <div class="form-group">
                        <label>Position Name:</label>
                             <asp:DropDownList ID="DdlPosition" runat="server" CssClass="form-control" Width="100%" Enabled="false"> 
                        </asp:DropDownList>
                            
                    </div>
                         
                        <div class="form-group">
                        <label>Is Active:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Required!" ControlToValidate="DdlisActive" AutoComplete="Off"
                            Display="Dynamic" ValidationGroup="category" BorderColor="#FFFF66"
                            SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                             <asp:DropDownList ID="DdlisActive" runat="server" CssClass="form-control" Width="100%" >
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem> 
                            </asp:DropDownList>
                            
                            
                    </div>
                     <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="category" />

                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                        </div>
                </div>
            </section>
        </div>
    </div>

</asp:Content>
