using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Wechat_Members")]
    public partial class Wechat_Members
    {
           public Wechat_Members(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public long MemberId {get;set;}

           /// <summary>
           /// Desc:会员名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberName {get;set;}

           /// <summary>
           /// Desc:会员编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberNo {get;set;}

           /// <summary>
           /// Desc:会员等级 0-普通会员
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? MemberLevel {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateDate {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberPhone {get;set;}

           /// <summary>
           /// Desc:号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberTel {get;set;}

           /// <summary>
           /// Desc:英文名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberEngName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberSex {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberIdNo {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MemberOpenId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateDate {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Updater {get;set;}

    }
}
