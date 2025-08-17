using System.Data;
using SwiftHrManagement.DAL.Report;

namespace SwiftHrManagement.web
{
    public class ReportDao : clsDAO
    {
        public ReportResult GetMedicalClaimReport(string user, string fromDate, string toDate, string claimType, string claimStatus)
        {
            string sql = "EXEC procMedicalClaim @flag = 'report'";
            sql += ", @user = " + FilterString(user);
            sql += ", @fromDate = " + FilterString(fromDate);
            sql += ", @toDate = " + FilterString(toDate);
            sql += ", @claimType = " + FilterString(claimType);
            sql += ", @claimStatus = " + FilterString(claimStatus);
            return ParseReportResult(sql);
        }
        public ReportResult GetFaDetail(string user, string branchId, string deptId, string groupId, string assetType,
                string assetNumber, string pageNumber, string pageSize)
        {
            string sql = "EXEC procAssetReport @flag = 'detail'";
            sql += ", @user = " + FilterString(user);
            sql += ", @branchId = " + FilterString(branchId);
            sql += ", @deptId = " + FilterString(deptId);
            sql += ", @groupId = " + FilterString(groupId);
            sql += ", @assetType = " + FilterString(assetType);
            sql += ", @assetNumber = " + FilterString(assetNumber);
            sql += ", @pageNumber = " + FilterString(pageNumber);
            sql += ", @pageSize = " + FilterString(pageSize);
            return ParseReportResult(sql);
        }
        public ReportResult GetFaSummary(string user, string branchId, string rptType)
        {
            string sql = "EXEC procAssetReport @flag = 'fa_summary'";
            sql += ", @user = " + FilterString(user);
            sql += ", @branchId = " + FilterString(branchId);
            sql += ", @rptType = " + FilterString(rptType);
            return ParseReportResult(sql);
        }

        public ReportResult GetFaDepDetailRpt(string user, string branchId, string fy, string month)
        {
            string sql = "EXEC procAssetReport @flag = 'dep_detail_rpt'";
            sql += ", @user = " + FilterString(user);
            sql += ", @branchId = " + FilterString(branchId);
            sql += ", @fy = " + FilterString(fy);
            sql += ", @month = " + FilterString(month);
            return ParseReportResult(sql);
        }

        public ReportResult GetFaDepGroupWiseRpt(string user, string branchId, string fy, string month)
        {
            string sql = "EXEC procAssetReport @flag = 'dep_groupwise_rpt'";
            sql += ", @user = " + FilterString(user);
            sql += ", @branchId = " + FilterString(branchId);
            sql += ", @fy = " + FilterString(fy);
            sql += ", @month = " + FilterString(month);
            return ParseReportResult(sql);
        }

        public ReportResult GetFaDepSummaryRpt(string user, string branchId, string fy, string month)
        {
            string sql = "EXEC procAssetReport @flag = 'dep_summary'";
            sql += ", @user = " + FilterString(user);
            sql += ", @branchId = " + FilterString(branchId);
            sql += ", @fy = " + FilterString(fy);
            sql += ", @month = " + FilterString(month);
            return ParseReportResult(sql);
        }

        public ReportResult GetDatewiseFaRpt(string user, string fromDate, string toDate, string branch, string group, string assetType, string rptType,
               string pageNumber, string pageSize)
        {
            string sql = "EXEC proc_faReport @flag = 'grpwise'";
            sql += ", @user = " + FilterString(user);
            sql += ", @fromDate = " + FilterString(fromDate);
            sql += ", @toDate = " + FilterString(toDate);
            sql += ", @branchId = " + FilterString(branch);
            sql += ", @groupId = " + FilterString(group);
            sql += ", @assetId = " + FilterString(assetType);
            sql += ", @rptType = " + FilterString(rptType);
            sql += ", @pageNumber = " + FilterString(pageNumber);
            sql += ", @pageSize = " + FilterString(pageSize);
            return ParseReportResult(sql);
        }
        public ReportResult GrpWiseFaRpt(string user, string fromDate, string toDate, string branchId, string groupId, string pageNumber, string pageSize)
        {
            string sql = "EXEC proc_faReport @flag = 'group-wise'";
            sql += ", @user = " + FilterString(user);
            sql += ", @fromDate = " + FilterString(fromDate);
            sql += ", @toDate = " + FilterString(toDate);
            sql += ", @branchId = " + FilterString(branchId);
            sql += ", @groupId = " + FilterString(groupId);
            sql += ", @pageNumber = " + FilterString(pageNumber);
            sql += ", @pageSize = " + FilterString(pageSize);
            return ParseReportResult(sql);
        }

        public ReportResult GetMDSDetailRpt(string user, string fromDate, string toDate, string fromBranch, string toBranch)
        {
            string sql = "EXEC [proc_mdsInventoryRpt] @flag = 'mds'";
            sql += ", @user = " + FilterString(user);
            sql += ", @fromDate = " + FilterString(fromDate);
            sql += ", @toDate = " + FilterString(toDate);
            sql += ", @fromBranch = " + FilterString(fromBranch);
            sql += ", @toBranch = " + FilterString(toBranch);
            return ParseReportResult(sql);
        }

        public DataSet GetIndividualAssetDetailRpt(string assetNOType, string assetNo)
        {
            string sql = "EXEC [proc_IndividualDetailedAssetReport] @flag = 'a'";
            sql += ", @assetNoType = " + FilterString(assetNOType);
            sql += ", @assetNo = " + FilterString(assetNo);
            return ExecuteDataset(sql);
        }
    }
}