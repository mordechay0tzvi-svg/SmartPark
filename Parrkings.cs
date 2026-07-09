namespace SmartPark
{
    abstract class GeneralPark 
    {
        DateTime entry;
        DateTime exit;
        bool spotSaved = false;
        
        public void Enter ()
        {
            entry = DateTime.Now;
        }

        public void Exit ()
        {
            exit = DateTime.Now;
            if (exit < entry)
            {
                throw new InvalidExitTime();
            }
            spotSaved = false;    
        }
        
        abstract int Calculate();
    }
 
    class RegularCarPark : GeneralPark, IOrderable
    {
        RegularCarPark():base(entry, exit, spotSaved){}
        public override int Calculate()
        {
            return  (exit.Hour - entry.Hour) * 15;   
        }
        public void OrderSpot()
        {
            spotSaved = true;
        }
    }

    class HandicapPark : GeneralPark, IOrderable
    {
        HandicapPark():base(entry, exit,spotSaved){}
        public override int Calculate()
        {
            return  (exit.Hour - entry.Hour) * 5;
        }
        public void OrderSpot()
        {
            spotSaved = true;
        }
    }

    class BikePark : GeneralPark
    {
        BikePark():base(entry, exit){}
        public override int Calculate()
        {
            return  (exit.Hour - entry.Hour) * 8;
        }
    }

    class InvalidExitTime : Exception() {}
}