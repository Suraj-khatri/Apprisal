<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TaxRuleSetup.BasicTaxRate.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
            border-top: 1px solid #ffffff !important;
            line-height: 1.42857;
            padding: 8px;
            vertical-align: top;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <header class="panel-heading">
                             <i class="fa fa-caret-right" aria-hidden="true"></i> 
                            Tax Rule Details
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>                            
                            <div class="row">
                                <div class="col-md-12"> 
                                    <label>Fiscal Year</label>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="col-md-6 form-group">
                                            <label> Select Year:</label><span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ErrorMessage="Required!" ControlToValidate="CmbFiscalYear" AutoComplete="Off"
                                                Display="Dynamic" ValidationGroup="TaxRule" BorderColor="#FFFF66"
                                                SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="CmbFiscalYear" runat="server" CssClass="form-control" Width="100%" 
                                                onselectedindexchanged="CmbFiscalYear_SelectedIndexChanged" AutoPostBack="true"> 
                                            </asp:DropDownList>                                            
                                            <asp:HiddenField ID="HFRowID" runat="server" Visible="False" />
                                        </div>
                                        <div class="col-md-6 form-group">
                                            <label>Copy From:</label><span class="errormsg">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ErrorMessage="Required!" ControlToValidate="CmbFiscalYear" AutoComplete="Off"
                                                Display="Dynamic" ValidationGroup="TaxRule" BorderColor="#FFFF66"
                                                SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="CmbCopyFrom" runat="server" CssClass="form-control" Width="100%"  
                                                onselectedindexchanged="CmbCopyFrom_SelectedIndexChanged" AutoPostBack="true"> 
                                            </asp:DropDownList>                                       
                                        </div>
                                    </asp:Panel>
                                 </div>
                            </div>
                            <br/>
                            <div class="row">
                                <div class="col-md-12">  
                                    <label>Basic Tax Rate</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12"> 
                                    <asp:Panel ID="TaxRatePanel" runat="server">
                                    <table class="table table1" style="border:0!important;" >
                                        <tr> 
                                            <th>&nbsp;</th>         
                                            <th colspan="2" style="text-align:center;font-weight:bold">Married</th>
                                            <th colspan="2" style="text-align:center;font-weight:bold">UnMarried</th>          
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>Amount</td>
                                            <td>Tax %</td>
                                            <td>Amount</td>
                                            <td>Tax %</td>
                                        </tr>
                                        <tr>
                                            <td class="txtlbl">
                                                <div class="form-group">
                                                    <div align="right"><label>First Slab:</label></div>
                                                </div>
                                            </td>
                                            </div>
                                            <td>            
                                                <asp:TextBox ID="TxtMarriedAmount1" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="cv1" runat="server" 
                                                    ControlToValidate="TxtMarriedAmount1" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                                    runat="server" ControlToValidate="TxtMarriedAmount1" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtMarriedTaxRate1" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                            <br />
                                                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                                    ControlToValidate="TxtMarriedTaxRate1" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double"
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RangeValidator ID="RangeValidator14" runat="server" 
                                                    ControlToValidate="TxtMarriedTaxRate1" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>   
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                                    runat="server" ControlToValidate="TxtMarriedTaxRate1" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtUnMarriedAmount1" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CV2" runat="server" 
                                                    ControlToValidate="TxtUnMarriedAmount1" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                                    runat="server" ControlToValidate="TxtUnMarriedAmount1" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>                                        
                                                <asp:TextBox ID="TxtUnMarriedTaxRate1" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                            <br />
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" 
                                                    ControlToValidate="TxtUnMarriedTaxRate1" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                    ControlToValidate="TxtUnMarriedTaxRate1" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                                    runat="server" ControlToValidate="TxtUnMarriedTaxRate1" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group">
                                                    <div align="right"><label>Second Slab:</label></div>
                                                </div>
                                            </td>
                                            </div>
                                            <td>
                                                <asp:TextBox ID="TxtMarriedAmount2" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                    ControlToValidate="TxtMarriedAmount2" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                                        runat="server" ControlToValidate="TxtMarriedAmount2" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>                                           
                                                <asp:TextBox ID="TxtMarriedTaxRate2" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                    </asp:TextBox>
                                                    <br />
                                                <asp:CompareValidator ID="CompareValidator10" runat="server" 
                                                    ControlToValidate="TxtMarriedTaxRate2" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                    ControlToValidate="TxtMarriedTaxRate2" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                                    runat="server" ControlToValidate="TxtMarriedTaxRate2" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtUnMarriedAmount2" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                    ControlToValidate="TxtUnMarriedAmount2" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                                                        runat="server" ControlToValidate="TxtUnMarriedAmount2" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>                                            
                                                <asp:TextBox ID="TxtUnMarriedTaxRate2" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                    </asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CompareValidator11" runat="server" 
                                                    ControlToValidate="TxtUnMarriedTaxRate2" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                                    ControlToValidate="TxtUnMarriedTaxRate2" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                                                        runat="server" ControlToValidate="TxtUnMarriedTaxRate2" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>    
                                        <tr>                                            
                                                <td>
                                                    <div class="form-group">
                                                        <div align="right"><label>Third Slab:</label></div>
                                                    </div>
                                                </td>                                            
                                            <td>
                                                <asp:TextBox ID="TxtMarriedAmount3" runat="server" CssClass="form-control" Width="100%"
                                                    Text="REMAINING" ReadOnly="true" style="text-align:right">
                                                </asp:TextBox>
                                                <br />            
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                                                        runat="server" ControlToValidate="TxtMarriedAmount3" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>       
                                            <td>
                                            
                                                <asp:TextBox ID="TxtMarriedTaxRate3" runat="server" CssClass="form-control" Width="100%"  style="text-align:right">
                                                </asp:TextBox>
                                                <br />
                                                    <asp:CompareValidator ID="CompareValidator12" runat="server" 
                                                    ControlToValidate="TxtMarriedTaxRate3" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator4" runat="server" 
                                                    ControlToValidate="TxtMarriedTaxRate3" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                                                        runat="server" ControlToValidate="TxtMarriedTaxRate3" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtUnMarriedAmount3" runat="server" CssClass="form-control" Width="100%"
                                                    Text="REMAINING" ReadOnly="true" style="text-align:right">
                                                </asp:TextBox>
                                                <br />            
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" 
                                                        runat="server" ControlToValidate="TxtUnMarriedAmount3" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>                                            
                                                <asp:TextBox ID="TxtUnMarriedTaxRate3" runat="server" CssClass="form-control" Width="100%" style="text-align:right">
                                                </asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CompareValidator13" runat="server" 
                                                    ControlToValidate="TxtUnMarriedTaxRate3" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator5" runat="server" 
                                                    ControlToValidate="TxtUnMarriedTaxRate3" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" 
                                                        runat="server" ControlToValidate="TxtUnMarriedTaxRate3" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>                                   
                                </asp:Panel>
                            </div>
                            </div>                            
                            <div class="row">
                                 <div class="col-md-12"> 
                                     <label>Tax</label> 
                                    <asp:Panel ID="TaxPanelAdditionalTax" runat="server">
                                        <div class="row">
                                             <div class="form-group">
                                                 <div class="col-md-3 col-md-offset-3 text-center">Amount</div>
                                                 <div class="col-md-3 text-center">Percentage</div>
                                                 <div class="col-md-3 text-center">Percentage Of</div>
                                            </div>
                                        </div>
                                     <div class="row">
                                         <div class="form-group">
                                         <div class="col-md-3 text-center"><label>Amount Greater Than:</label></div>
                                         <div class="col-md-3">
                                            <asp:TextBox ID="TxtAdditionalTaxAmount" runat="server" CssClass="form-control" ></asp:TextBox>
                                                <br />
                                            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="TxtAdditionalTaxAmount" 
                                                    Display="None" ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule">
                                            </asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" 
                                                    runat="server" ControlToValidate="TxtAdditionalTaxAmount" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                         </div>
                                         <div class="col-md-3 form-group">
                                            <asp:TextBox ID="TaxableAmountGreaterThan" runat="server" CssClass="form-control" >                        
                                                    </asp:TextBox>
                                              <br />
                                            <asp:CompareValidator ID="CompareValidator6" runat="server" 
                                                ControlToValidate="TaxableAmountGreaterThan" Display="None" 
                                                ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" ValidationGroup="TaxRule">

                                            </asp:CompareValidator> 
                                            <asp:RangeValidator ID="RangeValidator6" runat="server" 
                                                    ControlToValidate="TaxableAmountGreaterThan" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double">                                                \
                                            </asp:RangeValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" 
                                                runat="server" ControlToValidate="TaxableAmountGreaterThan" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                         </div>
                                         <div class="col-md-3 form-group">
                                             <asp:TextBox ID="TaxableAmountGreaterThanOf" runat="server" CssClass="form-control"
                                                    Text="Tax Amount of third slab" ReadOnly="true">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" 
                                                    runat="server" ControlToValidate="TaxableAmountGreaterThanOf" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                         </div>
                                     </div>
                                    </div>
                                </asp:Panel>
                                 </div>
                            </div>                            
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Tax</label> 
                                    <asp:Panel ID="TaxPanel" runat="server">
                                    <div class="row">
                                         <div class="col-md-3 col-md-offset-3 text-center">Percentage</div>
                                         <div class="col-md-3 text-center">Percentage Of </div>
                                     </div>
                                    <div class="row">
                                        <div class="form-group">
                                         <div class="col-md-3 form-group text-center"><label>Non Residential Tax:</label></div>
                                         <div class="col-md-3 form-group">
                                            <asp:TextBox ID="TxtNonResidentialTaxRate" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <br />
                                            <asp:CompareValidator ID="CompareValidator14" runat="server" 
                                                ControlToValidate="TxtNonResidentialTaxRate" Display="None" 
                                                ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                ValidationGroup="TaxRule"></asp:CompareValidator> 
                                            <asp:RangeValidator ID="RangeValidator7" runat="server" 
                                                ControlToValidate="TxtNonResidentialTaxRate" ErrorMessage="Invalid Rate!" 
                                                MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" 
                                                    runat="server" ControlToValidate="TxtNonResidentialTaxRate" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                         </div>
                                        <div class="col-md-3 form-group">
                                            <asp:TextBox ID="TxtNonResidentialTaxRateOf" runat="server" CssClass="form-control" 
                                                Text="Of Total Benefit" ReadOnly="true">
                                            </asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                ControlToValidate="TxtNonResidentialTaxRateOf" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                     </div>
                                    </div>
                                </asp:Panel>
                                </div>
                            </div>                            
                             <div class="row">
                                 <div class="col-md-12">
                                     <label>Other Benefits</label> 
                                      <asp:Panel ID="BenifitsPanel" runat="server">
                                    <div class="row">
                                         <div class="col-md-3 col-md-offset-3 form-group text-center">Percentage</div>
                                         <div class="col-md-3 form-group text-center">Percentage Of </div>
                                     </div>
                                    <div class="row">
                                        <div class="form-group">
                                         <div class="col-md-3 form-group text-center"><label>Vehicle Facility:</label></div>
                                         <div class="col-md-3 ">
                                            <asp:TextBox ID="TxtVehicleRate" runat="server" CssClass="form-control" >                        
                                            </asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator15" runat="server" 
                                                ControlToValidate="TxtVehicleRate" Display="None" 
                                                ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                ValidationGroup="TaxRule"></asp:CompareValidator> 
                                            <asp:RangeValidator ID="RangeValidator8" runat="server" 
                                                ControlToValidate="TxtVehicleRate" ErrorMessage="Invalid Rate!" 
                                                MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" 
                                                runat="server" ControlToValidate="TxtVehicleRate" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                           
                                         </div>
                                        <div class="col-md-3 form-group">
                                            <asp:DropDownList ID="CmbVehicleRateOf" runat="server" CssClass="form-control" ></asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" 
                                                runat="server" ControlToValidate="CmbVehicleRateOf" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                     </div>
                                    </div>
                                    <div class="row">
                                         <div class="col-md-3 form-group text-center"><label>House Facility:</label></div>
                                         <div class="col-md-3 form-group">
                                            <asp:TextBox ID="TxtHouseRate" runat="server" CssClass="form-control" >                        
                                            </asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator7" runat="server" 
                                                ControlToValidate="TxtHouseRate" Display="None" 
                                                ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                ValidationGroup="TaxRule"></asp:CompareValidator> 
                                            <asp:RangeValidator ID="RangeValidator9" runat="server" 
                                            ControlToValidate="TxtHouseRate" ErrorMessage="Invalid Rate!" 
                                                MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" 
                                                runat="server" ControlToValidate="TxtHouseRate" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>                                           
                                         </div>
                                        <div class="col-md-3 form-group">
                                            <asp:DropDownList ID="CmbHouseRateOf" runat="server" CssClass="form-control" ></asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" 
                                                runat="server" ControlToValidate="CmbHouseRateOf" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                     </div>
                                    </div>
                                </asp:Panel>
                                </div>
                            <div class="row">
                                 <div class="col-md-12">
                                     <label>Discount</label> 
                                    <asp:Panel ID="DiscountPanel" runat="server">
                                    <div class="row">
                                         <div class="col-md-3 col-md-offset-3 form-group text-center">Percentage</div>
                                         <div class="col-md-3 form-group text-center">Percentage Of </div>
                                     </div>
                                    <div class="row">
                                         <div class="col-md-3 form-group text-center"><label>Discount For Women:</label></div>
                                         <div class="col-md-3 form-group">
                                            <asp:TextBox ID="TxtDiscountRate" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:CompareValidator ID="CompareValidator17" runat="server" 
                                                    ControlToValidate="TxtDiscountRate" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator10" runat="server" 
                                                    ControlToValidate="TxtDiscountRate" ErrorMessage="Invalid Rate!" 
                                                        MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double"></asp:RangeValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" 
                                                    runat="server" ControlToValidate="TxtDiscountRate" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                           
                                         </div>
                                        <div class="col-md-3 form-group">
                                            <asp:TextBox ID="TxtDiscountRateOf" runat="server" CssClass="form-control"  Text="Of Tax Amount" ReadOnly="true" >
                                            </asp:TextBox>
                                                <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" 
                                                runat="server" ControlToValidate="TxtDiscountRateOf" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                     </div>

                                </asp:Panel>
                                </div>
                            </div>                            
                            <div class="row">
                                 <div class="col-md-12"> 
                                     <label>Deductibles</label>
                                    <asp:Panel ID="DeductiblesPanel" runat="server">
                                   <table class="table">
                                        <tr>
                                            <td></td>
                                            <td ><div class="text-center">Percentage</div></td>
                                            <td ><div class="text-center">Percentage Of</div></td>
                                            <td ><div class="text-center">Comparision Amount</div></td>
                                            <td ><div class="text-center">Higher/Lower</div></td>
                                            <td ><div class="text-center">Compare with Actual</div></td>                        
                                        </tr>
                                        <tr>                        
                                            <td class="form-group"><div class="text-right" style="width:100%"><label>Pension Holder:</label></div></td>  
                                            <td>                                                
                                                <asp:TextBox ID="TxtPensionRate" runat="server" CssClass="form-control" Width="100%" 
                                                    style="text-align:right"></asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CompareValidator18" runat="server" 
                                                    ControlToValidate="TxtPensionRate" Display="None" ErrorMessage="Invalid Rate!" SetFocusOnError="True" 
                                                    Type="Double" ValidationGroup="TaxRule">
                                                </asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="TxtPensionRate" 
                                                    ErrorMessage="Invalid Rate!" MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double">
                                                </asp:RangeValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" 
                                                    runat="server" ControlToValidate="TxtPensionRate" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>                      
                                            <td>
                                                <asp:TextBox ID="TxtPensionRateOf" runat="server" CssClass="form-control" Width="100%"
                                                        Text="FIRST SLAB" ReadOnly="true" ></asp:TextBox>
                                                    <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TxtPensionRateOf" 
                                                    Display="None" ErrorMessage="*" ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td >
                                                <asp:TextBox ID="TxtPensionCompAmount" runat="server" ReadOnly="true" CssClass="form-control" 
                                                    Width="100%" style="text-align:right"></asp:TextBox>
                                                    <br />
                                                <asp:CompareValidator ID="CompareValidator8" runat="server" 
                                                    ControlToValidate="TxtPensionCompAmount" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" 
                                                    runat="server" ControlToValidate="TxtPensionCompAmount" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td >
                                                <asp:DropDownList ID="CmbPensionHigherLower" runat="server" Enabled="false" CssClass="form-control" 
                                                    Width="100%"></asp:DropDownList>
                                                    <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" 
                                                    runat="server" ControlToValidate="CmbPensionHigherLower" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="text-center"><div  class="text-center">
                                            <asp:CheckBox ID="ChkPensionHolder" runat="server" Width="100%" Enabled="false" />                         
                                            </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="form-group" ><div align="right" style="width:100%"><label>Disable:</label></div></td>
                                            </div>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" 
                                                    runat="server" ControlToValidate="TxtDisableRate" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule" Type="Double">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="TxtDisableRate" runat="server" CssClass="form-control" Width="100%" 
                                                    style="text-align:right"></asp:TextBox>
                                                <br />
                                                <asp:CompareValidator ID="CompareValidator19" runat="server" 
                                                ControlToValidate="TxtDisableRate" Display="None" 
                                                ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator12" runat="server" 
                                                ControlToValidate="TxtDisableRate" ErrorMessage="Invalid Rate!" 
                                                MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double">
                                            </asp:RangeValidator>                                               
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtDisableRateOf" runat="server" CssClass="form-control" Width="100%"
                                                    Text="FIRST SLAB" ReadOnly="true"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" 
                                                    runat="server" ControlToValidate="TxtDisableRateOf" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                    </asp:RequiredFieldValidator>    
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtDisableCompAmount" runat="server" ReadOnly="true" CssClass="form-control" 
                                                    Width="100%" style="text-align:right"></asp:TextBox>
                                                    <br />
                                                    <asp:CompareValidator ID="CompareValidator9" runat="server" 
                                                    ControlToValidate="TxtDisableCompAmount" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" 
                                                runat="server" ControlToValidate="TxtDisableCompAmount" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="CmbDisableHigherLover" runat="server" Enabled="false" CssClass="form-control" 
                                                    Width="100%"></asp:DropDownList>
                                                    <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" 
                                                runat="server" ControlToValidate="CmbDisableHigherLover" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="text-center"><div align="center">
                                                <asp:CheckBox ID="ChkDisable" runat="server" Enabled="false"/>                             
                                            </div></td>
                                        </tr>
                                        <tr>
                                            <td class="form-group"><div align="right" style="width:100%"><label>Normal Donation:</label></div></td>
                                            <td> <asp:TextBox ID="TxtDonationRate" runat="server" CssClass="form-control" Width="100%" 
                                                    style="text-align:right"></asp:TextBox>
                                                    <br />
                                                <asp:CompareValidator ID="CompareValidator20" runat="server" 
                                                ControlToValidate="TxtDonationRate" Display="None" 
                                                ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RangeValidator ID="RangeValidator13" runat="server" 
                                                ControlToValidate="TxtDonationRate" ErrorMessage="Invalid Rate!" 
                                                MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double">
                                                </asp:RangeValidator>   
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" 
                                                    runat="server" ControlToValidate="TxtDonationRate" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtDonationRateOf" runat="server" CssClass="form-control" Width="100%"
                                                    Text="Adjusted Taxable Income" ReadOnly="true"></asp:TextBox>
                                                    <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" 
                                                    runat="server" ControlToValidate="TxtDonationRateOf" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtDonationCompAmount" runat="server" CssClass="form-control" Width="100%"
                                                    style="text-align:right"></asp:TextBox>
                                                    <br />
                                                    <asp:CompareValidator ID="CompareValidator16" runat="server" 
                                                    ControlToValidate="TxtDonationCompAmount" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" 
                                                runat="server" ControlToValidate="TxtDonationCompAmount" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="CmbDonationHigherLower" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                                    <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" 
                                                    runat="server" ControlToValidate="CmbDonationHigherLower" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="text-center"><div class="text-center">
                                            <asp:CheckBox ID="ChkDonation" runat="server" />
                                                <br />                        
                                            </div></td>
                                        </tr>
                                        <tr>
                                            <td class="form-group"><div class="text-right" style="width:100%"><label>Insurance:</label></div></td>
                                            <td>                                                
                                                <asp:TextBox ID="TxtInsuranceRate" runat="server" CssClass="form-control" Width="100%" 
                                                    style="text-align:right"></asp:TextBox>
                                                    <br />
                                                <asp:CompareValidator ID="CompareValidator21" runat="server" 
                                                    ControlToValidate="TxtInsuranceRate" Display="None" 
                                                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                    <asp:RangeValidator ID="RangeValidator15" runat="server" 
                                                    ControlToValidate="TxtInsuranceRate" ErrorMessage="Invalid Rate!" 
                                                    MaximumValue="100" MinimumValue="0.01" ValidationGroup="TaxRule" Type="Double">
                                                    </asp:RangeValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" 
                                                    runat="server" ControlToValidate="TxtInsuranceRate" Display="None" ErrorMessage="*" 
                                                        ValidationGroup="TaxRule">
                                                    </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtInsuranceRateOf" runat="server" CssClass="form-control" Width="100%"
                                                    Text="Premium" ReadOnly="true" ></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" 
                                                    runat="server" ControlToValidate="TxtInsuranceRateOf" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                    </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtInsuranceCompAmount" runat="server" CssClass="form-control" Width="100%" 
                                                    style="text-align:right"></asp:TextBox>
                                                    <br />
                                                <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="TxtInsuranceCompAmount" 
                                                    Display="None" ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" 
                                                    ControlToValidate="TxtInsuranceCompAmount" Display="None" ErrorMessage="*" ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="CmbInsuranceHigherLower" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" 
                                                runat="server" ControlToValidate="CmbInsuranceHigherLower" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="text-center"><div class="text-center">
                                                <asp:CheckBox ID="ChkInsurance" runat="server" Width="100%" />                             
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </div>
                            </div>
                            
                            <div class="row">
                                 <div class="col-md-12">
                                     <label>Contribution</label> 
                                     <asp:Panel ID="ContributionPanel" runat="server">
                                      <table class="table">
                                          <tr>
                                            <td></td>
                                            <td ><div class="text-center">Fraction</div></td>
                                            <td ><div class="text-center">Fraction Of</div></td>
                                            <td ><div class="text-center">Comparision Amount</div></td>
                                            <td ><div class="text-center">Higher/Lower</div></td>
                                            <td ><div class="text-center">Compare with Actual</div></td>                        
                                        </tr>
                                        <tr>                        
                                            <td class="form-group"><div class="text-right" style="width:100%"><label>Calculation:</label></div></td>  
                                            <td>
                                                <asp:TextBox ID="TxtFraction" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" 
                                                    runat="server" ControlToValidate="TxtFraction" Display="None" ErrorMessage="*" 
                                                    ValidationGroup="TaxRule">
                                                    </asp:RequiredFieldValidator>
                                            </td>                      
                                            <td>
                                                <asp:TextBox ID="TxtFractionOf" runat="server" CssClass="form-control" Width="100%"
                                                    Text="TOTAL BENEFIT" ReadOnly="true"></asp:TextBox>
                                                    <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" 
                                                runat="server" ControlToValidate="TxtFractionOf" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtContributionCompAmount" runat="server" CssClass="form-control" Width="100%" style="text-align:right"></asp:TextBox>
                                                    <br />
                                                    <asp:CompareValidator ID="CompareValidator23" runat="server" 
                                                    ControlToValidate="TxtContributionCompAmount" Display="None" 
                                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                                    ValidationGroup="TaxRule"></asp:CompareValidator> 
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" 
                                                runat="server" ControlToValidate="TxtContributionCompAmount" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            <asp:DropDownList ID="CmbContributionHigherLower" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                                <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" 
                                                runat="server" ControlToValidate="CmbContributionHigherLower" Display="None" ErrorMessage="*" 
                                                ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="text-center"><div class="text-center"><asp:CheckBox ID="ChkContribution" runat="server" Width="100%" /></div></td>
                                        </tr>                 
                                      </table>
                                  </asp:Panel>
                                </div>
                            </div>
                            
                            <div class="row">
                                 <div class="col-md-12"> 
                                     <label>Remote Location</label>
                                    <asp:Panel ID="RL_Panel" runat="server">
                                    <div class="row">
                                        <div class="col-md-3 form-group text-center">
                                            Remote Location Group:
                                        </div>
                                        <div class="col-md-3 form-group text-center">
                                            Maximum Amount
                                        </div> 
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 form-group text-center">
                                            <label>Group A:</label>
                                        </div>
                                        <div class="col-md-3 form-group text-center">
                                            <asp:TextBox ID="Remotelocation" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" 
                                            runat="server" ControlToValidate="Remotelocation" Display="None" ErrorMessage="*" 
                                            ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div> 
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 form-group text-center">
                                           <label>Group B:</label>
                                        </div>
                                        <div class="col-md-3 form-group text-center">
                                            <asp:TextBox ID="GroupB" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" 
                                            runat="server" ControlToValidate="GroupB" Display="None" ErrorMessage="*" 
                                            ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div> 
                                    </div>
                                     <div class="row">
                                        <div class="col-md-3 form-group text-center">
                                            <label>Group C:</label>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="GroupC" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" 
                                            runat="server" ControlToValidate="GroupC" Display="None" ErrorMessage="*" 
                                            ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div> 
                                    </div>
                                     <div class="row">
                                        <div class="col-md-3 form-group text-center">
                                           <label>Group D:</label>
                                        </div>
                                        <div class="col-md-3 form-group text-center">
                                            <asp:TextBox ID="GroupD" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" 
                                            runat="server" ControlToValidate="GroupD" Display="None" ErrorMessage="*" 
                                            ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div> 
                                    </div>
                                     <div class="row">
                                        <div class="col-md-3 form-group text-center">
                                            <label>Group E:</label>
                                        </div>
                                        <div class="col-md-3 form-group text-center">
                                            <asp:TextBox ID="GroupE" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" 
                                            runat="server" ControlToValidate="GroupE" Display="None" ErrorMessage="*" 
                                            ValidationGroup="TaxRule">
                                            </asp:RequiredFieldValidator>
                                        </div> 
                                    </div>                                    
                                </asp:Panel>
                                </div>
                            </div>
                            
                            <div class="row">
                                 <div class="col-md-12"> 
                                     <label>Medical Tax Credit</label>
                                    <asp:Panel ID="Medical_Panel" runat="server">
                                    <div class="col-md-6 form-group">                                  
                                        <label>Medical Tax Percent:</label>
                                        <asp:TextBox ID="medical_tax_pcnt" runat="server" CssClass="form-control" ></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" 
                                        runat="server" ControlToValidate="medical_tax_pcnt" Display="None" ErrorMessage="*" 
                                        ValidationGroup="TaxRule">
                                        </asp:RequiredFieldValidator>                                    
                                    </div>   
                                    <div class="col-md-6 form-group">                                  
                                        <label>Medical Tax Limit:</label>
                                        <asp:TextBox ID="medical_tax_limit" runat="server" CssClass="form-control" ></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" 
                                        runat="server" ControlToValidate="medical_tax_limit" Display="None" ErrorMessage="*" 
                                        ValidationGroup="TaxRule">
                                        </asp:RequiredFieldValidator>                                    
                                    </div>   
                                    </asp:Panel>
                                </div>
                            </div>                            
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="TaxRule"
                                    Width="75px" />
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_Click" Text=" Back" />
                            </div>

                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

