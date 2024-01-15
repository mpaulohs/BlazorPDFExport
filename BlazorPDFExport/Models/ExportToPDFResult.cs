namespace BlazorPDFExport.Models
{
    public record ExportToPDFResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string UrlExportPDF { get; set; } = string.Empty;
    }
}
