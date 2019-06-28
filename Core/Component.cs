using System;

namespace Core
{
    public abstract class Component
    {
        public string name;
        public string path;

        public Component() { }

        public abstract string Print(CDirectory root);

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
