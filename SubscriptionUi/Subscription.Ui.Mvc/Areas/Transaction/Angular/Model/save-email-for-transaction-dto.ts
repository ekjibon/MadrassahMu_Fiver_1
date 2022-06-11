class saveEmailForTransactionDto {
    transactions: saveEmailForTransactioDetailDto[]
}

class saveEmailForTransactioDetailDto {
    idTransaction: number;
    emails: string[];
}