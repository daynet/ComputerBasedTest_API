using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface ICorrectAnswerRepository
    {
        bool AddCorrectAnswer(CorrectAnswerVM model);

        CorrectAnswerVM GetCorrectAnswer(int CurrectAnswerId);

        IEnumerable<CorrectAnswerVM> GetTestCorrectAnswers();

        bool UpdateCorrectAnswer(CorrectAnswerVM model);

        bool DeleteCorrectAnswer(int CurrectAnswerId);
    }
}
