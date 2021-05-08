//-----------------------------------------------------------------------
// <copyright file=DicomTool.xaml.cs company="纳米维景">
// 版权所有 (C)2020,纳米维景(上海)医疗科技有限公司
// </copyright>
// ---------------------------------------------------------------------
// <summary>
//  修改日期                         版本号       		创建人     
// 2020/9/10           	      		V0.0.1        	   zyp     
// </summary>
// ---------------------------------------------------------------------
// <key>
// 
// </key>
//-----------------------------------------------------------------------

namespace CTCommunication.UIPage
{
    using CTCommunication.Class;
    using Dicom;
    using Dicom.Imaging;
    using Microsoft.WindowsAPICodePack.Dialogs;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// DicomTool.xaml 的交互逻辑.
    /// </summary>
    public partial class DicomTool : Page
    {
        #region Fields

        /// <summary>
        /// 储存多个收到的dicom文件..
        /// </summary>
        public List<MyDicom> Li_DicomImages = new List<MyDicom>();

        /// <summary>
        /// Defines the log.
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Defines the bitmap.
        /// </summary>
        private Bitmap bitmap = null;

        /// <summary>
        /// Defines the myDicom.
        /// </summary>
        private MyDicom myDicom = null;

        /// <summary>
        /// Defines the pixel.
        /// </summary>
        private byte[] pixel = null;

        /// <summary>
        /// Defines the pt_Down.
        /// </summary>
        private System.Windows.Point pt_Down;

        /// <summary>
        /// Defines the rawPixelData.
        /// </summary>
        private byte[] rawPixelData;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DicomTool"/> class.
        /// </summary>
        public DicomTool()
        {
            InitializeComponent();
            ImageManager.SetImplementation(WPFImageManager.Instance);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The AddDicomFromDir.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        private void AddDicomFromDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            //try
            //{
            //判断所指的文件夹/文件是否存在
            if (!dir.Exists)
            {
                log.Error("文件夹不存在" + path);
                return;
            }
            Li_DicomImages = new List<MyDicom>();
            DirectoryInfo dirD = dir as DirectoryInfo;
            FileSystemInfo[] files = dirD.GetFiles().OrderBy(f => f.LastWriteTime).ToArray();//获取文件夹下所有文件和文件夹
            //Array.Sort(files);
            foreach (FileSystemInfo FSys in files)
            {
                if (File.Exists(FSys.FullName) && FSys.Name.Contains("dcm"))
                {
                    FileInfo fileInfo = FSys as FileInfo;

                    if (fileInfo != null)
                    {
                        //如果是文件，进行文件操作
                        // FileInfo SFInfo = new FileInfo(fileInfo.DirectoryName + "\\" + fileInfo.Name);//获取文件所在原始路径
                        string filePath = fileInfo.DirectoryName + "\\" + fileInfo.Name;
                        if (filePath.ToLower().Contains("dcm"))
                        {
                            MyDicom myDicom1 = new MyDicom(Dicom.DicomFile.Open(filePath));
                            Li_DicomImages.Add(myDicom1);
                        }
                        else
                        {
                            Li_DicomImages.Clear();
                            byte[] temp = System.IO.File.ReadAllBytes(filePath);
                            DicomFile dicomFile = StaticImageFun.GetDicomFileByRaw(temp, temp.Length / (int.Parse(TB_TopoWidth.Text) * 2), int.Parse(TB_TopoWidth.Text));
                            MyDicom myDicom1 = new MyDicom(dicomFile);
                            Li_DicomImages.Add(myDicom1);
                        }
                    }
                }
            }
            if (Li_DicomImages.Count != 0)
            {
                RefreshDicomDirInfo();
            }
        }

        /// <summary>
        /// The AddDicomFromFile.
        /// </summary>
        /// <param name="str">The str<see cref="string[]"/>.</param>
        private void AddDicomFromFile(string[] str)
        {
            Li_DicomImages = new List<MyDicom>();
            rawPixelData = new byte[] { };
            //string[] files = str;
            List<FileInfo> files = new List<FileInfo>();
            str.Each(x => files.Add(new FileInfo(x)));
            // FileInfo[] fileInfos_Array = files.ToArray();
            files = files.OrderBy(f => f.LastWriteTime).ToList();
            // Array.Sort(files);
            foreach (var file_ in files)
            {
                string file = file_.FullName;
                if (file.ToLower().Contains(".dcm"))
                {
                    MyDicom myDicom1 = new MyDicom(Dicom.DicomFile.Open(file));
                    Li_DicomImages.Add(myDicom1);
                }
                else if (file.ToLower().Contains(".raw"))
                {
                    Li_DicomImages.Clear();
                    byte[] temp = System.IO.File.ReadAllBytes(file);
                    rawPixelData = rawPixelData.Concat<byte>(temp).ToArray();
                    DicomFile dicomFile = StaticImageFun.GetDicomFileByRaw(rawPixelData, rawPixelData.Length / (int.Parse(TB_TopoWidth.Text) * 4), int.Parse(TB_TopoWidth.Text));
                    MyDicom myDicom1 = new MyDicom(dicomFile);
                    Li_DicomImages.Add(myDicom1);
                }
            }
            if (Li_DicomImages.Count != 0)
            {
                RefreshDicomDirInfo();
            }
        }

