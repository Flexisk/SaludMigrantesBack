using BackSaludMigrantes.Models.Entities;

namespace BackSaludMigrantes.Responses
{
    public class StatamentsResponse
    {
        public bool IsRegistered { get; set; }
        public string? ErrorMessage { get; set; }
        public MigrantsStatements MigrantsStatements { get; set; }
    }
}
