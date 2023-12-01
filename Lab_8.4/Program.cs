using System;
public interface ICloneable<T>
{
    T Clone();
}
public interface IDataTemplate : ICloneable<IDataTemplate>
{
    void SetData(string data);
    string GetData();
}

// CSV
public class CsvDataTemplate : IDataTemplate
{
    private string data;

    public void SetData(string data)
    {
        this.data = data;
    }

    public string GetData()
    {
        return data;
    }

    public IDataTemplate Clone()
    {
        return new CsvDataTemplate { data = this.data };
    }
}

// XML
public class XmlDataTemplate : IDataTemplate
{
    private string data;

    public void SetData(string data)
    {
        this.data = data;
    }

    public string GetData()
    {
        return data;
    }

    public IDataTemplate Clone()
    {
        return new XmlDataTemplate { data = this.data };
    }
}

// JSON
public class JsonDataTemplate : IDataTemplate
{
    private string data;

    public void SetData(string data)
    {
        this.data = data;
    }

    public string GetData()
    {
        return data;
    }

    public IDataTemplate Clone()
    {
        return new JsonDataTemplate { data = this.data };
    }
}

// Інтерфейс адаптера
public interface IDataFormatAdapter
{
    IDataTemplate ConvertData(IDataTemplate sourceTemplate);
}

// Конвертація CSV в XML
public class CsvToXmlAdapter : IDataFormatAdapter
{
    public IDataTemplate ConvertData(IDataTemplate sourceTemplate)
    {
        Console.WriteLine("Converting CSV to XML...");
        return new XmlDataTemplate();
    }
}

// Конвертація JSON в XML
public class JsonToXmlAdapter : IDataFormatAdapter
{
    public IDataTemplate ConvertData(IDataTemplate sourceTemplate)
    {
        Console.WriteLine("Converting JSON to XML...");
        return new XmlDataTemplate();
    }
}

// Клас для вибору форматів та використання адаптерів
public class DataConversionSystem
{
    public void ConvertData(IDataFormatAdapter adapter, IDataTemplate sourceTemplate)
    {
        IDataTemplate targetTemplate = adapter.ConvertData(sourceTemplate);
        Console.WriteLine($"Converted data:\n{targetTemplate.GetData()}");
    }
}

// Клас програми для взаємодії з користувачем через консоль
class Program
{
    static void Main()
    {
        // Створення та введення даних для CSV
        IDataTemplate csvData = new CsvDataTemplate();
        csvData.SetData("CSV data...");

        // Вибір адаптера для конвертації
        Console.Write("Enter the target format (xml/json): ");
        string targetFormat = Console.ReadLine().ToLower();

        IDataFormatAdapter adapter;

        switch (targetFormat)
        {
            case "xml":
                adapter = new CsvToXmlAdapter();
                break;
            case "json":
                adapter = new JsonToXmlAdapter();
                break;
            default:
                Console.WriteLine("Invalid target format.");
                return;
        }

        // Використання системи конвертації
        DataConversionSystem conversionSystem = new DataConversionSystem();
        conversionSystem.ConvertData(adapter, csvData);
    }
}
