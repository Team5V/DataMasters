using BookStore.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace BookStore.Client.Core
{
    public class PdfExporter : IPdfExporter
    {
        private readonly string delimiter = "***************\n";

        public void ExportToPdf(IBookStoreContext context)
        {
            Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdfWriter = PdfWriter.GetInstance(
                doc, new FileStream("BookReport.pdf", FileMode.Create));

            doc.Open();

            Paragraph paragraph = new Paragraph();

            var query = context.Books.Include(x => x.Authors.Select(name => name.FullName))
                .Select(book => new
                {
                    Title = book.Title,
                    Authors = book.Authors.Select(a => a.FullName),
                    Language = book.Language,
                    Pages = book.Pages,
                    Genre = book.Genre
                });

            var queryToString = query.ToList();

            foreach (var item in queryToString)
            {
                paragraph.Add(
                    $"Title: {item.Title}\n" +
                    $"Author(s): {string.Join(",", item.Authors)}\n" +
                    $"Language: {item.Language}\n" +
                    $"Genre: {item.Genre}\n" +
                    $"Pages: {item.Pages}\n" +
                    $"{this.delimiter}");
            }

            doc.Add(paragraph);

            doc.Close();
        }
    }
}
