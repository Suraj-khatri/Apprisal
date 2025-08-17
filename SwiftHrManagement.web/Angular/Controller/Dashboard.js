// Defining angularjs Controller and injecting CustomersService


app.controller('DashBoardCtrl', function ($scope, $http, Journal, filterFilter) {
    $scope.JdtoAssignList = null;
    $scope.PRforReviewer = null;
    $scope.PAforReviewer = null;
    $scope.PRforCommitee = null;
    $scope.JDforApprove = null;
    $scope.PAtoinitiate = null;
    $scope.PRtoInitiate = null;
    $scope.IsSupervisor = false;
    $scope.IsReviewer = false;
    $scope.IsComeetee = false;

    Journal.JdToAssign().then(function (d) {
        $scope.JdtoAssignList = d.data;
        if (d.data.length>0) {
            $scope.IsSupervisor = true;
        }
        
    }, function () {

    });

    Journal.ReviewerPendingTask('PR').then(function (d) {
        
        $scope.PRforReviewer = d.data;
        if (d.data.length>0) {
            $scope.IsReviewer = true;
        }

    }, function () {

    });
    Journal.ReviewerPendingTask('PA').then(function (d) {
        $scope.PAforReviewer = d.data;
        if (d.data.length>0) {
            $scope.IsReviewer = true;
        }
    }, function () {

    });
    Journal.CommiteePendingTask().then(function (d) {
        $scope.PRforCommitee = d.data;
        if (d.data.length>0) {
            $scope.IsComeetee = true;
        }

    }, function () {

    });
});
