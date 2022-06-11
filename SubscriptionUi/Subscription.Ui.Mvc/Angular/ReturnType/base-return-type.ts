class baseReturnType<T> {
    constructor() { }
    hasException: boolean;
    exception: string;
    result: T
}

class baseListReturnType<T>{

    entityList: T;

    totalCount: number;

}

class baseGlobalReturnType {
    errorMessage: string
    hasError: boolean;
}

class baseResultReturnType<T> {
    status: STATUS_MESSAGE;
    errorMessage: string;
    id: string;
    result: T
}