<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="salaryDetailIndivisual.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.salaryDetailIndivisual" Title="Swift HRM" %>

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
            <i class="fa fa-caret-right"></i>
            Salary Details
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <asp:HiddenField ID="year" runat="server" />
                            <asp:HiddenField ID="month" runat="server" />                                 
                                  <div id="rpt" runat="server"></div>   
                          <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
