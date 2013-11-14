using System.Configuration;

namespace NTransparentArchive.Core.Configuration
{

    internal static class MappingCollectionRetriever
    {
        public static readonly string MAPPINGS_CONFIGURATION_SECTION_NAME = "TransparentArchiveMappingsSection";

        public static TransparentArchiveMappingCollection GetTheCollection()
        {
            var mappingsSection =
                (TransparentArchiveMappingConfigSection)
                    ConfigurationManager.GetSection(MAPPINGS_CONFIGURATION_SECTION_NAME);
            if (mappingsSection != null)
            {
                return mappingsSection.TransparentArchiveMappingCollectionItems;
            }
            return null; // OOPS!
        }
    }
}