using System;
using System.Diagnostics;

namespace FactoryMethod
{
    public class BaseLogistics
	{
		public ITransport CreateTransport(ITransport transport)
		{
			return transport as ITransport;
		}

        int _shipmentBaseCost = 10;
        public virtual int ShipmentBaseCost { get => _shipmentBaseCost; }

        public virtual int GetShipmentCost()
        {           
            return ShipmentBaseCost;
        }
    }
}

