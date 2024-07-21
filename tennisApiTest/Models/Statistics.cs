namespace tennisApiTest.Models
{
    public class Statistics
    {
        //Pays qui a le plus grand ratio de parties gagnées
        public string CountryWithHighestWinRatio { get; set; }

        //IMC moyen de tous les joueurs
        public double AverageIMC { get; set; }

        //La médiane de la taille des joueurs
        public double MedianHeight { get; set; }
    }


}
