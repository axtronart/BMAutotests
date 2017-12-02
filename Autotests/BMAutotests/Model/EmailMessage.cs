using System;
using System.Collections.Generic;
namespace BMAutotests.Model
{
    public class EmailMessage
    {
        public string subject;
        public string date;
        public string from;
        public string to;
        public string bcc;
        public string folder;
        public string type;
        public string contextTitle;
        public string contextMaintext;
        public string contextFooter;
        public string bestregards;
        public List<string> links = new List<string>();
        public object message;
        
        public override string ToString()
        {
            return "Тема = " + subject + ", дата = " + date + ", папка = " + folder;
        }
    }
}

