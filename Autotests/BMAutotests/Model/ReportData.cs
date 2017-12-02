
using System.Collections.Generic;
namespace BMAutotests.Model
{
    public class ReportData
    {
        public string Name;
        public string TableName;
        public List<string> ColonelsNames = new List<string>();
        public List<string> FirstRow = new List<string>();

        public override string ToString()
        {
            return "Название отчета = " + Name + ", Описание = " + TableName;
        }
    }
}
