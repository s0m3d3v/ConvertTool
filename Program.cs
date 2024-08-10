using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;
using Spectre.Console;
using System.Globalization;
using System.Collections.Generic;

public class ConvertTool
{
    public static void Main(string[] args)
    {
        var formats = new List<string> { "XML", "CSV", "JSON" };

        var fromFormat = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select the [green]source format[/]:")
                .AddChoices(formats));

        formats.Remove(fromFormat);

        var toFormat = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select the [green]target format[/]:")
                .AddChoices(formats));

        var inputFilePath = AnsiConsole.Ask<string>($"Enter the [green]input file path for {fromFormat}[/]:");
        var outputFilePath = AnsiConsole.Ask<string>($"Enter the [green]output file path for {toFormat}[/]:");

        try
        {
            var inputContent = File.ReadAllText(inputFilePath);
            string outputContent = fromFormat switch
            {
                "XML" => ConvertFromXml(inputContent, toFormat),
                "CSV" => ConvertFromCsv(inputContent, toFormat),
                "JSON" => ConvertFromJson(inputContent, toFormat),
                _ => throw new NotSupportedException("Unsupported format")
            };

            File.WriteAllText(outputFilePath, outputContent);
            AnsiConsole.MarkupLine("[green]Conversion successful![/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
        }
    }

    private static string ConvertFromXml(string input, string toFormat)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(input);
        var jsonText = JsonConvert.SerializeXmlNode(xmlDoc);

        return toFormat switch
        {
            "CSV" => JsonToCsv(jsonText),
            "JSON" => jsonText,
            _ => throw new NotSupportedException("Unsupported target format")
        };
    }

    private static string ConvertFromCsv(string input, string toFormat)
    {
        using var reader = new StringReader(input);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<dynamic>();

        var jsonText = JsonConvert.SerializeObject(records);

        return toFormat switch
        {
            "XML" => JsonToXml(jsonText),
            "JSON" => jsonText,
            _ => throw new NotSupportedException("Unsupported target format")
        };
    }

    private static string ConvertFromJson(string input, string toFormat)
    {
        return toFormat switch
        {
            "XML" => JsonToXml(input),
            "CSV" => JsonToCsv(input),
            _ => throw new NotSupportedException("Unsupported target format")
        };
    }

    private static string JsonToXml(string json)
    {
        var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
        var wrappedJson = new { Root = jsonObject };
        var xmlDoc = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(wrappedJson), "Root");
        using var stringWriter = new StringWriter();
        using var xmlTextWriter = XmlWriter.Create(stringWriter);
        xmlDoc.WriteTo(xmlTextWriter);
        xmlTextWriter.Flush();
        return stringWriter.GetStringBuilder().ToString();
    }

    private static string JsonToCsv(string json)
    {
        var records = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        using var writer = new StringWriter();
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
        csv.WriteRecords(records);
        return writer.ToString();
    }

}
