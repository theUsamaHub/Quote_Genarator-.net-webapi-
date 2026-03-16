# Quote Generator API (.NET 8)

A RESTful **Quote Generator API** built using **ASP.NET Core Web API (.NET 8)** and **Entity Framework Core**.  
The API allows storing, retrieving, and generating quotes, while also integrating with an external quotes API to populate the database automatically.

This project demonstrates backend development concepts such as **API design, database interaction, external API integration, and CI/CD automation**.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Features](#features)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [CI/CD Pipeline](#cicd-pipeline)
- [Running the Project Locally](#running-the-project-locally)

---

## Project Overview

The Quote Generator API is designed to manage quotes efficiently. It supports creating quotes, retrieving them from the database, and filling the database with quotes fetched from an external API.

**The purpose of this project is to practice and demonstrate:**

- REST API development
- Entity Framework Core database operations
- External API integration
- Backend project structure
- CI/CD with GitHub Actions

---

## Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core Web API (.NET 8) | Backend framework |
| Entity Framework Core | ORM / Database interaction |
| SQL Server | Database |
| HttpClient | External API integration |
| GitHub Actions | CI/CD automation |

---

## Project Structure

```
Quote_Generator/
│
├── Controllers/
│   └── QuotesController.cs
│
├── Models/
│   └── Quote.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Program.cs
├── appsettings.json
└── Quote_Generator.csproj
```

The structure separates responsibilities into **controllers**, **models**, and **data access layers**.

---

## Features

- ✅ Create quotes manually
- ✅ Retrieve all quotes from the database
- ✅ Get a random quote
- ✅ Fetch a quote by ID
- ✅ Delete a quote
- ✅ Auto-populate the database via an external quotes API

---

## API Endpoints

### Create Quote
Allows adding a new quote manually.

**`POST /api/quotes`**

**Request Body:**
```json
{
  "text": "Stay hungry, stay foolish",
  "author": "Steve Jobs"
}
```

---

### Get All Quotes
Returns all quotes stored in the database.

**`GET /api/quotes`**

---

### Get Random Quote
Returns a random quote from the database.

**`GET /api/quotes/random`**

---

### Get Quote By ID
Fetches a specific quote using its ID.

**`GET /api/quotes/{id}`**

---

### Delete Quote
Deletes a quote from the database.

**`DELETE /api/quotes/{id}`**

---

### Fill Database with Quotes (External API)

Integrates with [ZenQuotes](https://zenquotes.io/api/quotes) to automatically populate the database with quotes.

**`POST /api/quotes/fill-random`**

**This endpoint:**
1. Calls the ZenQuotes external API
2. Retrieves a list of quotes
3. Maps them to the internal `Quote` model
4. Saves them to the database

---

## Database Schema

### Quotes Table

| Field | Type | Description |
|---|---|---|
| `Id` | `int` | Primary key |
| `Text` | `string` | Quote content |
| `Author` | `string` | Quote author |
| `CreatedAt` | `datetime` | Timestamp when the quote was added |

---

## CI/CD Pipeline

The repository includes a **GitHub Actions CI workflow** that runs automatically on every push and pull request to all branches.

**Workflow steps:**

1. Checkout repository
2. Install .NET 8 SDK
3. Restore dependencies
4. Build the project
5. Run tests
6. Publish the build

**Workflow file:** `.github/workflows/main.yml`

---

## Running the Project Locally

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server instance
- Connection string configured in `appsettings.json`

### Steps

**1. Clone the repository**
```bash
git clone https://github.com/yourusername/quote-generator-api.git
```

**2. Navigate to the project folder**
```bash
cd quote-generator-api
```

**3. Restore dependencies**
```bash
dotnet restore
```

**4. Apply database migrations**
```bash
dotnet ef database update
```

**5. Run the project**
```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.
