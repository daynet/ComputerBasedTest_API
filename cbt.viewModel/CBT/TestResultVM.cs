using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
  public  class TestResultVM
    {
        public int testResultId { get; set; }
        public int? psid { get; set; }
        public int? questionBankId { get; set; }
        public string answer { get; set; }
        public int? testCategoryId { get; set; }
        public DateTime? dateTaken { get; set; }
        public TimeSpan? startTime { get; set; }
        public TimeSpan? finishTime { get; set; }
        public string altAnswer { get; set; }
    }
}
