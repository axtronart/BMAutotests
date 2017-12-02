using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProAutotests.Pages
{
    class Strings
    {
        internal string uppercaseFirst(string s)
        {
            if (s != null)
                return s.First().ToString().ToUpper() + s.Substring(1);
            else
                return null;
        }

        internal string getTextWithoutSpace(string text)
        {
            if (text != null)
                return text.Replace(" ", "");
            else return null;
        }
    }
}
