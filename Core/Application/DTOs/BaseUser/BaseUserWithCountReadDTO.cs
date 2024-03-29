namespace BusStation_API.Core.Application.DTOs.BaseUser
{
    public class BaseUserWithCountReadDTO
    {
        public int CountAllUsers { get; set; }
        public int? CurrentNumOfUsers { get; set; }
        public List<BaseUserReadDTO> Users { get; set; }

        public BaseUserWithCountReadDTO(int countAllUsers, int? currentNumOfUsers, List<BaseUserReadDTO> users)
        {
            CountAllUsers = countAllUsers;
            CurrentNumOfUsers = currentNumOfUsers;
            Users = users;
        }
    }
}
