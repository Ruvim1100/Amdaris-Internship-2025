--BEGIN TRY
--    BEGIN TRANSACTION;
--
--    COMMIT;
--END TRY
--BEGIN CATCH
--    ROLLBACK;
--    PRINT ERROR_MESSAGE();
--END CATCH

--Change Employee Departament
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE [HumanResources].[EmployeeDepartmentHistory]
    SET EndDate = GETDATE()
    WHERE BusinessEntityID = 165 AND EndDate IS NULL;

    INSERT INTO [HumanResources].[EmployeeDepartmentHistory] (BusinessEntityID, DepartmentID, ShiftID, StartDate)
    VALUES (165, 4, 2, GETDATE());

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH


--Delete Customer and related entities
BEGIN TRY
    BEGIN TRANSACTION;
    DELETE FROM Sales.SalesOrderDetail 
    WHERE SalesOrderID IN (
        SELECT SalesOrderID FROM Sales.SalesOrderHeader WHERE CustomerID = 29614);

    DELETE FROM Sales.SalesOrderHeader 
    WHERE CustomerID = 29614;

    DELETE FROM Sales.Customer 
    WHERE CustomerID = 29614;
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH


----CHECK
--SELECT p.BusinessEntityID
--FROM [Person].[Person] p
--WHERE NOT EXISTS (
--    SELECT 1 
--    FROM [HumanResources].[Employee] e
--    WHERE e.BusinessEntityID = p.BusinessEntityID
--)

--New employee in departament
BEGIN TRY
    BEGIN TRANSACTION;
	INSERT INTO [HumanResources].[Employee]
		([BusinessEntityID],[NationalIDNumber],[LoginID],[JobTitle],[BirthDate],[MaritalStatus],[Gender],[HireDate],
		[SalariedFlag],[VacationHours],[SickLeaveHours],[CurrentFlag],[rowguid],[ModifiedDate])
	VALUES(11770, 2958472841, 'adventurqe-works\ken012', 'Chief Executive Officer', '1969-01-29', 'S', 'M', GETDATE(),
		1, 0, 0, 1, NEWID(), GETDATE())

	INSERT INTO HumanResources.EmployeeDepartmentHistory (BusinessEntityID, DepartmentID, ShiftID, StartDate)
    VALUES (11770, 3, 1, GETDATE());
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

--Update Employee job title and salary
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE HumanResources.Employee
    SET JobTitle = '.NET Developer'
    WHERE BusinessEntityID = 282;

    UPDATE HumanResources.EmployeePayHistory
    SET Rate = Rate * 1.15
    WHERE BusinessEntityID = 282;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

--Delete empolyee history and set new flag
BEGIN TRY
    BEGIN TRANSACTION;

    DELETE FROM HumanResources.EmployeeDepartmentHistory WHERE BusinessEntityID = 286;
    DELETE FROM HumanResources.EmployeePayHistory WHERE BusinessEntityID = 286;
    UPDATE [HumanResources].[Employee] 
	SET [CurrentFlag] = 0
	WHERE BusinessEntityID = 286;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

--Change product Price and cost history
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE Production.Product
    SET ListPrice = 93
    WHERE ProductID = 441;

    INSERT INTO Production.ProductCostHistory (ProductID, StandardCost, StartDate)
    VALUES (441, 20.00, GETDATE());

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

--New Employee
BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO Person.Person (PersonType, FirstName, LastName, BusinessEntityID)
    VALUES ('EM', 'John', 'Doe', 300);
    
    INSERT INTO HumanResources.Employee (BusinessEntityID, NationalIDNumber, LoginID, JobTitle, BirthDate, MaritalStatus, Gender, HireDate)
    VALUES (300, '123456789', 'adventure-works\jdoe', 'Engineer', '1985-04-04', 'M', 'M', GETDATE());

    INSERT INTO HumanResources.EmployeeDepartmentHistory (BusinessEntityID, DepartmentID, ShiftID, StartDate)
    VALUES (300, 4, 2, GETDATE());

    COMMIT;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

--Update Person data
BEGIN TRY
    BEGIN TRANSACTION;

    UPDATE Person.Person
    SET FirstName = 'Vasliliy', LastName = 'Goloborodko'
    WHERE BusinessEntityID = 113;

    UPDATE Person.EmailAddress
    SET EmailAddress = 'vasilit.@amdaris.com'
    WHERE BusinessEntityID = 113;

    UPDATE Person.PersonPhone
    SET PhoneNumber = '32-3-44'
    WHERE BusinessEntityID = 113;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

--Change product location
BEGIN TRY
    BEGIN TRANSACTION;

	UPDATE Production.ProductInventory
	SET Quantity = Quantity + 5
	WHERE ProductID = 349 AND LocationID = 1;

	UPDATE Production.ProductInventory
	SET Quantity = Quantity - 5
	WHERE ProductID = 349 AND LocationID = 50;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH

----Create new Product
--BEGIN TRY
--    BEGIN TRANSACTION;

--    INSERT INTO Production.Product (Name, ProductNumber, SafetyStockLevel, StandardCost, ListPrice, SellStartDate)
--    VALUES ('Drone', 'shahed 3000', 500, 250, 600, GETDATE());

--	DECLARE @NewID INT = SCOPE_IDENTITY();

--    INSERT INTO Production.ProductModel (Name, CatalogDescription)
--    VALUES ('Child toy Model', NULL);

--	DECLARE @NewModelID INT = SCOPE_IDENTITY();

--    UPDATE Production.Product
--    SET ProductModelID = @NewID
--    WHERE ProductID = @NewModelID;

--    COMMIT;
--END TRY
--BEGIN CATCH
--    ROLLBACK;
--    PRINT ERROR_MESSAGE();
--END CATCH