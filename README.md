# Project Title

Simple CRUD with  .NET Core 3.1 + SQL Server EF Core

## Description

This project sets a boilerplate for Employees management.

## Getting Started

### Dependencies

* ex. Windows 10
* Visual Studio 2019, SQL server Management studio 2018

### Installing

## DB Instalation
* On the Solution Explorer, please open the EmployeeContext.cs and setup your own DB Server connstring
* EF Core will create and add a couple of Employee records to start playing with it.

## .NET Core API
* In the Employees Service folder open EmployeeService.sln file
* In VS execution's options click run and will execute both projects FillDB and the API itself.
* To properly set your DB connection, the proper way is to set that on your appsettings.Development.json to point the right SQL server, however is not yet ready for this Demo version.


## Authors

ex. Alex Villegas  

## Version History

* 0.1
    * Initial Release

## License

This project is licensed under the Copyleft License - see the LICENSE.md file for details

## Acknowledgments

Inspiration, code snippets, etc.
* [awesome-readme](https://github.com/matiassingers/awesome-readme)