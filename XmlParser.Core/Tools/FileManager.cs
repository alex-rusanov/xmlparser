using System;
using System.IO;
using Microsoft.Win32;
using XmlParser.Core.Models;

namespace XmlParser.Core.Tools
{
    public static class FileManager
    {
        private const string XmlFileFilter = "Xml Files (*.xml)|*.xml";

        private static readonly OpenFileDialog OpenFileDialog = new OpenFileDialog { Filter = XmlFileFilter };

        public static bool OpenXml(out XmlFile xmlFile)
        {
            xmlFile = null;

            var openFileDialogResult = OpenFileDialog.ShowDialog() ?? false;

            if (openFileDialogResult)
            {
                try
                {
                    xmlFile = new XmlFile(OpenFileDialog.FileName, File.ReadAllText(OpenFileDialog.FileName));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // TODO: Add logger
                    throw;
                }
            }

            return openFileDialogResult;
        }
    }
}
