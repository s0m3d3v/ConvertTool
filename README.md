# ConvertTool

ConvertTool is a command-line application built with .NET and Spectre.Console that converts XML files to JSON and CSV files to JSON. This tool provides a simple and interactive way to perform these conversions.

## Features

- Interactive command-line interface.
- Convert XML files to JSON and CSV format.
- Convert JSON files to XML and CSV format
- Convert CSV files to JSON and XML format.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

## Libraries
- [Spectre.Console](https://spectreconsole.net/)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [CsvHelper](https://joshclose.github.io/CsvHelper/)

## Getting Started

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/ConvertTool.git
    cd ConvertTool
    ```

2. **Build the project:**

    ```bash
    dotnet build
    ```

3. **Run the application:**

    ```bash
    dotnet run
    ```

## Usage

When you run the application, you will be prompted to choose the conversion type:

- **XML to JSON**: Converts an XML file to JSON format.
- **CSV to JSON**: Converts a CSV file to JSON format.
- **Exit**: Exits the application.

### XML to JSON Conversion

1. Enter the path to the XML file you want to convert.
2. Enter the path where you want to save the JSON file.
3. The tool will convert the XML file to JSON and save it to the specified location.

### CSV to JSON Conversion

1. Enter the path to the CSV file you want to convert.
2. Enter the path where you want to save the JSON file.
3. The tool will convert the CSV file to JSON and save it to the specified location.

## License

MIT License

Copyright (c) [2024] [moroysn]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
