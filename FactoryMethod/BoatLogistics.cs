using System;
namespace FactoryMethod
{
	public class BoatLogistics : BaseLogistics
    {
        int _shipmentBaseCost = 100;
        new public int ShipmentBaseCost { get => _shipmentBaseCost; }

        new public int GetShipmentCost()
        {
            return ShipmentBaseCost;
        }
    }
}

