using cbt.Common;
//using cbt.Common.Enum;
using cbt.dbEntity.Model;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;             
using System.Text;
using System.Threading.Tasks;

namespace cbt.Report
{
    public class ScoreSheet
    {
        CBTcontext _context = new CBTcontext();


        public IEnumerable< ScoresheetVM> getProspectiveStudentDetails(int psid)
        {
            var studDetails = (from m in _context.Signup
                                   //join n in _context.State on m.City equals n.Id

                               where m.Psid == psid
                               select new ScoresheetVM
                               {
                                   FirstName = m.FirstName + " " + m.MiddleName + " " + m.LastName,
                                   Email = m.Email,
                                   DOB = m.DOB,
                                   MobileNo = m.MobileNo,
                                   City = _context.State.Where(x => x.Id == m.City).Select(z => z.Name).FirstOrDefault(),// n.Name,
                                   COR = m.COR,
                                   dateTaken = m.ExamDate,
                                   NOI = m.NOI,
                                   Designation = m.Designation

                        

                    }).ToList();



            return studDetails;
        }

        


        public IEnumerable<ScoresheetVM> getIntrovert(int psid)
        {

            if (psid == 0) throw new Exception("Not a Valid User");

            var getScore = (from s in _context.TestResult
                            join tc in _context.TestCategory on s.TestCategoryId equals tc.TestCategoryId
                            where s.Psid == psid && s.TestCategoryId == (int)Category.IntrovertExtrovert
                            select new ScoresheetVM
                            {
                                questionBankId = s.QuestionBankId,
                                answer = s.Answer,
                                altanswer = s.Altanswer
                            }).ToList();

            return getScore;

        }


        public IEnumerable<ScoresheetVM> getSensitive(int psid)
        {

            if (psid == 0) throw new Exception("Not a valid user");

            var getScore = (from s in _context.TestResult
                            join tc in _context.TestCategory on s.TestCategoryId equals tc.TestCategoryId
                            where s.Psid == psid && s.TestCategoryId == (int)Category.SensitiveIntuitive
                            select new ScoresheetVM
                            {
                                questionBankId = s.QuestionBankId,
                                answer = s.Answer,
                                altanswer = s.Altanswer
                            }).ToList();

            return getScore;

        }

        public IEnumerable<ScoresheetVM> getThinking(int psid)
        {

            if (psid == 0) throw new Exception("Not a valid user");

            var getScore = (from s in _context.TestResult
                            join tc in _context.TestCategory on s.TestCategoryId equals tc.TestCategoryId
                            where s.Psid == psid && s.TestCategoryId == (int)Category.ThinkingFeeling
                            select new ScoresheetVM
                            {
                                questionBankId = s.QuestionBankId,
                                answer = s.Answer,
                                altanswer = s.Altanswer
                            }).ToList();

            return getScore;

        }

        public IEnumerable<ScoresheetVM> getJudging(int psid)
        {

            if (psid == 0) throw new Exception("Not a valid user");

            var getScore = (from s in _context.TestResult
                            join tc in _context.TestCategory on s.TestCategoryId equals tc.TestCategoryId
                            where s.Psid == psid && s.TestCategoryId == (int)Category.JudgingPercieving
                            select new ScoresheetVM
                            {
                                questionBankId = s.QuestionBankId,
                                answer = s.Answer,
                                altanswer = s.Altanswer
                            }).ToList();

            return getScore;

        }


        public List<Ratings> Rating(int psid)
        {

             List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);

           

            var  extrovert =   countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            //   Rating = ieresult + siResult + tfResult + jpresult;

            //  return Rating.ToList();

           // string rate = ieresult + siResult + tfResult + jpresult;
            Ratingm.Add(sss);

            return Ratingm.ToList();

        }




        public IEnumerable<ExplicitRating> explicitValue(int psid)
        {

            List<ExplicitRating>    stat = new List<ExplicitRating>();

          
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var statistic = new ExplicitRating
            {
                Ext = extrovert.ToString(),
                Intro = introvert,
                Sen = sensing,
                Intu = intu,
                Thi = thinking,
                Feel = feeling,
                Jud = judging,
                Per = percieving
            };

            stat.Add(statistic);

            return stat;
        }


