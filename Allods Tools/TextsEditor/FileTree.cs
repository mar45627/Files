using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextsEditor
{
    internal class FileTree<T> where T : class
    {
        private readonly char[] SEPARATORS = new char[1]
        {
           '/'
        };
        private FileTreeItem<T> _root;
        private FileTreeItem<T> _currentNode;

        public FileTreeItem<T> Current
        {
            get
            {
                return this._currentNode;
            }
        }

        public FileTreeItem<T> Root
        {
            get
            {
                return this._root;
            }
        }

        public FileTree(string rootNodeName)
        {
            this._root = new FileTreeItem<T>((FileTreeItem<T>)null, rootNodeName, default(T));
            this._currentNode = this._root;
        }

        public void AddItem(string fullPath, T content)
        {
            string[] strArray = fullPath.Split(this.SEPARATORS);
            int length = strArray.Length;
            FileTreeItem<T> fileTreeItem = this._root;
            for (int index = 0; index < length; ++index)
            {
                T content1 = index < length - 1 ? default(T) : content;
                fileTreeItem = fileTreeItem.GetChild(strArray[index]) ?? fileTreeItem.CreateChild(strArray[index], content1);
            }
        }

        public bool Enter(string childName)
        {
            if (childName == "..")
            {
                this.Leave();
                return true;
            }
            FileTreeItem<T> child = this._currentNode.GetChild(childName);
            if (child == null || !child.IsFolder)
                return false;
            this._currentNode = child;
            return true;
        }

        public void Leave()
        {
            if (this._currentNode == this._root || !this._currentNode.HasParent)
                return;
            this._currentNode = this._currentNode.Parent;
        }
    }
}
