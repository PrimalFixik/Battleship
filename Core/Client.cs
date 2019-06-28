using System;

namespace Core
{
    public class Client
    {
        public void GetAllChildren(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Print()}\n");
        }
        public void GetAllChildrenWithAdding(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }
            Console.WriteLine($"RESULT: {component1.Print()}");
        }
    }
}
