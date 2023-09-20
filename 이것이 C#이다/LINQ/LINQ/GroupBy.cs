using System;
using System.Linq;

namespace GroupBy
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){Name="A", Height = 186 },
                new Profile(){Name="B", Height = 158},
                new Profile(){Name="C", Height = 172},
                new Profile(){Name="D", Height = 178},
                new Profile(){Name="E", Height = 171},
            };

            var listProfile = from profile in arrProfile
                              orderby profile.Height
                              group profile by profile.Height < 175 into g
                              select new { GroupKey = g.Key, Profils = g };

            foreach (var Group in listProfile)
            {
                Console.WriteLine($"175cm 미만? : {Group.GroupKey}");

                foreach (var profile in Group.Profils)
                {
                    Console.WriteLine($">>> {profile.Name}, {profile.Height}");
                }
            }
        }
    }
}