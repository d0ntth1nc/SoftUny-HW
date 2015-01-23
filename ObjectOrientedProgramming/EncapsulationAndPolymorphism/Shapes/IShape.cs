
namespace Shapes
{
    public interface IShape
    {
        double Width { get; set; }
        double Height { get; set; }
        double CalculateArea();
        double CapculatePerimeter();
    }
}
