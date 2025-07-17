using Application.DTO.Speciality;
using Application.DTO.Speciality;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceAdapters.Controllers
{

    [Route("api/speciality")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _SpecialityService;
        //private readonly ISpecialitytempService _SpecialitytempService;

        public SpecialityController(ISpecialityService SpecialityService)
        {
            _SpecialityService = SpecialityService;
        }

        [HttpPost]
        public async Task<ActionResult<SpecialityAddedDTO>> AddSpeciality([FromBody] AddSpecialityDTO addSpecialityDTO)
        {
            var specialityadded = await _SpecialityService.Create(addSpecialityDTO);
            return specialityadded.ToActionResult();
        }

        [HttpPut]
        public async Task<ActionResult<UpdatedSpecialityDTO>> UpdateSpeciality([FromBody] UpdateSpecialityDTO updateSpecialityDTO)
        {
            var specyUpdated = await _SpecialityService.Update(updateSpecialityDTO);
            return specyUpdated.ToActionResult();
        }

        /* [HttpPost("with-technology")]
        public async Task<ActionResult<SpecialityTemporaryDTO>> CreateWithTechnology([FromBody] AddSpecialityWithTechnologyDTO AddSpecialityWithTechnologyDTO)
        {
            await _specialityTempService.StartSagaAsync(AddSpecialityWithTechnologyDTO);
            return Accepted();
        } */
    }
}