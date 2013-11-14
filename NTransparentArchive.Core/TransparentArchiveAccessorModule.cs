using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Ionic.Zip;
using NTransparentArchive.Core.Configuration;

namespace NTransparentArchive.Core
{
    public class TransparentArchiveAccessorModule : IHttpModule
    {

        private readonly IDictionary<string, string> _pathsToHandle = MappingCollectionRetriever.GetTheCollection().OfType<TransparentArchive>().ToDictionary(c => c.MountPath, c => c.ArchiveName);

        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            if (!_pathsToHandle.Any(p => application.Request.Path.StartsWith(p.Key)))
                return;
            var mostSpecificPath = _pathsToHandle.OrderBy(o => o.Key.Length).ThenBy(o => o.Key).Last(p => application.Request.Path.StartsWith(p.Key));


            var archiveEntryName = application.Request.Path.Replace(string.Format("{0}/", mostSpecificPath.Key), "");
            application.Response.ContentType =
                Util.GetMimeTypeFromRegistry(
                    archiveEntryName.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries).Last());
            var archiveName = application.Context.Server.MapPath(string.Format("~/{0}", mostSpecificPath.Value));
            if(!File.Exists(archiveName))
                return;
            var zip = ZipFile.Read(archiveName);
            if (!zip.ContainsEntry(archiveEntryName)) 
                return;
            zip[archiveEntryName].Extract(application.Response.OutputStream);

            application.Response.End();
        }

        #endregion

        public void Dispose() { }

        
    }
}