using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public abstract class DeliveryService : IDeliveryService
    {

        protected double costPerRefuel;

        public double CostPerRefuel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public IShippingVehicle ShippingVehicle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        protected IShippingVehicle shippingVehicle;

        public DeliveryService(IShippingVehicle vehicle)
        {
            
        }

    }

    
}