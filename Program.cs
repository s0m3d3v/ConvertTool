using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using Spectre.Console;

namespace ConvertTool
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose the conversion type:")
                        .AddChoices("XML to JSON", "CSV to JSON", "Exit"));

                switch (choice)
                {
                    case "XML to JSON":
                        ConvertXmlToJson();
                        break;
                    case "CSV to JSON":
                        ConvertCsvToJson();
                        break;
                    case "Exit":
                        if (AnsiConsole.Confirm("Are you sure you want to exit?"))
                        {
                            AnsiConsole.MarkupLine("[green]Exiting the program. Goodbye![/]");
                            return;
                        }
                        break;
                }
            }
        }

        static void ConvertXmlToJson()
        {
            var xmlPath = AnsiConsole.Ask<string>("Enter path for XML file:");
            var jsonPath = AnsiConsole.Ask<string>("Enter path to save JSON file:");

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);
                string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
                File.WriteAllText(jsonPath, jsonText);
                AnsiConsole.MarkupLine("[green]Conversion success![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
            }
        }

        static void ConvertCsvToJson()
        {
            var csvPath = AnsiConsole.Ask<string>("Enter path to CSV file:");
            var jsonPath = AnsiConsole.Ask<string>("Enter path to save JSON file:");

            try
            {
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<dynamic>();
                    string jsonText = JsonConvert.SerializeObject(records, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(jsonPath, jsonText);
                    AnsiConsole.MarkupLine("[green]Conversion success![/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
            }
        }
    }
}
