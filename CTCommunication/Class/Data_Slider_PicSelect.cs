//-----------------------------------------------------------------------
// <copyright file=Data_Slider_PicSelect.cs company="纳米维景">
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
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Defines the <see cref="Data_Slider_PicSelect" />.
    /// </summary>
    internal class Data_Slider_PicSelect : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// 选择图片的序号
        /// 从0开始...
        /// </summary>
        public Action<int> SelectImageIndex;

        /// <summary>
        /// Defines the currentImageIndex.
        /// </summary>
        private int currentImageIndex;

        /// <summary>
        /// Defines the numberOfImages.
        /// </summary>
        private int numberOfImages;

        #endregion

        #region Events

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the CurrentImageIndex.
        /// </summary>
        public int CurrentImageIndex
        {
            get
            {
                return currentImageIndex;
            }
            set
            {
                currentImageIndex = value;

                // SelectImageIndex();

                //OnPropertyChanged("CurrentImage");
                OnPropertyChanged("CurrentImageIndex");
            }
        }

        /// <summary>
        /// Gets or sets the NumberOfImages.
        /// </summary>
        public int NumberOfImages
        {
            get
            {
                return this.numberOfImages;
            }
            set
            {
                if (value == this.numberOfImages)
                {
                    return;
                }
                this.numberOfImages = value;
                OnPropertyChanged("NumberOfImages");
                this.CurrentImageIndex = 0;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propName">The propName<see cref="string"/>.</param>
        protected virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
