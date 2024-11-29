-- RECOMMENDATION 1: One Item Per Line + Leading Comma

-- BAD PRACTICE:
select p.FirstName as first_name, p.LastName as last_name, e.EmailAddress as email from [Person].Person p
join [Person].EmailAddress e on e.BusinessEntityID = p.BusinessEntityID
order by p.FirstName

-- GOOD PRACTICE:
select
    p.FirstName as first_name
    , p.LastName as last_name
    , e.EmailAddress as email
from 
    [Person].person p
    join [Person].emailaddress e 
        on e.BusinessEntityID = p.BusinessEntityID
order by p.FirstName

-- RECOMMENDATION 2-3: Comments + СTE

-- BAD PRACTICE:

select 
	c.AccountNumber as account_number
	, p.FirstName + ' ' + p.LastName as customer_name
	, sum(sod.LineTotal) as total_sales
from sales.Customer c
    right join person.Person p 
        on c.PersonID = p.BusinessEntityID
    join [Sales].SalesOrderHeader soh
	    on c.CustomerID = soh.CustomerID
    join [Sales].SalesOrderDetail sod
	    on soh.SalesOrderID = sod.SalesOrderID
    where soh.Status = 5 and c.PersonID is not null
group by 
	c.AccountNumber
	, p.FirstName + ' ' + p.LastName

-- GOOD PRACTICE:

/*
    Calculates the total sales amount of completed orders for each active customer.
    Business logic includes:
    1. Selecting only active customers.
    2. Joining sales data with customer information.
    3. Summing up the total sales per customer.
*/

GO
with active_customers as (
    select 
        c.AccountNumber as account_number
        , c.CustomerID as customer_id
        , p.FirstName + ' ' + p.LastName as customer_name
    from 
        sales.Customer c
    right join person.Person p 
        on c.PersonID = p.BusinessEntityID
    where 
        c.PersonID is not null -- only include active customers
)

-- OPTIMIZATION: Use table variables for better performance
declare @ActiveCustomersTable table (
    account_number nvarchar(50),
    customer_id int,
    customer_name nvarchar(200)
);

insert into @ActiveCustomersTable 
    (
        account_number
        , customer_id
        , customer_name
    )
select 
    account_number
    , customer_id
    , customer_name
from 
    active_customers;

-- select * from @ActiveCustomersTable;

select 
	ac.account_number as account_number
	, ac.customer_name as customer_name
	, sum(sod.LineTotal) as total_sales
from @ActiveCustomersTable as ac
    join [Sales].SalesOrderHeader soh
	    on ac.customer_id = soh.CustomerID
    join [Sales].SalesOrderDetail sod
	    on soh.SalesOrderID = sod.SalesOrderID
    where soh.Status = 5 -- completed orders
group by 
	ac.account_number
	, ac.customer_name

GO


