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

## Integration Testing Environment Setup
- 16:15 - Microsoft provides a slick way of setting up integration tests. The integration tests uses xUnit's testing framework but we convert the '.NET.Sdk' into a '.Net.Sdk.Web' which makes the testing environment act like a Web host and server. 
    - It is all in memory and does not take any sockets to run.    

## Running tests
- 17:31 - I Used MOQ to help build a mock of IRecipe. Was able to get MOQ to return the expected data back to the service.

- 18:07 - Was able to get the CustomWebApplicationFactory built. But I ran out of time to debug it and use it for real testing. 

# After Time Limit Work
## DishesController Integration Test
- Was able to get the DishesController Integration tests to work. I will now complete the unit tests for the DishService before I start building more integration tests.
- Was able to successfully test the UpdateDish method in the DishService.cs service. Now I need to build the integration test for it. 
    - There probably a few ways to do this. But I am thinking I need to pass in a json string into the body Http Message and have that be the parameter needed to make the PUT method work in the DishesController.


## References
- In this project I used reference code from:
    - "Integration tests in ASP.NET Core" - https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0
    - Nick Chapass - https://www.youtube.com/channel/UCrkPsvLGln62OMZRO6K-llg
        - Getting started with Mocking using Moq in .NET (Core, Framework, Standard) 
            - https://www.youtube.com/watch?v=9ZvDBSQa_so
        - Integration testing | ASP.NET Core 5 REST API Tutorial 15
            - https://www.youtube.com/watch?v=7roqteWLw4s

