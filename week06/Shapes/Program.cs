using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Shapes Project.");
        
        // Create a list of Shape
        List<Shape> xy = new List<Shape>();

        // Create different kinds of shapes and add them to the same list
        xy.Add(new Square("red", 2));
        xy.Add(new Rectangle("green", 3,9));
        xy.Add(new Circle("yellow", 3));

        // Get a custom calculation for each one
        foreach(Shape elt in xy)
        {
        string color = elt.GetColor();
        double area = elt.GetArea();
        Console.WriteLine(color+" "+area);
        }
    }
}