        /// <summary>
        /// The AddRAWFromDir.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        private void AddRAWFromDir(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            //try
            //{
            //判断所指的文件夹/文件是否存在
            if (!dir.Exists)
            {
                log.Error("文件夹不存在" + path);
                return;
            }
            Li_DicomImages = new List<MyDicom>();
            DirectoryInfo dirD = dir as DirectoryInfo;
            FileSystemInfo[] files = dirD.GetFiles().OrderBy(f => f.LastWriteTime).ToArray();//获取文件夹下所有文件和文件夹
            rawPixelData = new byte[] { };
            // Array.Sort(files);
            MyDicom myDicom1 = null;
            foreach (FileSystemInfo FSys in files)
            {
                if (File.Exists(FSys.FullName) && FSys.Name.Contains(".raw"))
                {
                    FileInfo fileInfo = FSys as FileInfo;

                    if (fileInfo != null)
                    {
                        //如果是文件，进行文件操作
                        // FileInfo SFInfo = new FileInfo(fileInfo.DirectoryName + "\\" + fileInfo.Name);//获取文件所在原始路径
                        string filePath = fileInfo.DirectoryName + "\\" + fileInfo.Name;
                        Li_DicomImages.Clear();
                        byte[] temp = System.IO.File.ReadAllBytes(filePath);
                        rawPixelData = rawPixelData.Concat(temp).ToArray();
                        DicomFile dicomFile = StaticImageFun.GetDicomFileByRaw(rawPixelData, rawPixelData.Length / (int.Parse(TB_TopoWidth.Text) * 2), int.Parse(TB_TopoWidth.Text));
                        myDicom1 = new MyDicom(dicomFile);
                    }
                }
            }
            if (myDicom1 != null)
            {
                Li_DicomImages.Add(myDicom1);
            }
            if (Li_DicomImages.Count != 0)
            {
                RefreshDicomDirInfo();
            }
        }

