# ASP .NET Car Dealership

## Overview  
This **ASP.NET Core MVC** project is designed for managing **vehicles, customers, sellers, test drives, and related data**. It uses **Entity Framework Core (EF Core) for database operations**, **C# models for structured data**, and supports **CRUD functionalities with user authentication and role-based access control**.

## Features  

### **Backend (C# & EF Core)**  
- **Entity Models**  
  - Vehicles: `Car`, `VehicleModel`, `VehicleType`
  - Customers & Sellers: `Customer`, `Seller`
  - Test Drives: `TestDrive`
  - Car Specifications: `Equipment`, `Fuel`, `Transmission`
- **Data Management**  
  - Uses **Entity Framework Core** for data persistence
  - **Relationships** between vehicles, test drives, and customers

### **User Authentication & Access Control**  
- **Login System** with credential-based authentication
- **Access Levels** for different user roles (Admin, Customer, Guest)
- **Role-Based Restrictions** for managing access to specific functionalities

- ### **Database Functionality**  
- **CRUD Operations** for managing cars, customers, and test drives
- **Database-first or Code-first approach** supported
- **Secure data storage** ensuring referential integrity

### **User Interface (MVC & Razor Pages)**  
- **Dynamic UI** with model binding
- **Navigation and shared layouts** for consistent user experience
- **Validation and error handling** for secure form submissions
