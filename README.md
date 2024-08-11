# Products

This project is a .NET application for managing product information. It includes functionalities to handle product data and integrates with Docker for containerization.

## Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/vs/older-downloads/)
- A valid configuration file with required DB connection string.

## Installation

### Cloning

Clone the repository to your local machine:

```bash
git clone https://github.com/yogendra-ykv/Products.git
```

### Navigate to the project directory
```
cd product
```

### Restore the dependencies
```
dotnet Restore
```

### Build the project
```
dotnet Build
```
## Setting up the project

Open a cmd in Product directory
Run below command
```
EntityFrameworkCore\Update-Database
```

Once this is done check in your localDB Database and table got created or not.

Run the web Api application.

SwaggerUI will open and all 7 asked api's will be there.