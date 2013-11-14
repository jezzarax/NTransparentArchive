using System.Configuration;

namespace NTransparentArchive.Core.Configuration
{
    [ConfigurationCollection(typeof (TransparentArchive))]
    public class TransparentArchiveMappingCollection : ConfigurationElementCollection
    {
        public TransparentArchive this[int idx]
        {
            get { return (TransparentArchive)BaseGet(idx); }
        }

        public new TransparentArchive this[string key]
        {
            get { return (TransparentArchive)BaseGet(key); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TransparentArchive();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TransparentArchive)(element)).MountPath;
        }
    }
}