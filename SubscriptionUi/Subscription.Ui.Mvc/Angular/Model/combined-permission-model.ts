class combinedPermissionModel {
    public idPermission: number;
    public permissionName: string;
    public permissionCode: number;
    public view: boolean;
    public edit: boolean
    public delete: boolean

    public static ConvertJSONToModel(_combinedPermissionJSON: any): combinedPermissionModel {
        var _combinedPermissionModel: combinedPermissionModel = new combinedPermissionModel();
        _combinedPermissionModel.idPermission = _combinedPermissionJSON.idPermission;
        _combinedPermissionModel.permissionName = _combinedPermissionJSON.permissionName;
        _combinedPermissionModel.permissionCode = _combinedPermissionJSON.permissionCode;
        _combinedPermissionModel.view = _combinedPermissionJSON.view;
        _combinedPermissionModel.edit = _combinedPermissionJSON.edit;
        _combinedPermissionModel.delete = _combinedPermissionJSON.delete;
        return _combinedPermissionModel;
    }

    public static ConvertJSONListToModelList(_combinedPermissionJSONList: any): combinedPermissionModel[] {
        var combinedPermissionList: combinedPermissionModel[] = new Array();
        angular.forEach(_combinedPermissionJSONList, function (_combinedPermissionJSON) {
            combinedPermissionList.push(combinedPermissionModel.ConvertJSONToModel(_combinedPermissionJSON));
        })
        return combinedPermissionList;
    }
}