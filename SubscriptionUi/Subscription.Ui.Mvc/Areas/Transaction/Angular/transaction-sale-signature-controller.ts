class transactionSaleSignatureController {
    scope;
    baseController: baseController;
    transactionSaleWebService: transactionSaleWebService;
    idWorkstation: string;

    private canvas: HTMLCanvasElement;
    private context: CanvasRenderingContext2D;
    private paint: boolean;

    private clickX: number[] = [];
    private clickY: number[] = [];
    private clickDrag: boolean[] = [];

    inputWorkstationID: boolean = true;
    inputSignature: boolean = false;
    signatureButton: boolean = false;
    transactionArray = [];

    transactionSaleSignatureEnum;
    currentTransactionSaleSignature: transactionSaleSignatureEnum;
    temporaryTransaction: temporaryTransactionOrderModel;

    constructor($scope
        , transactionSaleWebService) {
        var self = this;

        $scope.controller = this;
        this.scope = $scope;
        this.baseController = this.scope.baseController;
        this.transactionSaleWebService = transactionSaleWebService;
    }

    public onLoad() {
        var self = this;
        self.transactionSaleSignatureEnum = transactionSaleSignatureEnum;
        self.checkForSignatureState();
    }

    public checkForSignatureState() {
        var self = this;
        var idWorkstation: string = self.baseController.$localStorage.getItem(localStorageKey.IdWorkstation);
        if (self.baseController.isNullOrUndefined(idWorkstation) || idWorkstation.length == 0) {
            self.currentTransactionSaleSignature = transactionSaleSignatureEnum.ID_NOT_SET;
            self.idWorkstation = idWorkstation;
        } else {
            self.currentTransactionSaleSignature = transactionSaleSignatureEnum.ID_SET;
            console.log('drawwwwwwwwwwwwwwwwwwwwwwww');
            self.drawSignature();
            //new DrawingApp();
        }
        console.log(self.currentTransactionSaleSignature);
    }

    public setIdWorkstation() {
        var self = this;
        window.localStorage.setItem(localStorageKey.IdWorkstation, self.idWorkstation);
        self.checkForSignatureState();
    }

    public clickToSign() {
        var self = this;
        self.getTemporaryTransactionSignatureForWorkstation();

    }

    public getTemporaryTransactionData() {
        var self = this;
    }

    public drawSignature() {
        var canvas: any = document.querySelector('#paint');
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

    public resetSignature() {
        var canvas: any = document.querySelector('#paint');
        var ctx = canvas.getContext('2d');
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        console.log('reset');
    };

    public sendSignature() {
        var self = this;
        var canvas: any = document.querySelector('#paint');
        var dataURL = canvas.toDataURL();
        var base64 = dataURL.split(',')[1];

        self.saveBase64ToImage(base64).then(function (document: documentModel) {
            self.temporaryTransaction.document = document;
            self.saveSignatureWithImage();
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "Could not save signature image", ALERT_MESSAGE_TYPE.ERROR);
        })
    };

    public saveSignatureWithImage() {
        var self = this;

        self.baseController.showLoading();
        var _saveTemporaryTransactionDto: saveTemporaryTransactionDto = new saveTemporaryTransactionDto();
        _saveTemporaryTransactionDto.temporaryTransaction = self.temporaryTransaction;
        _saveTemporaryTransactionDto.temporaryTransaction.idTemporaryTransactionOrderState = signatureStateEnum.SIGNATURE_DONE;
        _saveTemporaryTransactionDto.temporaryTransaction = self.temporaryTransaction;
        self.transactionSaleWebService.saveTemporaryTransaction(_saveTemporaryTransactionDto)
            .then(function (response: baseResultReturnType<saveTemporaryTransactionReturnType>) {
                self.baseController.hideLoading();
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.temporaryTransaction = null;
                    self.currentTransactionSaleSignature = transactionSaleSignatureEnum.ID_SET;
                    self.resetSignature();
                    self.transactionArray = null;
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.hideLoading();
                self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {

            });
    }




    public saveBase64ToImage(base64Image): ng.IPromise<documentModel> {
        var self = this;
        var deffered: angular.IDeferred<documentModel> = self.baseController.q.defer();

        var onPictureAddeds: onPictureAddedDto[] = [];
        var onPictureAdded: onPictureAddedDto = new onPictureAddedDto();
        onPictureAdded.file = new File([self.b64toBlob(base64Image)], 'signature.png');

        onPictureAdded.document = new documentModel();
        onPictureAddeds.push(onPictureAdded);

        self.baseController.onPictureAdded(onPictureAddeds)
            .then(function (response: onPictureAddedDto[]) {
                deffered.resolve(response[0].document);
            })
            .catch(function (error: string) {
                deffered.reject(error);
            })

        return deffered.promise;
    }

    public getTemporaryTransactionSignatureForWorkstation() {
        var self = this;
        var idWorkstation: string = self.baseController.$localStorage.getItem(localStorageKey.IdWorkstation);

        if (self.baseController.isNullOrUndefined(idWorkstation)) {
            self.baseController.showMessage("Workstation id is not set, please refresh and try again", "", ALERT_MESSAGE_TYPE.ERROR);
            return;
        }

        self.baseController.showLoading();
        var _getTemporaryTransactionSignatureForWorkstation: getTemporaryTransactionSignatureForWorkstationDto = new getTemporaryTransactionSignatureForWorkstationDto();
        _getTemporaryTransactionSignatureForWorkstation.idWorkStation = idWorkstation


        self.transactionSaleWebService.getTemporaryTransactionOrderForWorkstation(_getTemporaryTransactionSignatureForWorkstation)
            .then(function (response: baseResultReturnType<getTemporaryTransactionSignatureForWorkstationReturnType>) {
                self.baseController.hideLoading();
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.currentTransactionSaleSignature = transactionSaleSignatureEnum.TRANSACTION_LOADED;
                    self.temporaryTransaction = response.result.temporaryTransaction;
                    self.transactionArray = JSON.parse(self.temporaryTransaction.transactionJson);
                    console.log(self.transactionArray);
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.hideLoading();
                self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {

            });
    }

    public b64toBlob(b64Data, contentType = '', sliceSize = 512) {
        const byteCharacters = atob(b64Data);
        const byteArrays = [];

        for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            const slice = byteCharacters.slice(offset, offset + sliceSize);

            const byteNumbers = new Array(slice.length);
            for (let i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            const byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }

        const blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }

}

transactionModule.controller("transactionSaleSignatureController"
    , ["$scope"
        , "transactionSaleWebService"
        , transactionSaleSignatureController
    ]);

enum transactionSaleSignatureEnum {
    ID_NOT_SET = 1,
    ID_SET = 2,
    TRANSACTION_LOADED = 3,
}
