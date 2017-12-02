
namespace BMAutotests.Model
{
    public class Event
    {
        public string NameCase;
        public string TypeEvent;
        public string Date;
        public string Time;
        //public string TimeSpent;
        public string Description;
        public override string ToString()
        {
            return "Название дела = " + NameCase + ", Тип события = " + TypeEvent;
        }
    }
}
