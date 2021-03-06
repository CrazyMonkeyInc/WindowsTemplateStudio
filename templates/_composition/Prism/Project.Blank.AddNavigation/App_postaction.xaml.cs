﻿//{[{
using Prism.Mvvm;
using System.Globalization;
//}]}namespace Param_RootNamespace
{
    public sealed partial class App : PrismUnityApplication
    {
//^^
//{[{
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            return LaunchApplicationAsync(PageTokens.Param_HomeNamePage, null);
        }

        /// <summary>
        /// Application-code (e.g. setting the theme and initial page navigation) to be executed
        /// when the application is launched (e.g. through the Start menu) or activated (e.g. through URI scheme activation).
        /// </summary>
        /// <param name="page">The page to launch to.</param>
        /// <param name="launchParam">An object parameter to be passed to the launch page.</param>
        /// <returns>Task returned for async method</returns>
        private async Task LaunchApplicationAsync(string page, object launchParam)
        {
            NavigationService.Navigate(page, launchParam);
            Window.Current.Activate();
            await Task.CompletedTask;
        }

        protected override Task OnActivateApplicationAsync(IActivatedEventArgs args)
        {
            return Task.CompletedTask;
        }
//}]}

        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
//{[{

            // We are remapping the default ViewNamePage and ViewNamePageViewModel naming to ViewNamePage and ViewNameViewModel to
            // gain better code reuse with other frameworks and pages within Windows Template Studio
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "Param_RootNamespace.ViewModels.{0}ViewModel, Param_RootNamespace", viewType.Name.Substring(0, viewType.Name.Length - 4));
                return Type.GetType(viewModelTypeName);
            });
//}]}
            await base.OnInitializeAsync(args);
        }

    }
}
