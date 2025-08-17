<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRecommend.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TransferRequest.ManageRecommend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
    
    <div class="panel">
        <header class="panel-heading">
           <i class="fa fa-caret-right"></i>   Transfer Request 
        </header>
        <asp:UpdatePanel ID="ext" runat="server">
 <ContentTemplate>
        <div class="panel-body">
            <span class="txtlbl" >Please enter valid data!</span>
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         From Branch: <span class="errormsg">*</span>
                    </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ControlToValidate="DdlFromBranch" 
                ErrorMessage="Required!" SetFocusOnError="True" 
                ValidationGroup="External">
            </asp:RequiredFieldValidator>
           
            <asp:DropDownList ID="DdlFromBranch" runat="server" AutoPostBack="True" 
               class="form-control" >
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                From Department: <span class="errormsg">*</span>
            <asp:RequiredFieldValidator 
                 ID="RequiredFieldValidator11" runat="server" ControlToValidate="DdlFromDept" 
                 ErrorMessage="Required!" 
                 SetFocusOnError="True" ValidationGroup="External"> 
            </asp:RequiredFieldValidator>
                
            <asp:DropDownList ID="DdlFromDept" runat="server" AutoPostBack="True" 
                class="form-control">
            </asp:DropDownList>
                </div>

                <div class="col-md-4 form-group">
                    <label>
                        To Branch: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="DdlToBranch"
                ErrorMessage="Required!" ValidationGroup="External" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="DdlToBranch" runat="server" AutoPostBack="True" 
               class="form-control" 
                onselectedindexchanged="DdlToBranch_SelectedIndexChanged1">
            </asp:DropDownList>
                </div>

                
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        To Deapartment: <span class="errormsg">*</span>
                    </label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate="DdlToDept" 
                    ErrorMessage="Required!" ValidationGroup="External" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="DdlToDept" runat="server" class="form-control">
                </asp:DropDownList>
                </div>
                </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                     Recommend By :
                    </label>
            <asp:Label ID="lblRecommendBy" runat="server" CssClass="form-control" width="100%"></asp:Label>
                </div>
                <div class="col-md-6 autocomplete-form">
                    <label>
                    &nbsp;
                    </label><br />
                    <asp:TextBox ID="txtRecommendBy" runat="server" CssClass="form-control" 
                ontextchanged="txtRecommendBy_TextChanged" width="100%" AutoPostBack="true"></asp:TextBox> 

            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtRecommendBy">
            </cc1:AutoCompleteExtender>  
            
            <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender" 
                          runat="server" Enabled="True" TargetControlID="txtRecommendBy" 
                          WatermarkCssClass="form-control" WatermarkText="Auto Complete">
            </cc1:TextBoxWatermarkExtender>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        <span>Effective Date:</span> 
                    </label>
                    <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtEffectiveDate">
                </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         <span >Actual Reported Date: </span>
                    </label>
            <asp:TextBox ID="txtReportedDate" runat="server" CssClass="form-control" Width="100%">
            </asp:TextBox>
            <cc1:CalendarExtender ID="txtReportedDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtReportedDate">
            </cc1:CalendarExtender>
                </div>
                </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                        Transfer Description: <span class="errormsg">*</span>
                    </label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate="txtTransferDesc" 
                    ErrorMessage="Required!" ValidationGroup="External" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                    <br />
                <asp:TextBox ID="txtTransferDesc" runat="server" 
                    CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <br />
            <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary" 
                    onclick="btnApprove_Click" Text=" Recommend "/>&nbsp;

                <cc1:ConfirmButtonExtender ID="btnApprove_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Recommend ?" Enabled="True" TargetControlID="btnApprove">
                </cc1:ConfirmButtonExtender>

                <asp:Button ID="btnReject" runat="server" CssClass="btn btn-primary" 
                    onclick="btnReject_Click" Text=" Approve "/>&nbsp;

                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                    ConfirmText="Confirm To Reject ?" Enabled="True" TargetControlID="btnReject">
                </cc1:ConfirmButtonExtender>

                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                    Text="Back" onclick="BtnBack_Click" />

        </div>
    </div>
      </div>
    </div>
      
     </ContentTemplate>
 </asp:UpdatePanel>

</asp:Content>
