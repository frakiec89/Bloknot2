using System.Text;

namespace Blocnot.BL
{
    /// <summary>
    /// интерфейс  взаимодействия  с  файлом 
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Получает  контент  из файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string GetContent(string filePath);
        /// <summary>
        /// Получает  контент  из файла с  нестандартной кодировкой
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        string GetContent(string filePath, Encoding encoding);

        /// <summary>
        /// Считает  символы  в контенте
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        int GetSymbolCount(string content);

        /// <summary>
        /// Проверяет  наличие файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool IsExistFile(string filePath);

        /// <summary>
        /// Сохраняет  контент  в  файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        void SaveContent(string filePath, string content);
        /// <summary>
        /// Сохраняет  контент  в  файл с нестандартной кодировкой
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        void SaveContent(string filePath, string content, Encoding encoding);
    }
}