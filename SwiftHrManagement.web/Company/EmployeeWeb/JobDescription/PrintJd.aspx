<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintJd.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.JobDescription.PrintJd" %>

<!DOCTYPE html>
<style type = "text/css">
    body{
        margin:0px 0px 0px 0px; 
        font-family:Tahoma;         
         color:#000;
         zoom:90%;

    }

.label
{     
    margin-bottom: 0px;
    padding:1px;   
    color:Black;
    font-weight:normal;
    font-size:12px;
    font-family:arial;  
}
  
    .prg{
         white-space: pre-line;
         margin-left:2%;
        
    }
    table {
  border-collapse: collapse;
  font-family:Calibri,'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
}
    table>tr>th,td,
    table>tr>td,th
    {
        padding:10px;
        border:1px solid #070202;
        text-align:left;

    }

    
</style>
<link href="../../../Content/bootstrap.css" rel="stylesheet" />
<head runat="server">
    <title>Print Preview JD</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
          <h3>
              <img src="../../../Content/images/SidLogo.png" class="img-responsive img-rounded text-center" style="height:50px;display: block;margin-left: auto;  margin-right: auto;" alt="Siddhartha Bank Limited"/></h3>  

<h4 style="width:100%"> Job Description Reports</h4>
            <h5 style="width:100%">
                Fiscal Year:<asp:Label ID="lblFiscal" runat="server"></asp:Label>
            </h5>


        </div>
             <table border="1"> 
           <tr>
               <th>Job Holder:</th>
               <td> <asp:Label ID="txtJobHolder" runat="server"></asp:Label>
                  </td>
               <th>Branch:</th>
               <td> <asp:Label ID="lblBranch" runat="server"></asp:Label></td>
               
           </tr>
           <tr>
               <th> Functional Title: </th>
               <td><asp:Label ID="lblFuncTitle" runat="server"></asp:Label></td>
               <th>Corpoerate Title:</th>
               <td><asp:Label ID="lblCorpTitle" runat="server"></asp:Label></td>

           </tr>
           <tr>
               <th>Supervisor Name:</th>
               <td><asp:Label ID="txtSuperVis" runat="server"></asp:Label></td>
               <td  colspan="2">Staffs Reporting : <div class="pull-right" ID="rptDiv" runat="server"></div></td>
           </tr>
           <tr>
               <th>Start Date:</th>
               <td><asp:Label ID="startDate" runat="server"></asp:Label></td>
               <th>End Date:</th>
               <td><asp:Label ID="endDate" runat="server"></asp:Label></td>
           </tr>
           <tr>
               <th colspan="4">Key Competencies:</th>
           </tr>
           <tr>
               <td colspan="4">
                   <p class="prg" ID="txtKeyComp" runat="server">
                       
                   </p>
                  



               </td>
           </tr>
           <tr>
             <th colspan="4">Functional Objectives:</th>  
           </tr>
           <tr>
               <td colspan="4">
                   <p class="prg" ID="txtObj" runat="server">
                     
                   </p>
               </td>
           </tr>
           <tr>
               <th colspan="4">Detail Job Description:</th>
           </tr>
           <tr>
               <td colspan="4">
                   <p class="prg" ID="txtGeneralJd" runat="server">
                               
                   </p>
                  
               </td>
           </tr>
        
            <tr >
                <th >Name Of the Job Holder:
                    <br />
                </th>
                <td >
                      <asp:Label ID="AckJdEmp" runat="server"></asp:Label>
                </td>
                <th >Name Of the Supervisor:
                    <br />
                </th>
                <td >
                          <asp:Label ID="AckJdSuv" runat="server"></asp:Label>
                </td>
            </tr>
            <tr >
                <th >Signature of the Job Holder:<br />


                </th>
                <th >
                    
                </th>
                <th >Signature of the Supervisor:<br />

                </th>
                <th >
               
                </th>
            </tr>
            <tr >
                <th >DATE:<br />

                </th>
                <td >
                      <asp:Label ID="AckdateEmp" runat="server"></asp:Label>
                </td>
                <th >DATE:<br />
                </th>
                <td > 
                    <asp:Label ID="AckdateSuv" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </form>
</body>
