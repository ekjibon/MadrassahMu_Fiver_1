var commonUtility = /** @class */ (function () {
    function commonUtility() {
    }
    commonUtility.redirectTo = function (url) {
        var newUrl = url.replace("~", eval('globalBaseServerUrl'));
        newUrl = newUrl.replace("//", "/");
        window.location.href = newUrl;
    };
    commonUtility.generateUUID = function () {
        var d = new Date().getTime();
        if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
            d += performance.now(); //use high-precision timer if available
        }
        return 'xxxxxxxx_xxxx_4xxx_yxxx_xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
    };
    return commonUtility;
}());
//# sourceMappingURL=common-utility.js.map