#load "../../../packages.csx"

using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

QuestPDF.Settings.License = LicenseType.Community;

Document
    .Create(document =>
    {
        document.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(2, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(text => text.FontSize(20));

            page.Header()
                .Text("Hello World!")
                .SemiBold()
                .FontSize(30)
                .FontColor(Colors.Blue.Medium);

            page.Content()
                .PaddingVertical(1, Unit.Centimetre)
                .Column(column =>
                {
                    column.Spacing(20);
                    column.Item()
                        .Text(Placeholders.LoremIpsum())
                        .Justify();

                    column.Item()
                        .Image(Placeholders.Image(200, 100));
                });

            page.Footer()
                .AlignCenter()
                .Text(text =>
                {
                    text.Span("Page ");
                    text.CurrentPageNumber();
                });
        });
    })
    .GeneratePdfAndShow();
