using System;
namespace BMAutotests.Model
{
    public class Noty
    {
        public string Type;
        public string Header;
        public string Body;
        public string ShortId;

        public override string ToString()
        {
            return String.Format("Type = {0}, Header = {1}, Body = {2}, ShortId = {3}", Type, Header, Body, ShortId);
        }
    }
}
