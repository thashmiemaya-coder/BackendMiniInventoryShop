# 🍏 Grocery Inventory Management System
## API Documentation
### Version 1.0

**Prepared By:** [Your Name]  
**Company:** Ceylon Innovation Services (PVT) LTD  
**Branch:** Negombo Branch  
**Date:** July 2026  

---

## 📋 Table of Contents

1. [Introduction](#introduction)
2. [Base URL](#base-url)
3. [Common Response Format](#common-response-format)
4. [Category APIs](#category-apis)
5. [Supplier APIs](#supplier-apis)
6. [Item APIs](#item-apis)
7. [Stock APIs](#stock-apis)
8. [Status Codes](#status-codes)
9. [Error Handling](#error-handling)
10. [Complete Endpoints Summary](#complete-endpoints-summary)

---

## Introduction

The **Grocery Inventory Management System API** provides a complete set of RESTful endpoints for managing grocery shop inventory. This API is built using **ASP.NET Core Web API** with **Clean Architecture** and follows industry best practices.

### Key Features

| Feature | Description |
|---------|-------------|
| ✅ **Category Management** | Create, read, update, and delete product categories |
| ✅ **Supplier Management** | Manage supplier information and contacts |
| ✅ **Item Management** | Add, edit, delete, and search inventory items |
| ✅ **Stock In/Out Tracking** | Record incoming and outgoing stock movements |
| ✅ **Real-time Stock Balance** | View current stock levels instantly |
| ✅ **Low Stock Alerts** | Get notified when items need reordering |
| ✅ **PDF Reports** | Export stock reports as PDF |
| ✅ **Professional Documentation** | Complete API reference with examples |

---

## Base URL
https://localhost:7016/api


# Category APIs

## 1. Get All Categories

**Method:** `GET`  
**Endpoint:** `/api/category`  
**Description:** Retrieves a list of all categories.

### Sample Response

```json
{
  "success": true,
  "message": "Operation successful",
  "data": [
    {
      "categoryId": 1,
      "categoryName": "Rice",
      "description": "All types of rice products",
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    },
    {
      "categoryId": 2,
      "categoryName": "Flour",
      "description": "Baking and cooking flours",
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    },
    {
      "categoryId": 3,
      "categoryName": "Oil",
      "description": "Cooking oils",
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    },
    {
      "categoryId": 4,
      "categoryName": "Sugar",
      "description": "Sugar and sweeteners",
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    }
  ],
  "errors": null
}
