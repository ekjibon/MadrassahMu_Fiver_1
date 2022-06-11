enum customerTypeEnum {
    PERSON = 1,
    COMPANY = 2
}

enum documentTypeEnum {
    PERSON_COVER_PHOTO = 2,
    PERSON_PROFILE_PICTURE = 3,
    PERSON_WORK_EXPERIENCE_MEDIA = 4,
    PERSON_EDUCATION_MEDIA = 5,
    COMPANY_LOGO = 6,
    COMPANY_PHOTO = 7,
    COMPANY_PRODUCT = 8,
    QR_CODE = 9,
    FILE_ICON = 10009,
    FLIPBOOK_DOCUMENT = 10010,
    CODE_PHOTO = 20011,
}

enum hostedDomainTypeEnum {
    PERSON = 1,
    COMPANY = 2
}

enum codeTypeEnum {
    QRCode = 1,
    Barcode = 2
}

enum codeActionEnum {
    shareProfile = 1,
    shareCompany = 2,
    registerToEntity = 3
}

enum workflowTransitionActionReturnMetaEnum {
    NONE = 1,
    OPEN_WEB_PAGE = 2,
    OUTPUT_DATA_TO_CLIENT = 3
}

enum contactTypeEnum {

    WEBSITE = 1,
    PHONE = 2,
    EMAIL_ADDRESS = 3,
    INSTANT_MESSENGER = 4,
    PERSONAL = 5,
    COMPANY = 6,
    BLOG = 7,
    RSS_FEED = 8,
    PORTFOLIO = 9,
    OTHER = 10,
    MOBILE = 11,
    HOME = 12,
    WORK = 13,
    SKYPE = 14,
    AIM = 15,
    YAHOO_MESSENGER = 16,
    GOOGLE_HANGOUTS = 17,
    QQ = 18,
    WECHAT = 19
}

enum parameterEnum {
    MAX_FILE_SIZE_FOR_FLIPBOOK = 12
}

enum flipBookStateEnum {
    PENDING_UPLOAD = 1,
    UPLOADED = 2,
    PROCESSING = 3,
    PROCESSED = 4,
    PENDING_PROCESSING = 5,
    ERROR_IN_PROCESSING = 6
}

enum flipBookDetailTypeEnum {
    PRE = 1,
    THUMB = 2,
    HQ = 3,
    IMG = 4,
    SPLIT = 5,
    MAIN_DOCUMENT = 6,
}

enum productTypeEnum {
    SERVICE = 1
}

enum sessionVariableSpaceEnum {
    TRANSACTION_SALE_DETAIL_BASIC_INFO_CONTROLLER = 1,
    TRANSFER = 2,
    BANK_RECONCILIATION_CONTROLLER = 3,
    BANK_RECONCILIATION_CURRENT_LINE_ID = 4,
    TRANSACTION_INITIALIZER = 5,
    TRANSACTION_SALE_LISTING_PER_CUSTOMER = 6,
    EMAIL_BATCH_DETAIL_BATCH = 7,
    EMAIL_BATCH_DETAIL_BATCH_DATA = 8,
    CUSTOMER_INITIALIZER = 9,
    STOCK_LISTING_CONTROLLER = 10,
    PAYMENT_CONTROLLER = 11
}

enum bankStatementStagingStateEnum {
    AWAITING_PROCESS = 1,
    PROCESSING_DONE = 2,
}

enum companyTypeEnum {
    PERSON = 1,
    COMPANY = 2
}

enum signatureStateEnum {
    AWAITING_SIGNATURE = 1,
    SIGNATURE_DONE = 2,
    SIGNATURE_SAVED = 3
}

enum mailStatusEnum {
    PENDING = 1,
    IN_PROGRESS = 2,
    FAILED = 3,
    SUCCESS = 4,
    READY = 5
}

enum orderStateEnum {
    PENDING = 1,
    CONVERTED_TO_TRANSACTION = 2
}

enum bankReconOrderProcessStateEnum {
    AWAITING_PROCESSING = 1,
    PROCESSED = 2,
}

enum subscriptionEnum {
    SELECT_CUSTOMER = 1,
    SELECT_TRANSACTION = 2,
}