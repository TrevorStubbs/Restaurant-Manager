# Challenge Log
- Log of My Progress through this Code Challenge

## Code Review
- 13:21 I have finished the code base review and have been able to get the app running on my machine.

## DishService TODO
- 14:41 - I completed the UpdateDish method in the DishService.cs file. 
    - I will not be able to test this until I get the unit testing environment built.
    - I had to update the DbContext with RecipeIngredients DbSet
    - Also had to include a composite primary key into the modelbuilder.

## Unit Testing Environment Setup
- 15:34 - The xUnitTesting environment is set up with an in-memory Sqlite server.
    - Entity Framework has an option to build an In-memory database but LINQ queries don't follow the same logic as making real calls to a database. (EF in memory databases makes calls to objects not entities)
    - I chose to go with a Sqlite server to get around this issue.
    - In the future when I build the integration tests I I will probably use EF's in memory system since we care more for proper contracts and connections than for accurate database calls.