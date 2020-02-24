using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [Route("api/planets")]
    public class PlanetsControllers : Controller 
    {
        Planets[] planets = new Planets[]
        {
            new Planets {Shape = "Round", Colour = "Blue", Planet = "Earth", Description = "Friendly", Population = "20 000"},
            new Planets {Shape = "Oval", Colour = "Brown", Planet  = "Mars", Description = "Very Bad", Population = "10 000"},
            new Planets {Shape = "Square", Colour = "Red", Planet = "Jupiter", Description = "Good", Population = "60 000"},
            new Planets {Shape = "Rectangle", Colour = "Grey", Planet = "Venus", Description = "Not Nice", Population = "5 000"},
            new Planets {Shape = "Triangle", Colour = "Black", Planet = "Mercury", Description = "Dark and Bad", Population = "No Puplation"},
            new Planets {Shape = "Acute", Colour = "Orange", Planet = "Saturn", Description = "Has ring around", Population = "No Population"}
        };

        [HttpGet("all")]
        public IEnumerable<Planets> ListAllPlanets()
        {
            return planets;
        }

        [HttpGet("colors/{color}")]
        public IEnumerable<Planets> ListPlanetsByColor(string color)
        {
            IEnumerable<Planets> retPlanet = 
                from g in planets
                where g.Colour.Equals(color)
                select g;

            return retPlanet;
        }

        [HttpGet("continents/{cont}")]
        public IEnumerable<Planets> ListPlanetsByContinents(string cont)
        {
            IEnumerable<Planets> retPlanet = 
                from g in planets
                where g.Planet.Equals(cont)
                select g;

            return retPlanet;
        }

        [HttpGet("descriptions/{des}")]
        public IEnumerable<Planets> ListPlanetsByDescription(string des)
        {
            IEnumerable<Planets> retPlanet = 
                from g in planets
                where g.Description.ToUpper().Contains(des.ToUpper())
                orderby g.Colour
                select g;

            return retPlanet;
        }
    }
}