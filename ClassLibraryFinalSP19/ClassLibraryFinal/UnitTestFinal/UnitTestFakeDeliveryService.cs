using System;
using ClassLibraryFinal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestFinal
{
    [TestClass]
    public class UnitTestFakeDeliveryService
    {

        [TestMethod]
        public void TestFakeService()
        {
            var totallyRealCompany = new Mock<IShippingService>();
            var companyCar = new Mock<IShippingVehicle>();
            var companyDelivery = new Mock<IDeliveryService>();

            totallyRealCompany.Setup(s => s.DeliveryService.Equals(companyDelivery));
            totallyRealCompany.Setup(s => s.DeliveryService.ShippingVehicle.Equals(companyCar));

            totallyRealCompany.SetupGet(s => s.ShippingLocation.StartZipCode).Returns(63017);
            totallyRealCompany.SetupGet(s => s.ShippingLocation.DestinationZipCode).Returns(63151);
            totallyRealCompany.SetupGet(s => s.ShippingDistance).Returns(100);
            totallyRealCompany.SetupGet(s => s.NumRefuels).Returns(1);

            //Arrange
            uint numRefuels, shippingDistance, startZip, destZip;

            //Act
            numRefuels = 1;
            shippingDistance = 100;
            startZip = 63017;
            destZip = 63151;

            //Assert
            Assert.AreEqual(totallyRealCompany.Object.ShippingLocation.StartZipCode, startZip);
            Assert.AreEqual(totallyRealCompany.Object.ShippingLocation.DestinationZipCode, destZip);
            Assert.AreEqual(totallyRealCompany.Object.ShippingDistance, shippingDistance);
            Assert.AreEqual(totallyRealCompany.Object.NumRefuels, numRefuels);
        }

        [TestMethod]
        public void TestFakeDeliveryService()
        {
            var airTravel = new Mock<IShippingService>();//as a stand in for a quick fake "vehicle"
            var cannon = new Mock<IDeliveryService>();//v efficient shoot products at people via giant t-shirt cannon

            cannon.Setup(v => v.ShippingVehicle.Equals(airTravel.Object));//give it a delivery service 

            Assert.IsNotNull(cannon.Object);//make sure the cannon isn't null
            Assert.IsInstanceOfType(cannon.Object, typeof(IDeliveryService));//make sure the cannon is a delivery service
            Assert.IsNotNull(cannon.Object.ShippingVehicle);//make sure its shipping vehicle isn't null
        }

        [TestMethod]
        public void TestFakeVehicle()
        {
            var deliveryCrow = new Mock<IShippingVehicle>();//send products by crow. Impress your friends
           
            deliveryCrow.SetupGet(m => m.MaxDistancePerRefuel).Returns(120);//can travel roughly 120 miles before needing to rest
            deliveryCrow.SetupGet(s => s.TopSpeed).Returns(40);//about 4- mph
            deliveryCrow.SetupGet(w => w.MaxWeight).Returns(3);
            

            uint MaxDistance, MaxWeight, TopSpeed;

            MaxWeight = 3;
            MaxDistance = 120;
            TopSpeed = 40;

            Assert.IsInstanceOfType(deliveryCrow.Object, typeof(IShippingVehicle));
            Assert.AreEqual(deliveryCrow.Object.MaxDistancePerRefuel, MaxDistance);
            Assert.AreEqual(deliveryCrow.Object.TopSpeed, TopSpeed);
            Assert.AreEqual(deliveryCrow.Object.MaxWeight, MaxWeight);
        }
    }
}
