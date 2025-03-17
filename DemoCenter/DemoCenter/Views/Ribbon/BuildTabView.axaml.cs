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
    public partial class BuildTabView : RibbonPage, IViewFor<BuildTabViewModel>
    {
        protected override Type StyleKeyOverride => typeof(RibbonPage);

        public static readonly StyledProperty<BuildTabViewModel> ViewModelProperty = AvaloniaProperty
        .Register<BuildTabView, BuildTabViewModel>(nameof(ViewModel));

        public BuildTabViewModel ViewModel
        {
            get => GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (BuildTabViewModel)value;
        }
        public BuildTabView()
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

        

        private void OnViewModelChanged(BuildTabViewModel value)
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
            if (value is BuildTabViewModel viewModel)
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
