using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Portfolio.Tests
{
	[TestClass]
	public class DocumentServiceTests
	{
		/// <summary>
		/// DocumentService instance for use throughout all unit tests.
		/// </summary>
		public DocumentService DocumentService { get; set; }

		/// <summary>
		/// Creates the initial instance
		/// </summary>
		[TestInitialize]
		public void Init() => DocumentService = new DocumentService();

		/// <summary>
		/// Checks whether DocumentService.GetDocument retrieves documents properly.
		/// </summary>
		/// <param name="path">The path of the embedded resource containing the document</param>
		/// <param name="expectedContent">The expected contents of the document</param>
		/// <param name="converted">Whether GetDocument should convert the file to HTML first.</param>
		[DataRow("Page1", "This file exists!", false)]
		[DataRow("Page2", "This file also exists!", false)]
		[DataRow("Page1", "<p>This file exists!</p>\n")]
		[DataRow("SomeNonexistentFile", null)]
		[TestMethod]
		public void GetDocumentTest(string path, string expectedContent, bool converted = true)
		{
			var retrievedContent = DocumentService.GetDocument(path, converted, "PortfolioTests.TestContent");
			Assert.IsTrue(retrievedContent == expectedContent);
		}

		/// <summary>
		/// Checks whether DocumentService.ListDocuments can find all embedded Markdown files.
		/// </summary>
		[TestMethod]
		public void ListDocumentsTest()
		{
			var result = DocumentService.ListDocuments("PortfolioTests.TestContent").ToList();
			Assert.IsTrue(result.Count == 2);
			Assert.IsTrue(result[0] == "Page1.md");
			Assert.IsTrue(result[1] == "Page2.md");
		}
	}
}