using createdfmlink.Properties;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace createdfmlink
{
    public static class MainEngine
    {
        public static void Create(string projectFileName)
        {
            var fileInfo = new FileInfo(projectFileName);
            Directory.SetCurrentDirectory(fileInfo.DirectoryName);
            var document = new XmlDocument();
            document.Load(projectFileName);
            XmlElement element = document.DocumentElement[Resources.ItemGroup];

            if (element == null)
            {
                throw new Exception(Resources.ItemGroupNotFoundMessage);
            }

            XmlNodeList nodes = element.GetElementsByTagName(Resources.FormResources);
            var createCommands = new StringBuilder();
            var deleteCommands = new StringBuilder();

            foreach (XmlNode node in nodes)
            {
                XmlAttribute attribute = node.Attributes[Resources.Include];

                if (attribute == null)
                {
                    continue;
                }

                string value = attribute.Value;

                if (!(value.ToLower().EndsWith(Resources.DfmExtension)))
                {
                    continue;
                }

                var dfmFileInfo = new FileInfo(value);
                createCommands.AppendFormat("{0} {1} {2}", Resources.HardLinkCommand, dfmFileInfo.Name, value);
                createCommands.AppendLine();
                deleteCommands.AppendFormat("{0} {1}", Resources.DeleteCommand, dfmFileInfo.Name);
                deleteCommands.AppendLine();
            }

            string directoryName = fileInfo.DirectoryName;
            string fileName = fileInfo.Name;
            File.WriteAllText(Path.Combine(directoryName, (fileName + Resources.CreateLinkExtension)), createCommands.ToString(), Encoding.Default);
            File.WriteAllText(Path.Combine(directoryName, (fileName + Resources.DeleteLinkExtension)), deleteCommands.ToString(), Encoding.Default);
        }
    }
}
