using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blocnot.BL
{
    
    public  interface IMessageServis
    {
        void ShowMessage(string message);
        void ShowExclamation (string message);
        void ShowError(string message);
    }

    public class MessageServis : IMessageServis
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение",  MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowExclamation(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
