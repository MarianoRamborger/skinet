
using API.Entities;
using Microsoft.EntityFrameworkCore; //EntityFramework needs to match the runtime version of dotnet that you are using, or there will be problems. To check, run dotnet --info then look for "Host (useful for support)" and check the version.


namespace API.Data

{
    public class StoreContext : DbContext //it needs DbContext because this class is going to interact with Entity Framework 
    //The DbContext represents a session with the database
    {
                //this is the constructor in which we feed the connection string. Le aclaramos el tipo que vamos a pasar (StoreContext), since vamos a hacer otro context later
            public StoreContext(DbContextOptions<StoreContext> options ) : base(options)  
            {

            }

            public DbSet<Product>  Products { get; set; }

    }
}