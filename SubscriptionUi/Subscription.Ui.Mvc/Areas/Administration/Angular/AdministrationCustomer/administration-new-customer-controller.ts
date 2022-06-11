class administrationNewCustomerController implements IChildAdministrationCustomerDetailController {
    scope;
    baseController: baseController;
    fileManager: fileManager
    callerController: IAdministrationCustomerDetailBasicInfoCaller;
    pictureTypeEnum;
    groupName: string = customerTabNameFromEnum.getName(customerTab.BASIC);

    formValidator: formValidator;
    addressPublicUtilityService: addressPublicUtilityService;
    chosenPlace: any;
    companyCategorySearch: string;
    customerTypeEnum;

    person_contactType: person_ContactTypeModel[];

    contactTypeForEntity: {
        contactType: contactTypeModel,
        contactTypes: any[],
    }[] = [];

    constructor(private $scope
        , private $parse
        , private toaster
        , private moment
        , fileManager
        , addressPublicUtilityService
    ) {

        this.scope = $scope;
        this.scope.controller = this;
        this.callerController = $scope.$parent.controller;
        this.fileManager = fileManager;
        this.addressPublicUtilityService = addressPublicUtilityService;
        this.baseController = $scope.baseController;
        this.callerController.registerAdministrationCustomerDetailBasicInfoController(this);
        this.initialize();
    }

    get address(): addressModel {
        var self = this;
        if (!self.hasCustomerDetailBeenLoaded) {
            return;
        }
        var address: addressModel;

        if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
            if (self.customer.company.companyLocations.length == 0) {
                address = new addressModel();
                var companyLocation: companyLocationModel = new companyLocationModel();
                companyLocation.address = address;
                self.customer.company.companyLocations.push(companyLocation);
            } else {
                address = self.customer.company.companyLocations[0].address;
            }
        }
        else if (self.customer.idCustomerType == customerTypeEnum.PERSON) {
            if (!self.baseController.isNullOrUndefined(self.customer.person)) {
                if (self.customer.person.person_Address.length == 0) {
                    address = new addressModel();
                    var person_Address: person_AddressModel = new person_AddressModel();
                    person_Address.address = address;
                    self.customer.person.person_Address.push(person_Address);
                } else {
                    address = self.customer.person.person_Address[0].address;
                }
            }
        }
        return address;
    }

    set address(value: addressModel) {
        var self = this;
        self.address = value;
    }
    //---
    get email(): string {
        var self = this;
        var _email: string;
        if (!self.baseController.isNullOrUndefined(self.customer)) {
            if (self.customer.idCustomerType == 2 && self.customer.person.person_ContactType.length > 0) {
                self.customer.person.person_ContactType.forEach((contactType) => {
                    if (contactType.idContactType == 2) {
                        _email = contactType.description;
                    }
                });
            } else {
                self.customer.company.company_ContactType.forEach((contactType) => {
                    if (contactType.idContactType == 2) {
                        _email = contactType.description;
                    }
                });
            }
        }
        return _email;
    }

    set email(value: string) {
        var self = this;
        self.email = value;
    }

    get phone(): string {
        var self = this;
        var _phone: string;
        if (!self.baseController.isNullOrUndefined(self.customer)) {
            if (self.customer.idCustomerType == 1 && self.customer.person.person_ContactType.length > 0) {
                self.customer.person.person_ContactType.forEach((contactType) => {
                    if (contactType.idContactType == 2) {
                        _phone = contactType.description;
                    }
                });
            } else {
                self.customer.company.company_ContactType.forEach((contactType) => {
                    if (contactType.idContactType == 2) {
                        _phone = contactType.description;
                    }
                });
            }
        }
        return _phone;
    }

    set phone(value: string) {
        var self = this;
        self.phone = value;
    }
    //---
    get screenMode(): SCREEN_MODE {
        return this.callerController.screenModeManager.currentMode;
    }

    set customer(customer: customerModel) {
        this.customer = customer;
    }

    get customer(): customerModel {
        return this.callerController.screenModeManager.entity;
    }

    get customerTypes(): customerTypeModel[] {
        return this.callerController.preloadedData.customerTypes;
    }
    get titles(): titleModel[] {
        return this.callerController.preloadedData.titles;
    }
    get countries(): countryModel[] {
        return this.callerController.preloadedData.countries;
    }
    get hasCustomerDetailBeenLoaded(): boolean {
        return this.callerController.hasCustomerDetailBeenLoaded;
    }
    get formName(): string {
        return this.callerController.formName;
    }
    get contactTypes(): contactTypeModel[] {
        return this.callerController.preloadedData.contactTypes;
    }

    public initialize() {
        var self = this;
        self.registerValidations();
        self.customerTypeEnum = customerTypeEnum;
        //if (!self.baseController.isNullOrUndefined(self.callerController.screenModeManager.entity)) {
        //    self.person_contactType = self.callerController.screenModeManager.entity.person.person_ContactType;
        //}
    }

    public registerValidations() {
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
            } else if (self.customer.person.nationalIdentificationNumber.length > 14){
                return true;
            }
        });

        self.formValidator.registerValidation('title', 'Please enter title', function () {
            if (self.baseController.isNullOrUndefined(self.customer.idCustomerType)) {
                return false;
            } else {
                if (self.customer.idCustomerType == customerTypeEnum.PERSON) {
                    return !self.baseController.isNullOrUndefined(self.customer.idCustomerType)
                }
                return true;
            }
        });


        self.formValidator.registerValidation('entityName', 'Please enter customer name', function () {
            if (self.baseController.isNullOrUndefined(self.customer.idCustomerType)) {
                return false;
            } else {
                if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
                    return !self.baseController.isNullOrUndefined(self.customer.company.name)
                } else {
                    return !self.baseController.isNullOrUndefined(self.customer.person.firstname)
                }
            }
        });

        self.formValidator.registerGroupValidation(self.groupName, ['customerType', 'title', 'entityName', 'country'])
    }

    public onDetailLoaded() {
        var self = this;
        self.refreshContactType();
    }

    public onCustomerTypeSelected(item: customerTypeModel) {
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
    }

    public onTitleSelected(item: titleModel) {
        var self = this;
        self.customer.person.idTitle = item.idTitle;
    }

    public onCountrySelected(item: countryModel) {
        var self = this;
        self.address.idCountry = item.idCountry;
    }

    public refreshContactType() {
        var self = this;
        if (!self.hasCustomerDetailBeenLoaded || self.baseController.isNullOrUndefined(self.customer.idCustomerType))
            return;

        self.contactTypeForEntity = [];
        Enumerable.From(self.contactTypes).Where(function (contactType: contactTypeModel) {
            return contactType.idParentContactType == null
        }).ForEach(function (contactType: contactTypeModel) {
            self.contactTypeForEntity.push({
                contactType: contactType,
                contactTypes: self.getEntityTypeForContactType(contactType)
            })
        });
    }



    public getEntityTypeForContactType(contactType: contactTypeModel) {
        var self = this;
        var defaultContactType: contactTypeModel = self.getDefaultContactTypeForParent(contactType);
        var contactTypes = [];
        var contactTypeFromEntities: any[];

        if (!self.hasCustomerDetailBeenLoaded || self.baseController.isNullOrUndefined(self.customer.idCustomerType))
            return;

        if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
            contactTypes = self.customer.company.company_ContactType;
        } else {
            contactTypes = self.customer.person.person_ContactType;
        }

        if (defaultContactType == null) {//no default contact type available, mail for example
            contactTypeFromEntities = Enumerable.From(contactTypes).Where(function (contactTypeFromEntity: any) {
                return contactTypeFromEntity.idContactType == contactType.idContactType;
            }).ToArray();
        } else {//get all for the contact type whose parent is same as contactType parameter
            contactTypeFromEntities = Enumerable.From(contactTypes).Where(function (contactTypeFromEntity: any) {
                return contactTypeFromEntity.contactType.idParentContactType == contactType.idContactType;
            }).ToArray();
        }

        return contactTypeFromEntities;
    }

    public addEntity_ContactType(contactType: contactTypeModel) {
        var self = this;
        var entity_ContactType: any = {};

        var idLocalName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idLocalCompany_ContactType" : "idLocalPerson_ContactType";
        var idName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idCompany_ContactType" : "idPerson_ContactType"

        entity_ContactType[idLocalName] = self.baseController.generateUUID();
        var defaultContactType: contactTypeModel = self.getDefaultContactTypeForParent(contactType);
        if (defaultContactType != null) {
            entity_ContactType.idContactType = defaultContactType.idContactType;
            entity_ContactType.contactType = defaultContactType;
        } else {
            entity_ContactType.idContactType = contactType.idContactType;
            entity_ContactType.contactType = contactType;
        }

        if (self.customer.idCustomerType == customerTypeEnum.COMPANY) {
            self.customer.company.company_ContactType.push(entity_ContactType);
        } else {
            self.customer.person.person_ContactType.push(entity_ContactType);
        }
        console.log(entity_ContactType);
        self.refreshContactType();
    }

    private getDefaultContactTypeForParent(contactType: contactTypeModel) {
        var self = this;
        return Enumerable.From(self.contactTypes).Where(function (_contactType: contactTypeModel) {
            return _contactType.idParentContactType == contactType.idContactType
        }).FirstOrDefault(null);
    }

    public isContactTypeHiearchycal(contactType: contactTypeModel) {
        var self = this;
        return self.getDefaultContactTypeForParent(contactType) != null;
    }

    public onContactTypeSelected(contactType: contactTypeModel, entity_ContactType: any) {
        var self = this;
        entity_ContactType.idContactType = contactType.idContactType;
    }

    public removeEntity_ContactType(entity_ContactType: any) {
        var self = this;
        var idLocalName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idLocalCompany_ContactType" : "idLocalPerson_ContactType";
        var idName = self.customer.idCustomerType == customerTypeEnum.COMPANY ? "idCompany_ContactType" : "idPerson_ContactType"
        var entity: any = self.customer.idCustomerType == customerTypeEnum.COMPANY ? self.customer.company.company_ContactType : self.customer.person.person_ContactType;

        var position: number = self.baseController.searchForEntityInList(idName, entity, entity_ContactType, idLocalName);
        entity.splice(position, 1);
        self.refreshContactType();
    }

}

administrationCustomerModule.controller("administrationNewCustomerController"
    , ["$scope"
        , "$parse"
        , "toaster"
        , "moment"
        , "fileManager"
        , administrationNewCustomerController
    ]);
