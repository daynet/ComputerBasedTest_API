using cbt.Common;
using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class QuestionBankRepository : IQuestionBank
    {
        private CBTcontext _context;
        public QuestionBankRepository(CBTcontext context)
        {
            _context = context;

        }

        public bool AddQuestion(QuestionBankVM model)
        {
            if (model == null) throw new Exception("There is no Entry!"); 

            var addQuestion = new QuestionBank
            {
                Question = model.question,
                CreatedBy = model.createdBy,
                IsDeleted = model.isDeleted,
                TestCategoryId = model.testCategoryId,
                DateOfDeletion = model.dateOfDeletion,
                DeletedBy = model.deletedBy,
                OptionA = model.optionA,
                OptionB =model.optionB
            };

         var que =   _context.QuestionBank.Add(addQuestion);

            if (_context.SaveChanges() > 0)
            {
                _context.QuestionOption.Add(new QuestionOption { QuestionBankId = que.QuestionBankId, QuetionOptionName = model.optionA, OptionLabel="A" });
                _context.QuestionOption.Add(new QuestionOption { QuestionBankId = que.QuestionBankId, QuetionOptionName = model.optionB, OptionLabel="B" });

            }
            return _context.SaveChanges() > 0;

        }

        public async Task<IEnumerable<QuestionBankVM>> GetQuestions()
        {

            var getQuestions = await (from q in _context.QuestionBank
                                select new QuestionBankVM
                                {
                                    questionBankId = q.QuestionBankId,
                                    question = q.Question,
                                    createdBy = q.CreatedBy,
                                    testCategoryId =q.TestCategoryId,
                                    testCategory = _context.TestCategory.Where(o => o.TestCategoryId == q.TestCategoryId).Select(o => o.CategoryName).FirstOrDefault(),
                                    dateOfDeletion = q.DateOfDeletion,
                                    deletedBy = q.DeletedBy,
                                    TestCategoryName = _context.TestCategory.Where(o=>o.TestCategoryId==q.TestCategoryId).Select(o=>o.CategoryName).FirstOrDefault(),

                                }).ToListAsync();

            foreach (var item in getQuestions)
            {
                item.questionOption = _context.QuestionOption.Where(o => o.QuestionBankId == item.questionBankId).Select(o => new QuestionOptionVM { quetionOptionId = o.QuetionOptionId, questionBankId = o.QuestionBankId, quetionOptionName = o.QuetionOptionName, optionTypeId = o.OptionTypeId }).ToList();
            }

            return getQuestions;

        }

        public bool UpdateQuestion(QuestionBankVM model)
        {
            var question = _context.QuestionBank.Find(model.questionBankId);
            if(question == null) throw new Exception("Record not found");

            question.Question = model.question;
            question.CreatedBy = model.createdBy;
            question.TestCategoryId = model.testCategoryId;
            question.DateOfDeletion = model.dateOfDeletion;
            question.DeletedBy = model.deletedBy;
            question.OptionA = model.optionA;
            question.OptionB = model.optionB;
           return _context.SaveChanges() > 0;




        }

        public bool DeleteQuestion(int QuestionBankId)
        {
            
            if (QuestionBankId == 0) throw new Exception("There is nothing to delete!");

            var question = _context.QuestionBank.Find(QuestionBankId);

            if (question == null) throw new Exception("Record not found");

            _context.QuestionBank.Remove(question);

            return _context.SaveChanges() > 0;
        }

        public bool DeleteMultipleQuestion(int QuestionBankId, int[] indexOfQuestions)
        {
            if (QuestionBankId == 0) throw new Exception("There is nothing to delete!");


            var questions = _context.QuestionBank.Where(x => x.QuestionBankId == QuestionBankId);

            //  var res = questions.Contains(indexOfQuestions[]);

            return _context.SaveChanges() > 0;
        }


        public async Task<QuestionBankVM> GetQuestionsById(int questionBankId)
        {
            var getQuestions = await (from q in _context.QuestionBank
                                where q.QuestionBankId == questionBankId
                                select new QuestionBankVM
                                {
                                    question = q.Question,
                                    createdBy = q.CreatedBy,
                                    questionBankId = q.QuestionBankId,
                                    testCategoryId = q.TestCategoryId,
                                    testCategory = _context.TestCategory.Where(o => o.TestCategoryId == q.TestCategoryId).Select(o => o.CategoryName).FirstOrDefault(),
                                    dateOfDeletion = q.DateOfDeletion,
                                    deletedBy = q.DeletedBy,
                                    optionA = _context.QuestionOption.Where(x => x.QuestionBankId == q.QuestionBankId && x.OptionLabel == "A").Select(x => x.QuetionOptionName).FirstOrDefault(),
                                    optionB = _context.QuestionOption.Where(x => x.QuestionBankId == q.QuestionBankId && x.OptionLabel == "B").Select(x => x.QuetionOptionName).FirstOrDefault(),
                                    TestCategoryName = _context.TestCategory.Where(o => o.TestCategoryId == q.TestCategoryId).Select(o => o.CategoryName).FirstOrDefault()

                                }).FirstOrDefaultAsync();

            return getQuestions;

            //return (from x in _context.QuestionBank
            //        where x.QuestionBankId == QuestionBankId
            //        select new QuestionBankVM
            //        {
            //            question = x.Question,
            //            questionBankId = x.QuestionBankId,
            //            createdBy = x.CreatedBy,
            //            testCategory = _context.TestCategory.Where(o => o.TestCategoryId == x.TestCategoryId).Select(o => o.CategoryName).FirstOrDefault(),
            //            testCategoryId=x.TestCategoryId,
            //            dateOfDeletion = x.DateOfDeletion,
            //            deletedBy = x.DeletedBy,
            //            optionA = x.OptionA,
            //            optionB = x.OptionA
            //        }).FirstOrDefault();

        }



        public async Task<IEnumerable<QuestionBankVM>> GetTestQuestion()
        {

            var getQuestions = await (from q in _context.QuestionBank
                                select new QuestionBankVM
                                {
                                    question = q.Question,
                                    createdBy = q.CreatedBy,
                                    questionBankId = q.QuestionBankId,
                                    testCategoryId = q.TestCategoryId,
                                    testCategory = _context.TestCategory.Where(o => o.TestCategoryId == q.TestCategoryId).Select(o => o.CategoryName).FirstOrDefault(),
                                    dateOfDeletion = q.DateOfDeletion,
                                    deletedBy = q.DeletedBy,
                                    optionA = _context.QuestionOption.Where(x=>x.QuestionBankId==q.QuestionBankId && x.OptionLabel == "A").Select(x=>x.QuetionOptionName).FirstOrDefault(),
                                    optionB = _context.QuestionOption.Where(x => x.QuestionBankId == q.QuestionBankId && x.OptionLabel=="B").Select(x => x.QuetionOptionName).FirstOrDefault(),
                                    TestCategoryName = _context.TestCategory.Where(o => o.TestCategoryId == q.TestCategoryId).Select(o => o.CategoryName).FirstOrDefault()

                                }).ToListAsync();

            return getQuestions;

        }

        public bool SendMail(SignupVM signupvm)
        {

            
            string messageContent = $"Dear {signupvm.FirstName + " " + signupvm.LastName}, <br /><br />" +
                                    "Thank you for your interest. <br />" +
                                    "Your Exam ID is: " + signupvm.Psid +
                                      " <br />You could get in touch with the marketing team on +2348181111113" +
                                      ", 9087560003, 9087559914 to schedule your counselling appointment. <br /><br />" +
                                      "Best Regards, <br /><br />" +
                                      "Skyline University Nigeria.";
            if (signupvm.Psid != 0)
            {
                SendEmailAPI.SendEmail("", signupvm.Email, "OTP from Skyline University NIgeria", messageContent, "");
                return true;
            }
            else
            {
                return false;
            }

           

        }

}


        

}
