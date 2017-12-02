using System.Collections.Generic;
namespace BMAutotests.Model
{
    public class Participant
    {
        public string Name;
        public string PhoneNumber;
        public string Email;
        public string Site;
        public List<string> RoleInCase = new List<string>();
        public List<string> Case = new List<string>();
    }
}
