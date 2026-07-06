# 🍏 Grocery Inventory Management System
## API Overview

**Version:** 1.0  
**Base URL:** `https://localhost:7016/api`  
**Prepared By:** [Your Name]  
**Company:** Ceylon Innovation Services (PVT) LTD  
**Branch:** Negombo Branch  
**Date:** July 2026  

---

## Quick Links

| Module | File |
|--------|------|
| Categories | [CATEGORY_API.md](CATEGORY_API.md) |
| Suppliers | [SUPPLIER_API.md](SUPPLIER_API.md) |
| Items | [ITEM_API.md](ITEM_API.md) |
| Stock Management | [STOCK_API.md](STOCK_API.md) |

---

## Common Response Format

All APIs return responses in this format:

```json
{
  "success": true,
  "message": "Operation completed successfully.",
  "data": {
    "id": 1,
    "name": "Example"
  },
  "errors": null
}


---

## 📁 **File 2: CATEGORY_API.md**

```markdown
# 📂 Category API Documentation

**Base URL:** `https://localhost:7016/api`  
**Module:** Categories  
**Version:** 1.0

---

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/category` | Get all categories |
| GET | `/api/category/{id}` | Get category by ID |
| POST | `/api/category` | Create a new category |
| PUT | `/api/category/{id}` | Update a category |
| DELETE | `/api/category/{id}` | Delete a category |
| GET | `/api/category/search?keyword={keyword}` | Search categories |
| GET | `/api/category/active` | Get active categories |

---

## 1. Get All Categories

**Method:** `GET`  
**Endpoint:** `/api/category`  
**Description:** Retrieves a list of all categories.

**Sample Response:**
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
    }
  ],
  "errors": null
}


---

## 📁 **File 3: SUPPLIER_API.md**

```markdown
# 🏢 Supplier API Documentation

**Base URL:** `https://localhost:7016/api`  
**Module:** Suppliers  
**Version:** 1.0

---

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/supplier` | Get all suppliers |
| GET | `/api/supplier/{id}` | Get supplier by ID |
| POST | `/api/supplier` | Create a new supplier |
| PUT | `/api/supplier/{id}` | Update a supplier |
| DELETE | `/api/supplier/{id}` | Delete a supplier |
| GET | `/api/supplier/search?keyword={keyword}` | Search suppliers |
| GET | `/api/supplier/active` | Get active suppliers |

---

## 1. Get All Suppliers

**Method:** `GET`  
**Endpoint:** `/api/supplier`  
**Description:** Retrieves a list of all suppliers.

**Sample Response:**
```json
{
  "success": true,
  "message": "Operation successful",
  "data": [
    {
      "supplierId": 1,
      "supplierName": "Ceylon Foods (Pvt) Ltd",
      "contactNumber": "077-1234567",
      "email": "info@ceylonfoods.lk",
      "address": "No. 123, Galle Road, Colombo 03",
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    },
    {
      "supplierId": 2,
      "supplierName": "Lanka Mills (Pvt) Ltd",
      "contactNumber": "011-9876543",
      "email": "info@lankamills.lk",
      "address": "No. 456, Kandy Road, Kurunegala",
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    }
  ],
  "errors": null
}


---

## 📁 **File 4: ITEM_API.md**

```markdown
# 📦 Item API Documentation

**Base URL:** `https://localhost:7016/api`  
**Module:** Items  
**Version:** 1.0

---

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/item` | Get all items |
| GET | `/api/item/{id}` | Get item by ID |
| POST | `/api/item` | Create a new item |
| PUT | `/api/item/{id}` | Update an item |
| DELETE | `/api/item/{id}` | Delete an item |
| GET | `/api/item/search?keyword={keyword}` | Search items |
| GET | `/api/item/category/{categoryId}` | Get items by category |
| GET | `/api/item/supplier/{supplierId}` | Get items by supplier |
| GET | `/api/item/low-stock` | Get low stock items |

---

## 1. Get All Items

**Method:** `GET`  
**Endpoint:** `/api/item`  
**Description:** Retrieves a list of all items with stock information.

**Sample Response:**
```json
{
  "success": true,
  "message": "Operation successful",
  "data": [
    {
      "itemId": 1,
      "itemCode": "RICE001",
      "barcode": "8901234567890",
      "itemName": "Basmati Rice 1kg",
      "categoryId": 1,
      "categoryName": "Rice",
      "supplierId": 1,
      "supplierName": "Ceylon Foods",
      "costPrice": 150.00,
      "sellingPrice": 210.00,
      "reorderLevel": 20,
      "currentStock": 45,
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    },
    {
      "itemId": 2,
      "itemCode": "RICE002",
      "barcode": "8901234567891",
      "itemName": "Kekulu Rice 1kg",
      "categoryId": 1,
      "categoryName": "Rice",
      "supplierId": 1,
      "supplierName": "Ceylon Foods",
      "costPrice": 120.00,
      "sellingPrice": 180.00,
      "reorderLevel": 20,
      "currentStock": 2,
      "isActive": true,
      "createdDate": "2026-07-06T10:00:00"
    }
  ],
  "errors": null
}


---

## 📁 **File 5: STOCK_API.md**

```markdown
# 📊 Stock API Documentation

**Base URL:** `https://localhost:7016/api`  
**Module:** Stock Management  
**Version:** 1.0

