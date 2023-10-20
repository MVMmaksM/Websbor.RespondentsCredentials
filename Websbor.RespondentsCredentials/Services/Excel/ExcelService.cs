using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.RespondentsCredentials.Services.Excel
{
    public class ExcelService : IExcelService
    {
        public byte[] GetExcelCatalog(List<CatalogWebsborAsgs> catalog)
        {
            throw new NotImplementedException();
        }

        public byte[] GetExcelCredential(List<Credentials> credential)
        {
            throw new NotImplementedException();
        }

        public byte[] GetShemaLoadCatalog()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Схема загрузки каталога Web-сбора");

            sheet.Cells["A1"].Value = "Краткое наименование";
            sheet.Cells["A1"].Value = "Полное наименование";
            sheet.Cells["B1"].Value = "ОКПО";
            sheet.Cells["C1"].Value = "ОКПО ЮЛ";
            sheet.Cells["D1"].Value = "ИНН";
            sheet.Cells["D1"].Value = "Адрес";
            sheet.Cells["D1"].Value = "ОКВЭД 2 факт.";
            sheet.Cells["D1"].Value = "ОКАТО факт.";
            sheet.Cells["D1"].Value = "ОКТМО факт.";
            sheet.Cells["D1"].Value = "ОКФС";
            sheet.Cells["D1"].Value = "ОКОГУ";
            sheet.Cells["D1"].Value = "ОКОПФ";
            sheet.Cells["D1"].Value = "Телефон";
            sheet.Cells["D1"].Value = "Доп. телефон";
            sheet.Cells["D1"].Value = "Адрес электронной почты";

            sheet.View.FreezePanes(2, 1);
            sheet.Cells[1, 1, 1, 15].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet.Cells[1, 1, 1, 15].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(217, 217, 217));
            sheet.Columns[1].Width = 100;
            sheet.Columns[2].Width = 30;
            sheet.Columns[3].Width = 30;
            sheet.Columns[4].Width = 30;
            sheet.Columns[5].Width = 30;
            sheet.Columns[6].Width = 30;
            sheet.Columns[7].Width = 30;
            sheet.Columns[8].Width = 30;
            sheet.Columns[9].Width = 30;
            sheet.Columns[10].Width = 30;
            sheet.Columns[11].Width = 30;
            sheet.Columns[12].Width = 30;
            sheet.Columns[13].Width = 30;
            sheet.Columns[14].Width = 30;
            sheet.Columns[15].Width = 30;
            sheet.Columns[1, 15].Style.Font.Name = "Times New Roman";
            sheet.Columns[1, 15].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Columns[1, 15].Style.Font.Size = 12;
            sheet.Cells[1, 1, 1, 15].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, 15].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Rows[1].Height = 30;
            sheet.Cells[1, 1, 1, 15].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 1, 15].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 1, 15].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 1, 15].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Columns[1, 15].Style.Numberformat.Format = "@";

            return package.GetAsByteArray();
        }

        public byte[] GetShemaLoadCredential()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("Схема загрузки учетных данных респондентов");

            sheet.Cells["A1"].Value = "Наименование";
            sheet.Cells["B1"].Value = "ОКПО";
            sheet.Cells["C1"].Value = "Пароль";
            sheet.Cells["D1"].Value = "Примечание";

            sheet.View.FreezePanes(2, 1);
            sheet.Cells[1, 1, 1, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet.Cells[1, 1, 1, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(217, 217, 217));
            sheet.Columns[1].Width = 100;
            sheet.Columns[2].Width = 30;
            sheet.Columns[3].Width = 30;
            sheet.Columns[4].Width = 30;
            sheet.Columns[1, 4].Style.Font.Name = "Times New Roman";
            sheet.Columns[1, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Columns[1, 4].Style.Font.Size = 12;
            sheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
            sheet.Cells[1, 1, 1, 4].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Rows[1].Height = 30;
            sheet.Cells[1, 1, 1, 4].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 1, 4].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 1, 4].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[1, 1, 1, 4].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Columns[1, 4].Style.Numberformat.Format = "@";

            return package.GetAsByteArray();
        }

        public List<CatalogWebsborAsgs> ReadExcelCatalog(string pathFile)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage(pathFile);
            var sheet = package.Workbook.Worksheets[0];

            return new List<CatalogWebsborAsgs>();
        }

        public List<Credentials> ReadExcelCredential(string pathFile)
        {
            throw new NotImplementedException();
        }
    }
}
