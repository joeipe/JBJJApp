using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBJJApp.Domain;
using JBJJApp.Web.ViewModels;

namespace JBJJApp.Data
{
    public class StudentData
    {
        private GenericRepository<Grade> _gradeRepo;
        private GenericRepository<Person> _personRepo;
        public StudentData(GenericRepository<Grade> gradeRepo, GenericRepository<Person> personRepo)
        {
            _gradeRepo = gradeRepo;
            _personRepo = personRepo;
        }

        #region Grade
        public IList<GradeViewModel> GetGrade()
        {
            var gradesData = _gradeRepo.GetAll();
            var gradesVM = ObjectMapper.Mapper.Map<IList<GradeViewModel>>(gradesData);
            return gradesVM;
        }

        public GradeViewModel GetGradeById(int id)
        {
            var gradeData = _gradeRepo.GetById(id);
            var gradeVM = ObjectMapper.Mapper.Map<GradeViewModel>(gradeData);
            return gradeVM;
        }

        public void AddGrade(GradeViewModel value)
        {
            var gradeData = ObjectMapper.Mapper.Map<Grade>(value);
            _gradeRepo.Add(gradeData);
        }

        public void UpdateGrade(GradeViewModel value)
        {
            var gradeData = ObjectMapper.Mapper.Map<Grade>(value);
            _gradeRepo.Edit(gradeData);
        }

        public void DeleteGrade(GradeViewModel value)
        {
            var gradeData = ObjectMapper.Mapper.Map<Grade>(value);
            _gradeRepo.Delete(gradeData);
        }
        #endregion

        #region Person
        public IList<PersonViewModel> GetPerson()
        {
            var personsData = _personRepo.GetAll();
            var personsVM = ObjectMapper.Mapper.Map<IList<PersonViewModel>>(personsData);
            return personsVM;
        }

        public PersonViewModel GetPersonById(int id)
        {
            var personData = _personRepo.GetById(id);
            var personVM = ObjectMapper.Mapper.Map<PersonViewModel>(personData);
            return personVM;
        }

        public PersonViewModel GetPersonWithGradeById(int id)
        {
            var personData = _personRepo
                .SearchForInclude
                (
                    t => t.Id == id,
                    i => i.Grade
                )
                .FirstOrDefault();
            var personVM = ObjectMapper.Mapper.Map<PersonViewModel>(personData);
            return personVM;
        }

        public void AddPerson(PersonViewModel value)
        {
            var personData = ObjectMapper.Mapper.Map<Person>(value);
            _personRepo.Add(personData);
        }

        public void UpdatePerson(PersonViewModel value)
        {
            var personData = ObjectMapper.Mapper.Map<Person>(value);
            _personRepo.Edit(personData);
        }

        public void DeletePerson(PersonViewModel value)
        {
            var personData = ObjectMapper.Mapper.Map<Person>(value);
            _personRepo.Delete(personData);
        }
        #endregion
    }
}
