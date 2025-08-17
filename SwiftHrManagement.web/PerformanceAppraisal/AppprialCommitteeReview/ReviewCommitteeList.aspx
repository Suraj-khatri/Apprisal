<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ReviewCommitteeList.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppprialCommitteeReview.ReviewCommitteeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    function getEdit(_obj) {
        if (confirm('Are you sure to delete? \n If you delete any type, member under this type will automatically delete!!!') = true) {
            document.getElementById("ctl00_MainPlaceHolder_HiddenField1").value = _obj;
            document.getElementById("ctl00_MainPlaceHolder_btnDelete").click();
            return true;
        }
        return false;
    }


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
            User Details
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server">	                                
                            </div>   
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:Button ID="btnDelete" runat="server" Text="Button" style="display:none" onclick="btnDelete_Click"/>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
