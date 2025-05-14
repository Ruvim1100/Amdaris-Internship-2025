USE AdventureWorks2022;

--Number of employees in each department
SELECT d.DepartmentID, d.Name, COUNT(e.BusinessEntityID) AS Employees
FROM [HumanResources].[Department] d
JOIN [HumanResources].[EmployeeDepartmentHistory] dh ON D.DepartmentID = dh.DepartmentID
JOIN [HumanResources].[Employee] e ON dh.BusinessEntityID = e.BusinessEntityID
WHERE dh.EndDate IS NULL
GROUP BY d.DepartmentID, d.Name
ORDER BY Employees;

-- TOP 10 Best selling products
SELECT TOP 10 p.ProductID, sc.Name, p.Name, SUM(sod.OrderQty) AS Total
FROM [Production].[ProductSubcategory] sc
JOIN [Production].[Product] p ON sc.ProductSubcategoryID = p.ProductSubcategoryID
JOIN [Sales].[SalesOrderDetail] sod ON p.ProductID = sod.ProductID
GROUP BY p.ProductID, sc.Name, p.Name
ORDER BY Total DESC;

--Average price in each subcategory
SELECT sc.ProductSubcategoryID, sc.Name, AVG(p.ListPrice) AS AveragePrice
FROM [Production].[Product] p
JOIN [Production].[ProductSubcategory] sc ON P.ProductSubcategoryID = sc.ProductSubcategoryID
WHERE p.ListPrice > 0
GROUP BY sc.ProductSubcategoryID, sc.Name
ORDER BY AveragePrice DESC;

--City with the maximum number of people
SELECT a.City, COUNT(p.BusinessEntityID) AS NumberOfPeople
FROM [Person].[Person] p
JOIN [Person].[BusinessEntityAddress] pa ON p.BusinessEntityID = pa.BusinessEntityID
RIGHT JOIN [Person].[Address] a ON pa.AddressID = a.AddressID
GROUP BY a.City
ORDER BY NumberOfPeople DESC;

--Categories with maximum Price > 100
SELECT c.Name, MAX(p.ListPrice) AS MaxPrice
FROM [Production].[ProductCategory] c
JOIN [Production].[ProductSubcategory] sc ON c.ProductCategoryID = sc.ProductCategoryID
JOIN [Production].[Product] p ON sc.ProductSubcategoryID = p.ProductSubcategoryID
GROUP BY c.Name
HAVING MAX(p.ListPrice) > 100
ORDER BY MaxPrice DESC;

--SalesPersons with order > 100000
SELECT sp.BusinessEntityID, p.FirstName, MAX(soh.TotalDue) AS MaxOrder
FROM [Person].[Person] p
JOIN [Sales].[SalesPerson] sp ON p.BusinessEntityID = sp.BusinessEntityID
JOIN [Sales].[SalesOrderHeader] soh ON sp.BusinessEntityID = soh.SalesPersonID
GROUP BY sp.BusinessEntityID, p.FirstName
HAVING MAX(soh.TotalDue) > 100000
ORDER BY MaxOrder;

--Orders where difference between max and min price > 10000
SELECT soh.SalesOrderID, MAX(sod.LineTotal) - MIN(sod.LineTotal) AS Difference
FROM [Sales].[SalesOrderHeader] soh
JOIN [Sales].[SalesOrderDetail] sod ON soh.SalesOrderID = sod.SalesOrderID
GROUP BY soh.SalesOrderID
HAVING MAX(sod.LineTotal) - MIN(sod.LineTotal) > 10000
ORDER BY [Difference] DESC;

--Product Count in each category
SELECT pc.ProductCategoryID, pc.Name, COUNT(p.ProductID) AS ProductCount
FROM [Production].[ProductCategory] pc
JOIN [Production].[ProductSubcategory] psc ON pc.ProductCategoryID = psc.ProductCategoryID
JOIN [Production].[Product] p ON psc.ProductSubcategoryID = p.ProductSubcategoryID
GROUP BY pc.ProductCategoryID, pc.Name
ORDER BY ProductCount DESC;
