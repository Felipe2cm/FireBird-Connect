using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using ClosedXML.Excel;

namespace ConnectToFireBirdDB
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }


        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            GenerateExcelFireBird();
        }

        private static void GenerateExcelFireBird()
        {
            string connectionString = Configuration.GetConnectionString("FireBirdConnection").ToString();

            FireBird fb = new(connectionString);            

            DataTable dataTable = fb.DataTableRetornar("SELECT * FROM PRODUTO");

            XLWorkbook wb = new();            

            wb.Worksheets.Add(dataTable, "Produtos");

            wb.SaveAs("ProdutosImportados.xlsx");
        }
    }
}
