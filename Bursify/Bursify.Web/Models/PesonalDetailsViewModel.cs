namespace Bursify.Web.Models
{
    public class PesonalDetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public PesonalDetailsViewModel(int id, string name, string bio)
        {
            ID = id;
            Name = name;
            Bio = bio;
        }

        public PesonalDetailsViewModel()
        {
        }
    }
}