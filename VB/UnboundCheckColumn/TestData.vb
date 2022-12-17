Imports System
Imports System.Collections.Generic

Namespace UnboundCheckColumn

    Public Class TestData

        Private _List As List(Of UnboundCheckColumn.TestDataItem)

        Public Property List As List(Of TestDataItem)
            Get
                Return _List
            End Get

            Private Set(ByVal value As List(Of TestDataItem))
                _List = value
            End Set
        End Property

        Public Sub New()
            Dim list As List(Of TestDataItem) = New List(Of TestDataItem)()
            For i As Integer = 0 To 20 - 1
                list.Add(New TestDataItem() With {.Id = Guid.NewGuid(), .Number = i})
            Next

            Me.List = list
        End Sub
    End Class

    Public Class TestDataItem

        Public Property Id As Guid

        Public Property Number As Integer
    End Class
End Namespace
