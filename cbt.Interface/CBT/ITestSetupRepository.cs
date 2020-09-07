using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
   public interface ITestSetupRepository
    {
        bool AddTestSetup(TestSetupVM model);

        TestSetupVM GetTestSetup(int TestCategoryId);

        IEnumerable<TestSetupVM> GetTestSetup();

        bool UpdateTestSetup(TestSetupVM model);

        bool DeleteTestSetup(int TestCategoryId);
    }
}
