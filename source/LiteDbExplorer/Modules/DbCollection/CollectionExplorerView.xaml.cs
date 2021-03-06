﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LiteDbExplorer.Modules.DbCollection
{
    /// <summary>
    /// Interaction logic for CollectionExplorerView.xaml
    /// </summary>
    public partial class CollectionExplorerView : UserControl, ICollectionReferenceListView
    {
        public CollectionExplorerView()
        {
            InitializeComponent();

            splitOrientationSelector.SelectionChanged += (sender, args) =>
            {
                splitContainer.Orientation = splitOrientationSelector.SelectedIndex == 0
                    ? Orientation.Vertical
                    : Orientation.Horizontal;
            };

            DockSearch.IsVisibleChanged += (sender, args) =>
            {
                if (DockSearch.Visibility == Visibility.Visible)
                {
                    Dispatcher.Invoke(async () =>
                    {
                        await Task.Delay(100);
                        TextSearch.Focus();
                        TextSearch.SelectAll();
                    });
                }
            };
        }

        public void ScrollIntoItem(object item)
        {
            CollectionListView.ScrollIntoItem(item);
        }

        public void ScrollIntoSelectedItem()
        {
            CollectionListView.ScrollIntoSelectedItem();
        }

        public void UpdateView(CollectionReference collectionReference)
        {
            CollectionListView.UpdateGridColumns(collectionReference);
        }

        public void UpdateView(DocumentReference documentReference)
        {
            CollectionListView.UpdateGridColumns(documentReference.LiteDocument);
        }

        public void Find(string text, bool matchCase)
        {
            CollectionListView.Find(text, matchCase);
        }

        public void FindPrevious(string text, bool matchCase)
        {
            CollectionListView.FindPrevious(text, matchCase);
        }
    }
}
