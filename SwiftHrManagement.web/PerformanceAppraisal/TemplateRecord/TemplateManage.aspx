<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="TemplateManage.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.TemplateRecord.TemplateManage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function DeleteNotification(ID) {
            if (confirm("Are you sure to delete this record?")) {
                document.getElementById("<% =hdnRowid.ClientID %>").value = ID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updpnl" runat="server">
    <ContentTemplate>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Appraisal Rating Search
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="lblmsg" runat="server" Text="" CssClass="label" ForeColor="Red"></asp:Label><br />
                        <asp:HiddenField ID="hdnRowid" runat="server" />
                        <asp:TextBox ID="txttotal" runat="server" Visible="false" TabIndex="10"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Template Name:<span class="required" >*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="true" ErrorMessage="Required"  
                                 CssClass="errormsg" ControlToValidate="txtTemplateName" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtTemplateName" runat="server" CssClass="form-control" AutoPostBack="true"
                                ontextchanged="txtTemplateName_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Template Description:<span class="required" >*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Enabled="true" ErrorMessage="Required"  
                                 CssClass="errormsg" ControlToValidate="txtTdescription" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtTdescription" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>                            
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Marking By:</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Enabled="true" ErrorMessage="Required"  
                                 CssClass="errormsg" ControlToValidate="ddlMarkingBy" ValidationGroup="Add"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlMarkingBy" runat="server" CssClass="form-control" TabIndex="2"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Marking Type:</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Enabled="true" ErrorMessage="Required" 
                                 CssClass="errormsg" ControlToValidate="ddlMarkingType" ValidationGroup="Add"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlMarkingType" runat="server" CssClass="form-control" AutoPostBack="true" 
                                 onselectedindexchanged="ddlMarkingType_SelectedIndexChanged" 
                                TabIndex="3">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="y">Yes</asp:ListItem>
                                <asp:ListItem Value="n">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 form-group">
                            <label>Percentage:</label>
                            
                            <asp:TextBox ID="txtPercentage" runat="server" CssClass="form-control" TabIndex="4" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Enabled="true" ErrorMessage="Required"
                                 CssClass="errormsg" ControlToValidate="txtPercentage" ValidationGroup="Add"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2 form-group" align="center">
                            <br />
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" 
                                ValidationGroup="Add" onclick="btnAdd_Click" TabIndex="5" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <div id="rptTemplate" runat="server" style="margin-top:15px;"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" ValidationGroup="Save"
                                Text="Save" onclick="BtnSave_Click" TabIndex="8" />
                            <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:confirmbuttonextender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                Text="Back" onclick="BtnBack_Click" TabIndex="9" />
                            <asp:Button ID="BtnDelete" runat="server" style="display:none" onclick="BtnDelete_Click"/>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
