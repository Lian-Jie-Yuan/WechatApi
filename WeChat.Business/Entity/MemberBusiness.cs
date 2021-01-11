using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;

namespace WeChat.Business.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberBusiness
    {
        private readonly IMemberService iMemberService;

        public MemberBusiness(IMemberService option)
        {
            iMemberService = option;
        }


        /// <summary>
        /// 创建一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create<T>(T model) where T : class, new()
        {
            return iMemberService.Create<T>(model);
        }

        /// <summary>
        /// 创建一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class, new()
        {
            return iMemberService.GetList<T>();
        }


        /// <summary>
        /// 根据openId获取会员信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Wechat_Members GetMembersByOpenIdOrCreate(string openId)
        {
            var model = iMemberService.GetMembersByOpenId(openId);
            if (model == null)
            {
                model = new Wechat_Members()
                {
                    mOpenId = openId
                };
                if (!Create(model))
                {
                    return null;
                }
            }

            return model;
        }

        /// <summary>
        /// 更新会员微信信息
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="avatarUrl"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="gender"></param>
        /// <param name="nickName"></param>
        /// <param name="province"></param>
        /// <returns></returns>
        public bool EditMemberInfo(string openId, string avatarUrl, string city, string country, string gender, string nickName, string province)
        {
            var model = iMemberService.GetMembersByOpenId(openId);
            if (model != null)
            {
                model.mAvatarUrl = avatarUrl;
                model.mCity = city;
                model.mCounttry = country;
                model.mSex = gender;
                model.mNickName = nickName;
                model.mProvince = province;
                return iMemberService.Update(model);
            }
            return false;
        }
    }
}
