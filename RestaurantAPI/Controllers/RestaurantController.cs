﻿using System.Collections;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{


    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
      
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)

        {
            _restaurantService = restaurantService;
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateRestaurantDto dto, [FromRoute]int id)
        {
        //if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    } //kod zastąpiony przez atrybut API

           _restaurantService.Update(id, dto);
        
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

                return NoContent();


        }


        [HttpPost]
        [Authorize(Roles ="Admin, Manager")]

        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
        {

            //walidacja

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //end

            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }


        [HttpGet]
   [AllowAnonymous]
  //      [Authorize(Policy = "Atleast20")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery]RestaurantQuery query)
        {
            var restaurantsDtos = _restaurantService.GetAll(query);
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
 

            return Ok(restaurant);
        }

    }
}
