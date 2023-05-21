using CapstoneProject.DAL;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }
        [HttpGet]
        [Route("GetListOfMedicines")]
        public async Task<List<Medicine>> GetMedicinesAsync()
        {
            try
            {
                return await medicineService.GetMedicineListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetMedicineById")]
        public async Task<IEnumerable<Medicine>> GetMedicinesByIdAsync(int Id)
        {
            try
            {
                var response = await medicineService.GetMedicineByIdAsync(Id);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteMedicine")]
        public async Task<IActionResult> DeleteMedicine(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await medicineService.DeleteMedicineAsync(Id);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("AddMedicine")]
        public async Task<IActionResult> AddMedicine(Medicine medicine)
        {
            if (medicine == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await medicineService.AddMedicineAsync(medicine);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("EditMedicine")]
        public async Task<IActionResult> EditMedicine(int Id, Medicine medicine)
        {
            if (medicine == null && Id < 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await medicineService.UpdateMedicineAsync(Id, medicine);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}
