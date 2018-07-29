﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace LovelyMother.Uwp.Models
{
    public class User :ObservableObject
    {
        /// <summary>
        /// 主键。
        /// </summary>
        private int _id;

        public int ID
        {
            get => _id;
            set => Set(nameof(ID), ref _id, value);
        }

        /// <summary>
        /// 自定义用户名。
        /// </summary>
        private int _userName;

        public int UserName
        {
            get => _userName;
            set => Set(nameof(UserName), ref _userName, value);
        }

        /// <summary>
        /// 用户任务完成总时间。
        /// </summary>

        private int _totalTime;

        public int TotalTime
        {
            get => _totalTime;
            set => Set(nameof(TotalTime), ref _totalTime, value);
        }
        /// <summary>
        ///     用户。
        /// </summary>
        private int _applicationUserID;

        public int ApplicationUserID
        {
            get => _applicationUserID;
            set => Set(nameof(ApplicationUserID), ref _applicationUserID, value);
        }
        /// <summary>
        /// 头像。
        /// </summary>

        private int _image;

        public int Image
        {
            get => _image;
            set => Set(nameof(Image), ref _image, value);
        }

        /// <summary>
        /// 好友列表。
        /// </summary>
        public List<FriendShip> FriendShips { get; set; }


    }
}