using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class CourseRepository : ICourse
    {
        private CBTcontext _context;

        public CourseRepository(CBTcontext context)
        {
            _context = context;
        }

        public IEnumerable<Courses> getCourse()
        {
            return (from m in _context.Course

                    select new Courses
                    {
                        courseId = m.CourseId,
                        courseName = m.CourseName
                    }).ToList();

        }

        public IEnumerable<NationalityVM> getNationality()
        {

            var nat = (from m in _context.Nationality
                       select new NationalityVM
                       {
                           NationalityId = m.NationalityID,
                           NationalityName = m.NationalityName

                       }).ToList();

            return nat;

        }

        public IEnumerable<StateVM> getState()
        {

            return (from m in _context.State
                    select new StateVM
                    {
                        Id = m.Id,
                        Name = m.Name


                    }).ToList();



        }



        public List<DateTime> getSaturdays()
        {
           // List<Saturdays> sat = new List<Saturdays>();
           DateTime startDate = new DateTime(2019, 9, 14);
            DateTime endDate = startDate.AddYears(1);
            List<DateTime> saturdays = new List<DateTime>();
            while (startDate < endDate)
            {
                if (startDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    startDate = startDate.AddDays(7);
                    saturdays.Add(new DateTime(startDate.Year, startDate.Month, startDate.Day));
                   
                   

                }

            }  
            return saturdays.ToList();
        }
    }

}
