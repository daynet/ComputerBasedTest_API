using cbt.dbEntity.Model;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class TestSetupRepository
    {

        private CBTcontext _context;


        public TestSetupRepository(CBTcontext context)
        {
            _context = context;

        }
       public bool AddTestSetup(TestSetupVM model)
       {
            if (model == null) throw new Exception("There is no Entry!");

            var setUp = new TestSetup()
            {
                DisplayResult = model.DisplayResult,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                StartTime = model.StartTime,
                StopTime = model.StopTime
            };

            _context.TestSetup.Add(setUp);

            if (_context.SaveChanges() > 0)
            {

                var testSetupId = setUp.TestSetupId;

                foreach (var id in model.QuestionBankIds)
                {
                    var publishQuestion = new PublishedQuestion
                    {
                        QuestionBankId = id.questionBankId,
                        TestSetupId = testSetupId
                    };

                    _context.PublishedQuestion.Add(publishQuestion);
                }
            }
           return  _context.SaveChanges() > 0;
              
        }

        public TestSetupVM GetTestSetupById(int TestSetUpId)
        {
            if (TestSetUpId == 0) throw new Exception("Kindly select a valid record!!!");


           var setupData = (from s in _context.TestSetup
                            where s.TestSetupId == TestSetUpId

                            select new TestSetupVM
                            {
                                DisplayResult = s.DisplayResult,
                                EndDate = s.EndDate,
                                StartDate = s.StartDate,
                                StartTime = s.StartTime,
                                StopTime = s.StopTime
                            });

            return setupData.FirstOrDefault();

        }

        public IEnumerable<TestSetupVM> GetTestSetup()
        {
            return (from s in _context.TestSetup
                    select new TestSetupVM
                    {
                        DisplayResult = s.DisplayResult,
                        EndDate = s.EndDate,
                        StartDate = s.StartDate,
                        StartTime = s.StartTime,
                        StopTime = s.StopTime

                    }).ToList();

        }

        public bool UpdateTestSetup(TestSetupVM model)
        {
            var setupData = _context.TestSetup.Find(model.TestSetupId);

            if (setupData == null) throw new Exception("Record not found");

            setupData.DisplayResult = model.DisplayResult;
            setupData.EndDate = model.EndDate;
            setupData.StartDate = model.StartDate;
            setupData.StartTime = model.StartTime;
            setupData.EndDate = model.EndDate;


            return _context.SaveChanges() > 0;
        }

        public bool DeleteTestSetup(int TestSetUpId)
        {
            if (TestSetUpId == 0) throw new Exception("There is nothing to delete!");

            var setup = _context.TestSetup.Find(TestSetUpId);

            if (setup == null) throw new Exception("Record not found");

            _context.TestSetup.Remove(setup);

            return _context.SaveChanges() > 0;

        }
    }
}
