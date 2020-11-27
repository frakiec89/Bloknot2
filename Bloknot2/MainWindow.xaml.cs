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
        public string FilePath => throw new NotImplementedException();

        string IMainWindow.Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler FileOpen;
        public event EventHandler FileSave;
        public event EventHandler ContentChane;

      
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetSymbolCount(int count)
        {
            throw new NotImplementedException();
        }
    }
}
