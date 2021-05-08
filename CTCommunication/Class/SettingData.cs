//-----------------------------------------------------------------------
// <copyright file=SettingData.cs company="纳米维景">
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

namespace CTCommunication.Class
{
    /// <summary>
    /// Defines the <see cref="Setting_CanTest" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Setting_CanTest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the BedLoopMove_Offset.
        /// </summary>
        public double BedLoopMove_Offset { get; set; }

        /// <summary>
        /// Gets or sets the BedLoopMove_Position1.
        /// </summary>
        public string BedLoopMove_Position1 { get; set; }

        /// <summary>
        /// Gets or sets the BedLoopMove_Position2.
        /// </summary>
        public string BedLoopMove_Position2 { get; set; }

        /// <summary>
        /// Gets or sets the BedLoopMove_Speed.
        /// </summary>
        public string BedLoopMove_Speed { get; set; }

        /// <summary>
        /// Gets or sets the BedMove_Height.
        /// </summary>
        public string BedMove_Height { get; set; }

        /// <summary>
        /// Gets or sets the BedMove_Position.
        /// </summary>
        public string BedMove_Position { get; set; }

        /// <summary>
        /// Gets or sets the BedMove_Speed.
        /// </summary>
        public string BedMove_Speed { get; set; }

        /// <summary>
        /// Gets or sets the Box_LoopSpan.
        /// </summary>
        public string Box_LoopSpan { get; set; }

        /// <summary>
        /// Gets or sets the Panel_LoopSpan.
        /// </summary>
        public string Panel_LoopSpan { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="Setting_DicomTool" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Setting_DicomTool
    {
        #region Properties

        /// <summary>
        /// Gets or sets the RawWidth.
        /// </summary>
        public string RawWidth { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="Setting_FlowTest" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Setting_FlowTest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the AccelerateDistance
        /// 加速距离 减速距离  用于定位像和螺旋  使床匀速..
        /// </summary>
        public float AccelerateDistance { get; set; }

        /// <summary>
        /// Gets or sets the BedMoveSpeed.
        /// </summary>
        public float BedMoveSpeed { get; set; }

        /// <summary>
        /// Gets or sets the CmdChannelPort.
        /// </summary>
        public int CmdChannelPort { get; set; }

        /// <summary>
        /// Gets or sets the ControlChannelPort.
        /// </summary>
        public int ControlChannelPort { get; set; }

        /// <summary>
        /// Gets or sets the DataChannelPort.
        /// </summary>
        public int DataChannelPort { get; set; }

        /// <summary>
        /// Gets or sets the DICOMFilePath.
        /// </summary>
        public string DICOMFilePath { get; set; }

        /// <summary>
        /// Gets or sets the HeartBeatSpan.
        /// </summary>
        public int HeartBeatSpan { get; set; }

        /// <summary>
        /// Gets or sets the HeartBeatTimeOutTime.
        /// </summary>
        public int HeartBeatTimeOutTime { get; set; }

        /// <summary>
        /// Gets or sets the IP.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the ScanEndPosition.
        /// </summary>
        public string ScanEndPosition { get; set; }

        /// <summary>
        /// Gets or sets the ScanStartPosition.
        /// </summary>
        public string ScanStartPosition { get; set; }

        /// <summary>
        /// Gets or sets the TirggerAccuracy
        /// 扫描触发精度..
        /// </summary>
        public float TirggerAccuracy { get; set; }

        /// <summary>
        /// Gets or sets the TOPOFilePath.
        /// </summary>
        public string TOPOFilePath { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="Setting_MRSTest" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Setting_MRSTest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CmdChannelPort.
        /// </summary>
        public int CmdChannelPort { get; set; }

        /// <summary>
        /// Gets or sets the ControlChannelPort.
        /// </summary>
        public int ControlChannelPort { get; set; }

        /// <summary>
        /// Gets or sets the DataChannelPort.
        /// </summary>
        public int DataChannelPort { get; set; }

        /// <summary>
        /// Gets or sets the DICOMFilePath.
        /// </summary>
        public string DICOMFilePath { get; set; }

        /// <summary>
        /// Gets or sets the HeartBeatSpan.
        /// </summary>
        public int HeartBeatSpan { get; set; }

        /// <summary>
        /// Gets or sets the HeartBeatTimeOutTime.
        /// </summary>
        public int HeartBeatTimeOutTime { get; set; }

        /// <summary>
        /// Gets or sets the IP.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the ScanEndPosition.
        /// </summary>
        public string ScanEndPosition { get; set; }

        /// <summary>
        /// Gets or sets the ScanStartPosition.
        /// </summary>
        public string ScanStartPosition { get; set; }

        /// <summary>
        /// Gets or sets the TOPOFilePath.
        /// </summary>
        public string TOPOFilePath { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="SettingData" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class SettingData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the DefaultPage.
        /// </summary>
        public string DefaultPage { get; set; }

        /// <summary>
        /// Gets or sets the setting_CanTest.
        /// </summary>
        public Setting_CanTest setting_CanTest { get; set; }

        /// <summary>
        /// Gets or sets the setting_DicomTool.
        /// </summary>
        public Setting_DicomTool setting_DicomTool { get; set; }

        /// <summary>
        /// Gets or sets the setting_FlowTest.
        /// </summary>
        public Setting_FlowTest setting_FlowTest { get; set; }

        /// <summary>
        /// Gets or sets the setting_MRSTest.
        /// </summary>
        public Setting_MRSTest setting_MRSTest { get; set; }

        #endregion
    }
}
