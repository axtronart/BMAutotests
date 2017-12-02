using System.Collections.Generic;
namespace BMAutotests.Model
{
    public class Dictionary
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
        public override string ToString()
        {
            return "Название = " + Name;
        }
    }
}
