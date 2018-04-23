using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;

namespace UnboundCheckColumn {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        TestData data = new TestData();
        SelectionHelper<Guid> selectionHelper = new SelectionHelper<Guid>();
        public Window1() {
            InitializeComponent();
            DataContext = data;
        }
        private void grid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e) {
            if(e.Column.FieldName != "Selected") return;
            Guid key = (Guid)e.GetListSourceFieldValue("Id");
            if(e.IsGetData)
                e.Value = selectionHelper.GetIsSelected(key);
            if(e.IsSetData)
                selectionHelper.SetIsSelected(key, (bool)e.Value);
        }
        private void BtnInvert_Click(object sender, RoutedEventArgs e) {
            for(int i = 0; i < data.List.Count; i++) {
                int rowHandle = grid.GetRowHandleByListIndex(i);
                bool newIsSelected = !selectionHelper.GetIsSelected(data.List[i].Id);
                grid.SetCellValue(rowHandle, "Selected", newIsSelected);
            }
        }
        private void BtnGetSelected_Click(object sender, RoutedEventArgs e) {
            string caption = string.Format("Selected rows (Total: {0})", selectionHelper.GetSelectionCount());
            MessageBox.Show(selectionHelper.GetSelectedKeysAsString(), caption);
        }
    }
    
}
