Imports System.Windows.Forms.Form
Imports System.Data.OleDb

Public Class Form2
    Dim x As String
    Dim y As String
    Dim z As String
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        x = TextBox1.Text
        y = TextBox2.Text
        z = TextBox3.Text

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Please enter all the values", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            TextBox1.Focus()
            Exit Sub
        Else
            Try
                connection()
                cmd = New OleDbCommand("routine_s", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("x", OleDbType.VarChar).Value = x
                cmd.Parameters.Add("y", OleDbType.VarChar).Value = y
                cmd.Parameters.Add("z", OleDbType.VarChar).Value = z
                da = New OleDbDataAdapter(cmd)
                dt.Load(cmd.ExecuteReader())
                Form5.DataGridView1.DataSource = dt

                Form5.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
            conn.Close()
        End If
       
    End Sub

End Class