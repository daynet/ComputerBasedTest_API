using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
    public class QuestionBankVM : CommonVM
    {
        public int questionBankId { get; set; }

        public int questionTypeId { get; set; }

     
        public string question { get; set; }

        public int testCategoryId { get; set; }

  
        public string createdBy { get; set; }

        public DateTime? dateOfCreation { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? dateOfDeletion { get; set; }
        public string optionA { get; set; }
        public string optionB { get; set; }

        public IEnumerable< QuestionOptionVM> questionOption { get; set; }

        public string deletedBy { get; set; }
        public string testCategory { get; set; }
        public string TestCategoryName { get; set; }


    }


}
