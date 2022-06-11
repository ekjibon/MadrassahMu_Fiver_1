class permissionManager {
    $window;
    globalVariableFactory;
    constructor(
        private globalFactory: globalVariableFactory,
        private window
    ) {
        this.globalVariableFactory = globalFactory;
        this.$window = window;
    }

    public getPermissionForStateName(stateName: string): combinedPermissionModel {
        var self = this;
        var viewCode = STATE_MAPPER[stateName];
        return self.getPermissionByCode(viewCode);
    }

    public getPermissionByCode(code: number) {
        var self = this;
        var permissions = JSON.parse(self.$window.sessionStorage.getItem(CUSTOM_VARIABLES.PERMISSIONKEY));
        var permissionForToBeState = Enumerable.From(permissions).Where(function (_permission: combinedPermissionModel) {
            return _permission.permissionCode == code;
        }).FirstOrDefault(null);

        return permissionForToBeState;
    }

    public getUserRole() {
        return JSON.parse(this.$window.sessionStorage.getItem(CUSTOM_VARIABLES.ROLE));
    }

    public getPermissionFromStateList(stateList: string[]) {
        var self = this;
        var isViewEnabled = false;
        stateList.forEach(function (stateName: string) {
            var statePermission = self.getPermissionForStateName(stateName);
            if (statePermission != null && statePermission.view) {
                isViewEnabled = true;
                return true;
            }
        });
        return isViewEnabled;
    }
}