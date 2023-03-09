## key terms
* entities = database tables represented by C# models
* database context = entire database (with all tables) represented by a single C# model
    * Naming = ProjNameContext
    * ProjNameContext : DbContext (from ef core)
    * DbContext = class representing mysql session that can query and save instances of entities
        * every time database is referenced, DbContext class is used to do so
* database naming conventions with Entity Framework
    * database column names/case must match property names/case of Models
    * name primary keys with the word Id and the class name thus ProductId
``` mermaid
flowchart TB

  DB((RestaurantByCuisine database))

  subgraph Restaurants
    r1("RestaurantId")
  end

  subgraph Cuisines
      direction TB
      c1("RestaurantId")
      c2("Description")
      c3("CategoryId")
  end


  DB --> Restaurants
  DB --> Cuisines

```
