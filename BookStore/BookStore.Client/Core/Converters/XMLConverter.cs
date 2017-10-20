using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace BookStore.Client.Core
{
    internal class XMLConverter
    {
        private IEnumerable<Author> ReadAuthors(string documentUrl, string nodeUrl)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(documentUrl);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes(nodeUrl);

            var authors = new HashSet<Author>();
            foreach (XmlNode node in nodeList)
            {
                var current = new Author();
                current.Id = int.Parse(node.SelectSingleNode("Author_Id").InnerText);
                current.FullName = node.SelectSingleNode("FullName").InnerText;
                current.Bio = node.SelectSingleNode("Bio").InnerText;
                authors.Add(current);
            }

            return authors;
        }
    }
}
