using Avalonia;
using Avalonia.Controls;
using Eremex.AvaloniaUI.Controls.Ribbon;
using Eremex.AvaloniaUI.Controls.TreeList;
using MasterImpulse.Shell.Aui.ViewModels;
using MasterImpulse.Shell.Aui.ViewModels.RibbonTabsViewModel;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive;
using MasterImpulse.Shell.Aui.ViewModels.RibbonTabsViewModel.MainTabsViewModel;

namespace MasterImpulse.Shell.Aui.Views.RibbonTabsView.MainTabsView
{
    public partial class DebuggingTabView : RibbonPage, IViewFor<DebuggingTabViewModel>
    {
        protected override Type StyleKeyOverride => typeof(RibbonPage);

        public static readonly StyledProperty<DebuggingTabViewModel> ViewModelProperty = AvaloniaProperty
        .Register<DebuggingTabView, DebuggingTabViewModel>(nameof(ViewModel));

        public DebuggingTabViewModel ViewModel
        {
            get => GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DebuggingTabViewModel)value;
        }
        public DebuggingTabView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                //Биндинг для всех фильтров "Поиск и замена"
                //foreach (RadioButton filter in wgtAllSearchFilters.Children)
                //{
                //    filter.WhenAnyValue(n => n.IsChecked)
                //    .Where(n => n == true)
                //    .Subscribe(n => ViewModel?.SetSearchFilter((VariablesSearchFilters)filter.Content));
                //}
            });

            this.GetObservable(DataContextProperty).Subscribe(OnDataContextChanged);
            this.GetObservable(ViewModelProperty).Subscribe(OnViewModelChanged);
            
        }

        

        private void OnViewModelChanged(DebuggingTabViewModel value)
        {
            if (value is null)
            {
                ClearValue(DataContextProperty);
            }
            else if (DataContext != value)
            {
                DataContext = value;
            }
        }

        private void OnDataContextChanged(object value)
        {
            if (value is DebuggingTabViewModel viewModel)
            {
                ViewModel = viewModel;
            }
            else
            {
                ViewModel = null;
            }
        }
    }
}
