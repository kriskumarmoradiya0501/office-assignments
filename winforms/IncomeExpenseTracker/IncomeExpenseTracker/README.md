# Income & Expense Tracker (WinForms, .NET 8)

A simple desktop app built exactly to the feature list you gave, with everything written
in plain code (no drag-and-drop designer files) so it's easy to read top to bottom.

## Project layout
```
IncomeExpenseTracker/
├── IncomeExpenseTracker.csproj
├── Program.cs                 -> entry point, shows Login then Main window
├── Models/
│   └── Transaction.cs         -> one record (Id, Date, Description, Type, Category, Amount)
└── Forms/
    ├── LoginForm.cs           -> username/password check (admin / password123)
    └── MainForm.cs            -> everything else: menu, input fields, list, summary, graph
```

## How to run it
This is a **Windows Forms** app, so it only runs on **Windows**.

1. Install the free **.NET 8 SDK** if you don't have it: https://dotnet.microsoft.com/download
2. Open a terminal/command prompt in the `IncomeExpenseTracker` folder.
3. Run:
   ```
   dotnet run
   ```
   (or open the folder in Visual Studio 2022 and press F5)

Login with:
- Username: `admin`
- Password: `password123`

## How the features map to the code (all inside `MainForm.cs`)
- **File → Import/Export Records** – reads/writes a CSV file (`OpenFileDialog` / `SaveFileDialog`)
- **Transaction → Add/Update/Delete** – uses whatever is currently typed in the input group;
  Update/Delete need a row selected first in the list
- **View → Show All/Income/Expense** – filters the ListView
- **View → Summary/Graph** – recalculates totals for the month chosen in the Month control
  and redraws the bar chart on the PictureBox
- **Settings → Change Font/Color** – `FontDialog` / `ColorDialog` applied to the list
- Selecting a row in the list loads it back into the input fields so you can edit or delete it

## Notes
- Data is kept in memory while the app runs (a `List<Transaction>`) — Import/Export is how you
  save/load between sessions, exactly as the spec asked for.
- No database is used, to keep things simple.
- Categories used: Income = Salary, Business, Interest, Gift, Other.
  Expense = Food, Travel, Rent, Shopping, Other.
