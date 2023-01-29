using System;

namespace Command
{
    interface ICommand
    {
        void Positive();
        void Negative();
    }

    class Conveyor
    {
        public void On() => Console.WriteLine("Конвейер запущен");
        public void Off() => Console.WriteLine("Конвейер остановлен");
        public void SpeedIncrease() => Console.WriteLine("Увеличена скорость конвейера");
        public void SpeedDecrease() => Console.WriteLine("Снижена скорость конвейера");
    }

    class ConveyorWorkCommand : ICommand
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
        public void Positive() => _conveyor.SpeedIncrease();
        public void Negative() => _conveyor.SpeedDecrease();

    }

    class Multypult
    {
        private List<ICommand> commands;
        private Stack<ICommand> history;
        public Multypult()
        {
            commands = new List<ICommand> { null, null };
            history = new Stack<ICommand>();
        }

        public void SetCommand(int button, ICommand commmand)
        {
            commands[button] = commmand;
        }

        public void PressOn(int button)
        {
            commands[button].Positive();
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
        static void Main(string[] args)
        {
            Conveyor conveyor = new();
            Multypult multypult = new();

            multypult.SetCommand(0, new ConveyorWorkCommand(conveyor));
            multypult.SetCommand(1, new ConveyerAjustCommand(conveyor));

            multypult.PressOn(0);
            multypult.PressOn(1);
            multypult.PressCancel();
            multypult.PressCancel();
        }
    }
}

