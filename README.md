# Stores

Contains pages to display data about a fictional stores entity and an API to create/update/delete the store data. Data is stored in a CSV file but could easily be switched to a SQL data store with minimal changes to the existing code due to the abstraction used by the Repository pattern. Unit test for the Controller methods are also provided. 

Built with ```.NET Core 1.1``` Version ```1.0.0-preview2-1-003177```. 

To run the project locally:

```git clone https://github.com/gcheney/stores.git```

```cd src/Stores/```

```dotnet restore```

```dotnet run```

To run the unit test project:

```cd test/Stores.Test/```

```dotnet restore```

```dotnet test```
