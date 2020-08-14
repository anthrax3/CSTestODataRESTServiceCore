using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSEFTPC4Core3ObjectService.ObjectServices;
//using CSEFTPC4Core3Objects.Objects;
using static CSEFTPC4Core3ObjectService.ObjectServices.Ac4yPersistentChildEFService;
using CSAc4yObjectPlanCORE;

namespace CSEFTPC4Core3EFRESTServiceOdataController.Controllers
{
    [ApiController]   
    [Route("[controller]")]
    public class Ac4yPersistentChildController : ODataController
    {
        [HttpGet]
        [EnableQuery]
        public IQueryable<Ac4yPersistentChild> Get()
        {

            return new Context().Ac4yPersistentChilds;
        }
        
        [HttpDelete]
        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            return Ok(new Ac4yPersistentChildEFService().DeleteById(new DeleteByIdRequest() { Id = key }));
        }

        [HttpPatch]
        [EnableQuery]
        public IActionResult Patch([FromODataUri] int key, [FromBody] Delta<Ac4yPersistentChild> request)
        {
            UpdateByIdResponse response =
                new Ac4yPersistentChildEFService().UpdateById(new UpdateByIdRequest()
                {
                    Id = key,
                    Ac4yPersistentChild = request.GetInstance()
                }); 

            return Ok(response);
        }
        
        [HttpPost]
        [EnableQuery]
        public InsertResponse Post([FromBody] Ac4yPersistentChild newObject)
        {
            return new Ac4yPersistentChildEFService().Insert(new InsertRequest() { Ac4yPersistentChild = newObject });
        }    
    } // Ac4yPersistentChildODataController
} // Ac4yPersistentChildEFRESTServiceOdataController.Controllers