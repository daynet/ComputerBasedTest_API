using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class PublishedQuestionRepository : IPublishQuestionRepository
    {

        private CBTcontext _context;


        public PublishedQuestionRepository(CBTcontext context)
        {
            _context = context;
        }

        public bool deletePublishedQuestion(int PublishedQuestionId)
        {
            if (PublishedQuestionId == 0) throw new Exception("There is nothing to delete!");

            var publishQuestion = _context.PublishedQuestion.Find(PublishedQuestionId);

            if (publishQuestion == null) throw new Exception("Record not found");

            _context.PublishedQuestion.Remove(publishQuestion);

            return _context.SaveChanges() > 0;
        }
    }
}
