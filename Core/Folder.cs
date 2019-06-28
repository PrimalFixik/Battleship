﻿using System.Collections.Generic;

namespace Core
{
    public class Folder : Component
    {
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component)
        {
            this._children.Add(component);
        }
        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }
        public override string Print(CDirectory root)
        {
            int i = 0;
            string result = "Folder(";
            foreach (Component component in this._children)
            {
                result += component.Print(root);
                if (i != this._children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }
            return result + ")";
        }
    }
}