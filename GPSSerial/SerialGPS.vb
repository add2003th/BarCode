Imports System.Windows.Forms
Public Class SerialGPS
    Inherits NmeaInterpreter
    Private WithEvents COM As IO.Ports.SerialPort
    Public Event DataReceived(ByVal s As String)

    Sub New(ByVal COMNAME As String, Optional ByVal Baudrade As Integer = 38400)
        MyBase.new()
        Me.COM = New IO.Ports.SerialPort(COMNAME, Baudrade)
    End Sub
    Sub Open()
        Try
            Me.COM.Open()
        Catch ex As Exception
            Throw New Exception("GPS CAN NOT OPEN", ex)
        End Try
    End Sub
    Private _Lat_lingReturnType As enumReturnformat = enumReturnformat.DECIMAL
    Property Lat_LongReturnType() As enumReturnformat
        Get
            Return _Lat_lingReturnType
        End Get
        Set(ByVal value As enumReturnformat)
            _Lat_lingReturnType = value
        End Set
    End Property
    Private Sub COM_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles COM.DataReceived
        Try
            Dim Sentence As String = Me.COM.ReadLine
            RaiseEvent DataReceived(Sentence)
            Me.Parse(Sentence, Me._Lat_lingReturnType)
        Catch ex As Exception
            Throw New Exception("RECEIVE GPS FAILED", ex)
        End Try

    End Sub
    Sub Close()
        Try
            Me.COM.Close()
        Catch ex As Exception
            Throw New Exception("GPS CAN NOT CLOSE", ex)
        End Try
    End Sub
End Class
