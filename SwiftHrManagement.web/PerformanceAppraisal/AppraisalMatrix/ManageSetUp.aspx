<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ManageSetUp.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix.ManageSetUp" %>

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
    <div class="col-md-10 col-md-offset-1">
        <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i>  
                Appraisal Performance Matrix Setup
            </header>
            <div class="panel-body">
                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                    <div  id = "DivMsg" runat="server"></div>
                    <asp:HiddenField ID="hdnDeleteId" runat="server" />
                    <asp:HiddenField ID="HdnEditId" runat="server" />
                </div>
                <asp:Panel ID="ProductListPanel" runat="server" CssClass="legend">
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Template:</label>
                             <strong><asp:Label ID="lblTemplate" runat="server"></asp:Label></strong> 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Appraisal Topic:</label>
                            <asp:DropDownList ID="ddlAppraisalTopic" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Weight(%):</label>
                          <asp:Label ID="lblWeight" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Appraisal Sub Topic:<span class="errormsg">*</span>  </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ddlAppraisalSubTopic" Display="Dynamic" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlAppraisalSubTopic" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Weight(%):<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtAppraisalSubTopicWeight" Display="Dynamic" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAppraisalSubTopicWeight" runat="server" CssClass="form-control" Width="40%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Job Element:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="ddlJobElement" Display="Dynamic" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlJobElement" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Weight: <span class="errormsg">*</span> </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtWeightJobElement" Display="Dynamic" ErrorMessage="Required!" 
                                SetFocusOnError="True" ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtWeightJobElement" runat="server" CssClass="form-control" Width="40%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Panel ID="PnDelete" runat="server">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                                        onclick="BtnSave_Click" ValidationGroup ="save" />
                                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>
                <div class="form-group">
                    &nbsp;
                </div>
                <div class="form-group">
                    <div id="rpt" runat="server"></div>
                </div>
            </div>
        </section>
    </div>
    <asp:Button ID="BtnDelete" runat="server" Text=""  style="display:none;" onclick="BtnDelete_Click" />
    <asp:Button ID="BtnEdit" runat="server" Text="" onclick="BtnEdit_Click"  style="display:none;" />
</div>
</asp:Content>