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
            if (exit < entry)
            {
                throw new InvalidExitTime();
            }
        }
        
        abstract int Calculate();
    }
 
    class RegularCarPark : GeneralPark, IOrderable
    {
        RegularCarPark():base(entry, exit){}
        override int Calculate()
        {
            return  (exit.Hour - entry.Hour) * 15;   
        }
    }
    class HandicapPark : GeneralPark, IOrderable
    {
        HandicapPark():base(entry, exit){}
        override int Calculate()
        {
            return  (exit.Hour - entry.Hour) * 5;
        }
    }
    class BikePark : GeneralPark
    {
        BikePark():base(entry, exit){}
        override int Calculate()
        {
            return  (exit.Hour - entry.Hour) * 8;
        }
    }
    class InvalidExitTime : Exception(){}
}