using DayAtDojo.Data;
using DayAtDojo.Data.Services;
using DayAtDojo.Domain;
using JBJJApp.Web.ViewModels;
using SharedKernel.Data;
using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JBJJApp.Web.Controllers
{
    public class DayAtDojoController : ApiController
    {
        private DayAtDojoData _dayAtDojoData;
        //public DayAtDojoController(DayAtDojoData dayAtDojoData)
        //{
        //    _dayAtDojoData = dayAtDojoData;
        //}

        public DayAtDojoController()
        {
            var dbContext = new DayAtDojoContext();
            var refScheduleContext = new ReferenceScheduleContext();
            var refStudentContext = new ReferenceStudentContext();
            _dayAtDojoData = new DayAtDojoData(
                new GenericRepository<Outcome>(dbContext),
                new GenericRepository<Attendance>(dbContext),
                new GenericRepository<SparringDetails>(dbContext),
                new GenericRepository<PersonSparringPartner>(refStudentContext),
                new GenericRepository<TimeTableClassAttended>(refScheduleContext)
                );
        }

        #region Outcome
        [HttpGet]
        public IHttpActionResult GetOutcome()
        {
            try
            {
                return Ok(_dayAtDojoData.GetOutcome());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOutcomeById(int id)
        {
            try
            {
                var outcomeVM = _dayAtDojoData.GetOutcomeById(id);

                if (outcomeVM == null)
                {
                    return NotFound();
                }

                return Ok(outcomeVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddOutcome([FromBody]OutcomeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.AddOutcome(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateOutcome([FromBody]OutcomeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.UpdateOutcome(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteOutcome(int id)
        {
            try
            {
                var outcomeVM = _dayAtDojoData.GetOutcomeById(id);
                if (outcomeVM == null)
                {
                    return NotFound();
                }

                outcomeVM.State = ObjectState.Deleted;
                _dayAtDojoData.DeleteOutcome(outcomeVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region Attendance
        [HttpGet]
        public IHttpActionResult GetAttendance()
        {
            try
            {
                return Ok(_dayAtDojoData.GetAttendance());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAttendanceById(int id)
        {
            try
            {
                var attendanceVM = _dayAtDojoData.GetAttendanceById(id);

                if (attendanceVM == null)
                {
                    return NotFound();
                }

                return Ok(attendanceVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult GetAttendanceWithGraphById(int id)
        {
            try
            {
                var attendanceVM = _dayAtDojoData.GetAttendanceWithGraphById(id);

                if (attendanceVM == null)
                {
                    return NotFound();
                }

                return Ok(attendanceVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddAttendance([FromBody]AttendanceViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.AddAttendance(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateAttendance([FromBody]AttendanceViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.UpdateAttendance(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            try
            {
                var attendanceVM = _dayAtDojoData.GetAttendanceById(id);
                if (attendanceVM == null)
                {
                    return NotFound();
                }

                attendanceVM.State = ObjectState.Deleted;
                _dayAtDojoData.DeleteAttendance(attendanceVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region SparringDetails
        [HttpGet]
        public IHttpActionResult GetSparringDetails()
        {
            try
            {
                return Ok(_dayAtDojoData.GetSparringDetails());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetSparringDetailsWithGraph()
        {
            try
            {
                return Ok(_dayAtDojoData.GetSparringDetailsWithGraph());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetSparringDetailsById(int id)
        {
            try
            {
                var sparringDetailsVM = _dayAtDojoData.GetSparringDetailsById(id);

                if (sparringDetailsVM == null)
                {
                    return NotFound();
                }

                return Ok(sparringDetailsVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetSparringDetailsWithGraphById(int id)
        {
            try
            {
                var sparringDetailsVM = _dayAtDojoData.GetSparringDetailsWithGraphById(id);

                if (sparringDetailsVM == null)
                {
                    return NotFound();
                }

                return Ok(sparringDetailsVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddSparringDetails([FromBody]SparringDetailsViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.AddSparringDetails(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateSparringDetails([FromBody]SparringDetailsViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.UpdateSparringDetails(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteSparringDetails(int id)
        {
            try
            {
                var sparringDetailsVM = _dayAtDojoData.GetSparringDetailsById(id);
                if (sparringDetailsVM == null)
                {
                    return NotFound();
                }

                sparringDetailsVM.State = ObjectState.Deleted;
                _dayAtDojoData.DeleteSparringDetails(sparringDetailsVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
    }
}
