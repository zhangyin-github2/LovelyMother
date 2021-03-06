﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LovelyMother.Uwp.Models;

namespace LovelyMother.Uwp.Services
{
    /// <summary>
    /// 用户服务。
    /// </summary>
    public interface IUserService
    {



        /*
        /// <summary>
        ///     根据用户名获得用户。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>服务结果。</returns>
        Task<ServiceResult<User>> GetUserByUserNameAsync(
            string userName);
            */




        /// <summary>
        ///     绑定账号。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>服务结果。</returns>
        Task<ServiceResult> UpdateMeAsync(string userName, int totalTime, int weekTotalTime , string image);




        /// <summary>
        ///     获得我。
        /// </summary>
        /// <returns>服务结果。</returns>
        
        Task<ServiceResult<AppUser>> GetMeAsync();
        
    }
}
