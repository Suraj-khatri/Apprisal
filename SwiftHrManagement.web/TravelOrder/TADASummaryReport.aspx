<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="TADASummaryReport.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.TADASummaryReport" %>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TADASummaryReport.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.TADASummaryReport" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                             Travel Order Summary Report
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                            </div>

                            <div class="form-group">
                                <label>Fiscal Year:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="DDL_YEAR" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="summary" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:DropDownList ID="DDL_YEAR" runat="server" CssClass="form-control" Width="100%"> 
                                </asp:DropDownList>
                                
                            </div>
                            
                            <div class="form-group autocomplete-form">
                                <label>Employee Name:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off" AutoPostBack="true" CssClass="form-control"
                                    OnTextChanged="txtEmpName_TextChanged"></asp:TextBox>
                                <strong><asp:Label ID="lblEmpName" runat="server"> </asp:Label></strong>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                    DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                    ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName">
                                </cc1:AutoCompleteExtender>
                                <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="txtEmpName"
                                    WatermarkCssClass="watermark" WatermarkText="All Employee">
                                </cc1:TextBoxWatermarkExtender>
                            </div>
                            

                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="btnDetail" runat="server" CssClass="btn btn-primary" Text="View Detail" OnClick="btnDetail_Click" ValidationGroup="summary"/>
                            </div>
                        </div>
                    </section>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
