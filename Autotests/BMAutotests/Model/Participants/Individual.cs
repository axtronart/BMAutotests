namespace BMAutotests.Model
{
    public class Individual : Participant
    {
        public string Surname;
        public string MiddleName;
        public string Organization;
        public override string ToString()
        {
            return "ФИО = " + Surname + " " + Name + " " + MiddleName;
        }
    }
}
