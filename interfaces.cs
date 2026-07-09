namespace SmartPark
{
    interface IOrderable
    {
        void OrderSpot(){}
    }

    interface IPayment
    {
        void Pay(){}
    }
    interface IRecordable
    {
        void RecordLine(){}
    }
}