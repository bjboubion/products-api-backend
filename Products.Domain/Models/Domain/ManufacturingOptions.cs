namespace products_api.Products.Domain.Models
{
    public class ManufacturingOptions
    {
        public double Weight { get; private set; }
        public double Height { get; private set; }
        public double Width { get; private set; }
        public double Length { get; private set; }

        public ManufacturingOptions(double weight, double height, double width, double length)
        {
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
        }
    }
}