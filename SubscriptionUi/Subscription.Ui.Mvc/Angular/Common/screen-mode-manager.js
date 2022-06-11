var screenModeManager = /** @class */ (function () {
    function screenModeManager(container, saveCallback, areCallsAsync) {
        if (saveCallback === void 0) { saveCallback = null; }
        if (areCallsAsync === void 0) { areCallsAsync = false; }
        this.container = container;
        this.saveCallback = saveCallback;
        this.areCallsAsync = areCallsAsync;
    }
    screenModeManager.prototype.setSaveCallback = function (saveCallback) {
        this.saveCallback = saveCallback;
    };
    screenModeManager.prototype.setEntity = function (entity) {
        this.entityBeforeEdit = this.cloneObject(entity);
        this.entity = this.cloneObject(entity);
    };
    screenModeManager.prototype.save = function () {
        if (this.onSaving != null)
            this.onSaving();
        var oldEntity = this.cloneObject(this.entityBeforeEdit);
        this.entityBeforeEdit = this.cloneObject(this.entity);
        this.setMode(SCREEN_MODE.VIEW);
        if (this.saveCallback) {
            this.saveCallback(this.entity, this.container, oldEntity);
        }
        if (this.onSaveCompleted != null) {
            this.onSaveCompleted(this.container);
        }
    };
    screenModeManager.prototype.edit = function () {
        if (this.onEditing != null)
            this.onEditing();
        var self = this;
        function editBody(onSuccess) {
            self.entity = self.cloneObject(self.entityBeforeEdit);
            self.setMode(SCREEN_MODE.EDIT);
            onSuccess();
        }
        function editBodyOnSuccess() {
            if (self.onEditCompleted != null)
                self.onEditCompleted(self.container);
        }
        if (this.areCallsAsync) {
            setTimeout(function () {
                editBody(editBodyOnSuccess);
            }, 0);
        }
        else {
            editBody(editBodyOnSuccess);
        }
    };
    screenModeManager.prototype.cancel = function () {
        if (this.onCancelling != null)
            this.onCancelling();
        var self = this;
        function cancelBody(onSuccess) {
            self.entity = self.cloneObject(self.entityBeforeEdit);
            self.setMode(SCREEN_MODE.VIEW);
            onSuccess();
        }
        function cancelBodyOnSuccess() {
            if (self.onCancelCompleted != null)
                self.onCancelCompleted(self.container);
        }
        if (this.areCallsAsync) {
            setTimeout(function () {
                cancelBody(cancelBodyOnSuccess);
            }, 0);
        }
        else {
            cancelBody(cancelBodyOnSuccess);
        }
    };
    screenModeManager.prototype.setMode = function (mode) {
        this.currentMode = mode;
    };
    screenModeManager.prototype.cloneObject = function (obj) {
        return JSON.parse(JSON.stringify(obj), dateParser.dateParserScreenMode);
    };
    return screenModeManager;
}()); //END class
//# sourceMappingURL=screen-mode-manager.js.map