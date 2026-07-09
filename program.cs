using System.Dynamic;

namespace SmartPark
{
    class Park
    {
        protected List<GeneralPark> parks {get; set;}
        Park()
        {
            parks = List<GeneralPark> new();
        }
        public List<GeneralPark> GetAll()
        {
            return parks;
        }
        public void AddPark(GeneralPark park)
        {
            park.Enter();
            parks.Add(park);
        }
        public GeneralPark GetPark(int number)
        {
            if (number > parks.Count)
                {   
                    throw new EmptyParking();
                }
            return parks[number];
        }
        public int GetParkNumber()
        {
            return parks.Count;
        }
    }
    class EmptyParking : Exception{}
    class program
    {
        Park parking = new Park();
        static GeneralPark? NewParking(string choice)
        {
            switch (choice)
            {
                case "1":
                return new RegularCarPark();
                case "2":
                return new HandicapPark();
                case "3":
                return new BikePark();
                default:
                return null;
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Start parking");
            Console.WriteLine("2. Finish parking:");
        }
        static void Start()
        {
            while (true)
            {
                Console.WriteLine("Choose type to park:");
                Console.WriteLine("1. Regular for 15 an hour");
                Console.WriteLine("2. Handicap for 5 an hour");
                Console.WriteLine("3. Motorcycle for 8 an hour");
                string choice = Console.ReadLine();
                GeneralPark? newPark = NewParking(choice);
                if (newPark == null)
                {
                    Console.WriteLine("Not a choice");
                    continue;
                } 
                Parking.AddPark(newPark);
                Console.WriteLine($"Parked succesfully. your parking number is {parking.Count}");
        }
        static void End()
        {
            while (true)
            {
                Console.WriteLine("Enter parking number:");
                int choice = Console.ReadLine();
                try
                {
                    GeneralPark toExit = parking.GetPark(coice);
                    try
                    {
                        toExit.Exit();
                    }
                    catch (InvalidExitTime)
                    {
                        Console.WriteLine("Error with time");
                    }
                    catch (InvalidExiting)
                    {
                        Console.WriteLine("Car already out");
                    }
                }
                catch (EmptyParking)
                {
                    Console.WriteLine("empty lot");
                    continue;
                }
            }
        }
        static void Main()
        {
            

        }
    }
}
