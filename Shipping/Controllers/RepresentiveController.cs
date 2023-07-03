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
    public class RepresentiveController : ControllerBase
    {
        IRepresentiveRepository representiveRepository;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public RepresentiveController(IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IRepresentiveRepository representiveRepository
            
            )
        {
            _userManager = userManager;
            _config = configuration;
            this.representiveRepository = representiveRepository;
            
        }

        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDtoRepresentive registerDto)
        {
            ApplicationUser representive = new Representive
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Address = registerDto.Address,
                PhoneNumber = registerDto.Phone,
                Id_Branch = registerDto.Branch,
                Id_Governate = registerDto.Governate,
                type_of_discount = registerDto.type_of_discount,
                company_percantage = registerDto.Percent,

            };

            var result = await _userManager.CreateAsync(representive, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, representive.Id),
            new Claim(ClaimTypes.Name, representive.UserName),
            new Claim(ClaimTypes.Role, "Representive"),
        };
            await _userManager.AddClaimsAsync(representive, claims);

            return Ok();
        }

        #endregion

        #region GetAll

        [HttpGet]
        public ActionResult getAllRepresentive()
        {
            List<GetAllRepresentive> sd = new List<GetAllRepresentive>();
            foreach (var item in representiveRepository.getall())
            {
                GetAllRepresentive d = new GetAllRepresentive();
                d.Id = item.Id;
                d.UserName = item.UserName;
                d.Phone = item.PhoneNumber;
                d.email = item.Email;
                d.Address = item.Address;
                d.Governate = item.Governates.Name;
                d.Branch = item.branches.Name;
                d.type_of_discount = item.type_of_discount;
                d.Percent = item.company_percantage;

                sd.Add(d);
            }
            return Ok(sd);

        }
        #endregion

        #region Update

        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult UpdateRepresentive(string id , UpdateRepresentiveDTO DTO)
        {
            if (DTO.Id==id)
            {
               var res= representiveRepository.getbyid(id);
                if (res != null)
                {
                    res.UserName=DTO.UserName;
                    res.Address= DTO.Address;
                    res.PhoneNumber = DTO.Phone;
                    res.Email = DTO.Email;
                    res.Id_Branch = DTO.Branch;
                    res.Id_Governate = DTO.Governate;
                    res.type_of_discount = DTO.type_of_discount;


                    representiveRepository.update(res);

                    return  Ok();
                }
            }

            return BadRequest(); 

        }

        #endregion

        #region Get BY ID'

        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult getById(string id) {
            var rep = representiveRepository.getbyid(id);
            if (rep == null)
            {  return BadRequest(); }
            return Ok  (rep);
        }
        #endregion


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            representiveRepository.delete(id);
            return Ok();

        }
    }
}
