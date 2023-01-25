using System;
namespace FactoryMethod
{
	public class TrainLogistics : BaseLogistics
	{
        int _shipmentBaseCost = 50;
        new public int ShipmentBaseCost { get => _shipmentBaseCost; }

        new public int GetShipmentCost()
        {
            return ShipmentBaseCost;
        }
    }
}

