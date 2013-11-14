namespace NTransparentArchive.Core
{
    internal class Util
    {
        public static string GetMimeTypeFromRegistry(string extension)
        {
            string mimeType = "application/unknown";
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension.StartsWith(".") ? extension : ("." + extension));
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }


    }
}
