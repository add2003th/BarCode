Imports System.Globalization
Public Class NmeaInterpreter

    Private NmeaCultureInfo As New CultureInfo("en-US")
    Private MPHPerKnot As Double = Double.Parse("1.150779", NmeaCultureInfo)

    Public Event PositionReceived(ByVal latitude As String, ByVal longitude As String)
    Public Event DateTimeChanged(ByVal dateTime As DateTime)
    Public Event BearingReceived(ByVal bearing As Double)
    Public Event SpeedReceived(ByVal speed As Double)
    Public Event SpeedLimitReached()
    Public Event FixObtained()
    Public Event FixLost()
    Public Event SatelliteReceived(ByVal pseudoRandomCode As Integer, _
     ByVal azimuth As Integer, _
     ByVal elevation As Integer, _
     ByVal signalToNoiseRatio As Integer)
    Public Function Parse(ByVal sentence As String, ByVal ReturnFormat As enumReturnformat) As Boolean
        If Not IsValid(sentence) Then Return False
        Select Case GetWords(sentence)(0)
            Case "$GPRMC"
                Return ParseGPRMC(sentence, ReturnFormat)
            Case "$GPGSV"
                Return ParseGPGSV(sentence)
            Case Else
                Return False
        End Select
    End Function

    ' Divides a sentence into individual words
    Public Function GetWords(ByVal sentence As String) As String()
        Return sentence.Split(","c)
    End Function

    ' Interprets a $GPRMC message
    Public Function ParseGPRMC(ByVal sentence As String, Optional ByVal ReturnFormat As enumReturnformat = enumReturnformat.DECIMAL) As Boolean
        Dim Words() As String = GetWords(sentence)
        If Words(3) <> "" And Words(4) <> "" And Words(5) <> "" And Words(6) <> "" Then
            Dim Latitude As String
            Dim Longitude As String
            Latitude = CStr(NMEAtoDecimal(Words(3)))
            Longitude = CStr(NMEAtoDecimal(Words(5)))

            Select Case ReturnFormat
                Case enumReturnformat.DECIMAL
                Case enumReturnformat.NMEA
                    Latitude = DecimalPosToDegrees(CDbl(Latitude), enumLongLat.Latitude, enumReturnformat.NMEA)
                    Longitude = DecimalPosToDegrees(CDbl(Longitude), enumLongLat.Longitude, enumReturnformat.NMEA)
                Case enumReturnformat.WithSigns
                    Latitude = DecimalPosToDegrees(CDbl(Latitude), enumLongLat.Latitude, enumReturnformat.WithSigns)
                    Longitude = DecimalPosToDegrees(CDbl(Longitude), enumLongLat.Longitude, enumReturnformat.WithSigns)
                Case Else
                    Latitude = "0"
                    Longitude = "0"
            End Select


            RaiseEvent PositionReceived(Latitude, Longitude)
        End If
        If Words(1) <> "" Then
            Dim UtcHours As Integer = CType(Words(1).Substring(0, 2), Integer)
            Dim UtcMinutes As Integer = CType(Words(1).Substring(2, 2), Integer)
            Dim UtcSeconds As Integer = CType(Words(1).Substring(4, 2), Integer)
            Dim UtcMilliseconds As Integer
            If Words(1).Length > 7 Then UtcMilliseconds = CType(Words(1).Substring(7), Integer)
            Dim Today As DateTime = System.DateTime.Now.ToUniversalTime
            Dim SatelliteTime As New System.DateTime(Today.Year, Today.Month, Today.Day, UtcHours, UtcMinutes, UtcSeconds, UtcMilliseconds)
            RaiseEvent DateTimeChanged(SatelliteTime.ToLocalTime)
        End If
        If Words(7) <> "" Then
            Dim Speed As Double = Double.Parse(Words(7), NmeaCultureInfo) * MPHPerKnot
            RaiseEvent SpeedReceived(Speed)
            If Speed > 55 Then RaiseEvent SpeedLimitReached()
        End If
        If Words(8) <> "" Then
            Dim Bearing As Double = CType(Words(8), Double)
            RaiseEvent BearingReceived(Bearing)
        End If
        If Words(2) <> "" Then
            Select Case Words(2)
                Case "A"
                    RaiseEvent FixObtained()
                Case "V"
                    RaiseEvent FixLost()
            End Select
        End If
        Return True
    End Function

    Public Function ParseGPGSV(ByVal sentence As String) As Boolean
        Dim PseudoRandomCode As Integer
        Dim Azimuth As Integer
        Dim Elevation As Integer
        Dim SignalToNoiseRatio As Integer
        Dim Words() As String = GetWords(sentence)
        Dim Count As Integer
        For Count = 1 To 4
            If (Words.Length - 1) >= (Count * 4 + 3) Then
                If Words(Count * 4) <> "" And Words(Count * 4 + 1) <> "" And Words(Count * 4 + 2) <> "" And Words(Count * 4 + 3) <> "" Then
                    PseudoRandomCode = CType(Words(Count * 4), Integer)
                    Elevation = CType(Words(Count * 4 + 1), Integer)
                    Azimuth = CType(Words(Count * 4 + 2), Integer)
                    SignalToNoiseRatio = CType(Words(Count * 4 + 2), Integer)
                    RaiseEvent SatelliteReceived(PseudoRandomCode, Azimuth, Elevation, SignalToNoiseRatio)
                End If
            End If
        Next
        Return True
    End Function

    Public Function IsValid(ByVal sentence As String) As Boolean
        Return sentence.Substring(sentence.IndexOf("*") + 1).Trim = GetChecksum(sentence)
    End Function

    Public Function GetChecksum(ByVal sentence As String) As String
        Dim Character As Char
        Dim Checksum As Integer
        For Each Character In sentence
            Select Case Character
                Case "$"c
                Case "*"c
                    Exit For
                Case Else
                    If Checksum = 0 Then
                        Checksum = Convert.ToByte(Character)
                    Else
                        Checksum = Checksum Xor Convert.ToByte(Character)
                    End If
            End Select
        Next
        Return Checksum.ToString("X2")
    End Function

    Public Enum enumLongLat
        Latitude = 1
        Longitude = 2
    End Enum
    Public Enum enumReturnformat
        WithSigns = 0
        NMEA = 1
        [DECIMAL] = 2
    End Enum
    Private Function NMEAtoDecimal(ByVal Pos As String) As Double
        'Pos="5601.0318"
        Dim PosDb As Double = CDbl(Pos) ' CType(Replace(Pos, ".", ","), Double) 'Replace . with , (Used in danish doubles)
        Dim Deg As Double = Math.Floor(PosDb / 100)
        Dim DecPos As Double = Math.Round(Deg + ((PosDb - (Deg * 100)) / 60), 5)
        Return DecPos '=56.0172
    End Function

    Public Function DecimalPosToDegrees(ByVal Decimalpos As Double, ByVal Type As enumLongLat, ByVal Outputformat As enumReturnformat, Optional ByVal SecondResolution As Integer = 2) As String
        Dim Deg As Integer = 0
        Dim Min As Double = 0
        Dim Sec As Double = 0
        Dim Dir As String = ""
        Dim tmpPos As Double = Decimalpos
        If tmpPos < 0 Then tmpPos = Decimalpos * -1

        Deg = CType(Math.Floor(tmpPos), Integer)
        Min = (tmpPos - Deg) * 60
        Sec = (Min - Math.Floor(Min)) * 60
        Min = Math.Floor(Min)
        Sec = Math.Round(Sec, SecondResolution)

        Select Case Type
            Case enumLongLat.Latitude '=1
                If Decimalpos < 0 Then
                    Dir = "S"
                Else
                    Dir = "N"
                End If
            Case enumLongLat.Longitude '=2
                If Decimalpos < 0 Then
                    Dir = "W"
                Else
                    Dir = "E"
                End If
        End Select
        Select Case Outputformat
            Case enumReturnformat.NMEA
                Return AddZeros(Deg, 3) & AddZeros(Min, 2) & AddZeros(Sec, 2)
            Case enumReturnformat.WithSigns
                Return Deg & "°" & Min & """" & Sec & "'" & Dir
            Case Else
                Return ""
        End Select
    End Function


    Public Function AddZeros(ByVal Value As Double, ByVal Zeros As Integer) As String
        If Math.Floor(Value).ToString.Length < Zeros Then
            Return Value.ToString.PadLeft(Zeros, CType("0", Char))
        Else
            Return Value.ToString
        End If
    End Function

End Class