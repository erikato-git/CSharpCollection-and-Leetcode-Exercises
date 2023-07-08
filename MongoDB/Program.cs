
using MongoDB.Driver;
using MongoDB;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;

// --- Set up --- //    Moved to DataAccess

//string connectionString = "mongodb://localhost:27017/";
//string databaseName = "simple_db";      // Creates db if not exist
//string collectionName = "people";

//var client = new MongoClient(connectionString);
//var db = client.GetDatabase(databaseName);
//var collection = db.GetCollection<PersonModel>(collectionName);



// --- 1.Test Connection ---- //

//var person = new PersonModel { FirstName = "Time", LastName = "Corey" };

//await collection.InsertOneAsync(person);
//var result = await collection.FindAsync(_ => true);     // returns all records / documents in db

//foreach(var item in result.ToList())
//{
//    Console.WriteLine($"{item.Id}: {item.FirstName} {item.LastName}" );
//} 



var db = new ChoreDataAccess();

await db.CreateUser(new UserModel { FirstName = "New Tim", LastName = "Corey" });
var users = await db.GetAllUsers();

var chore = new ChoreModel() { AsssignTo = users.FirstOrDefault(), ChoreText = "Mow the Lawn", FrequencyInDays = 7 };

await db.CreateChore(chore);    // The chore record is created with it associated user in the db, why its extremely fast to extract objects with its associated objects in NoSQL, it stores information together much as possible compared to SQL


Console.WriteLine("Check MongoDB Compas");






