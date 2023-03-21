﻿using BusinessLogic;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace AppointmentService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        ILogic logic;

        public AppointmentController(ILogic logic)
        {
            this.logic = logic;
        }

        [HttpPost("AddAppointmentByPatient")]
        public IActionResult AddAppointment([FromBody] AppointmentModel appointment)
        {

            try
            {
                appointment.AppointmentId = Guid.NewGuid();
                logic.AddAppointmentByPatient(appointment);

                return Ok(appointment);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateStatusByDoctor")]
        public IActionResult UpdateStatusByDoctor(Guid appointment_id, short status)
        {


            try
            {
                var response = logic.UpdateStatusByDoctor(appointment_id, status);
                return Ok(response);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateNurseIdByNurse")]
        public IActionResult UpdateNurseIdByNurse(Guid appointment_id, string nurse_id)
        {
            try
            {
                var response = logic.UpdateNurseIdByNurse(appointment_id, nurse_id);
                return Ok(response);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAppointmentsByDoctorId")]
        public IActionResult GetAppointmentsByDoctorId(string doctor_id) 
        {
            try
            {
                var response = logic.GetAppointmentsByDoctorId(doctor_id);
                return Ok(response);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAppointmentsByStatus")]
        public IActionResult GetAppointmentsByStatus(short status)
        {
            try
            {
                var response = logic.GetAppointmentsByStatus(status);
                return Ok(response);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAppointmentsByStatusOne")]
        public IActionResult GetAppointmentsByStatusOne()
        {
            try
            {
                var response = logic.GetAppointmentsByStatusOne();
                return Ok(response);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
