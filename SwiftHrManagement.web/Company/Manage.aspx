<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../ui/js/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <%--<script type="text/javascript">
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Yes, I am sure!',
            cancelButtonText: "No, cancel it!",
            closeOnConfirm: false,
            closeOnCancel: false
        },
 function(isConfirm){

     if (isConfirm){
         swal("Shortlisted!", "Candidates are successfully shortlisted!", "success");

     } else {
         swal("Cancelled", "Your imaginary file is safe :)", "error");
         e.preventDefault();
     }
 });
    </script>--%>
    <div class="col-md-10 col-md-offset-1">
            <section class="panel">
               <header class="panel-heading">
                   <i class="fa fa-caret-right"></i>
             Company Entry Details
                </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span>Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="row">
                            <div class=" col-md-4 form-group">
                                <label> Company Name :</label>
                                <span class="errormsg">*</span><asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCompName" 
                                    ErrorMessage="*" Display="None" ValidationGroup="Company"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtCompName" runat="server" CssClass="form-control"></asp:TextBox> 
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Company Short Name :</label>
                                <asp:TextBox ID="TxtCompShortName" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox> 
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Address1:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtCompAddress" 
                                ErrorMessage="*" Display="None" ValidationGroup="Company"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtCompAddress" runat="server" CssClass="form-control" ></asp:TextBox>   
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Address2:</label>  
                                <asp:TextBox ID="TxtCompAddress2" runat="server" CssClass="form-control"></asp:TextBox>                        
                            </div>
                          
                                <div class="col-md-4 form-group">
                                    <label>E-Mail:<span class="errormsg">*</span></label>  
                                    <asp:RegularExpressionValidator 
                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtEmail"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="Company"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="TxtEmail" Display="None" 
                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Company"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                               
                            </div> 
                          
                                <div class="col-md-4 form-group">
                                    <label>Company URL:<span class="errormsg">*</span></label>  
                                    <asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="Txturl" 
                                            ErrorMessage="Invalid URL!" 
                                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" 
                                            ValidationGroup="Company"></asp:RegularExpressionValidator>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="Txturl" Display="None" ErrorMessage="RequiredFieldValidator" 
                                            ValidationGroup="Company"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="Txturl" runat="server" CssClass="form-control"></asp:TextBox>      
                                </div>
                            
                        </div>
                        <div class="row">
                            
                                <div class="col-md-4 form-group">
                                    <label>Phone:<span class="errormsg">*</span></label> 
                                    <asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtCompPhone" 
                                            ErrorMessage="*" Display="None" ValidationGroup="Company"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtCompPhone" runat="server" CssClass="form-control"></asp:TextBox>    
                                </div>
                                <div class="col-md-4 form-group">
                                    <label>Fax </label> 
                                    <asp:TextBox ID="TxtCompFax" runat="server" CssClass="form-control"></asp:TextBox> 
                            </div> 
                        
                                <div class="col-md-4 form-group">
                                    <label>PAN/ Vat No.</label> 
                                    <asp:TextBox ID="TxtCompMapcode" runat="server" CssClass="form-control"></asp:TextBox>         
                                </div>
                            </div>
                        <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Contact Person:<span class="errormsg">*</span></label> 
                                    <asp:RequiredFieldValidator 
                                        ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="TxtContactPerson" ErrorMessage="*" Display="None" 
                                        ValidationGroup="Company"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtContactPerson" runat="server" CssClass="form-control" 
                                        MaxLength="30"></asp:TextBox>      
                                
                            </div> 
                            </div>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>Is Active:</label>&nbsp;
                                <asp:CheckBox ID="ChkActive" runat="server" Checked="True"/>  &nbsp;&nbsp; 
                                (Uncheck For Inactive)
                            </div>
                        </div>
                       <br />
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                                    onclick="BtnSave_Click" Text="Save" ValidationGroup="Company"  /> 
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm to save?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                    onclick="BtnBack_Click" Text="Back"  />
                            </div>
                </section>
      
    </div>

</asp:Content>
