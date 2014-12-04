using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DataGridRow_DoubleClick.WPF.Helpers
{
    public sealed class RowDoubleClickCommandHandler : FrameworkElement
    {
        public RowDoubleClickCommandHandler(DataGrid dataGrid)
        {
            MouseButtonEventHandler handler = (sender, args) =>
                                                  {
                                                      var row = sender as DataGridRow;
                                                      if (row != null && row.IsSelected)
                                                      {
                                                          var command = GetRowDoubleClick(dataGrid);
                                                          if(command == null) return;
                                                          
                                                          if (command.CanExecute(row))
                                                          {
                                                              command.Execute(row);
                                                          }
                                                      }
                                                  };

            dataGrid.LoadingRow += (s, e) =>
                                       {
                                           e.Row.MouseDoubleClick += handler;
                                       };

            dataGrid.UnloadingRow += (s, e) =>
                                         {
                                             e.Row.MouseDoubleClick -= handler;
                                         };
        }

        public static ICommand GetRowDoubleClick(DataGrid dg)
        {
            return (ICommand) dg.GetValue(RowDoubleClickProperty);
        }

        public static void SetRowDoubleClick(DataGrid dataGrid, ICommand command)
        {
            dataGrid.SetValue(RowDoubleClickProperty, command);
        }

        public static readonly DependencyProperty RowDoubleClickProperty = DependencyProperty.RegisterAttached(
            "RowDoubleClick",
            typeof (ICommand),
            typeof (RowDoubleClickCommandHandler),
            new PropertyMetadata((o, e) =>
                                     {
                                         var dataGrid = o as DataGrid;
                                         if (dataGrid != null)
                                         {
                                             new RowDoubleClickCommandHandler(dataGrid);
                                         }
                                     }));
    }
}
