
var app = angular.module("VoucherModule", ['angularUtils.directives.dirPagination']);

app.config(function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
});