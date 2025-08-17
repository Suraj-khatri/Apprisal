<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageOther.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix.ManageOther" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script type="text/javascript">
        function DeleteNotification(RowID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =hdnDeleteId.ClientID %>").value = RowID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }
  </script>
<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i>  
                Other Section Setup
            </header>
            <div class="panel-body">
                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                    <div  id = "DivMsg" runat="server"></div>
                    <asp:HiddenField ID="hdnDeleteId" runat="server" />
                </div>
                <asp:Panel ID="ProductListPanel" runat="server" CssClass="legend">
                    <div class="form-group">
                        <label>Template:</label>
                        <strong><asp:Label ID="lblTemplate" runat="server"></asp:Label></strong> 
                    </div>
                    <div class="form-group">
                        <label>Section:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="ddlSection" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Answer Type:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlAnsType" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlAnsType" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Select </asp:ListItem>
                            <asp:ListItem Value="Yes/No"> Yes/No</asp:ListItem>
                            <asp:ListItem Value="Numeric"> Numeric</asp:ListItem>
                            <asp:ListItem Value="Subjective"> Subjective</asp:ListItem>
                            <asp:ListItem Value="System">System </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Question:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtQuestion" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control"
                             TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Panel ID="PnDelete" runat="server">
                            <div align="left">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" onclick="BtnSave_Click" ValidationGroup ="save" />
                                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnDelete" runat="server" Text="" onclick="BtnDelete_Click"  style="display:none;"/>
                    </div>
                </asp:Panel>
                <div class="form-group">
                    &nbsp;
                </div>
                <div class="form-group">
                    <div id="rpt" runat="server">
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
</asp:Content>
