<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LFAHistoryReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LFAHistoryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="../../ajax_func.js" type="text/javascript"></script>
<link href="../../calendar/calendar.css" rel="stylesheet" type="text/css" />
<script src="../../calendar/calendar_us.js" type="text/javascript"></script>
<script src="../../Jsfunc.js" type="text/javascript"></script>

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

    function post(obj1, obj2, obj3, obj4) {
        //var a = document.getElementById(obj3).value;
        //alert(obj3);
        var tax=document.getElementById(obj1).value;
        var date = document.getElementById(obj2).value;
        if (tax != "") {
            if (!checknumber(document.getElementById(obj1))) {
                alert("please, enter valid number");
                document.getElementById(obj1).focus();
                return;
            }
        }
            
        if (date == "") {
            alert("You must enter date...");
            document.getElementById(obj2).focus();
            return ;

        }
        if (!isDate(date)) {
            //alert("please, enter valid date");
            document.getElementById(obj2).focus();
            return;
        }

        //alert(obj4);
        window.location.href = "LFAHistoryPost.aspx?" + obj4 + "&ID=" + obj3 + "&tax=" + tax + "&date=" + date;
    }
    
    

    
    </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading"> 
            <i class="fa fa-caret-right"></i>
            Leave Request Details For Approval
         </header>

        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                    </section>
                </div>
            </div>
           <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
        </div>
    </div>
</asp:Content>
