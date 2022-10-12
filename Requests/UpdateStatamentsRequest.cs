namespace BackSaludMigrantes.Requests
{
    public class UpdateStatamentsRequest
    {
        public string DataSISBEN { get; set; }
        public string Direction { get; set; }
        public string Mobile { get; set; }
        public byte LocationId { get; set; }
    }
}
