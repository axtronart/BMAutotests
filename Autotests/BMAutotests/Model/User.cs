
namespace BMAutotests.Model
{
    public class User
    {
        public string login;
        public string password;
        public string role;
        public string email;
        public string domain;

        public override string ToString()
        {
            return "login= " + login + " роль= " + role + ", password= " + password + ", email= " + email;
        }
    }
}
