
namespace BMAutotests.Model.Billing
{
    public class Expense
    {
        public string Name;
        public string NameCase;
        public string Date;
        public string Sum;
        public string Description;
        public string Status;
        public string Initials;
        public override string ToString()
        {
            return "Название затраты = " + Name + ", Описание затрат = " + Description;
        }
    }
}
