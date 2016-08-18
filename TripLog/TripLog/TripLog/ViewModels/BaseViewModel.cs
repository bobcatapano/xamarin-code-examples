using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripLog.Service;

namespace TripLog.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        protected INavService NavService { get; private set; }

        protected BaseViewModel()
        { }

        protected BaseViewModel(INavService navService)
        {
            NavService = navService;
        }

        public event PropertyChangedEventHandler PropertyChanged;
         
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract Task Init();
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {

        //protected INavService NavService { get; private set; }

        protected BaseViewModel(): base()
        {
       
        }

        protected BaseViewModel(INavService navService) : base(navService)
        {
           //NavService = navService;
        }

        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);
    }
}
