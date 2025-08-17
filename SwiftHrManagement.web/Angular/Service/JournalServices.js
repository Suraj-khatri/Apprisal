app.factory("Journal", function ($http) {

    return {

        AppriseeAgreementList: function () {
            return $http.get("/Autocomplete.asmx/PerformanceAgreement");
        },
        FiscalYearList: function () {
            
            return $http.get("/Autocomplete.asmx/FiscalList");
        },
        StatusList: function (status) {

            return $http.get("/Autocomplete.asmx/ApprisalStatusList?id=" + status);
        },
        FilterList: function (fiscalId, Empid, Ststus) {
            
            return $http.get("/Autocomplete.asmx/FilterAgreement?Fiscal=" + fiscalId + "&Emp=" + 0 + "&Status=" + Ststus);
        },
        AppriseeReviewList: function () {
            return $http.get("/Autocomplete.asmx/PerformanceReview");
        },
        FilterReviewList: function (fiscalId, Empid, Ststus) {
            
            return $http.get("/Autocomplete.asmx/FilterReview?Fiscal=" + fiscalId + "&Emp=" + Empid + "&Status=" + Ststus);
        },
        JodDescList: function (status) {
            return $http.get("/Autocomplete.asmx/JobDescription?ststus="+status);
        },
        FilterJodDescList: function (fiscalId, Empid, Ststus) {
            
            return $http.get("/Autocomplete.asmx/FilterJobDescription?status=" + Ststus + "&fiscal=" + fiscalId + "&EmpId=" + Empid );
        },
        AdminJDList: function () {

            return $http.get("/Autocomplete.asmx/AdminJdList");
        },

        ReviewinitiationcList: function () {
            return $http.get("/Autocomplete.asmx/ReviewInitiation");
        },
       FilterReviewinitiationcList: function (fiscalId, Empid) {
            return $http.get("/Autocomplete.asmx/FilterReviewInitiation?Fiscal=" + fiscalId + "&Emp=" + Empid);
       },
       JdToAssign: function () {
           return $http.get("/Autocomplete.asmx/JdToAssignList");
       },
       ReviewerPendingTask: function (status) {
           return $http.get("/Autocomplete.asmx/PendingTaskReview?status=" + status);
       },
       CommiteePendingTask: function (status) {
           return $http.get("/Autocomplete.asmx/CommiteePendingTask");
       },
        IsHrAdmin: function ()
        {
            return $http.get("/Autocomplete.asmx/ISHrAdmin");
       },
       DiscarsApp: function (appid,flag) {
           return $http.get("/Autocomplete.asmx/DiscardAppraisal?appid=" + appid+"&flag="+flag);
       },
       Emplist: function (flag)
       {

           return $http.get("/Autocomplete.asmx/ApprsaemplistEmpList?flag=" + flag);
       },
       AppraisalList: function (Id, EmpId, SuvId, RevId) {
           debugger
           return $http.get("/Autocomplete.asmx/AppraisalListTochange?Id=" + Id + "&EmpId=" + EmpId + "&SuvId=" + SuvId + "&RevId=" + RevId);
       },
       UpdateSupervisor: function (old, newsuv, appid, Ok, flag) {
           return $http.get("/Autocomplete.asmx/UpdateSupervisor?old=" + old + "&newsuv=" + newsuv + "&appid=" + appid + "&Ok=" + Ok + "&flag=" + flag);
       },
       DepartmentBranch: function (flag, branchId) {
           
           return $http.get("/Autocomplete.asmx/BranchDeptPosList?flag=" + flag + "&BranchId=" + branchId);
       },
       AppInfo: function (appid) {
           return $http.get("/Autocomplete.asmx/InfoToUPdate?appid=" + appid);
       },
      
       
    }


});