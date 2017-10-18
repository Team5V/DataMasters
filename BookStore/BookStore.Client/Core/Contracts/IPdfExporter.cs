using BookStore.Database;

namespace BookStore.Client.Core
{
    public interface IPdfExporter
    {
        void ExportToPdf(IBookStoreContext context);
    }
}
