using System;
using System.Collections.Generic;
using System.Linq;

namespace MimeTypes
{
    public static class MimeTypeMap
    {
        private const string Dot = ".";
        private const string DefaultMimeType = "application/octet-stream";
        private static readonly Lazy<IDictionary<string, string>> _mappings = new Lazy<IDictionary<string, string>>(BuildMappings);

        private static IDictionary<string, string> BuildMappings()
        {
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {

                #region Big freaking list of mime types
            
                // maps both ways,
                // extension -> mime type
                //   and
                // mime type -> extension
                //
                // any mime types on left side not pre-loaded on right side, are added automatically
                // some mime types can map to multiple extensions, so to get a deterministic mapping,
                // add those to the dictionary specifically
                //
                // combination of values from Windows 7 Registry and 
                // from C:\Windows\System32\inetsrv\config\applicationHost.config
                // some added, including .7z and .dat
                //
                // Some added based on http://www.iana.org/assignments/media-types/media-types.xhtml
                // which lists mime types, but not extensions
                //
                {".3g2", "video/3gpp2"},
                {".3gp", "video/3gpp"},
                {".3gp2", "video/3gpp2"},
                {".3gpp", "video/3gpp"},
                {".aa", "audio/audible"},
                {".AAC", "audio/aac"},
                {".aax", "audio/vnd.audible.aax"},
                {".ac3", "audio/ac3"},
                {".ADT", "audio/vnd.dlna.adts"},
                {".ADTS", "audio/aac"},
                {".aif", "audio/aiff"},
                {".aifc", "audio/aiff"},
                {".aiff", "audio/aiff"},
                {".asf", "video/x-ms-asf"},
                {".asr", "video/x-ms-asf"},
                {".asx", "video/x-ms-asf"},
                {".au", "audio/basic"},
                {".avi", "video/x-msvideo"},
                {".axa", "audio/annodex"},
                {".axv", "video/annodex"},
                {".caf", "audio/x-caf"},
                {".cdda", "audio/aiff"},
                {".dif", "video/x-dv"},
                {".divx", "video/divx"},
                {".dv", "video/x-dv"},
                {".f4v", "video/mp4"},
                {".flac", "audio/flac"},
                {".flv", "video/x-flv"},
                {".gsm", "audio/x-gsm"},
                {".IVF", "video/x-ivf"},
                {".lsf", "video/x-la-asf"},
                {".lsx", "video/x-la-asf"},
                {".m1v", "video/mpeg"},
                {".m2t", "video/vnd.dlna.mpeg-tts"},
                {".m2ts", "video/vnd.dlna.mpeg-tts"},
                {".m2v", "video/mpeg"},
                {".m3u", "audio/x-mpegurl"},
                {".m3u8", "audio/x-mpegurl"},
                {".m4a", "audio/m4a"},
                {".m4b", "audio/m4b"},
                {".m4p", "audio/m4p"},
                {".m4r", "audio/x-m4r"},
                {".m4v", "video/x-m4v"},
                {".mid", "audio/mid"},
                {".midi", "audio/mid"},
                {".mk3d", "video/x-matroska-3d"},
                {".mka", "audio/x-matroska"},
                {".mkv", "video/x-matroska"},
                {".mod", "video/mpeg"},
                {".mov", "video/quicktime"},
                {".movie", "video/x-sgi-movie"},
                {".mp2", "video/mpeg"},
                {".mp2v", "video/mpeg"},
                {".mp3", "audio/mpeg"},
                {".mp4", "video/mp4"},
                {".mp4v", "video/mp4"},
                {".mpa", "video/mpeg"},
                {".mpe", "video/mpeg"},
                {".mpeg", "video/mpeg"},
                {".mpg", "video/mpeg"},
                {".mpv2", "video/mpeg"},
                {".mqv", "video/quicktime"},
                {".mts", "video/vnd.dlna.mpeg-tts"},
                {".nsc", "video/x-ms-asf"},
                {".oga", "audio/ogg"},
                {".ogg", "audio/ogg"},
                {".ogv", "video/ogg"},
                {".opus", "audio/ogg"},
                {".pls", "audio/scpls"},
                {".qt", "video/quicktime"},
                {".ra", "audio/x-pn-realaudio"},
                {".ram", "audio/x-pn-realaudio"},
                {".rmi", "audio/mid"},
                {".rpm", "audio/x-pn-realaudio-plugin"},
                {".sd2", "audio/x-sd2"},
                {".smd", "audio/x-smd"},
                {".smx", "audio/x-smd"},
                {".smz", "audio/x-smd"},
                {".snd", "audio/basic"},
                {".spx", "audio/ogg"},
                {".ts", "video/vnd.dlna.mpeg-tts"},
                {".tts", "video/vnd.dlna.mpeg-tts"},
                {".vbk", "video/mpeg"},
                {".wav", "audio/wav"},
                {".wave", "audio/wav"},
                {".wax", "audio/x-ms-wax"},
                {".webm", "video/webm"},
                {".wm", "video/x-ms-wm"},
                {".wma", "audio/x-ms-wma"},
                {".wmp", "video/x-ms-wmp"},
                {".wmv", "video/x-ms-wmv"},
                {".wmx", "video/x-ms-wmx"},
                {".wvx", "video/x-ms-wvx"},
                {"audio/aac", ".AAC"},
                {"audio/aiff", ".aiff"},
                {"audio/basic", ".snd"},
                {"audio/mid", ".midi"},
                {"audio/mp4", ".m4a"},
                {"audio/wav", ".wav"},
                {"audio/x-m4a", ".m4a"},
                {"audio/x-mpegurl", ".m3u"},
                {"audio/x-pn-realaudio", ".ra"},
                {"audio/x-smd", ".smd"},
                {"video/3gpp", ".3gp"},
                {"video/3gpp2", ".3gp2"},
                {"video/mp4", ".mp4"},
                {"video/mpeg", ".mpg"},
                {"video/quicktime", ".mov"},
                {"video/vnd.dlna.mpeg-tts", ".m2t"},
                {"video/x-dv", ".dv"},
                {"video/x-la-asf", ".lsf"},
                {"video/x-ms-asf", ".asf"},

                #endregion

                };

            var cache = mappings.ToList(); // need ToList() to avoid modifying while still enumerating

            foreach (var mapping in cache)
            {
                if (!mappings.ContainsKey(mapping.Value))
                {
                    mappings.Add(mapping.Value, mapping.Key);
                }
            }

            return mappings;
        }

        public static string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            if (!extension.StartsWith(Dot))
            {
                extension = Dot + extension;
            }

            return _mappings.Value.TryGetValue(extension, out string mime) ? mime : DefaultMimeType;
        }

        public static string GetExtension(string mimeType, bool throwErrorIfNotFound = true)
        {
            if (mimeType == null)
            {
                throw new ArgumentNullException(nameof(mimeType));
            }

            if (mimeType.StartsWith("."))
            {
                throw new ArgumentException("Requested mime type is not valid: " + mimeType);
            }

            if (_mappings.Value.TryGetValue(mimeType, out string extension))
            {
                return extension;
            }

            if (throwErrorIfNotFound)
            {
                throw new ArgumentException("Requested mime type is not registered: " + mimeType);
            }

            return string.Empty;
        }
    }
}
