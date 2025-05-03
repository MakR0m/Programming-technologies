namespace DesignPatterns.Behavioral.Visitor.Shapes
{
    internal interface IShapeVisitor
    {
        void VisitCircle(Circle circle);
        void VisitRectangle(Rectangle rectangle);
    }
}