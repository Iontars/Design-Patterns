using System;
namespace FactoryMethod
{
	public class Car : ITransport
	{
        protected BaseLogistics logistics = new();

        public virtual string TransportName { get => new Car().GetType().Name ;  }

        uint _ownCost = 100;
        public uint OwnCost { get => _ownCost; set => MathF.Abs(_ownCost = value); }

        public virtual string DeliveryMethod()
        {
            return String.Format("Едем на {0} , смотмость {1} руб", TransportName, logistics.GetShipmentCost() + OwnCost);
        }
	}
}

