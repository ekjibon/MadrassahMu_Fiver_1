var downloadResponseService = /** @class */ (function () {
    function downloadResponseService() {
    }
    downloadResponseService.prototype.manageReponse = function (response) {
        var _navigator = navigator;
        var _window = window;
        var data = response.data;
        var headers = response.headers;
        var status = response.status;
        var octetStreamMime = 'application/octet-stream';
        var success = false;
        // Get the headers
        headers = headers();
        var filename = headers['x-filename'];
        if (filename == null || filename == undefined && headers["content-disposition"] != null && headers["content-disposition"] != undefined) {
            var contentDispositions = headers["content-disposition"].split(";");
            var filenameHeader = contentDispositions.filter(function (content) {
                return content.indexOf("filename=") > -1;
            });
            if (filenameHeader != null && filenameHeader != undefined && filenameHeader[0]) {
                filename = filenameHeader[0].split("=")[1];
            }
        }
        // Get the filename from the x-filename header or default to "download.bin"
        filename = filename || 'download.bin';
        filename = filename.replaceAll('"', '');
        // Determine the content type from the header or default to "application/octet-stream"
        var contentType = headers['content-type'] || octetStreamMime;
        try {
            // Try using msSaveBlob if supported
            console.log("Trying saveBlob method ...");
            var blob = new Blob([data], { type: contentType });
            if (_navigator.msSaveBlob)
                _navigator.msSaveBlob(blob, filename);
            else {
                // Try using other saveBlob implementations, if available
                var saveBlob = _navigator.webkitSaveBlob || _navigator.mozSaveBlob || _navigator.saveBlob;
                if (saveBlob === undefined)
                    throw "Not supported";
                saveBlob(blob, filename);
            }
            console.log("saveBlob succeeded");
            success = true;
            return true;
        }
        catch (ex) {
            console.log("saveBlob method failed with the following exception:");
        }
        if (!success) {
            // Get the blob url creator
            var urlCreator = _window.URL || _window.webkitURL || _window.mozURL || _window.msURL;
            if (urlCreator) {
                // Try to use a download link
                var link = document.createElement('a');
                if ('download' in link) {
                    // Try to simulate a click
                    try {
                        // Prepare a blob URL
                        console.log("Trying download link method with simulated click ...");
                        var blob = new Blob([data], { type: contentType });
                        var url = urlCreator.createObjectURL(blob);
                        link.setAttribute('href', url);
                        // Set the download attribute (Supported in Chrome 14+ / Firefox 20+)
                        link.setAttribute("download", filename);
                        // Simulate clicking the download link
                        var event = document.createEvent('MouseEvents');
                        event.initMouseEvent('click', true, true, window, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
                        link.dispatchEvent(event);
                        console.log("Download link method with simulated click succeeded");
                        success = true;
                        return true;
                    }
                    catch (ex) {
                        console.log("Download link method with simulated click failed with the following exception:");
                        console.log(ex);
                    }
                }
                if (!success) {
                    // Fallback to window.location method
                    try {
                        // Use application/octet-stream when using window.location to force download
                        console.log("Trying download link method with window.location ...");
                        var blob = new Blob([data], { type: octetStreamMime });
                        var url = urlCreator.createObjectURL(blob);
                        //window.location = url;
                        console.log("Download link method with window.location succeeded");
                        success = true;
                        return true;
                    }
                    catch (ex) {
                        console.log("Download link method with window.location failed with the following exception:");
                        console.log(ex);
                    }
                }
            }
        }
        if (!success) {
            return false;
        }
    };
    return downloadResponseService;
}());
//# sourceMappingURL=download-response-service.js.map