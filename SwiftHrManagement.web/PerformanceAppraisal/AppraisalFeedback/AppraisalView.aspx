<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AppraisalView.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.AppraisalView" Title="Swift HRM" %>
<%@ Import Namespace="System.Data"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style10
        {
        	padding:5px;
            height: 28px;
        }
        .style11
        {
        	padding:5px;
            height: 28px;
        }
        .style12
        {
        	padding:5px;
            height: 24px;
        }
        .style13
        {
        	padding:5px;
            height: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="100%">
    <tr>
        <td valign="bottom" class="wellcome" align="left">
        <img src="/images/big_bullit.gif">&nbsp;&nbsp;Performance Appraisal Details for Feedback</td>
    </tr>
    <tr>
        <td valign="top" bgcolor="#999999" height="1"></td>
    </tr>
    <tr>
        <td>
        <center>
          <table width="90%">
                <tr>                
                    <td colspan="2">
                            <div>
                                <%
                                    DataSet ds = AppraisalList(this.appId);
                                    DataTable dt = new DataTable();
                                    DataTable emp = ds.Tables[0];
                                    DataTable evaluation = ds.Tables[1];
                                    DataTable t1 = ds.Tables[2];//topic
                                    DataTable t2 = ds.Tables[3];//sub topic
                                    DataTable t3 = ds.Tables[4];//element                                    
                                    string tid = "";
                                    string sid = "";               
                                %> 
                                <table width="100%" class="">
                                <tr><td nowrap="nowrap"  class = "wellcome">Employee Name</td><td nowrap="nowrap"  class = "wellcome">:  <%=emp.Rows[0]["name"].ToString() %></td></tr>
                                <tr><td nowrap="nowrap"  class = "wellcome">Employee Position</td><td nowrap="nowrap"  class = "wellcome">:  <%=emp.Rows[0]["Position_Name"].ToString()%></td></tr>
                                <tr><td nowrap="nowrap"  class = "wellcome">Appraisal From</td><td nowrap="nowrap"  class = "wellcome">:  <%=emp.Rows[0]["FROM_DATE"].ToString()%></td></tr>
                                <tr><td nowrap="nowrap"  class = "wellcome">Appraisal To</td><td nowrap="nowrap"  class = "wellcome">:  <%=emp.Rows[0]["TO_DATE"].ToString()%></td></tr>
                                </table>
                            </div>
                            <table border = "0" cellspacing="0" id="mydata" class="TBL"></table>
                                                            
                                <tr class="HeaderStyle">
                                    <td class="style10">Topics</td>
                                    <td class="style10">Sub Topics</td>
                                    <td class="style10">Job Elements</td>
                                    <td class="style10">Rating Descriptions</td>
                                </tr> 
                                  <%foreach(DataRow row in t1.Rows){ %>  
                                <tr class="topicBg">
                                    <td class="style12"><%=row["name"].ToString() %></td>
                                    <td class="style12"></td>
                                    <td class="style12"></td>
                                    <td class="style12"></td>
                                </tr>                   
                                <%
                    tid = row["id"].ToString();
                    DataRow[] rows1 = t2.Select("Topic_Id='" + tid + "'");
                    foreach (DataRow row1 in rows1)
                    {       
                    %>                        
                        <tr  class="subTopicBg"><td class="style11"></td><td class="style11"><%=row1["Title"].ToString() %></td>
                            <td class="style11"></td><td class="style11"></td></tr>                        
                        <%
                        sid = row1["id"].ToString();
                        DataRow[] rows2 = t3.Select("Topic_Id='" + tid + "' AND SubTopic_Id='" + sid + "'");
                        foreach (DataRow row2 in rows2)
                        {
                        %>                        
                        <tr  class="topicBg"><td class="style13"><input id="element_Id" name="element_Id" type="hidden" value="<%=row2["id"].ToString()%>" /> </td> 
                            <td class="style13"></td><td class="style13"><%=row2["JOB_ELEMENT"].ToString() %></td>
                            <td class="style13">
                        <select id="element_weight" name="element_weight" disabled="disabled">
                        <option value="">Choose Rating</option>
                        <%foreach (DataRow wRow in evaluation.Rows)
                          {
                              string selected = "";
                              if (wRow["Weight"].ToString() == row2["Weight"].ToString())
                                  selected = "selected=\"selected\"";
                                  
                        %>
                            <option value="<%=wRow["Weight"].ToString()%>" <%=selected%>> <%=wRow["Name"].ToString()%></option>                            
                        <%} %>                      
                        </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                          
                        <textarea rows="1" disabled="disabled" id="element_remarks_<%=row2["id"].ToString()%>" 
                                name="element_remarks_<%=row2["id"].ToString()%>" class="inputTextBoxLP"><%=row2["Remarks"].ToString()%></textarea>
                        
                        </td></tr>                                      
                        <%}%>
                
                    <%} %>        
                <%} %>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" 
                            CssClass="button" Height="25px" Width="50px" Visible=false/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
           </center>
        </td>            
    </tr>
</table>   
</asp:Content>