        public List<CharacteristicVM> getCharacteristics(int psid)
        {

            List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            string mmm = ieresult + siResult + tfResult + jpresult;

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            Ratingm.Add(sss);

            var getkey = (from m in _context.Characteristic

                          where m.Rating == mmm && m.Key == "Strengths"

                          select new CharacteristicVM
                          {
                                                       
                              Quality = m.Quality
                          }).ToList();

                       return getkey;



         



        }



        public List<CharacteristicVM> getKeyCharacteristics(int psid)
        {

            List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            string mmm = ieresult + siResult + tfResult + jpresult;

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            Ratingm.Add(sss);

            var getkey = (from m in _context.Characteristic

                          where m.Rating == mmm && m.Key == "Key  Characteristics"

                          select new CharacteristicVM
                          {

                              Keyquality = m.Quality
                          }).ToList();

            return getkey;



        }


        public List<CharacteristicVM> getRelationship(int psid)
        {
            List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            string mmm = ieresult + siResult + tfResult + jpresult;

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            Ratingm.Add(sss);

            var getkey = (from m in _context.Characteristic

                          where m.Rating == mmm && m.Key == "Relationships"

                          select new CharacteristicVM
                          {

                              Relative = m.Quality
                          }).ToList();

            return getkey;


        }


        public List<CharacteristicVM> getPotentials(int psid)
        {
            List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            string mmm = ieresult + siResult + tfResult + jpresult;

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            Ratingm.Add(sss);

            var getkey = (from m in _context.Characteristic

                          where m.Rating == mmm && m.Key == "Potential Dvelopment Areas "

                          select new CharacteristicVM
                          {

                              Potentials = m.Quality
                          }).ToList();

            return getkey;


        }

        public List<CharacteristicVM> getIdeas(int psid)
        {
            List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            string mmm = ieresult + siResult + tfResult + jpresult;

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            Ratingm.Add(sss);

            var getkey = (from m in _context.Characteristic

                          where m.Rating == mmm && m.Key == "Careers ideas"

                          select new CharacteristicVM
                          {

                              Ideas = m.Quality
                          }).ToList();

            return getkey;


        }

        public List<CharacteristicVM> getStress(int psid)
        {
            List<Ratings> Ratingm = new List<Ratings>();
            var countIntrovert = getIntrovert(psid);

            var countSensing = getSensitive(psid) == null ? null : getSensitive(psid);

            var countThinking = getThinking(psid);

            var countJudging = getJudging(psid);



            var extrovert = countIntrovert.Where(x => x.answer != null).Count();

            var introvert = countIntrovert.Where(x => x.altanswer != null).Count();// == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            //var introvert = countIntrovert.Where(x => x.altanswer.Equals("X")).Count() == 0 ? 0 : countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            var sensing = countSensing.Where(x => x.answer != null).Count();

            var intu = countSensing.Where(x => x.altanswer != null).Count();

            var thinking = countThinking.Where(x => x.answer != null).Count();

            var feeling = countThinking.Where(x => x.altanswer != null).Count();

            var judging = countJudging.Where(x => x.answer != null).Count();

            var percieving = countJudging.Where(x => x.altanswer != null).Count();


            var ieresult = extrovert > introvert == true ? "E" : "I";

            var siResult = sensing > intu == true ? "S" : "N";

            var tfResult = thinking > feeling == true ? "T" : "F";

            var jpresult = judging > percieving == true ? "J" : "P";

            string mmm = ieresult + siResult + tfResult + jpresult;

            var sss = new Ratings
            {
                Rating = ieresult + siResult + tfResult + jpresult
            };

            Ratingm.Add(sss);

            var getkey = (from m in _context.Characteristic

                          where m.Rating == mmm && m.Key == "Stress Management"

                          select new CharacteristicVM
                          {

                              Stress = m.Quality
                          }).ToList();

            return getkey;


        }

        public int getExtrovertCount(int psid)
        {
            var countIntrovert = getIntrovert(psid);



            var b = countIntrovert.Where(x => x.altanswer.Equals("X")).Count();

            return b;

        }



    }
}
