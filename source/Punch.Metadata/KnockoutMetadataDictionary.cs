using System;
using System.Collections.Generic;
using System.Linq;
using Punch.Contracts;

namespace Punch.Core
{
    public class KnockoutMetadataDictionary : IDictionary<string, object>, IKnockoutMetadataDictionary
    {
        protected Dictionary<string, object> Dictionary { get; set; }
        public const string THIS = "$this";


        public KnockoutMetadataDictionary()
        {
            this.Dictionary = new Dictionary<string, object>();
        }

        public void SetThis(object value)
        {
            if (ContainsKey(THIS))
            {
                Dictionary[THIS] = value;
            }
            else
            {
                Dictionary.Add(THIS, value);
            }
        }

        public void Add(string key, object value)
        {
            if (key == THIS)
            {
                throw new ArgumentException(string.Format("Object for key {0} cannot be added to this dictionary. Use SetThis method instead.", THIS));
            }
            if (!ContainsKey(key))
            {
                Dictionary.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            return Dictionary.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return this.Dictionary.Keys; }
        }

        public bool Remove(string key)
        {
            if (key == THIS)
            {
                throw new ArgumentException(string.Format("Object for key {0} cannot be removed to this dictionary", THIS));
            }
            return this.Dictionary.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return this.TryGetValue(key, out value);
        }

        public ICollection<object> Values
        {
            get { return this.Dictionary.Values; }
        }


        public object this[string key]
        {
            get { return this.Dictionary[key]; }
            set
            {
                if (key == THIS)
                {
                    throw new ArgumentException(string.Format("Object for key {0} cannot be set", THIS));
                }
                this.Dictionary[key] = value;
            }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            foreach (var i in this.Dictionary.Keys)
            {
                if (i != THIS)
                {
                    this.Remove(i);
                }
            }
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.Dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this.Dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return this.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.Dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Dictionary.GetEnumerator();
        }
    }
}
