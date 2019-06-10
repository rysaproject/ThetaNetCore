﻿using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using ThetaWinApp.Info;
using ThetaWinApp.Properties;

namespace ThetaWinApp
{
	/// <summary>
	/// Main window
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// General Event Handler<br/>
		/// Windows loaded
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var settings = Settings.Default;
			if (settings.FormWidth > 0)
			{
				this.Width = settings.FormWidth;
				this.Height = settings.FormHeight;
			}

			ctrlHome.MenuSelected += (item) => { lstDrawerMenu.SelectedItem = item; } ;
		}

		/// <summary>
		/// General Event Handler <br />
		/// Window is closing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var settings = Settings.Default;
			if (this.WindowState == WindowState.Normal)
			{
				settings.FormWidth = this.Width;
				settings.FormHeight = this.Height;
			}
			settings.Save();
		}

		private void UIElement_OnPreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//until we had a StaysOpen glag to Drawer, this will help with scroll bars
			var dependencyObject = Mouse.Captured as DependencyObject;
			while (dependencyObject != null)
			{
				if (dependencyObject is ScrollBar) return;
				dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			}

			mnuHamburger.IsChecked = false;

		}

		/// <summary>
		/// List in menu drawer is selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LstDrawerMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (DesignerProperties.GetIsInDesignMode(this))
				return;

			String navigateTo = (lstDrawerMenu.SelectedItem as NavigateMenuItem)?.NavigateTo;
			

			foreach(var ctrl in ctrlsContainer.Children)
			{
				var elem = ctrl as FrameworkElement;
				elem.Visibility = elem.Tag.ToString() == navigateTo ? Visibility.Visible : Visibility.Collapsed;
			}
		}

	}
}