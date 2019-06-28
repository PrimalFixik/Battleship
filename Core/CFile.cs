namespace Core
{
    public class CFile : Component
    {
        public override string Print(CDirectory root)
        {
            return "File";
        }
        public override bool IsComposite()
        {
            return false;
        }
    }
}
