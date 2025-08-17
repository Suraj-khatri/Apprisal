<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LetterTemplate.Manage" %>
<%@ Import Namespace="System.Data"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="docs/style.css" type="text/css"/>
		
		<!-- 
			Include the WYSIWYG javascript files
		-->
 
		<script type="text/javascript" src="scripts/wysiwyg.js"></script>
		<script type="text/javascript" src="scripts/wysiwyg-settings.js"></script>
		<!-- 
			Attach the editor on the textareas
		-->
		<script type="text/javascript">
		    WYSIWYG.attach('textarea2', full);

		</script>
 
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<form name="form1" id="form1" method="post">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Add Letter Template Details
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Label ID="lblHead" runat="server" Visible="False"></asp:Label>
                    </div>
                     <%  
                        string letter_detail = "";
                        if (getltId() > 0)
                        {
                            DataSet ds = populateData();
                            DataTable dt = new DataTable();
                            DataTable lt = ds.Tables[0];
                            letter_detail = lt.Rows[0]["letter_detail"].ToString();

                        }
                    %> 
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Letter Type:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="txtLetterType" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Detail Content:<span class="errormsg">*</span></label>
                                <textarea id="textarea2" name="textarea2" class="form-control" style="height:200px;"><%=letter_detail%></textarea>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="page"
                                    onclick="BtnSave_Click" />
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                    Text="Back" onclick="BtnBack_Click"/>
                            </div>
                        </div>
                        <div class="col-md-6 form-group">
                            <div id="KeywordDiv"  style=" overflow:scroll;height:27em;" runat="server"></div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</form>
<%--   <script language="javascript">
       function insertData(data) {
           var textarea2 = document.getElementById("textarea2");
           if (document.selection) {
               //alert(textarea2);
               textarea2.focus();

               var sel = document.selection.createRange();
               // alert the selected text in textarea

               // Finally replace the value of the selected text with this new replacement one
               sel.text = data;
           } else {
               // code for Mozilla
               var textarea2 = document.getElementById("textarea2");
               var len = textarea2.value.length;
               var start = textarea2.selectionStart;
               var end = textarea2.selectionEnd;
               var sel = textarea2.value.substring(start, end);
               // This is the selected text and alert it			
               var replace = data;
               // Here we are replacing the selected text with this one
               textarea2.value = textarea2.value.substring(0, start) + replace + textarea2.value.substring(end, len);
           }
       }
    </script>--%>
</asp:Content>
