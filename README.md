# HTTP/REST-based &#39;Calculator Service&#39;

HTTP/REST­based &#39;Calculator Service&#39; capable of some basic arithmetic operations, like add, subtract, square, etc. along with a history.

NOTE: *This is an exercise designed to demonstrate some development skills.*

The document **2012.01.15-Code.Challenge-Calculator.Service.pdf** has the exercise description.

This document covers those topics:

- Introduction
  - Goals &amp; Objectives
  - General requirements
  - Architecture &amp; Components
- High-Level Use Cases
- REST/API description

# Solution Structure

IDE: Microsoft Visual Studio 2019

Framework: .NET 5

Language: C#

The solution consists of these projects:

- Server (Web API)
- ClientB (Blazor App)
- Library
- LibraryTests

# How to build the application

Package and project dependencies are detailed on the **Solution Structure Detail** section.

# How to run/test

For testing/local/development you can set the Startup Project to multiple.

1. In  **Solution Explorer** , select the solution (the top node).
2. Choose the solution node&#39;s context (right-click) menu and then choose  **Properties**. The  **Solution Property Pages**  dialog box appears.
3. Expand the  **Common Properties**  node, and choose  **Startup Project**.
4. Choose the  **Multiple Startup Projects**  option and set the actions like this:

![MultipleStartupProjects](https://user-images.githubusercontent.com/78768310/113060620-450ca080-9187-11eb-8305-b3062fb64d26.png)

Then it can be started …

![Start](https://user-images.githubusercontent.com/78768310/113061219-1a6f1780-9188-11eb-8d37-c582d0b4ebeb.png)

Two browser (default) instances will be opened, one for the client and one for the server.

![ServerAndClient](https://user-images.githubusercontent.com/78768310/113061216-19d68100-9188-11eb-95ec-bf16e08186d5.png)

The port definition for the client can be found in:

Properties folder, launchSettings.json file `"applicationUrl": "http://localhost:30485/"`

The port definition for the server can be found in:

Properties folder, launchSettings.json file `"applicationUrl": "http://localhost:16834/"`

On development environment (auto-detected) the server has the Swagger generated interface to test the API.

Note: *CalculatorService.Server accepts JSON and XML encodings as input. And returns JSON.*

The CalculatorService.ClientB uses JSON.

You can test XML encoding from the Swagger interface with the Request Body encoding format selector:

![TestXML](https://user-images.githubusercontent.com/78768310/113061212-193dea80-9188-11eb-808b-158235589343.png)

Another way to test the API is using curl, example:


```
curl -X POST "http://localhost:16834/calculator/add" -H  "accept: */*" -H  "Content-Type: application/xml" -d "<?xml version=\"1.0\" encoding=\"UTF-8\"?><AdditionModel>\t<Addends>1</Addends>\t<Addends>2</Addends>\t<Addends>3</Addends>\t<Addends>4</Addends>\t<Addends>5</Addends></AdditionModel>"
```

## Using the Client

The client is a web application that performs requests to the server HTTP service.

### Home

The five basic arithmetic operations supported by the server are present at the default/home page (A.K.A. &quot;Calculations&quot; in the menu)

NOTE: *Use only integer values. Decimal number are not allowed.*

For the Addition operation input more than one number and put the &quot;+&quot; sign in between. Sample: 1+3+5

For the Multiplication operation input more than one number and put the &quot;\*&quot; sign in between. Sample: 5\*3\*2

For all operations press the &quot;=&quot; button to get the results.

Some validations are performed at client application, like not a number input, others are done on the server service, like Division by Zero. In either case you will receive an information message on screen.

Is true that for a better performance validation than can be done on the client should be done before sending the request to the server, but this is an exercise to show different scenarios.

The other two menu options (Journal and Settings) works as follows:

### Journal /Journal

It has an input box witch is pre-filled with the actual Id sent from the client to the server as part of the request header and used to identify all the requests.

If you had done some operations and then click on &quot;Retrieve Journal&quot; button, a list of operation requests is shown.

The &quot;New Journal Id&quot; button generates a new id to be used on the successive API calls, the ID can be anything, we use a GUID for testing purposes.

Journal entries are associated with the ID, and it cannot be retrieved without that information.

NOTE: *the server adds the IP from the client to the entries, just in case of two different clients using the same ID.*

The Journal contents are cleared every time the server application is re-started.

### Settings /Setings

Can be used to change the URL of the service. Its initial value is prefilled for development and for production environments.

# Solution Structure Detail

Note on deployment: *When publishing to an Azure target, the .pubxml file contains your Azure subscription identifier. With that target type, adding this file to source control is discouraged.* Both Server and Client have publishing profiles generated on the solution.

Client goes to:
[Calculator Service Client](http://calculatorservicetestclient.azurewebsites.net/)

Server goes to:
[Calculator Service Server](https://calculatorserviceserver.azurewebsites.net/)

(Those links will be available for a limited time)


## CalculatorService.Server

Project type: Web API .NET 5.0

Packages

- AspNetCore.Mvc.Versioning Version=5.0.0
- AspNetCore Version=4.0.0
- Enrichers.Environment Version=2.1.3
- Enrichers.Process Version=2.0.1
- Enrichers.Thread Version=3.1.0
- Settings.Configuration Version=3.1.0
- AspNetCore Version=6.1.1

Projects dependencies

- Library

Reference Links:

[domaindrivendev/Swashbuckle.AspNetCore: Swagger tools for documenting API&#39;s built on ASP.NET Core (github.com)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

[Home · microsoft/aspnet-api-versioning Wiki (github.com)](https://github.com/Microsoft/aspnet-api-versioning/wiki)

[serilog/serilog-aspnetcore: Serilog integration for ASP.NET Core (github.com)](https://github.com/serilog/serilog-aspnetcore)

[serilog/serilog-settings-configuration: A Serilog configuration provider that reads from Microsoft.Extensions.Configuration (github.com)](https://github.com/serilog/serilog-settings-configuration)

## Implementation details

### Models:

We declared a class model for the different services, like AdditionModel class for /Add.

Also we have another class model for the request response, like AdditionResultModel class

And there is an ErrorResponseModel in line with the exercise specifications.

Models for Addition and Multiply, that get an array of values on the request have some extra annotations to support XML encoding, not needed on the other models.


##

### Controllers:

We have API controllers for each route, and those controllers inherits from a &quot;CommonController&quot; class that inherits from the AspNetCore.Mvc ControllerBase.

This way we avoid to repeat much of the code logic on every controller.

On this common controller we have the journal entry processing by the injected Journal class from the CalculatorService.Library and all the exceptions processing.

We send exceptions information to the client using the ErrorResponseModel.

The actual arithmetic operation is done by the calling CalculatorService.Library methods and this is invoked on each individual controller.

##

### Logging:

Is implemented using Serilog library ([https://serilog.net/](https://serilog.net/))

Serilog functionality is defined on the appsettings.json file under the &quot;Serilog&quot;: name.

Logs are sent to the console and to a file located on a server subdirectory &quot;Logs&quot;

With daily rolling interval, the log files are named like: CalculatorService.Server.Log\&lt;yyyyMMdd\&gt;.json

Note on usage: The logger is injected on the controllers following the common practice, but for logging events at application startup, an instance is created on the Main method of the Program class.

##

### API Versioning:

Is provided by the Microsoft.AspNetCore.Mvc.Versioning package.

Is added to the service collection on the Startup class with default values.

Implement different versions can be done by annotating the controllers and actions with appropriate attributes like `[ApiVersion("1.0", Deprecated = true)]` or `[MapToApiVersion("3.0")]` etc.


##

### CalculatorService.ClientB

Blazor App – .NET 5.0

Packages

- Nuget System.Net.Http.Json


## CalculatorService.Library

Class Library - .NET 5.0

Packages

- None

It has an associated project ClientService.LibraryTests

## ClientService.LibraryTests

Console Application

Packages

- NET.Test.Sdk 16.7.1
- TestAdapter 2.1.1
- TestFramework 2.1.1
- collector 1.3.0

Project References

- ClientService.Library
