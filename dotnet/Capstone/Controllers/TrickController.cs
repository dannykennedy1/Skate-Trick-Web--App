using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrickController : ControllerBase
    {
        public ITrickDao trickDao;

        public TrickController(ITrickDao trickDao)
        {
            this.trickDao = trickDao;
        }

        [HttpGet()]
        public ActionResult<List<Trick>> GetTricks()
        {
            return Ok(trickDao.GetTricks());
        }

        [HttpGet("{id}")]

        public ActionResult<Trick> GetTrickById(int id)
        {
            return Ok(trickDao.GetTrickById(id));
        }

        [HttpPost("addNewTrick")]

        public ActionResult<Trick> AddNewTrick(Trick newTrick)
        {
            Trick result = trickDao.AddNewTrick(newTrick);

            if(result.Id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut("{id}")]

        public ActionResult<Trick> ChangeTrick(Trick updatedTrick) 
        {
            Trick newTrick = trickDao.UpdateTrick(updatedTrick);

            if(newTrick == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newTrick);
            }
        }

    }
}
