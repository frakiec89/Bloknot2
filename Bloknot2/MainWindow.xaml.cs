using System;
using System.Windows;
using System.Windows.Documents;
using Blocnot.BL;
using Microsoft.Win32; // это надо

namespace Bloknot2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,IMainWindow
    {
        public string FilePath
        {
            get
            {
                return tbFilePath.Text;
            }
        }
        string IMainWindow.Content
        {
            get
            {
                TextRange textRange = new TextRange(tbContent.Document.ContentStart, tbContent.Document.ContentEnd);
                return textRange.Text;
            }
            set
            {
                tbContent.Document = new FlowDocument();//пустой  документ
                tbContent.AppendText(value); // 
            }
        }

        public event EventHandler FileOpen;
        public event EventHandler FileSave;
        public event EventHandler ContentChane;
      
        public MainWindow()
        {
            InitializeComponent();
            btOpen.Click += BtOpen_Click;
            btSave.Click += BtSave_Click;
            tbContent.TextChanged += TbContent_TextChanged;
            btSelect.Click += BtSelect_Click;
            slSize.ValueChanged += SlSize_ValueChanged;
            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Blocnot.BL.FileManager fileManager = new FileManager();
            MessageManager messageManager = new MessageManager();

            Blocnot.BL.MyPressenter pressenter = new MyPressenter(fileManager, this, messageManager); // подписали призентер  к онку 
        }

        private void SlSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbContent.FontSize = slSize.Value; // изменять  размер  шрифта
        }

        private void BtSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if ( openFileDialog.ShowDialog() == true)
            {
                tbFilePath.Text = openFileDialog.FileName;
            }
        }

        #region проброс событий
        private void TbContent_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
          if(ContentChane!=null)
            {
                ContentChane(this, EventArgs.Empty);
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if(FileSave!=null)
            {
                FileSave(this, EventArgs.Empty);
            }
        }

        private void BtOpen_Click(object sender, RoutedEventArgs e)
        {
            if (FileOpen != null)
            {
                FileOpen(this, EventArgs.Empty);  
            }
        }
        #endregion

        public void SetSymbolCount(int count)
        {
            lbCountSymbol.Content = "Кол-во символов: " + count.ToString();
        }
    }
}
