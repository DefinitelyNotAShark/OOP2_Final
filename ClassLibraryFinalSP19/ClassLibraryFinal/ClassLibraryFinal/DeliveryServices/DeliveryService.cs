using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public abstract class DeliveryService : IDeliveryService
    {
        protected double costPerRefuel;
        protected IShippingVehicle shippingVehicle;

        public double CostPerRefuel { get { return costPerRefuel; } set { costPerRefuel = value; } }
        public IShippingVehicle ShippingVehicle { get { return shippingVehicle; } set { shippingVehicle = value; } }

        public DeliveryService(IShippingVehicle vehicle)
        {
            this.ShippingVehicle = vehicle;          
        }
    }   
}