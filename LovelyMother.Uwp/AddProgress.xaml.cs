﻿using GalaSoft.MvvmLight.Messaging;
using LovelyMother.Uwp.Models;
using LovelyMother.Uwp.Models.Messages;
using LovelyMother.Uwp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Threading;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace LovelyMother.Uwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AddProgress : Page
    {
        //辅助判断
        private int i;

        public AddProgress()
        {
            GalaSoft.MvvmLight.Threading.DispatcherHelper.Initialize();
            DataContext = ViewModelLocator.Instance.AddProgressViewModel;
            i = 0;
            this.InitializeComponent();
        }
        private async void NewProgress_Click(object sender, RoutedEventArgs e)
        {
            if(i == 0)
            {
                Messenger.Default.Send<AddProgressMessage>(new AddProgressMessage() { choice = 1, ifSelectToAdd = true });
                Step1.Visibility = Visibility.Collapsed;
                Step2.Visibility = Visibility.Visible;
                NewProgress.Label = "已确认关闭";
                i++;
            }
            else if(i == 1)
            {
                Messenger.Default.Send<AddProgressMessage>(new AddProgressMessage() { choice = 2, ifSelectToAdd = true });
                if(!ProgressListView.Items.Any())
                {
                    await new MessageDialog("未发现新程序！").ShowAsync();//弹窗。
                    i = 0;
                    Frame.Navigate(typeof(ViewProgress));
                }
                else
                {
                    await new MessageDialog("Step 3 / 3 : 请选择要添加的程序后摁下按钮~").ShowAsync();//弹窗。
                    Step2.Visibility = Visibility.Collapsed;
                    AddProgressList.Visibility = Visibility.Visible;
                    theBlock.Visibility = Visibility.Visible;
                    ResetName.Visibility = Visibility.Visible;
                    NewProgress.Label = "添加";
                    i++;
                }
            }
            else
            {
                if(ProgressListView.SelectedItems.Count() != 0)
                {
                   Messenger.Default.Send<AddProgressMessage>(new AddProgressMessage() { choice = 3, ifSelectToAdd = true, parameter = ProgressListView.SelectedItem as Process, newName = ResetName.Text});
                   i = 0;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            Frame.Navigate(typeof(ViewProgress));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Step2.Visibility = Visibility.Collapsed;
            AddProgressList.Visibility = Visibility.Collapsed;
            theBlock.Visibility = Visibility.Collapsed;
            ResetName.Visibility = Visibility.Collapsed;
            i = 0;
            NewProgress.Label = "已确认打开";
            
        }
    }
}
