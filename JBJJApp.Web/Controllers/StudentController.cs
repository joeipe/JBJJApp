using JBJJApp.Web.ViewModels;
using SharedKernel.Data;
using SharedKernel.Enums;
using Student.Data;
using Student.Data.Services;
using Student.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JBJJApp.Web.Controllers
{
    public class StudentController : ApiController
    {
        private StudentData _studentData;

        //public StudentController(StudentData studentData)
        //{
        //    _studentData = studentData;
        //}

        public StudentController()
        {
            var dbContext = new StudentContext();
            _studentData = new StudentData(new GenericRepository<Grade>(dbContext), new GenericRepository<Person>(dbContext));
        }

        #region Grade
        [HttpGet]
        public IHttpActionResult GetGrade()
        {
            try
            {
                return Ok(_studentData.GetGrade());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetGradeById(int id)
        {
            try
            {
                var gradeVM = _studentData.GetGradeById(id);

                if (gradeVM == null)
                {
                    return NotFound();
                }

                return Ok(gradeVM);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddGrade([FromBody]GradeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.AddGrade(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateGrade([FromBody]GradeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.UpdateGrade(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteGrade(int id)
        {
            try
            {
                var gradeVM = _studentData.GetGradeById(id);
                if (gradeVM == null)
                {
                    return NotFound();
                }

                gradeVM.State = ObjectState.Deleted;
                _studentData.DeleteGrade(gradeVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region Person
        [HttpGet]
        public IHttpActionResult GetPerson()
        {
            try
            {
                return Ok(_studentData.GetPerson());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPersonById(int id)
        {
            try
            {
                var person = _studentData.GetPersonById(id);

                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPersonWithGradeById(int id)
        {
            try
            {
                var student = _studentData.GetPersonWithGradeById(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddPerson([FromBody]PersonViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.AddPerson(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdatePerson([FromBody]PersonViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.UpdatePerson(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePerson(int id)
        {
            try
            {
                var personVM = _studentData.GetPersonById(id);
                if (personVM == null)
                {
                    return NotFound();
                }

                personVM.State = ObjectState.Deleted;
                _studentData.DeletePerson(personVM);

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
