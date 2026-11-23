using System;

namespace SolidRefactoringLab
{
    public interface IReportFormatter
    {
        void FormatReport();
    }
    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }
    public class WordFormatter : IReportFormatter
    {
        public void  FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }
    public class PlainTextFormatter : IReportFormatter
    {
        public void  FormatReport()
        {
            Console.WriteLine("Formatting report as a plain text...");
        }
    }
    public class ExcelReportType : IReportFormatter
    {
        public  void  FormatReport()
        {
            Console.WriteLine("Formatting report as a Excel Spreadsheet...");
        }
    } 
    public class ReportManager
    {
        private readonly IReportFormatter _formatter;
        public string ReportData { get; set; } = string.Empty;
        public ReportManager(IReportFormatter formatter)
        {
        _formatter = formatter;
        }
        public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }
    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
        }
    class Program
    {
        static void Main(string[] args)
        {
            IReportFormatter formatter = new PdfFormatter();
            // 2. Pass it to the manager
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();
            // 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}