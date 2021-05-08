//-----------------------------------------------------------------------
// <copyright file=StaticImageFun.cs company="纳米维景">
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
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Defines the <see cref="StaticImageFun" />.
    /// </summary>
    internal static class StaticImageFun
    {
        #region Methods

        /// <summary>
        /// The GetBitmapSource.
        /// </summary>
        /// <param name="w">The w<see cref="int"/>.</param>
        /// <param name="h">The h<see cref="int"/>.</param>
        /// <param name="rawArray">The rawArray<see cref="byte[]"/>.</param>
        /// <returns>The <see cref="BitmapSource"/>.</returns>
        public static BitmapSource GetBitmapSource(int w, int h, byte[] rawArray)
        {
            //这里设置步长
            //宽度*每个像素占用的byte数,结果要被4整除,如果不,则补
            int rawStride = 1536;
            //创建一个BitmapSource
            //w-图像宽度
            //h-图像高度
            //96-dpix(不知道干嘛的，好像都用96)
            //96-dpiy
            //PixelFormats.Bgr24-图像的类型，我这边是BGR三通道24位的,用的时候分辨自己的图的类型
            //null-调色板，可以直接null
            //rawArray-像素数组
            //rawStride上面设置的步长
            // BitmapSource bitmap = BitmapSource.Create(w, h, 96, 96, PixelFormats.Gray16, null, rawArray, rawStride);
            //创建完控件直接调用就可以了
            BitmapSource bitmap = BitmapSource.Create(w, h, 96, 96, PixelFormats.Gray16, null, rawArray, rawStride);

            return bitmap;
        }

        /// <summary>
        /// The GetDicomFileByRaw.
        /// </summary>
        /// <param name="pixels">The pixels<see cref="byte[]"/>.</param>
        /// <param name="Heigh">The Heigh<see cref="int"/>.</param>
        /// <param name="width">The width<see cref="int"/>.</param>
        /// <returns>The <see cref="DicomFile"/>.</returns>
        public static DicomFile GetDicomFileByRaw(byte[] pixels, int Heigh, int width)
        {
            MemoryByteBuffer buffer = new MemoryByteBuffer(pixels);
            DicomDataset dataset = new DicomDataset();
            //FillDataset(dataset);
            dataset.AddOrUpdate(DicomTag.PhotometricInterpretation, PhotometricInterpretation.Monochrome2.Value);
            // dataset.Add(DicomTag.PhotometricInterpretation, PhotometricInterpretation.Monochrome2.ToString());
            dataset.AddOrUpdate(DicomTag.Rows, (ushort)Heigh);
            dataset.AddOrUpdate(DicomTag.Columns, (ushort)width);

            dataset.AddOrUpdate(DicomTag.BitsAllocated, (ushort)16);
            dataset.AddOrUpdate(DicomTag.SOPClassUID, "1.2.840.10008.5.1.4.1.1.2");
            dataset.Add(DicomTag.SOPInstanceUID, "1.2.840.10008.5.1.4.1.1.2.20181120090837121314");
            DicomPixelData pixelData = DicomPixelData.Create(dataset, true);

            pixelData.BitsStored = 16;
            //pixelData.BitsAllocated = 8;
            pixelData.SamplesPerPixel = pixelData.HighBit = 15;
            pixelData.PixelRepresentation = 0;
            pixelData.PlanarConfiguration = 0;
            pixelData.AddFrame(buffer);

            DicomFile dicomfile = new DicomFile(dataset);
            //   dicomfile.Save(@"C:\Users\admin\Pictures\Saved Pictures\" + System.DateTime.Now.ToString("FFFF")); ;
            return dicomfile;
        }

        /// <summary>
        /// The GetDicomImage.
        /// </summary>
        /// <param name="w">The w<see cref="int"/>.</param>
        /// <param name="h">The h<see cref="int"/>.</param>
        /// <param name="rawArray">The rawArray<see cref="byte[]"/>.</param>
        /// <returns>The <see cref="BitmapSource"/>.</returns>
        public static BitmapSource GetDicomImage(int w, int h, byte[] rawArray)
        {
            DicomFile dicomFile = new DicomFile();

            //这里设置步长
            //宽度*每个像素占用的byte数,结果要被4整除,如果不,则补
            int rawStride = 1536;
            //创建一个BitmapSource
            //w-图像宽度
            //h-图像高度
            //96-dpix(不知道干嘛的，好像都用96)
            //96-dpiy
            //PixelFormats.Bgr24-图像的类型，我这边是BGR三通道24位的,用的时候分辨自己的图的类型
            //null-调色板，可以直接null
            //rawArray-像素数组
            //rawStride上面设置的步长
            // BitmapSource bitmap = BitmapSource.Create(w, h, 96, 96, PixelFormats.Gray16, null, rawArray, rawStride);
            //创建完控件直接调用就可以了
            BitmapSource bitmap = BitmapSource.Create(w, h, 96, 96, PixelFormats.Gray16, null, rawArray, rawStride);
            return bitmap;
        }

        /// <summary>
        /// The RendImage.
        /// </summary>
        /// <param name="dicomFile">The dicomFile<see cref="DicomFile"/>.</param>
        /// <param name="dicomImage">The dicomImage<see cref="DicomImage"/>.</param>
        /// <param name="offsetX">The offsetX<see cref="double"/>.</param>
        /// <param name="offsetY">The offsetY<see cref="double"/>.</param>
        /// <returns>The <see cref="WriteableBitmap"/>.</returns>
        public static WriteableBitmap RendImage(DicomFile dicomFile, DicomImage dicomImage, double offsetX, double offsetY)
        {
           // dicomImage.WindowWidth = dicomFile.Dataset.Get(DicomTag.WindowWidth, 0) + offsetX;
           // dicomImage.WindowCenter = dicomFile.Dataset.Get(DicomTag.WindowCenter, 200) + offsetY;
            dicomImage.WindowWidth = 1507;
            dicomImage.WindowCenter = -295;
            if (dicomImage == null)
            {
                return null;
            }
            WriteableBitmap renderedImage = dicomImage.RenderImage().As<WriteableBitmap>();
            return renderedImage;
        }

        /// <summary>
        /// 将 BitmapSource 转化为 Bitmap.
        /// </summary>
        /// <param name="source">The source<see cref="BitmapSource"/>.</param>
        /// <returns>转化后的 Bitmap.</returns>
        public static System.Drawing.Bitmap ToBitmap(this BitmapSource source)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(ms);
                return new System.Drawing.Bitmap(ms);
            }
        }

        /// <summary>
        /// The DeleteObject.
        /// </summary>
        /// <param name="hObject">The hObject<see cref="System.IntPtr"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(System.IntPtr hObject);

        #endregion
    }
}
