
namespace BMAutotests.Model
{
    public class Document
    {
        public string NameCase; 
        public string Type;
        public string Time;
        public string Name;
        public string FileName;
        public string Date;
        public override string ToString()
        {
            return "Название дела = " + NameCase + ", название документа = " + Name;
        }
    }
}
