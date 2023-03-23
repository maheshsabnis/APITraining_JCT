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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IService<Employee, int> empServ;
        private readonly IService<Department, int> deptServ;

        /// <summary>
        /// Injected the service 
        /// </summary>
        /// <param name="serv"></param>
        public EmployeeAPIController(IService<Employee,int> serv, IService<Department, int> deptServ)
        {
            empServ = serv;
            this.deptServ = deptServ;

        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await empServ.GetAsync();
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
            var emp =  await empServ.GetAsync(id);
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee emp)
        {
            // Check for the Model Validation 
            if (ModelState.IsValid)
            {
                var result = await empServ.CreateAsync(emp);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee emp)
        {
            var result = await empServ.UpdateAsync(id,emp);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
              await empServ.DeleteAsync(id);
            return Ok("Delete Successful");
        }


        [HttpGet("{deptName}")]
        [ActionName("getEmpsByDname")]
        public async Task<IActionResult> ListEmployeesBydeptName(string deptName)
        {
            List<Employee> employees = new List<Employee>();

            int dno = ((from d in await deptServ.GetAsync()
                      where d.DeptName == deptName
                      select d).FirstOrDefault()).DeptNo;
            if (dno == 0)
            {
                return BadRequest($"Sorry the DeptName is not present in oour records");
            }
            
            employees = (from e in await empServ.GetAsync()
                        where e.DeptNo == dno
                        select new Employee() 
                        {
                          EmpNo = e.EmpNo,
                          EmpName = e.EmpName,
                          Designation   = e.Designation,
                          Salary = e.Salary,
                          DeptNo = dno
                        }).ToList();

            return Ok(employees);
        }
    }
}
