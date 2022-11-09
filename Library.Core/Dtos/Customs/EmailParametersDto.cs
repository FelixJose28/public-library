namespace Library.Core.Dtos.Customs
{
    public class EmailParametersDto
    {
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public bool IsHtml { get; set; }
    }
}
