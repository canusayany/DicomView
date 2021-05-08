//-----------------------------------------------------------------------
// <copyright file=Class_DataSetForDicomTag.cs company="纳米维景">
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
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Class_DataSetForDicomTag" />.
    /// </summary>
    public class Class_DataSetForDicomTag
    {
        #region Fields

        /// <summary>
        /// Defines the dicomFile.
        /// </summary>
        public DicomFile dicomFile;

        /// <summary>
        /// Defines the listView1.
        /// </summary>
        private static ListView listView1 = new ListView();

        #endregion
    }
}
