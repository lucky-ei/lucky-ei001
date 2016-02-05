Public Class Form1

    Const DAIKICHI As Integer = 1
    Const CHUKICHI As Integer = 2
    Const SUEKICHI As Integer = 3
    Const KYO As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim randomnumber As System.Random
        randomnumber = New System.Random()
        Dim resultkujibiki As Integer
        resultkujibiki = randomnumber.Next(4)

        Select Case resultkujibiki
            Case 1
                Label2.Text = "大吉です！！"
                TextBox1.Text = "今日は良いことありまっせ"
            Case 2
                Label2.Text = "中吉です！！"
                TextBox1.Text = "普通じゃないかな"
            Case 3
                Label2.Text = "末吉です！！"
                TextBox1.Text = "あんまり…"
            Case 0
                Label2.Text = "凶です！！"
                TextBox1.Text = "ドンマイ"
        End Select

    End Sub


End Class
