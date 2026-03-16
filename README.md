```markdown
# Quote Generator API (.NET 8)

A RESTful **Quote Generator API** built using **ASP.NET Core Web API (.NET 8)** and **Entity Framework Core**.  
The API allows storing, retrieving, and generating quotes, while also integrating with an external quotes API to populate the database automatically.

This project demonstrates backend development concepts such as **API design, database interaction, external API integration, and CI/CD automation**.

---

## Project Overview

The Quote Generator API is designed to manage quotes efficiently.  
It supports creating quotes, retrieving them from the database, and filling the database with quotes fetched from an external API.

The purpose of the project is to practice and demonstrate:

- REST API development
- Entity Framework Core database operations
- External API integration
- Backend project structure
- CI/CD with GitHub Actions

---

## Tech Stack

- **ASP.NET Core Web API (.NET 8)**
- **Entity Framework Core**
- **SQL Server**
- **HttpClient (API Integration)**
- **GitHub Actions (CI/CD)**

---

## Project Structure


Quote_Generator
│
├── Controllers
│   └── QuotesController.cs
│
├── Models
│   └── Quote.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Migrations
│
├── Program.cs
├── appsettings.json
└── Quote_Generator.csproj


The structure separates responsibilities into controllers, models, and data access layers.

---

## Features Implemented

### Create Quote

Allows adding a new quote manually.

**Endpoint:**

POST /api/quotes


**Example request:**
```json
{
  "text": "Stay hungry, stay foolish",
  "author": "Steve Jobs"
}




### Get All Quotes

Returns all quotes stored in the database.

**Endpoint:**

GET /api/quotes


---

### Get Random Quote

Returns a random quote from the database.

**Endpoint:**

GET /api/quotes/random


---

### Get Quote By ID

Fetches a specific quote using its ID.

**Endpoint:**

GET /api/quotes/{id}


---

### Delete Quote

Deletes a quote from the database.

**Endpoint:**

DELETE /api/quotes/{id}


---

### Fill Database with Quotes (External API)

The system integrates with an external API to automatically populate the database with quotes.

**External API used:**

https://zenquotes.io/api/quotes


**Endpoint:**

POST /api/quotes/fill-random


This endpoint:
1. Calls the external quotes API
2. Retrieves quotes
3. Converts them into the internal `Quote` model
4. Saves them in the database

---

## Database Schema

### Quotes Table

| Field | Type | Description |
|-------|------|-------------|
| Id | int | Primary key |
| Text | string | Quote content |
| Author | string | Quote author |
| CreatedAt | datetime | Time when quote was added |

---

## CI/CD Pipeline

The repository includes **GitHub Actions CI workflow**.

**Workflow steps:**
1. Checkout repository
2. Install .NET 8 SDK
3. Restore dependencies
4. Build the project
5. Run tests
6. Publish the build

**Workflow file:**

.github/workflows/main.yml


The pipeline runs automatically on **push and pull requests to all branches**.

---

## Running the Project Locally

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/quote-generator-api.git


2. **Navigate to the project folder**
   ```bash
   cd quote-generator-api


3. **Restore dependencies**
   ```bash
   dotnet restore


4. **Run the project**
   ```bash
   dotnet run
   ```

The API will start locally and can be tested using **Swagger or Postman**.

---

## Future Improvements

Possible enhancements for the project:

- Pagination for quotes
- Quote categories
- User authentication
- Favorite quotes system
- Rate limiting
- Caching for faster responses
- Docker containerization

---

## Author

**Usama**  
Backend Developer
```
