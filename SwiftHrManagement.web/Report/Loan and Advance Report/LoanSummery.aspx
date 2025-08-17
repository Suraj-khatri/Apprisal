<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="LoanSummery.aspx.cs" Inherits="SwiftHrManagement.web.Report.Loan_and_Advance_Report.LoanSummery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10 {
            color: #666666;
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
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>

                                    <asp:Panel ID="Loan_summery" runat="server" Visible="false">  
                                        <strong><span class="style10"> Loan Summery Report  </span></strong>  <br />                      
                                        <span class="style10">&nbsp;Loan Type:&nbsp;<strong> <asp:Label ID="LblLoanType" runat="server">
                                        </asp:Label></strong><br />
         
                                        &nbsp;Branch Name : 
                                        <strong><asp:Label ID="lblbranchName" runat="server"></asp:Label></strong>
                                        </span><br />
                
                                        <span class="style10">&nbsp;Departmant Name : &nbsp;
                                        <strong><asp:Label ID="lbldeptName" runat="server"></asp:Label></strong>
                                        </span><br />
                
                                        <span class="style10"> Employee Name :&nbsp; 
                                        <strong><asp:Label ID="lblEmpName"  runat="server"></asp:Label></strong>
                                        </span> <br />
                
                                        <asp:Label ID="Lbldatetype" runat="server"></asp:Label>  From Date: &nbsp; <strong>
                                        <asp:Label ID="From_Date"   runat="server"></asp:Label> </strong>&nbsp;  To Date: <strong> &nbsp;
                                        <asp:Label ID="To_Date"  runat="server"></asp:Label></strong> <br />
                                
                                    </asp:Panel> 
 
                                    <asp:Panel ID="Loan_details" runat="server" Visible="false">
                                        <strong><span class="style10"> Loan Details  Report </span></strong> <br />
                
                                        <span class="style10">&nbsp;Loan Type:&nbsp;<strong> <asp:Label ID="lblloantype1" runat="server">
                                        </asp:Label></strong></span><br />
                                        <span class="style10">&nbsp;Branch Name : 
                                        <strong> <asp:Label ID="lblleaveBranchName" runat="server"></asp:Label></strong>
                                        </span><br />
                        
                                        <span class="style10">&nbsp;Departmant Name : 
                                        <strong> <asp:Label ID="lblleaveDeptName" runat="server"></asp:Label></strong>
                                        </span><br />
                                        <span class="style10"> Employee Name :
                                        <strong><asp:Label ID="lblleaveEmpname"  runat="server"></asp:Label></strong>
                                        </span> <br />
                                        <strong><asp:Label ID="Label4" runat="server">
                                        </asp:Label> Report Till Date: </strong> <asp:Label ID="AsDate"   runat="server">
                                        </asp:Label>  <br />
                          
                                    </asp:Panel>                        
                            </div>
                            <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">

<tr>

                 <td>

                     
    <div align="center">
    <strong><font size="+1">
        <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
        </font></strong>
        <font size="-1"><strong>
        <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
     
     
<asp:Panel ID="Loan_summery" runat="server" Visible="false">  
                     

         <strong><span class="style10"> Loan Summery Report  </span></strong>  <br />                      
         <span class="style10">&nbsp;Loan Type:&nbsp;<strong> <asp:Label ID="LblLoanType" runat="server">
         </asp:Label></strong><br />
         
                &nbsp;Branch Name : 
                <strong><asp:Label ID="lblbranchName" runat="server"></asp:Label></strong>
                </span><br />
                
                <span class="style10">&nbsp;Departmant Name : &nbsp;
                <strong><asp:Label ID="lbldeptName" runat="server"></asp:Label></strong>
                </span><br />
                
                <span class="style10"> Employee Name :&nbsp; 
                <strong><asp:Label ID="lblEmpName"  runat="server"></asp:Label></strong>
                </span> <br />
                
             <asp:Label ID="Lbldatetype" runat="server"></asp:Label>  From Date: &nbsp; <strong>
             <asp:Label ID="From_Date"   runat="server"></asp:Label> </strong>&nbsp;  To Date: <strong> &nbsp;
                <asp:Label ID="To_Date"  runat="server"></asp:Label></strong> <br />
                                
 </asp:Panel> 
 
 <asp:Panel ID="Loan_details" runat="server" Visible="false">
                         
                          
                <strong><span class="style10"> Loan Details  Report </span></strong> <br />
                
                 <span class="style10">&nbsp;Loan Type:&nbsp;<strong> <asp:Label ID="lblloantype1" runat="server">
         </asp:Label></strong></span><br />
                  <span class="style10">&nbsp;Branch Name : 
                       <strong> <asp:Label ID="lblleaveBranchName" runat="server"></asp:Label></strong>
                        </span><br />
                        
                         <span class="style10">&nbsp;Departmant Name : 
                       <strong> <asp:Label ID="lblleaveDeptName" runat="server"></asp:Label></strong>
                        </span><br />
                        <span class="style10"> Employee Name :
                        <strong><asp:Label ID="lblleaveEmpname"  runat="server"></asp:Label></strong>
                        </span> <br />
                        <strong><asp:Label ID="Label4" runat="server">
                        </asp:Label> Report Till Date: </strong> <asp:Label ID="AsDate"   runat="server">
                        </asp:Label>  <br />
                          
        </asp:Panel>                         
   </div>  
 
 
 
 
                                         
                            </div>              
                     
                     
                       
                         <br />
                  </td>
</tr>

<tr>
            <td>

            <div id="rptDiv" runat="server"></div>

            </td>
    </tr>

</table>
    --%>
</asp:Content>
