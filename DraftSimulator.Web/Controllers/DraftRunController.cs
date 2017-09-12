using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DraftSimulator.DAL;

namespace DraftSimulator.Web.Controllers
{
    public class DraftRunController : ApiController
    {
        
        public IHttpActionResult GetDraftRun()
        {
            DraftRun draftRunInstance = new DraftRun();
            return Ok(draftRunInstance);
        }

        public IHttpActionResult PostDraftRun()
        {
            DraftRun draftRunInstance = new DraftRun();
            return Ok(draftRunInstance);
        }
    }
}
