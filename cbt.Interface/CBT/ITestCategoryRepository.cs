using cbt.viewModel.CBT;
using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
   public interface  ITestCategoryRepository
    {
       bool AddTestCategory(TestCategoryVM model);

        TestCategoryVM GetTestCategory(int TestCategoryId);

        IEnumerable<TestCategoryVM> GetTestCategories();

        bool UpdateTestCategory(TestCategoryVM model);

        bool DeleteTestCategory(int TestCategoryId);
    } 
}
