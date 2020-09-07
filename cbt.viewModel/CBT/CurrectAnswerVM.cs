using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
  public  class CorrectAnswerVM : CommonVM
    {
        public int correctAnswerId { get; set; }

        public int questionBankId { get; set; }

        public int questionOptionId { get; set; }

        public int questionOptionTypeId { get; set; }
        public string quetionBank { get; set; }
        public string questionOption { get; set; }
    }
}
