using BookStore.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.IO;
using System.Linq;

namespace BookStore.Client.Core
{
    public class PdfExporter : IPdfExporter
    {
        public void ExportToPdf(IBookStoreContext context)
        {
            Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdfWriter = PdfWriter.GetInstance(
                doc, new FileStream("BookReport.pdf", FileMode.Create));

            doc.Open();

            Paragraph paragraph = new Paragraph();
            //TODO refactor using lambda expressions syntax
            var query = from book in context.Books
                        from author in book.Authors
                        select new
                        {
                            Title = book.Title,
                            Authors = author.FullName,
                            Language = book.Language,
                            Pages = book.Pages,
                            Genre = book.Genre
                        } into x
                        select x;

            var queryToString = query.ToList();

            foreach (var item in queryToString as IEnumerable)
            {
                paragraph.Add($"{item.ToString()}\n");
            }

            doc.Add(paragraph);

            doc.Close();
        }
    }
}
