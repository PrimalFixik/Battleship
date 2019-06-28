using System;

namespace Core
{
    public abstract class Component
    {
        public Component() { }

        public abstract string Print();

        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual bool IsComposite()
        {
            return true;
        }
    }
}
