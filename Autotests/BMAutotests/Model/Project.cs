using System.Collections.Generic;

namespace BMAutotests.Model
{
    public class Project
    {
        public string Directories;
        public string Name;
        public string Description;
        public List<Case> СasesList = new List<Case>();
        public override string ToString()
        {
            return "Название = " + Name + ", описание = " + Directories;
        }
    }
}