        /// <summary>
        /// The Grid_ImageView_Drop.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DragEventArgs"/>.</param>
        private void Grid_ImageView_Drop(object sender, DragEventArgs e)
        {
            string dropFile = "Drop";
            string[] dropFiles = new string[] { };
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                int count = ((System.Array)e.Data.GetData(System.Windows.DataFormats.FileDrop)).Length;
                dropFiles = new string[count];
                for (int i = 0; i < count; i++)
                {
                    dropFile = ((System.Array)e.Data.GetData(System.Windows.DataFormats.FileDrop)).GetValue(i).ToString();
                    dropFiles[i] = dropFile;
                    if (Directory.Exists(dropFile))
                    {
                        OperatepDropFile(dropFile);
                        return;
                    }
                }
                AddDicomFromFile(dropFiles);
            }
        }

        /// <summary>
        /// The Grid_ImageView_MouseMove.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseEventArgs"/>.</param>
        private void Grid_ImageView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && myDicom != null)
            {
                if (pt_Down == new System.Windows.Point(0, 0))
                {
                    pt_Down = e.GetPosition(Grid_ImageView);
                    return;
                }
                if (pt_Down == e.GetPosition(Grid_ImageView))
                {
                    return;
                }
                System.Windows.Point ptCurrent = e.GetPosition(Grid_ImageView);
                if (Math.Abs((ptCurrent.X - pt_Down.X)) > 50 || Math.Abs((ptCurrent.Y - pt_Down.Y)) > 50)
                {
                    pt_Down = e.GetPosition(Grid_ImageView);
                    return;
                }
                myDicom.WindowWidth += (ptCurrent.X - pt_Down.X) * 50;
                myDicom.WindowCenter += (ptCurrent.Y - pt_Down.Y) * 50;
                Update_Image();
                // Update_Image((ptCurrent.X - pt_Down.X), (ptCurrent.Y - pt_Down.Y));
                pt_Down = e.GetPosition(Grid_ImageView);
            }
        }

        /// <summary>
        /// The Grid_ImageView_MouseWheel.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseWheelEventArgs"/>.</param>
        private void Grid_ImageView_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                double valueToSet = SB_PicSelect.Value + 1;
                if (valueToSet <= SB_PicSelect.Maximum)
                {
                    SB_PicSelect.Value = valueToSet;
                }
            }
            else
            {
                double valueToSet = SB_PicSelect.Value - 1;

                if (valueToSet >= SB_PicSelect.Minimum)
                {
                    SB_PicSelect.Value = valueToSet;
                }
            }
        }

        /// <summary>
        /// The Image_View_MouseMove.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="MouseEventArgs"/>.</param>
        private void Image_View_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(Image_View);
        }

        /// <summary>
        /// The MenuItem_OpFile_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void MenuItem_OpFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Title = "Select Files";
            string filter = "RAW Pixel(*.raw)|*.raw|DCM(*.dcm)|*.dcm";
            openFileDialog.Filter = filter;
            openFileDialog.FileName = "Select DCM or RAW File.";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = true;//允许同时选择多个文件
            bool? result = openFileDialog.ShowDialog();
            if (result != true)
            {
                return;
            }
            else
            {
                AddDicomFromFile(openFileDialog.FileNames);
            }
        }

        /// <summary>
        /// The MenuItem_OpFileDir_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void MenuItem_OpFileDir_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Select .dcm or .raw";
            dlg.IsFolderPicker = true;

            // dlg.InitialDirectory = currentDirectory;
            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            //  dlg.DefaultDirectory = currentDirectory;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //var folder = dlg.FileName;
                // Do something with selected folder string
                OperatepDropFile(dlg.FileName);
            }
        }

        /// <summary>
        /// The MI_ResetWWAndWC_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void MI_ResetWWAndWC_Click(object sender, RoutedEventArgs e)
        {
            Image_View.Source = myDicom.ResetWWAndWC();
            TBlock_WW.Text = "WW:" + ((int)(myDicom.WindowWidth)).ToString();
            TBlock_WC.Text = "WC:" + ((int)(myDicom.WindowCenter)).ToString();
        }

        /// <summary>
        /// The OP_TAG_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void OP_TAG_Click(object sender, RoutedEventArgs e)
        {
            UIPage.Controls.DicomTagView dicomTagView = new Controls.DicomTagView(myDicom);
            dicomTagView.Show();
        }

        /// <summary>
        /// The OperatepDropFile.
        /// </summary>
        /// <param name="dropFile">The dropFile<see cref="object"/>.</param>
        private void OperatepDropFile(object dropFile)
        {
            if (Directory.Exists(dropFile.ToString()))
            {
                DirectoryInfo dir = new DirectoryInfo(dropFile.ToString());
                FileInfo[] files = dir.GetFiles().OrderBy(f => f.LastWriteTime).ToArray();//获取文件夹下所有文件和文件夹
                if (files.Length == 0)
                {
                    return;
                }
                if (files[0].FullName.Contains(".dcm"))
                {
                    AddDicomFromDir(dropFile.ToString());
                    return;
                }
                string name = "";
                for (int i = 0; i < files.Length; i++)
                {
                    name += files[i];
                }
                if (name.Contains(".raw"))       //raw数据拼接
                {
                    AddRAWFromDir(dropFile.ToString());
                    return;
                }
            }
        }

        /// <summary>
        /// The Page_Loaded.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// The RefreshDicomDirInfo.
        /// </summary>
        private void RefreshDicomDirInfo()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (Li_DicomImages.Count > 0)
                {
                    SB_PicSelect.Minimum = 0;
                    SB_PicSelect.Maximum = Li_DicomImages.Count - 1;
                    SB_PicSelect.Value = 0;
                    TBlock_ImageIndexAndCount.Text = ((int)(SB_PicSelect.Value) + 1).ToString() + "/" + (SB_PicSelect.Maximum + 1);
                    myDicom = Li_DicomImages[0];
                    Update_Image();
                }
            }));
        }

        /// <summary>
        /// The SB_PicSelect_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedPropertyChangedEventArgs{double}"/>.</param>
        private void SB_PicSelect_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            if (Li_DicomImages.Count > 0)
            {
                Image_View.Source = Li_DicomImages[(int)SB_PicSelect.Value].RendImage();
                TBlock_ImageIndexAndCount.Text = ((int)(SB_PicSelect.Value) + 1).ToString() + "/" + (SB_PicSelect.Maximum + 1);
                myDicom = Li_DicomImages[(int)SB_PicSelect.Value];
            }
        }

        /// <summary>
        /// The TB_TopoWidth_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="TextChangedEventArgs"/>.</param>
        private void TB_TopoWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
           // MainWindow._SettingData.setting_DicomTool.RawWidth = TB_TopoWidth.Text;
        }

        /// <summary>
        /// The Update_Image.
        /// </summary>
        private void Update_Image()
        {
            Image_View.Source = myDicom.RendImageByWWAndWC();
            TBlock_WW.Text = "WW:" + ((int)(myDicom.WindowWidth)).ToString();
            TBlock_WC.Text = "WC:" + ((int)(myDicom.WindowCenter)).ToString();
        }

        #endregion
    }
}
