using cbt.Common;
using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace cbt.repository.CBT
{
    public class SignupRepository : ISignupRepository
    {

        private CBTcontext _context;
        private string displayName = ConfigurationManager.AppSettings["emailDisplayName"];
        private string fromEmail = ConfigurationManager.AppSettings["Username"];
        private string password = ConfigurationManager.AppSettings["Password"];
        private string smtpclient = ConfigurationManager.AppSettings["smtpClient"];
        private string enableSsl = ConfigurationManager.AppSettings["enableSsl"];
        private string postNumber = ConfigurationManager.AppSettings["smtpPort"];
        private string requireCredential = ConfigurationManager.AppSettings["smtpPort"];
        private string otpExpiration = ConfigurationManager.AppSettings["otpExpirationInMinutes"];
        private string smsUsername = ConfigurationManager.AppSettings["smsUsername"];
        private string smsPassword = ConfigurationManager.AppSettings["smsPassword"];
        private string school = ConfigurationManager.AppSettings["skyline"];
        private string server = ConfigurationManager.AppSettings["server"];
        private string port = ConfigurationManager.AppSettings["port"];
        SendSMSAPI sendSMSAPI = new SendSMSAPI();
        WireSMSAPI wireSMSAPI = new WireSMSAPI();
        HttpClient client = new HttpClient();


        public SignupRepository(CBTcontext context)
        {
            _context = context;


        }

        //public Signup AddProspectiveStudentEntry(SignupVM model)
        //{
        //    if (model == null) throw new Exception("There is no Entry!");

        //    Random generator = new Random();
        //    String token = generator.Next(0, 999999).ToString("D6");

        //    var emailExist = _context.Signup.Any(o => o.Email == model.Email);

        //    if(emailExist == true) throw new Exception("This Email is already register, request for OTP to continue.");

        //    var studentProfile = new Signup
        //    {
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        MiddleName = model.MiddleName,
        //        MobileNo = model.MobileNo,
        //        Email = model.Email,
        //        DOB = model.DOB,
        //        Program = model.Program,
        //        Address = model.Address,
        //        COR = model.COR,
        //        City = model.City,
        //        Designation = model.Designation,
        //        NOI = model.NOI,
        //        Token = token,
        //        TokenExpirationDate = DateTime.Now,
        //        ExamDate = model.ExamDate

        //    };



        //   var user = _context.Signup.Add(studentProfile);

        //    string messageContent = $"Dear {user.FirstName + " " + user.LastName}, <br /><br />" +
        //                             "Thank you for your interest. <br />" +
        //                             "Kindly enter this token : " + token + " to complete your registration";

        //    if (_context.SaveChanges() > 0)
        //    {
        //        SendEmailAPI.SendEmail("", user.Email, "OTP from Skyline University NIgeria", messageContent, "");
        //        sendSMSAPI.SendSMS(smsUsername, smsPassword, user.MobileNo, messageContent, "SMS");
        //    }
        //    return user;

        //}

        public Signup AddProspectiveStudentEntry(SignupVM model)
        {
            if (model == null) throw new Exception("There is no Entry!");

            var username = _context.Signup.Where(x => x.UserName == model.UserName).FirstOrDefault();

            if (username == null)
            {

                Random generator = new Random();
                String token = generator.Next(0, 999999).ToString("D6");

                string tokenizer = generator.Next(0, 9999).ToString("D4");

                var emailExist = _context.Signup.Any(o => o.Email == model.Email);

                // if (emailExist == true) throw new Exception("This Email is already registered, request for OTP to continue.");
                if (emailExist == true) throw new Exception("This Email is already registered");

                var studentProfile = new Signup
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    MobileNo = model.MobileNo,
                    Email = model.Email,
                    DOB = model.DOB,
                    Program = model.Program,
                    Address = model.Address,
                    COR = model.COR,
                    City = model.City,
                    Designation = model.Designation,
                    NOI = model.NOI,
                    Token = token,
                    TokenExpirationDate = DateTime.Now,
                    ExamDate = model.ExamDate,
                    State = model.State,
                    UserName = model.UserName == null ? tokenizer : model.UserName,
                    SchoolID = model.SchoolID,
                    Levels = model.Levels


                };



                var user = _context.Signup.Add(studentProfile);

                string messageContent = $"Dear {user.FirstName + " " + user.LastName}, <br /><br />" +
                                         "Thank you for your interest. <br />" +
                                         "Kindly enter this token : " + token + " to complete your registration";

                if (_context.SaveChanges() > 0)
                {
                    var mobile = "234" + user.MobileNo;
                    SendEmailAPI.SendEmail("", user.Email, "OTP from Skyline University NIgeria", messageContent, "");

                    var url = "http://ngn.rmlconnect.net:8080/bulksms/bulksms?" + "username=" + smsUsername + "&password=" + smsPassword + "&source=" + school + "&destination=" + mobile + "&type=" + 0 + "&dlr=" + 1 + "&message=your token is:" + token;

                    var r = client.GetAsync(url).Result;
                    if (r.IsSuccessStatusCode == true) { }


                }

                return user;
            }
            else
            {
                throw new Exception("You have already taken the test");
            }

        }

        public IEnumerable<ScoresheetVM> getProspectiveStudentDetails()
        {
            var studDetails = (from m in _context.Signup
                               join n in _context.State on m.City equals n.Id
                               join c in _context.Course on m.Program equals c.CourseId


                               select new ScoresheetVM
                               {
                                   FirstName = m.FirstName + " " + m.MiddleName + " " + m.LastName,
                                   Email = m.Email,
                                   DOB = m.DOB,
                                   MobileNo = m.MobileNo,
                                   City = n.Name,
                                   COR = m.COR,
                                   dateTaken = m.ExamDate,
                                   NOI = m.NOI,
                                   Designation = m.Designation,
                                   Program = c.CourseName,
                                   Address = m.Address,
                                   Psid = m.Psid


                               }).ToList();



            return studDetails;
        }

        public int ValidateOTP(string otp, int psid)
        {
            int otpExp = 0;
            var user = _context.Signup.Find(psid);
            if (user == null) throw new Exception("Sorry you did not register!");

            if (user.Token != otp) throw new Exception("Invalid OTP!");

            if (!string.IsNullOrEmpty(otpExpiration))
            {
                otpExp = Convert.ToInt32(otpExpiration);
            }
            if (DateTime.Now > user.TokenExpirationDate.AddMinutes(otpExp)) throw new Exception("OTP has expired");

            return user.Psid;

        }

        public bool ResendOTP(string email, string phoneNumber)
        {
            var user = _context.Signup.Where(o => o.Email == email).Select(o => o).FirstOrDefault();

            if (user == null) throw new Exception("Sorry you did not register, Kindly signup!");

            Random generator = new Random();
            String token = generator.Next(0, 999999).ToString("D6");

            user.Token = token;
            user.TokenExpirationDate = DateTime.Now;

            string messageContent = $"Dear {user.FirstName + " " + user.LastName}, <br /><br />" +
                                     "Thank you for your interest. <br />" +
                                     "Kindly enter this token : " + token + " to complete your registration";

            if (_context.SaveChanges() > 0)
            {
                SendEmailAPI.SendEmail("", user.Email, "OTP from Skyline University NIgeria", messageContent, "");
                sendSMSAPI.SendSMS(smsUsername, smsPassword, user.MobileNo, messageContent, "SMS");

                return true;
            }

            return false;

        }

        public bool SendEmails(string userEmail, string userName, string token)
        {
            try
            {

                using (SmtpClient client = new SmtpClient())
                {
                    client.Port = Convert.ToInt32(postNumber);

                    client.EnableSsl = Convert.ToBoolean(enableSsl);

                    client.Host = smtpclient;

                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.UseDefaultCredentials = false;

                    if (!string.IsNullOrEmpty(requireCredential))
                    {
                        if (Convert.ToBoolean(requireCredential) == true)
                        {
                            client.Credentials = new System.Net.NetworkCredential(fromEmail, password);
                        }

                    }

                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(fromEmail, displayName);
                    mail.IsBodyHtml = true;

                    mail.Subject = "OTP from Skyline University NIgeria";

                    string messageContent = $"Dear {userName}, <br /><br />" +
                                     "Thank you for filling this form <br />" +
                                     "Kindly validate your registration with this OTP : " + token;

                    mail.Body = messageContent;

                    mail.To.Add(userEmail);


                    try
                    {
                        client.Send(mail);

                    }
                    catch (Exception ex)
                    {
                        ///  throw new SecureException("Error : " + ex);
                    }


                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool isCounsel(SignupVM signup)
        {
            if (signup.Psid == 0) throw new Exception("There is nothing to update!");
            var id = _context.Signup.Find(signup.Psid);

            if (id == null) throw new Exception("This is not a valid psid");


           // if (id.isCounsel == signup.isCounsel) throw new Exception("There is nothing to update");


            id.isCounsel = signup.isCounsel;
            id.isContact = signup.isContact;
            



            return _context.SaveChanges() > 0;




        }


       public School createSchool(SchoolVM model)
       {
            if (model == null) throw new Exception("no data submitted");

            var isSchoolAvailable = (from m in _context.School
                                     where m.SchoolID == model.SchoolID select m).FirstOrDefault();


           


            if(isSchoolAvailable != null) throw new Exception("This school is already registered");
            
                var newSchool = new School()
                {
                    SchoolName = model.SchoolName
                };

                _context.School.Add(newSchool);
            _context.SaveChanges();
         
            return newSchool;
       }




        public IEnumerable<SchoolVM> getSchools()
        {

            var schoollist = (from m in _context.School

                              select new SchoolVM()
                              {
                                  SchoolID = m.SchoolID,
                                  SchoolName = m.SchoolName
                              }).ToList();

            return schoollist;
        }

    }
}
