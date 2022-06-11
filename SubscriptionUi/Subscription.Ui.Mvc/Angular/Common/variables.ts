class TOASTER_TYPE {
    static SUCCESS = "success";
    static INFO = "info";
    static WAIT = "wait";
    static WARNING = "warning";
    static ERROR = "error";
}
class ALERT_MESSAGE_TYPE {
    static WARNING = "warning";
    static SUCCESS = "success";
    static ERROR = "error";
}

class STATUS_MESSAGE {
    static SUCCESS = 10;
    static FAILURE = 11;
    static SERVERERROR = 12;
    static AUTHERROR = 13;
    static TOKENEXPIRED = 15;
    static TOKENINVALID = 16;
    static VALIDATION_ERROR = 17
}
enum SCREEN_MODE {
    VIEW,
    ADD,
    EDIT
}

enum Menu {
    SELECT_CUSTOMER = 1,
    SELECT_TRANSACTION = 2,
    DEFINE_FREQUENCY = 3,
    SUMMARY = 4,
    DEFINE_PAYMENT = 5,
    VIEW_SCHEDULED_TRANSACTIONS = 6,
    SCHEDULE_DETAILS = 7,
    PAYMENT_SCHEDULE_DETAILS = 8,
    FREQUENCY_SCHEDULE_DETAILS = 9,
}

class layoutCustomisation {
    name: string;
    author: string;
    description: string;
    version: string;
    year: number;
    isMobile: boolean;
    layout: {
        isNavbarFixed: boolean;
        isSidebarFixed: boolean;
        isSidebarClosed: boolean;
        isFooterFixed: boolean;
        theme: string;
        logo: string;
        isSidebarToggable: boolean
    }
}

class STATE_MAPPER {

}
class CUSTOM_VARIABLES {
    static AUTHKEY = "authKey";
    static PERMISSIONKEY = "permissionKey";
    static CURRENT_USER = "currentUser";
    static ROLE = "role";
    static LAYOUT = "layout";
    static ON_INITIALIZED = "ON_INITIALIZED";
    static PROFILE_NO_IMAGE = eval('globalBaseServerUrl') + "Images/blank-profile-cover-image.png";
    static IMAGES_EXTENSION = ['.tif', '.jpg', '.jpeg', '.gif', '.png'];
}



class PERMISSION {
}

enum SignInStatus {
    Success = 0,
    LockedOut = 1,
    RequiresVerification = 2,
    Failure = 3
}

class URL_LIST {
    static HOME = ""
    static AUTH = "Authentication/Authentication/Authentication"
    static TRANSACTION = "Transaction/Transaction/TransactionSaleListing"
    static DASHBOARD = "Administration/AdministrationDashboard/Index"
}

class MAP_DATA {
    static openStreetMapLayer = {
        name: "OpenStreetMap",
        url: "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
        type: "xyz",
        layerOptions: {
            attribution: "",
            maxNativeZoom: 18,
            maxZoom: 25
        }
    };
    static googleRoadmap = {
        name: "Google Streets",
        layerType: "ROADMAP",
        type: "google"
    };

    static centerLocation = {
        lat: -20.276326,
        lng: 57.557105,
        zoom: 10
    }

    static markerUrl = "Images/picto-pointer.png";
    static markerSvg = "data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 60 60'><path data-name='layer1' d='M32 2a18 18 0 0 0-18 18 18.1 18.1 0 0 0 .2 2.2C15.7 36.8 32 44.9 32 62c0-17.1 16.3-25.2 17.8-39.7A17.9 17.9 0 0 0 32 2zm0 24a6 6 0 1 1 6-6 6 6 0 0 1-6 6z'></path></svg>";

    static getSvgMarker(color: string) {
        var self = this;
        var svgMarkerIcon = MAP_DATA.markerSvg.replace(new RegExp('{{color}}', 'g'), color);
        var icon = {
            iconSize: [38, 38],
            iconUrl: svgMarkerIcon
        }
        //if (navigator.appCodeName == "Mozilla") {
        //    svgMarkerIcon = svgMarkerIcon.replace(new RegExp('#', 'g'), "%23");
        //}

        return icon;
    }
}

declare var L;
