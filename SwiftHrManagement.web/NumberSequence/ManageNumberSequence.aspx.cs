using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.DomainInv;
using SwiftHrManagement.DAL.NumberSequence;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.NumberSequence
{
    public partial class ManageNumberSequence :BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        NumberSequenceCore _nSeqCore = null;
        NumberSequenceDAO _nSeqDao = null;

        public ManageNumberSequence()
        {
            _nSeqCore = new NumberSequenceCore();
            _nSeqDao = new NumberSequenceDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 125) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateSeparatorDDLs();
                PopulateNumberSequenceDetails();
            }
        }

        private void PopulateNumberSequenceDetails()
        {
            _nSeqCore = _nSeqDao.GetNumberSequennceDetails();

            if (_nSeqDao != null)
            {
                GetCheckBoxStatus(ChkCompShortCode, _nSeqCore.IsCompShortCode);
                GetCheckBoxStatus(ChkUseCompShortCodeSep, _nSeqCore.IsCompSep);
                CmbCompShortCodeSep.Text = _nSeqCore.CompSeparator;
                GetCheckBoxStatus(ChkBranchShortCode, _nSeqCore.IsBranchCode);
                GetCheckBoxStatus(ChkUseBranchShortCodeSep, _nSeqCore.IsBranchSep);
                CmbBranchShortCodeSep.Text = _nSeqCore.BranchSeparator;
                GetCheckBoxStatus(ChkAssetShortCode, _nSeqCore.IsAssetCode);
                GetCheckBoxStatus(ChkUseAssetShortCodeSep, _nSeqCore.IsAssetCodeSep); 
                CmbAssetShortCodeSep.Text = _nSeqCore.AssetSeparator;
                TxtSequence.Text = _nSeqCore.NumSequence;                
                GetCheckBoxStatus(ChkUseSequenceSep, _nSeqCore.IsSequenceSep);
                GetCheckBoxStatus(ChkDateCode, _nSeqCore.IsDateCode);
                CmbDateFormat.Text = _nSeqCore.SeqDateFormat; 
            }

        }
        
        private void GetCheckBoxStatus(CheckBox chk,string checkStr)
        {
            if (checkStr.ToUpper() == "Y")
                chk.Checked = true;
            else
                chk.Checked = false;
        }


        private void PopulateSeparatorDDLs()
        {
            CmbDateFormat.Items.Add("YY");
            CmbDateFormat.Items.Add("YYYY");
            CmbDateFormat.Items.Add("YYMM");
            CmbDateFormat.Items.Add("YYMMDD");
            CmbDateFormat.Items.Add("YYYYMMDD");
            
            LoadSepartatorDDL(CmbSequenceSep);
            LoadSepartatorDDL(CmbCompShortCodeSep);
            LoadSepartatorDDL(CmbBranchShortCodeSep);
            LoadSepartatorDDL(CmbAssetShortCodeSep);
        }

        private void LoadSepartatorDDL(DropDownList ddl)
        {
            ddl.Items.Add("-");
            ddl.Items.Add("/");
        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            PreapareNumberSequence();
        }

        private void PreapareNumberSequence()
        {
            _nSeqCore.SeqDateFormat = CmbDateFormat.Text;
            _nSeqCore.NumSequence = TxtSequence.Text;
            _nSeqCore.IsSequenceSep = GetSelectedOptionFromCheckBox(ChkUseSequenceSep);
            _nSeqCore.SequenceSep = CmbSequenceSep.Text;
            _nSeqCore.IsCompShortCode = GetSelectedOptionFromCheckBox(ChkCompShortCode);
            _nSeqCore.IsCompSep = GetSelectedOptionFromCheckBox(ChkUseCompShortCodeSep);
            _nSeqCore.CompSeparator = CmbCompShortCodeSep.Text;
            _nSeqCore.IsBranchCode = GetSelectedOptionFromCheckBox(ChkBranchShortCode);
            _nSeqCore.IsBranchSep = GetSelectedOptionFromCheckBox(ChkUseBranchShortCodeSep);
            _nSeqCore.BranchSeparator = CmbBranchShortCodeSep.Text;
            _nSeqCore.IsAssetCode = GetSelectedOptionFromCheckBox(ChkAssetShortCode);
            _nSeqCore.IsAssetCodeSep = GetSelectedOptionFromCheckBox(ChkUseAssetShortCodeSep);
            _nSeqCore.AssetSeparator = CmbAssetShortCodeSep.Text;
            _nSeqCore.IsDateCode = GetSelectedOptionFromCheckBox(ChkDateCode);
            _nSeqCore.ActEmpID = Convert.ToInt16(ReadSession().Emp_Id);
            _nSeqDao.Save(_nSeqCore);
        }

        private string GetSelectedOptionFromCheckBox(CheckBox chk)
        {
            if (chk.Checked == true)
                return "Y";
            else
                return "N";            
        }
  
    }
}
