namespace BMAutotests.Model
{
    public class Organization : Participant
    {

        public string INN;
        public string LegalForm;

        public override string ToString()
        {
            return "Организация = " + Name;
        }
    }
}
