using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;

namespace Command
{
    interface ICommand
    {
        void Positive();
        void Negative();
    }

    class Conveyor
    {
        public int powerStep = 5;
        public int tempCurrentPower = default;
        public void On() => Console.WriteLine("Конвейер запущен");
        public void Off()
        {
            tempCurrentPower = default;
            Console.WriteLine("Конвейер остановлен");
        }
        public void SpeedIncrease()
        {
            Console.WriteLine("Увеличена скорость конвейера на " + powerStep + "%");
            tempCurrentPower += powerStep;
        }
        public void SpeedDecrease()
        {
            Console.WriteLine("Снижена скорость конвейера на " + powerStep + "%");
            tempCurrentPower -= powerStep;
        }
    }

    internal class ConveyorWorkCommand : ICommand
    {
        private Conveyor _conveyor;
        public ConveyorWorkCommand(Conveyor conveyor) => this._conveyor = conveyor;
        public void Positive() => _conveyor.On();
        public void Negative() => _conveyor.Off();
    }

    class ConveyerAjustCommand : ICommand
    {
        private Conveyor _conveyor;
        public ConveyerAjustCommand(Conveyor conveyor) => this._conveyor = conveyor;
        public void Positive()
        {
            _conveyor.SpeedIncrease();
        }
        public void Negative() => _conveyor.SpeedDecrease();

    }

    class Multipult
    {
        public List<ICommand> commands;
        public Stack<ICommand> history;
        public Multipult()
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
            commands[button].Positive();
            history.Push(commands[button]);
        }

        public void PressOff(int button)
        {
            commands[button].Negative();
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

    internal class DelayClass
    {
        public void Delay(float value) => Thread.Sleep((int)(value * 1000));
    }


    static class Program
    {
        static int nominalPower;
        static int scopeWork;
        readonly static uint _nominalPower_MAX = 100;
        readonly static uint _scopeWork_MAX = 1000;

        static void Main(string[] args)
        {
            Conveyor conveyor = new();
            Multipult multipult = new();
            DelayClass delayClass = new();

            do
            {
                Console.WriteLine("Задайте мощность конвейера");
                Int32.TryParse((Console.ReadLine()), out nominalPower);
            }
            while (nominalPower <= uint.MinValue || nominalPower > _nominalPower_MAX);

            do
            {
                Console.WriteLine("Задайте объём работ");
                Int32.TryParse((Console.ReadLine()), out scopeWork);
            }
            while (scopeWork <= uint.MinValue || scopeWork > _scopeWork_MAX);

            Console.WriteLine("Установлена мощность конвейера: " + nominalPower);

            int countOfIterations = 0;
            multipult.SetCommand(countOfIterations, new ConveyorWorkCommand(conveyor));
            multipult.PressOn(countOfIterations);
            delayClass.Delay(1);
            while (conveyor.tempCurrentPower < nominalPower)
            {
                multipult.SetCommand(countOfIterations, new ConveyerAjustCommand(conveyor));
                delayClass.Delay(1);
                multipult.PressOn(countOfIterations++);
            }

            Console.WriteLine("Мощность достигнута");
            delayClass.Delay(1);
            Console.WriteLine("В процессе...");
            delayClass.Delay(3);
            Console.WriteLine("Предстоящий объём работ" + scopeWork);

            while (scopeWork > 0 )
            {
                delayClass.Delay(1);
                scopeWork -= nominalPower;
                if (scopeWork > 0)
                {
                    Console.WriteLine("Оставшийся объём работ: " + scopeWork);
                }
                else
                {
                    Console.WriteLine("Оставшийся объём работ: " + uint.MinValue);
                }
            }

            Console.WriteLine("Остановка конвейера...");
            delayClass.Delay(1);

            while (conveyor.tempCurrentPower > 0)
            {
                multipult.SetCommand(countOfIterations, new ConveyerAjustCommand(conveyor));
                delayClass.Delay(1);
                multipult.PressOff(countOfIterations++);
            }

            multipult.SetCommand(countOfIterations, new ConveyorWorkCommand(conveyor));
            delayClass.Delay(1);
            multipult.PressOff(countOfIterations);

            multipult.commands.Clear();
            Console.WriteLine("Очередь задач очищена: " + multipult.commands.Count);
            Console.WriteLine("История задач составляет: " + multipult.history.Count);
        }
    }
}

