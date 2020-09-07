using cbt.Interface.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cbt.viewModel.CBT;
using cbt.dbEntity.Model;

namespace cbt.repository.CBT
{
    public class TestResultRepository : ITestResultRepository
    {
        private CBTcontext _context;
        static object objLock = new object();
        public TestResultRepository(CBTcontext context)
        {
            _context = context;
        }
        //public async Task<int> AddTestResult(TestResultVM model)
        //{
        //    lock (objLock)
        //    {


        //        using (System.Data.Entity.DbContextTransaction dbtrans = _context.Database.BeginTransaction())
        //        {

        //            int id = 0;
        //            if (model == null) throw new Exception("There is no Entry!");

        //            if (!ResultExist(model.testResultId))
        //            {
        //                var addQuestion = new TestResult
        //                {
        //                    Answer = model.answer,
        //                    Altanswer = model.altAnswer,
        //                    DateTaken = DateTime.Now,
        //                    FinishTime = DateTime.Now.TimeOfDay,
        //                    Psid = model.psid,
        //                    QuestionBankId = model.questionBankId,
        //                    StartTime = DateTime.Now.TimeOfDay,
        //                    TestCategoryId = model.testCategoryId

        //                };

        //                var test = _context.TestResult.Add(addQuestion);
        //                 _context.SaveChangesAsync();
        //                dbtrans.Commit();
        //                return test.TestResultId;
        //            }
        //            else
        //            {
        //                UpdateTestResult(model);
        //                return model.testResultId;
        //            }
        //        }
        //    } 
        //}

        public async Task<int> AddTestResult(IEnumerable<TestResultVM> model)
        {

            lock (objLock)
            {

                using (System.Data.Entity.DbContextTransaction dbtrans = _context.Database.BeginTransaction())
                {

                    int id = 0;
                    if (model.Count() == 0) throw new Exception("There is no Entry!");

                    foreach (var o in model)
                    {
                        //if (!ResultExist(o.testResultId))
                        //{
                        var addQuestion = new TestResult
                        {
                            Answer = o.answer,
                            Altanswer = o.altAnswer,
                            DateTaken = DateTime.Now,
                            FinishTime = DateTime.Now.TimeOfDay,
                            Psid = o.psid,
                            QuestionBankId = o.questionBankId,
                            StartTime = DateTime.Now.TimeOfDay,
                            TestCategoryId = o.testCategoryId

                        };

                        var test = _context.TestResult.Add(addQuestion);
                      //  _context.SaveChangesAsync().Wait();
                      //  dbtrans.Commit();
                        //return test.TestResultId;
                        // }
                        //else
                        //{
                        //     UpdateTestResult(model);
                        //    return o.testResultId;
                        //}
                    }
                    _context.SaveChangesAsync().Wait();
                    dbtrans.Commit();
                    return 1;
                }

            }
        }

        public TestResultVM GetTestResult(int testResultId)
        {
            var getResult = (from q in _context.TestResult
                                where q.TestResultId  == testResultId
                                select new TestResultVM
                                {
                                    answer = q.Answer,
                                    questionBankId = q.QuestionBankId,
                                    psid = q.Psid,
                                    testCategoryId = q.TestCategoryId,
                                    testResultId = q.TestResultId
                                }).FirstOrDefault();

            return getResult;
        }

        public IEnumerable<TestResultVM> GetTestResults(int psid)
        {
            var getResult = (from q in _context.TestResult
                             where q.Psid == psid
                             select new TestResultVM
                             {
                                 answer = q.Answer,
                                 questionBankId = q.QuestionBankId,
                                 psid = q.Psid,
                                 testCategoryId = q.TestCategoryId,
                                 testResultId = q.TestResultId
                             }).ToList();

            return getResult;
        }

        public bool UpdateTestResult(TestResultVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var result = _context.TestResult.Find(model.testResultId);

                         if(result == null) throw new Exception("Not found!");

            result.Answer = model.answer;

            return _context.SaveChanges() > 0;
        }

        public bool ResultExist(int testResultId)
        {
           return _context.TestResult.Any(o=>o.TestResultId == testResultId);
        }
    }
}
