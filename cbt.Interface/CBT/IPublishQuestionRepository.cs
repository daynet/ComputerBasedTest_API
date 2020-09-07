using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IPublishQuestionRepository
    {
        bool deletePublishedQuestion(int PublishedQuestionId);
       

    }
}
