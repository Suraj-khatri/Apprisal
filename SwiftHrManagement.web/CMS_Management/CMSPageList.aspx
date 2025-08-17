<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMSPageList.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.CMSPageList" %>
<%@ Import Namespace="System.Data"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Swift HR Management System 1.0</title>
    <link href="/Css/style.css" rel="Stylesheet" type="text/css" />
   
</head>
<body>
<form runat="server" id="form1">
            <%                                  
                            DataSet ds = PopulateCMSPage(this.Id);
                            DataTable dt = new DataTable();
                            DataTable cms = ds.Tables[0];
                            DataTable doc = ds.Tables[1];

                            DataSet DS1 = PopulateCMSNotice();
                            DataTable noticeHead = new DataTable();
                            DataTable notice = DS1.Tables[0];

                            if (cms.Rows[0]["func_type"].ToString() == "Content")
                            { %> 
                       
                                
<table>
                       
    <tr>
        <td> <span class="wellcome2"><strong><%=cms.Rows[0]["func_head"].ToString()%></strong></span></td>
    </tr>
    <tr>
        <td><%=cms.Rows[0]["func_detail"].ToString()%>

        </td>
    </tr>
    <tr>
     
        <td>
        <%
              if(doc.Rows.Count>0)
          { %>
    <table border="1" cellpadding="3" cellspacing="0" class="TBL">
        <tr>
          <td bgcolor="#E6E4D9"><strong>S.N. </strong></td>
          <td bgcolor="#E6E4D9"><strong>File Description </strong></td>
           <td bgcolor="#E6E4D9"><strong>File Date </strong></td>
          <td bgcolor="#E6E4D9"><strong>File Type</strong></td>
          <td bgcolor="#E6E4D9"><strong>Uploaded Date</strong></td>
          <td bgcolor="#E6E4D9"><strong>Link</strong></td>
        </tr>
         <%foreach (DataRow row in doc.Rows)
           { %>  
       
        <tr>
        
          <td  nowrap="nowrap"><%=row["SN"].ToString()%></td>
          <td  nowrap="nowrap"><%=row["doc_desc"].ToString()%></td>
          <td  nowrap="nowrap"><%=row["file_date"].ToString()%></td>
          <td nowrap="nowrap"><%=row["doc_ext"].ToString()%></td>
          <td nowrap="nowrap"><%=row["created_date"].ToString()%></td>
          <td  nowrap="nowrap"><a target='_blank' href='/doc/CMS_Management/<%=row["funct_id"].ToString() %>/<%=row["rowid"].ToString() %>.<%=row["doc_ext"].ToString() %>'>
          <img src="images/<%=row["doc_ext"].ToString() %>.jpg" alt="<%=row["doc_ext"].ToString() %>" width="35" height="30" style="border:0px;"/></a></td>
        </tr> 
           <%} %>        
      </table> 
      <%} %>
        </td>
    </tr>
    </table>
    
<%
                                    }
    if (cms.Rows[0]["func_type"].ToString() == "Notice")
    {%>
        <table>
                       
    <tr>
        <td> <span class="wellcome2"><strong><%=cms.Rows[0]["func_head"].ToString()%></strong></span></td>
    </tr>
    <tr>
        <td><%=cms.Rows[0]["func_detail"].ToString()%>

        </td>
    </tr>
    </table>
        
   <% }
                            if (cms.Rows[0]["func_type"].ToString() == "Query")
                            {%>
<table>                      
    <tr>
        <td> <span class="wellcome2"><strong><%=cms.Rows[0]["func_head"].ToString()%></strong></span></td>
    </tr>
    <tr>
        <td>
            <table border="0" class="TBL" cellpadding="5" cellspacing="5">  
                <tr>
    
    <%
      int cols = doc.Columns.Count;                        
      for (int i = 0; i < cols; i++)
      {%>
         <th align="left"><%=doc.Columns[i].ColumnName %></th>
      <%}%>
     </tr>
     
     <%                           
                                 
         foreach (DataRow dr in doc.Rows)
           { %>
           <tr>
           <%
             
             for (int i = 0; i < cols; i++)
            {%> 
                    <td><div align="left"><%=dr[i].ToString()%></div></td>
                        
        <% } %> 
        </tr>
      <%} %>  


</table>
      
        
        </td>
    </tr>
     </table>

                            <%}
%>
                            
                            
                            
</form>
</body>
</html>
