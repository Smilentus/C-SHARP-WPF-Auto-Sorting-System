using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FileSortingSystemV2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.LoadData();
            ReDrawUI();
        }

        public void ReDrawUI()
        {
            sortPathBox.Text = DataBase.sortPath;

            pathsPanel.Children.Clear();
            
            for (int i = 0; i < DataBase.createdPaths.Count; i++)
            {
                Canvas canvas = new Canvas();
                canvas.Style = this.Resources["canvasPath"] as Style;
                canvas.Name = "CNV" + i;

                Label lbl = new Label();
                lbl.Style = this.Resources["pathText"] as Style;
                lbl.Content = DataBase.createdPaths[i].getNameTag;
                canvas.MouseLeftButtonUp += EditPath_Click;

                canvas.Children.Add(lbl);
                pathsPanel.Children.Add(canvas);
            }

            pathsPanel.Height = DataBase.createdPaths.Count * 40;
        }

        private void EditPath_Click(object sender, RoutedEventArgs e)
        {
            Canvas cnv = (Canvas)sender;
            int index = int.Parse(cnv.Name.Replace("CNV", ""));
            DataBase.openedIndex = index;
            DataBase.isEditing = true;
            InputPathWindow IPW = new InputPathWindow();
            IPW.ShowDialog();
            ReDrawUI();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            SortResultWindow window = new SortResultWindow();
            window.Show();

            string[] files;
            try
            {
                files = Directory.GetFiles(DataBase.sortPath);
            } 
            catch(IOException ex)
            {
                window.AddInfo("Произошла ошибка! \n" + ex.GetType().Name);
                return;
            }

            string ext = "";
            bool isSorted = false;
            customPath otherPath = new customPath();

            if (files.Length == 0)
            {
                window.AddInfo("[WARNING] Сортировочная папка пустая!");
            }
            else
            {
                if (DataBase.createdPaths.Count == 0)
                {
                    window.AddInfo("[WARNING] Сортировочные пути не были найдены!");
                }
                else
                {
                    foreach (var file in files)
                    {
                        if (Directory.Exists(file))
                        {
                            window.AddInfo($"[WARNING] Замечена папка -> {file}");
                            continue;
                        }
                        
                        ext = System.IO.Path.GetExtension(file);
                        isSorted = false;

                        foreach (var path in DataBase.createdPaths)
                        {
                            if (path.constructedTag == "{other}")
                                otherPath = path;

                            if (Directory.Exists(path.constructedPath))
                            {
                                if (path.constructedExtensions.Contains(ext) || (file.Contains(path.constructedTag) && !string.IsNullOrEmpty(path.constructedTag)))
                                {
                                    isSorted = true;
                                    MoveFile(file, path, window);
                                    break;
                                }
                            }
                        }

                        if (!isSorted)
                        {
                            if (!SortSettings.sortToOther)
                                window.AddInfo($"[FAILURE] {file}");
                            else
                            {
                                if (otherPath != null)
                                    MoveFile(file, otherPath, window);
                                else
                                    window.AddInfo($"[FAILURE_S_T_O] {file}");
                            }
                        }
                    }

                    window.EndSorting();
                }
            }
        }

        private void MoveFile(string file, customPath path, SortResultWindow window)
        {
            string fileName = System.IO.Path.GetFileName(file);
            string crp = "";
            if (path.constructedPath[path.constructedPath.Length - 1] == '\\')
                crp = path.constructedPath + fileName;
            else
                crp = path.constructedPath + "\\" + fileName;
            int fileCounter = 0;
            string templateName = crp;
            while (File.Exists(crp))
            {
                fileCounter++;
                templateName = crp + fileCounter;
            }
            crp = templateName;
            File.Move(file, crp);
            window.AddInfo($"[SUCCESS] {file}");
        }

        private void SortPathBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Title = "Выбор пути для папки назначения ... ";
            dialog.IsFolderPicker = true;
            dialog.InitialDirectory = @"C:\";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                sortPathBox.Text = dialog.FileName;
            }
            else
            {
                // ... Nothing
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBase.createdPaths.Add(new customPath("", "", ""));
            DataBase.openedIndex = DataBase.createdPaths.Count - 1;
            DataBase.isEditing = false;
            InputPathWindow IPW = new InputPathWindow();
            IPW.ShowDialog();
            ReDrawUI();
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sortPathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataBase.sortPath = sortPathBox.Text;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataBase.SaveData();
        }
    }
}
