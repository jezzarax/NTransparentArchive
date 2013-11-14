using System.Configuration;

namespace NTransparentArchive.Core.Configuration
{
    public class TransparentArchive : ConfigurationElement
    {
        private const string ARCHIVE_NAME = "ArchiveName";
        private const string MOUNT_PATH = "MountPath";

        [ConfigurationProperty(ARCHIVE_NAME, DefaultValue = "", IsKey = false, IsRequired = true)]
        public string ArchiveName
        {
            get { return ((string) (base[ARCHIVE_NAME])); }
            set { base[ARCHIVE_NAME] = value; }
        }

        [ConfigurationProperty(MOUNT_PATH, DefaultValue = "", IsKey = true, IsRequired = true)]
        public string MountPath
        {
            get { return ((string) (base[MOUNT_PATH])); }
            set { base[MOUNT_PATH] = value; }
        }
    }
}