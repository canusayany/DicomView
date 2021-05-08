//-----------------------------------------------------------------------
// <copyright file=DicomTagView.xaml.cs company="纳米维景">
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

namespace CTCommunication.UIPage.Controls
{
    using CTCommunication.Class;
    using Dicom;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// DicomTagView.xaml 的交互逻辑.
    /// </summary>
    public partial class DicomTagView : Window
    {
        #region Fields

        /// <summary>
        /// Defines the log.
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Defines the dataTable1.
        /// </summary>
        private DataTable dataTable1;

        /// <summary>
        /// Defines the myDicom.
        /// </summary>
        private MyDicom myDicom;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DicomTagView"/> class.
        /// </summary>
        /// <param name="_myDicom">The _myDicom<see cref="MyDicom"/>.</param>
        public DicomTagView(MyDicom _myDicom)
        {
            myDicom = _myDicom ?? throw new ArgumentNullException(nameof(_myDicom));
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The CreatTagDataTable.
        /// </summary>
        /// <param name="dicomDataset">The dicomDataset<see cref="DicomDataset"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        private DataTable CreatTagDataTable(DicomDataset dicomDataset)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tag_ID", typeof(String));
            dataTable.Columns.Add("VR", typeof(String));
            dataTable.Columns.Add("VM", typeof(String));
            dataTable.Columns.Add("Length", typeof(String));

            dataTable.Columns.Add("tag", typeof(String));
            dataTable.Columns.Add("Value", typeof(String));
            foreach (DicomItem item in dicomDataset)
            {
                string t = string.Format("{0} {1} {2}", item.Tag, item.ValueRepresentation, item.Tag.DictionaryEntry.Name);
                log.Debug(t);
                log.Debug(item.ToString());
                string tagID = item.Tag.ToString();
                string vr = item.ValueRepresentation.ToString();

                string vm = "";
                string tag = item.Tag.DictionaryEntry.Name;
                dicomDataset.TryGetString(item.Tag, out string val);
                if (val==null)
                {
                    continue;
                }
                if (val.Length > 100)
                {
                    continue;
                }
                if (val.Length > 0)
                {
                    int vm_i = 0;
                    char[] ch = val.ToCharArray();
                    for (int i = 0; i < val.Length; i++)
                    {
                        if (ch[i] == '\\')
                        {
                            vm_i++;
                        }
                    }
                    vm = (vm_i + 1).ToString();
                }
                else
                {
                    vm = "0";
                }
                string length = val.Length.ToString();

                dataTable.Rows.Add(tagID, vr, vm, length, tag, val);
            }
            dataTable1 = dataTable;
            return dataTable;
        }

        /// <summary>
        /// The TB_Find_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="TextChangedEventArgs"/>.</param>
        private void TB_Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string selectString = "tag like '%" + TB_Find.Text + "%'";
                selectString += "or Value like '%" + TB_Find.Text + "%'";
                selectString += "or Tag_ID like '%" + TB_Find.Text + "%'";
                DataRow[] drs = dataTable1.Select(selectString);
                if (drs.Length == 0)
                {
                    DG_DicomTagView.ItemsSource = null;
                    return;
                }
                DG_DicomTagView.ItemsSource = ToDataTable(drs).DefaultView;
            }
            catch (Exception ex)
            {
                log.Error("筛选DicomTag错误！" + ex.Message);
            }
        }

        /// <summary>
        /// The ToDataTable.
        /// </summary>
        /// <param name="rows">The rows<see cref="DataRow[]"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        private DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone(); // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {
                tmp.ImportRow(row); // 将DataRow添加到DataTable中
            }
            return tmp;
        }

        /// <summary>
        /// The Window_Loaded.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DG_DicomTagView.ItemsSource = CreatTagDataTable(myDicom._DicomDataset).DefaultView;
        }

        #endregion
    }
}
