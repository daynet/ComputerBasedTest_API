using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
   public class TestCategoryVM : CommonVM
    {
        public int testCategoryId { get; set; }

        public string categoryName { get; set; }

        public DateTime? dateCreated { get; set; }

        public string createdBy { get; set; }

        public bool? isDelete { get; set; }

        public DateTime? dateOfDeletion { get; set; }

        public String deletedBy { get; set; }
    }
}
