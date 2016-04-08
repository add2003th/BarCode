Public Class MAIN
    Dim CM As New COINMAC
    Dim GPS As New TESTGPS
    Dim GPSRIVAL As New GPS2
    Private Sub MAIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        CM.OPENCOM()
        CM.ShowDialog()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        'GPS.OPENCOM()
        GPS.ShowDialog()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Application.Exit()
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        GPSRIVAL.ShowDialog()
    End Sub
End Class