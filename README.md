# Superheroes Database Project

## Introduction and Overview
This project involves creating SQL scripts to set up a database called SuperheroesDb, which revolves around superheroes. The scripts create tables, establish relationships between them, and populate the tables with data.

## Getting Started

### Prerequisites
- SQL Server Management Studio (SSMS) or an equivalent SQL client.
- SQL Server database server.

### Installation
1. Clone this repository.
2. Open SSMS and connect to your SQL Server instance.
3. Update the connection string in your C# code to match your SQL Server instance. You can find the connection string in the `ConnectionStringHelper` class in the `Chinook.Repositories` namespace. Replace the value of `connectionStringBuilder.DataSource` with the address of your SQL Server instance.

4. Run the SQL scripts in the following order:

**Note: Please run the following SQL scripts in SQL Server Management Studio (SSMS):**

### 01_dbCreate.sql
Creates the SuperheroesDb database.

### 02_tableCreate.sql
Creates tables: Superhero, Assistant, and Power, each with primary keys.

### 03_relationshipSuperheroAssistant.sql
Establishes a relationship between Superhero and Assistant using foreign keys.

### 04_relationshipSuperheroPower.sql
Creates a linking table to represent the many-to-many relationship between Superhero and Power.

### 05_insertSuperheroes.sql
Inserts three superheroes into the database.

### 06_insertAssistants.sql
Inserts three assistants and assigns them to superheroes.

### 07_powers.sql
Inserts four powers and associates them with superheroes.

### 08_updateSuperhero.sql
Updates the name of a selected superhero.

### 09_deleteAssistant.sql
Deletes an assistant by name.

## Usage
- You can use the provided scripts to set up the Superheroes database and perform CRUD operations on superheroes, assistants, and powers.

### Appendix B: Reading Data with SQL Client (Visual Studio)
- This section pertains to a separate part of the project where you interact with the Chinook database using C# and SQL Client library in Visual Studio.

### Customer Requirements
- Read all customers, specific customers, or customers by name.
- Return a page of customers.
- Add a new customer.
- Update an existing customer.
- Get the number of customers in each country.
- Get the highest spending customers.
- Determine the most popular genre for a given customer.


## Contributors
[Tobias Vetrhus](https://github.com/TobiasVetrhus)
[Tommy Jåvold](https://github.com/t-lined)
[Ritwaan Hashi](https://github.com/ritwaan)

