# Sunglasses Store Web App

This project is a web application for managing and selling sunglasses, built with **ASP.NET Core MVC (.NET 8)** and **Entity Framework Core 9**, using **MS SQL Server** as the database.  
The goal of the system is to support a product catalog, simulated purchases, and personalized recommendations. Business logic is separated from data access using the Repository pattern.

## Features

### Roles
- **Administrator**
  - Manage product catalog (add/update sunglasses: brand, model, color, UV protection, category).
  - Set discounts and promotions (e.g. *Summer Sale: -30%*).
  - Review orders and sales statistics.
  - Reply to customer inquiries.
- **Customer**
  - Register an account.
  - Search and filter products by brand, frame shape, lens color, or purpose (driving, sport, fashion).
  - Simulate purchases with checkout and invoice preview.
  - Rate products and recommend them to friends.
- **Guest**
  - Browse catalog and promotions without registration.

### Core Functionality
- **Product Catalog Management**
  - Full CRUD support for sunglasses.
  - Categorization by type (*sport*, *classic*, ...).
  - Automatic tagging for discounted items.
- **Advanced Search & Filters**
  - Sort by newest, best-selling, or price (asc/desc).
- **Shopping Simulation**
  - 3-step purchase process: select items → confirm delivery details → review invoice.
  - Order history on user profile.
- **Ratings & Recommendations**
  - Product rating system (1–5 stars, optional comments).
  - "Recommend to a friend" feature inside the app.
- **Admin Dashboard**
  - Sales statistics (e.g. top 5 best-selling models).
  - Average rating by brand.
  - Manage active promotions.

---

## Tech Stack
- **Backend:** ASP.NET Core MVC (.NET 8)
- **Frontend:**" Javascript, scss, bootstrap
- **ORM:** Entity Framework Core 9  
- **Database:** MS SQL Server  
- **Architecture:** Repository Pattern + layered separation of concerns  

---

## Setup
1. Clone the repository.  
2. Update the `appsettings.json` connection string to point to your SQL Server instance.  
3. Run database migrations (`dotnet ef database update`).  
4. Start the application with `dotnet run`.  

---
## App language
- Serbian

## App showcase

<img width="1912" height="912" alt="image" src="https://github.com/user-attachments/assets/4fa95034-1288-47b3-926d-c3ef712b2da4" />
<img width="1911" height="916" alt="image" src="https://github.com/user-attachments/assets/346f2fbf-bd48-43f9-8c9e-d9889e394de3" />
<img width="1910" height="906" alt="image" src="https://github.com/user-attachments/assets/39cb56b4-cb2a-4d3e-ae57-8a44d13eb867" />
<img width="1916" height="901" alt="image" src="https://github.com/user-attachments/assets/87811770-1f09-4da9-88d2-c1cc43c58c5b" />
<img width="1918" height="916" alt="image" src="https://github.com/user-attachments/assets/71de9de2-1e1f-498a-96ea-25ce601dafb1" />
<img width="1912" height="905" alt="image" src="https://github.com/user-attachments/assets/c2d68e93-4c0e-44c0-ae78-a4a7e6d66a4c" />
<img width="1915" height="907" alt="image" src="https://github.com/user-attachments/assets/ff9b03d4-87f4-48ca-bc7b-9a99a82fdbeb" />


