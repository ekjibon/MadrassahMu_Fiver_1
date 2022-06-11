var formValidator = /** @class */ (function () {
    function formValidator($parse, toastr, scope, formName) {
        if (formName === void 0) { formName = null; }
        this.$parse = $parse;
        this.toastr = toastr;
        this.scope = scope;
        this.formName = formName;
        this._watchers = [];
        this.validationResults = null;
        this.validationGroupItems = {};
    }
    Object.defineProperty(formValidator.prototype, "validationResults", {
        get: function () {
            if (this._validationResults == null)
                this._validationResults = {};
            return this._validationResults;
        },
        set: function (newValidationResults) {
            this._validationResults = newValidationResults;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(formValidator.prototype, "validationField", {
        get: function () {
            if (this._validationField == null)
                this._validationField = {};
            return this._validationField;
        },
        set: function (newValidationField) {
            this._validationField = newValidationField;
        },
        enumerable: false,
        configurable: true
    });
    formValidator.prototype.isGroupValid = function (groupName) {
        var self = this;
        var isAllFieldsValid = true;
        if (self.validationGroupItems[groupName] == null)
            return true;
        self.validationGroupItems[groupName].forEach(function (fieldName) {
            isAllFieldsValid = (isAllFieldsValid && self.isFieldValid(fieldName));
        });
        return isAllFieldsValid;
    };
    formValidator.prototype.isFormValid = function () {
        var self = this;
        if (this.validationResults == null)
            return true;
        for (var currentFieldName in this.validationResults) {
            if (!self.isFieldValid(currentFieldName)) {
                return false;
            }
        }
        return true;
    };
    formValidator.prototype.isFieldValid = function (fieldName) {
        return (this.validationResults == null
            || this.validationResults[fieldName] == null
            || this.validationResults[fieldName].errorMessages == null
            || this.validationResults[fieldName].errorMessages.length == 0);
    };
    formValidator.prototype.getAllValidationMessages = function () {
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
    };
    formValidator.prototype.getAllValidationMessagesAsList = function (joinString) {
        var self = this;
        var errorMessages = self.getAllValidationMessages();
        return errorMessages.join(joinString);
    };
    formValidator.prototype.getAllValidationMessagesForGroup = function (groupName) {
        var self = this;
        var errorMessages = new Array();
        if (self.validationResults == null)
            return errorMessages;
        if (self.validationGroupItems == null)
            return errorMessages;
        self.validationGroupItems[groupName].forEach(function (currentFieldName) {
            for (var d = 0; (self.validationResults[currentFieldName] != null && d < self.validationResults[currentFieldName].errorMessages.length); d++) {
                errorMessages.push(self.validationResults[currentFieldName].errorMessages[d]);
            }
        });
        return errorMessages;
    };
    formValidator.prototype.getAllValidationMessagesForGroupAsList = function (groupName, joinString) {
        var self = this;
        var errorMessages = self.getAllValidationMessagesForGroup(groupName);
        return errorMessages.join(joinString);
    };
    formValidator.prototype.getValidationMessage = function (fieldName) {
        var errorMessages = new Array();
        if (this.validationResults == null)
            return errorMessages;
        if (this.validationResults[fieldName] == null)
            return errorMessages;
        return this.validationResults[fieldName].errorMessages;
    };
    formValidator.prototype.getValidationMessageAsList = function (fieldName, joinString) {
        var self = this;
        var errorMessages = self.getValidationMessage(fieldName);
        if (joinString == null)
            joinString = '\n';
        return errorMessages.join(joinString);
    };
    formValidator.prototype.IsEmailAddressValid = function (email) {
        if (email == null)
            return false;
        if (email.length == 0)
            return false;
        return true;
    };
    formValidator.prototype.IsMandatoryFieldValid = function (value) {
        if (value == null)
            return false;
        if (value.length == 0)
            return false;
        return true;
    };
    formValidator.prototype.IsRangeOfFieldValid = function (value, min, max) {
        if (value != null && (value.length < min || value.length > max)) {
            return false;
        }
        return true;
    };
    formValidator.prototype.IsRegExFieldValid = function (value, regexPattern) {
        var regexValidator = new RegExp(regexPattern);
        if (regexValidator.test(value)) {
            return true;
        }
        return false;
    };
    formValidator.prototype.registerValidation = function (fieldName, errorMessage, validationFunction) {
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
    };
    formValidator.prototype.registerValidationForMandatoryForPrefix = function (prefixFieldName, fieldLabel, groupName, customErrorMessage) {
        if (customErrorMessage === void 0) { customErrorMessage = null; }
        var self = this;
        var formScope = self.scope[self.formName];
        angular.forEach(formScope, function (element, name) {
            var _fieldLabel = fieldLabel;
            var _customErrorMessage = customErrorMessage;
            if (!name.startsWith('$') && name.indexOf(prefixFieldName) > -1) {
                if (_customErrorMessage == null) {
                    if (_fieldLabel == null) {
                        _fieldLabel = element.$$attr.description;
                    }
                    _customErrorMessage = _fieldLabel + " is required.";
                }
                self.registerValidation(name, _customErrorMessage, function () {
                    var value = formScope[name].$modelValue;
                    return (self.IsMandatoryFieldValid(value));
                });
                self.registerGroupValidation(groupName, [name]);
            }
        });
    };
    formValidator.prototype.registerValidationForMandatory = function (objectToValidate, fieldName, fieldLabel, customErrorMessage) {
        if (customErrorMessage === void 0) { customErrorMessage = null; }
        var self = this;
        if (customErrorMessage == null) {
            customErrorMessage = fieldLabel + " is required.";
        }
        self.registerValidation(fieldName, customErrorMessage, function () {
            var formScope = self.scope[self.formName];
            var value = formScope[fieldName].$modelValue;
            //var fieldValueFn = self.$parse(fieldName);
            //var value = fieldValueFn(objectToValidate);
            return (self.IsMandatoryFieldValid(value));
        });
    };
    formValidator.prototype.registerValidationForNullOrRegEx = function (objectToValidate, fieldName, fieldLabel, regexPattern, customErrorMessage) {
        if (customErrorMessage === void 0) { customErrorMessage = null; }
        return this.registerValidationForRegEx(objectToValidate, fieldName, fieldLabel, regexPattern, true, customErrorMessage);
    };
    formValidator.prototype.registerValidationForRegEx = function (objectToValidate, fieldName, fieldLabel, regexPattern, canBeNull, customErrorMessage) {
        if (canBeNull === void 0) { canBeNull = false; }
        if (customErrorMessage === void 0) { customErrorMessage = null; }
        var self = this;
        if (customErrorMessage == null) {
            customErrorMessage = "Incorrect value entered for " + fieldLabel + "!";
        }
        self.registerValidation(fieldName, customErrorMessage, function () {
            //var fieldValueFn = self.$parse(fieldName);
            //var value = fieldValueFn(objectToValidate);
            var formScope = self.scope[self.formName];
            var value = formScope[fieldName].$modelValue;
            if (canBeNull && (value == null || value == ''))
                return true;
            else
                return (self.IsRegExFieldValid(value, regexPattern));
        });
    };
    formValidator.prototype.registerValidationRegExEmailOnly = function (fieldValue, fieldName, fieldLabel, regexPattern) {
        return this.registerValidationForRegExEmailFieldOnly(fieldValue, fieldName, fieldLabel, regexPattern, true);
    };
    formValidator.prototype.registerValidationForRegExEmailFieldOnly = function (fieldValue, fieldName, fieldLabel, regexPattern, canBeNull) {
        if (canBeNull === void 0) {
            canBeNull = false;
        }
        var self = this;
        return (self.IsRegExFieldValid(fieldValue, regexPattern));
    };
    formValidator.prototype.registerValidationForCharacterLengthRange = function (objectToValidate, fieldName, fieldLabel, minLength, maxLength, customErrorMessage) {
        if (customErrorMessage === void 0) {
            customErrorMessage = null;
        }
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
    };
    formValidator.prototype.registerValidationForEmail = function (objectToValidate, fieldName, fieldLabel) {
        var self = this;
        self.registerValidation(fieldName, "Please enter a valid email for field " + fieldLabel + "!", function () {
            var formScope = self.scope[self.formName];
            var value = formScope[fieldName].$modelValue;
            //var fieldValueFn = self.$parse(fieldName);
            //var value = fieldValueFn(objectToValidate);
            return (self.IsEmailAddressValid(value));
        });
    };
    formValidator.prototype.registerGroupValidation = function (groupName, fieldNames) {
        var _this = this;
        if (this.validationGroupItems[groupName] == null)
            this.validationGroupItems[groupName] = new Array();
        fieldNames.forEach(function (fieldName) {
            _this.validationGroupItems[groupName].push(fieldName);
        });
    };
    formValidator.prototype.validateForm = function (showToast, clearValidationResults) {
        if (showToast === void 0) { showToast = false; }
        if (clearValidationResults === void 0) { clearValidationResults = true; }
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
    };
    formValidator.prototype.validateGroup = function (groupName, showToast, clearValidationResultForGroup) {
        if (showToast === void 0) { showToast = false; }
        if (clearValidationResultForGroup === void 0) { clearValidationResultForGroup = true; }
        var self = this;
        if (self.validationGroupItems[groupName] == null)
            return true;
        self.validationGroupItems[groupName].forEach(function (fieldName) {
            self.clearValidationResultForField(fieldName);
            self.validateField(fieldName, false, false);
        });
        var isGroupValid = self.isGroupValid(groupName);
        if (!isGroupValid && showToast) {
            self.toastr.error('', self.getAllValidationMessagesForGroupAsList(groupName, '</br>'));
        }
        return isGroupValid;
    };
    formValidator.prototype.validateField = function (fieldName, showToast, clearValidationResultForField) {
        if (showToast === void 0) { showToast = false; }
        if (clearValidationResultForField === void 0) { clearValidationResultForField = true; }
        var self = this;
        if (self.validationField[fieldName] == null)
            return true;
        if (self.validationResults != null && clearValidationResultForField) {
            self.validationResults[fieldName] = null;
        }
        if (self.validationResults == null)
            self.validationResults = {};
        var isValid = true;
        self.validationField[fieldName].forEach(function (validationItem) {
            isValid = self.validateFieldItem(validationItem, false, false) && isValid;
        });
        if (showToast && !isValid) {
            self.toastr.error('', self.getValidationMessageAsList(fieldName, '<br/>'));
        }
        return isValid;
    };
    formValidator.prototype.validateFieldItem = function (validationItem, showToast, clearValidationResultForField) {
        if (showToast === void 0) { showToast = false; }
        if (clearValidationResultForField === void 0) { clearValidationResultForField = true; }
        var self = this;
        if (self.validationResults != null && clearValidationResultForField) {
            self.validationResults[validationItem.fieldName] = null;
        }
        if (self.validationResults == null)
            self.validationResults = {};
        if (validationItem.isValid()) {
            return true;
        }
        self.setValidationResult(validationItem.fieldName, validationItem.errorMessage);
        if (showToast) {
            self.toastr.error('', validationItem.errorMessage);
        }
        return false;
    };
    formValidator.prototype.setValidationResult = function (fieldName, errorMessage) {
        if (this.validationResults == null)
            this.validationResults = {};
        if (this.validationResults[fieldName] == null) {
            this.validationResults[fieldName] = new validationResult();
        }
        this.validationResults[fieldName].errorMessages.push(errorMessage);
    };
    formValidator.prototype.clearValidationResults = function () {
        this.validationResults = null;
    };
    formValidator.prototype.clearValidationResultForField = function (fieldName) {
        var self = this;
        if (self.validationResults != null) {
            self.validationResults[fieldName] = null;
        }
    };
    formValidator.prototype.clearGroupValidation = function (groupName) {
        this.validationGroupItems[groupName] = [];
    };
    formValidator.prototype.deRegister = function () {
        var self = this;
        self._watchers.forEach(function (watcher) {
            watcher();
        });
    };
    return formValidator;
}());
var validationResult = /** @class */ (function () {
    function validationResult() {
        this.errorMessages = [];
    }
    validationResult.prototype.isValid = function () {
        return this.errorMessages.length == 0;
    };
    return validationResult;
}());
var validationItem = /** @class */ (function () {
    function validationItem(fieldName, errorMessage, validationFunction) {
        this.fieldName = fieldName;
        this.errorMessage = errorMessage;
        this.validationFunction = validationFunction;
    }
    validationItem.prototype.isValid = function () {
        return this.validationFunction();
    };
    return validationItem;
}());
angular.module('validator', [])
    .directive("realTimeValidator", function () {
    return {
        require: "?ngModel",
        restrict: 'A',
        scope: {
            model: '=ngModel',
            formValidator: '=realTimeValidator'
        },
        link: function (scope, element, attrs, control) {
            if (!control)
                return;
            var watcher = scope.$watch('model', function (modelValue) {
                if (scope.formValidator != null && scope.formValidator != undefined) {
                    element.next(".error-msg").remove();
                    element.removeClass('error');
                    var isValid = scope.formValidator.validateField(attrs.name);
                    if (!isValid && element.hasClass('ng-dirty')) {
                        var errors = scope.formValidator.getValidationMessage(attrs.name);
                        element.addClass('error');
                        var contentTr = angular.element('<span class="error-msg">' + errors.join("<br/>") + '</span>');
                        contentTr.insertAfter(element);
                    }
                }
            });
        }
    };
});
//# sourceMappingURL=validation-utility.js.map