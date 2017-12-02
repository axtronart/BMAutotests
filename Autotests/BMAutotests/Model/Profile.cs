
namespace BMAutotests.Model
{
    public class Profile
    {
        public string Name;
        public string Patronimic;
        public string LastName;
        public string Initials;
        public string Company;
        public string Position;
        public string Site;
        public string Email;
        public string Phone;
        public string Department;
        public string Timezone;
        public string CurrentPassword;
        public string NewPassword;
        public string PasswordAgain;
        public string Message;

        public override string ToString()
        {
            return "Имя = " + Name + ", Логин = " + Email + ", Ошибка = " + Message + "Новый пароль" + NewPassword;
        }
    }
}
