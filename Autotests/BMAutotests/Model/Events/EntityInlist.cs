using System.Collections.Generic;

namespace BMAutotests.Model
{
    public class EntityInlist
    {
        public string Date;
        public string Time;
        public string Tag;
        public string TypeEvent;
        public string NameCase;
        public string Status;
        public string Initials;
        public List<Activity> Activities = new List<Activity>();
        public List <string> Presets = new List<string>();
        public override string ToString()
        {
            return "Название дела = " + NameCase + ", Тип события = " + TypeEvent;
        }
    }
}
