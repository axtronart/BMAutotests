
namespace BMAutotests.Model.Billing
{
    public class Invoice
    {
        public string Client;
        public string Number;
        public string CreateOn;
        public string DueDate;
        public string Status;
        public string Discount;
        public string PrimaryTax;
        public string SecondaryTax;
        public string SecondaryTaxMode;
        public override string ToString()
        {
            return "Клиент = " + Client + ", Номер = " + Number;
        }
    }
}
