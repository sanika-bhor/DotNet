// LSP(Liskov's substitution principle)
namespace LSP
{
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Triangle:Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle...");
        }
    }

    public class Circle:Triangle
    {
         public override void Draw()
        {
            Console.WriteLine("Drawing Circle...");
        }
    }
}