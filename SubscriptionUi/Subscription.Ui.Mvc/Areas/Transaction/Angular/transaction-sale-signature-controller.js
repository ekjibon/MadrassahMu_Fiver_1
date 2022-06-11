var transactionSaleSignatureController = /** @class */ (function () {
    function transactionSaleSignatureController($scope, transactionSaleWebService) {
        this.clickX = [];
        this.clickY = [];
        this.clickDrag = [];
        this.inputWorkstationID = true;
        this.inputSignature = false;
        this.signatureButton = false;
        this.transactionArray = [];
        var self = this;
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = this.scope.baseController;
        this.transactionSaleWebService = transactionSaleWebService;
    }
    transactionSaleSignatureController.prototype.onLoad = function () {
        var self = this;
        self.transactionSaleSignatureEnum = transactionSaleSignatureEnum;
        self.checkForSignatureState();
    };
    transactionSaleSignatureController.prototype.checkForSignatureState = function () {
        var self = this;
        var idWorkstation = self.baseController.$localStorage.getItem(localStorageKey.IdWorkstation);
        if (self.baseController.isNullOrUndefined(idWorkstation) || idWorkstation.length == 0) {
            self.currentTransactionSaleSignature = transactionSaleSignatureEnum.ID_NOT_SET;
            self.idWorkstation = idWorkstation;
        }
        else {
            self.currentTransactionSaleSignature = transactionSaleSignatureEnum.ID_SET;
            console.log('drawwwwwwwwwwwwwwwwwwwwwwww');
            self.drawSignature();
            //new DrawingApp();
        }
        console.log(self.currentTransactionSaleSignature);
    };
    transactionSaleSignatureController.prototype.setIdWorkstation = function () {
        var self = this;
        window.localStorage.setItem(localStorageKey.IdWorkstation, self.idWorkstation);
        self.checkForSignatureState();
    };
    transactionSaleSignatureController.prototype.clickToSign = function () {
        var self = this;
        self.getTemporaryTransactionSignatureForWorkstation();
    };
    transactionSaleSignatureController.prototype.getTemporaryTransactionData = function () {
        var self = this;
    };
    transactionSaleSignatureController.prototype.drawSignature = function () {
        var canvas = document.querySelector('#paint');
        var ctx = canvas.getContext('2d');
        var sketch = document.querySelector('#sketch');
        var sketch_style = getComputedStyle(sketch);
        canvas.width = parseInt(sketch_style.getPropertyValue('width'));
        canvas.height = parseInt(sketch_style.getPropertyValue('height'));
        var mouse = { x: 0, y: 0 };
        var last_mouse = { x: 0, y: 0 };
        /* Mouse Capturing Work */
        canvas.addEventListener('mousemove', function (e) {
            last_mouse.x = mouse.x;
            last_mouse.y = mouse.y;
            mouse.x = e.pageX - this.offsetLeft;
            mouse.y = e.pageY - (1.9 * this.offsetTop);
        }, false);
        /* Drawing on Paint App */
        ctx.lineWidth = 5;
        ctx.lineJoin = 'round';
        ctx.lineCap = 'round';
        ctx.strokeStyle = 'blue';
        canvas.addEventListener('mousedown', function (e) {
            canvas.addEventListener('mousemove', onPaint, false);
        }, false);
        canvas.addEventListener('mouseup', function () {
            canvas.removeEventListener('mousemove', onPaint, false);
        }, false);
        var onPaint = function () {
            ctx.beginPath();
            ctx.moveTo(last_mouse.x, last_mouse.y);
            ctx.lineTo(mouse.x, mouse.y);
            ctx.closePath();
            ctx.stroke();
        };
    };
    ;
    transactionSaleSignatureController.prototype.resetSignature = function () {
        var canvas = document.querySelector('#paint');
        var ctx = canvas.getContext('2d');
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        console.log('reset');
    };
    ;
    transactionSaleSignatureController.prototype.sendSignature = function () {
        var self = this;
        var canvas = document.querySelector('#paint');
        var dataURL = canvas.toDataURL();
        var base64 = dataURL.split(',')[1];
        self.saveBase64ToImage(base64).then(function (document) {
            self.temporaryTransaction.document = document;
            self.saveSignatureWithImage();
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "Could not save signature image", ALERT_MESSAGE_TYPE.ERROR);
        });
    };
    ;
    transactionSaleSignatureController.prototype.saveSignatureWithImage = function () {
        var self = this;
        self.baseController.showLoading();
        var _saveTemporaryTransactionDto = new saveTemporaryTransactionDto();
        _saveTemporaryTransactionDto.temporaryTransaction = self.temporaryTransaction;
        _saveTemporaryTransactionDto.temporaryTransaction.idTemporaryTransactionOrderState = signatureStateEnum.SIGNATURE_DONE;
        _saveTemporaryTransactionDto.temporaryTransaction = self.temporaryTransaction;
        self.transactionSaleWebService.saveTemporaryTransaction(_saveTemporaryTransactionDto)
            .then(function (response) {
            self.baseController.hideLoading();
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.temporaryTransaction = null;
                self.currentTransactionSaleSignature = transactionSaleSignatureEnum.ID_SET;
                self.resetSignature();
                self.transactionArray = null;
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.hideLoading();
            self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
        });
    };
    transactionSaleSignatureController.prototype.saveBase64ToImage = function (base64Image) {
        var self = this;
        var deffered = self.baseController.q.defer();
        var onPictureAddeds = [];
        var onPictureAdded = new onPictureAddedDto();
        onPictureAdded.file = new File([self.b64toBlob(base64Image)], 'signature.png');
        onPictureAdded.document = new documentModel();
        onPictureAddeds.push(onPictureAdded);
        self.baseController.onPictureAdded(onPictureAddeds)
            .then(function (response) {
            deffered.resolve(response[0].document);
        })
            .catch(function (error) {
            deffered.reject(error);
        });
        return deffered.promise;
    };
    transactionSaleSignatureController.prototype.getTemporaryTransactionSignatureForWorkstation = function () {
        var self = this;
        var idWorkstation = self.baseController.$localStorage.getItem(localStorageKey.IdWorkstation);
        if (self.baseController.isNullOrUndefined(idWorkstation)) {
            self.baseController.showMessage("Workstation id is not set, please refresh and try again", "", ALERT_MESSAGE_TYPE.ERROR);
            return;
        }
        self.baseController.showLoading();
        var _getTemporaryTransactionSignatureForWorkstation = new getTemporaryTransactionSignatureForWorkstationDto();
        _getTemporaryTransactionSignatureForWorkstation.idWorkStation = idWorkstation;
        self.transactionSaleWebService.getTemporaryTransactionOrderForWorkstation(_getTemporaryTransactionSignatureForWorkstation)
            .then(function (response) {
            self.baseController.hideLoading();
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.currentTransactionSaleSignature = transactionSaleSignatureEnum.TRANSACTION_LOADED;
                self.temporaryTransaction = response.result.temporaryTransaction;
                self.transactionArray = JSON.parse(self.temporaryTransaction.transactionJson);
                console.log(self.transactionArray);
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.hideLoading();
            self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
        });
    };
    transactionSaleSignatureController.prototype.b64toBlob = function (b64Data, contentType, sliceSize) {
        if (contentType === void 0) { contentType = ''; }
        if (sliceSize === void 0) { sliceSize = 512; }
        var byteCharacters = atob(b64Data);
        var byteArrays = [];
        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            var slice = byteCharacters.slice(offset, offset + sliceSize);
            var byteNumbers = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }
            var byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }
        var blob = new Blob(byteArrays, { type: contentType });
        return blob;
    };
    return transactionSaleSignatureController;
}());
transactionModule.controller("transactionSaleSignatureController", ["$scope",
    "transactionSaleWebService",
    transactionSaleSignatureController
]);
var transactionSaleSignatureEnum;
(function (transactionSaleSignatureEnum) {
    transactionSaleSignatureEnum[transactionSaleSignatureEnum["ID_NOT_SET"] = 1] = "ID_NOT_SET";
    transactionSaleSignatureEnum[transactionSaleSignatureEnum["ID_SET"] = 2] = "ID_SET";
    transactionSaleSignatureEnum[transactionSaleSignatureEnum["TRANSACTION_LOADED"] = 3] = "TRANSACTION_LOADED";
})(transactionSaleSignatureEnum || (transactionSaleSignatureEnum = {}));
//# sourceMappingURL=transaction-sale-signature-controller.js.map