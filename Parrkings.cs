namespace SmartPark
{
    abstract class GeneralPark 
    {
        DateTime entry;
        DateTime exit;
        
        void Enter ()
        {
            entry = DateTime.Now;
        }

        void Exit ()
        {
            exit = DateTime.Now;
        }
        
        override int Calculate();
        IPayment Pay(GeneralPark park)
        {
            
        }
    }
 
    class RegularCarPark : GeneralPark, IOrderable
    {
        RegularCarPark():base(entry, exit){}
        override int Calculate()
        {
            
        }
    }
    class HandicapPark : GeneralPark, IOrderable
    {
        HandicapPark():base(entry, exit){}
        override int Calculate()
        {
            
        }
    }
    class BikePark : GeneralPark
    {
        BikePark():base(entry, exit){}
        override int Calculate()
        {
            
        }
    }
    class InvalidTime : Exception();

}