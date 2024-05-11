# Simple Banking Transactions System in .NET 6

This project was developed as part of the challenge to create a banking transactions system using the .NET 6 framework.

## Technologies Used

- **.NET 6:** Used for backend development.
- **SQL Database:** Used [Postgres] to store account and transaction data.

## Environment Setup

To run this project locally, follow the steps below:

1. **Clone the repository:**
`https://github.com/Sweetrin0t7/BankingTransactions-`

2. **Install dependencies:**
dotnet restore

Access the application at `http://localhost:7159` in your web browser.

## Functionality

- **Transfer:** Allows transferring money between registered bank accounts.

## Project Structure

The project is structured as follows:

- **Controllers:** Contains controllers responsible for handling HTTP requests and calling corresponding services.
- **Services:** Contains the business logic of the application, where banking operations are performed.
- **Models:** Defines model classes used to represent account and transaction data.

## Testing

This project not includes unit tests to validate banking operations.

