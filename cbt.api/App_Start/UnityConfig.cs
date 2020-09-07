using Authentication.Athen;
using cbt.dbEntity.Model;
using cbt.Interface.CBT;
using cbt.Report.IReport;
using cbt.Report.ReportCall;
using cbt.repository.CBT;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace cbt.api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<CBTcontext, CBTcontext>();
            container.RegisterType<IAuthRepository, AuthRepository>();
            container.RegisterType<ICorrectAnswerRepository, CorrectAnswerRepository>();
            container.RegisterType<ITestCategoryRepository, TestCategoryRepository>();
              container.RegisterType<ISecurityManager, SecurityManager>();
            container.RegisterType<IRegisterUserRepository, RegisterUserRepository>();
            container.RegisterType<IQuestionBank, QuestionBankRepository>();
            container.RegisterType<ISignupRepository, SignupRepository>();
            container.RegisterType<ICourse, CourseRepository>();
            container.RegisterType<ITestResultRepository, TestResultRepository>();
            container.RegisterType<IReporting, ReportRoute>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}