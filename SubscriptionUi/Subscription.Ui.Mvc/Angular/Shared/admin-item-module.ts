var adminItemModule = angular.module("adminItemModule", []);

adminItemModule.controller("adminHeaderController"
    , ["$scope"
        , adminHeaderController
    ]);

adminItemModule.controller("adminFooterController"
    , ["$scope"
        , adminFooterController
    ]);

adminItemModule.controller("adminSidebarController"
    , ["$scope"
        , adminSidebarController
    ]);

baseModule.requires.push("adminItemModule");