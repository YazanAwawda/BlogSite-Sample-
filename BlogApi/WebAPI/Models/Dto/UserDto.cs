namespace WebAPI.Models.Dto
{
    public class UserDto
    {
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public bool admin { get; set; }
        public bool ban { get; set; }
    }
}
