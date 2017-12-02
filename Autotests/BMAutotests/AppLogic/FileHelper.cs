using BMAutotests.Model;
using BMAutotests.Model.Billing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BMAutotests.AppLogic
{
    public class FileHelper
    {
        public static string getTempPath()
        {
            string tempPath = typeof(FileHelper).Assembly.Location;
            return Path.GetDirectoryName(tempPath);
        }

        public static IEnumerable<User> user()
        {
            return JsonConvert.DeserializeObject<List<User>>(
                File.ReadAllText(getTempPath() + @"\data\user.json"));
        }
        public static IEnumerable<User> loginincorrect()
        {
            return JsonConvert.DeserializeObject<List<User>>(
                File.ReadAllText(getTempPath() + @"\data\login\loginincorrect.json"));
        }
        public static IEnumerable<User> logincorrect()
        {
            return JsonConvert.DeserializeObject<List<User>>(
                File.ReadAllText(getTempPath() + @"\data\login\logincorrect.json"));
        }
        public static IEnumerable<Meeting> meetings()
        {
            return JsonConvert.DeserializeObject<List<Meeting>>(
                File.ReadAllText(getTempPath() + @"\data\meeting\meetings.json"));
        }
        public static IEnumerable<EmailMessage> emails()
        {
            return JsonConvert.DeserializeObject<List<EmailMessage>>(
                File.ReadAllText(getTempPath() + @"\data\email\emails.json"));
        }
        public static IEnumerable<EmailMessage> welcomeemails()
        {
            return JsonConvert.DeserializeObject<List<EmailMessage>>(
                File.ReadAllText(getTempPath() + @"\data\email\welcomeemails.json"));
        }


        /*
        public static IEnumerable<SimpleString> directoriesname()
        {
            return JsonConvert.DeserializeObject<List<SimpleString>>(
               File.ReadAllText(getTempPath() + @"\data\knowledgebase\directoriesname.json"));

        }
        
        public static IEnumerable<Project> projects()
        {
            return JsonConvert.DeserializeObject<List<Project>>(
                File.ReadAllText(getTempPath() + @"\data\project\project.json"));
        }
        public static IEnumerable<Project> editprojects()
        {
            return JsonConvert.DeserializeObject<List<Project>>(
                File.ReadAllText(getTempPath() + @"\data\project\editproject.json"));
        }
        public static IEnumerable<Project> eventprojects()
        {
            return JsonConvert.DeserializeObject<List<Project>>(
                File.ReadAllText(getTempPath() + @"\data\event\eventproject.json"));
        }
        public static IEnumerable<Document> documents()
        {
            return JsonConvert.DeserializeObject<List<Document>>(
                File.ReadAllText(getTempPath() + @"\data\document\document.json"));
        }
        public static IEnumerable<Document> eventdocuments()
        {
            return JsonConvert.DeserializeObject<List<Document>>(
                File.ReadAllText(getTempPath() + @"\data\event\eventdocument.json"));
        }
        public static IEnumerable<Filter> filterdocuments()
        {
            return JsonConvert.DeserializeObject<List<Filter>>(
                File.ReadAllText(getTempPath() + @"\data\filters\documentfilters.json"));
        }
        public static IEnumerable<Filter> filterprojects()
        {
            return JsonConvert.DeserializeObject<List<Filter>>(
                File.ReadAllText(getTempPath() + @"\data\filters\projectfilters.json"));
        }
        public static IEnumerable<Filter> filterevents()
        {
            return JsonConvert.DeserializeObject<List<Filter>>(
                File.ReadAllText(getTempPath() + @"\data\filters\eventfilters.json"));
        }
        public static IEnumerable<Filter> sortevents()
        {
            return JsonConvert.DeserializeObject<List<Filter>>(
                File.ReadAllText(getTempPath() + @"\data\filters\eventsort.json"));
        }
        public static IEnumerable<DataBlock> datablocks()
        {
            return JsonConvert.DeserializeObject<List<DataBlock>>(
                File.ReadAllText(getTempPath() + @"\data\datablock\datablock.json"));
        }
        public static IEnumerable<Report> reports()
        {
            return JsonConvert.DeserializeObject<List<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\reports.json"));
        }
        public static IEnumerable<Individual> individuals()
        {
            return JsonConvert.DeserializeObject<List<Individual>>(
                File.ReadAllText(getTempPath() + @"\data\participants\individual.json"));
        }
        public static string getfileByName(string name)
        {
            return "C:\\filesforload\\" + name;
        }

        public static IEnumerable<Task> tasks()
        {
            return JsonConvert.DeserializeObject<List<Task>>(
                File.ReadAllText(getTempPath() + @"\data\task\task.json"));
        }

        public static IEnumerable<Task> subtasks()
        {
            return JsonConvert.DeserializeObject<List<Task>>(
                File.ReadAllText(getTempPath() + @"\data\task\subTask.json"));
        }

        public static IEnumerable<Event> events()
        {
            return JsonConvert.DeserializeObject<List<Event>>(
                File.ReadAllText(getTempPath() + @"\data\event\event.json"));
        }
        public static IEnumerable<Event> editevents()
        {
            return JsonConvert.DeserializeObject<List<Event>>(
                File.ReadAllText(getTempPath() + @"\data\event\editEvent.json"));
        }

        public static List<Dictionary> dictionariesValues()
        {
            return JsonConvert.DeserializeObject<List<Dictionary>>(
                File.ReadAllText(getTempPath() + @"\data\dictionaries\dictionariesValues.json"));
        }
        public static List<string> dictionaries()
        {
            return JsonConvert.DeserializeObject<List<string>>(
                File.ReadAllText(getTempPath() + @"\data\dictionaries\dictionaries.json"));
        }
        public static List<Dictionary> addDictionaries()
        {
            return JsonConvert.DeserializeObject<List<Dictionary>>(
                File.ReadAllText(getTempPath() + @"\data\dictionaries\addDictionaries.json"));
        }
        public static IEnumerable<Automation> automations()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Automation>>(
                File.ReadAllText(getTempPath() + @"\data\automation\automation.json"));
        }

        public static IEnumerable<Meeting> cases()
        {
            return JsonConvert.DeserializeObject<List<Meeting>>(
                File.ReadAllText(getTempPath() + @"\data\case\cases.json"));
        }

        public static List<SimpleString> findprojects()
        {
            return JsonConvert.DeserializeObject<List<SimpleString>>(
                File.ReadAllText(getTempPath() + @"\data\project\findstring.json"));
        }

        public static IEnumerable<Report> reportSorting()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\reportSorting.json"));
        }

        public static IEnumerable<Organization> organizations()
        {
            return JsonConvert.DeserializeObject<List<Organization>>(
                File.ReadAllText(getTempPath() + @"\data\participants\organization.json"));
        }

        public static List<Filter> filterparticipants()
        {
            return JsonConvert.DeserializeObject<List<Filter>>(
                File.ReadAllText(getTempPath() + @"\data\filters\participantfilter.json"));
        }

        public static List<Noty> notys()
        {
            return JsonConvert.DeserializeObject<List<Noty>>(
                File.ReadAllText(getTempPath() + @"\data\noty\notys.json"));
        }

        public static IEnumerable<Report> differentRootReports()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\differentRootReports.json"));
        }

        public static IEnumerable<Report> reportsWithCaseLinks()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\reportsWithCaseLinks.json"));
        }

        public static IEnumerable<Report> reportsWithReplaceableColumns()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\reportsWithReplaceableColumns.json"));
        }

        public static List<SearchString> searchparticipants()
        {
            return JsonConvert.DeserializeObject<List<SearchString>>(
                File.ReadAllText(getTempPath() + @"\data\participants\searchparticipants.json"));
        }

        public static IEnumerable<Report> reportDownload()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\reportDownload.json"));
        }

        public static IEnumerable<Report> systemReportDownload()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\systemReportDownload.json"));
        }

        public static IEnumerable<Report> reportsEdit()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Report>>(
                File.ReadAllText(getTempPath() + @"\data\report\reportsEdit.json"));
        }

        public static IEnumerable<Meeting> casesArchive()
        {
            return JsonConvert.DeserializeObject<List<Meeting>>(
                File.ReadAllText(getTempPath() + @"\data\case\casesArchive.json"));
        }
        public static IEnumerable<ReportData> reportsData()
        {
            return JsonConvert.DeserializeObject<IEnumerable<ReportData>>(
                File.ReadAllText(getTempPath() + @"\data\report\reportsData.json"));
        }
        public static IEnumerable<Profile> profile()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Profile>>(
                File.ReadAllText(getTempPath() + @"\data\profile\profile.json"));
        }
        public static IEnumerable<Profile> profilevalidation()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Profile>>(
                File.ReadAllText(getTempPath() + @"\data\profile\passwordincorrect.json"));
        }
        public static IEnumerable<Profile> currentpasswordvalidation()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Profile>>(
                File.ReadAllText(getTempPath() + @"\data\profile\currentpasswordincorrect.json"));
        }
        
        
        public static IEnumerable<Task> taskforemail()
        {
            return JsonConvert.DeserializeObject<List<Task>>(
                File.ReadAllText(getTempPath() + @"\data\task\taskforemail.json"));
        }
        public static IEnumerable<Task> taskforemailnotsend()
        {
            return JsonConvert.DeserializeObject<List<Task>>(
                File.ReadAllText(getTempPath() + @"\data\task\taskforemailnotsend.json"));
        }
        public static IEnumerable<SimpleString> taskstates()
        {
            return JsonConvert.DeserializeObject<List<SimpleString>>(
                File.ReadAllText(getTempPath() + @"\data\task\taskstates.json"));
        }
        public static IEnumerable<SimpleString> taskpriority()
        {
            return JsonConvert.DeserializeObject<List<SimpleString>>(
                File.ReadAllText(getTempPath() + @"\data\task\taskpriority.json"));
        }
        public static IEnumerable<Expense> expense()
        {
            return JsonConvert.DeserializeObject<List<Expense>>(
                File.ReadAllText(getTempPath() + @"\data\billing\expense.json"));
        }
        public static IEnumerable<Meeting> casesNotArchive()
        {
            return JsonConvert.DeserializeObject<List<Meeting>>(
                File.ReadAllText(getTempPath() + @"\data\case\casesNotArchive.json"));
        }

        public static List<EntityInlist> activity()
        {
            return JsonConvert.DeserializeObject<List<EntityInlist>>(
                File.ReadAllText(getTempPath() + @"\data\timing\timings.json"));
        }

        public static List<EntityInlist> activityWPreset()
        {
            return JsonConvert.DeserializeObject<List<EntityInlist>>(
                File.ReadAllText(getTempPath() + @"\data\timing\timingPresets.json"));
        }

        public static List<EntityInlist> editActivity()
        {
            return JsonConvert.DeserializeObject<List<EntityInlist>>(
                File.ReadAllText(getTempPath() + @"\data\timing\editTimings.json"));
        }

        public static IEnumerable<PaymentRecord> paymentrecord()
        {
            return JsonConvert.DeserializeObject<List<PaymentRecord>>(
                File.ReadAllText(getTempPath() + @"\data\billing\paymentrecord.json"));
        }
        public static List<Invoice> invoice()
        {
            return JsonConvert.DeserializeObject<List<Invoice>>(
                File.ReadAllText(getTempPath() + @"\data\billing\invoice.json"));
        }*/
    }
}
