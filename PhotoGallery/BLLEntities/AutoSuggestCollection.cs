using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLEntities
{
    public class AutoSuggestCollection : ICollection<AutoSuggestEntity>
    {
        private List<string> _ResultNames = new List<string>();
        private int _MaxCount = 10;

        public List<AutoSuggestEntity> SearchResults = new List<AutoSuggestEntity>();

        public void Add(AutoSuggestEntity item)
        {
            if (!_ResultNames.Contains(item.SearchResultName) && (this.Count != _MaxCount))
            {
                SearchResults.Add(item);
                _ResultNames.Add(item.SearchResultName);
            }
        }

        public void AddRange(IEnumerable<AutoSuggestEntity> collection)
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            SearchResults.Clear();
            _ResultNames.Clear();
        }

        public bool Contains(AutoSuggestEntity item)
        {
            return SearchResults.Contains(item);
        }

        public void CopyTo(AutoSuggestEntity[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public int MaxCount
        {
            get
            {
                return _MaxCount;
            }
            set
            {
                _MaxCount = value;
            }
        }

        public int Count
        {
            get 
            {
                return SearchResults.Count();
            }
        }

        public bool IsReadOnly
        {
            get 
            {
                return true;
            }
        }

        public bool Remove(AutoSuggestEntity item)
        {
            if (SearchResults.Remove(item))
            {
                _ResultNames.Remove(item.SearchResultName);
                return true;
            }
            return false;
        }

        public IEnumerator<AutoSuggestEntity> GetEnumerator()
        {
            return SearchResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
