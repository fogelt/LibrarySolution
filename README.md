# Library Solution

A .NET 9 library management system built with C# using clean architecture principles. Manage books, DVDs, and magazines with features for searching, borrowing, and member tracking.

## Quick Start

### Prerequisites
- .NET 9 SDK

### Run the Application

```bash
dotnet run --project Library.ConsoleApp
```

The interactive console menu will guide you through:
- Browsing library items
- Searching by title, author, or ISBN
- Borrowing and returning items
- Viewing members and statistics

### Run Tests

```bash
dotnet test
```

## Features

- **Item Management**: Books, DVDs, and Magazines
- **Member Management**: Register and track library members
- **Borrowing System**: Borrow and return items with availability tracking
- **Search & Filtering**: Search by title, author, or ISBN
- **Statistics**: Track most active members and library statistics

## Project Structure

- **Library.Core**: Business logic, models, and data persistence
- **Library.ConsoleApp**: Interactive console UI
- **Library.Tests**: Comprehensive unit tests

## Sample Data

The application includes pre-populated mock data in `mockdb.json` for immediate testing.
