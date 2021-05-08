//-----------------------------------------------------------------------
// <copyright file=MainWindow.xaml.cs company="纳米维景">
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

namespace CTCommunication
{
    using CTCommunication.Class;
    using System;
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// MainWindow.xaml 的交互逻辑.
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
       

      

        /// <summary>
        /// Defines the dicomTool.
        /// </summary>
        private UIPage.DicomTool dicomTool;

     

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //SetSettingXmlIniValue();
          //  ReadSettingXMLToClass();
            // SetSettingXmlIniValue();
           // ReadProtocolXMLToClass();
            PrintVersionAndTime();
            Window_Main.Title = $"TestTool                                Version:{AssemblyFileVersion()}";
        }
        #region 获取版本号并打印

        void PrintVersionAndTime()
        {
            string info = $"DLLName:{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.Version:{AssemblyFileVersion()}.Create Time:{GetBuildDateTime().ToString("yyyy: MM:dd   HH:mm: ss")}";
            log.Info(info);
        }
        private string AssemblyFileVersion()
        {

            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private DateTime GetBuildDateTime()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
            TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
            TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)
            return buildDateTime;
        }
        #endregion
        #endregion

        #region Methods

    
        /// <summary>
        /// The RB_DicomView_Checked.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void RB_DicomView_Checked(object sender, RoutedEventArgs e)
        {
            dicomTool = new UIPage.DicomTool();
            Frame_Page.Content = dicomTool;
          //  _SettingData.DefaultPage = "DicomTool";
        }

      

      
     
        /// <summary>
        /// 根据类生成xml文件.
        /// </summary>
        private void SetSettingXmlIniValue()
        {
           // _SettingData.DefaultPage = "DicomTagView";
            Setting_DicomTool setting_DicomTool = new Setting_DicomTool();
            Setting_MRSTest setting_MRSTest = new Setting_MRSTest();
            Setting_FlowTest setting_FlowTest = new Setting_FlowTest();
            Setting_CanTest setting_CanTest = new Setting_CanTest();

            setting_DicomTool.RawWidth = "768";

            setting_MRSTest.CmdChannelPort = 10087;
            setting_MRSTest.ControlChannelPort = 10027;
            setting_MRSTest.DataChannelPort = 10088;
            setting_MRSTest.HeartBeatSpan = 5000;
            setting_MRSTest.HeartBeatTimeOutTime = 10000;
            setting_MRSTest.IP = "172.18.21.44";
            setting_MRSTest.ScanEndPosition = "500";
            setting_MRSTest.ScanStartPosition = "800";
            setting_MRSTest.TOPOFilePath = @"E:\Temp\";
            setting_MRSTest.DICOMFilePath = @"E:\Data\";

            setting_FlowTest.CmdChannelPort = 10087;
            setting_FlowTest.ControlChannelPort = 10027;
            setting_FlowTest.DataChannelPort = 10088;
            setting_FlowTest.HeartBeatSpan = 5000;
            setting_FlowTest.HeartBeatTimeOutTime = 10000;
            setting_FlowTest.IP = "172.18.21.44";
            setting_FlowTest.ScanEndPosition = "500";
            setting_FlowTest.ScanStartPosition = "800";
            setting_FlowTest.TirggerAccuracy = 0.2f;
            setting_FlowTest.AccelerateDistance = 30f;
            setting_FlowTest.BedMoveSpeed = 80f;
            setting_FlowTest.TOPOFilePath = @"E:\Temp\";
            setting_FlowTest.DICOMFilePath = @"E:\Data\";

            setting_CanTest.BedLoopMove_Position1 = "800";
            setting_CanTest.BedLoopMove_Position2 = "1200";
            setting_CanTest.BedLoopMove_Offset = 0.5;
            setting_CanTest.BedLoopMove_Speed = "80";
            setting_CanTest.BedMove_Height = "971";
            setting_CanTest.BedMove_Position = "1200";
            setting_CanTest.BedMove_Speed = "90";
            setting_CanTest.Box_LoopSpan = "500";
            setting_CanTest.Panel_LoopSpan = "500";

         //   _SettingData.setting_CanTest = setting_CanTest;
         //   _SettingData.setting_FlowTest = setting_FlowTest;
         //   _SettingData.setting_MRSTest = setting_MRSTest;
         //   _SettingData.setting_DicomTool = setting_DicomTool;
         //   string strxml = XMLHelper.XmlSerialize<SettingData>(_SettingData);
         //   string path = AppDomain.CurrentDomain.BaseDirectory + "Setting\\" + "Setting.xml";
          //  System.IO.File.WriteAllText(path, strxml);
        }

        /// <summary>
        /// The StackPanel_Loaded.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
         
                    RB_DicomView.IsChecked = true;
                   
            
        }

        /// <summary>
        /// The Window_Closed.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void Window_Closed(object sender, EventArgs e)
        {
           // SaveSetting();
            Environment.Exit(0);
        }

        #endregion
    }
}
