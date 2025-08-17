<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageContributionProjection.aspx.cs" Inherits="SwiftHrManagement.web.Report.Contribution_Projection_Report.ManageContributionProjection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            One Third contribution projection report
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                   
                                    <label>Fiscal Year : <span class="errormsg">*</span> </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlFiscalYear" 
                                    SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contributionProjection" ></asp:RequiredFieldValidator>
                                 <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control" ></asp:DropDownList> 
                     
                                    
						    </div>
                                <div class="form-group">
                                    <label>Month : <span class="errormsg">*</span> </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                    ControlToValidate="DdlMonth" ValidationGroup="contributionProjection"   SetFocusOnError="True" ></asp:RequiredFieldValidator> 
                                      <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control" 
                                        AutoPostBack="True" ></asp:DropDownList> 
                                     
                                </div>
                              <div class="form-group">
                                    <label>Branch :  </label>
                                    <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control" 
                                        AutoPostBack="True"  onselectedindexchanged="DdlBranchType_SelectedIndexChanged" ></asp:DropDownList>  
                                  </div>
                                 <div class="form-group">
                                    <label>Department :  </label>
                                       <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="form-control" 
                                            AutoPostBack="True"  onselectedindexchanged="DdlDepartment_SelectedIndexChanged" ></asp:DropDownList>
                                    </div>
                             <div class="form-group">
                                    <label>Employee :  </label>
                             <asp:DropDownList ID="DdlEmployee" runat="server" CssClass="form-control" 
                                        AutoPostBack="True"  ></asp:DropDownList>  
                                 </div>
                             <div class="form-group">
                                    <asp:Button ID="BtnShowReport" runat="server" CssClass="btn btn-primary" Text="Show Report" 
                                         ValidationGroup="contributionProjection" onclick="BtnShowReport_Click"/>
                                 </div>
                            </div>
                        </section>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

