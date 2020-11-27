using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // для ввода  вывода

namespace Blocnot.BL
{
    public class FileManager : IFileManager
    {

        private readonly Encoding _encodingDefoult = Encoding.Default; // дефолтная кодировка

        public string GetContent(string filePath, Encoding encoding) // 
        {
            return File.ReadAllText(filePath, encoding); // делает  дело 
        }

        public string GetContent(string filePath) // перегруженый метод 
        {
            return GetContent(filePath, _encodingDefoult); // обертка
        }

        public void SaveContent(string filePath, string content, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public void SaveContent(string filePath, string content)
        {
            SaveContent(filePath, content, _encodingDefoult); // 
        }

        public bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// возвращает  кол-во  символов в контенте
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public int GetSymbolCount(string content)
        {
            return content.Length;
        }

    }
}
