var summaryViewModel = (function () {
    function summaryViewModel($scope, subscriptionWebService) {
        this.test = "scdeeed";
        $scope.controller = this;
        this.scope = $scope;
        // this.indexController = $scope.indexController;
        this.viewCallerController = $scope.viewSTController;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.screenMode = SCREEN_MODE;
        this.initialize();
    }
    summaryViewModel.prototype.registerValidations = function () {
        var self = this;
    };
    summaryViewModel.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        console.log(self.viewCallerController);
        console.log(self.callerController);
        console.log(1);
        if (self.callerController !== undefined) {
            self.callerController.registerChildController(this);
            console.log(2);
        }
        if (self.viewCallerController !== undefined) {
            self.viewCallerController.registerChildController(this);
            console.log(3);
        }
        console.log(self.transaction);
    };
    Object.defineProperty(summaryViewModel.prototype, "frequency", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.screenModeManager.entity.frequency;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(summaryViewModel.prototype, "selectedCustomer", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.screenModeManager.entity.transaction.customer;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(summaryViewModel.prototype, "transactionDetails", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.screenModeManager.entity.transaction.transactionDetails;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(summaryViewModel.prototype, "currentMode", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.screenModeManager.currentMode;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(summaryViewModel.prototype, "transaction", {
        get: function () {
            if (this.viewCallerController !== undefined)
                return this.viewCallerController.screenModeManager.entity.transaction;
            else {
                return this.callerController.screenModeManager.entity.transaction;
            }
        },
        enumerable: true,
        configurable: true
    });
    summaryViewModel.prototype.totalTransactionAmount = function () {
        var self = this;
        if (self.callerController !== undefined)
            return self.callerController.screenModeManager.entity.totalTransactionAmount();
    };
    summaryViewModel.prototype.initializeParentVariables = function (scheduleTransactionController) {
        var self = this;
        console.log(scheduleTransactionController);
    };
    summaryViewModel.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new customerListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdCustomer";
        self.paging.sortColumn = "idCustomer";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    summaryViewModel.prototype.removeTransactionDetail = function (transactionDetail) {
        var self = this;
        self.transactionDetails.splice(self.transactionDetails.indexOf(transactionDetail), 1);
    };
    summaryViewModel.prototype.generateSummaryText = function () {
        var self = this;
        if (self.frequency !== undefined) {
            switch (self.frequency.frequency) {
                case 1:
                    return "Occurs Once Off on " + dateParser.dateParserScreenMode(null, self.frequency.startDate);
                case 2:
                    //Occurs day 28 of every 1 month(s) effective 28/01/2021 until 28/06/2022 from 12:00 to 12:30
                    return "Occurs Daily effective " + dateParser.dateParserScreenMode(null, self.frequency.startDate) + " until " + dateParser.dateParserScreenMode(null, self.frequency.endDate);
                case 3:
                    //return "Occurs day " + self.frequency.weeklyDays + " of every " + self.frequency.recur + " Week effective " + self.frequency.startDate.toLocaleString() + " until " + self.frequency.endDate.toLocaleString();
                    return "Occurs every " + self.frequency.recurEvery + " Week effective " + dateParser.dateParserScreenMode(null, self.frequency.startDate) + " until " + dateParser.dateParserScreenMode(null, self.frequency.endDate);
                case 4:
                    return "Occurs day " + self.frequency.monthlyDays + " of every " + self.frequency.recurEvery + " Month(s) effective " + dateParser.dateParserScreenMode(null, self.frequency.startDate) + " until " + dateParser.dateParserScreenMode(null, self.frequency.endDate);
            }
        }
    };
    return summaryViewModel;
}());
summaryModule.controller("summaryController", ["$scope",
    "subscriptionWebService",
    summaryController
]);
//# sourceMappingURL=summary-view-model.js.map