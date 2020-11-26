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

        public event EventHandler FileOpen;
        public event EventHandler FileSave;
        public event EventHandler ContentChane;

      
        public MainWindow()
        {
            InitializeComponent();
            btOpen.Click += BtOpen_Click;
            btSave.Click += BtSave_Click;
            ContentChane += MainWindow_ContentChane;
        }

        private void MainWindow_ContentChane(object sender, EventArgs e)
        {
            if (ContentChane != null)
            {
               ContentChane(this, EventArgs.Empty);
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (FileSave!=null)
            {
                FileSave(this, EventArgs.Empty);
            }
        }

        private void BtOpen_Click(object sender, RoutedEventArgs e)
        {
            if (FileOpen != null) { FileOpen(this, EventArgs.Empty); }
        }

        public string FilePath
        {
            get
            {
                return tbFilePath.Text;
            }
        }

        string IMainWindow.Content 
        { 
            get { return new TextRange(tbContent.Document.ContentStart, tbContent.Document.ContentEnd).Text; }
            set { tbContent.AppendText(value); }
        }


        public void SetSymbolCount(int count)
        {
            throw new NotImplementedException();
        }
    }
}
