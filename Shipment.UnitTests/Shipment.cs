using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shipment.Application.Services;
using Shipment.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace Shipment.UnitTests
{
    [TestClass]
    public class Shipment
    {
        [TestMethod]
        public void Book_WithValidAmount_ReturnTrue()
        {
            // arrange
            ShipmentService shipmentService = new ShipmentService();
            ShipmentRequest shipmentRequest = new ShipmentRequest()
            {
                UserId = 1,
                PickupAddress = new Domain.Models.PickupAddress { Latitude = 95, Longitude = 65 },
                DestinationAddres = new Domain.Models.DestinationAddres { Longitude = 10, Latitude = 63 },
                Budget = 20
            };
            // Act
            var result = shipmentService.Book(shipmentRequest);
            // assert
            Assert.IsTrue(Convert.ToBoolean(result));
        }


        [TestMethod]
        public void Approve_WithValidShipment_ReturnTrue()
        {
            // arrangee
            ShipmentService shipmentService = new ShipmentService();
            // Act
            var result = shipmentService.Approve(1);
            // assert
            Assert.IsTrue(Convert.ToBoolean(result));
        }


        [TestMethod]
        public void Reject_WithNotExitsShipment_ReturnFalse()
        {
            // arrangee
            ShipmentService shipmentService = new ShipmentService();
            // Act
            var result = shipmentService.Approve(100);
            // assert
            Assert.IsFalse(Convert.ToBoolean(result));
        }


        [TestMethod]
        public void CreateOffer_WithValidShipment_ReturnTrue()
        {
            // arrangee
            ShipmentService shipmentService = new ShipmentService();
            ShipmentRequest shipmentRequest = new ShipmentRequest()
            {
                UserId = 1,
                PickupAddress = new Domain.Models.PickupAddress { Latitude = 95, Longitude = 65 },
                DestinationAddres = new Domain.Models.DestinationAddres { Longitude = 10, Latitude = 63 },
                Budget = 20
            };
            // Act
            var result = shipmentService.CreateOffer(shipmentRequest);
            // assert
            Assert.IsNotNull(result);
        }

    }
}
