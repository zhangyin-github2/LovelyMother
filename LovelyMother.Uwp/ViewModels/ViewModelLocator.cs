﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using LovelyMother.Uwp.Services;

namespace LovelyMother.Uwp.ViewModels
{
    /// <summary>
    ///     ViewModel定位器。
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///     ViewModel定位器单件。
        /// </summary>
        public static readonly ViewModelLocator Instance =
            new ViewModelLocator();

        /// <summary>
        ///     构造函数。
        /// </summary>
        private ViewModelLocator()
        {
            SimpleIoc.Default.Register<ILocalTaskService, LocalTaskService>();
            SimpleIoc.Default.Register<ILocalBlackListProgressService, LocalBlackListProgressService>();
            SimpleIoc.Default.Register<IRootNavigationService, RootNavigationService>();
            SimpleIoc.Default.Register<IIdentityService, IdentityService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IUserService, UserService>();
            SimpleIoc.Default.Register<IProcessService, ProcessService>();
            SimpleIoc.Default.Register<IUserService, UserService>();
            SimpleIoc.Default.Register<IWebTaskService, WebTaskService>();
            SimpleIoc.Default.Register<IWebBlackListProgressService, WebBlackListProgressService>();
            SimpleIoc.Default.Register<IFriendService, FriendService>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<UpdateUserViewModel>();
            SimpleIoc.Default.Register<CountDownViewModel>();
            SimpleIoc.Default.Register<WebTaskViewModel>();
            SimpleIoc.Default.Register<TaskViewModel>();
            SimpleIoc.Default.Register<FriendViewModel>();
            SimpleIoc.Default.Register<RankListViewModel>();
            SimpleIoc.Default.Register<AddProgressViewModel>();
        }


        /// <summary>
        ///  获得登录ViewModel。
        /// </summary>
        public LoginViewModel LoginViewModel =>
            SimpleIoc.Default.GetInstance<LoginViewModel>();

        /// <summary>
        /// 获得倒计时ViewModel
        /// </summary>
        public CountDownViewModel CountDownViewModel =>
            SimpleIoc.Default.GetInstance<CountDownViewModel>();

        /// <summary>
        /// 获得进程管理服务ViewModel
        /// </summary>
        public AddProgressViewModel AddProgressViewModel =>
            SimpleIoc.Default.GetInstance<AddProgressViewModel>();

        /// <summary>
        /// 获得日程ViewModel
        /// </summary>
        public TaskViewModel TaskViewModel => 
            SimpleIoc.Default.GetInstance<TaskViewModel>();



        public UpdateUserViewModel UpdateUserViewModel =>
            SimpleIoc.Default.GetInstance<UpdateUserViewModel>();



        public FriendViewModel FriendViewModel =>
            SimpleIoc.Default.GetInstance<FriendViewModel>();



        public RankListViewModel RankListViewModel =>
            SimpleIoc.Default.GetInstance<RankListViewModel>();



        public WebTaskViewModel WebTaskViewModel =>
            SimpleIoc.Default.GetInstance<WebTaskViewModel>();
    }
}
