using BackSaludMigrantes.Models.Context;
using BackSaludMigrantes.Models.Entities;
using BackSaludMigrantes.Requests;
using BackSaludMigrantes.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackSaludMigrantes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MigrantValidationsControllers : ControllerBase
    {
       
        private readonly DataContext _dataContext;

        public MigrantValidationsControllers(DataContext dbContext)
        {
            _dataContext = dbContext;
        }


        [HttpPost("Validate")]
        public ActionResult<ValidationResponse> RequestValidation(ValidationRequest validationRequest)
        {
            var response = new ValidationResponse();

            try
            {
                var registeredMigrant = _dataContext.MigrantsAcreditadom.FirstOrDefault(x => x.DocNum == validationRequest.DocNum
                                                         && x.Surname == validationRequest.Surname
                                                         && x.BirthDate == validationRequest.BirthDate);

                if (registeredMigrant is null)
                {
                    response.ErrorMessage = "No se encuentra registrado";
                    return response;
                }

                response.MigrantsStatementsFile = registeredMigrant.MigrantsStatementsFile;
                response.IsRegistered = true;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                return StatusCode(500, response);
            }
        }

       
        [HttpGet("Nucleo/{idSisben}")]
        public IEnumerable<MigrantsAcreditadom> GetMigrationStatamentsSisben(string idSisben)
        {

            var list = _dataContext.MigrantsAcreditadom.Where(x => x.MigrantsStatementsFile == idSisben).ToList();
            return list;

        }
     



    }
}