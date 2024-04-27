namespace DeliveryTreckAPI;

using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.IO; 
using System.Net.Http;
using System.Text; 
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]

public class CarpoolController : ControllerBase
{
    private readonly ICompanionRepository _companionRepository;

    public StoreController(ICompanionRepository companionRepository)
    {
        _companionRepository = companionRepository;
    }


    [HttpGet]
    [Route("/api/carpool/search")]
    public IActionResult Show()
    {
        return Ok(_companionRepository.GetAllProducts());
    }

    [HttpPost]
    [Route("/api/carpool/add")]
    public IActionResult Add([FromBody] Companion newCompanion)
    { 
        _companionRepository.AddCompanion(newCompanion);
        return Ok(_companionRepository.GetAllCompanions());
    }
    
    [HttpPost]
    [Route("/api/carpool/name")]
        public IActionResult Delete(string name)
        {
            var companion = _companionRepository.GetCompanionByName(name);
            if (companion != null)
            {
                _companionRepository.DeleteCompanion(name);
                return Ok($"{name} удален");
            }
            else
            {
                return NotFound($"{name} не найден");
            }
        }




}







