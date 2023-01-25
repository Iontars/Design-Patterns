using System;
namespace FactoryMethod
{
	public class Boat : ITransport
	{
		protected BoatLogistics boatLogistics = new();

        public virtual string TransportName { get => new Boat().GetType().Name; }

        uint _ownCost = 300;
        public uint OwnCost { get => _ownCost; set => MathF.Abs(_ownCost = value); }

        public string DeliveryMethod()
        {
            return String.Format("Едем на {0} , смотмость {1} руб", TransportName, boatLogistics.GetShipmentCost() + OwnCost);
        }
	}
}

