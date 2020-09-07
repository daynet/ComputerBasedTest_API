using cbt.viewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
    public class ScoresheetVM :CommonVM
    {
        public int Psid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string name
        {
            get  { return (FirstName + "  " + MiddleName + " " + LastName).ToString(); }
          //  { get { return (this.maturityDate - this.effectiveDate).Days; } }
            }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public DateTime? DOB { get; set; }

        public string Program { get; set; }

        public string Address { get; set; }

        public string COR { get; set; }

        public string City { get; set; }

        public string Designation { get; set; }

        public string NOI { get; set; }

        public int testResultId { get; set; }
        
        public int? questionBankId { get; set; }
        public string answer { get; set; }
        public string altanswer { get; set; }
        public int? testCategoryId { get; set; }
        public string dateTaken { get; set; }
        public TimeSpan? startTime { get; set; }
        public TimeSpan? finishTime { get; set; }

    }
}
