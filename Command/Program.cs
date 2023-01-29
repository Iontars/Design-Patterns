using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;

namespace Command
{
    interface ICommand
    {
        void Execute();
        void Negative();
    }

    class Conveyor
    {
        public float powerStep = 5f;
        public float tempCurrentPower = default;
        public void On() => Console.WriteLine("Конвейер запущен");
        public void Off()
        {
            tempCurrentPower = default;
            Console.WriteLine("Конвейер остановлен");
        }
        public void SpeedIncrease() => Console.WriteLine("Увеличена скорость конвейера на " + powerStep + "%");
        public void SpeedDecrease() => Console.WriteLine("Снижена скорость конвейера на " + powerStep + "%");
    }

    class ConveyorWorkCommand : ICommand
    {
        private Conveyor _conveyor;
        public ConveyorWorkCommand(Conveyor conveyor) => this._conveyor = conveyor;
        public void Execute() => _conveyor.On();
        public void Negative() => _conveyor.Off();
    }

    class ConveyerAjustCommand : ICommand
    {
        private Conveyor _conveyor;
        public ConveyerAjustCommand(Conveyor conveyor) => this._conveyor = conveyor;
        public void Execute()
        {
            _conveyor.tempCurrentPower += _conveyor.powerStep;
            _conveyor.SpeedIncrease();
        }
        public void Negative() => _conveyor.SpeedDecrease();

    }

    class Multypult
    {
        public List<ICommand> commands;
        private Stack<ICommand> history;
        public Multypult()
        {
            commands = new List<ICommand>();
            history = new Stack<ICommand>();
        }

        public void SetCommand(int button, ICommand commmand)
        {
            commands.Add(item: null);
            commands[button] = commmand;
        }

        public void PressOn(int button)
        {
            commands[button].Execute();
            history.Push(commands[button]);
        }

        public void PressCancel()
        {
            if (history.Count != 0)
            {
                history.Pop().Negative();
            }
        }
    }

    class Program
    {
        public static readonly float nominalPower = 20f;
        static void Main(string[] args)
        {
            Conveyor conveyor = new();
            Multypult multypult = new();

            int countOfIterations = 0;
            multypult.SetCommand(0, new ConveyorWorkCommand(conveyor));
            multypult.PressOn(countOfIterations);
            Thread.Sleep(1000);
            while (conveyor.tempCurrentPower < nominalPower)
            {
                multypult.SetCommand(countOfIterations, new ConveyerAjustCommand(conveyor));
                Thread.Sleep(1000);
                multypult.PressOn(countOfIterations++);
            }

            Console.WriteLine("Nominal power");
            Console.WriteLine("is working");
            Thread.Sleep(3000);



        }
    }
}

