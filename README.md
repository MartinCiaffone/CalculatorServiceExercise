# HTTP/REST-based &#39;Calculator Service&#39;

HTTP/REST­based &#39;Calculator Service&#39; capable of some basic arithmetic operations, like add, subtract, square, etc. along with a history.

NOTE: This is an exercise designed to demonstrate some development skills.

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

![](RackMultipart20210330-4-1w5j0cm_html_87c19960e491f1c2.png)

Then it can be started …

![](RackMultipart20210330-4-1w5j0cm_html_8806c13166b20066.png)

Two browser (default) instances will be opened, one for the client and one for the server.

![](RackMultipart20210330-4-1w5j0cm_html_49377bf4be19246.png)

The port definition for the client can be found in:

Properties folder, launchSettings.json file

&quot;applicationUrl&quot;: [http://localhost:30485](http://localhost:30485/)

The port definition for the server can be found in:

Properties folder, launchSettings.json file

&quot;applicationUrl&quot;: &quot;http://localhost:16834/&quot;

On development environment (auto-detected) the server has the Swagger generated interface to test the API.

Note: CalculatorService.Server accepts JSON and XML encodings as input. And returns JSON.

The CalculatorService.ClientB uses JSON.

You can test XML encoding from the Swagger interface with the Request Body encoding format selector:

![](RackMultipart20210330-4-1w5j0cm_html_7e54f37e8b733a77.png)

Another way to test the API is using curl, example:

curl -X POST &quot;http://localhost:16834/calculator/add&quot; -H &quot;accept: \*/\*&quot; -H &quot;Content-Type: application/xml&quot; -d &quot;\&lt;?xml version=\&quot;1.0\&quot; encoding=\&quot;UTF-8\&quot;?\&gt;\&lt;AdditionModel\&gt;\t\&lt;Addends\&gt;1\&lt;/Addends\&gt;\t\&lt;Addends\&gt;2\&lt;/Addends\&gt;\t\&lt;Addends\&gt;3\&lt;/Addends\&gt;\t\&lt;Addends\&gt;4\&lt;/Addends\&gt;\t\&lt;Addends\&gt;5\&lt;/Addends\&gt;\&lt;/AdditionModel\&gt;&quot;

## Using the Client

The client is a web application that performs requests to the server HTTP service.

Home

The five basic arithmetic operations supported by the server are present at the default/home page (A.K.A. &quot;Calculations&quot; in the menu)

NOTE: Use only integer values. Decimal number are not allowed.

For the Addition operation input more than one number and put the &quot;+&quot; sign in between. Sample: 1+3+5

For the Multiplication operation input more than one number and put the &quot;\*&quot; sign in between. Sample: 5\*3\*2

For all operations press the &quot;=&quot; button to get the results.

Some validations are performed at client application, like not a number input, others are done on the server service, like Division by Zero. In either case you will receive an information message on screen.

Is true that for a better performance validation than can be done on the client should be done before sending the request to the server, but this is an exercise to show different scenarios.

The other two menu options (Journal and Settings) works as follows:

Journal /Journal

It has an input box witch is pre-filled with the actual Id sent from the client to the server as part of the request header and used to identify all the requests.

If you had done some operations and then click on &quot;Retrieve Journal&quot; button, a list of operation requests is shown.

The &quot;New Journal Id&quot; button generates a new id to be used on the successive API calls, the ID can be anything, we use a GUID for testing purposes.

Journal entries are associated with the ID, and it cannot be retrieved without that information.

NOTE: the server adds the IP from the client to the entries, just in case of two different clients using the same ID.

The Journal contents are cleared every time the server application is re-started.

Settings /Setings

Can be used to change the URL of the service. Its initial value is prefilled for development and for production environments.

# Solution Structure Detail


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

## CalculatorService.ClientB

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

- Library
