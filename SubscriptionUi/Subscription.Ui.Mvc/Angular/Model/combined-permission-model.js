var combinedPermissionModel = /** @class */ (function () {
    function combinedPermissionModel() {
    }
    combinedPermissionModel.ConvertJSONToModel = function (_combinedPermissionJSON) {
        var _combinedPermissionModel = new combinedPermissionModel();
        _combinedPermissionModel.idPermission = _combinedPermissionJSON.idPermission;
        _combinedPermissionModel.permissionName = _combinedPermissionJSON.permissionName;
        _combinedPermissionModel.permissionCode = _combinedPermissionJSON.permissionCode;
        _combinedPermissionModel.view = _combinedPermissionJSON.view;
        _combinedPermissionModel.edit = _combinedPermissionJSON.edit;
        _combinedPermissionModel.delete = _combinedPermissionJSON.delete;
        return _combinedPermissionModel;
    };
    combinedPermissionModel.ConvertJSONListToModelList = function (_combinedPermissionJSONList) {
        var combinedPermissionList = new Array();
        angular.forEach(_combinedPermissionJSONList, function (_combinedPermissionJSON) {
            combinedPermissionList.push(combinedPermissionModel.ConvertJSONToModel(_combinedPermissionJSON));
        });
        return combinedPermissionList;
    };
    return combinedPermissionModel;
}());
//# sourceMappingURL=combined-permission-model.js.map