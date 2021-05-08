//-----------------------------------------------------------------------
// <copyright file=MyDicom.cs company="纳米维景">
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
    using Dicom;
    using Dicom.Imaging;
    using Dicom.IO.Buffer;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Defines the <see cref="MyDicom" />.
    /// </summary>
    public class MyDicom : DicomFile
    {
        #region Fields

        /// <summary>
        /// Defines the _DicomDataset.
        /// </summary>
        public DicomDataset _DicomDataset;

        /// <summary>
        /// Defines the _DicomFile.
        /// </summary>
        public DicomFile _DicomFile;

        /// <summary>
        /// Defines the _DicomImage.
        /// </summary>
        public DicomImage _DicomImage;

        /// <summary>
        /// Defines the WindowCenter.
        /// </summary>
        public double WindowCenter;

        /// <summary>
        /// Defines the WindowWidth.
        /// </summary>
        public double WindowWidth;

        /// <summary>
        /// Defines the imageManager.
        /// </summary>
        private static ImageManager imageManager;

        /// <summary>
        /// Defines the log.
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Defines the original_WindowCenter.
        /// </summary>
        private double original_WindowCenter;

        /// <summary>
        /// Defines the original_WindowWidth.
        /// </summary>
        private double original_WindowWidth;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDicom"/> class.
        /// </summary>
        public MyDicom()
        {
            ImageManager.SetImplementation(WPFImageManager.Instance);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyDicom"/> class.
        /// </summary>
        /// <param name="_dicomFile">The _dicomFile<see cref="DicomFile"/>.</param>
        public MyDicom(DicomFile _dicomFile)
        {
            _DicomFile = _dicomFile;
            _DicomImage = GetDicomImage(_DicomFile);
            _DicomDataset = _dicomFile.Dataset;
            WindowWidth = _DicomImage.WindowWidth;
            WindowCenter = _DicomImage.WindowCenter;
            original_WindowWidth = _DicomImage.WindowWidth;
            original_WindowCenter = _DicomImage.WindowCenter;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The GetDicomImage.
        /// </summary>
        /// <param name="dicomFile">The dicomFile<see cref="DicomFile"/>.</param>
        /// <returns>The <see cref="DicomImage"/>.</returns>
        public static DicomImage GetDicomImage(DicomFile dicomFile)
        {
          
            DicomImage dicomImage;
            try
            {
                dicomImage = new DicomImage(dicomFile.Dataset, 0);
                return dicomImage;
            }
            catch (System.Exception)
            {
                dicomFile = CreatDicomFileNoDicomImage(dicomFile);
                dicomImage = new DicomImage(dicomFile.Dataset, 0);
                return dicomImage;

            }

        }
      static DicomFile CreatDicomFileNoDicomImage( DicomFile dicomFile)
        {
            byte[] temp = new byte[512 * 512];
            dicomFile.Dataset.AddOrUpdate(DicomTag.Rows, (ushort)512);
            dicomFile.Dataset.AddOrUpdate(DicomTag.Columns, (ushort)512);
            dicomFile.Dataset.AddOrUpdate(DicomTag.BitsAllocated, (ushort)16);
            dicomFile.Dataset.TryGetString(DicomTag.SOPInstanceUID, out string str);
            if (str == null)
            {
                dicomFile.Dataset.Add(DicomTag.SOPInstanceUID, "1.1.1.1.1.1");
            }
          
            MemoryByteBuffer buffer = new MemoryByteBuffer(temp);
            DicomPixelData pixelData = DicomPixelData.Create(dicomFile.Dataset, true);
            pixelData.BitsStored = 16;
            //pixelData.BitsAllocated = 8;
            pixelData.SamplesPerPixel = pixelData.HighBit = 15;
            pixelData.PixelRepresentation = 0;
            pixelData.PlanarConfiguration = 0;
            pixelData.AddFrame(buffer);
          
            dicomFile = new DicomFile(dicomFile.Dataset);
            return dicomFile;
        }

        /// <summary>
        /// The RendImage.
        /// </summary>
        /// <param name="dicomFile">.</param>
        /// <param name="offsetX">.</param>
        /// <param name="offsetY">.</param>
        /// <returns>.</returns>
        public static WriteableBitmap RendImage(DicomFile dicomFile, double offsetX, double offsetY)
        {
            DicomImage dicomImage = GetDicomImage(dicomFile);
            dicomImage.WindowWidth = dicomFile.Dataset.GetSingleValue<double>(DicomTag.WindowWidth) + offsetX;
            dicomImage.WindowCenter = dicomFile.Dataset.GetSingleValue<double>(DicomTag.WindowCenter) + offsetY;
            // dicomImage.WindowWidth = 1507;
            // dicomImage.WindowCenter = -295;
            if (dicomImage == null)
            {
                return null;
            }
            WriteableBitmap renderedImage = dicomImage.RenderImage().As<WriteableBitmap>();
            return renderedImage;
        }

        /// <summary>
        /// The RendImage.
        /// </summary>
        /// <returns>The <see cref="WriteableBitmap"/>.</returns>
        public WriteableBitmap RendImage()
        {
            _DicomImage.WindowWidth = WindowWidth;
            _DicomImage.WindowCenter = WindowCenter;
            if (_DicomImage == null)
            {
                return null;
            }
            WriteableBitmap renderedImage = _DicomImage.RenderImage().AsWriteableBitmap();
            return renderedImage;
        }

        /// <summary>
        /// The RendImage.
        /// </summary>
        /// <param name="offsetX">The offsetX<see cref="double"/>.</param>
        /// <param name="offsetY">The offsetY<see cref="double"/>.</param>
        /// <returns>The <see cref="WriteableBitmap"/>.</returns>
        public WriteableBitmap RendImage(double offsetX, double offsetY)
        {
            _DicomImage.WindowWidth = WindowWidth + offsetX;
            _DicomImage.WindowCenter = WindowCenter + offsetY;
            WindowWidth = _DicomImage.WindowWidth;
            WindowCenter = _DicomImage.WindowCenter;
            if (_DicomImage == null)
            {
                return null;
            }
            WriteableBitmap renderedImage = _DicomImage.RenderImage().As<WriteableBitmap>();
            return renderedImage;
        }

        /// <summary>
        /// 根据偏差值生成新的dicomimage.
        /// </summary>
        /// <param name="offsetX">.</param>
        /// <param name="offsetY">.</param>
        /// <returns>.</returns>
        public WriteableBitmap RendImageByOffsetValue(double offsetX, double offsetY)
        {
            _DicomImage.WindowWidth = WindowWidth + offsetX;
            _DicomImage.WindowCenter = WindowCenter + offsetY;
            WindowWidth = _DicomImage.WindowWidth;
            WindowCenter = _DicomImage.WindowCenter;
            //  log.Debug(" _DicomImage.WindowWidth:" + _DicomImage.WindowWidth+ "   _DicomImage.WindowCenter:" + _DicomImage.WindowCenter);
            if (_DicomImage == null)
            {
                return null;
            }
            WriteableBitmap renderedImage = _DicomImage.RenderImage().As<WriteableBitmap>();
            return renderedImage;
        }

        /// <summary>
        /// 跟据类内部的窗宽窗位生成新的图像.
        /// </summary>
        /// <returns>.</returns>
        public WriteableBitmap RendImageByWWAndWC()
        {
            if (_DicomImage == null)
            {
                return null;
            }

            _DicomImage.WindowWidth = WindowWidth;
            _DicomImage.WindowCenter = WindowCenter;

            WriteableBitmap renderedImage = _DicomImage.RenderImage().AsWriteableBitmap();
            return renderedImage;
        }

        /// <summary>
        /// 根据新的窗宽窗位生成新的图像.
        /// </summary>
        /// <param name="newWindowWidth">.</param>
        /// <param name="newWindowCenter">.</param>
        /// <returns>.</returns>
        public WriteableBitmap RendImageByWWAndWC(double newWindowWidth, double newWindowCenter)
        {
            _DicomImage.WindowWidth = newWindowWidth;
            _DicomImage.WindowCenter = newWindowCenter;
            WindowWidth = newWindowWidth;
            WindowCenter = newWindowCenter;
            if (_DicomImage == null)
            {
                return null;
            }
            WriteableBitmap renderedImage = _DicomImage.RenderImage().As<WriteableBitmap>();
            return renderedImage;
        }

        /// <summary>
        /// 按照dicom信息里的窗宽窗位重新渲染dicom.
        /// </summary>
        /// <returns>The <see cref="WriteableBitmap"/>.</returns>
        public WriteableBitmap ResetWWAndWC()
        {
            WindowWidth = original_WindowWidth;
            WindowCenter = original_WindowCenter;
            //    WindowWidth = _DicomFile.Dataset.GetSingleValue<double>(DicomTag.WindowWidth) ;
            //WindowCenter = _DicomFile.Dataset.GetSingleValue<double>(DicomTag.WindowCenter);
            return RendImageByWWAndWC();
        }

        #endregion
    }
}
