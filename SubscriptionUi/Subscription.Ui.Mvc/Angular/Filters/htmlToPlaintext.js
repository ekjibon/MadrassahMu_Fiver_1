'use strict';
baseModule
    .filter('htmlToPlaintext', function () {
    return function (text) {
        return String(text).replace(/<[^>]+>/gm, '');
    };
});
//# sourceMappingURL=htmlToPlaintext.js.map