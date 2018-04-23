Imports System
Imports System.Collections.Generic

Public Class TestData
    Public Property List As List(Of TestDataItem)
    Public Sub New()
        List = GetTestData()
    End Sub
    Function GetTestData() As List(Of TestDataItem)
        Dim data As New List(Of TestDataItem)()
        For index = 1 To 20
            data.Add(New TestDataItem() With {.Id = Guid.NewGuid(), .Number = index})
        Next
        Return data
    End Function
End Class

Public Class TestDataItem
    Private privateId As Guid
    Public Property Id() As Guid
        Get
            Return privateId
        End Get
        Set(ByVal value As Guid)
            privateId = value
        End Set
    End Property
    Private privateNumber As Integer
    Public Property Number() As Integer
        Get
            Return privateNumber
        End Get
        Set(ByVal value As Integer)
            privateNumber = value
        End Set
    End Property
End Class

