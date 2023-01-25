using System;
namespace FactoryMethod
{
	public class Truck : Car, ITransport
	{
        new public string TransportName { get => new Truck().GetType().Name; }

        uint _ownCost = 150;
        new public uint OwnCost { get => _ownCost; set => MathF.Abs(_ownCost = value); }

        new public string DeliveryMethod() =>
        String.Format("Едем на {0} , стоимость {1} руб",
        TransportName,(base.logistics.GetShipmentCost() + OwnCost));
        
	}
}

