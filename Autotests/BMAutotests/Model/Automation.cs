
namespace BMAutotests.Model
{
    public class Automation
    {
        public string Name;
        public string Description;

        public override string ToString()
        {
            return "Название автоматизации = " + Name + ", Описание = " + Description;
        }
    }
}
