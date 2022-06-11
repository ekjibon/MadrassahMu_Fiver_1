var dateParser = {
    dateParserScreenMode: function (key, value) {
        var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*))(?:Z|(\+|-)([\d|:]*))?$/;
        var reZ = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})(?:Z|(\+|-))?$/;
        var reA = /(\d{4})-(\d{2})-(\d{2})T(\d{2})\:(\d{2})\:(\d{2})[+-](\d{2})\:(\d{2})/; //2019-07-30T00:00:00+04:00
        var dateToReturn;
        if (typeof value === 'string') {
            var a = reISO.exec(value);
            var b = reZ.exec(value);
            var c = reA.exec(value);
            if (a || b) {
                return new Date(value);
            }
            if (c) {
                return new Date(Date.parse(value));
            }
            //var dateConversion: any = new Date(Date.parse(value));
            //if (!isNaN(dateConversion) && dateConversion instanceof Date) {
            //    return dateConversion;
            //}
        }
        return value;
    },
    dateParserRequest: function (key, value) {
        var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*))(?:Z|(\+|-)([\d|:]*))?$/;
        var reMsAjax = /^\/Date\((d|-|.*)\)[\/|\\]$/;
        var reZ = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})(?:Z|(\+|-))?$/;
        if (typeof value === 'string') {
            var a = reISO.exec(value);
            var b = reZ.exec(value);
            if (a || b) {
                var initialDate = new Date(value);
                initialDate = initialDate.format("yyyy-m-dd");
                return initialDate;
            }
        }
        return value;
    },
    parseDateWithoutTime: function (value) {
        return value.format('yyyy-m-dd');
    },
    parseDateWithTime: function (value) {
        return value.format('yyyy-m-dd hh:mm:ss');
    }
};
function getMonthText(monthNumber) {
    var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    return months[monthNumber];
}
//# sourceMappingURL=date-conversion.js.map