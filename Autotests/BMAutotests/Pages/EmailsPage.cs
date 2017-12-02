using BMAutotests.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace BMAutotests.Pages
{
    public class EmailsPage
    {
        //все ссылки
        private string links = "//a";
        //CasePro
        private string linkCasePro = "//a[@class='link']";
        //Добро пожаловать в систему casepro
        private string title = "//*[contains(@style,'line-height: 1.26;')]";
        //кнопка посмотреть
        private string linkButton = "//a[@title='Посмотреть']";
        //Мы рады что вы присоединились к нам
        private string maintext = "//p";
        //вы получили это письмо
        private string footer = "//p[2]";
        //С уважением команда CasePro
        private string bestregards = "//p[3]";


        internal EmailMessage getContextEmailByType(EmailMessage EM)
        {
            if (EM.type == "Old")
            {
                return getContextOldEmail(EM);
            }else
            {
                return getContextEmail(EM);
            }
            
        }
        internal EmailMessage getContextEmail(EmailMessage EM)
        {
            Console.WriteLine("Новый тип письма"+ EM.type + EM.subject);
            HtmlDocument HT = new HtmlDocument();
            HT.LoadHtml(EM.message.ToString());
            //Получаем основной заголовок письма
            EM.contextTitle = getTextFromHtml(HT, title);
            //получаем основной текст письма
            EM.contextMaintext = getTextFromHtml(HT, maintext);
            //получаем футер
            EM.contextFooter = getTextFromHtmlWithoutSpace(getTextFromHtml(HT, footer));
            //получаем с уважением
            EM.bestregards = getTextFromHtmlWithoutSpace(getTextFromHtml(HT, bestregards));
            //получаем все ссылки в документе
            EM.links = getLinkList(HT, links);
            return EM;
        }
        internal EmailMessage getContextOldEmail(EmailMessage EM)
        {
            Console.WriteLine("Старое письмо" + EM.type + EM.subject);
            string oldLetter = "заглушка";
            //Получаем основной заголовок письма
            EM.contextTitle = oldLetter;
            //получаем основной текст письма
            EM.contextMaintext = oldLetter;
            //получаем футер
            EM.contextFooter = oldLetter;
            //получаем с уважением
            EM.bestregards = oldLetter;
            //получаем все ссылки в документе
            EM.links.Add(oldLetter);
            return EM;
        }
        internal string getTextFromHtml(HtmlDocument HT, string locator)
        {
            try
            {
                var contextMaintext = HT.DocumentNode.SelectSingleNode(locator);
                return contextMaintext.InnerText;
            }
            catch (Exception e)
            {
                return "ОШИБКА не могу увидеть текст" + e.Message;
            }

        }
        internal string getHref(HtmlDocument HT, string locator)
        {
            try
            {
                var contextMaintext = HT.DocumentNode.SelectSingleNode(locator);
                return contextMaintext.GetAttributeValue("href", "Нет ссылки");
            }
            catch (Exception e)
            {
                return "ОШИБКА, где моя ссылка" + e.Message;
            }
        }
        internal List<string> getLinkList(HtmlDocument HT, string locator)
        {
            List<string> list = new List<string>();
            foreach (var element in HT.DocumentNode.SelectNodes(locator))
            {
                list.Add(element.GetAttributeValue("href", "Нет ссылки"));
            }
            return list;
        }
        internal string getTextFromHtmlWithoutSpace(string text)
        {
            return new string(text.Where(v => (Char.IsLetterOrDigit(v) || Char.IsPunctuation(v))).ToArray());
            //return new string(text.Where(v => (Char.IsLetterOrDigit(v) || Char.IsWhiteSpace(v))).ToArray());
        }

    }
}
