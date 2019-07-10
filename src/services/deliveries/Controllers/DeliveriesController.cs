﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deliveries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace deliveries.Controllers
{
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveriesRepository _deliveriesRepository;

        public DeliveriesController(IDeliveriesRepository deliveriesRepository)
        {
            _deliveriesRepository = deliveriesRepository ?? throw new ArgumentNullException(nameof(deliveriesRepository));
        }

        [HttpGet("api/orders/{orderId:guid}/deliveries")]
        public async Task<IActionResult> GetOrderDeliveries([FromRoute]Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentException(nameof(orderId));
            }

            var deliveries = await _deliveriesRepository.GetOrderDeliveries(orderId);

            return Ok(deliveries);
        }

        [HttpGet("api/deliveries/{deliveryId:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid deliveryId)
        {
            if (deliveryId == Guid.Empty)
            {
                throw new ArgumentException(nameof(deliveryId));
            }

            var delivery = await _deliveriesRepository.GetDelivery(deliveryId);

            return Ok(delivery);
        }
    }
}