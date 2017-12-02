
namespace BMAutotests.Model.Billing
{
    public class PaymentRecord
    {
        public string Date;//Дата
        public string Source;//Источник
        public string Destination;//Счет
        public string Amount;//Сумма
        public string BalanceDue;//Остаток
        public string TotalPaid;//Оплачено
        
        public override string ToString()
        {
            return "Источник = " + Source + ", Счет = " + Destination;
        }
    }
}
