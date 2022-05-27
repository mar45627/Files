using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextsEditor
{
    internal class FileTreeItem<T> where T : class
    {
        private List<FileTreeItem<T>> _childList = new List<FileTreeItem<T>>();
        private Dictionary<string, int> _childMap = new Dictionary<string, int>();
        private string _name;
        private FileTreeItem<T> _parent;
        private T _content;

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public T Content
        {
            get
            {
                return this._content;
            }
        }

        public int ChildCount
        {
            get
            {
                return this._childList.Count;
            }
        }

        public bool HasParent
        {
            get
            {
                return this._parent != null;
            }
        }

        public bool IsFolder
        {
            get
            {
                return (object)this._content == null;
            }
        }

        public FileTreeItem<T> Parent
        {
            get
            {
                return this._parent;
            }
        }

        public string FullPath
        {
            get
            {
                if (this._parent == null)
                    return "";
                return this._parent.FullPath + "/" + this.Name;
            }
        }

        public int TotalCount
        {
            get
            {
                int total = this._childList.Count;
                this._childList.ForEach((Action<FileTreeItem<T>>)(child =>
                {
                    if (!child.IsFolder)
                        return;
                    total += child.TotalCount;
                }));
                return total;
            }
        }

        public FileTreeItem(FileTreeItem<T> parent, string name, T content)
        {
            this._parent = parent;
            this._name = name;
            this._content = content;
        }

        public FileTreeItem<T> CreateChild(string name, T content)
        {
            FileTreeItem<T> fileTreeItem = new FileTreeItem<T>(this, name, content);
            this._childList.Add(fileTreeItem);
            return fileTreeItem;
        }

        public FileTreeItem<T> GetChild(string name)
        {
            int index = 0;
            if (this._childMap.TryGetValue(name, out index))
                return this.GetChild(index);
            return this._childList.Find((Predicate<FileTreeItem<T>>)(child => child._name.Equals(name, StringComparison.InvariantCulture)));
        }

        public FileTreeItem<T> GetChild(int index)
        {
            return this._childList[index];
        }

        public void Sort()
        {
            this._childList.Sort((Comparison<FileTreeItem<T>>)((a, b) =>
            {
                if (!(a.IsFolder ^ b.IsFolder))
                    return a.Name.CompareTo(b.Name);
                return !a.IsFolder ? 1 : -1;
            }));
            this._childList.ForEach((Action<FileTreeItem<T>>)(i => i.Sort()));
        }

        public void BuildMap()
        {
            this._childMap.Clear();
            for (int index = 0; index < this._childList.Count; ++index)
            {
                this._childMap.Add(this._childList[index].Name, index);
                this._childList[index].BuildMap();
            }
        }

        public void ForEach(Action<FileTreeItem<T>> callback)
        {
            callback(this);
            foreach (FileTreeItem<T> fileTreeItem in this._childList)
                fileTreeItem.ForEach(callback);
        }
    }
}
