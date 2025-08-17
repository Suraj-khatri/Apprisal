<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ListInsurancePremium.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListInsurancePremium" %>
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
     <asp:HiddenField ID="hdnempid" runat="server" />    
    <asp:HiddenField ID="hdninsuranceid" runat="server" />
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            <a href="ListInsurance.aspx?Id=<%=GetEmpId().ToString()%>&Insurance_Id=<%=GetInsuranceId().ToString()%> ">List Insurance  </a> &raquo;List Insurance Premium 
						 
            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server">	                              
                            </div>   
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
<%--<table width="100%">
            <!-- BREAD CRUMBS START !-->
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						
						<img src="/images/big_bullit.gif"> 
						<a href="ListInsurance.aspx?Id=<%=GetEmpId().ToString()%>&Insurance_Id=<%=GetInsuranceId().ToString()%> ">List Insurance  </a> &raquo;List Insurance Premium 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>

                        
                        <tr>
                            <td align="center">   <asp:HiddenField ID="hdnempid" runat="server" />    <asp:HiddenField ID="hdninsuranceid" runat="server" />
                                 <div>
                                    <div id="rpt" runat="server"></div>
                                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>--%>
</asp:Content>
