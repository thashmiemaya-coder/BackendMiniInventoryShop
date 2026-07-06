📚 Mini Inventory Management System – Complete Documentation
📋 System Overview
The Mini Inventory Management System is a full‑stack inventory management solution built with ASP.NET Core Web API, React, and SQL Server. It provides a complete set of features for managing products, stock movements, suppliers, and reporting in a grocery/retail environment.

🔑 Login Credentials (For Testing)
Role	Email	Password	Access
Administrator	admin@grocery.lk	admin123	Full System Access
Note: The current version uses a simple authentication system. Additional roles can be added in future updates.

🚀 How to Run the Backend
1. Prerequisites
Visual Studio 2022 or later

SQL Server (Express or Developer Edition)

.NET SDK 10.0

2. Steps to Run
powershell
# Clone the repository
git clone <repository-url>

# Navigate to the backend folder
cd BackendMiniInventoryShop

# Open the solution in Visual Studio
# Double-click MiniInventory.API.slnx

# Update appsettings.json with your SQL Server connection string
# (Default: Server=DESKTOP-EIBD1L0\\SQLEXPRESS;Database=GroceryInventoryDB;...)

# Run database migrations
# Open Package Manager Console → Select MiniInventory.Infrastructure
Add-Migration InitialCreate
Update-Database

# Press F5 to run the API
# The API will start at: https://localhost:7016 or http://localhost:5010
