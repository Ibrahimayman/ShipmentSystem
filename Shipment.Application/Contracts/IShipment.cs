using Shipment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Application.Contracts
{
    public interface IShipment
    {
        Task<bool> Book(ShipmentRequest shipmentRequest);

        Task<int> CreateOffer(ShipmentRequest shipmentRequest);

        Task<bool> Reject(int id);

        Task<bool> Approve(int id);
    }
}
