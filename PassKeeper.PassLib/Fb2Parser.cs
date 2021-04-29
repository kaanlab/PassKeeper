using System.IO;
using System.Xml;


namespace PassKeeper.PassLib
{
    public class Fb2Parser
    {
        public void Parse(string inputFilePath, string outputFilePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(inputFilePath);

            XmlNodeList elemList = xDoc.GetElementsByTagName("strong");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!string.IsNullOrEmpty(elemList[i].InnerXml))
                    outputFilePath.AppendTextToFile(elemList[i].InnerXml);
            }
        }       
    }
}
