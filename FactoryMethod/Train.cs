using System;
namespace FactoryMethod
{
	public class Train : ITransport
	{
		protected TrainLogistics trainLogistics = new();

        public virtual string TransportName { get => new Train().GetType().Name; }

        uint _ownCost = 500;
        public uint OwnCost { get => _ownCost; set => MathF.Abs(_ownCost = value); }

        public string DeliveryMethod()
		{
            return String.Format("Едем на {0} , смотмость {1} руб", TransportName, trainLogistics.GetShipmentCost() + OwnCost);
        }
    }
}

