Imports Microsoft.VisualBasic
Imports System.Data

Public Module CommonFunctions

    Sub CheckAllItems(ByVal chkBoxLst As CheckBoxList)
        Dim i As Integer
        For i = 0 To chkBoxLst.Items.Count - 1
            chkBoxLst.Items(i).Selected = True
        Next
    End Sub


    Function GetSelectedValues(ByVal lst As CheckBoxList) As String
        Dim nlst As String
        Dim j As Integer
        'Dim ncount As Integer = 0
        nlst = ""

        For j = 0 To lst.Items.Count - 1
            If lst.Items(j).Selected Then
                nlst = nlst + lst.Items(j).Value + ","
                'ncount = ncount + 1
            End If
        Next
        If nlst = "" Then
            If lst.ID = "lstAccount" Then
                nlst = "0,"
            Else
                For j = 0 To lst.Items.Count - 1
                    nlst = nlst + lst.Items(j).Value + ","
                Next
            End If
        End If
        If nlst <> "" Then
            nlst = Left(nlst, Len(nlst) - 1)
        Else
            nlst = "x-1"
        End If

        Return nlst
    End Function


    Function GetSelectedValue(ByVal ddl As DropDownList) As String
        Dim ntxtddl As String
        Dim j As Integer
        ntxtddl = ""
        If ddl.SelectedIndex > 0 Then
            For j = 0 To ddl.Items.Count - 1
                If ddl.Items(j).Selected Then
                    ntxtddl = ntxtddl + ddl.Items(j).Text + ","
                End If
            Next
        Else
            ntxtddl = ddl.Items(0).Text + ","
        End If
        If ntxtddl <> "" Then ntxtddl = Left(ntxtddl, Len(ntxtddl) - 1)
        Return ntxtddl
    End Function


    Public Sub SetDataSource(ByRef chkboxList As CheckBoxList, ByVal dt As DataTable, ByVal valueField As String, ByVal dataField As String)
        chkboxList.DataSource = dt
        chkboxList.DataTextField = dataField
        chkboxList.DataValueField = valueField
        chkboxList.DataBind()
    End Sub

    Public Sub SetDataSource(ByRef ddl As DropDownList, ByVal dt As DataTable, ByVal valueField As String, ByVal dataField As String)
        ddl.DataSource = dt
        ddl.DataTextField = dataField
        ddl.DataValueField = valueField
        ddl.DataBind()
    End Sub


    Public Sub DisplayError(ByRef lblControl As Label, ByVal ex As Exception)
        lblControl.Text = ClsErrorCatch.ErrorCatch(ex)
        lblControl.Visible = True
    End Sub


End Module
