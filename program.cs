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
    class Program
    {
        Park parking = new Park();
        static GeneralPark NewParking(string choice)
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
                    return new RegularCarPark();
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Start parking");
            Console.WriteLine("2. Finish parking:");
        }
        static void StartParking()
        {
            Console.WriteLine("Choose type to park (regular is default):");
            Console.WriteLine("1. Regular for 15 an hour");
            Console.WriteLine("2. Handicap for 5 an hour");
            Console.WriteLine("3. Motorcycle for 8 an hour");
            string choice = Console.ReadLine();
            GeneralPark newPark = NewParking(choice);
            parking.AddPark(newPark);
            Console.WriteLine($"Parked succesfully. your parking number is {parking.GetParkNumber()}");
        }
        static void OrderSpot(GeneralPark toSave)
        {
            toSave.OrderSpot();
            Console.WriteLine("Parking spot orderd");
        }
        static void EndParking()
        {
            bool exiting = false;
            while (!exiting)
            {
                Console.WriteLine("Enter parking number:");
                int choice = Console.ReadLine();
                try
                {
                    GeneralPark toExit = parking.GetPark(coice);
                    try
                    {
                        toExit.Exit();
                        PayForParking(toExit);
                        RecordPark.Record(toExit);
                        exiting = true; 
                    }
                    catch (InvalidExitTime)
                    {
                        Console.WriteLine("Error with time");
                        RecordExitError.Record(toExit);
                        exiting = true; 
                    }
                    catch (InvalidExiting)
                    {
                        Console.WriteLine("Car already out");
                        RecordCarExitingAttept(toExit);
                        exiting = true; 
                    }
                }
                catch (EmptyParking)
                {
                    Console.WriteLine("empty lot");
                    continue;
                }
            }
        }
        static void PayForParking(GeneralPark toPay)
        {
            IPayment payMethod; 
            Console.WriteLine("Choose payment method (cash is default):");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit card");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    payMethod = new CashPayment();
                    break;
                case "2":
                    payMethod = new CreditCardPayment();
                    break;
                default:
                    payMethod = new CashPayment();
                    break;
            }
            Console.WriteLine(payMethod.Pay());
        }
        static void Main()
        {
            bool working = true;
            while(working)
            {
                Console.WriteLine("Welcome to our parking garage.");
                PrintMenu();
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        StartParking();
                    case "2":
                        EndParking();
                    default:
                        working = false;
                }
            }
        }
    }
}
