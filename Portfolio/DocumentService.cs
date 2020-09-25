using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using Markdig;

namespace Portfolio
{
    public interface IDocumentService
    {
        /// <summary>
        /// Retrieves a Markdown document.
        /// </summary>
        /// <param name="path">The path to the embedded resource.</param>
        /// <param name="converted">Whether the document should be converted to HTML</param>
        /// <returns>A string containing the document. Null if the document doesn't exist.</returns>
        public string GetDocument(string path, bool converted = true);

        /// <summary>
        /// Lists the paths of available documents
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ListDocuments();
    }

    public class DocumentService : IDocumentService
    {
        public string GetDocument(string path, bool converted = true)
        {
            var document = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream($"Portfolio.Pages.Content.{path}.md");

            if (document == null)
                return null;

            string content = new StreamReader(document).ReadToEnd();
            return converted ? Markdown.ToHtml(content) : content;
        }

        public IEnumerable<string> ListDocuments() =>
            from d in Assembly.GetExecutingAssembly().GetManifestResourceNames()
            where d.StartsWith("Portfolio.Pages.Content.")
            select d.Replace("Portfolio.Pages.Content.", string.Empty);
    }
}
