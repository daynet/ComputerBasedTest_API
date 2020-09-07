using cbt.viewModel.CBT;
using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface IQuestionBank
    {
        bool AddQuestion(QuestionBankVM model);

        Task<QuestionBankVM> GetQuestionsById(int QuestionBankId);

        Task<IEnumerable<QuestionBankVM>> GetQuestions();

        bool UpdateQuestion(QuestionBankVM model);

        bool DeleteQuestion(int QuestionBankId);

        bool DeleteMultipleQuestion(int QuestionBankId, int[] indexOfQuestions);

        Task<IEnumerable<QuestionBankVM>> GetTestQuestion();

        bool SendMail(SignupVM signupvm);
    }
}
