Imports Microsoft.VisualBasic

Namespace PS.Common

    Public Class Translator
        Private Shared _resource_name As String
        Private Shared _LanguageID As Integer


        Public Shared Function GetValue(ByVal key As String) As String
            Dim rs_name As String
            rs_name = "PS_EN"

            If System.Web.HttpContext.Current.Session("LanguageID") Is Nothing Then
                _LanguageID = 1
            Else
                _LanguageID = CType(System.Web.HttpContext.Current.Session("LanguageID"), Integer)
            End If

            If _LanguageID > 0 Then
                If _LanguageID = 2 Then
                    rs_name = "PS_SP"
                End If
            End If

            _resource_name = rs_name

            If Len(key) > 1 And Not IsDBNull(key) Then
                Dim text As String
                text = HttpContext.GetGlobalResourceObject(_resource_name, key)

                If text = "" Then
                    text = key
                End If

                Return text
'text 
            Else
                Return ""
            End If
        End Function
    End Class

End Namespace


