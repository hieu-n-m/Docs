--1. Get information about United Kingdom customers with Country Region Code of GB including columns: FullName, BirthDate, Gender, EmailAddress, Education (English), Phone, AddressLine1, AddressLine2
--Note: FullName combines from FirstName, MiddleName, LastName Gender includes F and M, if F shows as Female, M shows as Male

select 
	concat(customer.FirstName, ' ', customer.MiddleName, ' ', customer.LastName) as Fullname,
	customer.BirthDate,
	case 
		when customer.Gender = 'M' then 'Male'
		when customer.Gender = 'F' then 'Female'
	end as Gender,
	customer.EmailAddress,
	customer.EnglishEducation,
	customer.Phone,
	customer.AddressLine1,
	customer.AddressLine2
from dbo.DimCustomer as customer
inner join dbo.DimGeography as geography
	on customer.GeographyKey = geography.GeographyKey
where geography.CountryRegionCode = 'GB'

--2. Total number of customers by country includes 2 columns: CountryName, TotalCustomer

select 
	count(customer.CustomerKey) as TotalCustomer, 
	geography.EnglishCountryRegionName as CountryName
from dbo.DimCustomer as customer
inner join dbo.DimGeography as geography
	on customer.GeographyKey = geography.GeographyKey
group by geography.EnglishCountryRegionName

--3. Get the top 100 products of the highest selling price (ListPrice) including the following columns: ProductName (English), ModelName, ProductLine, ProductCategoryName (English), ProductSubcategoryName (English), DealerPrice, ListPrice, Color, Description (English)

select top 100
	product.EnglishProductName,
	product.ModelName,
	product.ProductLine,
	category.EnglishProductCategoryName,
	subcategory.EnglishProductSubcategoryName,
	product.DealerPrice,
	product.ListPrice,
	product.Color,
	product.EnglishDescription
from dbo.DimProduct as product
inner join dbo.DimProductSubcategory as subcategory
	on product.ProductSubcategoryKey = subcategory.ProductSubcategoryKey
inner join dbo.DimProductCategory as category
	on subcategory.ProductCategoryKey = category.ProductCategoryKey
order by product.ListPrice desc

--4. Based on the financial table (FactFinace), calculate the total amount of transactions according to each specific type of accounting compared between the three regions France, Germany, Australia, including the following columns:  AccountDescription, France, Germany, Australia

with t as (
	select	
		account.AccountDescription,
		organization.OrganizationName,
		finance.Amount
	from dbo.FactFinance as finance
	inner join dbo.DimAccount as account
		on finance.AccountKey = account.AccountKey
	inner join dbo.DimOrganization as organization
		on finance.OrganizationKey = organization.OrganizationKey
	where organization.OrganizationName in ('France', 'Germany', 'Australia')
)
select 
	AccountDescription,
	France,
	Germany,
	Australia
from t
pivot (
	sum(Amount)
	for OrganizationName in (France, Germany, Australia)
) as pivot_t
order by AccountDescription

--5. Get the latest stock information of all products including the following columns: ProductKey, ProductName (English), ModelName, ProductCategoryName, ProductSubcategoryName, UnitsBalance, UnitCost

with t as (
	select 
		product.ProductKey as product, 
		max(date.DateKey) as datekey 
	from dbo.DimProduct as product
	inner join dbo.FactProductInventory as inventory
		on product.ProductKey = inventory.ProductKey
	inner join dbo.DimDate as date
		on inventory.DateKey = date.DateKey
	group by product.ProductKey
)
select 
	product.ProductKey,
	product.EnglishProductName,
	product.ModelName,
	category.EnglishProductCategoryName,
	subcategory.EnglishProductSubcategoryName,
	inventory.UnitsBalance,
	inventory.UnitCost
from dbo.DimProduct as product
inner join dbo.FactProductInventory as inventory
	on product.ProductKey = inventory.ProductKey
inner join dbo.DimProductSubcategory as subcategory
	on product.ProductSubcategoryKey = subcategory.ProductSubcategoryKey
