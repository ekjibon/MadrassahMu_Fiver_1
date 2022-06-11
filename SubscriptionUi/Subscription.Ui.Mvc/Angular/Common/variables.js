var TOASTER_TYPE = /** @class */ (function () {
    function TOASTER_TYPE() {
    }
    TOASTER_TYPE.SUCCESS = "success";
    TOASTER_TYPE.INFO = "info";
    TOASTER_TYPE.WAIT = "wait";
    TOASTER_TYPE.WARNING = "warning";
    TOASTER_TYPE.ERROR = "error";
    return TOASTER_TYPE;
}());
var ALERT_MESSAGE_TYPE = /** @class */ (function () {
    function ALERT_MESSAGE_TYPE() {
    }
    ALERT_MESSAGE_TYPE.WARNING = "warning";
    ALERT_MESSAGE_TYPE.SUCCESS = "success";
    ALERT_MESSAGE_TYPE.ERROR = "error";
    return ALERT_MESSAGE_TYPE;
}());
var STATUS_MESSAGE = /** @class */ (function () {
    function STATUS_MESSAGE() {
    }
    STATUS_MESSAGE.SUCCESS = 10;
    STATUS_MESSAGE.FAILURE = 11;
    STATUS_MESSAGE.SERVERERROR = 12;
    STATUS_MESSAGE.AUTHERROR = 13;
    STATUS_MESSAGE.TOKENEXPIRED = 15;
    STATUS_MESSAGE.TOKENINVALID = 16;
    STATUS_MESSAGE.VALIDATION_ERROR = 17;
    return STATUS_MESSAGE;
}());
var SCREEN_MODE;
(function (SCREEN_MODE) {
    SCREEN_MODE[SCREEN_MODE["VIEW"] = 0] = "VIEW";
    SCREEN_MODE[SCREEN_MODE["ADD"] = 1] = "ADD";
    SCREEN_MODE[SCREEN_MODE["EDIT"] = 2] = "EDIT";
})(SCREEN_MODE || (SCREEN_MODE = {}));
var Menu;
(function (Menu) {
    Menu[Menu["SELECT_CUSTOMER"] = 1] = "SELECT_CUSTOMER";
    Menu[Menu["SELECT_TRANSACTION"] = 2] = "SELECT_TRANSACTION";
    Menu[Menu["DEFINE_FREQUENCY"] = 3] = "DEFINE_FREQUENCY";
    Menu[Menu["SUMMARY"] = 4] = "SUMMARY";
    Menu[Menu["DEFINE_PAYMENT"] = 5] = "DEFINE_PAYMENT";
    Menu[Menu["VIEW_SCHEDULED_TRANSACTIONS"] = 6] = "VIEW_SCHEDULED_TRANSACTIONS";
    Menu[Menu["SCHEDULE_DETAILS"] = 7] = "SCHEDULE_DETAILS";
    Menu[Menu["PAYMENT_SCHEDULE_DETAILS"] = 8] = "PAYMENT_SCHEDULE_DETAILS";
    Menu[Menu["FREQUENCY_SCHEDULE_DETAILS"] = 9] = "FREQUENCY_SCHEDULE_DETAILS";
})(Menu || (Menu = {}));
var layoutCustomisation = /** @class */ (function () {
    function layoutCustomisation() {
    }
    return layoutCustomisation;
}());
var STATE_MAPPER = /** @class */ (function () {
    function STATE_MAPPER() {
    }
    return STATE_MAPPER;
}());
var CUSTOM_VARIABLES = /** @class */ (function () {
    function CUSTOM_VARIABLES() {
    }
    CUSTOM_VARIABLES.AUTHKEY = "authKey";
    CUSTOM_VARIABLES.PERMISSIONKEY = "permissionKey";
    CUSTOM_VARIABLES.CURRENT_USER = "currentUser";
    CUSTOM_VARIABLES.ROLE = "role";
    CUSTOM_VARIABLES.LAYOUT = "layout";
    CUSTOM_VARIABLES.ON_INITIALIZED = "ON_INITIALIZED";
    CUSTOM_VARIABLES.PROFILE_NO_IMAGE = eval('globalBaseServerUrl') + "Images/blank-profile-cover-image.png";
    CUSTOM_VARIABLES.IMAGES_EXTENSION = ['.tif', '.jpg', '.jpeg', '.gif', '.png'];
    return CUSTOM_VARIABLES;
}());
var PERMISSION = /** @class */ (function () {
    function PERMISSION() {
    }
    return PERMISSION;
}());
var SignInStatus;
(function (SignInStatus) {
    SignInStatus[SignInStatus["Success"] = 0] = "Success";
    SignInStatus[SignInStatus["LockedOut"] = 1] = "LockedOut";
    SignInStatus[SignInStatus["RequiresVerification"] = 2] = "RequiresVerification";
    SignInStatus[SignInStatus["Failure"] = 3] = "Failure";
})(SignInStatus || (SignInStatus = {}));
var URL_LIST = /** @class */ (function () {
    function URL_LIST() {
    }
    URL_LIST.HOME = "";
    URL_LIST.AUTH = "Authentication/Authentication/Authentication";
    URL_LIST.TRANSACTION = "Transaction/Transaction/TransactionSaleListing";
    URL_LIST.DASHBOARD = "Administration/AdministrationDashboard/Index";
    return URL_LIST;
}());
var MAP_DATA = /** @class */ (function () {
    function MAP_DATA() {
    }
    MAP_DATA.getSvgMarker = function (color) {
        var self = this;
        var svgMarkerIcon = MAP_DATA.markerSvg.replace(new RegExp('{{color}}', 'g'), color);
        var icon = {
            iconSize: [38, 38],
            iconUrl: svgMarkerIcon
        };
        //if (navigator.appCodeName == "Mozilla") {
        //    svgMarkerIcon = svgMarkerIcon.replace(new RegExp('#', 'g'), "%23");
        //}
        return icon;
    };
    MAP_DATA.openStreetMapLayer = {
        name: "OpenStreetMap",
        url: "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
        type: "xyz",
        layerOptions: {
            attribution: "",
            maxNativeZoom: 18,
            maxZoom: 25
        }
    };
    MAP_DATA.googleRoadmap = {
        name: "Google Streets",
        layerType: "ROADMAP",
        type: "google"
    };
    MAP_DATA.centerLocation = {
        lat: -20.276326,
        lng: 57.557105,
        zoom: 10
    };
    MAP_DATA.markerUrl = "Images/picto-pointer.png";
    MAP_DATA.markerSvg = "data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 60 60'><path data-name='layer1' d='M32 2a18 18 0 0 0-18 18 18.1 18.1 0 0 0 .2 2.2C15.7 36.8 32 44.9 32 62c0-17.1 16.3-25.2 17.8-39.7A17.9 17.9 0 0 0 32 2zm0 24a6 6 0 1 1 6-6 6 6 0 0 1-6 6z'></path></svg>";
    return MAP_DATA;
}());
//# sourceMappingURL=variables.js.map