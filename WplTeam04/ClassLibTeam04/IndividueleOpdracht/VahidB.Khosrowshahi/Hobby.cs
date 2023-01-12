namespace ClassLibTeam04Framework.IndividueleOpdracht.VahidBaradarkhodamKhosrowshahi
{

    public class Hobby
    {
        private decimal aantalUrenPerWeek;
        private string beschrijving;
        private string naam;

        public decimal AantalUrenPerWeek
        {
            get
            {
                return aantalUrenPerWeek;
            }
            set
            {
                SetAantalUrenPerWeek();
                
            }
        }

        public string Beschrijving
        {
            get
            {
                return beschrijving;
            }
            set
            {
                if (beschrijving == null)
                {
                    beschrijving = "Het spelen van een videospel op een elektronisch systeem.";
                }
                else
                {
                    beschrijving = value.ToString();
                }
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                if (naam==null)
                {
                    naam = "Gaming";
                }

                else
                {
                    naam = value.ToString();
                }
            }
        }
        
        public void SetAantalUrenPerWeek(params int[] uren)
        {

            int totaal = 0;
            int totaalperweek = 0;
            for (int i = 0; i < uren.Length; i++)
            {

                totaal += uren[i];
                totaalperweek = totaal / 7;
            }
            if (totaalperweek==0)
            {
                totaalperweek = 2;
            }
            this.aantalUrenPerWeek = totaalperweek;
        }

        public Hobby()
        {
            this.beschrijving = Beschrijving;
            this.naam = Naam;
            this.aantalUrenPerWeek = AantalUrenPerWeek;
        }

        public Hobby(string naam, string beschrijving)
        {
            this.naam = naam;
            this.beschrijving = beschrijving;
        }
    }
}