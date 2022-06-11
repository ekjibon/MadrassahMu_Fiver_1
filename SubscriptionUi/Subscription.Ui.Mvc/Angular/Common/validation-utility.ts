class formValidator {
    private _validationResults: iValidationResult;
    private _watchers: any[] = [];
    get validationResults(): iValidationResult {
        if (this._validationResults == null)
            this._validationResults = {};
        return this._validationResults;
    }

    set validationResults(newValidationResults: iValidationResult) {
        this._validationResults = newValidationResults;
    }

    private _validationField: iValidationField;

    get validationField(): iValidationField {
        if (this._validationField == null)
            this._validationField = {};
        return this._validationField;
    }

    set validationField(newValidationField: iValidationField) {
        this._validationField = newValidationField;
    }

    private validationGroupItems: {
        [groupName: string]: string[];
    };

    constructor(private $parse, private toastr, private scope, private formName = null) {
        this.validationResults = null;
        this.validationGroupItems = {};
    }

    public isGroupValid(groupName: string) {
        var self = this;
        var isAllFieldsValid: boolean = true;
        if (self.validationGroupItems[groupName] == null)
            return true;
        self.validationGroupItems[groupName].forEach((fieldName) => {
            isAllFieldsValid = (isAllFieldsValid && self.isFieldValid(fieldName));
        });

        return isAllFieldsValid;
    }

    public isFormValid() {
        var self = this;

        if (this.validationResults == null)
            return true;

        for (var currentFieldName in this.validationResults) {
            if (!self.isFieldValid(currentFieldName)) {
                return false
            }
        }
        return true;
    }

    public isFieldValid(fieldName: string): boolean {
        return (this.validationResults == null
            || this.validationResults[fieldName] == null
            || this.validationResults[fieldName].errorMessages == null
            || this.validationResults[fieldName].errorMessages.length == 0)
    }

    public getAllValidationMessages(): string[] {
        var self = this;
        var errorMessages = new Array();
        if (self.validationResults == null)
            return errorMessages;

        for (var currentFieldName in this.validationResults) {

            for (var d = 0; (self.validationResults[currentFieldName] != null && d < self.validationResults[currentFieldName].errorMessages.length); d++) {
                errorMessages.push(self.validationResults[currentFieldName].errorMessages[d]);
            }
        }

        return errorMessages;
    }
    public getAllValidationMessagesAsList(joinString: string): string {
        var self = this;
        var errorMessages = self.getAllValidationMessages();
        return errorMessages.join(joinString);
    }
    public getAllValidationMessagesForGroup(groupName: string): string[] {
        var self = this;
        var errorMessages = new Array();
        if (self.validationResults == null)
            return errorMessages;

        if (self.validationGroupItems == null)
            return errorMessages;

        self.validationGroupItems[groupName].forEach((currentFieldName) => {
            for (var d = 0; (self.validationResults[currentFieldName] != null && d < self.validationResults[currentFieldName].errorMessages.length); d++) {
                errorMessages.push(self.validationResults[currentFieldName].errorMessages[d]);
            }
        });

        return errorMessages;

    }
    public getAllValidationMessagesForGroupAsList(groupName: string, joinString: string): string {
        var self = this;
        var errorMessages = self.getAllValidationMessagesForGroup(groupName);
        return errorMessages.join(joinString);
    }
    public getValidationMessage(fieldName: string): string[] {
        var errorMessages = new Array();
        if (this.validationResults == null)
            return errorMessages;
        if (this.validationResults[fieldName] == null)
            return errorMessages;

        return this.validationResults[fieldName].errorMessages;
    }
    public getValidationMessageAsList(fieldName: string, joinString: string): string {
        var self = this;
        var errorMessages = self.getValidationMessage(fieldName);
        if (joinString == null)
            joinString = '\n';
        return errorMessages.join(joinString);
    }


    public IsEmailAddressValid(email: string): boolean {
        if (email == null)
            return false;
        if (email.length == 0)
            return false;
        return true;
    }

    public IsMandatoryFieldValid(value: string): boolean {
        if (value == null)
            return false;
        if (value.length == 0)
            return false;
        return true;
    }
    public IsRangeOfFieldValid(value: string, min: number, max: number): boolean {
        if (value != null && (value.length < min || value.length > max)) {
            return false;
        }
        return true;
    }
    public IsRegExFieldValid(value: string, regexPattern: string): boolean {
        var regexValidator = new RegExp(regexPattern);

        if (regexValidator.test(value)) {
            return true;
        }
        return false;
    }

    public registerValidation(fieldName: string, errorMessage: string, validationFunction: () => boolean) {
        var self = this;
        if (self.validationField[fieldName] == null)
            self.validationField[fieldName] = new Array();

        var _validationItem = new validationItem(fieldName, errorMessage, validationFunction);
        self.validationField[fieldName].push(_validationItem);

        //watch
        //var elementWithRootScope = fieldName;
        //var element = angular.element('[ng-model="' + elementWithRootScope + '"]');
        //if (element.length == 0) {
        //    element = angular.element('[name="' + elementWithRootScope + '"]');
        //    elementWithRootScope = element.attr('ng-model');
        //}

        //if (element != null && element != undefined) {

        //    var watcher = self.scope.$watch(elementWithRootScope, function (v) {
        //        var isValid = self.validateFieldItem(_validationItem, false, false);

        //        element.next(".error-msg").remove();
        //        if (element.hasClass('ng-dirty')) {
        //            if (isValid) {
        //                element.removeClass('error');
        //            } else {
        //                element.addClass('error');
        //                var contentTr = angular.element('<span class="error-msg">' + errorMessage + '</span>');
        //                contentTr.insertAfter(element);
        //            }
        //        }
        //    });
        //    self._watchers.push(watcher);
        //}
    }

    public registerValidationForMandatoryForPrefix(prefixFieldName: string, fieldLabel: string, groupName: string, customErrorMessage: string = null) {
        var self = this;

        var formScope = self.scope[self.formName];

        angular.forEach(formScope, function (element, name) {
            let _fieldLabel = fieldLabel;
            let _customErrorMessage = customErrorMessage;

            if (!name.startsWith('$') && name.indexOf(prefixFieldName) > -1) {

                if (_customErrorMessage == null) {
                    if (_fieldLabel == null) {
                        _fieldLabel = element.$$attr.description;
                    }
                    _customErrorMessage = _fieldLabel + " is required.";
                }

                self.registerValidation(name, _customErrorMessage, () => {
                    var value = formScope[name].$modelValue;
                    return (self.IsMandatoryFieldValid(value));
                });
                self.registerGroupValidation(groupName, [name])
            }
        });

    }

    public registerValidationForMandatory(objectToValidate, fieldName: string, fieldLabel: string, customErrorMessage: string = null) {
        var self = this;

        if (customErrorMessage == null) {
            customErrorMessage = fieldLabel + " is required.";
        }
        self.registerValidation(fieldName, customErrorMessage, () => {
            var formScope = self.scope[self.formName];
            var value = formScope[fieldName].$modelValue;

            //var fieldValueFn = self.$parse(fieldName);
            //var value = fieldValueFn(objectToValidate);
            return (self.IsMandatoryFieldValid(value));
        });
    }

    public registerValidationForNullOrRegEx(objectToValidate, fieldName: string, fieldLabel: string, regexPattern: string, customErrorMessage: string = null) {
        return this.registerValidationForRegEx(objectToValidate, fieldName, fieldLabel, regexPattern, true, customErrorMessage);
    }

    public registerValidationForRegEx(objectToValidate, fieldName: string, fieldLabel: string, regexPattern: string, canBeNull: boolean = false, customErrorMessage: string = null) {
        var self = this;
        if (customErrorMessage == null) {
            customErrorMessage = "Incorrect value entered for " + fieldLabel + "!";
        }
        self.registerValidation(fieldName, customErrorMessage, () => {
            //var fieldValueFn = self.$parse(fieldName);
            //var value = fieldValueFn(objectToValidate);

            var formScope = self.scope[self.formName];
            var value = formScope[fieldName].$modelValue;

            if (canBeNull && (value == null || value == ''))
                return true;
            else
                return (self.IsRegExFieldValid(value, regexPattern));
        });
    }
    public registerValidationRegExEmailOnly(fieldValue, fieldName, fieldLabel, regexPattern) {
        return this.registerValidationForRegExEmailFieldOnly(fieldValue, fieldName, fieldLabel, regexPattern, true);
    }
    public registerValidationForRegExEmailFieldOnly(fieldValue, fieldName, fieldLabel, regexPattern, canBeNull) {
        if (canBeNull === void 0) { canBeNull = false; }
        var self = this;
        return (self.IsRegExFieldValid(fieldValue, regexPattern));
    }
    public registerValidationForCharacterLengthRange(objectToValidate, fieldName, fieldLabel, minLength, maxLength, customErrorMessage) {
        if (customErrorMessage === void 0) { customErrorMessage = null; }
        var self = this;
        if (customErrorMessage == null) {
            customErrorMessage = fieldLabel + ' should contain ' + minLength + ' to ' + maxLength + ' characters.';
        }
        self.registerValidation(fieldName, customErrorMessage, function () {
            var fieldValueFn = self.$parse(fieldName);
            var value = fieldValueFn(objectToValidate);
            if (value == null) {
                return true;
            }
            else {
                return (value.toString().length >= minLength && value.toString().length <= maxLength);
            }
        });
    }
    public registerValidationForEmail(objectToValidate, fieldName: string, fieldLabel: string) {
        var self = this;

        self.registerValidation(fieldName, "Please enter a valid email for field " + fieldLabel + "!", () => {
            let formScope = self.scope[self.formName];
            let value = formScope[fieldName].$modelValue;

            //var fieldValueFn = self.$parse(fieldName);
            //var value = fieldValueFn(objectToValidate);
            return (self.IsEmailAddressValid(value));
        });
    }
    public registerGroupValidation(groupName: string, fieldNames: string[]) {
        if (this.validationGroupItems[groupName] == null)
            this.validationGroupItems[groupName] = new Array();

        fieldNames.forEach((fieldName) => {
            this.validationGroupItems[groupName].push(fieldName);
        });
    }

    public validateForm(showToast: boolean = false, clearValidationResults: boolean = true) {
        var self = this;

        if (self.validationField == null)
            return true;

        if (clearValidationResults)
            self.clearValidationResults();

        for (var fieldName in self.validationField) {
            self.clearValidationResultForField(fieldName);
            self.validateField(fieldName, false, false);
        }

        var isFormValid = self.isFormValid();
        if (!isFormValid && showToast) {
            self.toastr.pop({
                type: 'error',
                body: self.getAllValidationMessagesAsList('</br>'),
                bodyOutputType: 'trustedHtml'
            });
        }
        return isFormValid;
    }

    public validateGroup(groupName: string, showToast: boolean = false, clearValidationResultForGroup: boolean = true) {
        var self = this;

        if (self.validationGroupItems[groupName] == null)
            return true;

        self.validationGroupItems[groupName].forEach((fieldName) => {
            self.clearValidationResultForField(fieldName);
            self.validateField(fieldName, false, false);
        });
        var isGroupValid = self.isGroupValid(groupName);
        if (!isGroupValid && showToast) {
            self.toastr.error('', self.getAllValidationMessagesForGroupAsList(groupName, '</br>'));
        }
        return isGroupValid;
    }
    public validateField(fieldName: string, showToast: boolean = false, clearValidationResultForField: boolean = true) {
        var self = this;

        if (self.validationField[fieldName] == null)
            return true;

        if (self.validationResults != null && clearValidationResultForField) {
            self.validationResults[fieldName] = null;
        }

        if (self.validationResults == null)
            self.validationResults = {};

        var isValid = true;
        self.validationField[fieldName].forEach((validationItem) => {
            isValid = self.validateFieldItem(validationItem, false, false) && isValid;
        });

        if (showToast && !isValid) {
            self.toastr.error('', self.getValidationMessageAsList(fieldName,'<br/>'));
        }

        return isValid;
    }
    private validateFieldItem(validationItem: validationItem, showToast: boolean = false, clearValidationResultForField: boolean = true): boolean {
        var self = this;

        if (self.validationResults != null && clearValidationResultForField) {
            self.validationResults[validationItem.fieldName] = null;
        }

        if (self.validationResults == null)
            self.validationResults = {};

        if (validationItem.isValid()) {
            return true;
        }

        self.setValidationResult(validationItem.fieldName, validationItem.errorMessage)

        if (showToast) {
            self.toastr.error('', validationItem.errorMessage);
        }
        return false;
    }

    public setValidationResult(fieldName: string, errorMessage: string) {
        if (this.validationResults == null)
            this.validationResults = {};

        if (this.validationResults[fieldName] == null) {
            this.validationResults[fieldName] = new validationResult();
        }
        this.validationResults[fieldName].errorMessages.push(errorMessage);
    }
    public clearValidationResults() {
        this.validationResults = null;
    }
    public clearValidationResultForField(fieldName: string) {
        var self = this;
        if (self.validationResults != null) {
            self.validationResults[fieldName] = null;
        }
    }
    public clearGroupValidation(groupName: string) {
        this.validationGroupItems[groupName] = [];
    }

    public deRegister() {
        var self = this;
        self._watchers.forEach(function (watcher) {
            watcher();
        })
    }
}

