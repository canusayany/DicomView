//-----------------------------------------------------------------------
// <copyright file=XMLProtocolTransClass.cs company="纳米维景">
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
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="Protocol" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [System.SerializableAttribute()]
    public class Protocol
    {
        #region Properties

        /// <summary>
        /// Gets or sets the BodySize.
        /// </summary>
        public string BodySize { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ExamPartID.
        /// </summary>
        public string ExamPartID { get; set; }

        /// <summary>
        /// Gets or sets the IsEmergency.
        /// </summary>
        public string IsEmergency { get; set; }

        /// <summary>
        /// Gets or sets the IsEnhanced.
        /// </summary>
        public string IsEnhanced { get; set; }

        /// <summary>
        /// Gets or sets the IsFactory.
        /// </summary>
        public string IsFactory { get; set; }

        /// <summary>
        /// Gets or sets the IsTabletSuitable.
        /// </summary>
        public string IsTabletSuitable { get; set; }

        /// <summary>
        /// Gets or sets the IsValid.
        /// </summary>
        public string IsValid { get; set; }

        /// <summary>
        /// Gets or sets the PatientPosition.
        /// </summary>
        public string PatientPosition { get; set; }

        /// <summary>
        /// Gets or sets the ProtocolFamily.
        /// </summary>
        public string ProtocolFamily { get; set; }

        /// <summary>
        /// Gets or sets the ProtocolID.
        /// </summary>
        public string ProtocolID { get; set; }

        /// <summary>
        /// Gets or sets the ProtocolName.
        /// </summary>
        public string ProtocolName { get; set; }

        /// <summary>
        /// Gets or sets the ScanEntry.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ScanEntry")]
        public List<ScanEntryClass> ScanEntry { get; set; }

        /// <summary>
        /// Gets or sets the ScanMode.
        /// </summary>
        public string ScanMode { get; set; }

        /// <summary>
        /// Gets or sets the SortID.
        /// </summary>
        public string SortID { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="ReconJob" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.SerializableAttribute()]
    public class ReconJob
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Center_X.
        /// </summary>
        [XmlElement(ElementName = "Center-X")]
        public string Center_X { get; set; }

        /// <summary>
        /// Gets or sets the Center_Y.
        /// </summary>
        [XmlElement(ElementName = "Center-Y")]
        public string Center_Y { get; set; }

        /// <summary>
        /// Gets or sets the DenoiseCoef.
        /// </summary>
        public string DenoiseCoef { get; set; }

        /// <summary>
        /// Gets or sets the FOV.
        /// </summary>
        public string FOV { get; set; }

        /// <summary>
        /// Gets or sets the Height.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets the ImageOrder.
        /// </summary>
        public string ImageOrder { get; set; }

        /// <summary>
        /// Gets or sets the Increment.
        /// </summary>
        public string Increment { get; set; }

        /// <summary>
        /// Gets or sets the Kernel.
        /// </summary>
        public string Kernel { get; set; }

        /// <summary>
        /// Gets or sets the ProtocolType.
        /// </summary>
        public string ProtocolType { get; set; }

        /// <summary>
        /// Gets or sets the SeriesDescription.
        /// </summary>
        public string SeriesDescription { get; set; }

        /// <summary>
        /// Gets or sets the SliceThickness.
        /// </summary>
        public string SliceThickness { get; set; }

        /// <summary>
        /// Gets or sets the VoxelSizeXY.
        /// </summary>
        public string VoxelSizeXY { get; set; }

        /// <summary>
        /// Gets or sets the Width.
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets the Window.
        /// </summary>
        public string Window { get; set; }

        /// <summary>
        /// Gets or sets the WindowCenter.
        /// </summary>
        public string WindowCenter { get; set; }

        /// <summary>
        /// Gets or sets the WindowWidth.
        /// </summary>
        public string WindowWidth { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="ScanEntryClass" />.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.SerializableAttribute()]
    public class ScanEntryClass
    {
        #region Properties

        /// <summary>
        /// Gets or sets the AngleSpeed.
        /// </summary>
        public string AngleSpeed { get; set; }

        /// <summary>
        /// Gets or sets the BinningMode.
        /// </summary>
        public string BinningMode { get; set; }

        /// <summary>
        /// Gets or sets the DelayTime.
        /// </summary>
        public string DelayTime { get; set; }

        /// <summary>
        /// Gets or sets the ExpMode.
        /// </summary>
        public string ExpMode { get; set; }

        /// <summary>
        /// Gets or sets the ExposureTime.
        /// </summary>
        public string ExpTime { get; set; }

        /// <summary>
        /// Gets or sets the ExpSum.
        /// </summary>
        public string ExpSum { get; set; }

        /// <summary>
        /// Gets or sets the FrameNum.
        /// </summary>
        public string FrameNum { get; set; }

        /// <summary>
        /// Gets or sets the FrameTime.
        /// </summary>
        public string FrameTime { get; set; }

        /// <summary>
        /// Gets or sets the KV.
        /// </summary>
        public string KV { get; set; }

        /// <summary>
        /// Gets or sets the MA.
        /// </summary>
        public string MA { get; set; }

        /// <summary>
        /// Gets or sets the OverSample.
        /// </summary>
        public string OverSample { get; set; }

        /// <summary>
        /// Gets or sets the PatientPosition.
        /// </summary>
        public string PatientPosition { get; set; }

        /// <summary>
        /// Gets or sets the Pitch.
        /// </summary>
        public string Pitch { get; set; }

        /// <summary>
        /// Gets or sets the ReconJob.
        /// </summary>
        public ReconJob ReconJob { get; set; }

        /// <summary>
        /// Gets or sets the ScanDirection.
        /// </summary>
        public string ScanDirection { get; set; }

        /// <summary>
        /// Gets or sets the ScanLength.
        /// </summary>
        public string ScanLength { get; set; }

        /// <summary>
        /// Gets or sets the ScanMode.
        /// </summary>
        public string ScanMode { get; set; }

        /// <summary>
        /// Gets or sets the ScanRange.
        /// </summary>
        public string ScanRange { get; set; }

        /// <summary>
        /// Gets or sets the ScanType.
        /// </summary>
        [XmlAttribute(AttributeName = "ScanType")]
        //[System.Xml.Serialization.XmlElementAttribute("ScanType")]
        public string ScanType { get; set; }

        /// <summary>
        /// Gets or sets the TableEndPosition.
        /// </summary>
        public string TableEndPosition { get; set; }

        /// <summary>
        /// Gets or sets the TableHeight.
        /// </summary>
        public string TableHeight { get; set; }

        /// <summary>
        /// Gets or sets the TableSpeed.
        /// </summary>
        public string TableSpeed { get; set; }

        /// <summary>
        /// Gets or sets the TableStartPosition.
        /// </summary>
        public string TableStartPosition { get; set; }

        /// <summary>
        /// Gets or sets the TubePosition.
        /// </summary>
        public string TubePosition { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="XMLProtocolTransClass" />.
    /// </summary>
    internal class XMLProtocolTransClass
    {
    }
}
