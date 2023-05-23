﻿Imports LMDataAccessLayer

Namespace MensajeriaEspecializada

    Public Class ReporteInventarioSiembraBLL

#Region "Atributos (Filtros de Busqueda)"

        Dim _idUsuario As Integer
        Dim _idEstado As Integer
        Dim _idCiudad As Integer

#End Region

#Region "Propiedades"

        Public Property IdUsuario As Long
            Get
                Return _idUsuario
            End Get
            Set(value As Long)
                _idUsuario = value
            End Set
        End Property

        Public Property IdEstado() As Integer
            Get
                Return _idEstado
            End Get
            Set(ByVal value As Integer)
                _idEstado = value
            End Set
        End Property

        Public Property IdCiudad() As Integer
            Get
                Return _idCiudad
            End Get
            Set(ByVal value As Integer)
                _idCiudad = value
            End Set
        End Property

#End Region

#Region "Constructores"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region

#Region "Métodos Públicos"

        Public Function ObtenerReporte() As DataTable
            Dim dtReporte As New DataTable
            If _idUsuario > 0 Then
                Using dbManager As New LMDataAccess
                    Try
                        With dbManager
                            .SqlParametros.Add("@idUsuario", SqlDbType.Int).Value = _idUsuario
                            If _idEstado > 0 Then .SqlParametros.Add("@idEstado", SqlDbType.Int).Value = _idEstado
                            If _idCiudad > 0 Then .SqlParametros.Add("@idCiudad", SqlDbType.Int).Value = _idCiudad
                            dtReporte = .ejecutarDataTable("ReporteInventarioSiembra", CommandType.StoredProcedure)
                        End With
                    Catch ex As Exception
                        Throw ex
                    End Try
                End Using
            End If
            Return dtReporte
        End Function

#End Region

    End Class

End Namespace
