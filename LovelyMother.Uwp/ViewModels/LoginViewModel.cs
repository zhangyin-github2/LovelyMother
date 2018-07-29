﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using LovelyMother.Uwp.Services;

namespace LovelyMother.Uwp.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        ///     登录错误信息。
        /// </summary>
        public const string LoginErrorMessage =
            "Sorry!!!\n\nAn error occurred when we tried to sign you in.\nPlease screenshot this dialog and send it to your teacher.\n\nError:\n";

        /// <summary>
        ///     对话框服务。
        /// </summary>
        private readonly IDialogService _dialogService;

        /// <summary>
        ///     身份服务。
        /// </summary>
        private readonly IIdentityService _identityService;

        /// <summary>
        ///     根导航服务。
        /// </summary>
        private readonly IRootNavigationService _rootNavigationService;

        /// <summary>
        ///     登录命令。
        /// </summary>
        private RelayCommand _loginCommand;

        /// <summary>
        ///     构造函数。
        /// </summary>
        /// <param name="identityService">身份服务。</param>
        /// <param name="rootNavigationService">根导航服务。</param>
        /// <param name="dialogService">对话框服务。</param>
        public LoginViewModel(IIdentityService identityService,
            IRootNavigationService rootNavigationService,
            IDialogService dialogService)
        {
            _identityService = identityService;
            _rootNavigationService = rootNavigationService;
            _dialogService = dialogService;
        }

        /// <summary>
        ///     登录命令。
        /// </summary>
        public RelayCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new RelayCommand(async () => {
                
                _loginCommand.RaiseCanExecuteChanged();
                var serviceResult = await _identityService.LoginAsync();
                
                _loginCommand.RaiseCanExecuteChanged();

                switch (serviceResult.Status)
                {
                    case ServiceResultStatus.OK:
                        _rootNavigationService.Navigate(typeof(YuhaoTest2), null,
                            NavigationTransition.EntranceNavigationTransition);
                        break;
                    default:
                        await _dialogService.ShowAsync(
                            LoginErrorMessage + serviceResult.Message);
                        break;
                }
            }));


    }
}
