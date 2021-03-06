﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Caliburn.Micro;
using LiteDbExplorer.Wpf.Framework;

namespace LiteDbExplorer.Framework
{
    public abstract class Document : LayoutItemBase, IDocument
    {
        public string GroupId { get; set; }

        public string GroupDisplayName { get; set; }

        public bool GroupDisplayNameIsVisible { get; set; }

        public GroupDisplayVisibility GroupDisplayVisibility { get; set; } = GroupDisplayVisibility.Auto;

        public SolidColorBrush GroupDisplayBackground { get; set; }

        private ICommand _closeCommand;
        public override ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand(p => TryClose(null), p => true)); }
        }

        public void UpdateGroupDisplay()
        {
            UpdateGroupDisplayRequest?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> UpdateGroupDisplayRequest;
    }

    public abstract class Document<T> : Document, IDocument<T> where T : IReferenceNode
    {
        public virtual string InstanceId { get; protected set; }

        public abstract void Init(T item);
    }

    public abstract class DocumentWithConductor<T> : Conductor<IScreen>.Collection.OneActive, IDocument<T> where T : IReferenceNode
    {
        [Browsable(false)]
        public Guid Id { get; } = Guid.NewGuid();

        [Browsable(false)]
        public string ContentId => Id.ToString();

        private bool _isSelected;

        [Browsable(false)]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        [Browsable(false)]
        public virtual bool ShouldReopenOnStart => false;

        public virtual object IconContent { get; set; }

        public string GroupId { get; set; }

        public string GroupDisplayName { get; set; }

        public bool GroupDisplayNameIsVisible { get; set; }

        public GroupDisplayVisibility GroupDisplayVisibility { get; set; } = GroupDisplayVisibility.Auto;

        public SolidColorBrush GroupDisplayBackground { get; set; }

        public virtual string InstanceId { get; protected set; }

        public abstract void Init(T item);

        private ICommand _closeCommand;
        public virtual ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand(p => TryClose(null), p => true)); }
        }

        public void UpdateGroupDisplay()
        {
            UpdateGroupDisplayRequest?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> UpdateGroupDisplayRequest;
    }
}