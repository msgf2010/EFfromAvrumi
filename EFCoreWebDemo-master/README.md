# Entity Framework Web Instructions:

First, you'll need to add a reference to the following NuGet packages. **MAKE SURE TO INSTALL VERSION 2.1.1 OF ALL THESE PACKAGES:**

* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Design
* Microsoft.Extensions.Configuration.FileExtensions
* Microsoft.Extensions.Configuration.Json

You can then go ahead and create your `DbContext` class, however, make sure to create a constructor that takes in a connection string. See how I did it here:

https://github.com/LITW06/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleContext.cs#L7-L12

Then, you'll need to create a class that implements the interface `IDesignTimeDbContextFactory<NameOfYourDbContext>`. See mine here:

https://github.com/LITW06/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleContextFactory.cs

You'll then need to change the directory on this line to match the name of your web project:

https://github.com/LITW06/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleContextFactory.cs#L12

(at the end of that line where it says `EFCoreWebDemo.Web` by mine, change it to match the name of _your_ web project)

Once you have all that set up, you can go to the command line, and **make sure to go into the data projects directory**. From there, you
can run both the `dotnet ef migrations add {SomeMigration}` and `dotnet ef database update` commands.

From there, you can create your repository classes as you did before, but instead of using the old style of database access code, you can now
use Entity Framework.
