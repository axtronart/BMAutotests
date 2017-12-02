using System.Collections.Generic;

namespace BMAutotests.Model
{
    public class Project
    {
        public string Directories;
        public string Name;
        public string Description;
        public List<Meeting> СasesList = new List<Meeting>();
        public override string ToString()
        {
            return "Название = " + Name + ", описание = " + Directories;
        }
    }
}
