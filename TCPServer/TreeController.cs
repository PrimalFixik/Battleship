using Core;
using Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TCPServer
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/tree")]
    public class TreeController : ApiController
    {
        TreeService service = new TreeService();

        [HttpGet]
        [Route("GetRoot")]
        public IHttpActionResult GetRoot()
        {
            try
            {
                return Ok(service.GetTree());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("GetPath")]
        public IHttpActionResult GetPath([FromBody]string path)
        {
            try
            {
                return Ok(service.GetTree(path));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("GetArchive")]
        public IHttpActionResult GetArchive([FromBody]string path)
        {
            try
            {
                service.GetArchive(path);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
    }
}