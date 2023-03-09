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

  DB((RestaurantByCuisine db           .     ))

  subgraph Cuisines
    r1("CuisineId")
  end

  subgraph Restaurants
      direction TB
      c1("RestaurantId")
      c2("Description")
      c3("CuisineId")
  end

  DB ..- Restaurants
  DB ..- Cuisines
  r1 --> c3

 %% Class Colors %%
  Cuisines:::tropical
  Restaurants:::tropical
  DB:::purple

  %% Colors %%

  classDef tropical fill:#C6EDC3,stroke:#000,stroke-width:2px,font-size:1.5rem,color:black
  classDef blue fill:#131761,stroke:#000,stroke-width:2px,font-size:1.5rem,color:#fff
  classDef orange fill:#ECA762,stroke:#000,stroke-width:2px,color:black,font-size:1.5rem
  classDef red fill:#FF303B,stroke:#000,stroke-width:2px,color:#fff
  classDef green fill:#027F55,stroke:#000,stroke-width:2px,color:#fff
  classDef pink fill:#E17A9B,stroke:#333,stroke-width:5px,font-size:1rem,font-weight:700,color:black
  classDef forestGreen fill:#027F55,stroke:#333,stroke-width:2px,font-size:3rem,font-weight:700
  classDef yellow fill:#FDF046,stroke:#333,stroke-width:2px,font-size:1.5rem,font-weight:700,color:black
  classDef purple fill:#D183FD,stroke:#333,stroke-width:2px,font-size:1rem,font-weight:600,color:black

```
