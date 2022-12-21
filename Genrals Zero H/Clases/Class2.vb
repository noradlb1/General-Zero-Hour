Public Class Button_Download
    Inherits Control
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
        ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
        Me.DoubleBuffered = True
        Me.Size = New System.Drawing.Size(115, 60)
        Me.BackColor = Color.Transparent
        Me.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular)
    End Sub
    Private mState As MouseState = MouseState.None
    Enum MouseState As Byte
        None = 0
        Down = 2
        Click = 4
    End Enum
    Public Event ControlEvents(ByVal parm As ControlState)
    Public dState As ControlState = ControlState.None
    Enum ControlState As Byte
        ProgressReady = 0 ' >>
        Processing = 2
        None = 3
        Completed = 4
        ReadyOpenFile = 5
    End Enum
    Private _TextAlignment As StringAlignment = StringAlignment.Center
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        mState = MouseState.None
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        mState = MouseState.Down
        Invalidate()
        MyBase.OnMouseDown(e)
    End Sub
    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        mState = MouseState.Click
        Invalidate()
        MyBase.OnClick(e)
    End Sub
    Private Property _BackColorProgress As Color = Color.FromArgb(145, 146, 145)

    <System.ComponentModel.Category("[ Colors ]")>
    Public Property BackColorProgress As Color
        Get
            Return _BackColorProgress
        End Get
        Set(value As Color)
            _BackColorProgress = value
            Invalidate()
        End Set
    End Property
    Private Property _ForColorProgress As Color = Color.FromArgb(0, 0, 0)

    <System.ComponentModel.Category("[ Colors ]")>
    Public Property ForColorProgress As Color
        Get
            Return _ForColorProgress
        End Get
        Set(value As Color)
            _ForColorProgress = value
            Invalidate()
        End Set
    End Property
    Private Property _BackColorButton As Color = Color.FromArgb(0, 0, 0)
    <System.ComponentModel.Category("[ Colors ]")>
    Public Property BackColorButton As Color
        Get
            Return _BackColorButton
        End Get
        Set(value As Color)
            _BackColorButton = value
            Invalidate()
        End Set
    End Property
    Private Property _DefaultTextColor As Color = Color.FromArgb(245, 245, 245)
    <System.ComponentModel.Category("[ Colors ]")>
    Public Property DefaultTextColor As Color
        Get
            Return _DefaultTextColor
        End Get
        Set(value As Color)
            _DefaultTextColor = value
            Invalidate()
        End Set
    End Property
    Private Property _DownTextColor As Color = Color.FromArgb(245, 245, 245)
    <System.ComponentModel.Category("[ Colors ]")>
    Public Property DownTextColor As Color
        Get
            Return _DownTextColor
        End Get
        Set(value As Color)
            _DownTextColor = value
            Invalidate()
        End Set
    End Property
    Private Property _Text0 As String = "Download"
    <System.ComponentModel.Category("[ Control ]")>
    Public Property Text0 As String
        Get
            Return _Text0
        End Get
        Set(value As String)
            _Text0 = value
            Invalidate()
        End Set
    End Property
    Private Property _Text1 As String = "Open File"
    <System.ComponentModel.Category("[ Control ]")>
    Public Property Text1 As String
        Get
            Return _Text1
        End Get
        Set(value As String)
            _Text1 = value
            Invalidate()
        End Set
    End Property
    Private Property _Path As String = Nothing
    <System.ComponentModel.Category("[ Control ]")>
    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
            Invalidate()
        End Set
    End Property
    Private Property _Height_Progress As Integer = 3
    <System.ComponentModel.Category("[ Control ]")>
    Public Property Height_Progress As Integer
        Get
            Return _Height_Progress
        End Get
        Set(value As Integer)
            If value < 1 Then value = 1
            If value > 5 Then value = 5
            _Height_Progress = value
            Invalidate()
        End Set
    End Property
    Private Objsender As Object() = {0, 0, 0, 0}
    Private Property Totalsize As Integer = 0
    Private Property Value As Integer = 0
    Private Property LineX As Integer = 0
    Private Property LineY As Integer = 0
    Private Property Trans As Integer = 255
    Private Property StringSize As New SizeF
    Private Property Started As Boolean = False
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        With G
            .SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            Select Case mState
                Case MouseState.None
                    If Started Then
                        If Systimer.Enabled = False Then
                            dState = ControlState.None
                            EnableTimer(Me.Width, 0)
                        End If
                        .FillRectangle(New SolidBrush(BackColorProgress), New Rectangle(0, point_0.Y, point_0.X, Me.Height))
                        If Not point_0.Y >= Me.Height / 2 Then
                            Dim xCols As Color = Color.FromArgb(Trans, DownTextColor.R, DownTextColor.G, DownTextColor.B)
                            .DrawString(Text0, Me.Font, New SolidBrush(xCols), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                            If Not Trans <= 15 Then
                                Trans -= 15
                            End If
                        End If
                    Else
                        Select Case dState
                            Case ControlState.ProgressReady
                                .FillRectangle(New SolidBrush(BackColorProgress), New Rectangle(0, point_0.Y, point_0.X, Me.Height))
                                If Not point_0.Y >= Me.Height / 2 Then
                                    .DrawString(Text0, Me.Font, New SolidBrush(DefaultTextColor), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                                End If
                                .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(0, Me.Height - Height_Progress, Value, Me.Height))
                                If Objsender(0) = 0 Then
                                    Objsender(0) = 1
                                    RaiseEvent ControlEvents(ControlState.ProgressReady)
                                End If
                            Case ControlState.Processing
                                StringSize = .MeasureString(Text1, Me.Font)
                                If Systimer.Enabled = False Then
                                    EnableTimer(0, 0)
                                End If
                                If point_1.Y = 0 Then
                                    .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(0, Me.Height - point_1.X - Height_Progress, Me.Width, Height_Progress))
                                Else
                                    .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(point_1.Y, Me.Height - point_1.X - Height_Progress, Me.Width - point_1.Y * 2, Height_Progress))
                                End If
                                .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                                If Objsender(1) = 0 Then
                                    Objsender(1) = 1
                                    RaiseEvent ControlEvents(ControlState.Processing)
                                End If
                            Case ControlState.Completed
                                .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(point_1.Y, Me.Height - point_1.X - Height_Progress, Me.Width - point_1.Y * 2, Height_Progress))
                                .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                                If Objsender(2) = 0 Then
                                    Objsender(2) = 1
                                    RaiseEvent ControlEvents(ControlState.Completed)
                                End If
                                If Me.Enabled = False Then Me.Enabled = True
                            Case ControlState.None
                                .FillRectangle(New SolidBrush(BackColorButton), ClientRectangle)
                                .DrawString(Text0, Me.Font, New SolidBrush(DefaultTextColor), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})

                                If Objsender(3) = 0 Then
                                    Objsender(3) = 1
                                    RaiseEvent ControlEvents(ControlState.None)
                                End If
                            Case ControlState.ReadyOpenFile
                                StringSize = .MeasureString(Text1, Me.Font)
                                Dim X As Integer = CInt(Me.Height / 2) - StringSize.Height + Height_Progress + RSize(Height_Progress)
                                Dim Y As Integer = CInt(Me.Width / 2) - CInt(StringSize.Width / 2) - 10
                                .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(Y, Me.Height - X - Height_Progress, Me.Width - Y * 2, Height_Progress))
                                .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                                If Me.Enabled = False Then Me.Enabled = True
                        End Select
                    End If
                Case MouseState.Down
                    If dState = ControlState.Completed Then
                        .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(point_1.Y, Me.Height - point_1.X - Height_Progress, Me.Width - point_1.Y * 2, Height_Progress))
                        .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                    ElseIf dState = ControlState.ReadyOpenFile Then
                        StringSize = .MeasureString(Text1, Me.Font)
                        Dim X As Integer = CInt(Me.Height / 2) - StringSize.Height + Height_Progress + RSize(Height_Progress)
                        Dim Y As Integer = CInt(Me.Width / 2) - CInt(StringSize.Width / 2) - 10
                        .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(Y, Me.Height - X - Height_Progress, Me.Width - Y * 2, Height_Progress))
                        .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        If Me.Enabled = False Then Me.Enabled = True
                    Else
                        .FillRectangle(New SolidBrush(BackColorProgress), ClientRectangle)
                        .DrawString(Text0, Me.Font, New SolidBrush(DownTextColor), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                    End If
                Case MouseState.Click
                    If dState = ControlState.Completed Then
                        .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(point_1.Y, Me.Height - point_1.X - Height_Progress, Me.Width - point_1.Y * 2, Height_Progress))
                        .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                    ElseIf dState = ControlState.ReadyOpenFile Then
                        StringSize = .MeasureString(Text1, Me.Font)
                        Dim X As Integer = CInt(Me.Height / 2) - StringSize.Height + Height_Progress + RSize(Height_Progress)
                        Dim Y As Integer = CInt(Me.Width / 2) - CInt(StringSize.Width / 2) - 10
                        .FillRectangle(New SolidBrush(ForColorProgress), New Rectangle(Y, Me.Height - X - Height_Progress, Me.Width - Y * 2, Height_Progress))
                        .DrawString(Text1, Me.Font, New SolidBrush(ForColorProgress), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        If Me.Enabled = False Then Me.Enabled = True
                    Else
                        .FillRectangle(New SolidBrush(BackColorButton), ClientRectangle)
                        .DrawString(Text0, Me.Font, New SolidBrush(DefaultTextColor), New Rectangle(1, 0, Width - 1, Height), New StringFormat With {.Alignment = _TextAlignment, .LineAlignment = StringAlignment.Center})
                        Started = True
                        Me.Enabled = False
                    End If
            End Select
        End With
    End Sub
    Public Sub Progress_Value(ByVal BytesReceived As Integer, ByVal TotalBytesToReceive As Integer)
        If dState = ControlState.ProgressReady Then
            Value = RateConverter(BytesReceived, TotalBytesToReceive, Me.Width)
            Totalsize = Me.Width
            Me.Invalidate()
            If Value = Totalsize Then
                dState = ControlState.Processing
            End If
        End If
    End Sub
    Public Sub RestValues()
        If Systimer IsNot Nothing Then
            Systimer.Stop()
            Systimer.Enabled = False
        End If
        Started = False
        Totalsize = 0
        Value = 0
        point_0 = New Point(0, 0)
        point_1 = New Point(0, 0)
        dState = ControlState.None
        mState = MouseState.None
        StringSize = New SizeF
        Objsender(0) = 0
        Objsender(1) = 0
        Objsender(2) = 0
        Objsender(3) = 0
        LineX = 0
        LineY = 0
        Trans = 255
        If Me.Enabled = False Then Me.Enabled = True
        Me.Invalidate()
    End Sub
    Private point_0 As Point = New Point(0, 0)
    Private point_1 As Point = New Point(0, 0)
    Private Systimer As New System.Timers.Timer
    Private Sub DisableTimer()
        If Systimer IsNot Nothing Then
            Systimer.Stop()
            Systimer.Enabled = False
            Started = False
        End If
    End Sub
    Private Sub EnableTimer(x As Integer, y As Integer)
        If dState = ControlState.None Then
            point_0.X = x
            point_0.Y = y
        ElseIf dState = ControlState.Processing Then
            point_1.X = x
        End If
        Systimer = New System.Timers.Timer
        AddHandler Systimer.Elapsed, AddressOf OnTimedEvent
        Systimer.Interval = 1
        Systimer.AutoReset = True
        Systimer.Enabled = True
    End Sub
    Private Sub OnTimedEvent(source As Object, e As Timers.ElapsedEventArgs)
        If dState = ControlState.None Then
            If point_0.Y < Me.Height - Height_Progress Then
                point_0.Y += 1
                Me.Invalidate()
            Else
                dState = ControlState.ProgressReady
                DisableTimer()
                Me.Invalidate()
            End If
        ElseIf dState = ControlState.Processing Then
            If point_1.X <= CInt(Me.Height / 2) - StringSize.Height + Height_Progress + RSize(Height_Progress) Then
                point_1.X += 1
                Me.Invalidate()
            Else
                LineX = 1
            End If
            If point_1.Y <= CInt(Me.Width / 2) - CInt(StringSize.Width / 2) - 10 Then
                point_1.Y += 1
                Me.Invalidate()
            Else
                LineY = 1
            End If
            If LineX = 1 And LineY = 1 Then
                dState = ControlState.Completed
                DisableTimer()
                Me.Invalidate()
            End If
        End If
    End Sub
    Private Function RSize(v As Integer) As Integer
        Select Case v
            Case 1
                Return 7
            Case 2
                Return 6
            Case 3
                Return 5
            Case 4
                Return 3
            Case 5
                Return 2
        End Select
        Return 3
    End Function
    Private Function RateConverter(ByVal _Value As Integer, ByVal _Totalsize As Integer, ByVal _Width As Integer) As Integer
        Try
            If _Totalsize = 0 Then
                Return 0
            End If
            Return CInt(Math.Round(CDbl(((CDbl(_Value) / CDbl(_Totalsize)) * _Width))))
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class