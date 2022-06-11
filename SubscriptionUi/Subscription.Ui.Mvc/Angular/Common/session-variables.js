var sessionSpace = /** @class */ (function () {
    function sessionSpace() {
        this.list = {};
    }
    return sessionSpace;
}());
var sessionVariables = /** @class */ (function () {
    function sessionVariables() {
        this.list = {};
    }
    sessionVariables.prototype.createSessionSpace = function () {
        sessionVariables.sessionIdMax += 1;
        return sessionVariables.sessionIdMax;
    };
    sessionVariables.prototype.putVariableInSessionSpace = function (sessionSpaceId, sessionKey, sessionValue) {
        if (this.list[sessionSpaceId] == null) {
            this.list[sessionSpaceId] = new sessionSpace();
        }
        var _sessionSpace = this.list[sessionSpaceId];
        _sessionSpace[sessionKey] = sessionValue;
    };
    sessionVariables.prototype.getVariableFromSessionSpace = function (sessionSpaceId, sessionKey) {
        if (this.list == undefined || this.list == null || this.list[sessionSpaceId.toString()] == null || this.list[sessionSpaceId.toString()] == undefined) {
            return null;
        }
        return this.list[sessionSpaceId.toString()][sessionKey];
    };
    sessionVariables.prototype.clearSessionSpace = function (sessionSpaceId) {
        this.list[sessionSpaceId] = null;
    };
    sessionVariables.sessionIdMax = 1;
    return sessionVariables;
}());
//# sourceMappingURL=session-variables.js.map