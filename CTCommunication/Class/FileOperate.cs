//-----------------------------------------------------------------------
// <copyright file=FileOperate.cs company="纳米维景">
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
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="FileOperate" />.
    /// </summary>
    internal class FileOperate
    {
        #region Fields

        /// <summary>
        /// 读取协议...
        /// </summary>
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Methods

        /// <summary>
        /// xml字符串转实体类.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="strXML">.</param>
        /// <returns>.</returns>
        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 从xml读取配置.
        /// </summary>
        /// <returns>.</returns>
        public static List<Protocol> GetScanProtocolDataFromXML()
        {
            List<Protocol> protocols = new List<Protocol>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Protocols\\";
            DirectoryInfo dir = new DirectoryInfo(path);
            //try
            //{
            //判断所指的文件夹/文件是否存在
            if (!dir.Exists)
            {
                log.Error("没有找到文件夹!");
                return protocols;
            }

            DirectoryInfo dirD = dir as DirectoryInfo;
            FileSystemInfo[] files = dirD.GetFileSystemInfos();//获取文件夹下所有文件和文件夹
                                                               //对单个FileSystemInfo进行判断，如果是文件夹则进行递归操作
            foreach (FileSystemInfo FSys in files)
            {
                FileInfo fileInfo = FSys as FileInfo;

                if (fileInfo != null)
                {
                    //如果是文件，进行文件操作
                    // FileInfo SFInfo = new FileInfo(fileInfo.DirectoryName + "\\" + fileInfo.Name);//获取文件所在原始路径
                    string temp = File.ReadAllText(fileInfo.DirectoryName + "\\" + fileInfo.Name);
                    Protocol protocol = DESerializer<Protocol>(temp);
                    protocols.Add(protocol);
                }
            }

            return protocols;
        }

        /// <summary>
        /// 从xml读取配置.
        /// </summary>
        /// <returns>.</returns>
        public static SettingData GetSettingDataFromXML()
        {
            SettingData settingData = null;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Setting\\" + "Setting.xml";
            if (!System.IO.File.Exists(path))
            {
                log.Error("错误，配置文件无法找到！");
                return settingData;
            }
            string strXML = System.IO.File.ReadAllText(path);
            settingData = DESerializer<SettingData>(strXML);
            return settingData;
        }

        /// <summary>
        /// The SaveXML.
        /// </summary>
        /// <param name="settingData">The settingData<see cref="SettingData"/>.</param>
        public static void SaveXML(SettingData settingData)
        {
            string strxml = XMLHelper.XmlSerialize<SettingData>(settingData);
            string path = AppDomain.CurrentDomain.BaseDirectory + "Setting\\" + "Setting.xml";
            System.IO.File.WriteAllText(path, strxml);
        }

        #endregion
    }
}
