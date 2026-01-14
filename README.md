# DateTimePlus

![NuGet](https://img.shields.io/nuget/v/DateTimePlus?color=blue)
![.NET](https://img.shields.io/badge/.NET-9.0-blue)

`DateTimePlus` is a lightweight extensions library for working with dates and times in **.NET 9**. It simplifies common operations that normally require repetitive or complex code, such as working with `DateOnly`, `TimeOnly`, and date ranges.

---

## Main Features

### 1️⃣ DateOnlyExtensions
- Useful methods for working with `DateOnly`.  
- Examples:
  - `NextWeekday()` → Gets the next business day.  
  - `AddBusinessDays(int days)` → Adds business days skipping weekends.  
  - `DaysUntil(DateOnly date)` → Calculates the difference in days.  
  - `MonthsUntil(DateOnly date)` → Calculates the difference in months.  

### 2️⃣ TimeOnlyExtensions
- Combines `TimeOnly` with `DateOnly` to obtain a `DateTime`.  

### 3️⃣ DateRange
- Easily work with ranges of dates.  
- Main methods:
  - `Days()` → Returns all days in the range.  
  - `BusinessDays()` → Returns only business days.  
  - `Contains(DateOnly date)` → Checks if a date is within the range.  

---

## Installation

Install via NuGet:

```bash
dotnet add package DateTimePlus --version 0.3.0
