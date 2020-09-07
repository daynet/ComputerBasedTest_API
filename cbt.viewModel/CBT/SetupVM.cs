using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbt.viewModel.CBT
{
  public class SetupVM
  {
  }

    public class Courses
    {
        public int courseId { get; set; }

        public string courseName { get; set; }

    }

    public class StateVM
    {
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string CreatedUser { get; set; }

        public string Name { get; set; }
    }

    public class Saturdays
    {
        public DateTime saturday { get; set; }
    }



    public class Ratings
    {
        public string Rating { get; set; }
    }

    public class ExplicitRating
    {
        public string Ext { get; set; }
        public int Intro { get; set; }
        public int Sen { get; set; }
        public int Intu { get; set; }
        public int Thi { get; set; }
        public int Feel { get; set; }
        public int Jud { get; set; }
        public int Per { get; set; }


    }


    public class CharacteristicVM
    {
        public int CharacteristicId { get; set; }


        public string Rating { get; set; }

        public string Quality { get; set; }

        public string Keyquality { get; set; }
        public string Relative { get; set; }
        public string Potentials { get; set; }
        public string Ideas { get; set; }
        public string Stress { get; set; }


        public string Key { get; set; }



    }
}
