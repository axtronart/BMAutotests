namespace BMAutotests.Model
{
    public class Case
    {
        public string CaseName;
        public string CaseType;
        public string CaseDescription;
        public bool CaseArchive = false;

        public override string ToString()
        {
            return "Название дела = " + CaseName + ", Тип дела = " + CaseType;
        }
    }
}
