var customerTypeEnum;
(function (customerTypeEnum) {
    customerTypeEnum[customerTypeEnum["PERSON"] = 1] = "PERSON";
    customerTypeEnum[customerTypeEnum["COMPANY"] = 2] = "COMPANY";
})(customerTypeEnum || (customerTypeEnum = {}));
var documentTypeEnum;
(function (documentTypeEnum) {
    documentTypeEnum[documentTypeEnum["PERSON_COVER_PHOTO"] = 2] = "PERSON_COVER_PHOTO";
    documentTypeEnum[documentTypeEnum["PERSON_PROFILE_PICTURE"] = 3] = "PERSON_PROFILE_PICTURE";
    documentTypeEnum[documentTypeEnum["PERSON_WORK_EXPERIENCE_MEDIA"] = 4] = "PERSON_WORK_EXPERIENCE_MEDIA";
    documentTypeEnum[documentTypeEnum["PERSON_EDUCATION_MEDIA"] = 5] = "PERSON_EDUCATION_MEDIA";
    documentTypeEnum[documentTypeEnum["COMPANY_LOGO"] = 6] = "COMPANY_LOGO";
    documentTypeEnum[documentTypeEnum["COMPANY_PHOTO"] = 7] = "COMPANY_PHOTO";
    documentTypeEnum[documentTypeEnum["COMPANY_PRODUCT"] = 8] = "COMPANY_PRODUCT";
    documentTypeEnum[documentTypeEnum["QR_CODE"] = 9] = "QR_CODE";
    documentTypeEnum[documentTypeEnum["FILE_ICON"] = 10009] = "FILE_ICON";
    documentTypeEnum[documentTypeEnum["FLIPBOOK_DOCUMENT"] = 10010] = "FLIPBOOK_DOCUMENT";
    documentTypeEnum[documentTypeEnum["CODE_PHOTO"] = 20011] = "CODE_PHOTO";
})(documentTypeEnum || (documentTypeEnum = {}));
var hostedDomainTypeEnum;
(function (hostedDomainTypeEnum) {
    hostedDomainTypeEnum[hostedDomainTypeEnum["PERSON"] = 1] = "PERSON";
    hostedDomainTypeEnum[hostedDomainTypeEnum["COMPANY"] = 2] = "COMPANY";
})(hostedDomainTypeEnum || (hostedDomainTypeEnum = {}));
var codeTypeEnum;
(function (codeTypeEnum) {
    codeTypeEnum[codeTypeEnum["QRCode"] = 1] = "QRCode";
    codeTypeEnum[codeTypeEnum["Barcode"] = 2] = "Barcode";
})(codeTypeEnum || (codeTypeEnum = {}));
var codeActionEnum;
(function (codeActionEnum) {
    codeActionEnum[codeActionEnum["shareProfile"] = 1] = "shareProfile";
    codeActionEnum[codeActionEnum["shareCompany"] = 2] = "shareCompany";
    codeActionEnum[codeActionEnum["registerToEntity"] = 3] = "registerToEntity";
})(codeActionEnum || (codeActionEnum = {}));
var workflowTransitionActionReturnMetaEnum;
(function (workflowTransitionActionReturnMetaEnum) {
    workflowTransitionActionReturnMetaEnum[workflowTransitionActionReturnMetaEnum["NONE"] = 1] = "NONE";
    workflowTransitionActionReturnMetaEnum[workflowTransitionActionReturnMetaEnum["OPEN_WEB_PAGE"] = 2] = "OPEN_WEB_PAGE";
    workflowTransitionActionReturnMetaEnum[workflowTransitionActionReturnMetaEnum["OUTPUT_DATA_TO_CLIENT"] = 3] = "OUTPUT_DATA_TO_CLIENT";
})(workflowTransitionActionReturnMetaEnum || (workflowTransitionActionReturnMetaEnum = {}));
var contactTypeEnum;
(function (contactTypeEnum) {
    contactTypeEnum[contactTypeEnum["WEBSITE"] = 1] = "WEBSITE";
    contactTypeEnum[contactTypeEnum["PHONE"] = 2] = "PHONE";
    contactTypeEnum[contactTypeEnum["EMAIL_ADDRESS"] = 3] = "EMAIL_ADDRESS";
    contactTypeEnum[contactTypeEnum["INSTANT_MESSENGER"] = 4] = "INSTANT_MESSENGER";
    contactTypeEnum[contactTypeEnum["PERSONAL"] = 5] = "PERSONAL";
    contactTypeEnum[contactTypeEnum["COMPANY"] = 6] = "COMPANY";
    contactTypeEnum[contactTypeEnum["BLOG"] = 7] = "BLOG";
    contactTypeEnum[contactTypeEnum["RSS_FEED"] = 8] = "RSS_FEED";
    contactTypeEnum[contactTypeEnum["PORTFOLIO"] = 9] = "PORTFOLIO";
    contactTypeEnum[contactTypeEnum["OTHER"] = 10] = "OTHER";
    contactTypeEnum[contactTypeEnum["MOBILE"] = 11] = "MOBILE";
    contactTypeEnum[contactTypeEnum["HOME"] = 12] = "HOME";
    contactTypeEnum[contactTypeEnum["WORK"] = 13] = "WORK";
    contactTypeEnum[contactTypeEnum["SKYPE"] = 14] = "SKYPE";
    contactTypeEnum[contactTypeEnum["AIM"] = 15] = "AIM";
    contactTypeEnum[contactTypeEnum["YAHOO_MESSENGER"] = 16] = "YAHOO_MESSENGER";
    contactTypeEnum[contactTypeEnum["GOOGLE_HANGOUTS"] = 17] = "GOOGLE_HANGOUTS";
    contactTypeEnum[contactTypeEnum["QQ"] = 18] = "QQ";
    contactTypeEnum[contactTypeEnum["WECHAT"] = 19] = "WECHAT";
})(contactTypeEnum || (contactTypeEnum = {}));
var parameterEnum;
(function (parameterEnum) {
    parameterEnum[parameterEnum["MAX_FILE_SIZE_FOR_FLIPBOOK"] = 12] = "MAX_FILE_SIZE_FOR_FLIPBOOK";
})(parameterEnum || (parameterEnum = {}));
var flipBookStateEnum;
(function (flipBookStateEnum) {
    flipBookStateEnum[flipBookStateEnum["PENDING_UPLOAD"] = 1] = "PENDING_UPLOAD";
    flipBookStateEnum[flipBookStateEnum["UPLOADED"] = 2] = "UPLOADED";
    flipBookStateEnum[flipBookStateEnum["PROCESSING"] = 3] = "PROCESSING";
    flipBookStateEnum[flipBookStateEnum["PROCESSED"] = 4] = "PROCESSED";
    flipBookStateEnum[flipBookStateEnum["PENDING_PROCESSING"] = 5] = "PENDING_PROCESSING";
    flipBookStateEnum[flipBookStateEnum["ERROR_IN_PROCESSING"] = 6] = "ERROR_IN_PROCESSING";
})(flipBookStateEnum || (flipBookStateEnum = {}));
var flipBookDetailTypeEnum;
(function (flipBookDetailTypeEnum) {
    flipBookDetailTypeEnum[flipBookDetailTypeEnum["PRE"] = 1] = "PRE";
    flipBookDetailTypeEnum[flipBookDetailTypeEnum["THUMB"] = 2] = "THUMB";
    flipBookDetailTypeEnum[flipBookDetailTypeEnum["HQ"] = 3] = "HQ";
    flipBookDetailTypeEnum[flipBookDetailTypeEnum["IMG"] = 4] = "IMG";
    flipBookDetailTypeEnum[flipBookDetailTypeEnum["SPLIT"] = 5] = "SPLIT";
    flipBookDetailTypeEnum[flipBookDetailTypeEnum["MAIN_DOCUMENT"] = 6] = "MAIN_DOCUMENT";
})(flipBookDetailTypeEnum || (flipBookDetailTypeEnum = {}));
var productTypeEnum;
(function (productTypeEnum) {
    productTypeEnum[productTypeEnum["SERVICE"] = 1] = "SERVICE";
})(productTypeEnum || (productTypeEnum = {}));
var sessionVariableSpaceEnum;
(function (sessionVariableSpaceEnum) {
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["TRANSACTION_SALE_DETAIL_BASIC_INFO_CONTROLLER"] = 1] = "TRANSACTION_SALE_DETAIL_BASIC_INFO_CONTROLLER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["TRANSFER"] = 2] = "TRANSFER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["BANK_RECONCILIATION_CONTROLLER"] = 3] = "BANK_RECONCILIATION_CONTROLLER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["BANK_RECONCILIATION_CURRENT_LINE_ID"] = 4] = "BANK_RECONCILIATION_CURRENT_LINE_ID";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["TRANSACTION_INITIALIZER"] = 5] = "TRANSACTION_INITIALIZER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["TRANSACTION_SALE_LISTING_PER_CUSTOMER"] = 6] = "TRANSACTION_SALE_LISTING_PER_CUSTOMER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["EMAIL_BATCH_DETAIL_BATCH"] = 7] = "EMAIL_BATCH_DETAIL_BATCH";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["EMAIL_BATCH_DETAIL_BATCH_DATA"] = 8] = "EMAIL_BATCH_DETAIL_BATCH_DATA";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["CUSTOMER_INITIALIZER"] = 9] = "CUSTOMER_INITIALIZER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["STOCK_LISTING_CONTROLLER"] = 10] = "STOCK_LISTING_CONTROLLER";
    sessionVariableSpaceEnum[sessionVariableSpaceEnum["PAYMENT_CONTROLLER"] = 11] = "PAYMENT_CONTROLLER";
})(sessionVariableSpaceEnum || (sessionVariableSpaceEnum = {}));
var bankStatementStagingStateEnum;
(function (bankStatementStagingStateEnum) {
    bankStatementStagingStateEnum[bankStatementStagingStateEnum["AWAITING_PROCESS"] = 1] = "AWAITING_PROCESS";
    bankStatementStagingStateEnum[bankStatementStagingStateEnum["PROCESSING_DONE"] = 2] = "PROCESSING_DONE";
})(bankStatementStagingStateEnum || (bankStatementStagingStateEnum = {}));
var companyTypeEnum;
(function (companyTypeEnum) {
    companyTypeEnum[companyTypeEnum["PERSON"] = 1] = "PERSON";
    companyTypeEnum[companyTypeEnum["COMPANY"] = 2] = "COMPANY";
})(companyTypeEnum || (companyTypeEnum = {}));
var signatureStateEnum;
(function (signatureStateEnum) {
    signatureStateEnum[signatureStateEnum["AWAITING_SIGNATURE"] = 1] = "AWAITING_SIGNATURE";
    signatureStateEnum[signatureStateEnum["SIGNATURE_DONE"] = 2] = "SIGNATURE_DONE";
    signatureStateEnum[signatureStateEnum["SIGNATURE_SAVED"] = 3] = "SIGNATURE_SAVED";
})(signatureStateEnum || (signatureStateEnum = {}));
var mailStatusEnum;
(function (mailStatusEnum) {
    mailStatusEnum[mailStatusEnum["PENDING"] = 1] = "PENDING";
    mailStatusEnum[mailStatusEnum["IN_PROGRESS"] = 2] = "IN_PROGRESS";
    mailStatusEnum[mailStatusEnum["FAILED"] = 3] = "FAILED";
    mailStatusEnum[mailStatusEnum["SUCCESS"] = 4] = "SUCCESS";
    mailStatusEnum[mailStatusEnum["READY"] = 5] = "READY";
})(mailStatusEnum || (mailStatusEnum = {}));
var orderStateEnum;
(function (orderStateEnum) {
    orderStateEnum[orderStateEnum["PENDING"] = 1] = "PENDING";
    orderStateEnum[orderStateEnum["CONVERTED_TO_TRANSACTION"] = 2] = "CONVERTED_TO_TRANSACTION";
})(orderStateEnum || (orderStateEnum = {}));
var bankReconOrderProcessStateEnum;
(function (bankReconOrderProcessStateEnum) {
    bankReconOrderProcessStateEnum[bankReconOrderProcessStateEnum["AWAITING_PROCESSING"] = 1] = "AWAITING_PROCESSING";
    bankReconOrderProcessStateEnum[bankReconOrderProcessStateEnum["PROCESSED"] = 2] = "PROCESSED";
})(bankReconOrderProcessStateEnum || (bankReconOrderProcessStateEnum = {}));
var subscriptionEnum;
(function (subscriptionEnum) {
    subscriptionEnum[subscriptionEnum["SELECT_CUSTOMER"] = 1] = "SELECT_CUSTOMER";
    subscriptionEnum[subscriptionEnum["SELECT_TRANSACTION"] = 2] = "SELECT_TRANSACTION";
})(subscriptionEnum || (subscriptionEnum = {}));
//# sourceMappingURL=angular-project-enum.js.map