using cbt.Interface.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cbt.viewModel.CBT;
using cbt.dbEntity.Model;

namespace cbt.repository.CBT
{
   public class CorrectAnswerRepository : ICorrectAnswerRepository
    {
        private CBTcontext _context;
        public CorrectAnswerRepository(CBTcontext context)
        {
            _context = context;
        }

        public bool AddCorrectAnswer(CorrectAnswerVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var answer = new CorrectAnswer
            {
                QuestionBankId = model.questionBankId,
                QuestionOptionId = model.questionOptionId,
                QuestionOptionTypeId = model.questionOptionTypeId,
            };

            _context.CorrectAnswer.Add(answer);

            return _context.SaveChanges() > 0;
        }

        public bool DeleteCorrectAnswer(int CurrectAnswerId)
        {
            if (CurrectAnswerId == 0) throw new Exception("There is nothing to delete!");

          var answer =  _context.CorrectAnswer.Find(CurrectAnswerId);

            if (answer == null) throw new Exception("No record found!");

            _context.CorrectAnswer.Remove(answer);

            if (_context.SaveChanges() > 0)
                return true;

            return false;
        }

        public CorrectAnswerVM GetCorrectAnswer(int CurrectAnswerId)
        {
            return (from x in _context.CorrectAnswer
                    where x.CorrectAnswerId == CurrectAnswerId
                    select new CorrectAnswerVM {
                        correctAnswerId = x.CorrectAnswerId,
                        questionBankId = x.QuestionBankId,
                        quetionBank = _context.QuestionBank.Where(o=>o.QuestionBankId==x.QuestionBankId).Select(o=>o.Question).FirstOrDefault(),
                        questionOptionId = x.QuestionOptionId,
                        questionOption = _context.QuestionOption.Where(o=>o.QuetionOptionId==x.QuestionOptionId).Select(o=>o.QuetionOptionName).FirstOrDefault(),
                        questionOptionTypeId = x.QuestionOptionTypeId,
                       // questionOptionType = _context.qu

                    }).FirstOrDefault();
        }

        public IEnumerable<CorrectAnswerVM> GetTestCorrectAnswers()
        {
            return (from x in _context.CorrectAnswer
                    select new CorrectAnswerVM
                    {
                        correctAnswerId = x.CorrectAnswerId,
                        questionBankId = x.QuestionBankId,
                        quetionBank = _context.QuestionBank.Where(o => o.QuestionBankId == x.QuestionBankId).Select(o => o.Question).FirstOrDefault(),
                        questionOptionId = x.QuestionOptionId,
                        questionOption = _context.QuestionOption.Where(o => o.QuetionOptionId == x.QuestionOptionId).Select(o => o.QuetionOptionName).FirstOrDefault(),
                        questionOptionTypeId = x.QuestionOptionTypeId,
                        // questionOptionType = _context.qu

                    }).ToList();
        }

        public bool UpdateCorrectAnswer(CorrectAnswerVM model)
        {
            var answer = _context.CorrectAnswer.Find(model.correctAnswerId);

            if (answer == null) throw new Exception("Record not found");

            answer.QuestionBankId = model.questionBankId;
            answer.QuestionOptionId = model.questionOptionId;

            return _context.SaveChanges() > 0;
        }
    }
}
