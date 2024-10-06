namespace UrbanJungleRealty.Application.Dtos.RegisterDto
{
    public class RegisterRequestDto
    {
        public RegisterRequestDto(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
