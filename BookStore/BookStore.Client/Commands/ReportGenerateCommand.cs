using BookStore.Client.Core;
using BookStore.Data;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace BookStore.Client.Commands
{
    public class ReportGenerateCommand : BaseCommand, ICommand
    {
        private readonly IPdfExporter exporter;

        public ReportGenerateCommand(IBookStoreContext context, IPdfExporter exporter)
            : base(context)
        {
            Guard.WhenArgument(context, "No database loaded.").IsNull().Throw();
            Guard.WhenArgument(exporter, "Exporter cannot be null").IsNull().Throw();
            this.exporter = exporter;
        }

        public override string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "Parameters cannot be null or empty.").IsNullOrEmpty().Throw();
            this.exporter.ExportToPdf(Context);
            return $"Successfully exported a list of books to file \"BookReport.pdf\".";
        }
    }
}
