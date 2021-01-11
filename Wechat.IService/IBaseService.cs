using System;
using System.Collections.Generic;
using System.Text;

namespace Wechat.IService
{
    /// <summary>
    /// 基类接口
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// 获取列表信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> GetList<T>() where T : class, new();


        /// <summary>
        /// 创建一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create<T>(T model) where T : class, new();

     

    }
}
