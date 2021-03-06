﻿Imports System.Configuration
Imports NHLGames.My.Resources
Imports NHLGames.Objects

Namespace Utilities
    Public Class SettingsExtensions
        Public Shared Function ReadGameWatchArgs(Optional defaultReturnValue As Object = Nothing) As GameWatchArguments
            Dim args As Object = My.Settings.DefaultWatchArgs

            If String.IsNullOrEmpty(args) OrElse IsNothing(args) Then Return defaultReturnValue

            If TypeOf args Is GameWatchArguments Then
                args = DirectCast(args, GameWatchArguments)
                Return args
            End If

            Try
                Return Serialization.DeserializeObject(Of GameWatchArguments)(args)
            Catch ex As Exception
                Console.WriteLine(English.errorDeserialize, My.Settings.DefaultWatchArgs, NameOf(GameWatchArguments))
                Return defaultReturnValue
            End Try
        End Function

        Public Shared Function ReadAdDetectionConfigs(Optional defaultReturnValue As Object = Nothing) As AdDetectionConfigs
            Dim configs As Object = My.Settings.AdDetection

            If String.IsNullOrEmpty(configs) OrElse IsNothing(configs) Then Return defaultReturnValue

            If TypeOf configs Is AdDetectionConfigs Then
                configs = DirectCast(configs, AdDetectionConfigs)
                Return configs
            End If

            Try
                Return Serialization.DeserializeObject(Of AdDetectionConfigs)(configs)
            Catch ex As Exception
                Console.WriteLine(English.errorDeserialize, My.Settings.DefaultWatchArgs, NameOf(AdDetectionConfigs))
                Return defaultReturnValue
            End Try
        End Function
    End Class
End Namespace
