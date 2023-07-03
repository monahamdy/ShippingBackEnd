using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.DTO;
using Shipping.Models;
using Shipping.Repository;
using System.Security.Claims;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private BranchesRepo _branchRepo;
        public BranchController(BranchesRepo branchRepo)
        {
            _branchRepo = branchRepo;
        }
        [HttpGet]
        public ActionResult Get_Braches()
        {
           
            return Ok(_branchRepo.GetBranches());
        }
        [HttpGet("{id}")]
        public ActionResult Get_Brach(string id)
        {
            if (id != null)
            {
                return Ok(_branchRepo.GetBranches(id));

            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult Add_Branch(Branches branch)
        {
            if (branch!=null)
            {
                _branchRepo.Insert(branch);
                return Created("", branch);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public ActionResult update_Branch(string id,Branches branch)
        {
            if (id != null)
            {
                var data = _branchRepo.GetBranches(id);
                if (data != null)
                {
                    _branchRepo.Update(id, branch);
                    return Created("Updated", data);
                }
            }
            return NotFound();


        }
        [HttpDelete("{id}")] 
        public ActionResult Delete_Branch(string id)
        {
            if (id != null)
            {
                var data = _branchRepo.GetBranches(id);
                if (data != null)
                {
                    _branchRepo.Delete(id);
                    return Created("Deleted", data);
                }
            }
            return NotFound();
        }

    }
}
