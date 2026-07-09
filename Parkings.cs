using SmartPark.interfaces;
namespace SmartPark.Parkings
{
    abstract class GeneralPark 
    {
        DateTime entry;
        DateTime exit;
        public bool spotSaved = false;
        public bool inside = false;
        
        public void Enter ()
        {
            entry = DateTime.Now;
            inside = true;
        }

        public void Exit ()
        {
            exit = DateTime.Now;
            if (exit < entry)
            {
                throw new InvalidExitTime();
            }
            spotSaved = false; 
            inside = false;
        }
        public abstract int Calculate();
    }
 
    class RegularCarPark : GeneralPark, IOrderable
    {
        RegularCarPark():base(entry, exit, spotSaved){}
        public override int Calculate()
        {
            return 15 * (exit.Hour - entry.Hour);   
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
            return 5 * (exit.Hour - entry.Hour);
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
            return 8 * (exit.Hour - entry.Hour);
        }
    }

    class InvalidExitTime : Exception() {}    
}
