<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListPendingCEA.aspx.cs" Inherits="SwiftHrManagement.web.CEA.ListPendingCEA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function submit_form() {
            var btn = document.getElementById("<%=btnHidden.ClientID %>");
            if (btn != null)
                btn.click();
        }
        function ApproveReject(id, type) {
            var amount = document.getElementById("txtarea_" + id).value;
            window.location.href = "ApproveCEA.aspx?ID=" + id + "&Flag=" + type + "&amt=" + amount;
        }
        function newTableToggle(idTD, idImg) {
            var td = document.getElementById(idTD);
            var img = document.getElementById(idImg);
            if (td != null && img != null) {
                var isHidden = td.style.display == "none" ? true : false;
                img.src = isHidden ? "/images/icon_hide.png" : "/images/icon_show.png";
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
           CEA Assignment
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
