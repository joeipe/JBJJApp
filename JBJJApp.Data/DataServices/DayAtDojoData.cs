using JBJJApp.Domain;
using JBJJApp.Web.ViewModels;
using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBJJApp.Data.DataServices
{
    public class DayAtDojoData
    {
        private GenericRepository<Outcome> _outcomeRepo;
        private GenericRepository<Attendance> _attendanceRepo;
        private GenericRepository<SparringDetails> _sparringDetailsRepo;
        public DayAtDojoData(GenericRepository<Outcome> outcomeRepo, GenericRepository<Attendance> attendanceRepo, GenericRepository<SparringDetails> sparringDetailsRepo)
        {
            _outcomeRepo = outcomeRepo;
            _attendanceRepo = attendanceRepo;
            _sparringDetailsRepo = sparringDetailsRepo;
        }

        #region Outcome
        public IList<OutcomeViewModel> GetOutcome()
        {
            var outcomesData = _outcomeRepo.GetAll();
            var outcomesVM = ObjectMapper.Mapper.Map<IList<OutcomeViewModel>>(outcomesData);
            return outcomesVM;
        }

        public OutcomeViewModel GetOutcomeById(int id)
        {
            var outcomeData = _outcomeRepo.GetById(id);
            var outcomeVM = ObjectMapper.Mapper.Map<OutcomeViewModel>(outcomeData);
            return outcomeVM;
        }

        public void AddOutcome(OutcomeViewModel value)
        {
            var outcomeData = ObjectMapper.Mapper.Map<Outcome>(value);
            _outcomeRepo.Add(outcomeData);
        }

        public void UpdateOutcome(OutcomeViewModel value)
        {
            var outcomeData = ObjectMapper.Mapper.Map<Outcome>(value);
            _outcomeRepo.Edit(outcomeData);
        }

        public void DeleteOutcome(OutcomeViewModel value)
        {
            var outcomeData = ObjectMapper.Mapper.Map<Outcome>(value);
            _outcomeRepo.Delete(outcomeData);
        }
        #endregion

        #region Attendance
        public IList<AttendanceViewModel> GetAttendance()
        {
            var attendancesData = _attendanceRepo.GetAll();
            var attendancesVM = ObjectMapper.Mapper.Map<IList<AttendanceViewModel>>(attendancesData);
            return attendancesVM;
        }

        public AttendanceViewModel GetAttendanceById(int id)
        {
            var attendanceData = _attendanceRepo.GetById(id);
            var attendanceVM = ObjectMapper.Mapper.Map<AttendanceViewModel>(attendanceData);
            return attendanceVM;
        }

        public void AddAttendance(AttendanceViewModel value)
        {
            var attendanceData = ObjectMapper.Mapper.Map<Attendance>(value);
            _attendanceRepo.Add(attendanceData);
        }

        public void UpdateAttendance(AttendanceViewModel value)
        {
            var attendanceData = ObjectMapper.Mapper.Map<Attendance>(value);
            _attendanceRepo.Edit(attendanceData);
        }

        public void DeleteAttendance(AttendanceViewModel value)
        {
            var attendanceData = ObjectMapper.Mapper.Map<Attendance>(value);
            _attendanceRepo.Delete(attendanceData);
        }
        #endregion

        #region SparringDetails
        public IList<SparringDetailsViewModel> GetSparringDetails()
        {
            var sparringDetailssData = _sparringDetailsRepo.GetAll();
            var sparringDetailssVM = ObjectMapper.Mapper.Map<IList<SparringDetailsViewModel>>(sparringDetailssData);
            return sparringDetailssVM;
        }

        public SparringDetailsViewModel GetSparringDetailsById(int id)
        {
            var sparringDetailsData = _sparringDetailsRepo.GetById(id);
            var sparringDetailsVM = ObjectMapper.Mapper.Map<SparringDetailsViewModel>(sparringDetailsData);
            return sparringDetailsVM;
        }

        public void AddSparringDetails(SparringDetailsViewModel value)
        {
            var sparringDetailsData = ObjectMapper.Mapper.Map<SparringDetails>(value);
            _sparringDetailsRepo.Add(sparringDetailsData);
        }

        public void UpdateSparringDetails(SparringDetailsViewModel value)
        {
            var sparringDetailsData = ObjectMapper.Mapper.Map<SparringDetails>(value);
            _sparringDetailsRepo.Edit(sparringDetailsData);
        }

        public void DeleteSparringDetails(SparringDetailsViewModel value)
        {
            var sparringDetailsData = ObjectMapper.Mapper.Map<SparringDetails>(value);
            _sparringDetailsRepo.Delete(sparringDetailsData);
        }
        #endregion
    }
}
