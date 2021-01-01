using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wechat.Model
{

    /// <summary>
    /// 
    /// </summary>
    public interface IBaseDBFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         public  ISqlSugarClient GetClient();
    }
}
