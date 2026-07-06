# 🍏 Grocery Inventory Management System
## API Documentation

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


## Supplier APIs

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Supplier` | Get all suppliers |
| POST | `/api/Supplier` | Create a new supplier |

### Sample Request Body (POST)

```json
{
  "supplierName": "Ceylon Foods (Pvt) Ltd",
  "contactNumber": "077-1234567",
  "email": "info@ceylonfoods.lk",
  "address": "No. 123, Galle Road, Colombo 03"
}
```
## Supplier APIs

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Supplier` | Get all suppliers |
| POST | `/api/Supplier` | Create a new supplier |

### Sample Request Body (POST)

```json
{
  "supplierName": "Ceylon Foods (Pvt) Ltd",
  "contactNumber": "077-1234567",
  "email": "info@ceylonfoods.lk",
  "address": "No. 123, Galle Road, Colombo 03"
}
```
## Item APIs

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Item` | Get all items |
| POST | `/api/Item` | Create a new item |

### Sample Request Body (POST)

```json
{
  "itemCode": "RICE001",
  "barcode": "8901234567890",
  "itemName": "Basmati Rice 1kg",
  "categoryId": 1,
  "supplierId": 1,
  "costPrice": 150.00,
  "sellingPrice": 210.00,
  "reorderLevel": 20
}

```
## Stock APIs

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Stock/in` | Record stock in (add stock) |
| POST | `/api/Stock/out` | Record stock out (remove stock) |
| GET | `/api/Stock/balance` | Get stock balance report |
| GET | `/api/Stock/low-stock` | Get low stock items |

---

### Sample Request Body (POST Stock In)

```json
{
  "itemId": 1,
  "supplierId": 1,
  "quantity": 50,
  "costPrice": 150.00
}

```
## User APIs

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/User/login` | User login |
| POST | `/api/User/register` | Register a new user |

---

### Sample Request Body (POST Login)

```json
{
  "username": "admin@grocery.lk",
  "password": "admin123"
}


