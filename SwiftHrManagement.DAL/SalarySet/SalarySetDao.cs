using System;
using System.Data;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.SalarySet
{
    public class SalarySetDao:BaseDAO
    {
        public DataTable OnSaveUpdateMaster(string salaryMasterId,string salaryTitle,string description,string grades,string user)
        {
            var sql = "Exec [proc_salarySet] @flag = " + (salaryMasterId == "0" ? "'i'" : "'u'");
            sql += ", @salarySetMasterId = " + filterstring(salaryMasterId);
            sql += ", @salaryTitle = " + filterstring(salaryTitle);
            sql += ", @description=" + filterstring(description);
            sql += ", @grades=" + filterstring(grades);
            sql += ", @user=" + filterstring(user);
           return ReturnDataset(sql).Tables[0];
        }

        public DataTable OnSaveUpdate(string salaryMasterId, string payableHead, string payableValue, string valuefor, string user)
        {
            var sql = "Exec [proc_salarySet] @flag ="+ "'ii'";
            sql += ", @salarySetMasterId = " + filterstring(salaryMasterId);
            sql += ", @payableHead=" + filterstring(payableHead);
            sql += ", @payableValue=" + filterstring(payableValue);
            sql += ", @valuefor=" + filterstring(valuefor);
            sql += ", @user=" + filterstring(user);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable OnSaveUpdateGrade(string salaryMasterId, string gradeFrom, string gradeTo, string amount, string user, long grade)  
        {
            var sql = "Exec [proc_salarySet] @flag =" + "'ig'";
            sql += ", @salarySetMasterId = " + filterstring(salaryMasterId);
            sql += ", @gradeFrom=" + filterstring(gradeFrom);
            sql += ", @gradeTo=" + filterstring(gradeTo);
            sql += ", @amount=" + filterstring(amount);
            sql += ", @user=" + filterstring(user);
            sql += ", @grades=" + grade;
            return ReturnDataset(sql).Tables[0];
        }
         
        public  DataTable FindSalarySetById(long masterId)
        {
            var sql = "SELECT Salary_Title,Desccription,No_of_Grades FROM salarySetMaster WHERE salarySetMasterId =" + masterId + " ";
            return ReturnDataset(sql).Tables[0];
        }

        public  string  OnDeleteMaster(long masterId)
        {
            var sql = "DELETE salarySetMaster WHERE salarySetMasterId ="+masterId+" ";
            return GetSingleresult(sql);
        }

        public  DataTable FindSalaryDeatilsById(long masterId)
        {
            var sql = "SELECT salaryDetailId,s.DETAIL_TITLE [Payable Head],dbo.ShowDecimal(payableValue) [Payable Value],case when value_for='A' then 'Assignment' else 'Limit Check' end as [Value For] FROM salarySetDetails sd"
              +" inner join StaticDataDetail s on sd.payableHead = s.ROWID where sd.salarySetMasterId =" + masterId + " ";
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable FindGradeDeatilsById(long masterId) 
        {
            var sql = "select id,grade [Grade],dbo.ShowDecimal(amount) [Amount] from Grade_Setup where salary_set_id =" + masterId + " ";
            return ReturnDataset(sql).Tables[0];
        }

        public string Ondelete(long  rowId)
        {
            var sql = "delete salarySetDetails where salaryDetailId  =" + rowId + " ";
            return GetSingleresult(sql);
        }

        public string OndeleteGrade(long rowId) 
        {
            var sql = "delete Grade_Setup where id  =" + rowId + " ";
            return GetSingleresult(sql);
        }

        public DataTable OnSaveUpdateGratuity(string fromYear,string toYear, string rate, string user)  
        {
            var sql = "Exec [proc_gratuity] @flag =" + "'i'";
            sql += ", @fromYear = " + filterstring(fromYear);
            sql += ", @toYear=" + filterstring(toYear);
            sql += ", @rate=" + filterstring(rate);
            //sql += ", @rateOn=" + filterstring(rateOn);
            sql += ", @user=" + filterstring(user);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable OnSaveGratuityMaster(string startDate, string calculateOn, string startYear, string endyear,string user)
        {
            var sql = "Exec [proc_GratuityMasterSetup] @flag =" + "'i'";
            sql += ", @startFrom = " + filterstring(startDate);
            sql += ", @calculateOn = " + filterstring(calculateOn);
            sql += ", @startYear = " + filterstring(startYear);
            sql += ", @endYear = " + filterstring(endyear);
            sql += ", @user =" + filterstring(user);
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable FindGratuityDeatilsById(long id) 
        {
            var sql = "SELECT id,start_year,end_year,rate FROM GratuitySetup WHERE id =" + id + " ";
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable FindGratuityMasterDetails(long Id)
        {
            var sql = "SELECT Id,Start_From,Calculate_On,Start_Year,End_Year FROM GratuityMaster_Setup WHERE Id =" + Id + " ";
            return ReturnDataset(sql).Tables[0];
        }

        public string OndeleteGratuity(long rowId)
        {
            var sql = "delete GratuitySetup where id  =" + rowId + " ";
            return GetSingleresult(sql);
        }

        public DataTable FindGradeAmount(string newSalarySet, string grade) 
        {
            var sql = "Exec [Proc_SalaryAssignment] @flag =" + "'g'";
            sql += ", @new_Salary_set = " + filterstring(newSalarySet);
            sql += ",@grade=" + filterstring(grade);

            return ReturnDataset(sql).Tables[0];
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
