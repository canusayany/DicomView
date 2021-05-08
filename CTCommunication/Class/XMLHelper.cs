//-----------------------------------------------------------------------
// <copyright file=XMLHelper.cs company="纳米维景">
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
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="XMLHelper" />.
    /// </summary>
    public class XMLHelper
    {
        #region Methods

        /// <summary>
        /// The XmlSerialize.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="obj">The obj<see cref="T"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string XmlSerialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }

        #endregion
    }
}
