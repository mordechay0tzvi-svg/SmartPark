using SmartPark.Parkings;
namespace SmartPark.interfaces
{
    interface IOrderable
    {
        void OrderSpot();
    }

    interface IPayment
    {
        void Pay(GeneralPark park);
    }

    class CreditCardPayment : IPayment
    {
        string Pay(GeneralPark parking)
        {
            return $"{parking.Calculate}; paid by credit card";
        }
    }
    class CashPayment : IPayment
    {
        void Pay(GeneralPark parking)
        {
            return $"{parking.Calculate}; paid in cash";
        }
    }

    interface IRecordable
    {
        string Record(GeneralPark parking);
    }
    class RecordPark : IRecordable
    {
        string Record(GeneralPark parking)
        {
            return $"{parking.entry} | {parking.exit} | {parking.Calculate()}";
        }
    }
    class RecordError : IRecordable
    {
        string Record(GeneralPark parking)
        {
            return $"Error with exit time with parking enterd at: {parking.entry}";
        }
    }
}
