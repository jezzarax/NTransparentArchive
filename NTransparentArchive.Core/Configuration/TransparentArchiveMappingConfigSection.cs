using System.Configuration;

namespace NTransparentArchive.Core.Configuration
{
    public class TransparentArchiveMappingConfigSection : ConfigurationSection
    {
        private const string TRANSPARENT_ARCHIVE_MAPPINGS = "TransparentArchiveMappings";

        [ConfigurationProperty(TRANSPARENT_ARCHIVE_MAPPINGS)]
        public TransparentArchiveMappingCollection TransparentArchiveMappingCollectionItems
        {
            get { return ((TransparentArchiveMappingCollection)(base[TRANSPARENT_ARCHIVE_MAPPINGS])); }
        }
    }
}