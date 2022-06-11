class screenModeManager<T, K> {

    public entityBeforeEdit: T;
    public entity: T;
    public container: K;
    public currentMode: SCREEN_MODE;
    public saveCallback: (modifiedEntity: T, container: K, oldEntity?: T) => void;
    public onSaving;
    public onSaveCompleted;
    public onEditing;
    public onEditCompleted;
    public onCancelling;
    public onCancelCompleted;
    public areCallsAsync: boolean;

    constructor(container: K, saveCallback: (modifiedEntity: T, container: K, oldEntity?: T) => void = null, areCallsAsync: boolean = false) {
        this.container = container;
        this.saveCallback = saveCallback;
        this.areCallsAsync = areCallsAsync;
    }

    public setSaveCallback(saveCallback) {
        this.saveCallback = saveCallback;
    }

    public setEntity(entity): void {
        this.entityBeforeEdit = this.cloneObject(entity);
        this.entity = this.cloneObject(entity);
    }

    public save() {
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
    }

    public edit() {
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
            setTimeout(() => {
                editBody(editBodyOnSuccess);
            }, 0);
        }
        else {
            editBody(editBodyOnSuccess);
        }
    }

    public cancel() {
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
            setTimeout(() => {
                cancelBody(cancelBodyOnSuccess);
            }, 0);
        }
        else {
            cancelBody(cancelBodyOnSuccess);
        }
    }

    public setMode(mode: SCREEN_MODE) {
        this.currentMode = mode;
    }

    public cloneObject(obj) {
        return JSON.parse(JSON.stringify(obj), dateParser.dateParserScreenMode);
    }

} //END class

