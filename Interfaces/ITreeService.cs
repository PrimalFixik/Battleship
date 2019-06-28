using Core;

namespace Interfaces
{
    public interface ITreeService
    {
        HierarchyTree GetTree();

        HierarchyTree GetTree(string path);

        void GetArchive(string path);
    }
}