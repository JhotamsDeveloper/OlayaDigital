using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlayaDigital.Core.DTOs;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigitalAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlayaDigitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IRepository _postRepository;

        public UserController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var _data = _unitOfWork.UserRepository.GetAll();

            //Mapeo con AutoMapper
            var _dataMapper = _mapper.Map<IEnumerable<UserDto>>(_data);

            //Estructurar el response del api
            var _response = new ApiResponse<IEnumerable<UserDto>>(_dataMapper)
            {
                Msg = "Resultado de la busqueda"
            };
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var _data = await _unitOfWork.UserRepository.GetById(id);
            var _dataDto = _mapper.Map<UserDto>(_data);

            //Estructurar el response del api
            var _response = new ApiResponse<UserDto>(_dataDto);
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto model)
        {
            var _data = _mapper.Map<User>(model);
            await _unitOfWork.UserRepository.Add(_data);
            await _unitOfWork.saveChangesAsync();
            var _dataDto = _mapper.Map<UserDto>(_data);

            //Estructurar el response del api
            var _response = new ApiResponse<UserDto>(_dataDto);
            return Ok(_response);
        }



        //Ejemplo para actualizar una entidad https: //localhost:44389/api/post?id=1
        [HttpPut]
        public async Task<IActionResult> Put(int id, UserDto modelDto)
        {
            var _data = _mapper.Map<User>(modelDto);
            modelDto.Id = id;
            _unitOfWork.UserRepository.Update(_data);
            await _unitOfWork.saveChangesAsync();
            //Estructurar el response del api
            return Ok("Registro guardado éxitosamente");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.saveChangesAsync();
            //Estructurar el response del api
            return Ok("El registo se elimino exitosamente");
        }
    }
}
