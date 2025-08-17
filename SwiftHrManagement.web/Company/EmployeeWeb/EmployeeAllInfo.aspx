<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EmployeeAllInfo.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.EmployeeAllInfo" Title="Swift HR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Import Namespace="System.Data"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:Panel ID="empSearchPanel" runat="server" Visible="true">
        <div class="panel">
            <header class="panel-heading autocomplete-form form-inline">
                <label>Employee Name:</label>
                <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off" width="50%" cssclass="form-control"></asp:TextBox>&nbsp; &nbsp;
                <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-sm btn-primary" 
                    onclick="BtnSearch_Click" ValidationGroup="srch"/>&nbsp;
                <asp:RequiredFieldValidator ID="rfc" runat="server" 
                   ControlToValidate="txtEmpName" Display="None" ErrorMessage="*" 
                   SetFocusOnError="True" ValidationGroup="srch"></asp:RequiredFieldValidator>
                <asp:Label ID="lblmsg" runat="server" CssClass="errormsg"></asp:Label>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                        TargetControlID="txtEmpName" MinimumPrefixLength="1" CompletionInterval="10"
                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                </cc1:AutoCompleteExtender>
                <asp:TextBox ID="txtEmpID" runat="server" Visible="false"></asp:TextBox>
                <br/>
                 <span class="subheading">
                  <asp:Label ID="LblEmpName" runat="server"></asp:Label>
            <% string empId = "0";
               empId = GetEmployeeId();
            %>
                     </span>
            </header>
          
        </div>
    </asp:Panel>
      <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="visoft__tab_xpie7">
        <cc1:TabPanel runat="server" HeaderText="Profile" ID="TabPanel1" >
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel1" runat="server">
                    <ContentTemplate>
                        <iframe class="framebody" src="/Company/EmployeeWeb/Manage.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%"> </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TpnlServiceEvent" runat="server" HeaderText="Service">
            <ContentTemplate>
                <asp:UpdatePanel ID="updtpnlServices" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/Promotion/ListEventDetails.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>

        <cc1:TabPanel ID="TpnlPromotion" runat="server" HeaderText="Promotion">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/ListPromotion.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>

        <cc1:TabPanel ID="TpnlTransfer" runat="server" HeaderText="Transfer">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/ListTransfer.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>

        <cc1:TabPanel ID="TpnlEducation" runat="server" HeaderText="Education">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel10" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ViewEducation.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>+
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TpnlMedical" runat="server" HeaderText="Medical">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel4" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ViewMedical.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="ID Card">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel5" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ListIdentification.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Family Member">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel6" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ListFamilyMembers.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe> 
                    </ContentTemplate>
                </asp:UpdatePanel>       
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Training">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel3" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ChooseTrainingType.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>        
                    </ContentTemplate>
                </asp:UpdatePanel>        
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel8" runat="server" HeaderText="Assign Leave">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel8" runat="server">
                    <ContentTemplate>
                        <iframe src="/LeaveManagementModule/LeaveAssignment/List.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>        
                    </ContentTemplate>
                </asp:UpdatePanel>      
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel9" runat="server" HeaderText="Appraisal">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel9" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/Grade/ListGrade.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe> 
                    </ContentTemplate>
                </asp:UpdatePanel>          
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="Payroll">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel7" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/PayRollAllInfo.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="Tppastexp" runat="server" HeaderText="Past Experience">
            <ContentTemplate>
                <asp:UpdatePanel ID="updtpnlpastexp" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ListPastExperience.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>

        <%--<cc1:TabPanel ID="Tpnlrefrences" runat="server" HeaderText="Refrences">
            <ContentTemplate>
                <asp:UpdatePanel ID="Updtpnlrefrences" runat="server">
                    <ContentTemplate>
                        <iframe src="/Company/EmployeeWeb/ListEmployeeReferience.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>--%>

        <cc1:TabPanel ID="TabPanel15" runat="server" HeaderText="Upload">
            <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel15" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/EmpFileUploader.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>

       <%-- <cc1:TabPanel ID="TpnlJD" runat="server" HeaderText="JD">
            <ContentTemplate>
                <asp:UpdatePanel ID="updtpnlJobDescription" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/ListJD.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>--%>

        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Supervisor">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/AddSupervisor.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel11" runat="server" HeaderText="Relative">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>               
                        <iframe src="/Company/EmployeeWeb/AddRelative.aspx?Id=<% Response.Write(empId); %>" frameborder="0" height="1000px" width="100%" > </iframe>          
                    </ContentTemplate>
                </asp:UpdatePanel>         
            </ContentTemplate> 
        </cc1:TabPanel>
        
    </cc1:TabContainer>
</asp:Content>
