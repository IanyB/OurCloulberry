using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentSystem.WpfClient.Behavior
{
    public static class EventToCommandBehavior
    {
        public static readonly DependencyProperty SearchCommand =
            EventBehaviourFactory.CreateCommandExecutionEventBehaviour(TextBox.KeyUpEvent, "SearchCommand", typeof (EventToCommandBehavior));

        public static void SetSearchCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(SearchCommand, value);
        }

        public static ICommand GetSearchCommand(DependencyObject o)
        {
            return o.GetValue(SearchCommand) as ICommand;
        }
    }
}
