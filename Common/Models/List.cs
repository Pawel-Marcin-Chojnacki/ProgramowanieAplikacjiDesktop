namespace Common.Models
{
    public class List
    {
        public long Dt { get; set; }

        public Main Main { get; set; }

        public Weather[] Weather { get; set; }

        public Clouds Clouds { get; set; }

        public Wind Wind { get; set; }

        public Sys Sys { get; set; }

        public System.DateTime DtTxt { get; set; }
    }
}
