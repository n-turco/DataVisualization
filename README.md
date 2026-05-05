# DataVisualization

## Project Overview

DataVisualization is a Windows Forms desktop application that parses CSV files, processes, and renders a visual representation of COVID-19 data. Built entirely in C#, it provides an intuitive graphical interface for exploring pandemic statistics through interactive charts and graphs.

## Key Features

* Load and display COVID-19 data visually within a Windows Forms UI
* Data was pulled from https://health-infobase.canada.ca/covid-19/ | cases_and_deaths.csv | lab_indicators_data.csv 
* Interactive chart controls for exploring case trends and statistics
* Event-driven Windows Forms design using the built-in charting library
* Lightweight desktop application with no external server or database required

## Technical Stack

* **.NET** (Windows Forms / WinForms)
* **C#** — 100% of the codebase
* **System.Windows.Forms.DataVisualization** — charting and graphing controls
* **Visual Studio** solution format (`.slnx`)

## Project Structure

```
DataVisualization/
├── DataVisualization/          # Main application project
│   ├── Form1.cs                # Primary Windows Form with chart UI and event logic
│   ├── Form1.Designer.cs       # Auto-generated designer layout
│   └── ...                     # Supporting classes and resources
├── DataVisualization.slnx      # Visual Studio solution file
├── .gitignore
└── .gitattributes
```

## How to Run (Local Development)

1. **Prerequisites:** Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) and Visual Studio (or the .NET CLI) installed on a Windows machine.

2. **Clone the repository:**
   ```bash
   git clone https://github.com/n-turco/DataVisualization.git
   cd DataVisualization
   ```

3. **Open in Visual Studio:**
   Open `DataVisualization.slnx` in Visual Studio and press **F5** to build and run.

   **Or via CLI:**
   ```bash
   dotnet restore
   dotnet build
   dotnet run --project DataVisualization/DataVisualization.csproj
   ```

4. The Windows Forms window will launch, displaying the COVID-19 data visualization.

> **Note:** This is a Windows-only application due to its dependency on Windows Forms.

## Developer

Nicholas Turco
