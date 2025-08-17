<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageSalarySetDetails.aspx.cs" Inherits="SwiftHrManagement.web.SalarySet.ManageSalarySetDetails" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
    <script src="../Jsfunc.js" type="text/javascript"></script>

    <script type="text/javascript">
        function DeleteNotification(RowID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =hdnDeleteId.ClientID %>").value = RowID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }
    
        
  </script>
 
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnDeleteId" runat="server" />
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:Label ID="abc" runat="server"></asp:Label>
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                             Add Salary Heads
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                <div id="DivMsg" runat="server"></div>
                            </div>

                            <div class="form-group">
                                <label>Salary Title:<span class="errormsg">*</span></label>
                                 <asp:TextBox ID="txtSalaryTitle" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                            </div>
                            
                            <div class="form-group">
                                <label>Payable Head:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="ddlPayableHead" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="salarysetDetails" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddlPayableHead" runat="server" CssClass="form-control" Width="100%"> 
                                </asp:DropDownList>
                                    
                            </div>
                             <div class="form-group">
                                <label> Payable Value:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="txtPayableValue" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="salarysetDetails" BorderColor="#FFFF66"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtPayableValue" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                  
                            </div>
                             <div class="form-group">
                                <label> Value For:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="ddlValuefor" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="salarysetDetails" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddlValuefor" runat="server" CssClass="form-control" Width="100%">
                                    <asp:ListItem Value="A">Assignment</asp:ListItem>
                                    <asp:ListItem Value="L">Limit Check</asp:ListItem> 
                                </asp:DropDownList>
                                    
                            </div>

                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="salarysetDetails"
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
                    </section>
                     </div>
                </div>
            <div class="row">
                <div  class="col-md-10 col-md-offset-1">
                    <section class="panel">
                         <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                             
                        </div>
                    </section>
                </div>
               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>