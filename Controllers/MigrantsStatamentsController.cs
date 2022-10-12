using BackSaludMigrantes.Models.Context;
using BackSaludMigrantes.Models.Entities;
using BackSaludMigrantes.Requests;
using BackSaludMigrantes.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackSaludMigrantes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MigrantsStatamentsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public MigrantsStatamentsController(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        [HttpGet("Statement/{idSisben}")]

        public ActionResult<StatamentsResponse> GetMigrationStatamentsSisben(string idSisben)
        {
            var response = new StatamentsResponse();

            MigrantsStatements MSS = new MigrantsStatements();
            try
            {
                MSS = _dataContext.MigrantsStatements.Find(idSisben);
                if (MSS == null)
                {
                    response.ErrorMessage = "No Se Encuentra Registrado Declaraciones";
                    return response;
                }
                response.MigrantsStatements = MSS;
                response.IsRegistered = true;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                return StatusCode(500, response);
            }

        }
        [HttpPut("UpdateDataStataments/{fileData}")]
        public async Task<ActionResult<StatamentsResponse>> UpdateDataStataments(string fileData, UpdateStatamentsRequest updateStatamentsRequest)
        {
            var result = new StatamentsResponse();

            try
            {
                MigrantsStatements ms = null;
                int i =0;
                ms = _dataContext.MigrantsStatements.Find(fileData);
                if (ms != null)
                {
                    ms.DataSISBEN = updateStatamentsRequest.DataSISBEN;
                    ms.Direction = updateStatamentsRequest.Direction;
                    ms.Mobile = updateStatamentsRequest.Mobile;
                    ms.LocationId = updateStatamentsRequest.LocationId;
                    ms.StatamentsDate = DateTime.Now;
                    i = this._dataContext.SaveChanges();
                }else{
                    ms = new MigrantsStatements();
                    ms.DataSISBEN = updateStatamentsRequest.DataSISBEN;
                    ms.Direction = updateStatamentsRequest.Direction;
                    ms.Mobile = updateStatamentsRequest.Mobile;
                    ms.LocationId = updateStatamentsRequest.LocationId;
                    ms.StatamentsDate = DateTime.Now;
                    _dataContext.MigrantsStatements.Add(ms);
                    i = this._dataContext.SaveChanges();
                }
                if(i>0){
                    result.IsRegistered = true;
                    result.ErrorMessage = "Se realizo los cambios correctamente";
                }else{
                    result.IsRegistered = false;
                    result.ErrorMessage = "No se pudo actualizar los cambios";                    
                }


                return result;
            }
            catch (Exception ex)
            {
               result.ErrorMessage = ex.Message;
               result.IsRegistered = false;
               return result;
            }           
        }
    }
}
