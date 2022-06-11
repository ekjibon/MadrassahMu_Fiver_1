class summaryController {
    scope;
    baseController: baseController;
    callerController: ISummaryControllerCaller;
    paging: customerListSortingPagingInfo;
    screenMode: any;
    subscriptionWebService: subscriptionWebService;
    mode;

    constructor($scope
        , subscriptionWebService
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.screenMode = SCREEN_MODE;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.callerController.registerSummaryController(this);
        console.log(self.callerController);
        self.mode = SCREEN_MODE;
    }

    get frequency(): defineFrequencyModel {
        if (this.callerController !== undefined) {
            return this.callerController.frequency;
        }
    }

    get selectedCustomer(): customerModel {
        if (this.callerController !== undefined) {
            return this.callerController.transaction.customer;
        }
    }

    get customerAddress(): string {
        var self = this;
        var address = "";
        if (!self.baseController.isNullOrUndefined(self.callerController.transaction.customer)
            && !self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person)
            && !self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person.person_Address)
            && self.callerController.transaction.customer.person.person_Address.length > 0
            && !self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person.person_Address[0].address)
        ) {
            var address = self.selectedCustomer.person.person_Address[0].address.addressLine1;
            if (!self.baseController.isNullOrUndefined(self.callerController.transaction.customer.person.person_Address[0].address.city)) {
                address += ", " + self.selectedCustomer.person.person_Address[0].address.city;
            }
        }
        return address;
    }

    get transactionDetails(): transactionDetailModel[] {
        if (this.callerController !== undefined)
            return this.callerController.transaction.transactionDetails;
    }

    get currentMode(): SCREEN_MODE {
        if (this.callerController !== undefined)
            return this.callerController.currentMode;
    }

    get transaction(): transactionModel {
        if (this.callerController !== undefined)
            return this.callerController.transaction;
    }

    public totalTransactionAmount(): number {
        var self = this;
        if (self.callerController !== undefined)
            return self.callerController.totalTransactionAmount();
    }

    public initializeParentVariables(scheduleTransactionController) {
        var self = this;
        console.log(scheduleTransactionController);
    }

    public removeTransactionDetail(transactionDetail: transactionDetailModel) {
        var self = this;
        self.transactionDetails.splice(self.transactionDetails.indexOf(transactionDetail), 1);
    }

    public isTransactionScheduled(): boolean {
        var self = this;
        if (self.transaction.idTransactionType == 2) {
            return false;
        }
        return true;
    }

    public generateSummaryText(): string {
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

    }

    public getMonthNames(names: string): string {
        var listOfMonthIndexes = names.split(',');
        var nameOfMonthsToReturn: string[] = [];
        listOfMonthIndexes.forEach((month) => {
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
    }
}

summaryModule.controller("summaryController"
    , ["$scope"
        , "subscriptionWebService"
        , summaryController
    ]);