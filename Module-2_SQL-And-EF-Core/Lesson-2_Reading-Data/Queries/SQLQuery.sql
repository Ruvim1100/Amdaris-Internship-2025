USE [AdventureWorks2022];

-- Task #1
--From the Person.Person table write a query in SQL to return all rows 
--and a subset of the columns (FirstName, LastName, businessentityid) 
--from the person table in the AdventureWorks database. 
--The third column heading is renamed to Employee_id. 
--Arranged the output in ascending order by lastname.

SELECT FirstName, LastName, BusinessEntityID AS Employee_id
FROM [Person].[Person]
ORDER BY LastName;


-- Task #2
--From the Person.PersonPhone table write a query in SQL 
--to find the persons whose last name starts with letter 'L'. 
--Return BusinessEntityID, FirstName, LastName, and PhoneNumber. 
--Sort the result on lastname and firstname.

SELECT Person.BusinessEntityID, Person.FirstName, Person.LastName, Phone.PhoneNumber
FROM [Person].[Person] Person
JOIN [Person].[PersonPhone] Phone ON Person.BusinessEntityID = Phone.BusinessEntityID
WHERE Person.LastName LIKE 'L%'
ORDER BY Person.LastName, Person.FirstName;

--Task#3
--From the following tables: Sales.SalesPerson, Person.Person, Person.Address
--Write a query in SQL to retrieve the salesperson for each PostalCode who belongs 
--to a territory and SalesYTD is not zero. 
--Return row numbers of each group of PostalCode, 
--last name, salesytd, postalcode column. 
--Sort the salesytd of each postalcode group in descending order. 
--Shorts the postalcode in ascending order.
WITH PostalCodes as (SELECT PostalCode, COUNT(1) AS row_numbers FROM [Person].[Address] GROUP BY PostalCode)
SELECT
	p.LastName, 
	sp.SalesYTD, 
	pa.PostalCode,
	pc.row_numbers
FROM [Sales].[SalesPerson] sp
JOIN [Person].[Person] p ON sp.BusinessEntityID = p.BusinessEntityID
JOIN [Person].[BusinessEntityAddress] bea ON p.BusinessEntityID = bea.BusinessEntityID
JOIN [Person].[Address] pa ON bea.AddressID = pa.AddressID
JOIN PostalCodes pc ON pc.PostalCode = pa.PostalCode
WHERE SP.TerritoryID IS NOT NULL AND sp.SalesYTD > 0
ORDER BY pa.PostalCode, SalesYTD desc


--Task#4
--From the following table: Sales.SalesOrderDetail 
--Write a query in SQL to retrieve the total cost 
--of each salesorderID that exceeds 100000. 
--Return SalesOrderID, total cost.

SELECT
    SalesOrderID,
    SUM(LineTotal) AS TotalCost
FROM Sales.SalesOrderDetail
GROUP BY SalesOrderID
HAVING SUM(LineTotal) > 100000;