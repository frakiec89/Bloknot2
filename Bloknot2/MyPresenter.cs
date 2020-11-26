using Blocnot.BL; // это  надо
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloknot2
{
    public class MyPresenter
    {
        private IMainWindow _window;
        private IFileManager _manager;
        private IMessageServis _message;

        private string _FilePath;
        

        MyPresenter (  IMessageServis message , IMainWindow window , IFileManager manager )
        {
           _message = message;
           _window = window;
           _manager = manager;


            _window.SetSymbolCount(0);

            _window.FileSave += _window_FileSave;
            _window.FileOpen += _window_FileOpen;
            _window.ContentChane += _window_ContentChane;
        }

        private void _window_ContentChane(object sender, EventArgs e)
        {
            string content = _window.Content;
            int count = _manager.GetSymbolCount(content);
            _window.SetSymbolCount(count);
        }

        private void _window_FileOpen(object sender, EventArgs e)
        {
            try
            {
                _FilePath = _window.FilePath;

                if (!_manager.IsExistFile(_FilePath))
                {
                    _message.ShowError("Файл  не существует");
                    return;
                }

                string content = _manager.GetContent(_FilePath);
                int count = _manager.GetSymbolCount(content);

                _window.Content = content;
                _window.SetSymbolCount(count);
            }
            catch ( Exception ex)
            {
                _message.ShowError(ex.Message);
            }
        }

        private void _window_FileSave(object sender, EventArgs e)
        {
            try
            {
                string content = _window.Content;
                _manager.SaveContent(_FilePath, content);
                _message.ShowMessage("Сохранение прошло успешно");
            }
            catch
            {
                _message.ShowError("Ошибка сохранения");
            }
        }
    }
}
