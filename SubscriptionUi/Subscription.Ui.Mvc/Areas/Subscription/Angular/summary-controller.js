var summaryController = /** @class */ (function () {
    function summaryController($scope, subscriptionWebService) {
        $scope.controller = this;
        this.scope = $scope;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.screenMode = SCREEN_MODE;
        this.initialize();
    }
    summaryController.prototype.initialize = function () {
        var self = this;
        self.callerController.registerSummaryController(this);
        console.log(self.callerController);
        self.mode = SCREEN_MODE;
    };
    Object.defineProperty(summaryController.prototype, "frequency", {
        get: function () {
            if (this.callerController !== undefined) {
                return this.callerController.frequency;
            }
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(summaryController.prototype, "selectedCustomer", {
        get: function () {
            if (this.callerController !== undefined) {
                return this.callerController.transaction.customer;
            }
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(summaryController.prototype, "customerAddress", {
        get: function () {
            var self = this;
            var address = "";
            if (!self.baseController.isNullOrUndefined(self.callerController.transaction.customer)
                && !self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person)
                && !self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person.person_Address)
                && self.callerController.transaction.customer.person.person_Address.length > 0
                && !self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person.person_Address[0].address)) {
                var address = self.selectedCustomer.person.person_Address[0].address.addressLine1;
                if (!self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person.person_Address[0].address.city)) {
                    address += ", " + self.selectedCustomer.person.person_Address[0].address.city;
                }
            }
            return address;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(summaryController.prototype, "transactionDetails", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.transaction.transactionDetails;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(summaryController.prototype, "currentMode", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(summaryController.prototype, "transaction", {
        get: function () {
            if (this.callerController !== undefined)
                return this.callerController.transaction;
        },
        enumerable: false,
        configurable: true
    });
    summaryController.prototype.totalTransactionAmount = function () {
        var self = this;
        if (self.callerController !== undefined)
            return self.callerController.totalTransactionAmount();
    };
    summaryController.prototype.initializeParentVariables = function (scheduleTransactionController) {
        var self = this;
        console.log(scheduleTransactionController);
    };
    summaryController.prototype.removeTransactionDetail = function (transactionDetail) {
        var self = this;
        self.transactionDetails.splice(self.transactionDetails.indexOf(transactionDetail), 1);
    };
    summaryController.prototype.isTransactionScheduled = function () {
        var self = this;
        if (self.transaction.idTransactionType == 2) {
            return false;
        }
        return true;
    };
    summaryController.prototype.generateSummaryText = function () {
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
                    return "Occurs day " + self.frequency.selectedmonthlyDates + " of every " + self.getMonthNames(self.frequency.selectedMonths) + " effective " + dateParser.dateParserScreenMode(null, self.frequency.startDate) + " until " + dateParser.dateParserScreenMode(null, self.frequency.endDate);
            }
        }
    };
    summaryController.prototype.getMonthNames = function (names) {
        var listOfMonthIndexes = names.split(',');
        var nameOfMonthsToReturn = [];
        listOfMonthIndexes.forEach(function (month) {
            switch (month) {
                case '1':
                    nameOfMonthsToReturn.push('January');
                    break;
                case '2':
                    nameOfMonthsToReturn.push('February');
                    break;
                case '3':
                    nameOfMonthsToReturn.push('March');
                    break;
                case '4':
                    nameOfMonthsToReturn.push('April');
                    break;
                case '5':
                    nameOfMonthsToReturn.push('May');
                    break;
                case '6':
                    nameOfMonthsToReturn.push('June');
                    break;
                case '7':
                    nameOfMonthsToReturn.push('July');
                    break;
                case '8':
                    nameOfMonthsToReturn.push('August');
                    break;
                case '9':
                    nameOfMonthsToReturn.push('September');
                    break;
                case '10':
                    nameOfMonthsToReturn.push('October');
                    break;
                case '11':
                    nameOfMonthsToReturn.push('November');
                    break;
                case '12':
                    nameOfMonthsToReturn.push('December');
                    break;
            }
        });
        return nameOfMonthsToReturn.toString();
    };
    return summaryController;
}());
summaryModule.controller("summaryController", ["$scope",
    "subscriptionWebService",
    summaryController
]);
//# sourceMappingURL=summary-controller.js.map