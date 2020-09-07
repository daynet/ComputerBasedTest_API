using cbt.viewModel.CBT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Interface.CBT
{
    public interface ICourse
    {
        IEnumerable<Courses> getCourse();

        IEnumerable<NationalityVM> getNationality();

        IEnumerable<StateVM> getState();

        List<DateTime> getSaturdays();
        
    }
}
