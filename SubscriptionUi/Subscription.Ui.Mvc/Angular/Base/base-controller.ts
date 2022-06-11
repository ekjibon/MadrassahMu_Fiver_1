class baseController {
    $scope;
    $rootScope;
    $location;
    $anchorScroll;
    $localStorage;
    $window;
    $timeout;
    $uibModal;
    $document;
    $parse;
    layoutCustomisation: layoutCustomisation;
    SweetAlert;
    toaster;
    globalVariableFactory: globalVariableFactory;
    isCpfLoadingInProgress: boolean = false;
    modalInstanceForLoading = null;
    isFooterShown: boolean = false;
    pageSizeList: any[];
    pageSizeLargerList: any[];
    q: ng.IQService;
    state: string;
    moment;
    permissionManager: permissionManager;
    actionName: string;
    areaName: string;
    confirmBtnColor: string;
    datePickersState;
    ckeditorOptions;
    datepickerOptions;
    formWizard: {
        form: any,
        currentStep: number
        validationForStep?: {},
        controller: any
    }
    columnEnums: any;
    modeEnums;
    loginStatusEnum;
    roleEnum;
    authenticationTypeEnum;
    isInitialized: boolean = false;
    loadedControllerInstances: { controllerName: string, instance: any }[] = [];
    loadedControllerInstancesListeners: { controllerName: string, listeners: any[] }[] = [];
    authenticationFactory: authenticationFactory;
    fileWebService: fileWebService;
    fileManager: fileManager;

    fileTypes: fileTypeReturnType[];
    areFileTypeBeingLoaded: boolean = false;
    fileUploadStates: fileUploadStateModel[] = [];
    test: string = "baseController - testing to see if it works";

    loadingMessages: string = "";
    signalR;
    stickyBlockMessage: stickyMessage = new stickyMessage();
    constructor(
        $scope,
        $rootScope,
        $location,
        $anchorScroll,
        $localStorage,
        $window,
        $timeout,
        $uibModal,
        $q,
        $document,
        $parse,
        SweetAlert,
        toaster,
        moment,
        globalVariableFactory: globalVariableFactory,
        permissionManager: permissionManager,
        authenticationFactory: authenticationFactory,
        fileWebService: fileWebService,
        fileManager: fileManager,
        signalR
    ) {
        $scope.baseController = this;
        this.$scope = $scope;
        this.$rootScope = $rootScope;
        this.$location = $location;
        this.$anchorScroll = $anchorScroll;
        this.$localStorage = localStorage;
        this.$window = $window;
        this.$timeout = $timeout;
        this.$uibModal = $uibModal;
        this.$document = $document;
        this.$parse = $parse;
        this.SweetAlert = SweetAlert;
        this.toaster = toaster;
        this.moment = moment;
        this.globalVariableFactory = globalVariableFactory;
        this.permissionManager = permissionManager;
        this.authenticationFactory = authenticationFactory;
        this.fileWebService = fileWebService;
        this.fileManager = fileManager;
        this.q = $q;
        this.signalR = signalR;

        this.initializeVariables();
    }

    public initializeVariables() {
        var self = this;
        self.initializeTemplate();
        self.pageSizeList = [
            { text: "10", value: 10 }
            , { text: "20", value: 20 }
            , { text: "30", value: 30 }
            , { text: "50", value: 50 }
            , { text: "100", value: 100 }
        ];
        self.pageSizeLargerList = [
            { text: "100", value: 100 }
            , { text: "200", value: 200 }
            , { text: "400", value: 400 }
        ];
        self.columnEnums =
        {
        };
        self.datePickersState = [];
        self.modeEnums = SCREEN_MODE;
        self.authenticationTypeEnum = authenticationTypeEnum;
        self.getState();
        self.getAction();
        self.getAreaName();

        self.ckeditorOptions = {
            language: 'en',
            allowedContent: true,
            entities: false,
            readOnly: false
        };

        self.datepickerOptions = {
            showWeeks: false
        }

        //self.getLoggedUser();
        self.confirmBtnColor = "";

    }

    public initializeSignalR(idUser: string, idConnectionType: SIGNALR_CONNECTION_TYPE) {
        var self = this;

        self.signalR.setHubName("messageHub");
        self.signalR.connectToHub();
        if (self.signalR.isServerUp) {
            var canConnect: boolean = false;
            self.signalR.client().broadcastMessage = function (messageContent) {
                self.showSignalRBroadcastMessage(messageContent);
            };

            if (idConnectionType == SIGNALR_CONNECTION_TYPE.OTHER) {
                canConnect = true;
            }

            if (idConnectionType == SIGNALR_CONNECTION_TYPE.USER && self.globalVariableFactory.isUserLoggedIn) {
                canConnect = true;
            }

            if (canConnect) {
                self.signalR.start(function () {
                    self.signalR.server().subscribe({ "IdConnection": idUser, "IdConnectionType": idConnectionType });
                });
            }
        }
    }

    public sendMessageSignalR(message: string) {
        var self = this;
        self.signalR.start(function () {
            self.signalR.server().send(message);
        });
    }

    public showSignalRBroadcastMessage(messageContent) {
        var self = this;
        self.$timeout(function () {
            self.showToast(TOASTER_TYPE.INFO, "Broadcast Message", messageContent);
        }, 1000)
    }

    public showSignalRMessage(messageType: SIGNALR_MESSAGE_TYPE, messageContent) {
        var self = this;
        var messageHeader: string = "";
        var shouldShowToast: boolean = false;

        if (messageType == SIGNALR_MESSAGE_TYPE.FLIPBOOK_COVERSION_COMPLETED) {
            messageHeader = "FlipBook";
            shouldShowToast = true;
            self.stickyBlockMessage.clearBlock('SIGNALR-' + SIGNALR_MESSAGE_TYPE.FLIPBOOK_COVERSION_PROGRESS);
        }

        else if (messageType == SIGNALR_MESSAGE_TYPE.FLIPBOOK_COVERSION_PROGRESS) {
            self.stickyBlockMessage.clearBlock('SIGNALR-' + SIGNALR_MESSAGE_TYPE.FLIPBOOK_COVERSION_PROGRESS);
            self.stickyBlockMessage.addMessage(messageContent, 'SIGNALR-' + SIGNALR_MESSAGE_TYPE.FLIPBOOK_COVERSION_PROGRESS);
        }

        if (shouldShowToast) {
            self.$timeout(function () {
                self.showToast(TOASTER_TYPE.INFO, messageHeader, messageContent);
            }, 1000)
        }

    }

    public getBaseLocation(): geoLocation {
        var self = this;
        if (window.localStorage.getItem("CenterLocation") == null) {
            var _geolocation: geoLocation = new geoLocation();
            navigator.geolocation.getCurrentPosition(function (location) {
                _geolocation.lat = location.coords.latitude;
                _geolocation.lng = location.coords.longitude;
                _geolocation.zoom = 10;
                window.localStorage.setItem("CenterLocation", JSON.stringify(_geolocation));
            }, function (error) {
                alert("Please enable location on browser");
            }, { timeout: 10000 });
        } else {
            var geoString = window.localStorage.getItem("CenterLocation");
            _geolocation = JSON.parse(geoString);
        }
        return _geolocation;
    }


    public addLoadedControllerInstance(controllerInstance: { controllerName: string, instance: any }) {
        var self = this;
        self.loadedControllerInstances.push(controllerInstance);
        self.notifyListenersForLoadedController(controllerInstance);
    }

    public getOrAddToListenerControllerInstance(listenerControllerInstance: { controllerName: string, listener: any }) {
        var self = this;
        var instance: { controllerName: string, instance: any } = Enumerable.From(self.loadedControllerInstances).Where(function (_listenerControllerInstance: { controllerName: string, instance: any }) {
            return _listenerControllerInstance.controllerName == listenerControllerInstance.controllerName
        }).FirstOrDefault(null);

        if (instance == null) {
            self.addToListenerControllerInstance(listenerControllerInstance);
        } else {
            return instance.instance;
        }
    }

    public notifyListenersForLoadedController(controllerInstance: { controllerName: string, instance: any }) {
        var self = this;
        var listenerList: any[] = Enumerable.From(self.loadedControllerInstancesListeners).Where(function (listener: { controllerName: string, listeners: any[] }) {
            return listener.controllerName == controllerInstance.controllerName;
        }).FirstOrDefault(null);

        if (listenerList != null) {
            listenerList.forEach(function (listener) {
                listener(controllerInstance.instance)
            })
        }
    }

    public addToListenerControllerInstance(listener: { controllerName: string, listener: any }) {
        var self = this;
        var listenerList: any[] = Enumerable.From(self.loadedControllerInstancesListeners).Where(function (listener: { controllerName: string, listeners: any[] }) {
            return listener.controllerName == listener.controllerName;
        }).FirstOrDefault(null);

        if (listenerList == null) {
            self.loadedControllerInstancesListeners.push({ controllerName: listener.controllerName, listeners: [] })
        } else {
            listenerList.push(listener.listener);
        }
    }

    public initializeTemplate() {
        var self = this;
        //self.layoutCustomisation = JSON.parse(self.$window.sessionStorage.getItem(CUSTOM_VARIABLES.LAYOUT));
        //if (self.isNullOrUndefined(self.layoutCustomisation)) {
        //    self.$window.sessionStorage.setItem(CUSTOM_VARIABLES.LAYOUT, JSON.stringify(self.$rootScope.app));
        //    self.layoutCustomisation = self.$rootScope.app;;
        //}
    }

    public saveTemplateLayout() {
        var self = this;
        self.$window.sessionStorage.setItem(CUSTOM_VARIABLES.LAYOUT, JSON.stringify(self.layoutCustomisation));
    }

    public initFormWizard(form: any, validationForStep: any, controller: any) {
        var self = this;
        self.formWizard = {
            form: form,
            currentStep: 1,
            validationForStep: validationForStep,
            controller: controller
        };
    }

    public formWizardNext() {
        var self = this;
        self.toTheTop();
        if (self.validateForm(self.formWizard.form) && self.execValidationsForStep(self.formWizard.currentStep)) {
            self.formWizardNextStep();
        }
    }

    public formWizardPrevious() {
        var self = this;
        self.toTheTop();
        self.formWizardPrevStep();
    }
    public formWizardGoTo(step: number) {
        var self = this;

        if ((self.formWizard.currentStep) > (step)) { //go back
            self.toTheTop();
            self.formWizardGoToStep(step);

        } else {
            if (self.validateForm(self.formWizard.form) && self.execValidationsForStep(self.formWizard.currentStep)) { //go next
                self.toTheTop();
                self.formWizardGoToStep(step);
            }
        }
    }
    public formWizardSubmit() {

    }
    public formWizardReset() {

    }

    public formWizardNextStep() {
        var self = this;
        self.formWizard.currentStep++;
    }

    public formWizardPrevStep() {
        var self = this;
        self.formWizard.currentStep--;
    }

    public formWizardGoToStep(step: number) {
        var self = this;
        self.formWizard.currentStep = step;
    }
    public execValidationsForStep(step: number) {
        var self = this;
        if (!self.isNullOrUndefined(self.formWizard.validationForStep) && !self.isNullOrUndefined(self.formWizard.validationForStep[step])) {
            for (var i = 0; i < self.formWizard.validationForStep[step].validations.length; i++) {
                var isCurrentValid = self.formWizard.validationForStep[step].validations[i](self.formWizard.controller);
                if (!isCurrentValid) {
                    return false;
                }
            }
        }
        return true;
    }

    public toTheTop() {
        var self = this;
        self.$document.scrollTopAnimated(0, 600);
    }

    public showFooter() {
        this.isFooterShown = true;
    }

    public hideFooter() {
        this.isFooterShown = true;
    }

    public showMessage(message: string, title: string, messageType: string, showCancelButton: boolean = false, okCallback = null, isHtml = false, okButtonText = "Ok", cancelButttonText = "Cancel", cancelCallback = null, caller = null, params: any = null) {
        var self = this;

        if (messageType == ALERT_MESSAGE_TYPE.ERROR && self.isNullOrUndefined(isHtml))
            isHtml = true;

        if (messageType == ALERT_MESSAGE_TYPE.WARNING || messageType == ALERT_MESSAGE_TYPE.ERROR) {
            self.confirmBtnColor = "#da4f4a";
        } else {
            self.confirmBtnColor = "#3b8a32 ";
        }

        self.SweetAlert.swal({
            title: title,
            text: message,
            type: messageType,
            showCancelButton: showCancelButton,
            confirmButtonColor: self.confirmBtnColor,
            confirmButtonText: okButtonText,
            cancelButtonText: cancelButttonText,
            html: isHtml
        }, function (isConfirm) {
            if (isConfirm) {
                if (okCallback != null)
                    okCallback(caller, params);
            } else {
                if (cancelCallback != null)
                    cancelCallback(caller);
            }
        });
    }

    public showCustomModal(modalController, modalTemplateUrl, caller, dataToPass, onOk, onCancel = function () { }, size = 'lg', backdrop = '', cssClass = '', shouldShareSameScope = false) {
        var self = this;
        var modalData: any = {
            templateUrl: modalTemplateUrl,
            controller: modalController,
            size: size,
            backdrop: backdrop,
            windowClass: cssClass,
            resolve: {
                dataToPass: function () {
                    return dataToPass;
                },
                caller: function () {
                    return caller;
                },
                baseController: function () {
                    return self
                }
            }
        }
        if (shouldShareSameScope) {
            modalData.scope = self.$scope
        }
        var modalInstance = self.$uibModal.open(modalData);

        modalInstance.result.then(onOk, onCancel);
        return modalInstance;
    }

    public showLoading() {
        var self = this;
        if (self.modalInstanceForLoading == null) {
            self.modalInstanceForLoading = self.$uibModal.open({
                template: '<div class="modal-body" ><img src="' + self.globalVariableFactory.baseServerUrl + '/Content/Images/loader.svg" style="width:125px;"></div>',
                backdrop: 'static',
                windowClass: 'loading-center-modal'
            });
        }
    }

    public hideLoading() {
        var self = this;
        if (self.modalInstanceForLoading != null) {
            self.modalInstanceForLoading.close();
            self.modalInstanceForLoading = null;
        }
    }

    public showToast(toasterType: TOASTER_TYPE, toasterTitle: string, toasterText: string = "") {       
        this.toaster.pop(toasterType, toasterTitle, toasterText);
        //self.toaster.error("An error occured!");
        //console.log(toasterType + "  --  " + toasterTitle + "  --  " + toasterText);
        //this.toaster.info(toasterText, toasterTitle)
    }

    public isNullOrUndefined(val) {
        return angular.isUndefined(val) || val == null;
    }

    public getAbbreviation(word: string) {
        return word.toUpperCase().match(/\b\w/g).join('');
    }

    public validateForm(form) {
        var firstError = null;
        var isFormValid = true;
        if (form.$invalid) {
            var field = null, firstError = null;
            for (field in form) {
                if (field[0] != '$') {
                    if (firstError === null && !form[field].$valid) {
                        firstError = form[field].$name;
                        isFormValid = false;
                    }

                    if (form[field].$pristine) {
                        form[field].$dirty = true;
                    }
                }
            }
            angular.element('.ng-invalid[name=' + firstError + ']').focus();
            this.showMessage("Errors are marked with a red, dashed border!", "The form cannot be submitted because it contains validation errors!", ALERT_MESSAGE_TYPE.WARNING);
        }
        return isFormValid;
    }

    public searchForEntityInList(entityIdName: string, list: any[], comparisonCriteria, localIdName: string = null): number {
        var hasEntityBeenFound = false;
        var positionOfEntity = null;
        list.some(function (value, index, array) {
            if (value[entityIdName] != null && value[entityIdName] != undefined && value[entityIdName] == comparisonCriteria[entityIdName]) {
                positionOfEntity = index;
                hasEntityBeenFound = true;
                return positionOfEntity;
            }
        });

        if ((localIdName != null && localIdName != undefined) || hasEntityBeenFound) {
            if (!hasEntityBeenFound) {
                positionOfEntity = this.searchForEntityInList(localIdName, list, comparisonCriteria);
                return positionOfEntity;
            } else {
                return positionOfEntity;
            }
        } else {
            return null;
        }
    }

    public cloneObject(obj) {
        return JSON.parse(JSON.stringify(obj), dateParser.dateParserScreenMode);
    }

    public getState() {
        this.state = eval('controllerName');
    }
    public getAction() {
        this.actionName = eval('actionName');
    }
    public getAreaName() {
        this.areaName = eval('areaName');
    }

    public generateUUID() { // Public Domain/MIT
        return commonUtility.generateUUID();
    }

    public toggleDatePicker(id: string) {
        var self = this;
        if (self.isNullOrUndefined(self.datePickersState[id])) {
            self.datePickersState[id] = true;
        } else {
            self.datePickersState[id] = !self.datePickersState[id];
        }
    }

    public getFileExtension(fileName: string): string {
        var self = this;
        var re = /(?:\.([^.]+))?$/;
        return re.exec(fileName)[1];
    }

    public logout() {
        var self = this;
        self.authenticationFactory.logOff()
            .then(function (response: boolean) {
                if (response) {
                    window.location.href = self.globalVariableFactory.baseServerUrl;
                } else {
                    self.toaster.error("An error occured!");
                }
            }).catch(function (errorResponse) {
                self.toaster.error(errorResponse);
            }).finally(function () {

            });
    }

    public getLoggedUser() {
        var self = this;
        self.authenticationFactory.getLoggedUser()
            .then(function (response: userWithoutConfidentialInfo) {
                self.globalVariableFactory.loggedInUserDetail = response;
            }).catch(function (errorResponse) {
                self.toaster.error(errorResponse);
            }).finally(function () {

            });
    }

    public redirectToUrlFromBase(url: string) {
        var self = this;
        self.$window.location = self.globalVariableFactory.baseServerUrl + "/" + url;
    }

    public getRandomColorCode() {
        var self = this;
        var letters = '0123456789ABCDEF';
        var color = '#';
        for (var i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    }

    public getThumbnailForPicture(document: documentModel, isProfileImage: boolean = false) {
        var self = this;

        var imageUrl;

        if (self.areFileTypeBeingLoaded) {
            return;
        }

        if (self.isNullOrUndefined(self.fileTypes)) {
            self.getFileTypeFromServer().then(function () {
                return self.getGenericFileThumbnailFromExtension(document, isProfileImage);
            }).catch(function () {
                return CUSTOM_VARIABLES.PROFILE_NO_IMAGE;
            })
        } else {
            return self.getGenericFileThumbnailFromExtension(document, isProfileImage);
        }
    }


    public getGenericFileThumbnailFromExtension(document: documentModel, isProfileImage: boolean = false): string {
        var self = this;
        let imageUrl: string = CUSTOM_VARIABLES.PROFILE_NO_IMAGE;
        let extension: string = null;

        if (self.isNullOrUndefined(document) || self.isNullOrUndefined(document.fileExtension) || self.isNullOrUndefined(document.serverFilePath) || self.isNullOrUndefined(document.parameter1)) {
            extension = "unknown";
        } else if (CUSTOM_VARIABLES.IMAGES_EXTENSION.indexOf(document.fileExtension.toLowerCase()) < 0) {
            extension = document.fileExtension.toLowerCase();
        } else {
            imageUrl = document.parameter1.paramaterValue + document.serverFilePath;
        }
        if (!self.isNullOrUndefined(extension) && !isProfileImage) {
            var fileType: fileTypeReturnType = Enumerable.From(self.fileTypes).Where(function (fileType: fileTypeReturnType) {
                return fileType.extension.indexOf(extension.toLowerCase()) >= 0
            }).FirstOrDefault(null);

            if (fileType != null) {
                imageUrl = fileType.serverUrl;
            }
        }

        return imageUrl;
    }

    public getFileTypeFromServer(): ng.IPromise<boolean> {
        var self = this;
        let deferred: angular.IDeferred<boolean> = self.q.defer();
        self.areFileTypeBeingLoaded = true;
        self.fileWebService.getFileType()
            .then(function (response: baseResultReturnType<fileTypeReturnType[]>) {
                self.areFileTypeBeingLoaded = false;
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.fileTypes = response.result;
                    deferred.resolve();
                } else {
                    self.showToast(TOASTER_TYPE.WARNING, "File thumbnail may not be loaded");
                    deferred.reject();
                }
            }).catch(function (errorMsg) {
                self.areFileTypeBeingLoaded = false;
                self.showToast(TOASTER_TYPE.WARNING, "File thumbnail may not be loaded");
                deferred.reject();
            }).finally(function () {
            });

        return deferred.promise;
    }

    public onPictureAdded(onPictureAddeds: onPictureAddedDto[], customUploadFunction = null): ng.IPromise<onPictureAddedDto[]> {
        var self = this;
        var deffered: angular.IDeferred<onPictureAddedDto[]> = self.q.defer();

        if (onPictureAddeds.length == 0)
            deffered.reject("No file to upload");

        var uploadDocumentListPerFiles: uploadDocumentListPerFileDto[] = [];

        Enumerable.From(onPictureAddeds).ForEach(function (onPictureAdded: onPictureAddedDto) {
            var fileUploadState: fileUploadStateModel = new fileUploadStateModel();
            fileUploadState.id = self.generateUUID();
            fileUploadState.isUploaded = false;
            self.fileUploadStates.push(fileUploadState);

            onPictureAdded.fileUploadState = fileUploadState;
            onPictureAdded.id = fileUploadState.id;

            var uploadDocumentListPerFile: uploadDocumentListPerFileDto = new uploadDocumentListPerFileDto();
            uploadDocumentListPerFile.file = onPictureAdded.file;
            uploadDocumentListPerFile.id = onPictureAdded.id;

            uploadDocumentListPerFiles.push(uploadDocumentListPerFile);
        })

        self.fileManager.uploadDocumentListPerFile(uploadDocumentListPerFiles, [], 0, null, customUploadFunction)
            .then(function (uploadedDocuments: uploadDocumentListPerFileReturnType[]) {
                onPictureUploaded(uploadedDocuments);
            })
            .catch(function (error: string) {
                onPictureUploadFailed(error);
            });

        function onPictureUploaded(uploadedDocuments: uploadDocumentListPerFileReturnType[]) {
            Enumerable.From(uploadedDocuments).ForEach(function (uploadedDocument: uploadDocumentListPerFileReturnType) {
                var pictureUploadStateFromArray: fileUploadStateModel = Enumerable.From(self.fileUploadStates).Where(function (_pictureUploadStateFromArray: fileUploadStateModel) {
                    return _pictureUploadStateFromArray.id == uploadedDocument.id;
                }).First();
                pictureUploadStateFromArray.isUploaded = true;

                var onPictureAdded: onPictureAddedDto = Enumerable.From(onPictureAddeds).Where(function (_onPictureAdded: onPictureAddedDto) {
                    return _onPictureAdded.id == uploadedDocument.id;
                }).First();

                onPictureAdded.document.fileExtension = uploadedDocument.document.fileExtension
                onPictureAdded.document.fileName = uploadedDocument.document.fileName
                onPictureAdded.document.idParameterBasePhysicalFilePath = uploadedDocument.document.idParameterBasePhysicalFilePath
                onPictureAdded.document.idParameterBaseServerUrl = uploadedDocument.document.idParameterBaseServerUrl
                onPictureAdded.document.parameter1 = uploadedDocument.document.parameter1
                onPictureAdded.document.physicalFilePath = uploadedDocument.document.physicalFilePath
                onPictureAdded.document.serverFilePath = uploadedDocument.document.serverFilePath
            });
            deffered.resolve(onPictureAddeds);
        }

        function onPictureUploadFailed(error: string) {
            deffered.reject(error);
        }

        return deffered.promise;
    }

    public areFilesPendingUpload() {
        var self = this;
        return Enumerable.From(self.fileUploadStates).Where(function (fileUploadState: fileUploadStateModel) {
            return fileUploadState.isUploaded = false
        }).Count() > 0;
    }
}

class onPictureAddedDto {
    file: File;
    id: string;
    document: documentModel;
    fileUploadState: fileUploadStateModel;
}

class stickyMessage {
    constructor() {
        var self = this;
        var _messages = sessionStorage.getItem("STICKY_MESSAGE_BLOCK");
        if (_messages != null || _messages != undefined) {
            this.messageGroup = JSON.parse(_messages);
        }

        this.messageGroup = {};
        setInterval(function () {
            angular.element(".permanent-message").html(self.getFormattedMessage);
        }, 1000);
    }

    get getFormattedMessage(): string {
        var self = this;
        var keys: string[] = Object.keys(self.messageGroup);

        var content = Enumerable.From(keys).Select(function (key: string) {
            return self.messageGroup[key].join(",");
        }).ToArray();
        return content.join('<br/>');
    }

    public addMessage(message: string, blockId: string) {
        var self = this;
        if (self.messageGroup[blockId] == null || self.messageGroup[blockId] == undefined) {
            self.messageGroup[blockId] = []
        }

        self.messageGroup[blockId].push(message);
    }

    public clearBlock(blockId: string) {
        var self = this;
        self.messageGroup[blockId] = [];
    }

    private messageGroup: {
        [groupName: string]: string[];
    };
}