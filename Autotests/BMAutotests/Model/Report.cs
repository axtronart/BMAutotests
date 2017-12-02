
using System.Collections.Generic;
namespace BMAutotests.Model
{
    public class Report
    {
        public string Name;
        public string Description;
        public List<string> Colonels;
        public List<string> ColonelsNames = new List<string>();
        public List<string> ColonelsFormats = new List<string>();
        public List<string> ColonelsFilters = new List<string>();
        public List<string> ColonelsFiltersValues = new List<string>();

        public override string ToString()
        {
            return "Название отчета = " + Name + ", Описание = " + Description;
        }
    }
}
