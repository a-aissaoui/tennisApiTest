namespace tennisApiTest.Models
{
    public class Player
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string shortname { get; set; }
        public string sex { get; set; }
        public Country country { get; set; }
        public string picture { get; set; }
        public PlayerData data { get; set; }
    }
}
