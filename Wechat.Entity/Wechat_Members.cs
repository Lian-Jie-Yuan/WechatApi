using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///会员数据信息
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
           public long mId {get;set;}

           /// <summary>
           /// Desc:会员名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mName {get;set;}

           /// <summary>
           /// Desc:会员编号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mNo {get;set;}

           /// <summary>
           /// Desc:会员等级 0-普通会员
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? mLevel {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mPhone {get;set;}

           /// <summary>
           /// Desc:号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mTel {get;set;}

           /// <summary>
           /// Desc:英文名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mEngName {get;set;}

           /// <summary>
           /// Desc:0- 位置 1-男性 2-女性
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mSex {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mIdNo {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mOpenId {get;set;}

           /// <summary>
           /// Desc:微信昵称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mNickName {get;set;}

           /// <summary>
           /// Desc:微信头像
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mAvatarUrl {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mCounttry {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mProvince {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mCity {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string mLanguage {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateDate {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Updater {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateDate {get;set;}

    }
}
