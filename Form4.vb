Imports System.Windows.Forms.Form
Imports System.Data.OleDb

Public Class Form4
    Dim x As String
    Dim y As String
    Dim z As String
    Dim w As String
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        w = TextBox1.Text
        x = TextBox2.Text
        y = TextBox3.Text
        z = TextBox4.Text

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Please enter all the values", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            TextBox1.Focus()
            Exit Sub
        Else
            Try
                connection()
                cmd = New OleDbCommand("attend_s", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("w", OleDbType.VarChar).Value = w
                cmd.Parameters.Add("x", OleDbType.VarChar).Value = x
                cmd.Parameters.Add("y", OleDbType.VarChar).Value = y
                cmd.Parameters.Add("z", OleDbType.VarChar).Value = z
                da = New OleDbDataAdapter(cmd)
                dt.Load(cmd.ExecuteReader())
                Form7.DataGridView1.DataSource = dt

                Form7.Show()
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If

    End Sub
End Class