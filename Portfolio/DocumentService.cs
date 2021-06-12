using Markdig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Portfolio
{
	public interface IDocumentService
	{
		/// <summary>
		/// Retrieves a Markdown document.
		/// </summary>
		/// <param name="path">The path to the embedded resource.</param>
		/// <param name="converted">Whether the document should be converted to HTML</param>
		/// <param name="path">The directory containing all Markdown documents.</param>
		/// <returns>A string containing the document. Null if the document doesn't exist.</returns>
		public string GetDocument(string path, bool converted = true, string directory = "Portfolio.Pages.Content");

		/// <summary>
		/// Lists the paths of available documents
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> ListDocuments(string directory = "Portfolio.Pages.Content");
	}

	public class DocumentService : IDocumentService
	{
		public string GetDocument(string path, bool converted = true, string directory = "Portfolio.Pages.Content")
		{
			//Get the document, if it exists.
			Stream document = Assembly.GetCallingAssembly()
				.GetManifestResourceStream($"{directory}.{path}.md");

			//If it doesn't exist, this path may be referring to a folder instead. Check if there's an Index.md file at this path and retrieve it if it does.
			if (document == null)
			{
				Console.WriteLine($"Can't find file: {directory}.{path}.md");

				document = Assembly.GetCallingAssembly()
					.GetManifestResourceStream($"{directory}.{path}.Index.md");
				if (document == null)
				{
					Console.WriteLine($"Can't find file {directory}.{path}.Index.md");
					return null;
				}
			}

			//Convert the content to HTML if requested and return it.
			string content = new StreamReader(document).ReadToEnd();
			return converted ? Markdown.ToHtml(content, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build()) : content;
		}

		public IEnumerable<string> ListDocuments(string directory = "Portfolio.Pages.Content")
		{
			return from d in Assembly.GetCallingAssembly().GetManifestResourceNames()
				   where d.StartsWith(directory) && d.EndsWith(".md")
				   select d.Replace($"{directory}.", string.Empty);
		}
	}
}
