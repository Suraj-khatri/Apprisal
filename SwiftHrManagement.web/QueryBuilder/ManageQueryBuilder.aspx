<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="ManageQueryBuilder.aspx.cs" Inherits="SwiftHrManagement.web.QueryBuilder.ManageQueryBuilder" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/listBoxMovement.js" type="text/javascript"></script>


    <script type ="text/javascript" >
        function moveAcross(obj) {            
            var e = document.getElementById(obj).value;
            document.getElementById('<% = txtField.ClientID %>').value = e;
        }
//        function MoveItem(firstList, secondList) {
//            listbox_moveacross(firstList, secondList);
//            //ReadList();
//        }

//        function ReadList() {
//            var DdlSecondList = document.getElementById("<% =DdlSecondList.ClientID %>");           
//            var fielList = "";    
//            for (var i = 0; i < DdlSecondList.options.length; i++) {
//                var item = DdlSecondList.options[i].value;
//                fielList += fielList == "" ? item : ", " + item;
//            }

//            fielList = fielList == "" ? "*" : fielList;           
//            var txtWriteSql = document.getElementById("<% =txtWriteSql.ClientID %>").value = "SELECT " + fielList + " FROM " + document.getElementById("<% =Ddltablelist.ClientID %>").value;
//        }
        
        
    
    </script>

    <style type="text/css">
        .style10
        {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-lg-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Query Builder
                    </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Label ID="lblSql" runat="server" Text=""></asp:Label>
                                    <input type="hidden" id="hdnValue" name="hdnValue">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Write Sql:</label>
                                    <asp:TextBox ID="txtWriteSql" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Report Name List:</label>
                                    <asp:DropDownList ID="DdlReportName" runat="server" CssClass="form-control" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group" style="margin-top:25px;">
                                    <asp:Button ID="txtShowSql" runat="server" CssClass="btn btn-primary" Text="Show SQL" 
                                        onclick="txtShowSql_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:DropDownList ID="Ddltablelist" runat="server" CssClass="form-control" AutoPostBack="true" 
                                        onselectedindexchanged="Ddltablelist_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group" style="margin-top:-6px">
                                    <label><asp:Label ID="LblSecondList" runat="server" Text=""></asp:Label></label>
                                    <asp:DropDownList ID="ddlsecondTableList" runat="server" CssClass="form-control">
                                      </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5" >
                                <div class="form-group" align="center">
                                    <asp:DropDownList ID="DdlFirstList" runat="server" CssClass="form-control" multiple="multiple" size="10">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div align="center" class="btn btn-primary" onClick=" return  listbox_moveacross('<%=DdlFirstList.ClientID %>', '<%=DdlSecondList.ClientID %>');">&gt;&gt;</div><br><br>
	                                <div align="center"  class="btn btn-primary" onClick="return listbox_moveacross('<%=DdlSecondList.ClientID %>', '<%=DdlFirstList.ClientID %>');">&lt;&lt;</div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <asp:DropDownList ID="DdlSecondList" runat="server" CssClass="form-control" size="10" multiple="multiple">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <input type ="button" class ="btn btn-primary" onclick ="return moveAcross('<%=DdlFirstList.ClientID  %>    ')" value = "Add" />
	                                <input type ="button" class ="btn btn-primary" onclick ="listbox_selectall('<%=DdlFirstList.ClientID %>    ', true)" value = "Select All" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <input type = "button" class="btn btn-primary" onclick ="listbox_selectall('<%=DdlSecondList.ClientID %>    ', true)" value = "Select All" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                &nbsp;
                            </div>
                        </div>
                       
                                    <label>Query Condtion</label>
                               
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Field:<span class="errormsg">*</span></label>
                                     <asp:TextBox ID="txtField" runat="server" CssClass = "form-control"></asp:TextBox>
                                     <asp:Label ID="lblField" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Operator:<span class="errormsg">*</span></label>
                                    <asp:DropDownList ID="Ddloperator" runat="server" CssClass = "form-control">
                                    <asp:ListItem Value = ""> select </asp:ListItem>
                                    <asp:ListItem Value = "="> = </asp:ListItem>
                                    <asp:ListItem Value = "<"> < </asp:ListItem>
                                    <asp:ListItem Value = ">"> > </asp:ListItem>
                                    <asp:ListItem Value = "like"> like </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lbloperator" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Condtion:<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="txtCondition" runat="server" CssClass = "form-control"></asp:TextBox>
                                    <asp:Label ID="lblcondition" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Report Name:</label>
                                    <asp:TextBox ID="txtReportName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="BtnGenerateQuery" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnGenerateQuery_Click" Text="GenerateQuery" />
                                    <asp:Button ID="BtnGenerateReport" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnGenerateReport_Click" Text="Generate Report" />
                                    <asp:Button ID="BtnExportToExcel" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnExportToExcel_Click" Text="Export To Excel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
