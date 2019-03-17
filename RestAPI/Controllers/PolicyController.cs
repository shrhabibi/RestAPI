using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Model;


namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        // GET api/valuess
        [HttpGet]
        public List<Versicherungspolice> Get()
        {
            DataLayer dataLayer = new DataLayer();
            List<Versicherungspolice> Versicherungspolicen = dataLayer.GetPolicies();
            String error = dataLayer.GetException();

            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            return Versicherungspolicen;
        }

        [HttpPost]
        public List<Versicherungspolice> Post([FromBody]int UserID)
        {
            DataLayer dataLayer = new DataLayer();
            List<Versicherungspolice> Versicherungspolicen = dataLayer.GetPolicies(UserID);
            String error = dataLayer.GetException();
            if(error!="")
            {
                Versicherungspolice Error = new Versicherungspolice();
                Error.ID = 0; Error.Name = "Fehler"; Error.Beschreibung = error;
                Versicherungspolicen = new List<Versicherungspolice>();
                Versicherungspolicen.Add(Error);
            }

            return Versicherungspolicen;
        }
    }

    
}