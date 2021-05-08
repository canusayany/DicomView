//-----------------------------------------------------------------------
// <copyright file=ProtocolToUI.cs company="纳米维景">
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
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="ProtocolToUI" />.
    /// </summary>
    internal class ProtocolToUI
    {
        #region Methods

        /// <summary>
        /// 刷新treeView赋值.
        /// </summary>
        /// <param name="_protocols">.</param>
        /// <param name="SecondLevel_MouseDoubleClick">The SecondLevel_MouseDoubleClick<see cref="MouseButtonEventHandler"/>.</param>
        /// <param name="TV_Protocol">The TV_Protocol<see cref="TreeView"/>.</param>
        public static void RefreshTreeView(List<Protocol> _protocols, MouseButtonEventHandler SecondLevel_MouseDoubleClick, TreeView TV_Protocol)
        {
            TV_Protocol.Items.Clear();
            TreeViewItem firstLevel = new TreeViewItem();
            TreeViewItem SecondLevel = new TreeViewItem();
            TreeViewItem thirdLevel = new TreeViewItem();
            TreeViewItem fourthLevel = new TreeViewItem();
            foreach (var protocol in _protocols)
            {
                firstLevel = new TreeViewItem();
                firstLevel.Header = protocol.ProtocolName;
                firstLevel.FontSize = 17;
                foreach (var scanEntry in protocol.ScanEntry)
                {
                    SecondLevel = new TreeViewItem();
                    SecondLevel.FontSize = 15;
                    SecondLevel.MouseDoubleClick += SecondLevel_MouseDoubleClick;
                    SecondLevel.Header = scanEntry.ScanType;

                    Type t = typeof(ScanEntryClass);
                    PropertyInfo[] properties = t.GetProperties();
                    foreach (var property in properties)
                    {
                        thirdLevel = new TreeViewItem();
                        thirdLevel.FontSize = 13;
                        thirdLevel.Header = property.Name + ": " + property.GetValue(scanEntry);

                        SecondLevel.Items.Add(thirdLevel);
                    }

                    thirdLevel = new TreeViewItem();
                    thirdLevel.Header = "重建参数";
                    ReconJob reconJob = scanEntry.ReconJob;
                    //ScanRangeRebuildMode scanRangeRebuildMode = dic_scanRangePraMode.Value._ScanRangeRebuildMode;
                    t = typeof(ReconJob);
                    properties = t.GetProperties();
                    foreach (var property in properties)
                    {
                        fourthLevel = new TreeViewItem();
                        fourthLevel.FontSize = 13;
                        fourthLevel.Header = property.Name + ": " + property.GetValue(reconJob);

                        thirdLevel.Items.Add(fourthLevel);
                    }
                    SecondLevel.Items.Add(thirdLevel);

                    firstLevel.Items.Add(SecondLevel);
                }
                TV_Protocol.Items.Add(firstLevel);
            }
        }

        /// <summary>
        /// The SetSelected__ScanEntry.
        /// </summary>
        /// <param name="protocols">The protocols<see cref="List{Protocol}"/>.</param>
        /// <param name="treeViewItem">The treeViewItem<see cref="TreeViewItem"/>.</param>
        /// <returns>The <see cref="ScanEntryClass"/>.</returns>
        public static ScanEntryClass SetSelected__ScanEntry(List<Protocol> protocols, TreeViewItem treeViewItem)
        {
            ScanEntryClass scanEntry = new ScanEntryClass();
            //    ScanRangePraMode selected_scanRangePraMode = new ScanRangePraMode();
            var firstName = treeViewItem.Parent.GetValue(TreeViewItem.HeaderProperty);
            var secondName = treeViewItem.GetValue(TreeViewItem.HeaderProperty);

            foreach (var protocol in protocols)
            {
                if (protocol.ProtocolName == firstName.ToString())
                {
                    foreach (var item in protocol.ScanEntry)
                    {
                        if (item.ScanType == secondName.ToString())
                        {
                            scanEntry = item;
                            return scanEntry;
                        }
                    }
                    return scanEntry;
                }
            }
            return scanEntry;
        }

        #endregion
    }
}
