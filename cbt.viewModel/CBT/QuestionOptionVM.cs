using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
    public class QuestionOptionVM : CommonVM
    {
        public int quetionOptionId { get; set; }

        public int? optionTypeId { get; set; }

        public int? questionBankId { get; set; }

        public string quetionOptionName { get; set; }
    }
}
