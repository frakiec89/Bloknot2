using Blocnot.BL; /// Это надо
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; // Это надо 

namespace Bloknot2
{
    public class MessageManager : IMassegeManager
    {
        public void MessageError(string mwssage)
        {
            MessageBox.Show(mwssage, "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void MessageMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
