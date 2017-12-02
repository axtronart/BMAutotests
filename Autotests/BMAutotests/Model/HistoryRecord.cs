
using System.Collections.Generic;

namespace BMAutotests.Model
{
    public class HistoryRecord
    {
        public string TypeOfRecord;
        public string TypeOfEntity;
        public string Date;
        public string Time;
        public string Author;
        public override string ToString()
        {
            return "Тип записи = " + TypeOfRecord + ", Тип сущности = " + TypeOfEntity + ", дата = " + Date;
        }
    }
}
