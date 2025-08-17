<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.UPLOAD.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script language="javascript">
        
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;            

            for (i = 0; i < checkBoxes.length; i++){             
                checkBoxes[i].checked = boolChecked ;               
            }
        }  
       
    </script>
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Upload File For : <asp:Label ID="lblTrainingProgram" runat="server" Text="Label"></asp:Label>
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <label>File Description:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RFC" runat="server" ControlToValidate="TxtFileDescription" Display="Dynamic" 
                            ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="uploader"></asp:RequiredFieldValidator>                 
                        <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label> Select File:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fileUpload" 
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="uploader">
                        </asp:RequiredFieldValidator>
                        <input id="fileUpload" runat="server" name="fileUpload" type="file" class="inputTextBoxLP"/>                                                
                    </div>
                    <div class="form-group">
                        <asp:Table ID="tblResult" runat="server"></asp:Table>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" class="inputTextBoxLP"
                            ValidationGroup="uploader" onclick="BtnUpload_Click"/>
                       <asp:Button ID="Delete" runat="server" CssClass="btn btn-primary" onclick="Delete_Click" Text="Delete" />
                        <asp:Button ID="Btn_Back" runat="server" CssClass="btn btn-primary" OnClick="Btn_Back_Click" Text="Back" />
                    </div>
                </div>
            </section>
        </div>
    </div>           
</asp:Content>