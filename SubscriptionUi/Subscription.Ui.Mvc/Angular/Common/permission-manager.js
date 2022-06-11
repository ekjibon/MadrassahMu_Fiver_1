var permissionManager = /** @class */ (function () {
    function permissionManager(globalFactory, window) {
        this.globalFactory = globalFactory;
        this.window = window;
        this.globalVariableFactory = globalFactory;
        this.$window = window;
    }
    permissionManager.prototype.getPermissionForStateName = function (stateName) {
        var self = this;
        var viewCode = STATE_MAPPER[stateName];
        return self.getPermissionByCode(viewCode);
    };
    permissionManager.prototype.getPermissionByCode = function (code) {
        var self = this;
        var permissions = JSON.parse(self.$window.sessionStorage.getItem(CUSTOM_VARIABLES.PERMISSIONKEY));
        var permissionForToBeState = Enumerable.From(permissions).Where(function (_permission) {
            return _permission.permissionCode == code;
        }).FirstOrDefault(null);
        return permissionForToBeState;
    };
    permissionManager.prototype.getUserRole = function () {
        return JSON.parse(this.$window.sessionStorage.getItem(CUSTOM_VARIABLES.ROLE));
    };
    permissionManager.prototype.getPermissionFromStateList = function (stateList) {
        var self = this;
        var isViewEnabled = false;
        stateList.forEach(function (stateName) {
            var statePermission = self.getPermissionForStateName(stateName);
            if (statePermission != null && statePermission.view) {
                isViewEnabled = true;
                return true;
            }
        });
        return isViewEnabled;
    };
    return permissionManager;
}());
//# sourceMappingURL=permission-manager.js.map