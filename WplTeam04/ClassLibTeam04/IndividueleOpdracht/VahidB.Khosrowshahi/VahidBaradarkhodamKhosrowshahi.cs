using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04Framework.IndividueleOpdracht.VahidBaradarkhodamKhosrowshahi
{
    class VahidBaradarkhodamKhosrowshahi: Profiel
    {

        private string voornaam = "Vahid";
        private string achternaam = "BaradarkhodamKhosrowshahi";
        private List<string> quotes = new List<string>()
        {
            "Release Yourself Through the Process of Listening",
            "Practice Kindness In Times of Stress",
            "Forget Your Past, Forgive Yourself, And Begin Again Right Now",
            "You Will Reach Acceptance",
            "The One Who Falls and Gets Back Up is so Much Stronger Than the One Who Never Fell.",
            "Do Not Give The Past The Power to Define Your Future",
            "Getting Over a Painful Experience is a Lot Like Crossing Monkey Bars. You Have to Let Go at Some Point to Move Forward",
            "I Am Not What Happened To Me. I Am What I Choose To Become.",
            "Letting Go Gives Us Freedom, and Freedom is the Only Condition For Happiness",
            "Life Shrinks or Expands In Proportion To One's Courage"

        };

        public override int GetAge()
        {
            DateTime birthDay = GetBirthDay();
            DateTime today = DateTime.Today;
            
            if (birthDay > DateTime.Now)
            {
                return 0;
            }
              
            int age = DateTime.Now.Year - birthDay.Year;
            
            if (DateTime.Now.Month < birthDay.Month ||
               (DateTime.Now.Month == birthDay.Month &&
                DateTime.Now.Day < birthDay.Day))
            {
                age--;
            }
             
            if (age >= 0)
                return age;
            else
                return 0;
        }

        public override DateTime GetBirthDay()
        {
            DateTime birthday = new DateTime(1978, 08, 09);
            return birthday;
        }

        public override string GetFirstName()
        {
            return voornaam;
        }

        public override string GetFullName()
        {
            string fullname = voornaam + " " + achternaam;
            return fullname;
        }

        public override string GetLastName()
        {
            return achternaam;
        }

        public override string GetRandomPersonalQuote()
        {
            Random rnd = new Random();
            int qIndex = rnd.Next(quotes.Count);
            return quotes[qIndex];
        }

        public override List<string> GetThreeRandomQuotes()
        {
            Random rnd = new Random();
            List<string> randomq = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                int qIndex = rnd.Next(quotes.Count);
                if (randomq.Contains(quotes[qIndex]))
                {
                    i--;
                }
                else
                {
                    randomq.Add(quotes[qIndex]);
                }
            }
            return randomq;
        }
        public new List<string> Hobbies
        {
            get
            {
                return Hobbies;
            }

            set
            {
                Hobbies.Add(value.ToString());
            }
        }

        public VahidBaradarkhodamKhosrowshahi()
        {
            Hobbies.Add("ski");
            Hobbies.Add("football");
            Hobbies.Add("poker");

        }
    }
}
