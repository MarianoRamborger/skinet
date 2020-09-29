namespace API.Entities
{
    public class Product
    {

        public int  Id { get; set; }
        //EF es convention-based. Si ve una int Id en la table, automaticamente la va a usar como primary key y autogenerarla ante la creacion de un nuevo elemento

        public string Name {get; set;}

        // public int Price {get; set;}

     
    }
}

//semi-related. Para generar la migración, dotnet ef migrations -h. Podemos then generar el code para scaffoldear la database
// I used:
// dotnet ef migrations add InitialCreate -o Data/Migrations - Esto NECESITA el package Microsoft.EntityFrameworkCoreDesign que bajamos via nuget.
// Esto va a generar el código para crear la db en base a nuestros model/entities, con el output en data/migrations