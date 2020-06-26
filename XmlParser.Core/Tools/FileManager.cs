using System.IO;
using Microsoft.Win32;
using XmlParser.Core.Models;

namespace XmlParser.Core.Tools
{
    public static class FileManager
    {
        #region Constants

        private const string XmlFileFilter = "Xml Files (*.xml)|*.xml";

        #endregion

        #region Fields

        private static readonly OpenFileDialog OpenFileDialog = new OpenFileDialog { Filter = XmlFileFilter };

        #endregion

        #region Public Methods

        public static bool OpenXml(out XmlFile xmlFile)
        {
            xmlFile = null;

            var openFileDialogResult = OpenFileDialog.ShowDialog() ?? false;

            if (openFileDialogResult)
            {
                xmlFile = new XmlFile(OpenFileDialog.FileName, File.ReadAllText(OpenFileDialog.FileName));
            }

            return openFileDialogResult;
        }

        #endregion
    }
}
