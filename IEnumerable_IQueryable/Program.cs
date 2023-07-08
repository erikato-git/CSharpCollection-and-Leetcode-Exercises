
using IEnumerable_IQueryable;
using System.Diagnostics;

var db = new ORM();


// ---- IEnumerable ---- //

IEnumerable<Customer> e = db.GetCustomersAsEnumerable();
// e <- 100 customers

var highPayCustomers = e.Where(e => e.Revenue > 500);
// highPayCustomers <- 50 customers

var finalData = highPayCustomers.ToList();



// ----- IQueryable ---- //

IQueryable<Customer> q = db.GetCustomersAsQueryable();
// q <- 0 customers

highPayCustomers = q.Where(e => e.Revenue > 500);
// highPayCustomers <- 0

finalData = highPayCustomers.ToList();
// finalData <- 100 customers
// When calling ToList() the query will be executed from the db, like: Select * from Customers Where Revenue > 500


// Conclusion: IEnumerable uses two queries and load all data from db into the server while IQueryable executes the whole SQL-script when needed
