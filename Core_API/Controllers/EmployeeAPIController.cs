using Core_API.Models;
using Core_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
    /// <summary>
    /// The URL ROute Expression
    /// api/[controller]
    /// The 'api' is fixed word in URL
    /// The [controller], is a Expression or placeholder for 'controller class name' excluding the word 'Controller' e.g. it will be 'EmployeeAPI'
    /// The Route URL will be
    /// https://[SERVER-NAME | HOST-NAME | IP-ADDRESS]:[PORT-NO]/api/EmployeeAPI
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IService<Employee, int> deptServ;

        /// <summary>
        /// Injected the service 
        /// </summary>
        /// <param name="serv"></param>
        public EmployeeAPIController(IService<Employee,int> serv)
        {
            deptServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await deptServ.GetAsync();
            return Ok(result);
        }
        /// <summary>
        /// https://[SERVER-NAME | HOST-NAME | IP-ADDRESS]:[PORT-NO]/api/EmployeeAPI/{VALU-OF-ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dept =  await deptServ.GetAsync(id);
            return Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee dept)
        { 
            var result = await deptServ.CreateAsync(dept);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee dept)
        {
            var result = await deptServ.UpdateAsync(id,dept);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
              await deptServ.DeleteAsync(id);
            return Ok("Delete Successful");
        }
    }
}
