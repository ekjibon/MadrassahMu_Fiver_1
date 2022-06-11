enum LOGIN_STATUS {
    Success = 0,
    LockedOut = 1,
    RequiresVerification = 2,
    Failure = 3
}

enum CUSTOMER_TYPE {
    PERSON = 1,
    COMPANY = 2
}

enum SIGNALR_MESSAGE_TYPE {
    FLIPBOOK_COVERSION_COMPLETED = 1,
    FLIPBOOK_COVERSION_PROGRESS = 2
}

enum SIGNALR_CONNECTION_TYPE {
    USER = 1,
    OTHER = 2
}