<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Receive.List" %>

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
                        <div class="col-md-10 col-md-offset-1">
                            <div class="panel">
                                        <div class="panel-heading" align="left">
                                            <label>Product Acknowledge</label>
                                            <asp:Label ID="LblBranchDept" runat="server" CssClass="subheading"></asp:Label>
                                            <asp:HiddenField ID="hdnapid" runat="server" />
                                        </div>
                                        <div class="panel-body">
                                            <div id="rpt" runat="server"></div>
                                        </div>
                                        <div class="panel-body">
                                            <div class="panel-heading">
                                                    Requisition Information
                                            </div>
                                            <div class="row">
                                            <div class="col-md-12">
                                                 <span class="txtlbl">Please enter valid data</span><span class="required">(* Required fields)</span>
                                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                            </div>
                                           
                                            <div class="form-group col-md-12">
                                              <asp:TextBox ID="txtReceivedMsg" runat="server" CssClass="form-control" 
                                                        TextMode="MultiLine" Width="100%"></asp:TextBox>
                                            </div>
                                                </div>
                                                 <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                                                   Text="Acknowledge" ValidationGroup="approve" onclick="BtnSave_Click" />
                                                 <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                                       ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                                 </cc1:ConfirmButtonExtender>
                                                   <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" 
                                                       Text="Back" ValidationGroup="chart" onclick="BtnCancel_Click" />
                                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                                      </div>
                            </div>
                        </div>                
</asp:Content>