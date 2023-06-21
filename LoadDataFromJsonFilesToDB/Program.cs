
// Create DB Context

using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
optionsBuilder
    .UseSqlServer("Data Source=DESKTOP-H8DOV00\\SQLEXPRESS;Initial Catalog=LoadFromJsonFiles;Integrated Security=True;TrustServerCertificate=True");

var context = new DataContext(optionsBuilder.Options);

// Delete all existing weatherforecasts in DB
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
















