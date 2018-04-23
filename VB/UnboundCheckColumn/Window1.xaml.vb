Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid

Namespace UnboundCheckColumn
    Partial Public Class Window1
        Inherits Window
        Private data As TestData
        Private selectionHelper As New SelectionHelper(Of Guid)()
        Public Sub New()
            InitializeComponent()
            data = New TestData()
            DataContext = data
        End Sub
        Private Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As GridColumnDataEventArgs)
            If e.Column.FieldName = "Selected" Then
                Dim key As Guid = CType(e.GetListSourceFieldValue("Id"), Guid)
                If e.IsGetData Then
                    e.Value = selectionHelper.GetIsSelected(key)
                End If
                If e.IsSetData Then
                    selectionHelper.SetIsSelected(key, CBool(e.Value))
                End If
            End If
        End Sub
        Private Sub BtnInvert_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            For i As Integer = 0 To data.List.Count - 1
                Dim rowHandle As Integer = grid.GetRowHandleByListIndex(i)
                Dim newIsSelected As Boolean = Not selectionHelper.GetIsSelected(data.List(i).Id)
                grid.SetCellValue(rowHandle, "Selected", newIsSelected)
            Next i
        End Sub
        Private Sub BtnGetSelected_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim caption As String = String.Format("Selected rows (Total: {0})", selectionHelper.GetSelectionCount())
            MessageBox.Show(selectionHelper.GetSelectedKeysAsString(), caption)
        End Sub
    End Class
End Namespace
