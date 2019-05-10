using JBJJApp.Web.ViewModels;
using Schedule.Data;
using Schedule.Data.Services;
using Schedule.Domain;
using SharedKernel.Data;
using SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JBJJApp.Web.Controllers
{
    public class ScheduleController : ApiController
    {
        private ScheduleData _scheduleData;

        //public ScheduleController(ScheduleData scheduleData)
        //{
        //    _scheduleData = scheduleData;
        //}

        public ScheduleController()
        {
            var dbContext = new ScheduleContext();
            _scheduleData = new ScheduleData(new GenericRepository<ClassType>(dbContext), new GenericRepository<TimeTable>(dbContext));
        }

        #region ClassType
        // GET: api/Schedule
        [HttpGet]
        public IHttpActionResult GetClassType()
        {
            try
            {
                return Ok(_scheduleData.GetClassType());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // GET: api/Schedule/5
        [HttpGet]
        public IHttpActionResult GetClassTypeById(int id)
        {
            try
            {
                var classTypeVM = _scheduleData.GetClassTypeById(id);

                if (classTypeVM == null)
                {
                    return NotFound();
                }

                return Ok(classTypeVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Schedule
        [HttpPost]
        public IHttpActionResult AddClassType([FromBody]ClassTypeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.AddClassType(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Schedule/5
        [HttpPost]
        public IHttpActionResult UpdateClassType([FromBody]ClassTypeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.UpdateClassType(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Schedule/5
        [HttpDelete]
        public IHttpActionResult DeleteClassType(int id)
        {
            try
            {
                var classTypeVM = _scheduleData.GetClassTypeById(id);
                if (classTypeVM == null)
                {
                    return NotFound();
                }

                classTypeVM.State = ObjectState.Deleted;
                _scheduleData.DeleteClassType(classTypeVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region TimeTable
        [HttpGet]
        public IHttpActionResult GetTimeTable()
        {
            try
            {
                return Ok(_scheduleData.GetTimeTable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Schedule/5
        [HttpGet]
        public IHttpActionResult GetTimeTableById(int id)
        {
            try
            {
                var timeTable = _scheduleData.GetTimeTableById(id);

                if (timeTable == null)
                {
                    return NotFound();
                }

                return Ok(timeTable);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetTimeTableWithClassTypeById(int id)
        {
            try
            {
                var timeTable = _scheduleData.GetTimeTableWithClassTypeById(id);

                if (timeTable == null)
                {
                    return NotFound();
                }

                return Ok(timeTable);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Schedule
        [HttpPost]
        public IHttpActionResult AddTimeTable([FromBody]TimeTableViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.AddTimeTable(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Schedule/5
        [HttpPost]
        public IHttpActionResult UpdateTimeTable([FromBody]TimeTableViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.UpdateTimeTable(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Schedule/5
        [HttpDelete]
        public IHttpActionResult DeleteTimeTable(int id)
        {
            try
            {
                var timeTableVM = _scheduleData.GetTimeTableById(id);
                if (timeTableVM == null)
                {
                    return NotFound();
                }

                timeTableVM.State = ObjectState.Deleted;
                _scheduleData.DeleteTimeTable(timeTableVM);

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
