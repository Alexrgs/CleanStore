# Store

Sample application built using ASP.NET Core and Entity Framework Core. The architecture uses CQRS, MediatR and Fluent validation to achive the Clean Architecture

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio 2019](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 3.0.100-preview6-012264](https://www.microsoft.com/net/download/dotnet-core/3.0)
* [NSwagStudio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  1. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  1. Next, build the solution by running:
     ```
     dotnet build
     ```	 
  1. within the `Store.WebUI\ClientApp` directory, launch the front end by running:
     ```
     npm start
     ```
  1. Once the front-end has started, within the `Store.WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  1. Launch [http://localhost:/5000](http://localhost:5001/) in your browser to view the Web UI
  
  1. Launch [http://localhost:5000/swagger](http://localhost:5001/swagger) in your browser to view the API swegger

## Technologies / Frameworks
* .NET Core 3.0
* ASP.NET Core 3.0
* Entity Framework Core 3.0
* React
* Redux
* Swagger
* IdentityServer4

## Roadmap

- [ ] Add separeted idendity project 
- [ ] Update to .net Core 3.0 LTS 
- [ ] Update Fluent Validation to stable version
- [ ] Add NSwag API client generation on build (PS: Can only be done after official support to .Net core 3.0) 

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/Alexrgs/CQRS_Store/LICENSE.md) file for details.

## Special thanks

* Jayson Taylor for the awesome explanation about clean architecture and CQRS  
* Rico Suter the bright mind behind NSwag

