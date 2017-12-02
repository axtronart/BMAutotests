
namespace BMAutotests.Model
{
    public class Decision
    {
        public string Number;
        public string Type; 
        public string DateNote;
        public string NumberNote;
        public string Customer;
        public string SubjectAnalyses;
        public string Theme;
        public string Description;
        public string Category;

        public override string ToString()
        {
            return "Номер решения = " + Number + ", Тип решения = " + Type;
        }
    }
}
