BEGIN
	DECLARE	@IdUser int = 1;
	DECLARE	@Date date = '20211229';

	DECLARE @ChequeAmount float =0;
	DECLARE @OtherAmount float =0;
	DECLARE @user nvarchar(max) ='';
	
	SELECT SUM(A.TotalAmount) AS TotalAmount,A.TransactionPaymentType FROM(
		SELECT SUM(t.TotalAmount) AS TotalAmount ,t.IdTransaction,
		
		CASE WHEN MAX(pd.ChequeNo) IS NOT NULL THEN 'Cheque'
			 WHEN MAX(pd.ChequeNo) IS NULL THEN  'Cash' END AS TransactionPaymentType
		
		FROM Transact.[Transaction] t
		JOIN TRANSACT.[Payment] p
		ON p.IdPayment = t.IdPayment
		/*ON p.IdPayment = t.IdTransaction*/
		JOIN TRANSACT.[PaymentDetail] pd
		ON pd.IdPayment = p.IdPayment
		WHERE t.IdUserAuthor = @IdUser
		AND CONVERT(DATE,  t.TransactionDate) = @Date
		GROUP BY t.IdTransaction
	) AS A
	GROUP BY TransactionPaymentType
	
	SELECT @user = p.FirstName +' '+ p.LastName FROM IDT.[User] u
		JOIN Person.Person p
		on p.IdPerson = u.IdPerson
		WHERE u.IdUser = @IdUser
		SELECT @user AS [User]
END