class validationResult {
    field: string;
    errorMessages: string[];

    constructor() {
        this.errorMessages = [];
    }

    public isValid() {
        return this.errorMessages.length == 0;
    }
}

class validationItem {

    public fieldName: string;
    public errorMessage: string;
    public validationFunction: iValidationFunctionDelegate;

    constructor(fieldName: string,
        errorMessage: string,
        validationFunction: iValidationFunctionDelegate) {
        this.fieldName = fieldName;
        this.errorMessage = errorMessage;
        this.validationFunction = validationFunction;
    }

    public isValid(): boolean {
        return this.validationFunction();
    }
}

interface iValidationFunctionDelegate { (): boolean }

interface iValidationResult {
    [fieldName: string]: validationResult;
}

interface iValidationItem {
    [fieldName: string]: validationItem;
}

interface iValidationField {
    [fieldName: string]: validationItem[];
}

angular.module('validator', [])
    .directive("realTimeValidator", function () {
        return {
            require: "?ngModel",
            restrict: 'A',
            scope: {
                model: '=ngModel'
                , formValidator: '=realTimeValidator'
            },
            link: function (scope, element, attrs, control) {
                if (!control) return;
                var watcher = scope.$watch('model', function (modelValue) {
                    if (scope.formValidator != null && scope.formValidator != undefined) {
                        element.next(".error-msg").remove();
                        element.removeClass('error');
                        let isValid = scope.formValidator.validateField(attrs.name);
                        if (!isValid && element.hasClass('ng-dirty')) {
                            let errors: string[] = scope.formValidator.getValidationMessage(attrs.name);
                            element.addClass('error');
                            var contentTr = angular.element('<span class="error-msg">' + errors.join("<br/>") + '</span>');
                            contentTr.insertAfter(element);
                        }
                    }
                });
            }
        };
    });