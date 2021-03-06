﻿Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.NetworkInformation
Imports System.Net

Public Enum InternetConnectionState
    Connected
    Disconnected
End Enum

Public Class NetworkConnections
    Implements IDisposable

    Public Shared Property CheckHostName As String = "www.google.com"
    Public Property ConnectionStableAfterSec As Integer = 5

    Private MonitoringStarted As Boolean = False
    Private StableCheckTimer As System.Threading.Timer
    Private IsFirstCheck As Boolean = True
    Private wConnectionIsStable As Boolean
    Private PrevInternetConnectionState As InternetConnectionState = InternetConnectionState.Disconnected

    Public Event InternetConnectionStateChanged(ByVal ConnectionState As InternetConnectionState)
    Public Event InternetConnectionStableChanged(ByVal IsStable As Boolean, ByVal ConnectionState As InternetConnectionState)

    Public Sub StartMonitoring()
        If MonitoringStarted = False Then
            AddHandler NetworkChange.NetworkAddressChanged, AddressOf NetworkAddressChanged
            MonitoringStarted = True
            NetworkAddressChanged(Me, Nothing)
        End If
    End Sub

    Public Sub StopMonitoring()
        If MonitoringStarted = True Then
            Try
                RemoveHandler NetworkChange.NetworkAddressChanged, AddressOf NetworkAddressChanged
            Catch ex As Exception
            End Try

            MonitoringStarted = False
        End If
    End Sub

    Public ReadOnly Property ConnectionIsStableNow As Boolean
        Get
            Return wConnectionIsStable
        End Get
    End Property

    <DllImport("wininet.dll")> _
    Private Shared Function InternetGetConnectedState(ByRef Description As Integer, ByVal ReservedValue As Integer) As Boolean
    End Function

    Private Shared Function IsInternetAvailable() As Boolean
        Try
            Dim ConnDesc As Integer
            Dim conn As Boolean = InternetGetConnectedState(ConnDesc, 0)
            Return conn
        Catch
            Return False
        End Try
    End Function

    Private Shared Function IsInternetAvailableByDns() As Boolean
        Try
            Dim iheObj As IPHostEntry = Dns.GetHostEntry(CheckHostName)
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Shared Function CheckInternetConnectionIsAvailable() As Boolean
        Return IsInternetAvailable() And IsInternetAvailableByDns()
    End Function

    Private Sub NetworkAddressChanged(sender As Object, e As EventArgs)
        wConnectionIsStable = False
        StableCheckTimer = New System.Threading.Timer(AddressOf ElapsedAndStable, Nothing, New TimeSpan(0, 0, ConnectionStableAfterSec), New TimeSpan(1, 0, 0))

        If IsFirstCheck Then
            If CheckInternetConnectionIsAvailable() Then
                PrevInternetConnectionState = InternetConnectionState.Connected
                RaiseEvent InternetConnectionStateChanged(InternetConnectionState.Connected)
            Else
                PrevInternetConnectionState = InternetConnectionState.Disconnected
                RaiseEvent InternetConnectionStateChanged(InternetConnectionState.Disconnected)
            End If

            IsFirstCheck = False
        Else
            If CheckInternetConnectionIsAvailable() Then
                If PrevInternetConnectionState <> InternetConnectionState.Connected Then
                    PrevInternetConnectionState = InternetConnectionState.Connected
                    RaiseEvent InternetConnectionStateChanged(InternetConnectionState.Connected)
                End If
            Else
                If PrevInternetConnectionState <> InternetConnectionState.Disconnected Then
                    PrevInternetConnectionState = InternetConnectionState.Disconnected
                    RaiseEvent InternetConnectionStateChanged(InternetConnectionState.Disconnected)
                End If
            End If
        End If
    End Sub

    Private Sub ElapsedAndStable()
        If wConnectionIsStable = False Then
            wConnectionIsStable = True
            Dim hasnet As Boolean = CheckInternetConnectionIsAvailable()
            RaiseEvent InternetConnectionStableChanged(True, IIf(hasnet, InternetConnectionState.Connected, InternetConnectionState.Disconnected))
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Try
                    RemoveHandler NetworkChange.NetworkAddressChanged, AddressOf NetworkAddressChanged
                Catch ex As Exception
                End Try
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class