# Car Renting System

**Team ID:** 22

**TA:** Alaa Khaled

---

## Description

A C# Windows Forms application for managing a car‑rental workflow, backed by an Oracle database.

---

## Table of Contents

1. [Features](#features)
2. [Technologies](#technologies)
3. [Folder Structure](#folder-structure)
4. [Database Setup](#database-setup)
5. [Running the Application](#running-the-application)
6. [Documentation](#documentation)
7. [Contact](#contact)

---

## Features

* **User Roles:**

  * Customers: register, log in, search available cars, rent or cancel rentals.
  * Admins: add/update/remove cars, view all rentals.

* **Oracle Stored Procedures:**

  * Encapsulated business logic for inserting, querying, and updating rental data.
  * Examples: `GET_AVAILABLE_CARS`, `CREATE_RENTAL`, `CANCEL_RENTAL`.

* **WinForms UI:**

  * Intuitive forms for login, registration, car catalog, and rental management.
  * Crystal Reports integration (if required by Phase 2).

---

## Technologies

* **C# Windows Forms** (.NET 6.0 or later)
* **Visual Studio 2022** (or newer)
* **Oracle Database** (SQL Developer for DDL/DML)
* **Crystal Reports** (reporting engine, if applicable)
* **Git & GitHub** (version control)

---

## Folder Structure

```
Car-Renting-System
├─ docs
│   ├─ Phase1_CarRentingSystem.docx
│   └─ Phase2_CarRentingSystem.docx
│
├─ sql
│   ├─ create_tables.sql
│   ├─ sample_data_inserts.sql
│   └─ stored_procedures.sql
│
├─ src
│   └─ CarRentingSystem
│       ├─ CarRentingSystem.sln
│       ├─ CarRentingSystem.csproj
│       ├─ /bin
│       ├─ /obj
│       ├─ /Forms
│       │   ├─ LoginForm.cs
│       │   ├─ RegistrationForm.cs
│       │   ├─ MainForm.cs
│       │   └─ …  
│       ├─ /Reports         ← Crystal Reports (.rpt) files (Phase 2)  
│       └─ /Models          ← Entity classes, database‑helper classes  
│
├─ .gitignore
└─ README.md
```

---

## Database Setup

1. **Install/Start Oracle Database**

   * Confirm you have an Oracle instance running (XE or full edition).
   * Open **Oracle SQL Developer** and connect with your credentials.

2. **Create Tables**

   * Execute `sql/create_tables.sql` to create all required tables:

     * `Users`
     * `Cars`
     * `Rentals`
     * Any lookup or join tables.

3. **Insert Sample Data**

   * Execute `sql/sample_data_inserts.sql` to populate initial rows (demo users, cars).

4. **Create Stored Procedures**

   * Execute `sql/stored_procedures.sql` to create procedures used by the application (e.g., `GET_AVAILABLE_CARS`, `CREATE_RENTAL`, `CANCEL_RENTAL`).

---

## Documentation

* **Phase 1 Deliverable** (`docs/Phase1_CarRentingSystem.docx`):

  * Software Requirements Specification (SRS).
  * Use‑case diagram (≥ 5 use cases, ≥ 2 actors).
  * Sequence diagram for one main use case.

* **Phase 2 Deliverable** (`docs/Phase2_CarRentingSystem.docx`):

  * Table definitions and stored‑procedure scripts (exported from Oracle SQL Developer).
  * Two ODP.NET forms (connected & disconnected modes).
  * Crystal Reports examples (grouped columns, summary fields, parameters).
  * GUI screenshots and navigation.

---

## Contact

If you have questions or need assistance, contact:

* **Your Name** ‹[ibrahimmohamedabdelsadek@gmail.com)›

