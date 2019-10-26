# Zymo Products REST API
---

### Description
This is the API that will interface with the Products Database.

Due to the complexity inherent in Zymo's requirements, we decided to architect this application with a Domain Driven Design. This means that objects should not only be data holders for the application, but should also help maintain it's own state and business logic. As such, validation, business rules, etc. should be contained within domain models and Services will orchestrate these dynamic models to reach an end goal. 

##### Fun Fact! Models that act as simple types and/or data holders are called "anemic" models, whereas the Domain models we will be discussing are "rich" models.

This architecture described for this API was modeled, in large part, from this [Microsoft article](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/ddd-oriented-microservice).

This Web API has 3 main layers, as well as a directory for Unit and Integration tests. The three layers include:
1. **Infrastructure Layer** - This layer is involved with data persistence. When domain entities are created in the application, they are derived from a persistent data source before being mapped into a domain object. KEEP DOMAIN MODEL ENTITY CLASSES AGNOSTIC TO INFRASTRUCTURE. 

2. **Domain Layer** - From Microsoft, the Domain Model Layer is "responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. This layer is the heart of business software." This layer will ignore data persistence, which is performed by the Infrastructure layer, and will instead focus on using the information provided by the Infrastructure enforce business logic at the domain level.

3. **API layer** -  This layer defines the jobs that the software is supposed to do. The API layer directs the expressive domain objects created by the previous layer in order to work out specific problems. Domain models will enforce the business logic, while the API layer provides the context by which the Domain object will need to validate against. Here, you will find the view models, queries, controllers, and interfaces/software contracts. Concrete interface implementations are done in one of the other layers.


### Requirements and Setup
The application is an ASP.NET Core powered Web API connected to a MongoDB document database. Currently in the code, the MongoDB connection is based on hosting environment (Dev vs Prod), such that in Development the application utilizes a local MongoDB while in Prod it uses Mongo Atlas.

As such, to use it in development right now, you will need MongoDB installed locally.

Once MongoDB is installed and is populated with test data, the only thing that needs to be done is run a ```dotnet restore``` in the command line (makes sure all packages are up to date) and then ```dotnet run``` to start the application. You can also use it in debug mode.

**Note:** Since this is not a UI driven application, the proper endpoints are "/api/{example-endpoint}", though keep in mind that swagger will open in development.

---

### Open Endpoints
Currently, there are 3 major endpoints:
1. Kits - This interfaces with services that handles kit specific actions from the database. Full CRUD is accessible here for kits. Note: kits will actually use component services when needed to reference specific kit components.
2. Components - Similar to the kits endpoint, except for components. 
3. Search - Utilizes services created for reading product data. This will replace the Search API. 

---

### Endpoints that require Authentication
To be determined once Azure Active Directory is activated and ready to go.

---

### Testing
Tests are stored in two files: one for each Services and Repository.

```csharp
public async Task LayerBeingTested_MethodBeingTested_ExpectedResult()
{
    // Arrange
    var id = '700';

    // Act
    var result = _serviceBeingTested.GetById(id);

    // Assert
    Assert.That(result, It.IsNotNull);
}
```
---
### Deployment

Currently, there is one branch (master) that is connected to Azure CI/CD Pipelines. In essence, this means that merges into master will trigger a Pipeline to build and publish the code. This will become more effective once we include tests in the Pipeline.

---
### Authors and Maintainers 
* Bryan Boubion
* Michael Foss
---
