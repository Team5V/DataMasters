using BookStore.Models;
using System.Collections.Generic;
using System.Xml;

namespace BookStore.Client.Core
{
    public class XmlParser
    {
        public List<Author> ReadFromFile(string fileUrl, string nodeUrl)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileUrl);
            var nodeList = xmlDoc.DocumentElement.SelectNodes(nodeUrl);

            var authors = new List<Author>();

            foreach (XmlNode node in nodeList)
            {
                var author = new Author
                {
                    FullName = node.SelectSingleNode("fullName").InnerText,
                    Bio = node.SelectSingleNode("bio").InnerText
                };
                authors.Add(author);
            }

            return authors;
        }
    }
}
