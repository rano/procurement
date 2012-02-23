Imports Microsoft.VisualBasic

Namespace PS.Common


    Public Class SessionInit
        Private Shared _WUSession As Aptify.Framework.Web.eBusiness.ClsWUSession
        Private Shared _SessionID As String

        Public Shared Function GetSession() As String

            If _SessionID Is Nothing Then
                _WUSession = New Aptify.Framework.Web.eBusiness.ClsWUSession
                _SessionID = _WUSession.GetWUSessionID(System.Web.HttpContext.Current.Session.SessionID, Convert.ToString(System.Web.HttpContext.Current.Session("LoginID")))
                System.Web.HttpContext.Current.Session("WUSession") = _SessionID

                Dim oUser As New Aptify.Framework.Web.eBusiness.User
                oUser.LoadValuesFromSessionObject(System.Web.HttpContext.Current.Session)

                System.Web.HttpContext.Current.Session("UserName") = oUser.FirstName + " " + oUser.LastName
                System.Web.HttpContext.Current.Session("UserID") = oUser.UserID
            End If

            Return _SessionID

        End Function

        
    End Class

End Namespace
