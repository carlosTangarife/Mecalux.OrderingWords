namespace Mecalux.OrderingWords.Domain.Entities
{
    public class TextStatistics
    {
        public int HyphensQuantity { get; set; }
        public int WordQuantity { get; set; }
        public int SpacesQuantity { get; set; }

        public TextStatistics()
        {
            HyphensQuantity = 0;
            WordQuantity = 0;
            SpacesQuantity = 0;
        }
    }
}
