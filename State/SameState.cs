using System;
namespace State
{
}
//{
//    enum MaterialState { SOLID, LIQUID, GAS }

//    class Water
//    {
//        public MaterialState State { get; set; }

//        public Water(MaterialState waterState)
//        {
//            State = waterState;
//        }

//        public void Heat()
//        {
//            if (State == MaterialState.SOLID)
//            {
//                Console.WriteLine("Превращаем лед в жидкость");
//                State = MaterialState.LIQUID;
//            }
//            else if (State == MaterialState.LIQUID)
//            {
//                Console.WriteLine("Превращаем жидкость в пар");
//                State = MaterialState.GAS;
//            }
//            else if (State == MaterialState.GAS)
//            {
//                Console.WriteLine("Повышаем температуру водяного пара");
//            }
//        }
//        public void Frost()
//        {
//            if (State == MaterialState.LIQUID)
//            {
//                Console.WriteLine("Превращаем жидкость в лед");
//                State = MaterialState.SOLID;
//            }
//            else if (State == MaterialState.GAS)
//            {
//                Console.WriteLine("Превращаем водяной пар в жидкость");
//                State = MaterialState.LIQUID;
//            }
//        }
//        public string CurrentState()
//        {
//            return State.ToString();
//        }
//    }
//}

