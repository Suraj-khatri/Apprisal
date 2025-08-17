<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="AdvanceSummery.aspx.cs" Inherits="SwiftHrManagement.web.Report.Loan_and_Advance_Report.AdvanceSummery" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
        
                                <asp:Panel ID="Advance_Summery" runat="server" Visible="false">  
                       
                                    <strong><span class="style10"> Advance Summery Report  </span></strong>  <br />    
                                    <span class="style10">&nbsp;Advance Type:
                                    <strong><asp:Label ID="LblAdvanceType" runat="server"></asp:Label></strong><br />
                                    &nbsp;Branch Name : 
                                    <strong> <asp:Label ID="lblbranchName" runat="server"></asp:Label></strong>
                                    </span><br />
                                    <span class="style10">&nbsp;Departmant Name : 
                                    <strong><asp:Label ID="lbldeptName" runat="server"></asp:Label></strong>
                                    </span><br />
                                    <span class="style10"> Employee Name : 
                                    <strong><asp:Label ID="lblEmpName"  runat="server"></asp:Label></strong>
                                    </span> <br />
                                    <strong><asp:Label ID="Lbldatetype" runat="server"></asp:Label></strong> 
                
                                    From Date: <strong><asp:Label ID="From_Date" runat="server"></asp:Label></strong>  To Date: 
                                    <strong> <asp:Label ID="To_Date"  runat="server"></asp:Label></strong>  <br />
                                         
                                </asp:Panel>   

                                <asp:Panel ID="Advance_details" runat="server" Visible="false">

                                    <strong><span class="style10"> Advance Details Report </span></strong> <br />
                                     <span class="style10">&nbsp;Advance Type:
                                        <strong><asp:Label ID="LblAdvanceType1" runat="server"></asp:Label></strong></span><br />
                                    <span class="style10">&nbsp;Branch Name : 
                                    <strong> <asp:Label ID="lblleaveBranchName" runat="server"></asp:Label></strong>
                                    </span><br />
                                    <span class="style10">&nbsp;Departmant Name : 
                                    <strong> <asp:Label ID="lblleaveDeptName" runat="server"></asp:Label></strong>
                                    </span><br />
                                    <span class="style10"> Employee Name :</strong> 
                                    <strong><asp:Label ID="lblleaveEmpname"  runat="server"></asp:Label></strong>
                                    </span> <br />
                                    <strong><asp:Label ID="Label4" runat="server"></asp:Label></strong>  Report Till Date: 
                                    <strong> <asp:Label ID="AsDate"   runat="server"></asp:Label> </strong>  <br />      
                                
                                </asp:Panel>                             
              
                            </div>
                             <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>