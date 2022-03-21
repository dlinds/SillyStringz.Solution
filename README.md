# _SillyStringz Factory_

#### By _Daniel Lindsey_

#### _Admin interface for SillyStringz Factory that allows management of engineers and machines

## Technologies Used

- _C#_
- _.NET Framework_
- _HTML_
- _CSS_
- _Javascript_
- _jQuery_
- _MySQL_
- _Entity_
- _Linq_

## Description

This is a C# web application for a Factory called SillyStringz. Once run, the site will allow the owner, to manage both machines and engineers. The application is written in C# and uses the .NET 5.0 web framework. The application utilizes a many to many database relationship, where engineers can be assigned to multiple machines and machines may have multiple engineers assigned to it.

<br>

# Setup/Installation Requirements

## Cloning the repository

To view this application, you must clone it to your computer. To do so,

1. Locate and click the green Code button at the top of the [https://github.com/dlinds/SillyStringz.Solution](repository page), and choose the option to _Download ZIP_.
2. Once downloaded, navigate to your Downloads folder and extract the contents to a location of your choosing.

## Installing C# and .NET

Once the project is downloaded to your computer, you will need to download and install C# and the .NET SDK.

1. First, download and install the .NET 5 SDK

- [Mac](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.401-macos-x64-installer)
- [Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.401-windows-x64-installer)

2. Once installed, open a new terminal either via Command Prompt (Windows) or Terminal (OSX).
3. Type the following command:
   - **_dotnet tool install -g dotnet-script_**
4. Next, configure your terminal environment with the following command

   - Mac: **_echo 'export PATH=$PATH:~/.dotnet/tools' >> ~/.zshrc_**
   - Windows: **_echo 'export PATH=$PATH:~/.dotnet/tools' >> ~/.bash_profile_**
     <br>
     <br>

## Setting up the database

Prior to running the application, you will need to install MySQL and MySQL Workbench.

- During install, take note of the password you set for MySQL.
  <br>

[Mac and Windows Download Link](https://dev.mysql.com/downloads/workbench/)

## Set up appsettings.json

Next, you will need to tell the application how to create, write to, and access a database.

1. In the Factory directory, create a file called appsettings.json
2. Paste the following into the file, editing both the database name and the password in the string (using the password you set when installing MySql).

   {
   "ConnectionStrings": {
   "DefaultConnection": "Server=localhost;Port=3306;database=(my-database-name-here);uid=root;pwd=(my-password-here);"
   }
   }


<br>

# Run the project
  Now that everything is installed and set up, you may run the project.

1. Open up a new terminal and navigate to the Factory Folder
2. Type in the following command: **_dotnet ef database update_**
  * this will create a database with the structure needed for the application to run
3. Type in the following command: **_dotnet run_**
4. Open a web browser and navigate to http://localhost:5000

<br>

# Known Bugs

- _Mobile scaling does not work correctly. The navbar is quite difficult to utilize_

<br>

# License

_MIT_

Copyright (c) _3-20-2022_ _Daniel Lindsey_
