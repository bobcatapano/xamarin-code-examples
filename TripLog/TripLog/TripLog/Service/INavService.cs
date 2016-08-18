using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.ViewModels;
using System.ComponentModel;

namespace TripLog.Service
{
    public interface INavService
    {
        bool CanGoBack { get; }

        Task GoBack();
        Task NavigateTo<TVM>() where TVM : BaseViewModel;
        Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : BaseViewModel;
        Task RemoveLastView();
        Task ClearBackStack();
        Task NavigateToUri(Uri uri);

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
