using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
   public class QuestionOptionRepository: IQuestionOption
    {
        private CBTcontext _context;
        public QuestionOptionRepository(CBTcontext context)
        {
            _context =  context;
        }
        public bool AddQuestionOption(QuestionOptionVM model)
        {

            if (model == null) throw new Exception("There is no Entry!");

            var qOption = new QuestionOption
            {
                QuetionOptionName = model.quetionOptionName
            };

            _context.QuestionOption.Add(qOption);

            return _context.SaveChanges() > 0;
        }


       
        public bool deleteQuestionOption(int QuestionOptionId)
        {
            if (QuestionOptionId == 0) throw new Exception("There is nothing to delete!");

            var qOption = _context.QuestionOption.Find(QuestionOptionId);

            if (qOption == null) throw new Exception("Record not found");

            _context.QuestionOption.Remove(qOption);

            return _context.SaveChanges() > 0;
        }

        public IEnumerable<QuestionOptionVM> GetQuestionOption()
        {
            return (from x in _context.QuestionOption
                    select new QuestionOptionVM
                    {
                        quetionOptionName = x.QuetionOptionName
                    });
        }

        public QuestionOptionVM GetQuestionOptionById(int QuestionOptionId)
        {
            return (from x in _context.QuestionOption
                    where x.QuetionOptionId == QuestionOptionId
                    select new QuestionOptionVM
                    {
                      quetionOptionName = x.QuetionOptionName
                    }).FirstOrDefault();
        }

        public bool UpdateQuestionOption(QuestionOptionVM model)
        {
            var qOption = _context.QuestionOption.Find(model.quetionOptionId);

            if (qOption == null) throw new Exception("Record not found");

            qOption.QuetionOptionName = model.quetionOptionName;
         

            return _context.SaveChanges() > 0;

        }

    }
}
