<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Approve.List" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-user"></i>
            &nbsp;Requisition Approve
        </header>
        <asp:HiddenField ID="hdnapid" runat="server" />

        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                           
                            <div class="form-group">
                                <label>Requisition Information</label>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <span class="txtlbl"> Requested Message:</span><br />                                     
                                <asp:TextBox ID="txtReqMsg" runat="server" CssClass="form-control" TextMode="MultiLine"  width="100%"
                                    Enabled="false"></asp:TextBox>
                                <asp:Panel ID="unschPnl" runat="server" Visible="false">
                                <span class="txtlbl"> Unscheduled Reason:</span><br />                                     
                                <asp:TextBox ID="txtUnschReason" runat="server" CssClass="form-control" TextMode="MultiLine" width="100%"
                                    Enabled="false"></asp:TextBox></asp:Panel>
                                <span class="txtlbl"> Recommended Message:</span><br />                                     
                                <asp:TextBox ID="txtRecmsg" runat="server" CssClass="form-control" TextMode="MultiLine" width="100%"
                                    Enabled="false"></asp:TextBox>  
                                <span class="txtlbl"> Approve Message:<span class="required">*</span></span><br /> 
                                <asp:TextBox ID="TxtAppMessage" runat="server" CssClass="form-control" 
                                    width="100%" TextMode="MultiLine"></asp:TextBox> 
                                <br />
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" 
                                    Text="Approve" ValidationGroup="approve"/>
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                        </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnReject" runat="server" CssClass="btn btn-primary" onclick="BtnReject_Click" Text="Reject" 
                                    ValidationGroup="approve"/>
                                <cc1:ConfirmButtonExtender ID="BtnReject_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Reject?" Enabled="True" TargetControlID="BtnReject">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" 
                                    ValidationGroup="chart"/>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>