namespace Arkitektur.WebUI.DTOs.UserDtos
{
    public class AssignRoleDto
    {
        public string? FullName { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }
    }
}
