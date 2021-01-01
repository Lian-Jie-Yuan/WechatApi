using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Wechat.Entity
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Wechat_Users")]
    public partial class Wechat_Users
    {
           public Wechat_Users(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long userId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string openId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateTime {get;set;}

    }
}
