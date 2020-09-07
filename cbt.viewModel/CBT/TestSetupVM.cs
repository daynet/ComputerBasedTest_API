using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
   public class TestSetupVM
   {

        public int TestSetupId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? StopTime { get; set; }

        public bool? DisplayResult { get; set; }

        public IEnumerable<QuestionBankVM> QuestionBankIds { get; set; }
    }
}
