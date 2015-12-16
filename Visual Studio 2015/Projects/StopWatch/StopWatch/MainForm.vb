Public Class MainForm
    'スタート時刻
    Private startTime As DateTime
    '経過時間
    Private lapseTime As TimeSpan = TimeSpan.Zero
    'タイマーが動作中かどうか
    Private isTimerRunning As Boolean = False
    'カウントダウンする時間
    Private countDownTime As TimeSpan = TimeSpan.FromMinutes(5.0)


    '表示時間の文字列
    Private Function GetDisplayTimeString() As String
        '時間を文字列に変換するときの書式
        Dim format As String = "mm\:ss\.f"
        '書式を使って経過時間を文字列に変換して返す
        'Return lapseTime.ToString(format)
        '書式を使って残り時間を文字列に変換して返す
        Return GetRemainingTime().ToString(format)
    End Function

    'UIの更新
    'Private Sub UpdateUI()
    '表示時間の文字列を設定
    'displayTimeTextBox.Text = GetDisplayTimeString()
    'End Sub


    'メインフォームが読み込まれるときに呼ばれる
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '時間表示テキストボックスに文字列を設定
        'displayTimeTextBox.Text = "00:00.0"
        'timer.Start()

        'UIの更新
        UpdateUI()
    End Sub

    'タイマー稼動中は定期的に（ここでは100ミリ秒間隔で）呼ばれる
    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        '時間表示テキストボックスに現在時刻を文字列に変換して設定
        '    displayTimeTextBox.Text = DateTime.Now.ToLongTimeString()

        '経過時間は、現在の時刻 - 開始時刻
        lapseTime = DateTime.Now - startTime
        'UIの更新
        UpdateUI()
        'カウントダウンが終わったかどうかの確認
        CheckTime()
    End Sub

    'スタートボタンがクリックされたときに呼ばれる
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        If lapseTime = TimeSpan.Zero Then
            '開始時刻を記録
            startTime = DateTime.Now
        End If

        'タイマーがスタートしたことを記録
        isTimerRunning = True
        'タイマーをスタート
        timer.Start()
    End Sub

    'ストップボタンがクリックされたときに呼ばれる
    Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
        'タイマーを止める
        'timer.Stop()
        'UIの更新
        'UpdateUI()
        StopTimer()
    End Sub

    'リセットボタンがクリックされたときに呼ばれる
    Private Sub resetButton_Click(sender As Object, e As EventArgs) Handles resetButton.Click
        '経過時間をリセット
        lapseTime = TimeSpan.Zero
        'タイマーを止める
        'timer.Stop()
        'UIの更新
        'UpdateUI()
        StopTimer()
    End Sub

    Private Sub StopTimer()
        'タイマーを止める
        timer.Stop()
        'タイマーがストップしたことを記録
        isTimerRunning = False
        'UIの更新
        UpdateUI()
    End Sub

    '各ボタンを有効にするか無効にするかどうかを設定
    Private Sub EnableButtons()
        'スタートボタンはタイマー動作中でないときだけ有効にする
        startButton.Enabled = Not isTimerRunning
        'ストップボタンはタイマー動作中にだけ有効にする
        stopButton.Enabled = isTimerRunning
        'リセットボタンは経過時間が0でないときにだけ有効にする
        resetButton.Enabled = lapseTime <> TimeSpan.Zero
    End Sub

    'UIの更新
    Private Sub UpdateUI()
        '表示時間の文字列を設定
        displayTimeTextBox.Text = GetDisplayTimeString()
        '各ボタンを有効にするか無効にするかを設定
        EnableButtons()
        'カウントダウンする時間を入力するテキストボックスの更新
        UpdateCountDownTimeTextBox()
    End Sub

    Private Function GetRemainingTime() As TimeSpan
        '残り時間はカウントダウンする時間から経過した時間を引いた時間
        Dim remainingTime As TimeSpan = countDownTime - lapseTime
        '残り時間が0未満なら0、そうでないなら残り時間を返す
        If remainingTime <= TimeSpan.Zero Then
            Return TimeSpan.Zero
        Else
            Return remainingTime
        End If
    End Function

    'カウントダウンする時間を入力するテキストボックスの更新
    Private Sub UpdateCountDownTimeTextBox()
        'カウントダウンする時間を文字列に変換したものを設定
        countDownTimeTextBox.Text = countDownTime.Minutes.ToString()
        'タイマー動作中は読み込み専用にして入力させないようにする
        countDownTimeTextBox.ReadOnly = isTimerRunning
    End Sub

    Private Sub countDownTimeTextBox_TextChanged(sender As Object, e As EventArgs) Handles countDownTimeTextBox.TextChanged
        'カウントダウンする時間を入力するテキストボックスの文字列を整数に変換
        Dim countDownTimeMinutes As Integer
        '変換できたら
        If Integer.TryParse(countDownTimeTextBox.Text, countDownTimeMinutes) Then
            countDownTime = TimeSpan.FromMinutes(countDownTimeMinutes)
            'UIの更新
            UpdateUI()
        End If

    End Sub

    'カウントダウンが終わったかどうかの確認
    Private Sub CheckTime()
        'もし残り時間が0だったら
        If GetRemainingTime() = TimeSpan.Zero Then
            'ストップする
            StopTimer()
            '「メッセージ（情報）」の音を鳴らす
            Media.SystemSounds.Asterisk.Play()
        End If
    End Sub
End Class
