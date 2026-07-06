# 🍏 Grocery Inventory Management System
## Technical Explanation

**Version:** 1.0  
**Prepared By:** [Your Name]  
**Company:** Ceylon Innovation Services (PVT) LTD  
**Branch:** Negombo Branch  
**Program:** Intern Development Program 2026  
**Date:** July 2026  

---

## 📋 Table of Contents

1. [Project Overview](#project-overview)
2. [Technology Stack](#technology-stack)
3. [System Architecture](#system-architecture)
4. [Features & Modules](#features--modules)
5. [Challenges & Solutions](#challenges--solutions)
6. [Key Learnings](#key-learnings)
7. [Future Enhancements](#future-enhancements)
8. [Conclusion](#conclusion)

---

## Project Overview

### What is this project?

The **Grocery Inventory Management System** is a full-stack web application designed to help grocery shop owners manage their inventory efficiently. It provides a complete solution for tracking products, managing suppliers, recording stock movements, and generating real-time reports.

### Project Purpose

This project was developed as part of the Intern Development Program at Ceylon Innovation Services (PVT) LTD. The main objectives were:

1. **Demonstrate Clean Architecture** - Show how to structure enterprise applications
2. **Implement Repository Pattern** - Show data access abstraction
3. **Build a Real-World Application** - Solve actual business problems
4. **Learn Professional Development** - Follow industry best practices

### Key Features

| Feature | Description |
|---------|-------------|
| ✅ **Dashboard** | Summary cards, stock chart, low stock alerts |
| ✅ **Category Management** | Add, edit, delete, and search categories |
| ✅ **Supplier Management** | Manage supplier information and contacts |
| ✅ **Item Management** | Add, edit, delete, and search inventory items |
| ✅ **Stock In** | Record incoming stock from suppliers |
| ✅ **Stock Out** | Record outgoing stock (Sales, Damage, Internal Use) |
| ✅ **Stock Balance Report** | View real-time stock status with PDF export |
| ✅ **Low Stock Report** | Identify items needing reorder |
| ✅ **PDF Export** | Generate professional PDF reports |
| ✅ **Print Functionality** | Print-friendly report views |

---

## Technology Stack

### Backend Technologies

| Technology | Version | Purpose |
|------------|---------|---------|
| ASP.NET Core Web API | .NET 10 | RESTful API development |
| Entity Framework Core | 10.0.9 | ORM for database operations |
| SQL Server | 2022 | Relational database |
| Swashbuckle | 6.5.0 | API documentation (Swagger) |
| C# | 10 | Programming language |

### Frontend Technologies

| Technology | Version | Purpose |
|------------|---------|---------|
| React | 18.3.1 | UI framework |
| Vite | 8.1.0 | Build tool and dev server |
| Tailwind CSS | 4.0 | Styling and UI design |
| React Router | 6.22.0 | Client-side routing |
| Axios | 1.6.0 | HTTP client for API calls |
| Lucide React | 0.344.0 | Icon library |
| jsPDF | Latest | PDF generation |
| jspdf-autotable | Latest | PDF table generation |

### Development Tools

| Tool | Purpose |
|------|---------|
| Visual Studio 2022 | Backend development |
| VS Code | Frontend development |
| SQL Server Management Studio | Database management |
| Postman | API testing |
| Git | Version control |
| GitHub | Source code hosting |

---

## System Architecture

### Backend Architecture (Clean Architecture)

The backend follows **Clean Architecture** principles with clear separation of concerns into 5 layers:
