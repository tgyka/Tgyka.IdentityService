namespace Tgyka.IdentityService.Database.Mssql.Model.Dtos
{
    public class CreateDto
    {
        public DateTime CreatedDate => DateTime.UtcNow;
        public int CreatedBy { get; set; }
    }
}
