USE AdventureWorks2022;

--Clinets with 20 and more orders
SELECT *
FROM [Sales].[Customer] c
WHERE (
    SELECT COUNT(*)
    FROM [Sales].[SalesOrderHeader] soh
    WHERE soh.CustomerID = c.CustomerID
) > 20;

--Persons with rate higher then average
SELECT p.BusinessEntityID, p.FirstName, p.LastName
FROM [Person].[Person] p
WHERE EXISTS (SELECT 1
				FROM [HumanResources].[EmployeePayHistory] ep
				WHERE ep.BusinessEntityID = P.BusinessEntityID
				AND ep.Rate > (SELECT AVG(Rate) FROM [HumanResources].[EmployeePayHistory]));

--Product types (> or < then average price)
SELECT p.ProductID, 
	   p.Name, 
	   p.ListPrice, 
	   CASE
			WHEN ListPrice > (SELECT AVG(ListPrice) FROM [Production].[Product] WHERE ListPrice > 0)
			THEN 'EXPENSIVE'
			ELSE 'CHEAP'
	   END AS PriceType
FROM [Production].[Product] p
WHERE ListPrice > 0;

--Persons from Marketing departament
SELECT P.FirstName, p.LastName
FROM [Person].[Person] p
JOIN [HumanResources].[EmployeeDepartmentHistory] eh ON p.BusinessEntityID = eh.BusinessEntityID
WHERE eh.DepartmentID IN
	(SELECT hd.DepartmentID 
	FROM [HumanResources].[Department] hd 
	WHERE hd.Name = 'Marketing') AND eh.EndDate IS NULL;

--Number of employees in each department
SELECT d.Name, (SELECT COUNT(*) 
					   FROM [HumanResources].[EmployeeDepartmentHistory] eh
					   WHERE eh.DepartmentID = d.DepartmentID AND eh.EndDate IS NULL) 
					   AS EmployeeCount
FROM [HumanResources].[Department] d
ORDER BY EmployeeCount DESC;

--Customers who haven't ordered anything since 2014
SELECT p.BusinessEntityID, p.FirstName + p.LastName AS [Name]
FROM [Person].[Person] p
JOIN [Sales].[Customer] c ON p.BusinessEntityID = c.PersonID
WHERE NOT EXISTS (SELECT 1 FROM [Sales].[SalesOrderHeader] soh
					WHERE soh.CustomerID = c.CustomerID AND soh.OrderDate > '2014-01-01');

--Products that were never ordered
SELECT p.ProductID, p.Name
FROM (SELECT ProductID, [Name] FROM [Production].[Product]) AS p
WHERE p.ProductID NOT IN (SELECT DISTINCT sod.ProductID 
						  FROM [Sales].[SalesOrderDetail] sod);

--Employee salary chnaged two or more time
SELECT p.BusinessEntityID, p.FirstName + p.LastName AS FullName
FROM [Person].[Person] p
WHERE p.BusinessEntityID IN
	(SELECT eph.BusinessEntityID
	FROM [HumanResources].[EmployeePayHistory] eph
	GROUP BY eph.BusinessEntityID
	HAVING COUNT(*) > 1);