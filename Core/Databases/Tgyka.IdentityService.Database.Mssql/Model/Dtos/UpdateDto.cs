namespace Tgyka.IdentityService.Database.Mssql.Model.Dtos
{
    public class UpdateDto
    {
        public int Id { get; set; }
        public DateTime? ModifiedDate => DateTime.UtcNow;
        public int? ModifiedBy {  get; set; }
    }
}
