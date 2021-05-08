//-----------------------------------------------------------------------
// <copyright file="Test.cs" company="纳米维景">
// 版权所有 (C)2020,纳米维景(上海)医疗科技有限公司
// </copyright>
// ---------------------------------------------------------------------
// <summary>
//     修改日期                  版本号       创建人     
// 2020/8/25 13:30:00               V0.0.1                   liujian     
// </summary>
// ---------------------------------------------------------------------
// <key>
// 
// </key>
//-----------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VT0Test
{
    public partial class Protocol
    {
        private string id;
        private string protocolName;
        private string partID;
        private string description;
        private string scanMode;
        private string notes;
        private string type;
        private int isEmergency;
        private int storeState;
        private int isValid;
        private string patientPosition;
        private string bodySize;

        private int? isTabletSuitable;
        private int? isEnhanced;
        private int? isFactory;
        private string protocolFamily;
        private bool isChecked;
        private int sort;
        public event EventHandler IsCheckedChange;
        public Dictionary<string, ScanRangePraMode> Dic_scanRangePraMode = new Dictionary<string, ScanRangePraMode>();






        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;

            }
        }


        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ProtocolName
        {
            get
            {
                return protocolName;
            }

            set
            {
                protocolName = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PartID
        {
            get
            {
                return partID;
            }

            set
            {
                partID = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ScanMode
        {
            get
            {
                return scanMode;
            }

            set
            {
                scanMode = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;

            }
        }
        public string PatientPosition
        {
            get
            {
                return patientPosition;
            }

            set
            {
                patientPosition = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int IsEmergency
        {
            get
            {
                return isEmergency;
            }

            set
            {
                isEmergency = value;

            }
        }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int StoreState
        {
            get
            {
                return storeState;
            }

            set
            {
                storeState = value;

            }
        }
        public string BodySize
        {
            get
            {
                return bodySize;
            }

            set
            {
                bodySize = value;

            }
        }
        public int? IsTabletSuitable
        {
            get
            {
                return isTabletSuitable;
            }

            set
            {
                isTabletSuitable = value;

            }
        }
        public int? IsEnhanced
        {
            get
            {
                return isEnhanced;
            }

            set
            {
                isEnhanced = value;

            }
        }
        public int? IsFactory
        {
            get
            {
                return isFactory;
            }

            set
            {
                isFactory = value;

            }
        }
        public string ProtocolFamily
        {
            get
            {
                return protocolFamily;
            }

            set
            {
                protocolFamily = value;

            }
        }
        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public int IsValid
        {
            get
            {
                return isValid;
            }

            set
            {
                isValid = value;

            }
        }
        public int Sort
        {
            get
            {
                return sort;
            }

            set
            {
                sort = value;

            }
        }

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }

            set
            {
                isChecked = value;
                if (IsCheckedChange != null)
                {
                    IsCheckedChange(this, null);
                }

            }
        }


    }
    public class BasicContainer
    {
        public static T GetValue<T>(object t, T defValue = default(T))
        {
            if (t == null || t.ToString() == "") return defValue;
            try
            {
                return (T)Convert.ChangeType(t.ToString(), typeof(T));
            }
            catch
            {
                return defValue;
            }
        }
    }

    public partial class ProtocolScanRange
    {
        public ProtocolScanRange()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           


        public string ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ProtocolId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ScanRange { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int ScanType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public int? StoreState { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Parameters { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public int? IsValid { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Sort { get; set; }

    }

    public partial class ProtocolRecon
    {
        public ProtocolRecon()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ScanRangeID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SeriesDescription { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Window { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public int? StoreState { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Parameters { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public int? IsValid { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Sort { get; set; }

    }

    public class ScanRangePraMode
    {
        private string scanRangeID;
        private string scanRange;
        private string scanMode;
        private string kV;
        private string mA;
        private string scanDirection;
        private string scanLength;
        private string tubePosition;
        private string patientPosition;
        private string tableStartPosition;
        private string tableEndPosition;
        private string tableHeight;
        private string delayTime;
        private string binningMode;
        private string expMode;
        private string frameNum;
        private string frameTime;
        private string expTime;
        private string overSample;
        private string pitch;
        private string angleSpeed;
        private string expSum;

        public string ScanRangeID
        {
            get
            {
                return scanRangeID;
            }
            set
            {
                scanRangeID = value;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ScanRange
        {
            get
            {
                return scanRange;
            }
            set
            {
                scanRange = value;

            }
        }
        /// <summary>
        /// 扫描模式
        /// </summary>
        public string ScanMode
        {
            get
            {
                return scanMode;
            }
            set
            {
                scanMode = value;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KV
        {
            get
            {
                return kV;
            }
            set
            {
                kV = value;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MA
        {
            get
            {
                return mA;
            }
            set
            {
                mA = value;

            }
        }

        /// <summary>
        /// 扫描方向
        /// </summary>
        public string ScanDirection
        {
            get
            {
                return scanDirection;
            }
            set
            {
                scanDirection = value;

            }
        }
        public string ScanLength
        {
            get
            {
                return scanLength;
            }
            set
            {
                scanLength = value;

            }
        }
        /// <summary>
        /// 球管位置
        /// </summary>
        public string TubePosition
        {
            get
            {
                return tubePosition;
            }
            set
            {
                tubePosition = value;

            }
        }

        public string PatientPosition
        {
            get
            {
                return patientPosition;
            }
            set
            {
                patientPosition = value;

            }
        }
        public string TableStartPosition
        {
            get
            {
                return tableStartPosition;
            }
            set
            {
                tableStartPosition = value;

            }
        }
        public string TableEndPosition
        {
            get
            {
                return tableEndPosition;
            }
            set
            {
                tableEndPosition = value;

            }
        }
        public string TableHeight
        {
            get
            {
                return tableHeight;
            }
            set
            {
                tableHeight = value;

            }
        }
        public string DelayTime
        {
            get
            {
                return delayTime;
            }
            set
            {
                delayTime = value;

            }
        }
        public string BinningMode
        {
            get
            {
                return binningMode;
            }
            set
            {
                binningMode = value;

            }
        }
        public string ExpMode
        {
            get
            {
                return expMode;
            }
            set
            {
                expMode = value;

            }
        }
        public string FrameNum
        {
            get
            {
                return frameNum;
            }
            set
            {
                frameNum = value;

            }
        }
        public string FrameTime
        {
            get
            {
                return frameTime;
            }
            set
            {
                frameTime = value;

            }
        }
        public string ExpTime
        {
            get
            {
                return expTime;
            }
            set
            {
                expTime = value;

            }
        }
        public string OverSample
        {
            get
            {
                return overSample;
            }
            set
            {
                overSample = value;

            }
        }
        public string Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;

            }
        }

        public string AngleSpeed
        {
            get
            {
                return angleSpeed;
            }
            set
            {
                angleSpeed = value;

            }
        }
        public string ExpSum
        {
            get
            {
                return expSum;
            }
            set
            {
                expSum = value;

            }
        }
    }


    public class ScanRangeRebuildMode
    {
        private string protocolReconID;
        private string seriesDescription;
        private string sliceThickness;
        private string kernel;
        private string window;
        private string width;
        private string height;
        private string increment;
        private string windowCenter;
        private string windowWidth;
        private string imageOrder;
        private string voxelSizeXY;
        private string denoiseCoef;
        private string fov;
        private string fOV_X;
        private string fOV_Y;

        public string SeriesDescription
        {
            get
            {
                return seriesDescription;
            }
            set
            {
                seriesDescription = value;

            }
        }
        public string SliceThickness
        {
            get
            {
                return sliceThickness;
            }
            set
            {
                sliceThickness = value;

            }
        }
        public string Kernel
        {
            get
            {
                return kernel;
            }
            set
            {
                kernel = value;

            }
        }
        public string Window
        {
            get
            {
                return window;
            }
            set
            {
                window = value;

            }
        }
        public string Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;

            }
        }
        public string Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;

            }
        }
        public string Increment
        {
            get
            {
                return increment;
            }
            set
            {
                increment = value;

            }
        }
        public string WindowCenter
        {
            get
            {
                return windowCenter;
            }
            set
            {
                windowCenter = value;

            }
        }
        public string WindowWidth
        {
            get
            {
                return windowWidth;
            }
            set
            {
                windowWidth = value;

            }
        }
        public string ImageOrder
        {
            get
            {
                return imageOrder;
            }
            set
            {
                imageOrder = value;

            }
        }
        public string VoxelSizeXY
        {
            get
            {
                return voxelSizeXY;
            }
            set
            {
                voxelSizeXY = value;

            }
        }
        public string DenoiseCoef
        {
            get
            {
                return denoiseCoef;
            }
            set
            {
                denoiseCoef = value;

            }
        }
        public string FOV
        {
            get
            {
                return fov;
            }
            set
            {
                fov = value;

            }
        }
        public string FOV_X
        {
            get
            {
                return fOV_X;
            }
            set
            {
                fOV_X = value;

            }
        }
        public string FOV_Y
        {
            get
            {
                return fOV_Y;
            }
            set
            {
                fOV_Y = value;

            }
        }

        public string ProtocolReconID { get => protocolReconID; set => protocolReconID = value; }
    }
    public class Test
    {

        public void XMLTOClass(XDocument document, out Protocol protocol)
        {
            // ScanRangePraMode     scanRangePraMode = new ScanRangePraMode();
            protocol = new Protocol();
            List<ProtocolScanRange> protocolScanRanges = new List<ProtocolScanRange>();
            List<ProtocolRecon> protocolRecons = new List<ProtocolRecon>();
            XElement xElement = document.Root.Element("ProtocolName");
            if (xElement != null)
            {

                protocol.ProtocolName = xElement.Value;
            }

            xElement = document.Root.Element("ScanMode");
            if (xElement != null)
            {
                protocol.ScanMode = xElement.Value;
            }
            xElement = document.Root.Element("PatientPosition");
            if (xElement != null)
            {
                protocol.PatientPosition = xElement.Value;
            }
            xElement = document.Root.Element("BodySize");
            if (xElement != null)
            {
                protocol.BodySize = xElement.Value;
            }

            xElement = document.Root.Element("IsTabletSuitable");
            if (xElement != null)
            {
                protocol.IsTabletSuitable = BasicContainer.GetValue<int>(xElement.Value);
            }

            xElement = document.Root.Element("IsEnhanced");
            if (xElement != null)
            {
                protocol.IsEnhanced = BasicContainer.GetValue<int>(xElement.Value);
            }
            xElement = document.Root.Element("IsEmergency");
            if (xElement != null)
            {
                protocol.IsEmergency = BasicContainer.GetValue<int>(xElement.Value);
            }

            xElement = document.Root.Element("IsFactory");
            if (xElement != null)
            {
                protocol.IsFactory = BasicContainer.GetValue<int>(xElement.Value);
            }

            xElement = document.Root.Element("IsValid");
            if (xElement != null)
            {
                protocol.IsValid = BasicContainer.GetValue<int>(xElement.Value);
            }
            xElement = document.Root.Element("ProtocolFamily");
            if (xElement != null)
            {
                protocol.ProtocolFamily = xElement.Value;
            }
            xElement = document.Root.Element("Description");
            if (xElement != null)
            {
                protocol.Description = xElement.Value;
            }



            // xElement = document.Root.Element("Entry");
            IEnumerable<XElement> nodeFirst = document.Root.Elements();
            foreach (var item in nodeFirst)
            {
                if (item.Name.LocalName == "ScanEntry")
                {
                    ProtocolScanRange protocolScanRange = new ProtocolScanRange();
                    protocolScanRange.ID = Guid.NewGuid().ToString();
                    protocolScanRange.ProtocolId = protocol.ID;
                    protocolScanRange.IsValid = 1;
                    protocolScanRange.StoreState = 1;
                    if (item.Attribute("ScanType").Value == "Topo")
                    {
                        protocolScanRange.ScanType = 1;

                        ScanRangePraMode scanRangePraMode = new ScanRangePraMode();
                        scanRangePraMode.ScanRangeID = protocolScanRange.ID;
                        xElement = item.Element("ScanRange");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanRange = xElement.Value;
                            protocolScanRange.ScanRange = xElement.Value;
                        }

                        xElement = item.Element("ScanMode");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanMode = xElement.Value;
                        }
                        xElement = item.Element("PatientPosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.PatientPosition = xElement.Value;
                        }
                        xElement = item.Element("MA");
                        if (xElement != null)
                        {
                            scanRangePraMode.MA = xElement.Value;
                        }

                        xElement = item.Element("ScanDirection");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanDirection = xElement.Value;
                            scanRangePraMode.ScanDirection = xElement.Value;
                        }

                        xElement = item.Element("KV");
                        if (xElement != null)
                        {
                            scanRangePraMode.KV = xElement.Value;
                        }


                        xElement = item.Element("TubePosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.TubePosition = xElement.Value;
                        }
                        xElement = item.Element("ScanLength");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanLength = xElement.Value;
                        }

                        xElement = item.Element("TableStartPosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.TableStartPosition = xElement.Value;
                        }

                        xElement = item.Element("BinningMode");
                        if (xElement != null)
                        {
                            scanRangePraMode.BinningMode = xElement.Value;
                        }
                        xElement = item.Element("TableEndPosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.TableEndPosition = xElement.Value;
                        }
                        xElement = item.Element("DelayTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.DelayTime = xElement.Value;
                        }

                        xElement = item.Element("TableHeight");
                        if (xElement != null)
                        {
                            scanRangePraMode.TableHeight = xElement.Value;
                        }

                        xElement = item.Element("ExpMode");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpMode = xElement.Value;
                        }
                        xElement = item.Element("FrameNum");
                        if (xElement != null)
                        {
                            scanRangePraMode.FrameNum = xElement.Value;
                        }
                        xElement = item.Element("FrameTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.FrameTime = xElement.Value;
                        }
                        xElement = item.Element("ExpTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpTime = xElement.Value;
                        }
                        xElement = item.Element("OverSample");
                        if (xElement != null)
                        {
                            scanRangePraMode.OverSample = xElement.Value;
                        }
                        xElement = item.Element("Pitch");
                        if (xElement != null)
                        {
                            scanRangePraMode.Pitch = xElement.Value;
                        }
                        xElement = item.Element("AngleSpeed");
                        if (xElement != null)
                        {
                            scanRangePraMode.AngleSpeed = xElement.Value;
                        }

                        xElement = item.Element("ExposureTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpTime = xElement.Value;
                        }

                        xElement = item.Element("ExpSum");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpSum = xElement.Value;
                        }

                        string jsonStr = JsonConvert.SerializeObject(scanRangePraMode);
                        protocolScanRange.Parameters = jsonStr;
                        protocolScanRanges.Add(protocolScanRange);
                        var xElements = item.Elements("ReconJob");
                        if (xElements != null)
                        {

                            foreach (var element in xElements)
                            {
                                ProtocolRecon protocolRecon = new ProtocolRecon();
                                protocolRecon.ID = Guid.NewGuid().ToString();
                                protocolRecon.ScanRangeID = protocolScanRange.ID;
                                protocolRecon.IsValid = 1;
                                protocolRecon.StoreState = 1;
                                ScanRangeRebuildMode scanRangeRebuildMode = new ScanRangeRebuildMode();
                                scanRangeRebuildMode.ProtocolReconID = protocolRecon.ID;
                                xElement = element.Element("SeriesDescription");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.SeriesDescription = xElement.Value;
                                    protocolRecon.SeriesDescription = xElement.Value;
                                }

                                xElement = element.Element("SliceThickness");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.SliceThickness = xElement.Value;
                                }

                                xElement = element.Element("Kernel");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Kernel = xElement.Value;
                                }

                                xElement = element.Element("Window");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Window = xElement.Value;
                                    protocolRecon.Window = xElement.Value;
                                }

                                xElement = element.Element("Width");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Width = xElement.Value;
                                }

                                xElement = element.Element("Height");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Height = xElement.Value;
                                }

                                xElement = element.Element("Increment");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Increment = xElement.Value;
                                }
                                xElement = element.Element("WindowCenter");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.WindowCenter = xElement.Value;
                                }
                                xElement = element.Element("WindowWidth");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.WindowWidth = xElement.Value;
                                }
                                xElement = element.Element("ImageOrder");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.ImageOrder = xElement.Value;
                                }
                                xElement = element.Element("VoxelSizeXY");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.VoxelSizeXY = xElement.Value;
                                }
                                xElement = element.Element("DenoiseCoef");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.DenoiseCoef = xElement.Value;
                                }
                                xElement = element.Element("FOV");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.FOV = xElement.Value;
                                }
                                xElement = element.Element("Center-X");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.FOV_X = xElement.Value;
                                }
                                xElement = element.Element("Center-Y");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.FOV_Y = xElement.Value;
                                }


                                jsonStr = JsonConvert.SerializeObject(scanRangeRebuildMode);
                                protocolRecon.Parameters = jsonStr;
                                protocolRecons.Add(protocolRecon);
                            }
                        }
                        protocol.Dic_scanRangePraMode.Add(item.Attribute("ScanType").Value, scanRangePraMode);

                    }
                    else if (item.Attribute("ScanType").Value == "Scan")
                    {

                        protocolScanRange.ScanType = 2;


                        ScanRangePraMode scanRangePraMode = new ScanRangePraMode();
                        scanRangePraMode.ScanRangeID = protocolScanRange.ID;
                        #region 赋值
 xElement = item.Element("ScanRange");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanRange = xElement.Value;
                            protocolScanRange.ScanRange = xElement.Value;
                        }

                        xElement = item.Element("ScanMode");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanMode = xElement.Value;
                        }
                        xElement = item.Element("PatientPosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.PatientPosition = xElement.Value;
                        }
                        xElement = item.Element("MA");
                        if (xElement != null)
                        {
                            scanRangePraMode.MA = xElement.Value;
                        }

                        xElement = item.Element("ScanDirection");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanDirection = xElement.Value;
                        }

                        xElement = item.Element("KV");
                        if (xElement != null)
                        {
                            scanRangePraMode.KV = xElement.Value;
                        }


                        xElement = item.Element("TubePosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.TubePosition = xElement.Value;
                        }
                        xElement = item.Element("ScanLength");
                        if (xElement != null)
                        {
                            scanRangePraMode.ScanLength = xElement.Value;
                        }

                        xElement = item.Element("TableStartPosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.TableStartPosition = xElement.Value;
                        }

                        xElement = item.Element("BinningMode");
                        if (xElement != null)
                        {
                            scanRangePraMode.BinningMode = xElement.Value;
                        }
                        xElement = item.Element("TableEndPosition");
                        if (xElement != null)
                        {
                            scanRangePraMode.TableEndPosition = xElement.Value;
                        }
                        xElement = item.Element("DelayTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.DelayTime = xElement.Value;
                        }

                        xElement = item.Element("TableHeight");
                        if (xElement != null)
                        {
                            scanRangePraMode.TableHeight = xElement.Value;
                        }

                        xElement = item.Element("ExpMode");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpMode = xElement.Value;
                        }
                        xElement = item.Element("FrameNum");
                        if (xElement != null)
                        {
                            scanRangePraMode.FrameNum = xElement.Value;
                        }
                        xElement = item.Element("FrameTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.FrameTime = xElement.Value;
                        }
                        xElement = item.Element("ExpTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpTime = xElement.Value;
                        }
                        xElement = item.Element("OverSample");
                        if (xElement != null)
                        {
                            scanRangePraMode.OverSample = xElement.Value;
                        }
                        xElement = item.Element("Pitch");
                        if (xElement != null)
                        {
                            scanRangePraMode.Pitch = xElement.Value;
                        }

                        xElement = item.Element("AngleSpeed");
                        if (xElement != null)
                        {
                            scanRangePraMode.AngleSpeed = xElement.Value;
                        }

                        xElement = item.Element("ExposureTime");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpTime = xElement.Value;
                        }

                        xElement = item.Element("ExpSum");
                        if (xElement != null)
                        {
                            scanRangePraMode.ExpSum = xElement.Value;
                        }
                        #endregion
                       

                        //  scanRangePraMode.ScanRangeID = protocolScanRange.ID;
                        string jsonStr = JsonConvert.SerializeObject(scanRangePraMode);

                        protocolScanRange.Parameters = jsonStr;
                        protocolScanRanges.Add(protocolScanRange);
                        var xElements = item.Elements("ReconJob");
                        if (xElements != null)
                        {

                            foreach (var element in xElements)
                            {
                                ProtocolRecon protocolRecon = new ProtocolRecon();
                                protocolRecon.ID = Guid.NewGuid().ToString();
                                protocolRecon.ScanRangeID = protocolScanRange.ID;
                                protocolRecon.IsValid = 1;
                                protocolRecon.StoreState = 1;
                                ScanRangeRebuildMode scanRangeRebuildMode = new ScanRangeRebuildMode();
                                scanRangeRebuildMode.ProtocolReconID = protocolRecon.ID;
                                xElement = element.Element("SeriesDescription");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.SeriesDescription = xElement.Value;
                                }

                                xElement = element.Element("SliceThickness");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.SliceThickness = xElement.Value;
                                }

                                xElement = element.Element("Kernel");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Kernel = xElement.Value;
                                }

                                xElement = element.Element("Window");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Window = xElement.Value;
                                }

                                xElement = element.Element("Width");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Width = xElement.Value;
                                }

                                xElement = element.Element("Height");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Height = xElement.Value;
                                }

                                xElement = element.Element("Increment");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.Increment = xElement.Value;
                                }
                                xElement = element.Element("WindowCenter");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.WindowCenter = xElement.Value;
                                }
                                xElement = element.Element("WindowWidth");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.WindowWidth = xElement.Value;
                                }
                                xElement = element.Element("ImageOrder");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.ImageOrder = xElement.Value;
                                }
                                xElement = element.Element("VoxelSizeXY");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.VoxelSizeXY = xElement.Value;
                                }
                                xElement = element.Element("DenoiseCoef");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.DenoiseCoef = xElement.Value;
                                }
                                xElement = element.Element("FOV");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.FOV = xElement.Value;
                                }
                                xElement = element.Element("Center-X");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.FOV_X = xElement.Value;
                                }
                                xElement = element.Element("Center-Y");
                                if (xElement != null)
                                {
                                    scanRangeRebuildMode.FOV_Y = xElement.Value;
                                }
                                jsonStr = JsonConvert.SerializeObject(scanRangeRebuildMode);
                                protocolRecon.Parameters = jsonStr;
                                protocolRecons.Add(protocolRecon);
                            }
                        }
                        var v = item.Attribute("ScanType").Value;
                        protocol.Dic_scanRangePraMode.Add(item.Attribute("ScanType").Value, scanRangePraMode);
                    }

                }
            }

        }
    }
}
