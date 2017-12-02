
using System.Collections.Generic;

namespace BMAutotests.Model
{
    public class Task
    {
        public string NameCase;
        public string NameTask;
        public string Date;
        public string Time;
        public string Duration;
        public string States;
        public string Priority;
        public string ResponseUser;
        public string Description;
        public string Tag;
        public List<Task> SubTask = new List<Task>();
        public List<string> FileNames = new List<string>();
        public override string ToString()
        {
            return "Название дела = " + NameCase + ", название задачи = " + NameTask + ", дата = " + Date;
        }
    }
}
