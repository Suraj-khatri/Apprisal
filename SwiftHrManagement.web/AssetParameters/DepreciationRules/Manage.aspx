<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.AssetParameters.DepreciationRules.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<script src="../../Jsfunc.js" type="text/javascript"></script> 
<div class="row">
    <div class="col-md-12">
        <section class="panel"> 
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                Depreciation Rule Setup
            </header>
            <div class="panel-body">
                <div class="col-md-12">
                    <span class="txtlbl">Please enter valid data</span>
                    <span class="required">(* Required fields)</span><br />
                    <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
                </div>
                <div class="row">
<div class="col-md-6 form-group">
                    <label>Fiscal Year:</label>
                    <asp:DropDownList ID="CmbFiscalYear" runat="server" CssClass="form-control" Width="100%" AutoPostBack="true"></asp:DropDownList>
                </div>
                </div>
                
                <div class="row">
                <div class="col-md-6">
                    <h4>Absorbed Portion</h4>
                
                    <div class="table-responsive"> 
                        <table class="table table-bordered table-striped table-condensed">
                            <thead>
                                <tr>
                                    <th>
                                        Booked Quarter
                                    </th>
                                    <th>
                                        Numerator
                                    </th>
                                    <th>
                                        Denominator
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        First Quarter:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNumerator1" name="TxtNumerator1" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDenominator1" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Second Quarter:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNumerator2" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDenominator2" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Third Quarter:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNumerator3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDenominator3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fourth Quarter:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtNumerator4" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDenominator4" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col-md-6">
                    <h4>Parameters</h4>
                
                    <div class="table-responsive"> 
                        <table class="table table-bordered table-striped table-condensed">
                            <thead>
                                <tr>
                                    <th>
                                        Asset Pool
                                    </th>
                                    <th>
                                        Depreciation
                                    </th>
                                    <th>
                                        Other Details
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        A
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDep_Percent_A" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        Allowed Repair & Maintenance %
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        B
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDep_Percent_B" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMaintenance_Percent" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        C
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDep_Percent_C" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        Limit for Disolving Asset Pool
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        D
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDep_Percent_D" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDisolve_Limit" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                     </div>
                       
            </div>
                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                            onclick="btnSave_Click" Text="Save" ValidationGroup="chart" />
                        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>     
                        &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                            Text="Back" onclick="BtnBack_Click" />
        </section>
    </div>
</div>                                                   
 </asp:Content>