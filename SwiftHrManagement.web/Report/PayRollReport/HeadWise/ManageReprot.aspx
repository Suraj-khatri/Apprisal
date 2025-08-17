<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ManageReprot.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.HeadWise.ManageReprot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            color:#666666;           
        }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                </font></strong>
                                <font size="-1"><strong>
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                </strong></font> 
                                <br/>
                                <strong><span > Contribution Summery Report  </span></strong>  <br />                 
                                <span class="style10">&nbsp;Fiscal Year:&nbsp;<strong><asp:Label ID="LblFiscalyear" runat="server"></asp:Label></strong></span><br />
                                <span class="style10">&nbsp;Branch Name : &nbsp;<strong><asp:Label ID="lblBranchName" runat="server"></asp:Label></strong></span><br />
                                <span class="style10">&nbsp;Dept Name : &nbsp;<strong><asp:Label ID="lblDeptName" runat="server"></asp:Label></strong></span><br />
                                <span class="style10">&nbsp;Report  : &nbsp;<strong><asp:Label ID="lblReport" runat="server"></asp:Label></strong></span><br /> 
                            </div>
                             <div id="rptDiv" runat="server" class="table-responsive"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
