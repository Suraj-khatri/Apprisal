<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageStaticData.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.StaticSetUp.ManageStaticData" %>

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
    function DeleteNotification(RowID) {
      
        if (confirm("Are you sure to delete this message?")) {
            document.getElementById("<%=hdnDeleteId.ClientID%>").value = RowID;
            document.getElementById("<%=BtnDelete.ClientID %>").click();
            
     
        }

    }
    </script> 
  
    <style type="text/css">
        .style10
        {
            font-weight: bold;
            color: #333333;
            height: 35px;
        }
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Add New Static Data
                </header>
                <div class="panel-body">
                    <div class="form-group">  
                        <span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields!) </span><br />     
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Category:</label>
                        <asp:TextBox ID="TxtDataType" runat="server" CssClass="form-control" 
                            Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="TxtTypeId" runat="server" Enabled="False" CssClass="form-group"  Visible="False"></asp:TextBox>
                    </div>
                    <div class="form-group">
                       <label>Title:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDetailTitle" Display="None" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="Data" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtDetailTitle" runat="server" CssClass="form-control" MaxLength="100"  TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Description: <span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDetailDesc" Display="None" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="Data" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtDetailDesc" runat="server" CssClass="form-control" MaxLength="100" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" Text="Save" ValidationGroup="Data"/>
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" Text="delete" style="display:none;" onclick="BtnDelete_Click1" />
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Visible = "false" onclick="BtnBack_Click" Text="Back" />
                    </div>
                    <div class="form-group">
                        <asp:HiddenField ID="hdnDeleteId" runat="server" />
                    </div>
                    <div class="form-group">
                        <div id="rpt" runat="server">
                        </div>
                        <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
