using Shipment.Application.Contracts;
using Shipment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Application.Services
{
    public class ShipmentService : IShipment
    {
        List<ShipmentRequest> shipmentRequests = new List<ShipmentRequest>();
        public Task<bool> Approve(int id)
        {
            ShipmentRequest shipmentRequest = shipmentRequests.SingleOrDefault(x => x.Id == id);
            if (shipmentRequest == null) return Task.FromResult(false);
            shipmentRequest.Status = Domain.Models.ShipmentStatus.Accepted;
            return Task.FromResult(true);
        }

        public Task<bool> Book(ShipmentRequest shipmentRequest)
        {
            if (!shipmentRequest.IsBooked)
            {
                shipmentRequest.IsBooked = true;
                shipmentRequest.DateCreated = DateTime.Now;
                shipmentRequests.Add(shipmentRequest);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<int> CreateOffer(ShipmentRequest shipmentRequest)
        {
            shipmentRequest.DateCreated = DateTime.Now;
            shipmentRequests.Add(shipmentRequest);
            return Task.FromResult(shipmentRequest.Id);
        }

        public Task<bool> Reject(int id)
        {
            ShipmentRequest shipmentRequest = shipmentRequests.SingleOrDefault(x => x.Id == id);
            if(shipmentRequest == null) return Task.FromResult(false);
            shipmentRequest.Status = Domain.Models.ShipmentStatus.Rejected;
            return Task.FromResult(true);
        }
    }
}
