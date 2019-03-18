Public Class Form1

    '移动窗口
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



    '关闭按钮

    '设置按钮贴图
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Close.Image = My.Resources.close_0
    End Sub
    '单击按钮退出
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
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


End Class

