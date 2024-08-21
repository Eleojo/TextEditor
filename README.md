
# TextEditor

TextEditor is an ASP.NET Core MVC application designed for creating, editing, and managing text documents with user authentication. This project demonstrates the use of ASP.NET Identity, Entity Framework Core, and integration with a rich text editor.

## Features

- User authentication and authorization using ASP.NET Identity.
- Create, edit, and delete text documents.
- Rich text editor for document content.
- User-specific document management.

## Prerequisites

Before you begin, ensure you have the following installed:

- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/)
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
  
## Setting Up the Project

### Step 1: Clone the Repository

Clone the repository from GitHub:

```bash
git clone https://github.com/yourusername/TextEditor.git
```

### Step 2: Open the Project in Visual Studio

1. Open Visual Studio.
2. Click on **Open a project or solution**.
3. Navigate to the cloned `TextEditor` folder and select the `TextEditor.sln` file.

### Step 3: Update the Connection String

1. Open the `appsettings.json` file in the root directory.
2. Update the connection string to point to your SQL Server instance:
   
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server_name;Database=TextEditor;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

   Replace `your_server_name` with your actual SQL Server instance name.

### Step 4: Apply Migrations and Update the Database

1. Open the **Package Manager Console** in Visual Studio (found under `Tools > NuGet Package Manager > Package Manager Console`).
2. Run the following command to apply migrations and create the database:

   ```powershell
   Update-Database
   ```

### Step 5: Build and Run the Application

1. **Build the project** by selecting `Build > Build Solution` from the top menu or pressing `Ctrl+Shift+B`.
2. **Run the application** by pressing `F5` or clicking the **Start Debugging** button.

   The application should launch in your default browser at `https://localhost:5001` or `http://localhost:5000`.

## Usage

Once the application is running:

- **Register a new user** or **log in** if you already have an account.
- **Create new documents** by clicking on the "Create" button.
- **Edit or delete documents** from your document list.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## Contact

For any inquiries, please contact [your email address].
```

Replace `"yourusername"` with your GitHub username and `"your email address"` with your actual email address before using the README.
