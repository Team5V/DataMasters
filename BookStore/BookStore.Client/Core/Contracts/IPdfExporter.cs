using BookStore.Database;

namespace BookStore.Client.Core.Contracts
{
    public interface IPdfExporter
    {
        void ExportToPdf(IBookStoreContext context);
    }
}
