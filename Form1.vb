Public Class Form1


    '窗口淡入淡出函数
    Private Sub FormFade(ByVal FType)
        Select Case FType
            Case ("in")
                Dim FadeCount As Integer
                For FadeCount = 10 To 90 Step 10
                    Me.Opacity = FadeCount / 100
                    Me.Refresh()
                    Threading.Thread.Sleep(50)
                Next
            Case ("out")
                Dim FadeCount As Integer
                For FadeCount = 90 To 10 Step -10
                    Me.Opacity = FadeCount / 100
                    Me.Refresh()
                    Threading.Thread.Sleep(50)
                Next
        End Select
        Me.Opacity = 99
    End Sub



    '移动窗口函数
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub



    '事件

    '设置按钮贴图，淡入
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DoubleBuffered = True '采用缓冲，解决窗体闪烁问题
        FormFade("in") '窗体打开时淡入
        Close.Image = My.Resources.close_0
    End Sub
    '单击按钮退出
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        FormFade("out")
        End
    End Sub
    '按钮选中时贴图
    Private Sub Close_MouseMove(sender As Object, e As MouseEventArgs) Handles Close.MouseMove
        Close.Image = My.Resources.close_1
    End Sub

    '按钮按下时贴图
    Private Sub Close_MouseDown(sender As Object, e As MouseEventArgs) Handles Close.MouseDown
        Close.Image = My.Resources.close_2
    End Sub
    '按钮移开时恢复贴图
    Private Sub Close_MouseLeave(sender As Object, e As EventArgs) Handles Close.MouseLeave
        Close.Image = My.Resources.close_0
    End Sub

    '关闭窗口时淡出
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FormFade("out")
    End Sub
End Class

