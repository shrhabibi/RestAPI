using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Model;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        // POST: api/User
        [HttpPost]
        public Benuzer Post([FromBody]Benuzer User)
        {
            DataLayer dataLayer = new DataLayer();
            Benuzer Result = dataLayer.GetUser(User.Benutzername, User.Kennwort);
            String error = dataLayer.GetException();
            if (error != "")
            {
                Result = new Benuzer();
                Result.ID = 0; Result.Benutzername = "Fehler"; Result.Kennwort = "Fehler";
            }

            return Result;

        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}