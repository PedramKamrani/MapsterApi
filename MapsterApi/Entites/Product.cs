using System.Drawing;

namespace MapsterApi.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public string WeightWithUnit { get; set; }
        public string Size { get; set; }


        public int ColorId { get; set; }
        public Colors Color { get; set; }
    }
}
