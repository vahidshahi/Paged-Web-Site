using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibTeam04.IndividueleTaken.HassanAli.HassanAli
{
    public class HassanAli : Profiel
    {
        public HassanAli()
        {
            hobbies.Add("Koken");
            hobbies.Add("Gamen");
            hobbies.Add("Baskeballen");
            Hobbies = hobbies;

           
           
        }
        private static string achternaam = "Ali";
        private static string voornaam = "Hassan";
        private List<string> qoutes = new List<string>
        {
            "Brains, like hearts, go where they are appreciated.",
            "If you want to know your past look into your present conditions. If you want to know your future look into your present actions. - Chinese proverb",
            "Learn from the mistakes of others. You can't live long enough to make them all yourself.",
            "The most important thing to remember is this: to be ready at any moment to give up what you are for what you might become.",
            "Once you choose hope, anything’s possible.",
            "Never underestimate the power of Dua (supplication).",
            "Do not lose hope, nor be sad.",
            "Speak only when your words are more beautiful than the silence.",
            "And He found you lost and guided [you]. And He found you poor and made [you] self-sufficient.",
            "Call upon Me, I will respond to you."

        };
        public string Voornaam { get { return voornaam; } set { value = voornaam; }}
        public string Naam { get { return voornaam; } set { value = achternaam; } }
        public override string GetRandomPersonalQuote()
        {
            Random random = new Random();
            int index = random.Next(qoutes.Count);
            return qoutes[index];
        }
        
        public override List<string> GetThreeRandomQuotes()
        {
            List<string> newRandomList = new List<string>();
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int qIndex = rand.Next(qoutes.Count) ;
               
                if (newRandomList.Contains(qoutes[qIndex]))
                {
                    i--;
                }
                else
                {
                    newRandomList.Add(qoutes[qIndex]);
                }
            }
            return newRandomList;
        }
        public override int GetAge()
        {
            DateTime birthday = GetBirthDay();
            DateTime dateNow = DateTime.Now;
            int age = dateNow.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear)
                age = age - 1;
            return age;
        }
        public override DateTime GetBirthDay()
        {
            DateTime birthday = new DateTime(1997, 25, 11);
            return birthday;
        }
        private List<string> hobbies = new List<string>();
       
        
        public List<string> Hobbies
        {
            get { return hobbies; }
            set { value = hobbies; }
        }
        //hobbies.Add(value.ToString()
        public override string GetFirstName()
        {
            return voornaam;
        }
        public override string GetLastName()
        {
            return achternaam;
        }
        public override string GetFullName()
        {
            return voornaam + " " + achternaam;
        }
       

    }
}
