using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentTest.Helper
{
    public class RelayCommand:ICommand
    {
        private Action action;

        // meh no way around it. should be less hard coded
        public Action<IPageViewModel> actions;

        public RelayCommand(Action<IPageViewModel> actions)
        {
            this.actions = actions;
        }

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            if(this.action!=null)
            this.action();
            else    // again: too hard coded
            this.actions((IPageViewModel)parameter);
        }

    }
}
