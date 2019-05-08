using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class ShippingSnail : Snail, IShippingVehicle
    {
        public uint TopSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public uint MaxDistancePerRefuel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public uint MaxWeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ShippingSnail()
        {
            
        }
    }
}