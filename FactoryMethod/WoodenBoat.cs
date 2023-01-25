using System;
namespace FactoryMethod
{
	public class WoodenBoat : Boat, ITransport
	{
        new public string TransportName { get => new WoodenBoat().GetType().Name; }

        new public string DeliveryMethod()
        {
            return String.Format("Едем на {0} , смотмость {1} руб", TransportName, base.boatLogistics.GetShipmentCost() + OwnCost);
        }
    }
}

