namespace SmartPark
{
    interface IOrderable
    {
        void OrderSpot();
    }

    interface IPayment
    {
        void Pay();
    }

    class CreditCardPayment : IPayment
    {
        void Pay()
        {
            
        }
    }
    class CashPayment : IPayment
    {
        void Pay()
        {
            
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