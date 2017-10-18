using BookStore.Data;

namespace BookStore.Client.Core
{
    public interface IPdfExporter
    {
        void ExportToPdf(IBookStoreContext context);
    }
}
