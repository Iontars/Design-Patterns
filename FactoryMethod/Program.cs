using System;

namespace FactoryMethod
{
    class Program
    {
        static BaseLogistics logistics = new();

        static void Main(string[] args)
        {
            string transportName;
            Console.WriteLine("Выбрать способ поездки \nset: boat, car, train, wooden boat or truck");
            // set: boat, car, train, wooden boat, truck
            transportName = Console.ReadLine() ?? "";
            Console.WriteLine(GetWay(ChooseTransport(transportName)));
        }

        public static string GetWay(ITransport transport) => logistics.CreateTransport(transport).DeliveryMethod();

        public static ITransport ChooseTransport(string value)
        {
            switch (value)
            {
                case "boat":
                    return new Boat();
                case "train":
                    return new Train();
                case "car":
                    return new Car();
                case "wooden boat":
                    return new WoodenBoat();
                case "truck":
                    return new Truck();
                default:
                    throw new Exception("нет транспорта");
            }
        }
    }
}