inner join dbo.DimProductCategory as category
	on subcategory.ProductCategoryKey = category.ProductCategoryKey
inner join t 
	on t.product = product.ProductKey and t.datekey = inventory.DateKey

--6. Get the inventory information of the 10 products with the highest inventory value including the following columns: ProductName (English), ModelName, ProductCategoryName, ProductSubcategoryName, UnitsBalance, UnitCost

with t as (
	select top 10
		product.ProductKey as product,
		product.EnglishProductName,
		product.ModelName,
		product.ProductSubcategoryKey,
		inventory.UnitsBalance,
		inventory.UnitCost
	from dbo.DimProduct as product
	inner join dbo.FactProductInventory as inventory
		on product.ProductKey = inventory.ProductKey
	inner join dbo.DimDate as date
		on inventory.DateKey = date.DateKey
	order by date.DateKey desc, UnitCost desc
)
select 
	t.EnglishProductName,
	t.ModelName,
	category.EnglishProductCategoryName,
	subcategory.EnglishProductSubcategoryName,
	t.UnitsBalance,
	t.UnitCost
from t
inner join dbo.DimProductSubcategory as subcategory
	on t.ProductSubcategoryKey = subcategory.ProductSubcategoryKey
inner join dbo.DimProductCategory as category
	on subcategory.ProductCategoryKey = category.ProductCategoryKey

--7. Get the Internet Sales invoice details of the product whose English Name is "Road-150 Red, 48" including the following columns: SalesOrderNumber, SalesOrderLineNumber, CustomerName, ProductName, OrderQuantity, UnitPrice, DiscountAmount, SalesAmount, ProductStandardCost, TotalProductCost

select 
	sale.SalesOrderNumber,
	sale.SalesOrderLineNumber,
	concat(customer.FirstName, ' ', customer.MiddleName, ' ', customer.LastName) as CustomerName,
	product.EnglishProductName,
	sale.OrderQuantity,
	sale.UnitPrice,
	sale.DiscountAmount,
	sale.SalesAmount,
	sale.ProductStandardCost,
	sale.TotalProductCost
from dbo.FactInternetSales as sale
inner join dbo.DimCustomer as customer
	on sale.CustomerKey = customer.CustomerKey
inner join dbo.DimProduct as product
	on sale.ProductKey = product.ProductKey
where product.EnglishProductName = 'Road-150 Red, 48'

--8. Get information 20 Internet Sales invoices with the highest total payable including the following columns: CustomerName, SalesOrderNumber, CustomerKey, TotalOrderCost
--Note: SalesOrderNumber has multiple SalesOrderLineNumber

with t as (
	select
		sale.SalesOrderNumber,
		customer.CustomerKey,
		sum(sale.TotalProductCost) as TotalOrderCost
	from dbo.FactInternetSales as sale
	inner join dbo.DimCustomer as customer
		on sale.CustomerKey = customer.CustomerKey
	group by sale.SalesOrderNumber, customer.CustomerKey
)
select top 20
	concat(customer.FirstName, ' ', customer.MiddleName, ' ', customer.LastName) as CustomerName,
	t.SalesOrderNumber,
	t.CustomerKey,
	t.TotalOrderCost
from t
inner join dbo.DimCustomer as customer
	on t.CustomerKey = customer.CustomerKey
order by t.TotalOrderCost desc

--9. Get the top 10 resellers with the highest revenue including the following schools: ResellerName, ResellerKey, TotalQuantity, TotalOrderCost

with t as (
	select
		sale.ResellerKey,
		sum(sale.OrderQuantity) as TotalQuantity,
		sum(sale.TotalProductCost) as TotalOrderCost
	from dbo.FactResellerSales as sale
	inner join dbo.DimReseller as reseller
		on sale.ResellerKey = reseller.ResellerKey
	group by sale.ResellerKey
)
select top 10
	reseller.ResellerName,
	t.ResellerKey,
	t.TotalQuantity,
	t.TotalOrderCost
from t
inner join dbo.DimReseller as reseller
		on t.ResellerKey = reseller.ResellerKey
order by t.TotalOrderCost desc

