using Blocnot.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bloknot2
{
    public interface IMainWindow
    {
        string FilePath { get; }
        string Content { get; set; }

        event EventHandler FileOpen;
        event EventHandler FileSave;
        event EventHandler ContentChane;
        void SetSymbolCount(int count);
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,IMainWindow
    {
        // todo Реализовать  интрефей IMainWindow
        public MainWindow()
        {
            InitializeComponent();
        }

        public string FilePath => throw new NotImplementedException();

        string IMainWindow.Content { get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); }


        #region Здесь  просыны события

        public event EventHandler FileOpen;
        public event EventHandler FileSave;
        public event EventHandler ContentChane;

        #endregion

        public void SetSymbolCount(int count)
        {
            throw new NotImplementedException();
        }
    }
}
