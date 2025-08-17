<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.Branch.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
   <div class="col-md-10 col-md-offset-1">
            <section class="panel">
               <header class="panel-heading">
                   <i class="fa fa-caret-right"></i>
                Branch Add Details
                </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span>Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        </div>
                    <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Branch Name:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtBranchName" runat="server" CssClass="form-control" ValidationGroup="Branch"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Required!" ControlToValidate="TxtBranchName" 
                                    Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator>       
                            </div>
                      <%--      <div class="col-md-4 form-group">
                                <label>Branch Group:<span class="errormsg">*</span></label>
                                <asp:DropDownList ID="DdlBranchGroup" runat="server" CssClass="form-control" ValidationGroup="Branch"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Required!" ControlToValidate="DdlBranchGroup" 
                                    Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator> 
                            </div>--%>
                            <div class="col-md-4 form-group">
                                <label>Branch Code:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtShortName" runat="server" CssClass="form-control" 
                                    ValidationGroup="Branch"></asp:TextBox>
                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="TxtShortName" ErrorMessage="Required!" Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Address:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtBranchAddress" runat="server" CssClass="form-control" 
                                  ValidationGroup="Branch"></asp:TextBox>
                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TxtBranchAddress" 
                                    ErrorMessage="Required!" Display="Dynamic" ValidationGroup="Branch" 
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Phone:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtBranchPhone" runat="server" 
                                    CssClass="form-control" ValidationGroup="Branch"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ErrorMessage="Required!" ControlToValidate="TxtBranchPhone" 
                                        Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator>                      
                                <cc1:FilteredTextBoxExtender ID="TxtBranchPhone_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" 
                                    TargetControlID="TxtBranchPhone">
                                </cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Fax<span class="errormsg"> *</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Txtfax" 
                                    Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" 
                                    ValidationGroup="Branch"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="Txtfax" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="Txtfax_FilteredTextBoxExtender" runat="server" 
                                    Enabled="True" FilterType="Numbers" TargetControlID="Txtfax">
                                </cc1:FilteredTextBoxExtender>
                           
                        </div>
                    </div>
                    <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Email:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="Branch"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                                    ErrorMessage="Invalid Email!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="Branch" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtEmail" runat="server"
                                   CssClass="form-control" ValidationGroup="Branch"></asp:TextBox>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Country:<span class="errormsg">*</span></label>
                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="form-control" Enabled="False" ></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="ddlcountry"
                                    Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                
                        </div>
                            <div class="col-md-4 form-group">
                                <label>Zone:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required!" ControlToValidate="ddlzone"
                                    Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddlzone" runat="server" CssClass="form-control" 
                                    OnSelectedIndexChanged="ddlzone_SelectedIndexChanged" ValidationGroup="Branch">
                                </asp:DropDownList>
                            </div>
                       </div>
                    <div class="row">
                            <div class="col-md-4 form-group">
                                <label>District <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Required!" ControlToValidate="ddldistrict"
                                    Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddldistrict" runat="server"
                                    CssClass="form-control" ValidationGroup="Branch">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Branch Contact Person: <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Required!" ControlToValidate="TxtContactPerson"
                                    Display="Dynamic" ValidationGroup="Branch" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtContactPerson" runat="server" CssClass="form-control"
                                    ValidationGroup="Branch"></asp:TextBox>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Contact Person Mobile:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True"
                                    ValidationGroup="Branch"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" ValidationGroup="Branch"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtMobile_FilteredTextBoxExtender"
                                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMobile">
                                </cc1:FilteredTextBoxExtender>
                            </div>
                    </div>
                   <%-- <div class="form-group">
                        <strong>Inventory Branch Setup</strong>
                    </div>
                    <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Stock A/C:</label>
                                <asp:TextBox ID="stockAc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Expenses A/C:</label>
                                <asp:TextBox ID="expensesAc" runat="server" CssClass="form-control"></asp:TextBox>
                            
                        </div>
                            <div class="col-md-4 form-group">
                                <label>Stock In Transit A/C:</label>
                                <asp:TextBox ID="transitAc" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                       </div>
                    <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Is Direct Expense</label>
                                <asp:DropDownList ID="isDirectExp" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                </asp:DropDownList></td>
                          
                        </div>
                    </div>
                        <br/>--%>
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                        OnClick="BtnSave_Click" Text="Save" ValidationGroup="Branch"/>
                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                        Text="Back" OnClick="BtnBack_Click" />
                                
                            </div>
                    
                </section>
       </div>
</asp:Content>
