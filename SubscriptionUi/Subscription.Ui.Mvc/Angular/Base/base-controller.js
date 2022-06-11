var baseController = /** @class */ (function () {
    function baseController($scope, $rootScope, $location, $anchorScroll, $localStorage, $window, $timeout, $uibModal, $q, $document, $parse, SweetAlert, toaster, moment, globalVariableFactory, permissionManager, authenticationFactory, fileWebService, fileManager, signalR) {
        this.isCpfLoadingInProgress = false;
        this.modalInstanceForLoading = null;
        this.isFooterShown = false;
        this.isInitialized = false;
        this.loadedControllerInstances = [];
        this.loadedControllerInstancesListeners = [];
        this.areFileTypeBeingLoaded = false;
        this.fileUploadStates = [];
        this.test = "baseController - testing to see if it works";
        this.loadingMessages = "";
        this.stickyBlockMessage = new stickyMessage();
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
    baseController.prototype.initializeVariables = function () {
        var self = this;
        self.initializeTemplate();
        self.pageSizeList = [
            { text: "10", value: 10 },
            { text: "20", value: 20 },
            { text: "30", value: 30 },
            { text: "50", value: 50 },
            { text: "100", value: 100 }
        ];
        self.pageSizeLargerList = [
            { text: "100", value: 100 },
            { text: "200", value: 200 },
            { text: "400", value: 400 }
        ];
        self.columnEnums =
            {};
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
        };
        //self.getLoggedUser();
        self.confirmBtnColor = "";
    };
    baseController.prototype.initializeSignalR = function (idUser, idConnectionType) {
        var self = this;
        self.signalR.setHubName("messageHub");
        self.signalR.connectToHub();
        if (self.signalR.isServerUp) {
            var canConnect = false;
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
    };
    baseController.prototype.sendMessageSignalR = function (message) {
        var self = this;
        self.signalR.start(function () {
            self.signalR.server().send(message);
        });
    };
    baseController.prototype.showSignalRBroadcastMessage = function (messageContent) {
        var self = this;
        self.$timeout(function () {
            self.showToast(TOASTER_TYPE.INFO, "Broadcast Message", messageContent);
        }, 1000);
    };
    baseController.prototype.showSignalRMessage = function (messageType, messageContent) {
        var self = this;
        var messageHeader = "";
        var shouldShowToast = false;
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
            }, 1000);
        }
    };
    baseController.prototype.getBaseLocation = function () {
        var self = this;
        if (window.localStorage.getItem("CenterLocation") == null) {
            var _geolocation = new geoLocation();
            navigator.geolocation.getCurrentPosition(function (location) {
                _geolocation.lat = location.coords.latitude;
                _geolocation.lng = location.coords.longitude;
                _geolocation.zoom = 10;
                window.localStorage.setItem("CenterLocation", JSON.stringify(_geolocation));
            }, function (error) {
                alert("Please enable location on browser");
            }, { timeout: 10000 });
        }
        else {
            var geoString = window.localStorage.getItem("CenterLocation");
            _geolocation = JSON.parse(geoString);
        }
        return _geolocation;
    };
    baseController.prototype.addLoadedControllerInstance = function (controllerInstance) {
        var self = this;
        self.loadedControllerInstances.push(controllerInstance);
        self.notifyListenersForLoadedController(controllerInstance);
    };
    baseController.prototype.getOrAddToListenerControllerInstance = function (listenerControllerInstance) {
        var self = this;
        var instance = Enumerable.From(self.loadedControllerInstances).Where(function (_listenerControllerInstance) {
            return _listenerControllerInstance.controllerName == listenerControllerInstance.controllerName;
        }).FirstOrDefault(null);
        if (instance == null) {
            self.addToListenerControllerInstance(listenerControllerInstance);
        }
        else {
            return instance.instance;
        }
    };
    baseController.prototype.notifyListenersForLoadedController = function (controllerInstance) {
        var self = this;
        var listenerList = Enumerable.From(self.loadedControllerInstancesListeners).Where(function (listener) {
            return listener.controllerName == controllerInstance.controllerName;
        }).FirstOrDefault(null);
        if (listenerList != null) {
            listenerList.forEach(function (listener) {
                listener(controllerInstance.instance);
            });
        }
    };
    baseController.prototype.addToListenerControllerInstance = function (listener) {
        var self = this;
        var listenerList = Enumerable.From(self.loadedControllerInstancesListeners).Where(function (listener) {
            return listener.controllerName == listener.controllerName;
        }).FirstOrDefault(null);
        if (listenerList == null) {
            self.loadedControllerInstancesListeners.push({ controllerName: listener.controllerName, listeners: [] });
        }
        else {
            listenerList.push(listener.listener);
        }
    };
    baseController.prototype.initializeTemplate = function () {
        var self = this;
        //self.layoutCustomisation = JSON.parse(self.$window.sessionStorage.getItem(CUSTOM_VARIABLES.LAYOUT));
        //if (self.isNullOrUndefined(self.layoutCustomisation)) {
        //    self.$window.sessionStorage.setItem(CUSTOM_VARIABLES.LAYOUT, JSON.stringify(self.$rootScope.app));
        //    self.layoutCustomisation = self.$rootScope.app;;
        //}
    };
    baseController.prototype.saveTemplateLayout = function () {
        var self = this;
        self.$window.sessionStorage.setItem(CUSTOM_VARIABLES.LAYOUT, JSON.stringify(self.layoutCustomisation));
    };
    baseController.prototype.initFormWizard = function (form, validationForStep, controller) {
        var self = this;
        self.formWizard = {
            form: form,
            currentStep: 1,
            validationForStep: validationForStep,
            controller: controller
        };
    };
    baseController.prototype.formWizardNext = function () {
        var self = this;
        self.toTheTop();
        if (self.validateForm(self.formWizard.form) && self.execValidationsForStep(self.formWizard.currentStep)) {
            self.formWizardNextStep();
        }
    };
    baseController.prototype.formWizardPrevious = function () {
        var self = this;
        self.toTheTop();
        self.formWizardPrevStep();
    };
    baseController.prototype.formWizardGoTo = function (step) {
        var self = this;
        if ((self.formWizard.currentStep) > (step)) { //go back
            self.toTheTop();
            self.formWizardGoToStep(step);
        }
        else {
            if (self.validateForm(self.formWizard.form) && self.execValidationsForStep(self.formWizard.currentStep)) { //go next
                self.toTheTop();
                self.formWizardGoToStep(step);
            }
        }
    };
    baseController.prototype.formWizardSubmit = function () {
    };
    baseController.prototype.formWizardReset = function () {
    };
    baseController.prototype.formWizardNextStep = function () {
        var self = this;
        self.formWizard.currentStep++;
    };
    baseController.prototype.formWizardPrevStep = function () {
        var self = this;
        self.formWizard.currentStep--;
    };
    baseController.prototype.formWizardGoToStep = function (step) {
        var self = this;
        self.formWizard.currentStep = step;
    };
    baseController.prototype.execValidationsForStep = function (step) {
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
    };
    baseController.prototype.toTheTop = function () {
        var self = this;
        self.$document.scrollTopAnimated(0, 600);
    };
    baseController.prototype.showFooter = function () {
        this.isFooterShown = true;
    };
    baseController.prototype.hideFooter = function () {
        this.isFooterShown = true;
    };
    baseController.prototype.showMessage = function (message, title, messageType, showCancelButton, okCallback, isHtml, okButtonText, cancelButttonText, cancelCallback, caller, params) {
        if (showCancelButton === void 0) { showCancelButton = false; }
        if (okCallback === void 0) { okCallback = null; }
        if (isHtml === void 0) { isHtml = false; }
        if (okButtonText === void 0) { okButtonText = "Ok"; }
        if (cancelButttonText === void 0) { cancelButttonText = "Cancel"; }
        if (cancelCallback === void 0) { cancelCallback = null; }
        if (caller === void 0) { caller = null; }
        if (params === void 0) { params = null; }
        var self = this;
        if (messageType == ALERT_MESSAGE_TYPE.ERROR && self.isNullOrUndefined(isHtml))
            isHtml = true;
        if (messageType == ALERT_MESSAGE_TYPE.WARNING || messageType == ALERT_MESSAGE_TYPE.ERROR) {
            self.confirmBtnColor = "#da4f4a";
        }
        else {
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
            }
            else {
                if (cancelCallback != null)
                    cancelCallback(caller);
            }
        });
    };
    baseController.prototype.showCustomModal = function (modalController, modalTemplateUrl, caller, dataToPass, onOk, onCancel, size, backdrop, cssClass, shouldShareSameScope) {
        if (onCancel === void 0) { onCancel = function () { }; }
        if (size === void 0) { size = 'lg'; }
        if (backdrop === void 0) { backdrop = ''; }
        if (cssClass === void 0) { cssClass = ''; }
        if (shouldShareSameScope === void 0) { shouldShareSameScope = false; }
        var self = this;
        var modalData = {
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
                    return self;
                }
            }
        };
        if (shouldShareSameScope) {
            modalData.scope = self.$scope;
        }
        var modalInstance = self.$uibModal.open(modalData);
        modalInstance.result.then(onOk, onCancel);
        return modalInstance;
    };
    baseController.prototype.showLoading = function () {
        var self = this;
        if (self.modalInstanceForLoading == null) {
            self.modalInstanceForLoading = self.$uibModal.open({
                template: '<div class="modal-body" ><img src="' + self.globalVariableFactory.baseServerUrl + '/Content/Images/loader.svg" style="width:125px;"></div>',
                backdrop: 'static',
                windowClass: 'loading-center-modal'
            });
        }
    };
    baseController.prototype.hideLoading = function () {
        var self = this;
        if (self.modalInstanceForLoading != null) {
            self.modalInstanceForLoading.close();
            self.modalInstanceForLoading = null;
        }
    };
    baseController.prototype.showToast = function (toasterType, toasterTitle, toasterText) {
        if (toasterText === void 0) { toasterText = ""; }
        this.toaster.pop(toasterType, toasterTitle, toasterText);
        //self.toaster.error("An error occured!");
        //console.log(toasterType + "  --  " + toasterTitle + "  --  " + toasterText);
        //this.toaster.info(toasterText, toasterTitle)
    };
    baseController.prototype.isNullOrUndefined = function (val) {
        return angular.isUndefined(val) || val == null;
    };
    baseController.prototype.getAbbreviation = function (word) {
        return word.toUpperCase().match(/\b\w/g).join('');
    };
    baseController.prototype.validateForm = function (form) {
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
    };
    baseController.prototype.searchForEntityInList = function (entityIdName, list, comparisonCriteria, localIdName) {
        if (localIdName === void 0) { localIdName = null; }
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
            }
            else {
                return positionOfEntity;
            }
        }
        else {
            return null;
        }
    };
    baseController.prototype.cloneObject = function (obj) {
        return JSON.parse(JSON.stringify(obj), dateParser.dateParserScreenMode);
    };
    baseController.prototype.getState = function () {
        this.state = eval('controllerName');
    };
    baseController.prototype.getAction = function () {
        this.actionName = eval('actionName');
    };
    baseController.prototype.getAreaName = function () {
        this.areaName = eval('areaName');
    };
    baseController.prototype.generateUUID = function () {
        return commonUtility.generateUUID();
    };
    baseController.prototype.toggleDatePicker = function (id) {
        var self = this;
        if (self.isNullOrUndefined(self.datePickersState[id])) {
            self.datePickersState[id] = true;
        }
        else {
            self.datePickersState[id] = !self.datePickersState[id];
        }
    };
    baseController.prototype.getFileExtension = function (fileName) {
        var self = this;
        var re = /(?:\.([^.]+))?$/;
        return re.exec(fileName)[1];
    };
    baseController.prototype.logout = function () {
        var self = this;
        self.authenticationFactory.logOff()
            .then(function (response) {
            if (response) {
                window.location.href = self.globalVariableFactory.baseServerUrl;
            }
            else {
                self.toaster.error("An error occured!");
            }
        }).catch(function (errorResponse) {
            self.toaster.error(errorResponse);
        }).finally(function () {
        });
    };
    baseController.prototype.getLoggedUser = function () {
        var self = this;
        self.authenticationFactory.getLoggedUser()
            .then(function (response) {
            self.globalVariableFactory.loggedInUserDetail = response;
        }).catch(function (errorResponse) {
            self.toaster.error(errorResponse);
        }).finally(function () {
        });
    };
    baseController.prototype.redirectToUrlFromBase = function (url) {
        var self = this;
        self.$window.location = self.globalVariableFactory.baseServerUrl + "/" + url;
    };
    baseController.prototype.getRandomColorCode = function () {
        var self = this;
        var letters = '0123456789ABCDEF';
        var color = '#';
        for (var i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    };
    baseController.prototype.getThumbnailForPicture = function (document, isProfileImage) {
        if (isProfileImage === void 0) { isProfileImage = false; }
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
            });
        }
        else {
            return self.getGenericFileThumbnailFromExtension(document, isProfileImage);
        }
    };
    baseController.prototype.getGenericFileThumbnailFromExtension = function (document, isProfileImage) {
        if (isProfileImage === void 0) { isProfileImage = false; }
        var self = this;
        var imageUrl = CUSTOM_VARIABLES.PROFILE_NO_IMAGE;
        var extension = null;
        if (self.isNullOrUndefined(document) || self.isNullOrUndefined(document.fileExtension) || self.isNullOrUndefined(document.serverFilePath) || self.isNullOrUndefined(document.parameter1)) {
            extension = "unknown";
        }
        else if (CUSTOM_VARIABLES.IMAGES_EXTENSION.indexOf(document.fileExtension.toLowerCase()) < 0) {
            extension = document.fileExtension.toLowerCase();
        }
        else {
            imageUrl = document.parameter1.paramaterValue + document.serverFilePath;
        }
        if (!self.isNullOrUndefined(extension) && !isProfileImage) {
            var fileType = Enumerable.From(self.fileTypes).Where(function (fileType) {
                return fileType.extension.indexOf(extension.toLowerCase()) >= 0;
            }).FirstOrDefault(null);
            if (fileType != null) {
                imageUrl = fileType.serverUrl;
            }
        }
        return imageUrl;
    };
    baseController.prototype.getFileTypeFromServer = function () {
        var self = this;
        var deferred = self.q.defer();
        self.areFileTypeBeingLoaded = true;
        self.fileWebService.getFileType()
            .then(function (response) {
            self.areFileTypeBeingLoaded = false;
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.fileTypes = response.result;
                deferred.resolve();
            }
            else {
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
    };
    baseController.prototype.onPictureAdded = function (onPictureAddeds, customUploadFunction) {
        if (customUploadFunction === void 0) { customUploadFunction = null; }
        var self = this;
        var deffered = self.q.defer();
        if (onPictureAddeds.length == 0)
            deffered.reject("No file to upload");
        var uploadDocumentListPerFiles = [];
        Enumerable.From(onPictureAddeds).ForEach(function (onPictureAdded) {
            var fileUploadState = new fileUploadStateModel();
            fileUploadState.id = self.generateUUID();
            fileUploadState.isUploaded = false;
            self.fileUploadStates.push(fileUploadState);
            onPictureAdded.fileUploadState = fileUploadState;
            onPictureAdded.id = fileUploadState.id;
            var uploadDocumentListPerFile = new uploadDocumentListPerFileDto();
            uploadDocumentListPerFile.file = onPictureAdded.file;
            uploadDocumentListPerFile.id = onPictureAdded.id;
            uploadDocumentListPerFiles.push(uploadDocumentListPerFile);
        });
        self.fileManager.uploadDocumentListPerFile(uploadDocumentListPerFiles, [], 0, null, customUploadFunction)
            .then(function (uploadedDocuments) {
            onPictureUploaded(uploadedDocuments);
        })
            .catch(function (error) {
            onPictureUploadFailed(error);
        });
        function onPictureUploaded(uploadedDocuments) {
            Enumerable.From(uploadedDocuments).ForEach(function (uploadedDocument) {
                var pictureUploadStateFromArray = Enumerable.From(self.fileUploadStates).Where(function (_pictureUploadStateFromArray) {
                    return _pictureUploadStateFromArray.id == uploadedDocument.id;
                }).First();
                pictureUploadStateFromArray.isUploaded = true;
                var onPictureAdded = Enumerable.From(onPictureAddeds).Where(function (_onPictureAdded) {
                    return _onPictureAdded.id == uploadedDocument.id;
                }).First();
                onPictureAdded.document.fileExtension = uploadedDocument.document.fileExtension;
                onPictureAdded.document.fileName = uploadedDocument.document.fileName;
                onPictureAdded.document.idParameterBasePhysicalFilePath = uploadedDocument.document.idParameterBasePhysicalFilePath;
                onPictureAdded.document.idParameterBaseServerUrl = uploadedDocument.document.idParameterBaseServerUrl;
                onPictureAdded.document.parameter1 = uploadedDocument.document.parameter1;
                onPictureAdded.document.physicalFilePath = uploadedDocument.document.physicalFilePath;
                onPictureAdded.document.serverFilePath = uploadedDocument.document.serverFilePath;
            });
            deffered.resolve(onPictureAddeds);
        }
        function onPictureUploadFailed(error) {
            deffered.reject(error);
        }
        return deffered.promise;
    };
    baseController.prototype.areFilesPendingUpload = function () {
        var self = this;
        return Enumerable.From(self.fileUploadStates).Where(function (fileUploadState) {
            return fileUploadState.isUploaded = false;
        }).Count() > 0;
    };
    return baseController;
}());
var onPictureAddedDto = /** @class */ (function () {
    function onPictureAddedDto() {
    }
    return onPictureAddedDto;
}());
var stickyMessage = /** @class */ (function () {
    function stickyMessage() {
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
    Object.defineProperty(stickyMessage.prototype, "getFormattedMessage", {
        get: function () {
            var self = this;
            var keys = Object.keys(self.messageGroup);
            var content = Enumerable.From(keys).Select(function (key) {
                return self.messageGroup[key].join(",");
            }).ToArray();
            return content.join('<br/>');
        },
        enumerable: false,
        configurable: true
    });
    stickyMessage.prototype.addMessage = function (message, blockId) {
        var self = this;
        if (self.messageGroup[blockId] == null || self.messageGroup[blockId] == undefined) {
            self.messageGroup[blockId] = [];
        }
        self.messageGroup[blockId].push(message);
    };
    stickyMessage.prototype.clearBlock = function (blockId) {
        var self = this;
        self.messageGroup[blockId] = [];
    };
    return stickyMessage;
}());
//# sourceMappingURL=base-controller.js.map