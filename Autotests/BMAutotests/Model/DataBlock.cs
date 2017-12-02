
namespace BMAutotests.Model
{
    public class DataBlock
    {
        public string Name;
        public string Description;
        public string Multiblock;

        public override string ToString()
        {
            return "Название блока = " + Name + ", Описание блока = " + Description;
        }
    }
}
