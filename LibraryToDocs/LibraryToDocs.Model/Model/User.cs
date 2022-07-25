namespace LibraryToDocs.Model
{
    public class User : BaseModel
    {
        public Guid IdUser { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Password == user.Password;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Password);
        }
    }
}
