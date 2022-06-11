var LOGIN_STATUS;
(function (LOGIN_STATUS) {
    LOGIN_STATUS[LOGIN_STATUS["Success"] = 0] = "Success";
    LOGIN_STATUS[LOGIN_STATUS["LockedOut"] = 1] = "LockedOut";
    LOGIN_STATUS[LOGIN_STATUS["RequiresVerification"] = 2] = "RequiresVerification";
    LOGIN_STATUS[LOGIN_STATUS["Failure"] = 3] = "Failure";
})(LOGIN_STATUS || (LOGIN_STATUS = {}));
var CUSTOMER_TYPE;
(function (CUSTOMER_TYPE) {
    CUSTOMER_TYPE[CUSTOMER_TYPE["PERSON"] = 1] = "PERSON";
    CUSTOMER_TYPE[CUSTOMER_TYPE["COMPANY"] = 2] = "COMPANY";
})(CUSTOMER_TYPE || (CUSTOMER_TYPE = {}));
var SIGNALR_MESSAGE_TYPE;
(function (SIGNALR_MESSAGE_TYPE) {
    SIGNALR_MESSAGE_TYPE[SIGNALR_MESSAGE_TYPE["FLIPBOOK_COVERSION_COMPLETED"] = 1] = "FLIPBOOK_COVERSION_COMPLETED";
    SIGNALR_MESSAGE_TYPE[SIGNALR_MESSAGE_TYPE["FLIPBOOK_COVERSION_PROGRESS"] = 2] = "FLIPBOOK_COVERSION_PROGRESS";
})(SIGNALR_MESSAGE_TYPE || (SIGNALR_MESSAGE_TYPE = {}));
var SIGNALR_CONNECTION_TYPE;
(function (SIGNALR_CONNECTION_TYPE) {
    SIGNALR_CONNECTION_TYPE[SIGNALR_CONNECTION_TYPE["USER"] = 1] = "USER";
    SIGNALR_CONNECTION_TYPE[SIGNALR_CONNECTION_TYPE["OTHER"] = 2] = "OTHER";
})(SIGNALR_CONNECTION_TYPE || (SIGNALR_CONNECTION_TYPE = {}));
//# sourceMappingURL=Angular.Enum.Common.js.map