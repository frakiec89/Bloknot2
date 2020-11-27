using System;
using System.Windows;
using System.Windows.Documents;
using Blocnot.BL;
using Microsoft.Win32; // Эту бибилиотеку  надо

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
            tbContent.TextChanged += MainWindow_ContentChane;
            slSize.ValueChanged += SlSize_ValueChanged;

            btSelect.Click += BtSelect_Click;


            WindowCollection windowCollection = App.Current.Windows;


            FileManager fileMabeger = new FileManager();
            MessageServis messageServis = new MessageServis();
             MyPresenter myPresenter = new MyPresenter(messageServis, this , fileMabeger);

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
            tbContent.Document = new FlowDocument();

            if (FileOpen != null) 
            {
                FileOpen(this, EventArgs.Empty); 
            }
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
            lbCountSimbol.Content = "Колл-во  символов " +  count.ToString();
        }

        /// <summary>
        /// Открывает  окно диалга для выбора файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //  using Microsoft.Win32; // Эту бибилиотеку  надо

           if  (  dialog.ShowDialog()== true)
            {
                tbFilePath.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Меняет  размер  шрифта контента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbContent.FontSize = slSize.Value;
        }
    }
}
