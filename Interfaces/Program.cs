namespace Interfaces
{
    class Rocket
    {
        public RocketHeader Header { get; set; }
        public IEngine Engine { get; set; } 

        public int Weight
        {
            get
            {
                return Header.GetWeight() + Engine.Weight;
            }
        }
    }

    class RocketHeader
    {
        public int Cosmonauts { get; set; }
        public int MassShell { get; set; }

        public RocketHeader(int humanCount, int mass)
        {
            Cosmonauts = humanCount;
            MassShell = mass;
        }

        public int GetWeight()
        {
            return (Cosmonauts * 80) + MassShell;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"Сообщение {message}  отправлено");
        }

    }

    interface IEngine
    {
        void Start();
        void Stop();
        int Weight { get; }
        int Power { get; }   

    }

    class HatersEngine : IEngine
    {
        public int Weight { get; }
        public int Power { get; }
        public string GetCop { get; }

        public HatersEngine(int weight, int power, string getCop)
        {
            Weight = weight;
            Power = power;
            GetCop = getCop;
        }

        public void Start()
        {
            Console.WriteLine("Старт");

        }

        public void Stop()
        {
            Console.WriteLine("Стоп");
        }

    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Rocket rocket = new Rocket();
            rocket.Header = new RocketHeader(3, 5000);
            rocket.Engine = new HatersEngine(322, 228, "Доступ получен");

            int result = CulcMethod(rocket.Engine.Power, rocket.Weight);
            Console.WriteLine("Максимальная скорость " + result );
            if (result > 200)
            {
                rocket.Engine.Start();
            }
            else
            {
                Console.WriteLine("Превышена максимальная мощность");
            }
            Console.ReadKey();

        }

        public static int CulcMethod(int power, int mass)
        {
            return (mass / power * 10) + 82;    
        }
    }
}