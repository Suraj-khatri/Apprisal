<%--<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeAllInfo.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.EmployeeAllInfo" Title="Swift HR" %>--%>
<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="PayrollAllInfo.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.PayrollAllInfo" Title="Swift HR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="System.Data"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<% int empId = 0;
   empId = GetEmployeeId();
%>
    <cc1:TabContainer ID="TabContainer1" runat="server" 
        CssClass="visoft__tab_xpie7" ActiveTabIndex="0">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Insurance">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListInsurance.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
    
    
        <cc1:TabPanel ID="TabPanel8" runat="server" HeaderText="Advance">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel8" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListAdvance.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
        
          <cc1:TabPanel ID="TabPanel9" runat="server" HeaderText="Contribution">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel9" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/chooseContributionType.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
        
          <cc1:TabPanel ID="TabPanel10" runat="server" HeaderText="Payble">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel10" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListPayable.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        


</cc1:TabPanel>
<%--
  <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Grade">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel3" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/Grade/ListGrade.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        


</cc1:TabPanel>--%>
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Interest Benefit">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel2" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListBenefitsOnlyForTaxSettings.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>        
        
                <cc1:TabPanel ID="TabPanel12" runat="server" HeaderText="Adhoc">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel12" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListAdhocPayment.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
        
        
                <cc1:TabPanel ID="TabPanel13" runat="server" HeaderText="Bank A/C">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel13" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListBankAccounts.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
 <cc1:TabPanel ID="TabPaneldonation" runat="server" HeaderText="Donation">
    <ContentTemplate>
    <asp:UpdatePanel ID="updatePandonation" runat="server">
        <ContentTemplate>
            <iframe src="/Company/EmployeeWeb/ListDonations.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
        </ContentTemplate>
    </asp:UpdatePanel>
    </ContentTemplate>        
</cc1:TabPanel>          
        
<cc1:TabPanel ID="TabPanel14" runat="server" HeaderText="Loan">
    <ContentTemplate>
        <asp:UpdatePanel ID="updatePanel14" runat="server">
            <ContentTemplate>
            <iframe src="/Company/EmployeeWeb/ListLoan.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
            </ContentTemplate>
        </asp:UpdatePanel>
            
            
    </ContentTemplate>
        
</cc1:TabPanel>
        

<cc1:TabPanel ID="TabMedicalBill" runat="server" HeaderText="Medical">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel5" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListMedicalBill.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>
        
        
                <cc1:TabPanel ID="TabPanel16" runat="server" HeaderText="Other">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel16" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListOtherInfo.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>

<cc1:TabPanel ID="TabFuturePayable" runat="server" HeaderText="Future Payable">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel7" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListFuturePayable.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>    
        
     
        
        

        
<cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Future Tax Contr.">
            <ContentTemplate>
             <asp:UpdatePanel ID="updatePanel4" runat="server">
                        <ContentTemplate>
                 <iframe src="/Company/EmployeeWeb/ListFutureContribution.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
            
                </ContentTemplate>
                    </asp:UpdatePanel>
            
            
            </ContentTemplate>
        
</cc1:TabPanel>    
        
     
        
        
</cc1:TabContainer>
 
 
</asp:Content>

