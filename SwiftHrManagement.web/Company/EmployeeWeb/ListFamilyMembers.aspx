<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ListFamilyMembers.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListFamilyMembers" %>
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
            <i class="fa fa-caret-right"></i>   List Family Member  
                <span class="subheading"><asp:Label ID="LblEmpName" runat="server"></asp:Label>
                <asp:HiddenField ID="hdnempid" runat="server" /></span>
        </header>
        <div class="panel-body">
            <div id="rpt" runat="server"></div>
                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
        </div>
    </div>
   

</asp:Content>
