namespace ClassLibTeam04.IndividueleTaken.HassanAli
{
    public class Hobby
    {
        public Hobby()
        {
            this.beschrijving = Beschrijving; 
            this.naam = Naam; 
            this.aantalUrenPerweek = double.Parse(AantalUrenPerWeek);

        }
        public Hobby(string naam, string beschrijving)
        {
            Naam = naam;
            Beschrijving = beschrijving;
        }
        private double aantalUrenPerweek;
        private string beschrijving;
        private string naam;

        public string AantalUrenPerWeek
        {
            get { return aantalUrenPerweek.ToString(); }
            set { SetAantalUrenPerWeek(uren); }
        }
        public string Beschrijving 
        {
            get { return beschrijving; }
            set
            {
                if(string.IsNullOrWhiteSpace(beschrijving))
                {
                    beschrijving = "Het spelen van een videospel op een elektronich systeem.";
                }
                else
                {
                    beschrijving = value;
                }
            }
        }
        public string  Naam
        {
            get { return naam; }
            set
            {
            if(naam == null)
                {
                    naam = "Gaming";
                }
            else
                {
                    naam = value.ToString();
                }
            }
        }
        int[] uren = new int[7];
       
        public void SetAantalUrenPerWeek(params int[] uren)
        {
            double urenPerWeek = 0;
            double totaal = 0;
            for(int i = 0; i < uren.Length; i++)
            {
                totaal += uren[i];
                
            }
            urenPerWeek = totaal / 7;
            if(urenPerWeek == 0)
            {
                urenPerWeek = 2;
            }
            aantalUrenPerweek = urenPerWeek;
        }
        
    }
}
