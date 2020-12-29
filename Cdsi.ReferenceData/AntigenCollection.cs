using Cdsi.SupportingData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Cdsi.ReferenceData
{

    public class AntigenCollection : IDictionary<object, antigenSupportingData>
    {
        public antigenSupportingData this[object key]
        {
            get
            {
                var name = $"Cdsi.SupportingData.xml.AntigenSupportingData- {key}-508.xml";
                var assembly = Assembly.GetAssembly(typeof(antigenSupportingData));
                var resource = assembly.GetManifestResourceStream(name);
                var deserializer = new XmlSerializer(typeof(antigenSupportingData));
                return (antigenSupportingData)deserializer.Deserialize(resource);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<object> Keys
        {
            get
            {
                var re = new Regex("AntigenSupportingData- (.*)-508");
                var assembly = Assembly.GetAssembly(typeof(antigenSupportingData));
                var resources = assembly.GetManifestResourceNames();
                var xmls = resources.Where(r => re.IsMatch(r));
                var names = xmls.Select(r => (object)re.Match(r).Groups[1].Value);
                return names.ToList();
            }
        }


        public ICollection<antigenSupportingData> Values => Keys.Select(k => this[k]).ToList();

        public int Count => Keys.Count;

        public bool IsReadOnly => true;

        public void Add(object key, antigenSupportingData value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<object, antigenSupportingData> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<object, antigenSupportingData> item)
        {
            return item.Key.Equals(this[item.Key]);
        }

        public bool ContainsKey(object key)
        {
            return Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<object, antigenSupportingData>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public IEnumerator<KeyValuePair<object, antigenSupportingData>> GetEnumerator()
        {
            return Keys.Select(k => new KeyValuePair<object, antigenSupportingData>(key: k, value: this[k])).GetEnumerator();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Remove(object key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<object, antigenSupportingData> item)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool TryGetValue(object key, [MaybeNullWhen(false)] out antigenSupportingData value)
        {
            var success = true;
            try
            {
                value = this[key];
            }
            catch
            {
                value = null;
                success = false;
            }
            return success;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
