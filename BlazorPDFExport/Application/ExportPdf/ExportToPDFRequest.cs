using BlazorPDFExport.Models;
using Mediator;
using PuppeteerSharp;

namespace BlazorPDFExport.Application.ExportPdf
{
    public record ExportToPDFRequest : IRequest<ExportToPDFResult>
    {
        public required string Url { get; set; }
    }
    public class CreateTodoRequestHandler(IWebHostEnvironment environment) : IRequestHandler<ExportToPDFRequest, ExportToPDFResult>
    {
        private readonly IWebHostEnvironment _environment = environment;

        public async ValueTask<ExportToPDFResult> Handle(ExportToPDFRequest request, CancellationToken cancellationToken)
        {
            try
            {
                using var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
                await using var page = await browser.NewPageAsync();
                await page.GoToAsync(request.Url);
                await page.EvaluateExpressionHandleAsync("document.fonts.ready");
                var path = Path.Combine(_environment.WebRootPath, "files");
                var fileName = $"exportPDF_{Guid.NewGuid()}.pdf";
                var filePath = Path.Combine(path, fileName);
                await page.PdfAsync(filePath);
                var urlPath = $"/files/{fileName}";
                return new ExportToPDFResult { Success = true, Message = "PDF exported successfully", FilePath = urlPath, UrlExportPDF = request.Url };

            }
            catch (Exception ex)
            {
                return new ExportToPDFResult { Success = false, Message = ex.Message };
            }
        }
    }
}