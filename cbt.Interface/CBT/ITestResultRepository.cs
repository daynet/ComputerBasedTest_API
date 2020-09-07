using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
  public  interface ITestResultRepository 
    {
        // int AddTestResult(TestResultVM model);
         Task<int> AddTestResult(IEnumerable<TestResultVM> model);

        TestResultVM GetTestResult(int QuestionBankId);

        IEnumerable<TestResultVM> GetTestResults(int Psid);

        bool UpdateTestResult(TestResultVM model);

        bool ResultExist(int testResultId);
    }
}
