﻿using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace CourseplayEditor.Tools.Behaviors
{
    /// <summary>
    /// https://stackoverflow.com/a/5118406/6098146
    /// </summary>
    public class BindableSelectedItemBehavior : Behavior<TreeView>
    {
        #region SelectedItem Property

        public object SelectedItem
        {
            get { return (object) GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(BindableSelectedItemBehavior),
                new UIPropertyMetadata(null, OnSelectedItemChanged)
            );

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is BindableSelectedItemBehavior behavior))
            {
                return;
            }

            var item = e.NewValue as TreeViewItem
                ?? behavior.AssociatedObject?.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
            if (item == null)
            {
                return;
            }

            item.SetValue(TreeViewItem.IsSelectedProperty, true);
        }

        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject != null)
            {
                AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }
        }

        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
        }
    }
}
