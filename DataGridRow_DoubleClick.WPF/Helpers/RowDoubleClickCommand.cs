using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

namespace DataGridRow_DoubleClick.WPF.Helpers
{
    public class RowDoubleClickCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var dataGridRow = parameter as DataGridRow;
            if (dataGridRow != null)
            {
                Debug.WriteLine(dataGridRow.DataContext);
            }else
            {
                Debug.WriteLine("Null");
            }
        }
    }
}
