using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Bll;
using Quki.Entity.Base;
using Quki.Entity.IBase;
using Quki.Interface;

namespace Quki.WebApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    ///
    /// T Entity Karşılık gelmektedir (veritabanını tablolarına)
    /// 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApiBaseController<TInterface, T, TDto> : ControllerBase where TInterface : IGenericService<T, TDto> where T:EntityBase where TDto: DtoBase
    {
        private readonly TInterface servis;

        public ApiBaseController(TInterface servis)
        {
            this.servis = servis;
        }

        [HttpGet]
        public IResponse<TDto> Find(int id) 
        {
            try
            {
                var entity = servis.TgetItemByID(id);
                var entityDto = ObjectMapper.Mapper.Map<TDto>(entity);

                if(entity == null)
                {
                    return new Response<TDto>
                    {
                        StatusCode = StatusCodes.Status204NoContent,
                        Message = "Getirilecek kayıt bulunamadı.",
                        Data = null
                    };
                }

                return new Response<TDto>
                {
                    StatusCode= StatusCodes.Status200OK,
                    Message = "Getirme işlemi başarılı.",
                    Data = entityDto
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Hata:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
