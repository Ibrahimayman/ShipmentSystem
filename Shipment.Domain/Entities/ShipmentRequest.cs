using Shipment.Domain.Common;
using Shipment.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Domain.Entities
{
    public class ShipmentRequest : BaseDomainEntity
    {
        public PickupAddress PickupAddress { get; set; }

        public DestinationAddres DestinationAddres { get; set; }

        public decimal Budget { get; set; }

        public string AdditionalInfo { get; set; }

        public bool IsBooked { get; set; } = false;

        public ShipmentStatus Status { get; set; }

        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
    }
}
