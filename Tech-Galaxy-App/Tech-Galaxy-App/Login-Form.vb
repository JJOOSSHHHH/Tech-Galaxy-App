Imports System.Data.OleDb
Public Class frmLogin

    Public Sub ClearData()
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub brnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please enter the necessary information to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            DoSignIn()
        End If
    End Sub

    Public Sub DoSignIn()
        con.Open()
        Using cmd As New OleDbCommand("SELECT username,password FROM tbl_login WHERE username=@Username AND password=@Password", con)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text)
            Dim result = cmd.ExecuteScalar()
            If result > 0 Then
                Dim reader As OleDbDataReader
                reader = cmd.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    If reader.Item(6).ToString = "admin" Then
                        frmMain.Show()
                        Me.Close()
                    Else
                        frmUserMain.Show()
                        Me.Close()
                    End If
                End If
            End If
        End Using
        TESTIIIIING

    End Sub
End Class
