var administrationNewCustomerController = /** @class */ (function () {
    function administrationNewCustomerController($scope, $parse, toaster, moment, fileManager, addressPublicUtilityService) {
        this.$scope = $scope;
        this.$parse = $parse;
        this.toaster = toaster;
        this.moment = moment;
        this.groupName = customerTabNameFromEnum.getName(customerTab.BASIC);
        this.contactTypeForEntity = [];
        this.scope = $scope;
        this.scope.controller = this;
        this.callerController = $scope.$parent.controller;
        this.fileManager = fileManager;
        this.addressPublicUtilityService = addressPublicUtilityService;
        this.baseController = $scope.baseController;
        this.callerController.registerAdministrationCustomerDetailBasicInfoController(this);
        this.initialize();
    }
    Object.defineProperty(administrationNewCustomerController.prototype, "address", {
        get: function () {
            var self = this;
            if (!self.hasCustomerDetailBeenLoaded) {
                return;
            }
            var address;
            if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
                if (self.customer.company.companyLocations.length == 0) {
                    address = new addressModel();
                    var companyLocation = new companyLocationModel();
                    companyLocation.address = address;
                    self.customer.company.companyLocations.push(companyLocation);
                }
                else {
                    address = self.customer.company.companyLocations[0].address;
                }
            }
            else if (self.customer.idCustomerType == customerTypeEnum.PERSON) {
                if (!self.baseController.isNullOrUndefined(self.customer.person)) {
                    if (self.customer.person.person_Address.length == 0) {
                        address = new addressModel();
                        var person_Address = new person_AddressModel();
                        person_Address.address = address;
                        self.customer.person.person_Address.push(person_Address);
                    }
                    else {
                        address = self.customer.person.person_Address[0].address;
                    }
                }
            }
            return address;
        },
        set: function (value) {
            var self = this;
            self.address = value;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "email", {
        //---
        get: function () {
            var self = this;
            var _email;
            if (!self.baseController.isNullOrUndefined(self.customer)) {
                if (self.customer.idCustomerType == 2 && self.customer.person.person_ContactType.length > 0) {
                    self.customer.person.person_ContactType.forEach(function (contactType) {
                        if (contactType.idContactType == 2) {
                            _email = contactType.description;
                        }
                    });
                }
                else {
                    self.customer.company.company_ContactType.forEach(function (contactType) {
                        if (contactType.idContactType == 2) {
                            _email = contactType.description;
                        }
                    });
                }
            }
            return _email;
        },
        set: function (value) {
            var self = this;
            self.email = value;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "phone", {
        get: function () {
            var self = this;
            var _phone;
            if (!self.baseController.isNullOrUndefined(self.customer)) {
                if (self.customer.idCustomerType == 1 && self.customer.person.person_ContactType.length > 0) {
                    self.customer.person.person_ContactType.forEach(function (contactType) {
                        if (contactType.idContactType == 2) {
                            _phone = contactType.description;
                        }
                    });
                }
                else {
                    self.customer.company.company_ContactType.forEach(function (contactType) {
                        if (contactType.idContactType == 2) {
                            _phone = contactType.description;
                        }
                    });
                }
            }
            return _phone;
        },
        set: function (value) {
            var self = this;
            self.phone = value;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "screenMode", {
        //---
        get: function () {
            return this.callerController.screenModeManager.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "customer", {
        get: function () {
            return this.callerController.screenModeManager.entity;
        },
        set: function (customer) {
            this.customer = customer;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "customerTypes", {
        get: function () {
            return this.callerController.preloadedData.customerTypes;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "titles", {
        get: function () {
            return this.callerController.preloadedData.titles;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "countries", {
        get: function () {
            return this.callerController.preloadedData.countries;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "hasCustomerDetailBeenLoaded", {
        get: function () {
            return this.callerController.hasCustomerDetailBeenLoaded;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "formName", {
        get: function () {
            return this.callerController.formName;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(administrationNewCustomerController.prototype, "contactTypes", {
        get: function () {
            return this.callerController.preloadedData.contactTypes;
        },
        enumerable: false,
        configurable: true
    });
    administrationNewCustomerController.prototype.initialize = function () {
        var self = this;
        self.registerValidations();
        self.customerTypeEnum = customerTypeEnum;
        //if (!self.baseController.isNullOrUndefined(self.callerController.screenModeManager.entity)) {
        //    self.person_contactType = self.callerController.screenModeManager.entity.person.person_ContactType;
        //}
    };
    administrationNewCustomerController.prototype.registerValidations = function () {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        self.formValidator.registerValidationForMandatory(self.scope, 'customerType', 'Customer Type');
        self.formValidator.registerValidationForMandatory(self.scope, 'country', 'Country');
        self.formValidator.registerValidation('nationalIdentificationNumber', 'Invalid NIC', function () {
            if (self.baseController.isNullOrUndefined(self.customer.person.nationalIdentificationNumber)) {
                return false;
            }
            else if (self.customer.person.nationalIdentificationNumber.length > 14) {
                return true;
            }
        });
        self.formValidator.registerValidation('title', 'Please enter title', function () {
            if (self.baseController.isNullOrUndefined(self.customer.idCustomerType)) {
                return false;
            }
            else {
                if (self.customer.idCustomerType == customerTypeEnum.PERSON) {
                    return !self.baseController.isNullOrUndefined(self.customer.idCustomerType);
                }
                return true;
            }
        });
        self.formValidator.registerValidation('entityName', 'Please enter customer name', function () {
            if (self.baseController.isNullOrUndefined(self.customer.idCustomerType)) {
                return false;
            }
            else {
                if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
                    return !self.baseController.isNullOrUndefined(self.customer.company.name);
                }
                else {
                    return !self.baseController.isNullOrUndefined(self.customer.person.firstname);
                }
            }
        });
        self.formValidator.registerGroupValidation(self.groupName, ['customerType', 'title', 'entityName', 'country']);
    };
    administrationNewCustomerController.prototype.onDetailLoaded = function () {
        var self = this;
        self.refreshContactType();
    };
    administrationNewCustomerController.prototype.onCustomerTypeSelected = function (item) {
        var self = this;
        self.customer.idCustomerType = item.idCustomerType;
        if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
            if (self.baseController.isNullOrUndefined(self.customer.company)) {
                self.customer.company = new companyModel();
            }
            if (self.baseController.isNullOrUndefined(self.customer.company.companyLocations)) {
                self.customer.company.companyLocations = [];
            }
            if (self.baseController.isNullOrUndefined(self.customer.company.company_ContactType)) {
                self.customer.company.company_ContactType = [];
            }
        }
        else if (self.customer.idCustomerType == customerTypeEnum.PERSON) {
            if (self.baseController.isNullOrUndefined(self.customer.person)) {
                self.customer.person = new personModel();
            }
            if (self.baseController.isNullOrUndefined(self.customer.person.person_Address)) {
                self.customer.person.person_Address = [];
            }
            if (self.baseController.isNullOrUndefined(self.customer.person.person_ContactType)) {
                self.customer.person.person_ContactType = [];
            }
        }
        self.refreshContactType();
    };
    administrationNewCustomerController.prototype.onTitleSelected = function (item) {
        var self = this;
        self.customer.person.idTitle = item.idTitle;
    };
    administrationNewCustomerController.prototype.onCountrySelected = function (item) {
        var self = this;
        self.address.idCountry = item.idCountry;
    };
    administrationNewCustomerController.prototype.refreshContactType = function () {
        var self = this;
        if (!self.hasCustomerDetailBeenLoaded || self.baseController.isNullOrUndefined(self.customer.idCustomerType))
            return;
        self.contactTypeForEntity = [];
        Enumerable.From(self.contactTypes).Where(function (contactType) {
            return contactType.idParentContactType == null;
        }).ForEach(function (contactType) {
            self.contactTypeForEntity.push({
                contactType: contactType,
                contactTypes: self.getEntityTypeForContactType(contactType)
            });
        });
    };
    administrationNewCustomerController.prototype.getEntityTypeForContactType = function (contactType) {
        var self = this;
        var defaultContactType = self.getDefaultContactTypeForParent(contactType);
        var contactTypes = [];
        var contactTypeFromEntities;
        if (!self.hasCustomerDetailBeenLoaded || self.baseController.isNullOrUndefined(self.customer.idCustomerType))
            return;
        if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
            contactTypes = self.customer.company.company_ContactType;
        }
        else {
            contactTypes = self.customer.person.person_ContactType;
        }
        if (defaultContactType == null) { //no default contact type available, mail for example
            contactTypeFromEntities = Enumerable.From(contactTypes).Where(function (contactTypeFromEntity) {
                return contactTypeFromEntity.idContactType == contactType.idContactType;
            }).ToArray();
        }
        else { //get all for the contact type whose parent is same as contactType parameter
            contactTypeFromEntities = Enumerable.From(contactTypes).Where(function (contactTypeFromEntity) {
                return contactTypeFromEntity.contactType.idParentContactType == contactType.idContactType;
            }).ToArray();
        }
        return contactTypeFromEntities;
    };
    administrationNewCustomerController.prototype.addEntity_ContactType = function (contactType) {
        var self = this;
        var entity_ContactType = {};
        var idLocalName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idLocalCompany_ContactType" : "idLocalPerson_ContactType";
        var idName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idCompany_ContactType" : "idPerson_ContactType";
        entity_ContactType[idLocalName] = self.baseController.generateUUID();
        var defaultContactType = self.getDefaultContactTypeForParent(contactType);
        if (defaultContactType != null) {
            entity_ContactType.idContactType = defaultContactType.idContactType;
            entity_ContactType.contactType = defaultContactType;
        }
        else {
            entity_ContactType.idContactType = contactType.idContactType;
            entity_ContactType.contactType = contactType;
        }
        if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
            self.customer.company.company_ContactType.push(entity_ContactType);
        }
        else {
            self.customer.person.person_ContactType.push(entity_ContactType);
        }
        console.log(entity_ContactType);
        self.refreshContactType();
    };
    administrationNewCustomerController.prototype.getDefaultContactTypeForParent = function (contactType) {
        var self = this;
        return Enumerable.From(self.contactTypes).Where(function (_contactType) {
            return _contactType.idParentContactType == contactType.idContactType;
        }).FirstOrDefault(null);
    };
    administrationNewCustomerController.prototype.isContactTypeHiearchycal = function (contactType) {
        var self = this;
        return self.getDefaultContactTypeForParent(contactType) != null;
    };
    administrationNewCustomerController.prototype.onContactTypeSelected = function (contactType, entity_ContactType) {
        var self = this;
        entity_ContactType.idContactType = contactType.idContactType;
    };
    administrationNewCustomerController.prototype.removeEntity_ContactType = function (entity_ContactType) {
        var self = this;
        var idLocalName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idLocalCompany_ContactType" : "idLocalPerson_ContactType";
        var idName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idCompany_ContactType" : "idPerson_ContactType";
        var entity = self.customer.idCustomerType == customerTypeEnum.COMPANY ? self.customer.company.company_ContactType : self.customer.person.person_ContactType;
        var position = self.baseController.searchForEntityInList(idName, entity, entity_ContactType, idLocalName);
        entity.splice(position, 1);
        self.refreshContactType();
    };
    return administrationNewCustomerController;
}());
administrationCustomerModule.controller("administrationNewCustomerController", ["$scope",
    "$parse",
    "toaster",
    "moment",
    "fileManager",
    administrationNewCustomerController
]);
//# sourceMappingURL=administration-new-customer-controller.js.map