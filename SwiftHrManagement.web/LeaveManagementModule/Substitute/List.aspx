<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Substitute.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="JavaScript" src="../../calendar/calendar_us.js"></script>
<link rel="stylesheet" href="../../calendar/calendar.css">
    <script src="../../../ui/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="JavaScript" src="../../../calendar/calendar_us.js"></script>
    <link href="../../../ui/css/jquery-ui.css" rel="stylesheet" />
    <script src="../../../ui/js/jquery-ui-1.10.3.min.js"></script>  
<script language="javascript">
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
    <script>
     $(function () {
         $("#datepicker").datepicker();
     });
        </script>
     <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Assign Substitute Leave
       </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                             <div id="rpt" runat="server"></div>
                        </div>
                    </section>
                </div>
            </div>
              <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
        </div>
    </div>         
</asp:Content>
