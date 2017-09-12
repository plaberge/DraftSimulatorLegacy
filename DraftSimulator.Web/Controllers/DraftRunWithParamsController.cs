using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DraftSimulator.DAL;

namespace DraftSimulator.Web.Controllers
{
    public class DraftRunWithParamsController : ApiController
    {
        public IHttpActionResult GetDraftRunWithBalls(int Ball1, int Ball2, int Ball3, int Ball4)
        {
            DraftRun draftRunInstance = new DraftRun(Ball1, Ball2, Ball3, Ball4);
            return Ok(draftRunInstance);
        }

        
        public IHttpActionResult PostDraftRunWithLatLong(decimal latitude, decimal longitude)
        {
            DraftRun draftRunInstance = new DraftRun(latitude, longitude);
            return Ok(draftRunInstance);
        }
    }
}
