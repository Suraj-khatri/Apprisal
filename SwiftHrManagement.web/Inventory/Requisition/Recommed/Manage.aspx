<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.Requisition.Recommed.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script type="text/javascript" language="javascript">
        function submit_form() {
            var btn = document.getElementById("<%=btnHidden.ClientID %>");
            if (btn != null)
                btn.click();
        }

        function nav(page) {
            var hdd = document.getElementById("hdd_curr_page");
            if (hdd != null)
                hdd.value = page;

            submit_form();
        }

        function newTableToggle(idTD, idImg) {
            var td = document.getElementById(idTD);
            var img = document.getElementById(idImg);
            if (td != null && img != null) {
                var isHidden = td.style.display == "none" ? true : false;
                img.src = isHidden ? "/images/icon_hide.gif" : "/images/icon_show.gif";
                img.alt = isHidden ? "Hide" : "Show";
                td.style.display = isHidden ? "" : "none";
            }
        }
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;
            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = boolChecked;
            }
        }
    </script>

    <asp:UpdatePanel ID="UPDPANEL" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel"> 
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                           Recommend Requisition
                            <asp:HiddenField ID="hdnapid" runat="server" />
                        </header>
                        <div class="form-group">
                            <div class="panel-body">
                                <div id="rpt" runat="server"></div>
                                <div class="col-md-12">
                                    <label>Requisition Information</label>
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <label>Requested Message :</label>
                                    <asp:TextBox ID="txtReqMsg" runat="server" CssClass="form-control"  TextMode="MultiLine" Enabled="false"></asp:TextBox> 
                                </div>
                                <asp:Panel ID="unschPnl" runat="server" Visible="false">
                                    <div class="col-md-12">
                                        <label>Unscheduled Reason :</label>
                                        <asp:TextBox ID="txtUnschReason" runat="server" CssClass="form-control"  TextMode="MultiLine" Enabled="false"></asp:TextBox> 
                                    </div>
                                 </asp:Panel>    
                                <div class="col-md-12">
                                    <label>Recommend Message :</label>
                                    <asp:TextBox ID="txtRecommedMsg" runat="server" CssClass="form-control"  TextMode="MultiLine"></asp:TextBox>  
                                </div>
                                <div>&nbsp;</div>
                                <div class="col-md-12">
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" Text="Recommend" 
                                            ValidationGroup="approve" />
                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Recommend?" 
                                        Enabled="True" TargetControlID="BtnSave">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnReject" runat="server" CssClass="btn btn-primary" Text="Reject" ValidationGroup="recommed" 
                                        onclick="BtnReject_Click" />
                                    <cc1:ConfirmButtonExtender ID="BtnReject_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Reject?" 
                                        Enabled="True" TargetControlID="BtnReject">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" ValidationGroup="recommed" />
                                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
