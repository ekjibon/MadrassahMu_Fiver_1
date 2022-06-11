class defineFrequencyController implements ICommonChildControllerCaller {
    scope;
    baseController: baseController;
    callerController: IDefineFrequencyControllerCaller;
    months: string[] = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];
    dates: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
    every: string[] = ["First", "Second", "Third", "Fourth", "Last"];
    days: string[] = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    frequencies = [{ id: 2, description: 'Daily' }, { id: 3, description: 'Weekly' }, { id: 4, description: 'Monthly' }];
    daysInWeekSelected: number[] = [1, 2];
    weeklyDays: number[] = [];
    selectedDays: string[] = [];
    idSelectedFrequency: string;
    screenMode: any;
    subscriptionWebService: subscriptionWebService;
    moment: any;
    weekOccursOnDaysBool: boolean[] = [false, false, false, false, false, false, false];
    monthsBool: boolean[] = [false, false, false, false, false, false, false, false, false, false, false, false];
    datesOccursOnMonthsBool: boolean[] = [false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false];
    everyOccursOnMonthsBool: boolean[] = [false, false, false, false, false];
    dayOccursOnMonthsBool: boolean[] = [false, false, false, false, false, false, false];
    selectedDaysOrEveryForMonthlyFrequencyBool: boolean[] = [true, false];
    selectedMonths: number[] = [];
    selectedDatesForMonthlyFrequency: number[] = [];
    selectedDaysForMonthlyFrequency: number[] = [];
    selectedEveryForMonthlyFrequency: number[] = [];
    selectedDaysOrEveryForMonthlyFrequency: number[] = [];

    formName: string;
    currentMode: SCREEN_MODE;

    formValidator: formValidator;
    //groupName: string = selectCustomerTabNameFromEnum.getName(subscriptionTab.FREQUENCY);
    groupName: Menu = Menu.DEFINE_FREQUENCY;

    constructor($scope
        , private $parse
        , private toaster
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
        self.moment = self.baseController.moment;
        self.callerController.registerDefineFrequencyController(this);
        self.frequency.frequency = 2;
    }

    public registerValidation() {
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

    }

    public validateForGroup(): boolean {
        var self = this;
        var isValid: boolean = true;
        var formScope = self.scope[self.formName];

        var errorMessages: string[] = [];

        //isValid = isValid && self.formValidator.validateGroup(self.groupName.toString(), false, true);
        isValid = true //to remove
        //errorMessages = errorMessages.concat(self.formValidator.getAllValidationMessagesForGroup(self.groupName.toString()));
        errorMessages = [];

        if (errorMessages.length > 0) {
            self.baseController.showMessage(
                errorMessages.join('\n'),
                'ERROR',
                ALERT_MESSAGE_TYPE.ERROR
            );
        }

        return isValid;
    }

    get selectedCustomer(): customerModel {
        return this.callerController.selectedCustomer;
    }

    get frequency(): defineFrequencyModel {
        return this.callerController.frequency;
    }

    set frequency(frequency: defineFrequencyModel) {
        this.callerController.frequency = frequency;
    }

    public isDaySelectedForWeeklyFrequency(day: string) {
        var self = this;
        self.weekOccursOnDaysBool[self.days.indexOf(day)] = !self.weekOccursOnDaysBool[self.days.indexOf(day)];
        if (self.weekOccursOnDaysBool[self.days.indexOf(day)] == true) {
            self.weeklyDays.push((self.days.indexOf(day) + 1));
        } else {
            self.weeklyDays.splice(self.weeklyDays.indexOf(self.days[day]), 1);
        }
        self.frequency.weeklyDaysSelected = JSON.parse(JSON.stringify(self.weeklyDays.toString()));
    }

    public isMonthSelectedForMonthlyFrequency(month: string) {
        var self = this;
        self.monthsBool[self.months.indexOf(month)] = !self.monthsBool[self.months.indexOf(month)];
        if (self.monthsBool[self.months.indexOf(month)] == true) {
            self.selectedMonths.push((self.months.indexOf(month) + 1));
        } else {
            self.selectedMonths.splice(self.selectedMonths.indexOf(self.months[month]), 1);
        }
        self.frequency.selectedMonths = JSON.parse(JSON.stringify(self.selectedMonths.toString()));
    }

    public isDateSelectedForMonthlyFrequency(date: string) {
        var self = this;
        self.datesOccursOnMonthsBool[self.dates.indexOf(parseInt(date))] = !self.datesOccursOnMonthsBool[self.dates.indexOf(parseInt(date))];
        if (self.datesOccursOnMonthsBool[self.dates.indexOf(parseInt(date))] == true) {
            self.selectedDatesForMonthlyFrequency.push((self.dates.indexOf(parseInt(date)) + 1));
        } else {
            self.selectedDatesForMonthlyFrequency.splice(self.selectedDatesForMonthlyFrequency.indexOf(self.dates[date]), 1);
        }
        self.frequency.selectedmonthlyDates = JSON.parse(JSON.stringify(self.selectedDatesForMonthlyFrequency.toString()));
    }

    public isEverySelectedForMonthlyFrequency(every: string) {
        var self = this;
        self.everyOccursOnMonthsBool[self.every.indexOf(every)] = !self.everyOccursOnMonthsBool[self.every.indexOf(every)];
        if (self.everyOccursOnMonthsBool[self.every.indexOf(every)] == true) {
            self.selectedEveryForMonthlyFrequency.push((self.every.indexOf(every) + 1));
        } else {
            self.selectedEveryForMonthlyFrequency.splice(self.selectedEveryForMonthlyFrequency.indexOf(self.every[every]), 1);
        }
        self.frequency.selectedMonthlyEvery = JSON.parse(JSON.stringify(self.selectedEveryForMonthlyFrequency.toString()));
    }

    public isDaySelectedForMonthlyFrequency(day: string) {
        var self = this;
        self.dayOccursOnMonthsBool[self.days.indexOf(day)] = !self.dayOccursOnMonthsBool[self.days.indexOf(day)];
        if (self.dayOccursOnMonthsBool[self.days.indexOf(day)] == true) {
            self.selectedDaysForMonthlyFrequency.push((self.days.indexOf(day) + 1));
        } else {
            self.selectedDaysForMonthlyFrequency.splice(self.selectedDaysForMonthlyFrequency.indexOf(self.days[day]), 1);
        }
        self.frequency.selectedMonthlyDays = JSON.parse(JSON.stringify(self.selectedDaysForMonthlyFrequency.toString()));
    }

    public isDaysOrEverySelectedForMonthlyFrequency(index: number) {
        var self = this;
        self.selectedDaysOrEveryForMonthlyFrequencyBool[index] = !self.selectedDaysOrEveryForMonthlyFrequencyBool[index];
        if (self.selectedDaysOrEveryForMonthlyFrequencyBool[index] == true) {
            self.selectedDaysOrEveryForMonthlyFrequency.push((index + 1));
        } else {
            self.selectedDaysOrEveryForMonthlyFrequency.splice(self.selectedDaysOrEveryForMonthlyFrequency.indexOf(index), 1);
        }
        self.frequency.isEverySelected = JSON.parse(JSON.stringify(self.selectedDaysOrEveryForMonthlyFrequency.toString()));
    }

    public checkIfItemShouldBeChecked(day) {
        var self = this;
        console.log("mana: " + self.frequency.weeklyDaysSelectedFromServer.indexOf(day))
        return self.frequency.weeklyDaysSelectedFromServer.indexOf(day) > -1;
    }

    public convertListToJSON() {
        console.log(JSON.stringify(this.dates.toString()));
    }
}

class defineFrequencyModel {
    frequency: number;
    startDate: Date;
    endDate: Date = null;
    recurEvery: string;
    isEverySelected: string;
    weeklyDaysSelected: string;
    weeklyDaysSelectedFromServer: boolean[] = [false, false, false, false, false, false, false];
    selectedMonths: string;
    selectedMonthsFromServer: boolean[] = [false, false, false, false, false, false, false, false, false, false, false, false];
    selectedmonthlyDates: string;
    selectedMonthlyDatesFromServer: boolean[] = [false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false];
    selectedMonthlyEvery: string;
    selectedMonthlyEveryFromServer: boolean[] = [false, false, false, false, false];
    selectedMonthlyDays: string;
    selectedMonthlyDaysFromServer: boolean[] = [false, false, false, false, false, false, false];
    selectedDaysOrEveryForMonthlyFrequency: string;
    selectedDaysOrEveryForMonthlyFrequencyFromServer: boolean[] = [false, false];
}


defineFrequencyModule.controller("defineFrequencyController"
    , ["$scope"
        , "subscriptionWebService"
        , defineFrequencyController
    ]);