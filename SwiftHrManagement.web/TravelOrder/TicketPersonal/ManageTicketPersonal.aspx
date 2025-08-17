<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageTicketPersonal.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.TicketPersonal.ManageTicketPersonal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" language="javascript">


        function DeleteEmp(ID) {
            if (confirm("Are you sure to Delete this?")) {
                document.getElementById("<% =hdnEmpId.ClientID %>").value = ID;
                document.getElementById("<%=btnDeleteEmp.ClientID %>").click();
            }
        }

       
       
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
   
<asp:UpdatePanel ID="UPDATE1" runat="server">
    <ContentTemplate> 
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                        Add New Ticket Personal
                </header>
                <div class="panel-body">

                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Description:</label>
                        <asp:TextBox ID="TxtDataType" runat="server" CssClass="form-control"  Width="100%" Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="TxtTypeId" runat="server" CssClass="form-control"  Width="100%" Enabled="False" Style="margin-left: 0px"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-md-10">
                            <div class="form-group autocomplete-form">
                                <label>Employee Name:</label><span class="errormsg">*</span>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpName"
                                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="ticket"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdnEmpId" runat="server" />
                                <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control"  Width="100%" ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true"
                                    Enabled="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                    ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName" />
                                <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txtEmpName" WatermarkCssClass="watermark" WatermarkText="All Employee" />
                    
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <br/>
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                OnClick="btnAdd_Click" Font-Strikeout="False" ValidationGroup="ticket"
                                Width="75px" />
                    
                            </div>
                        </div>
                        
                    </div>
                    
                    
                    <div id="rptEmp" runat="server"></div> 
                
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                            OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="ticket"
                            Width="75px" />
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                            OnClick="BtnDelete_Click" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Delete ?" Enabled="True"
                            TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                            OnClick="BtnBack_Click" Text=" Back" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnDeleteEmp" runat="server"  Text="" OnClick="btnDeleteEmp_Click" Style="display: none;" />
                    </div>
                </div>
            </section>
        </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>

    
</asp:Content>
