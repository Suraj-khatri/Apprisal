<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="ManageOperation.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.GlobalSaleryCRUDOperation.ManageOperation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <%--  <link href="../../Css/style.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
            </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

    <script type="text/javascript">

        function SearchEmp() {
            var branchId = document.getElementById("<%=ddlBranch.ClientID%>").value;
            var PositionId = document.getElementById("<%=ddlPostition.ClientID%>").value;
            if (branchId == "" || PositionId == "") {
                alert("Input Branch or Position");
                return;
            }

            var HeadId = document.getElementById("<%=DdlHead.ClientID%>").value;
             if (HeadId != "") {
                 var RangeFrom = document.getElementById("<%=txtFromSalary.ClientID%>").value;
                 var RangeTo = document.getElementById("<%=txtSalaryTo.ClientID%>").value;
             }
             var empId = document.getElementById("<%=ddlEmployee.ClientID%>").value;

            var URL = "/Payrole_management/GlobalSaleryCRUDOperation/ListOperation.aspx?BranchId=" + branchId + "&PositionId=" + PositionId
            + "&EmpId=" + empId + "&headId=" + HeadId + "&rangeFrom=" + RangeFrom + "&rangeTo=" + RangeTo;
            GB_show("", URL, 390, 850);
        }

        function OnUpdate(RowID) {
            if (confirm("Are you sure to Update this message?")) {
                document.getElementById("<% =hdnHeadId.ClientID %>").value = RowID;
                 document.getElementById("<% =BtnUpdate.ClientID %>").click();
             }
         }
         function OnValidation() {
             alert("Please Insert Branch/Position!");

         }
         function OnValidation1() {
             alert("Please Insert JobType/Flat Or Percentage and value!");

         }

         function ManageMethod(object, id) {
             try {
                 var method = document.getElementById("FlatOrPercentage_" + id);

                 if (method) {
                     if (object.value == "a") {
                         method.options[1].selected = true;
                     }
                     else {
                         method.options[0].selected = true;
                     }
                     ShowHideItem(object, id);
                 }
             }
             catch (ex) { }
         }

         function ShowHideItem(me, id) {
             var method = document.getElementById("FlatOrPercentage_" + id);

             for (var i = 0; i < method.options.length; i++) {
                 if (me.value == "a") {
                     if (i != 1) {
                         method.options[i].style.display = "none";
                     }
                 }
                 else {
                     method.options[i].style.display = "";
                 }
             }
         }
 </script>
    <style type="text/css">
        .clickimage {
            cursor: pointer;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:UpdatePanel ID="UPDATE1" runat="server">
        <ContentTemplate>
        <div class="row">
            <div class="col-lg-8 col-md-offset-2">
                 <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i> 
                           Salary Operation
                        </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span>&nbsp;               
                <span class="errormsg">(* Required Fields)</span><br />
                        <br />
                        <div id="DivMsg" runat="server"></div>
                        <asp:HiddenField ID="hdnHeadId" runat="server" />
                        <asp:HiddenField ID="hdnJobType" runat="server" />
                        <asp:HiddenField ID="hdnFlatPercentage" runat="server" />
                        <asp:HiddenField ID="HdnValue" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>Branch: <span class="errormsg">*</span></label>
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        

                        <asp:Label ID="lblbranch" runat="server" class="errormsg"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Position:<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="ddlPostition" runat="server" CssClass="form-control"
                            OnSelectedIndexChanged="ddlPostition_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                            <asp:Label ID="lblPosition" runat="server" class="errormsg"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Head:</label>
                        <asp:DropDownList ID="DdlHead" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="DdlHead_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="showSalaryRange" runat="server" visible="false">
                        <div class="form-group">
                            <label>Range From:</label>
                            <asp:TextBox ID="txtFromSalary" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Range To:</label>
                            <asp:TextBox ID="txtSalaryTo" runat="server" CssClass="form-control"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Employee:</label>
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <input type="button" value="Search" onclick="SearchEmp()" class="btn btn-primary" />
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update"
                            OnClick="BtnUpdate_Click" Style="display: none;" />
                    </div>
                    <div id="rpt" runat="server"></div>
                </div>
                </section>
            </div>
        </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
        

