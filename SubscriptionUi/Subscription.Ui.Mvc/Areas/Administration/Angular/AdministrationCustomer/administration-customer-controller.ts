class administrationCustomerController implements IAdministrationCustomerDetailBasicInfoCaller {
    scope;
    baseController: baseController;
    administrationCustomerWebService: administrationCustomerWebService;
    screenModeManager: screenModeManager<customerModel, administrationCustomerController>;
    idCustomer: number;
    callerController: IAdministrationCustomerDetailBasicInfoCaller;

    preloadedData: {
        customerTypes: customerTypeModel[],
        countries: countryModel[],
        titles: titleModel[],
        contactTypes: contactTypeModel[]
    } =
        {
            customerTypes: [],
            countries: [],
            titles: [],
            contactTypes: []
        };
    formValidator: formValidator;

    childControllers: IChildAdministrationCustomerDetailController[] = [];
    administrationNewCustomerController: administrationNewCustomerController;

    hasCustomerDetailBeenLoaded: boolean = false;
    hasScreenDetailBeenLoaded: boolean = false;

    currentTabShown: customerTab = customerTab.BASIC;
    profileTabEnum;

    formName: string = 'customerForm';

    constructor($scope
        , administrationCustomerWebService) {
        var self = this;
        $scope.controller = this;
        this.callerController = $scope.$parent.controller;
        this.administrationCustomerWebService = administrationCustomerWebService;
        this.scope = $scope;

        this.baseController = this.scope.baseController;

        this.initVariables();
        this.registerValidations();
    }

    get screenMode(): SCREEN_MODE {
        return this.screenModeManager.currentMode;
    }

    get customer(): customerModel {
        if (!this.baseController.isNullOrUndefined(this.callerController)) {
            return this.callerController.screenModeManager.entity;
        }
    }

    registerAdministrationCustomerDetailBasicInfoController(administrationNewCustomerController: administrationNewCustomerController) {
        this.administrationNewCustomerController = administrationNewCustomerController;
        this.childControllers.push(administrationNewCustomerController);
    }

    public initVariables() {
        var self = this;
        this.baseController = this.scope.baseController;
        self.profileTabEnum = customerTab;
    }

    public setInfo(id: number, mode: SCREEN_MODE) {
        var self = this;
        self.idCustomer = id;
        self.screenModeManager = new screenModeManager<customerModel, administrationCustomerController>(self, self.saveMethod, false);
        self.screenModeManager.currentMode = mode;
        self.loadScreenConstants();
        self.initialize();
    }

    public initialize() {
        var self = this;
        if (self.screenModeManager.currentMode == SCREEN_MODE.ADD) {
            var customer: customerModel;
            var _customer: customerModel = self.baseController.globalVariableFactory.sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.CUSTOMER_INITIALIZER, "CUSTOMER_INITIALIZER");
            if (!self.baseController.isNullOrUndefined(_customer)) {
                customer = _customer;
            } else {
                var customer = new customerModel();
            }

            self.screenModeManager.setEntity(customer);
            self.screenModeManager.entity.person = new personModel();
            self.screenModeManager.entity.person.person_ContactType = [];
            self.screenModeManager.entity.person.person_ContactType[0] = new person_ContactTypeModel();
            self.screenModeManager.entity.person.person_ContactType[0].idContactType = 1;
            self.screenModeManager.entity.person.person_ContactType[1] = new person_ContactTypeModel();
            self.screenModeManager.entity.person.person_ContactType[1].idContactType = 2;
            self.screenModeManager.entity.company = new companyModel();
            self.screenModeManager.entity.company.company_ContactType = [];
            self.screenModeManager.entity.company.company_ContactType[0] = new company_ContactTypeModel();
            self.screenModeManager.entity.company.company_ContactType[0].idContactType = 1;
            self.screenModeManager.entity.company.company_ContactType[1] = new company_ContactTypeModel();
            self.screenModeManager.entity.company.company_ContactType[1].idContactType = 2;
            self.onCustomerDetailLoaded();
        } else {
            self.loadEntity();
        }
    }

    public loadEntity() {
        var self = this;
        self.baseController.showLoading();
        var _getAdministrationCustomerDto = new getAdministrationCustomerDto();
        _getAdministrationCustomerDto.idCustomer = self.idCustomer;
        self.administrationCustomerWebService.getAdministrationCustomer(_getAdministrationCustomerDto)
            .then(function (response: baseResultReturnType<getAdministrationCustomerReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.screenModeManager.setEntity(response.result.customer);
                    self.onCustomerDetailLoaded();
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                //self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
    }

    public formatPersonForView(person: personModel): personModel {
        return person;
    }

    public saveMethod(modifiedEntity: customerModel, caller: administrationCustomerController) {
        var self: administrationCustomerController = caller;

        self.registerValidations();

        if (!self.validateForGroups()) {
            self.screenModeManager.setMode(SCREEN_MODE.EDIT);
            return;
        }

        var _saveAdministrationCustomerDto: saveAdministrationCustomerDto = new saveAdministrationCustomerDto();

        self.baseController.showLoading();

        if (self.screenModeManager.entity.idCustomerType == CUSTOMER_TYPE.PERSON) {
            /*var _personContactTypePhone: person_ContactTypeModel = new person_ContactTypeModel();
            _personContactTypePhone.idContactType = 1;
            _personContactTypePhone.description = self.screenModeManager.entity.person.person_ContactType[0].description ;
            _personContactTypePhone.idPerson = self.screenModeManager.entity.person.idPerson;

            self.screenModeManager.entity.person.person_ContactType.push(_personContactTypePhone);

            var _personContactTypeEmail: person_ContactTypeModel = new person_ContactTypeModel();
            _personContactTypePhone.idContactType = 2;
            _personContactTypePhone.description = self.screenModeManager.entity.person.person_ContactType[1].description;
            _personContactTypePhone.idPerson = self.screenModeManager.entity.person.idPerson;

            self.screenModeManager.entity.person.person_ContactType.push(_personContactTypeEmail);*/
            if (self.baseController.isNullOrUndefined(self.screenModeManager.entity.person) && self.screenModeManager.entity.person.person_ContactType.length > 0) {
                self.screenModeManager.entity.person.person_ContactType[1].idContactType = 1; //phone
                self.screenModeManager.entity.person.person_ContactType[0].idContactType = 2; //mail
            }
            
        } else {
            /*var _companyContactTypePhone: company_ContactTypeModel = new company_ContactTypeModel();
            _companyContactTypePhone.idContactType = 1;
            _companyContactTypePhone.description = self.screenModeManager.entity.company.company_ContactType[0].description;
            _companyContactTypePhone.idCompany = self.screenModeManager.entity.company.idCompany;

            self.screenModeManager.entity.company.company_ContactType.push(_companyContactTypePhone);

            var _companyContactTypeEmail: company_ContactTypeModel = new company_ContactTypeModel();
            _companyContactTypeEmail.idContactType = 2;
            _companyContactTypeEmail.description = self.screenModeManager.entity.company.company_ContactType[1].description;
            _companyContactTypeEmail.idCompany = self.screenModeManager.entity.company.idCompany;

            self.screenModeManager.entity.company.company_ContactType.push(_companyContactTypeEmail);*/
            if (self.baseController.isNullOrUndefined(self.screenModeManager.entity.company) && self.screenModeManager.entity.company.company_ContactType.length > 0) {
                self.screenModeManager.entity.company.company_ContactType[1].idContactType = 1; //phone
                self.screenModeManager.entity.company.company_ContactType[0].idContactType = 2; //mail
            }
        }

        //self.screenModeManager.entity.person.person_ContactType = self.administrationNewCustomerController.person_contactType;

        _saveAdministrationCustomerDto.customer = self.screenModeManager.entity;
        if (self.baseController.isNullOrUndefined(_saveAdministrationCustomerDto.customer.idCustomerType)) {
            self.baseController.showMessage("Please enter title", "Warning", ALERT_MESSAGE_TYPE.WARNING, false, () => { return; });
        }

        self.administrationCustomerWebService.saveAdministrationCustomer(_saveAdministrationCustomerDto)
            .then(function (response: baseResultReturnType<saveAdministrationCustomerReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.screenModeManager.setEntity(response.result.customer);
                    self.onCustomerDetailLoaded();
                    self.baseController.showMessage("Saved successfully", "", ALERT_MESSAGE_TYPE.SUCCESS, null, () => {
                        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationCustomer/AdministrationCustomerListing/";
                    });
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }

            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
                self.screenModeManager.setMode(SCREEN_MODE.EDIT);
            }).finally(function () {
                self.baseController.hideLoading();
            });
        self.screenModeManager.setMode(SCREEN_MODE.EDIT);
    }

    public registerValidations() {
        var self = this;
        for (var i = 0; i < self.childControllers.length; i++) {
            var currentChild = self.childControllers[i];
            currentChild.registerValidations();
        }
    }

    public validateForGroups(): boolean {
        var self = this;
        var isValid: boolean = true;
        var formScope = self.scope['profileForm'];

        var errorMessages: string[] = [];
        for (var i = 0; i < self.childControllers.length; i++) {
            var currentChild = self.childControllers[i];
            isValid = isValid && currentChild.formValidator.validateGroup(currentChild.groupName, false, true);
            errorMessages = errorMessages.concat(currentChild.formValidator.getAllValidationMessagesForGroup(currentChild.groupName));
        }

        if (errorMessages.length > 0) {
            self.baseController.toaster.pop({
                type: 'error',
                body: errorMessages.join('</br>'),
                bodyOutputType: 'trustedHtml'
            });
        }

        return isValid;
    }

    public idGroupValid(profileTab: customerTab): boolean {
        var self = this;
        let isValid: boolean = true;

        let groupName = customerTabNameFromEnum.getName(profileTab);
        let childValidator: IChildAdministrationCustomerDetailController = Enumerable.From(self.childControllers).Where(function (childController: IChildAdministrationCustomerDetailController) {
            return childController.groupName == groupName
        }).FirstOrDefault(null);

        if (childValidator != null && childValidator.hasCustomerDetailBeenLoaded) {
            isValid = childValidator.formValidator.validateGroup(groupName, false)
        }

        return isValid;
    }


    public loadScreenConstants() {
        var self = this;
        self.administrationCustomerWebService.getAdministrationCustomerScreenConstant()
            .then(function (response: baseResultReturnType<administrationCustomerScreenContantReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {

                    self.preloadedData.customerTypes = response.result.customerTypes;
                    self.preloadedData.titles = response.result.titles;
                    self.preloadedData.countries = response.result.countries;
                    self.preloadedData.contactTypes = response.result.contactTypes;
                    self.onScreenDetailLoaded();
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    }

    public assignValuesToCustomer(customer: customerModel): customerModel {
        var self = this;

        return customer;
    }

    public onCustomerDetailLoaded() {
        var self = this;
        self.hasCustomerDetailBeenLoaded = true;
        self.onAllDetailLoaded();
    }

    public onScreenDetailLoaded() {
        var self = this;
        self.hasScreenDetailBeenLoaded = true;
        self.onAllDetailLoaded();
    }

    public onAllDetailLoaded() {
        var self = this;

        if (self.hasCustomerDetailBeenLoaded && self.hasScreenDetailBeenLoaded) {
            self.assignObjectsIfRequired();
            self.childControllers.forEach(function (controller: IChildAdministrationCustomerDetailController) {
                controller.onDetailLoaded();
            })
        }
    }

    public assignObjectsIfRequired() {
        var self = this;

        if (!self.baseController.isNullOrUndefined(self.screenModeManager.entity)
            && !self.baseController.isNullOrUndefined(self.screenModeManager.entity.idCustomerType) && self.baseController.isNullOrUndefined(self.screenModeManager.entity.customerType)) {
            self.screenModeManager.entity.customerType = Enumerable.From(self.preloadedData.customerTypes).Where(function (cutomerType: customerTypeModel) {
                return cutomerType.idCustomerType == self.screenModeManager.entity.idCustomerType
            }).FirstOrDefault(null);
        }


        if (!self.baseController.isNullOrUndefined(self.screenModeManager.entity)
            && !self.baseController.isNullOrUndefined(self.screenModeManager.entity.person) && !self.baseController.isNullOrUndefined(self.screenModeManager.entity.person.person_ContactType)) {
            Enumerable.From(self.screenModeManager.entity.person.person_ContactType).ForEach(function (person_ContactType: person_ContactTypeModel) {
                if (!self.baseController.isNullOrUndefined(person_ContactType.idContactType) && self.baseController.isNullOrUndefined(person_ContactType.contactType)) {
                    person_ContactType.contactType = Enumerable.From(self.preloadedData.contactTypes).Where(function (contactType: contactTypeModel) {
                        return contactType.idContactType == person_ContactType.idContactType
                    }).FirstOrDefault(null);
                }
            })
        }

        if (!self.baseController.isNullOrUndefined(self.screenModeManager.entity)
            && !self.baseController.isNullOrUndefined(self.screenModeManager.entity.company) && !self.baseController.isNullOrUndefined(self.screenModeManager.entity.company.company_ContactType)) {
            Enumerable.From(self.screenModeManager.entity.company.company_ContactType).ForEach(function (company_ContactType: company_ContactTypeModel) {
                if (!self.baseController.isNullOrUndefined(company_ContactType.idContactType) && self.baseController.isNullOrUndefined(company_ContactType.contactType)) {
                    company_ContactType.contactType = Enumerable.From(self.preloadedData.contactTypes).Where(function (contactType: contactTypeModel) {
                        return contactType.idContactType == company_ContactType.idContactType
                    }).FirstOrDefault(null);
                }
            })
        }
    }

    public onOkToModal() {
        var self = this;
        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.TRANSFER, "CUSTOMER", self.screenModeManager.entity)
        self.scope.$close(self.baseController.globalVariableFactory.sessionVariables);
    }

    public onCancelToModal() {
        var self = this;
        self.scope.$dismiss();
    }
}


enum customerTab {
    BASIC = 1,
}

class customerTabNameFromEnum {
    static getName(_customerTab: customerTab) {
        let name: string;

        switch (_customerTab) {
            case customerTab.BASIC:
                name = 'basicInfo';
                break;
        }
        return name;
    }
}

administrationCustomerModule.controller("administrationCustomerController"
    , ["$scope"
        , "administrationCustomerWebService"
        , administrationCustomerController
    ]);
