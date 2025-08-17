<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.FiscalMonthSetup.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<div class="row">
    <div class="col-md-4 col-md-offset-3">
        <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Fiscal Month Setting
            </header>
            <div class="panel-body">

                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                             <label>Nepali Year:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage="Required!" ControlToValidate="TxtNepYear" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="TxtNepYear" runat="server" CssClass="form-control" MaxLength="15" ></asp:TextBox>
                                
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Baisakh 1st(Eng. Date):<span class="errormsg">*</span></label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="Required!" ControlToValidate="TxtEngDate" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="TxtEngDate" runat="server" CssClass="form-control" MaxLength="15" ></asp:TextBox>
                            
                            <cc1:CalendarExtender ID="TxtEngDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtEngDate">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                </div>
              
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <b><asp:Label ID="Label13" runat="server" Text="Month Name"></asp:Label></b>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <b><asp:Label ID="Label14" runat="server" Text="Number of Days"></asp:Label></b>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Baisakh:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth1" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth1" runat="server" CssClass="form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RV1" runat="server" 
                                    ControlToValidate="txtMonth1" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="VN1" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth1">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Jestha:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth2" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth2" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                    ControlToValidate="txtMonth2" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth2">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ashad:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth3" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth3" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                    ControlToValidate="txtMonth3" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth3">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Shrawan:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth4" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth4" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                    ControlToValidate="txtMonth4" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth4">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Bhadra:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth5" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth5" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator4" runat="server" 
                                    ControlToValidate="txtMonth5" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth5">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ashwin:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth6" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth6" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator5" runat="server" 
                                    ControlToValidate="txtMonth6" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth6">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Kartik:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth7" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth7" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator6" runat="server" 
                                    ControlToValidate="txtMonth7" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth7">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Mangsir:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth8" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth8" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator7" runat="server" 
                                    ControlToValidate="txtMonth8" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth8">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Poush:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth9" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth9" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator8" runat="server" 
                                    ControlToValidate="txtMonth9" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth9">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Magh:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth10" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth10" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator9" runat="server" 
                                    ControlToValidate="txtMonth10" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth10">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Falgun:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth11" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth11" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator10" runat="server" 
                                    ControlToValidate="txtMonth11" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth11">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Chaitra:<span class="errormsg">*</span></label>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                ErrorMessage="Required!" ControlToValidate="txtMonth12" AutoComplete="Off"
                                Display="Dynamic" ValidationGroup="fismonth" BorderColor="#FFFF66"
                                SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtMonth12" runat="server" CssClass=" form-control" MaxLength="15" ></asp:TextBox>
                            
                            <asp:RangeValidator ID="RangeValidator11" runat="server" 
                                    ControlToValidate="txtMonth12" ErrorMessage="29-32" 
                                    MaximumValue="32" MinimumValue="29" ValidationGroup="fismonth" Type="Integer"></asp:RangeValidator>                 
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtMonth12">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                     </div>
                </div>
                
                <div class="form-group">
                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                        OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="fismonth"
                        Width="75px" />
                </div>
            </div>
        </section>
    </div>
</div>

    <asp:UpdatePanel ID="updPanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" RenderMode="Inline">
        <ContentTemplate>
            <asp:Button ID="btnUpdate" runat="server" style="display:none" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="click" />
        </Triggers>        
    </asp:UpdatePanel>
    
</asp:Content>
