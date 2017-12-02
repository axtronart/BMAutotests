
namespace BMAutotests.Model
{
    public class Filter
    {
        public string Default; 
        public string Type; 
        public string Clear; 
        public string Current;
        public string Field;

        // Если фильтруем участников, то по этому полю можем искать нужного участника
        // см. ParticipantFiltersTests
        public string ResultName;

        public override string ToString()
        {
            return "По умолчанию = " + Default + ", значение = " + Current;
        }
    }
}
