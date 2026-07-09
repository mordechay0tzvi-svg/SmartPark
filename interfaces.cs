namespace SmartPark
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
        void Record(GeneralPark parking);
    }
    class RecordPark : IRecordable
    {
        void Record(GeneralPark parking)
        {
             File.WriteAllText("records.txt" ,$"{parking.entry} | {parking.exit} | {parking.Calculate()}");
        }
    }
    class RecordExitError : IRecordable
    {
        void Record(GeneralPark parking)
        {
             File.WriteAllText("records.txt" ,$"Error with exit time with parking enterd at: {parking.entry}");
        }
    }

    class RecordCarExitingAttept : IRecordable
    {
        void Record(GeneralPark parking)
        {
             File.WriteAllText("records.txt" ,$"attempt to exit car that already exited at: {parking.exit}");
        }
    }
}
