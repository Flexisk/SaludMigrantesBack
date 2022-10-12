using BackSaludMigrantes.Models.Entities;

namespace BackSaludMigrantes.Responses
{
    public class ValidationResponse
    {
        public bool IsRegistered { get; set; }
        public string? ErrorMessage { get; set; }
        public string MigrantsStatementsFile { get; set; }
    }
}
