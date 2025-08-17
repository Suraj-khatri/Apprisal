<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="PaySlip.aspx.cs" Inherits="SwiftHrManagement.web.PaySlip.PaySlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
            <div class="col-md-12 form-group" style="text-align: center;">
                    <label>
                        <!--<img src=""  alt="nabil" height="50"  />--> &nbsp;
                    </label><br/>
               <label> Monthly Pay-Slip</label>
                <br/>
                   <label>Date : </label> 
            <asp:Label runat="server" ID="lblDate"></asp:Label> 
                </div>
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
Name:
                    </label>
                      <asp:Label runat="server" ID="lblEmpName"></asp:Label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Month:
                    </label>
                    <asp:Label runat="server" ID="lblMonthName"></asp:Label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Office:
                    </label>
                     <asp:Label runat="server" ID="lblBranchName"></asp:Label>
                </div>

            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
Fiscal Year:
                    </label>
                     <asp:Label runat="server" ID="lblFiscalYear"></asp:Label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Position
                    </label>
                    <asp:Label runat="server" ID="lblPosition"></asp:Label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        A/c No
                    </label>
                    <asp:Label runat="server" ID="lblBankAccount"></asp:Label>
                </div>
            </div>
            <div class="row">
            <div class="col-md-12" id="rptSalary" runat="server"></div>
             <div class="col-md-12" id="rptSalaryD" runat="server"></div>
              </div>
            <div class="row">
                <div class="col-md-6"><label>Net Home Take </label> </div>
                 <div class="col-md-6"><asp:Label runat="server" ID="lblNetAmount"></asp:Label></div>
                </div>
            <div class="row">
                <div class="col-md-12">
                    <lable>Annual Income Detail</lable>
                     <div id="YearlyBenefits" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label>Insurance Premium (Paid By Bank)</label> 
                     <div id="InsuranceBenefit" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label> Tax Calculation Details</label>
                     <div id="TaxCalculationDetail" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label>Tax & Gratuity</label>
                      <div id="TaxNGratuity" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label> Loan/Advance/Facility</label>
                    <div id="Facility" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label> Appraisal Rating</label>
                    <div id="AppRating" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label>Estimatated Self RF contribution For This Year</label>
                    <div id="EstimatedRf" runat="server"></div>
                </div>
            </div>
            
        </div>
    </div>

   
 
</asp:Content>
