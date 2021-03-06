﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LovelyMother.Uwp.Models;
using LovelyMother.Uwp.Services;

namespace LovelyMother.Uwp.ViewModels
{
    public class FriendViewModel:ViewModelBase
    {

        /// <summary>
        ///     对话框服务。
        /// </summary>
        private readonly IDialogService _dialogService;

        /// <summary>
        ///     身份服务。
        /// </summary>
        private readonly IIdentityService _identityService;

        private readonly IFriendService _friendService;

        /// <summary>
        /// 用户服务。
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        ///     根导航服务。
        /// </summary>
        private readonly IRootNavigationService _rootNavigationService;


        private FriendList _selectFriend;
        public FriendList SelectFriend
        {
            get => _selectFriend;
            set => Set(nameof(SelectFriend), ref _selectFriend, value);
        }



        /// <summary>
        ///     构造函数。
        /// </summary>
        /// <param name="identityService">身份服务。</param>
        /// <param name="rootNavigationService">根导航服务。</param>
        /// <param name="dialogService">对话框服务。</param>
        public FriendViewModel(IIdentityService identityService,
            IRootNavigationService rootNavigationService,
            IDialogService dialogService,
            IUserService userService,
            IFriendService friendService)
        {
            _identityService = identityService;
            _rootNavigationService = rootNavigationService;
            _dialogService = dialogService;
            _userService = userService;
            _friendService = friendService;
            FriendCollection = new ObservableCollection<FriendList>();
            SelectFriend = new FriendList();
            refresh();

        }
        public async void refresh()
        {
            FriendCollection.Clear();
            var thisuser = _identityService.GetCurrentUserAsync();
            if (thisuser.ApplicationUserID != null)
            {
                var friendList = await _friendService.GetMyFriend(thisuser.ApplicationUserID);
                foreach (var thisFriendList in friendList)
                {
                    FriendCollection.Add(thisFriendList);
                }

            }

        }

        public ObservableCollection<FriendList> FriendCollection
        {
            get;
            private set;
        }



        private string _inputName;
        public string InputName
        {
            get => _inputName;
            set => Set(nameof(InputName), ref _inputName, value);
        }

        /// <summary>
        ///     刷新命令。
        /// </summary>
        private RelayCommand _refreshFriendCommand;

        public RelayCommand RefreshFriendCommand =>
            _refreshFriendCommand ?? (_refreshFriendCommand = new RelayCommand(async () =>
            {

                FriendCollection.Clear();
                var thisuser = _identityService.GetCurrentUserAsync();
                if (thisuser.ApplicationUserID != null)
                {
                    var friendList = await _friendService.GetMyFriend(thisuser.ApplicationUserID);
                    foreach (var thisFriendList in friendList)
                    {
                        FriendCollection.Add(thisFriendList);
                    }

                }

            }));

        private RelayCommand _addFriendCommand;
        public RelayCommand AddFriendCommand =>
            _addFriendCommand ?? (_addFriendCommand = new RelayCommand(async () =>
                {
                    var thisuser = _identityService.GetCurrentUserAsync();
                    if (thisuser.ApplicationUserID != null)
                    {
                        await _friendService.AddMyFriend(InputName);
                        FriendCollection.Clear();
                        var friendList = await _friendService.GetMyFriend(thisuser.ApplicationUserID);

                        foreach (var thisFriendList in friendList)
                        {
                            FriendCollection.Add(thisFriendList);
                        }
                    }

                }));


        private RelayCommand _deleteFriendCommand;
        public RelayCommand DeleteFriendCommand =>
            _deleteFriendCommand ?? (_deleteFriendCommand = new RelayCommand(async () =>
            {
                var thisuser = _identityService.GetCurrentUserAsync();
                if (thisuser.ApplicationUserID != null)
                {
                    await _friendService.DeleteMyFriend(SelectFriend.FriendUserName);
                    FriendCollection.Clear();
                    var friendList = await _friendService.GetMyFriend(thisuser.ApplicationUserID);

                    foreach (var thisFriendList in friendList)
                    {
                        FriendCollection.Add(thisFriendList);
                    }
                }
                

            }));



    }




}
