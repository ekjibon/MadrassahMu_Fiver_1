class sessionSpace {
    private list: {
        [sessionKey: string]: any;
    };
    constructor() {
        this.list = {};
    }
}

class sessionVariables {
    private list: {
        [sessionSpaceId: number]: sessionSpace;
    };
    private static sessionIdMax = 1;

    constructor() {
        this.list = {};
    }

    public createSessionSpace(): number {
        sessionVariables.sessionIdMax += 1;
        return sessionVariables.sessionIdMax;
    }
    public putVariableInSessionSpace(sessionSpaceId: number, sessionKey: string, sessionValue: any) {
        if (this.list[sessionSpaceId] == null) {
            this.list[sessionSpaceId] = new sessionSpace();
        }
        var _sessionSpace = this.list[sessionSpaceId];
        _sessionSpace[sessionKey] = sessionValue;
    }

    public getVariableFromSessionSpace(sessionSpaceId: number, sessionKey: string) {
        if (this.list == undefined || this.list == null || this.list[sessionSpaceId.toString()] == null || this.list[sessionSpaceId.toString()] == undefined) {
            return null;
        }

        return this.list[sessionSpaceId.toString()][sessionKey];
    }


    public clearSessionSpace(sessionSpaceId: number) {
        this.list[sessionSpaceId] = null;
    }
}