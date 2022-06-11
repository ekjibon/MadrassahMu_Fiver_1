interface IChildAdministrationCustomerDetailController {
    formValidator: formValidator;
    baseController: baseController;
    onDetailLoaded();
    hasCustomerDetailBeenLoaded: boolean;
    groupName: string;
    registerValidations();
}

interface IAdministrationCustomerDetailBasicInfoCaller {
    screenModeManager: screenModeManager<customerModel, administrationCustomerController>;
    registerAdministrationCustomerDetailBasicInfoController(administrationNewCustomerController: administrationNewCustomerController);
    preloadedData: {
        customerTypes: customerTypeModel[],
        titles: titleModel[],
        countries: countryModel[],
        contactTypes: contactTypeModel[]
    }
    hasCustomerDetailBeenLoaded: boolean;
    formName: string;
}