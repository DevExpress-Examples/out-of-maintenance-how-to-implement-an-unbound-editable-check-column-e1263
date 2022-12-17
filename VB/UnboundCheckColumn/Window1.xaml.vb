Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid

Namespace UnboundCheckColumn

    ''' <summary>
    ''' Interaction logic for Window1.xaml
    ''' </summary>
    Public Partial Class Window1
        Inherits Window

        Private data As TestData = New TestData()

        Private selectionHelper As SelectionHelper(Of Guid) = New SelectionHelper(Of Guid)()

        Public Sub New()
            Me.InitializeComponent()
            DataContext = data
        End Sub

        Private Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As GridColumnDataEventArgs)
            If Not Equals(e.Column.FieldName, "Selected") Then Return
            Dim key As Guid = CType(e.GetListSourceFieldValue("Id"), Guid)
            If e.IsGetData Then e.Value = selectionHelper.GetIsSelected(key)
            If e.IsSetData Then selectionHelper.SetIsSelected(key, CBool(e.Value))
        End Sub

        Private Sub BtnInvert_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            For i As Integer = 0 To data.List.Count - 1
                Dim rowHandle As Integer = Me.grid.GetRowHandleByListIndex(i)
                Dim newIsSelected As Boolean = Not selectionHelper.GetIsSelected(data.List(i).Id)
                Me.grid.SetCellValue(rowHandle, "Selected", newIsSelected)
            Next
        End Sub

        Private Sub BtnGetSelected_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim caption As String = String.Format("Selected rows (Total: {0})", selectionHelper.GetSelectionCount())
            Call MessageBox.Show(selectionHelper.GetSelectedKeysAsString(), caption)
        End Sub
    End Class
End Namespace
