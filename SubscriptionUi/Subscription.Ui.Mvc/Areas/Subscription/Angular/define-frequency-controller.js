var defineFrequencyController = /** @class */ (function () {
    function defineFrequencyController($scope, $parse, toaster, subscriptionWebService) {
        this.$parse = $parse;
        this.toaster = toaster;
        this.months = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"];
        this.dates = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
        this.every = ["First", "Second", "Third", "Fourth", "Last"];
        this.days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
        this.frequencies = [{ id: 2, description: 'Daily' }, { id: 3, description: 'Weekly' }, { id: 4, description: 'Monthly' }];
        this.daysInWeekSelected = [1, 2];
        this.weeklyDays = [];
        this.selectedDays = [];
        this.weekOccursOnDaysBool = [false, false, false, false, false, false, false];
        this.monthsBool = [false, false, false, false, false, false, false, false, false, false, false, false];
        this.datesOccursOnMonthsBool = [false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false];
        this.everyOccursOnMonthsBool = [false, false, false, false, false];
        this.dayOccursOnMonthsBool = [false, false, false, false, false, false, false];
        this.selectedDaysOrEveryForMonthlyFrequencyBool = [true, false];
        this.selectedMonths = [];
        this.selectedDatesForMonthlyFrequency = [];
        this.selectedDaysForMonthlyFrequency = [];
        this.selectedEveryForMonthlyFrequency = [];
        this.selectedDaysOrEveryForMonthlyFrequency = [];
        //groupName: string = selectCustomerTabNameFromEnum.getName(subscriptionTab.FREQUENCY);
        this.groupName = Menu.DEFINE_FREQUENCY;
        $scope.controller = this;
        this.scope = $scope;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.screenMode = SCREEN_MODE;
        this.initialize();
    }
    defineFrequencyController.prototype.initialize = function () {
        var self = this;
        self.moment = self.baseController.moment;
        self.callerController.registerDefineFrequencyController(this);
        self.frequency.frequency = 2;
    };
    defineFrequencyController.prototype.registerValidation = function () {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        //  self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        //  self.formValidator.registerValidationForMandatory(self.scope, 'frequency', 'Choose Frequency');
        //self.formValidator.registerValidation('frequency', 'Choose Frequency', function () {
        //    return self.frequency.frequency < 0
        //});
        //  self.formValidator.registerValidationForMandatory(self.scope, 'startDate', 'Start Date/ Time');
        //  self.formValidator.registerValidationForMandatory(self.scope, 'recurEvery', 'Choose Recur');
        //  self.formValidator.registerValidationForMandatory(self.scope, 'endDate', 'End Date/ Time');
        //  self.formValidator.registerGroupValidation(self.groupName.toString(), []) //'endDate' TO ADD BACK AFTER DEMO 'frequency', 'startDate', 'endDate', 'recurEvery'
    };
    defineFrequencyController.prototype.validateForGroup = function () {
        var self = this;
        var isValid = true;
        var formScope = self.scope[self.formName];
        var errorMessages = [];
        //isValid = isValid && self.formValidator.validateGroup(self.groupName.toString(), false, true);
        isValid = true; //to remove
        //errorMessages = errorMessages.concat(self.formValidator.getAllValidationMessagesForGroup(self.groupName.toString()));
        errorMessages = [];
        if (errorMessages.length > 0) {
            self.baseController.showMessage(errorMessages.join('\n'), 'ERROR', ALERT_MESSAGE_TYPE.ERROR);
        }
        return isValid;
    };
    Object.defineProperty(defineFrequencyController.prototype, "selectedCustomer", {
        get: function () {
            return this.callerController.selectedCustomer;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(defineFrequencyController.prototype, "frequency", {
        get: function () {
            return this.callerController.frequency;
        },
        set: function (frequency) {
            this.callerController.frequency = frequency;
        },
        enumerable: false,
        configurable: true
    });
    defineFrequencyController.prototype.isDaySelectedForWeeklyFrequency = function (day) {
        var self = this;
        self.weekOccursOnDaysBool[self.days.indexOf(day)] = !self.weekOccursOnDaysBool[self.days.indexOf(day)];
        if (self.weekOccursOnDaysBool[self.days.indexOf(day)] == true) {
            self.weeklyDays.push((self.days.indexOf(day) + 1));
        }
        else {
            self.weeklyDays.splice(self.weeklyDays.indexOf(self.days[day]), 1);
        }
        self.frequency.weeklyDaysSelected = JSON.parse(JSON.stringify(self.weeklyDays.toString()));
    };
    defineFrequencyController.prototype.isMonthSelectedForMonthlyFrequency = function (month) {
        var self = this;
        self.monthsBool[self.months.indexOf(month)] = !self.monthsBool[self.months.indexOf(month)];
        if (self.monthsBool[self.months.indexOf(month)] == true) {
            self.selectedMonths.push((self.months.indexOf(month) + 1));
        }
        else {
            self.selectedMonths.splice(self.selectedMonths.indexOf(self.months[month]), 1);
        }
        self.frequency.selectedMonths = JSON.parse(JSON.stringify(self.selectedMonths.toString()));
    };
    defineFrequencyController.prototype.isDateSelectedForMonthlyFrequency = function (date) {
        var self = this;
        self.datesOccursOnMonthsBool[self.dates.indexOf(parseInt(date))] = !self.datesOccursOnMonthsBool[self.dates.indexOf(parseInt(date))];
        if (self.datesOccursOnMonthsBool[self.dates.indexOf(parseInt(date))] == true) {
            self.selectedDatesForMonthlyFrequency.push((self.dates.indexOf(parseInt(date)) + 1));
        }
        else {
            self.selectedDatesForMonthlyFrequency.splice(self.selectedDatesForMonthlyFrequency.indexOf(self.dates[date]), 1);
        }
        self.frequency.selectedmonthlyDates = JSON.parse(JSON.stringify(self.selectedDatesForMonthlyFrequency.toString()));
    };
    defineFrequencyController.prototype.isEverySelectedForMonthlyFrequency = function (every) {
        var self = this;
        self.everyOccursOnMonthsBool[self.every.indexOf(every)] = !self.everyOccursOnMonthsBool[self.every.indexOf(every)];
        if (self.everyOccursOnMonthsBool[self.every.indexOf(every)] == true) {
            self.selectedEveryForMonthlyFrequency.push((self.every.indexOf(every) + 1));
        }
        else {
            self.selectedEveryForMonthlyFrequency.splice(self.selectedEveryForMonthlyFrequency.indexOf(self.every[every]), 1);
        }
        self.frequency.selectedMonthlyEvery = JSON.parse(JSON.stringify(self.selectedEveryForMonthlyFrequency.toString()));
    };
    defineFrequencyController.prototype.isDaySelectedForMonthlyFrequency = function (day) {
        var self = this;
        self.dayOccursOnMonthsBool[self.days.indexOf(day)] = !self.dayOccursOnMonthsBool[self.days.indexOf(day)];
        if (self.dayOccursOnMonthsBool[self.days.indexOf(day)] == true) {
            self.selectedDaysForMonthlyFrequency.push((self.days.indexOf(day) + 1));
        }
        else {
            self.selectedDaysForMonthlyFrequency.splice(self.selectedDaysForMonthlyFrequency.indexOf(self.days[day]), 1);
        }
        self.frequency.selectedMonthlyDays = JSON.parse(JSON.stringify(self.selectedDaysForMonthlyFrequency.toString()));
    };
    defineFrequencyController.prototype.isDaysOrEverySelectedForMonthlyFrequency = function (index) {
        var self = this;
        self.selectedDaysOrEveryForMonthlyFrequencyBool[index] = !self.selectedDaysOrEveryForMonthlyFrequencyBool[index];
        if (self.selectedDaysOrEveryForMonthlyFrequencyBool[index] == true) {
            self.selectedDaysOrEveryForMonthlyFrequency.push((index + 1));
        }
        else {
            self.selectedDaysOrEveryForMonthlyFrequency.splice(self.selectedDaysOrEveryForMonthlyFrequency.indexOf(index), 1);
        }
        self.frequency.isEverySelected = JSON.parse(JSON.stringify(self.selectedDaysOrEveryForMonthlyFrequency.toString()));
    };
    defineFrequencyController.prototype.checkIfItemShouldBeChecked = function (day) {
        var self = this;
        console.log("mana: " + self.frequency.weeklyDaysSelectedFromServer.indexOf(day));
        return self.frequency.weeklyDaysSelectedFromServer.indexOf(day) > -1;
    };
    defineFrequencyController.prototype.convertListToJSON = function () {
        console.log(JSON.stringify(this.dates.toString()));
    };
    return defineFrequencyController;
}());
var defineFrequencyModel = /** @class */ (function () {
    function defineFrequencyModel() {
        this.endDate = null;
        this.weeklyDaysSelectedFromServer = [false, false, false, false, false, false, false];
        this.selectedMonthsFromServer = [false, false, false, false, false, false, false, false, false, false, false, false];
        this.selectedMonthlyDatesFromServer = [false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false];
        this.selectedMonthlyEveryFromServer = [false, false, false, false, false];
        this.selectedMonthlyDaysFromServer = [false, false, false, false, false, false, false];
        this.selectedDaysOrEveryForMonthlyFrequencyFromServer = [false, false];
    }
    return defineFrequencyModel;
}());
defineFrequencyModule.controller("defineFrequencyController", ["$scope",
    "subscriptionWebService",
    defineFrequencyController
]);
//# sourceMappingURL=define-frequency-controller.js.map