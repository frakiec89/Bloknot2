using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocnot.BL
{
    public class MyPressenter
    {

        private readonly IFileManager _manager;
        private readonly IMainWindow _windows;
        private readonly IMassegeManager _message;

        public MyPressenter(IFileManager manager, IMainWindow windoe, IMassegeManager message)
        {
            _manager = manager;
            _windows = windoe;
            _message = message;

            _windows.SetSymbolCount(0); //  Стартовое  значение 

            _windows.ContentChane += _windows_ContentChane;
            _windows.FileOpen += _windows_FileOpen;
            _windows.FileSave += _windows_FileSave;
        }

        private void _windows_FileSave(object sender, EventArgs e)
        {
            try
            {
                string filePath = _windows.FilePath;

                if(! _manager.IsExistFile(filePath))
                {
                    _message.MessageError("Файл отстствует"); return;
                }

                string Conntent = _windows.Content;
                _manager.SaveContent(filePath, Conntent);

                _message.MessageMessage("Файл сохранился");
            }
            catch 
            {
                _message.MessageError("Ошибка сохрания");
            }
        }

        private void _windows_FileOpen(object sender, EventArgs e)
        {
            try
            {
                string filePath = _windows.FilePath;

                if (!_manager.IsExistFile(filePath))
                {
                    _message.MessageError("Файл отстствует");
                    return;
                }

                string conntent = _manager.GetContent(filePath);
                _windows.Content = conntent;
            }
            catch
            {
                _message.MessageError("Ошибка Открытия файла");
            }
        }

        private void _windows_ContentChane(object sender, EventArgs e)
        {
            string content = _windows.Content;
            int count = _manager.GetSymbolCount(content);
            _windows.SetSymbolCount(count);
        }
    }
}