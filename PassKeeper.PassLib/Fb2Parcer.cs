using System.IO;
using System.Xml;


namespace PassKeeper.PassLib
{
    public class Fb2Parcer
    {
        public void Parce(string inputFilePath, string outputFilePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(inputFilePath);

            XmlNodeList elemList = xDoc.GetElementsByTagName("strong");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!string.IsNullOrEmpty(elemList[i].InnerXml))
                    AppendTextToFile(outputFilePath, elemList[i].InnerXml);
            }
        }

        public void AppendTextToFile(string path, string innerXml)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(innerXml);
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(innerXml);
            }
        }
    }
}
