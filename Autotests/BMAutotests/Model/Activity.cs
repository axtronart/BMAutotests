namespace BMAutotests.Model
{
    public class Activity
    {
        public string EntityName;
        public string EntityTag;
        public string Type;
        public string Date;
        public string Time;
        public string TimeLog;
        public override string ToString()
        {
            return "Сущность = " + EntityName + ", название таймлога = " + Type;
        }
    }
}
