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
    public class TestCategoryRepository : ITestCategoryRepository
    {
        private CBTcontext _context;
        public TestCategoryRepository(CBTcontext context)
        {
            _context = context;
        }
        public bool AddTestCategory(TestCategoryVM model)
        {
            if (model == null) throw new Exception("There is no Entry!"); ;

            var category = new TestCategory
            {
                CategoryName = model.categoryName,
                CreatedBy = model.createdBy,
                DateCreated = model.dateCreated,
                IsDelete = model.isDelete
            };

            _context.TestCategory.Add(category);

            return _context.SaveChanges() > 0;
        }

        public bool DeleteTestCategory(int TestCategoryId)
        {
            if (TestCategoryId == 0) throw new Exception("There is nothing to delete!");

            var category = _context.TestCategory.Find(TestCategoryId);

            if (category == null) throw new Exception("Record not found");

            _context.TestCategory.Remove(category);

            return _context.SaveChanges() > 0;
        }

        public IEnumerable<TestCategoryVM> GetTestCategories()
        {
            return (from x in _context.TestCategory
                    select new TestCategoryVM {
                        testCategoryId=x.TestCategoryId,
                        categoryName = x.CategoryName,
                        createdBy = x.CreatedBy,
                        dateCreated = x.DateCreated,
                        isDelete = x.IsDelete
                    }).ToList();
        }

        public TestCategoryVM GetTestCategory(int TestCategoryId)
        {
            return (from x in _context.TestCategory
                    where x.TestCategoryId == TestCategoryId
                    select new TestCategoryVM
                    {
                        testCategoryId = x.TestCategoryId,
                        categoryName = x.CategoryName,
                        createdBy = x.CreatedBy,
                        dateCreated = x.DateCreated,
                        isDelete = x.IsDelete
                    }).FirstOrDefault();
        }

        public bool UpdateTestCategory(TestCategoryVM model)
        {
            var category = _context.TestCategory.Find(model.testCategoryId);

            if(category == null) throw new Exception("Record not found");

            category.CategoryName = model.categoryName;
            category.CreatedBy = model.createdBy;

            return _context.SaveChanges() > 0;
            
        }
    }
}
