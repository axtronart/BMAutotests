namespace BMAutotests.Model
{
    public class Meeting
    {
        public string Number;
        public string Type;

        public override string ToString()
        {
            return "Заседание = " + Number + ", Тип = " + Type;
        }
    }
}
