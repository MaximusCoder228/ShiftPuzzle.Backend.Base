namespace DeliveryTreckAPI;

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.IO; 
using System;

[ApiController]

public class CarpoolController : ControllerBase
{
    private readonly ProductRepository _productRepository;

    [HttpPost]
    [Route("/api/carpool/add")]

    
}