---

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/stock/in` | Add stock in |
| POST | `/api/stock/out` | Remove stock out |
| GET | `/api/stock/balance` | Get stock balance report |
| GET | `/api/stock/low-stock` | Get low stock report |
| GET | `/api/stock/records` | Get all stock in records |
| GET | `/api/stock/out/records` | Get all stock out records |
| GET | `/api/stock/in/item/{itemId}` | Get stock in by item |
| GET | `/api/stock/out/item/{itemId}` | Get stock out by item |

---

## 1. Add Stock In

**Method:** `POST`  
**Endpoint:** `/api/stock/in`  
**Description:** Records incoming stock from suppliers.  
**Content-Type:** `application/json`

### Request Body

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `itemId` | `int` | Yes | ID of the item |
| `supplierId` | `int` | Yes | ID of the supplier |
| `quantity` | `int` | Yes | Quantity received |
| `costPrice` | `decimal` | Yes | Cost per unit |
| `stockInDate` | `string` | No | Date (default: today) |

**Sample Request:**
```json
{
  "itemId": 1,
  "supplierId": 1,
  "quantity": 50,
  "costPrice": 150.00,
  "stockInDate": "2026-07-06"
}


---

## 📁 **File 6: API_SUMMARY.md**

```markdown
# 📋 API Summary – Complete Endpoints Table

**Base URL:** `https://localhost:7016/api`  
**Version:** 1.0  
**Total Endpoints:** 31

---

## All Endpoints

| # | Method | Endpoint | Module | Description |
|---|--------|----------|--------|-------------|
| 1 | GET | `/api/category` | Categories | Get all categories |
| 2 | GET | `/api/category/{id}` | Categories | Get category by ID |
| 3 | POST | `/api/category` | Categories | Create category |
| 4 | PUT | `/api/category/{id}` | Categories | Update category |
| 5 | DELETE | `/api/category/{id}` | Categories | Delete category |
| 6 | GET | `/api/category/search?keyword={keyword}` | Categories | Search categories |
| 7 | GET | `/api/category/active` | Categories | Get active categories |
| 8 | GET | `/api/supplier` | Suppliers | Get all suppliers |
| 9 | GET | `/api/supplier/{id}` | Suppliers | Get supplier by ID |
| 10 | POST | `/api/supplier` | Suppliers | Create supplier |
| 11 | PUT | `/api/supplier/{id}` | Suppliers | Update supplier |
| 12 | DELETE | `/api/supplier/{id}` | Suppliers | Delete supplier |
| 13 | GET | `/api/supplier/search?keyword={keyword}` | Suppliers | Search suppliers |
| 14 | GET | `/api/supplier/active` | Suppliers | Get active suppliers |
| 15 | GET | `/api/item` | Items | Get all items |
| 16 | GET | `/api/item/{id}` | Items | Get item by ID |
| 17 | POST | `/api/item` | Items | Create item |
| 18 | PUT | `/api/item/{id}` | Items | Update item |
| 19 | DELETE | `/api/item/{id}` | Items | Delete item |
| 20 | GET | `/api/item/search?keyword={keyword}` | Items | Search items |
| 21 | GET | `/api/item/category/{categoryId}` | Items | Get items by category |
| 22 | GET | `/api/item/supplier/{supplierId}` | Items | Get items by supplier |
| 23 | GET | `/api/item/low-stock` | Items | Get low stock items |
| 24 | POST | `/api/stock/in` | Stock | Add stock in |
| 25 | POST | `/api/stock/out` | Stock | Remove stock out |
| 26 | GET | `/api/stock/balance` | Stock | Get stock balance report |
| 27 | GET | `/api/stock/low-stock` | Stock | Get low stock report |
| 28 | GET | `/api/stock/records` | Stock | Get all stock in records |
| 29 | GET | `/api/stock/out/records` | Stock | Get all stock out records |
| 30 | GET | `/api/stock/in/item/{itemId}` | Stock | Get stock in by item |
| 31 | GET | `/api/stock/out/item/{itemId}` | Stock | Get stock out by item |

---

## Quick Reference by Module

### Categories (7 endpoints)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/category` | Get all categories |
| GET | `/api/category/{id}` | Get category by ID |
| POST | `/api/category` | Create category |
| PUT | `/api/category/{id}` | Update category |
| DELETE | `/api/category/{id}` | Delete category |
| GET | `/api/category/search` | Search categories |
| GET | `/api/category/active` | Get active categories |

### Suppliers (7 endpoints)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/supplier` | Get all suppliers |
| GET | `/api/supplier/{id}` | Get supplier by ID |
| POST | `/api/supplier` | Create supplier |
| PUT | `/api/supplier/{id}` | Update supplier |
| DELETE | `/api/supplier/{id}` | Delete supplier |
| GET | `/api/supplier/search` | Search suppliers |
| GET | `/api/supplier/active` | Get active suppliers |

### Items (9 endpoints)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/item` | Get all items |
| GET | `/api/item/{id}` | Get item by ID |
| POST | `/api/item` | Create item |
| PUT | `/api/item/{id}` | Update item |
| DELETE | `/api/item/{id}` | Delete item |
| GET | `/api/item/search` | Search items |
| GET | `/api/item/category/{categoryId}` | Get items by category |
| GET | `/api/item/supplier/{supplierId}` | Get items by supplier |
| GET | `/api/item/low-stock` | Get low stock items |

### Stock (8 endpoints)

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/stock/in` | Add stock in |
| POST | `/api/stock/out` | Remove stock out |
| GET | `/api/stock/balance` | Get stock balance |
| GET | `/api/stock/low-stock` | Get low stock report |
| GET | `/api/stock/records` | Get all stock in records |
| GET | `/api/stock/out/records` | Get all stock out records |
| GET | `/api/stock/in/item/{itemId}` | Get stock in by item |
| GET | `/api/stock/out/item/{itemId}` | Get stock out by item |

---

## Sample API Call (cURL)

### Get All Categories
```bash
curl -X GET https://localhost:7016/api/category

