# API Versioning Task - Day One

A practical implementation of **API Versioning (URL Path Versioning)** in ASP.NET Core Web API built with **Clean Architecture**, **Entity Framework Core**, and **Swagger UI** multi-version documentation.

---

## 📌 Overview & Concept

The project demonstrates how to evolve an API contract without breaking existing clients:
* **Version 1.0 (`/api/v1.0/products`)**: The legacy response contract (returns `id`, `name`, `price`).
* **Version 2.0 (`/api/v2.0/products`)**: The updated response contract introducing new business fields (returns `id`, `name`, `price`, and `categoryName`).

Both versions share the exact same underlying business logic and database access through a shared Application Service (`IProductService`), adhering to **Clean Architecture** principles.

---

## 🏗️ Architecture Layers

* **Domain**: Core entities (`Product`, `Category`) and repository interfaces.
* **Application**: DTOs, business contracts, interfaces, and service logic (`IProductService`, `ProductService`).
* **Infrastructure**: Data access implementation, EF Core `ApplicationDbContext`, and repositories.
* **API (Presentation)**:
  * Versioned Controllers (`Controllers/V1`, `Controllers/V2`).
  * Versioned API Contracts (`Contracts/V1`, `Contracts/V2`).
  * Swagger UI setup configured for independent version docs (`v1`, `v2`).

---

## 🛠️ Tech Stack & Packages

* **.NET 8 / 9 Web API**
* **Entity Framework Core & SQL Server**
* **Asp.Versioning.Mvc**
* **Asp.Versioning.Mvc.ApiExplorer**
* **Swashbuckle.AspNetCore (Swagger)**

---

## 🚀 Getting Started & Setup

### 1. Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (latest LTS recommended).
* Microsoft SQL Server / LocalDB.
* Visual Studio 2022 or VS Code.

### 2. Configure Database Connection
In `APIVersioningTaskDayOne.Api/appsettings.json`, update the connection string to match your SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=APIVersioningDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Apply Migrations
Open **Package Manager Console** (ensure *Default project* is set to `APIVersioningTaskDayOne.Infrastructure`):

```powershell
Update-Database
```

*(Or via .NET CLI from the solution folder)*:
```bash
dotnet ef database update --project APIVersioningTaskDayOne.Infrastructure --startup-project APIVersioningTaskDayOne.Api
```

### 4. Run the Application
Press **F5** in Visual Studio or run:
```bash
dotnet run --project APIVersioningTaskDayOne.Api
```

The browser will open **Swagger UI** at:
`https://localhost:<port>/swagger`

---

## 🧪 Available Endpoints

### Version 1.0
* `GET /api/v1.0/products`
* `GET /api/v1.0/products/{id}`

**Sample Response (V1):**
```json
{
  "id": 1,
  "name": "Laptop",
  "price": 25000
}
```

### Version 2.0
* `GET /api/v2.0/products`
* `GET /api/v2.0/products/{id}`

**Sample Response (V2):**
```json
{
  "id": 1,
  "name": "Laptop",
  "price": 25000,
  "categoryName": "Electronics"
}
```

---

## 👨‍💻 Author
**Ahmad Youssef Abu Hassan**
```
