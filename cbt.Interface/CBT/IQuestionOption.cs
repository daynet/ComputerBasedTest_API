using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IQuestionOption
    {
        bool AddQuestionOption(QuestionOptionVM model);

        QuestionOptionVM GetQuestionOptionById(int QuestionOptionId);

        IEnumerable<QuestionOptionVM> GetQuestionOption();

        bool UpdateQuestionOption(QuestionOptionVM model);

        bool deleteQuestionOption(int QuestionOptionId);


    }
}
