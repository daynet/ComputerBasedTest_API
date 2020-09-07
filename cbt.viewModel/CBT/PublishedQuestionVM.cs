using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
    public class PublishedQuestionVM
    {
        public int PublishedQuestionId { get; set; }

        public int? QuestionId { get; set; }

        public int? TestSetupId { get; set; }
    }
}
