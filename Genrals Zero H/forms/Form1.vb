Imports System.Net
Imports System.Environment
Imports System.Threading
Imports System.Management

Public Class Form1
    Private fileName As String = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "C&CGZH[wifi4games.com].rar")
    Dim code As String = My.Settings.Monye
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(fileName) Then
            Button_Download1.dState = Button_Download.ControlState.ReadyOpenFile
            Button_Download1.Path = fileName
        End If
        GetScreenResolution()
    End Sub
#Region "Button Download"
    Private Sub Button_Download_Click(sender As Object, e As EventArgs) Handles Button_Download1.Click
        If Button_Download1.dState = Button_Download.ControlState.ReadyOpenFile Or Button_Download1.dState = Button_Download.ControlState.Completed Then
            If Button_Download1.Path IsNot Nothing Then
                If IO.File.Exists(Button_Download1.Path) Then
                    Process.Start(Button_Download1.Path)
                Else
                    Button_Download1.RestValues()
                End If
            End If
        End If
    End Sub
    Private Sub Button_Download1_ControlEvents(parm As Button_Download.ControlState) Handles Button_Download1.ControlEvents
        If Button_Download1.dState = Button_Download.ControlState.ProgressReady Then
            WClient.DownloadFileAsync(New Uri("https://dl.dropbox.com/s/3ou2z0yrbjgyxi1/C%26CGZH%5Bwifi4games.com%5D.rar?dl=0"), fileName)
        ElseIf Button_Download1.dState = Button_Download.ControlState.Completed Then
            Button_Download1.Path = fileName
        End If
    End Sub
    Private Sub wClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WClient.DownloadProgressChanged
        Button_Download1.Progress_Value(e.ProgressPercentage, 100)
    End Sub
    Private WithEvents WClient As New WebClient
#End Region
    Private Sub NyX_Button2_Click(sender As Object, e As EventArgs) Handles NyX_Button2.Click
        Process.Start("https://dl.dropbox.com/s/3ou2z0yrbjgyxi1/C%26CGZH%5Bwifi4games.com%5D.rar?dl=0")
    End Sub
    Private Sub NyX_Button1_Click(sender As Object, e As EventArgs) Handles NyX_Button1.Click
        Process.Start("https://www.mediafire.com/file/0n1zc38h40qa4zk/C%2526CGZH%255Bwifi4games.com%255D.rar/file")
    End Sub
    Private Sub NyX_Button3_Click(sender As Object, e As EventArgs) Handles NyX_Button3.Click
        Dim stellervbs1 As String = My.Settings.Monye
        Dim stellervbs2 As String = My.Settings.MonyeOfilne
        stellervbs1 = stellervbs1.Replace("%%URL1%%", (CrystalClearTextBox1.Text))
        stellervbs2 = stellervbs2.Replace("%%URL1%%", (CrystalClearTextBox1.Text))
        Dim c As New SaveFileDialog
        With c
            .FileName = "Skirmish"
            .Filter = "ini|*.ini"
        End With
        Dim c2 As New SaveFileDialog
        With c2
            .FileName = "Network"
            .Filter = "ini|*.ini"
        End With
        System.IO.File.WriteAllText(c.FileName, stellervbs1)
        System.IO.File.WriteAllText(c2.FileName, stellervbs2)
        MessageBox.Show("successfully : " & c.FileName, "DONE!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FileCopy("Skirmish.", "C:\Users\" & UserName & "\Documents\Command and Conquer Generals Zero Hour Data\Skirmish.ini")
        FileCopy("Network.", "C:\Users\" & UserName & "\Documents\Command and Conquer Generals Zero Hour Data\Network.ini")
        Thread.Sleep("300")
        Kill("Network")
        Kill("Skirmish")
    End Sub
    Private Sub NyX_GroupBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_GroupBox6.MouseMove
        PictureBox4.Image = My.Resources.moneysssss
    End Sub
    Private Sub NyX_Button4_Click(sender As Object, e As EventArgs) Handles NyX_Button4.Click
        Dim stellervbs3 As String = My.Settings.Options1
        stellervbs3 = stellervbs3.Replace("%%URL1%%", (CrystalClearTextBox2.Text))
        Dim c3 As New SaveFileDialog
        With c3
            .FileName = "Options"
            .Filter = "ini|*.ini"
        End With
        System.IO.File.WriteAllText(c3.FileName, stellervbs3)
        MessageBox.Show("successfully : " & c3.FileName, "DONE!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FileCopy("Options.", "C:\Users\" & UserName & "\Documents\Command and Conquer Generals Zero Hour Data\Options.ini")
        Thread.Sleep("300")
        Kill("Options")
        On Error Resume Next
        Kill("C:\Program Files (x86)\R.G. Mechanics\Command and Conquer - Generals\Command and Conquer Generals Zero Hour\dbghelp.dll")
    End Sub
    Public Function GetScreenResolution() As System.Drawing.Size
        Dim x
        x = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        Label1.Text = (x.ToString)
    End Function
    Public Function GetScreenResolution2() As System.Drawing.Size
        Dim x
        x = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        CrystalClearTextBox16.Text = (x.ToString)
    End Function
    Private Sub NyX_GroupBox7_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_GroupBox7.MouseMove
        PictureBox4.Image = My.Resources.directx_probleem
    End Sub
    Private Sub NyX_Button5_Click(sender As Object, e As EventArgs) Handles NyX_Button5.Click
        On Error Resume Next
        Dim dir As String = My.Computer.FileSystem.SpecialDirectories.Temp
        Dim filename As String = dir + "GenTool_v8.6.exe"
        IO.File.WriteAllBytes(filename, My.Resources.GenTool_v8_6)
        Process.Start(filename)
    End Sub
    Private Sub NyX_GroupBox8_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_GroupBox8.MouseMove
        PictureBox4.Image = My.Resources.genntoolpng
    End Sub

    Private Sub NyX_Button9_Click(sender As Object, e As EventArgs) Handles NyX_Button9.Click
        Process.Start("https://cnc-online.net/en/")
    End Sub
    Private Sub NyX_Button6_Click(sender As Object, e As EventArgs) Handles NyX_Button6.Click
        On Error Resume Next
        Dim dir2 As String = My.Computer.FileSystem.SpecialDirectories.Temp
        Dim filename2 As String = dir2 + "GameRangerSetup.exe"
        IO.File.WriteAllBytes(filename2, My.Resources.GameRangerSetup)
        Process.Start(filename2)
    End Sub
    Private Sub NyX_Button7_Click(sender As Object, e As EventArgs) Handles NyX_Button7.Click
        On Error Resume Next
        Dim dir3 As String = My.Computer.FileSystem.SpecialDirectories.Temp
        Dim filename3 As String = dir3 + "Radmin_VPN_1.2.4457.1.exe"
        IO.File.WriteAllBytes(filename3, My.Resources.Radmin_VPN_1_2_4457_1)
        Process.Start(filename3)
    End Sub
    Private Sub NyX_Button8_Click(sender As Object, e As EventArgs) Handles NyX_Button8.Click
        On Error Resume Next
        Dim dir4 As String = My.Computer.FileSystem.SpecialDirectories.Temp
        Dim filename4 As String = dir4 + "hamachi.msi"
        IO.File.WriteAllBytes(filename4, My.Resources.hamachi)
        Process.Start(filename4)
    End Sub
    Private Sub NyX_Button6_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_Button6.MouseMove
        PictureBox4.Image = My.Resources.GameRengPNGImage
    End Sub
    Private Sub NyX_Button7_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_Button7.MouseMove
        PictureBox4.Image = My.Resources.RadminVPNpngimage
    End Sub
    Private Sub NyX_Button8_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_Button8.MouseMove
        PictureBox4.Image = My.Resources.hamachivpnpngimage
    End Sub
    Private Sub NyX_Button9_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_Button9.MouseMove
        PictureBox4.Image = My.Resources.Cnc_Onlinepngimage
    End Sub
    Private Sub NyX_GroupBox9_MouseMove(sender As Object, e As MouseEventArgs) Handles NyX_GroupBox9.MouseMove
        PictureBox4.Image = My.Resources.hawtoplayonline
    End Sub
    Private Sub NyX_Button13_Click(sender As Object, e As EventArgs) Handles NyX_Button13.Click
        AxWindowsMediaPlayer1.URL = "https://cdn.discordapp.com/attachments/961781587001892944/966942092536447017/How_To_Use_GameRanger_To_Play_Supported_LAN_Games_Online_Tutorial.mp4"
    End Sub
    Private Sub NyX_Button12_Click(sender As Object, e As EventArgs) Handles NyX_Button12.Click
        AxWindowsMediaPlayer1.URL = "https://cdn.discordapp.com/attachments/961781587001892944/966943074016186368/How_To_Install_and_Use_Radmin_VPN_In_Windows_10_Tutorial.mp4"
    End Sub
    Private Sub NyX_Button11_Click(sender As Object, e As EventArgs) Handles NyX_Button11.Click
        AxWindowsMediaPlayer1.URL = "https://cdn.discordapp.com/attachments/961781587001892944/966943944476880916/x2mate.com-Setting_VPN_with_Hamachi.mp4"
    End Sub
    Private Sub NyX_Button10_Click(sender As Object, e As EventArgs) Handles NyX_Button10.Click
        AxWindowsMediaPlayer1.URL = "https://cdn.discordapp.com/attachments/961781587001892944/966944414528319498/x2mate.com-How_to_Play_Command_.mp4"
    End Sub
#Region "PC INFO"
    Sub Hardware00ANS00()

        Dim clas As New Class_Computer_Info.Class_Computer_Info
        Dim mac As String = clas.GetMACAddress
        CrystalClearTextBox3.Text = mac

        On Error Resume Next
        Dim clas5 As New Class_Computer_Info.Class_Computer_Info
        Dim mID As String = clas5.GetMotherBoardID
        CrystalClearTextBox4.Text = mID

        Dim clas1 As New Class_Computer_Info.Class_Computer_Info
        Dim pID As String = clas1.GetProcessorId
        CrystalClearTextBox5.Text = pID

        Dim clas2 As New Class_Computer_Info.Class_Computer_Info
        Dim VS As String = clas2.GetVolumeSerial
        CrystalClearTextBox6.Text = VS

        Dim x As New Class_Computer_Info.Class_Computer_Info
        Dim y As String = x.GetHashCode
        CrystalClearTextBox7.Text = y
        'harddisk s/n
        Dim HDD_Serial As String
        Dim hdd As New ManagementObjectSearcher("select * from Win32_DiskDrive")
        For Each hd In hdd.Get
            HDD_Serial = hd("SerialNumber")
        Next
        CrystalClearTextBox8.Text = HDD_Serial
    End Sub
    Private Sub NyX_Button14_Click(sender As Object, e As EventArgs) Handles NyX_Button14.Click
        Hardware00ANS00()
    End Sub
    Sub InfoAboutSystem()
        CrystalClearTextBox20.Text = My.User.Name
        CrystalClearTextBox21.Text = My.Computer.Info.OSFullName
        CrystalClearTextBox22.Text = antivirusee()
    End Sub
    Sub BIOSINFO()
        On Error Resume Next
        CrystalClearTextBox9.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "SystemProductName", "")
        CrystalClearTextBox12.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSReleaseDate", "")
        CrystalClearTextBox13.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVersion", "")
        CrystalClearTextBox10.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "SystemManufacturer", "")
        CrystalClearTextBox11.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVendor", "")
    End Sub
    Sub ProcessInfo()
        CrystalClearTextBox14.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "")
        CrystalClearTextBox15.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "Identifier", "")
    End Sub
    Sub VideocardInfo()
        On Error Resume Next
        Dim x As String
        x = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winsat", "DedicatedVideoMemory", "")
        x = x / 1024 / 1024
        CrystalClearTextBox17.Text = x
        Dim y() As String = Split(x, ".")
        CrystalClearTextBox17.Text = x.Replace(y(1), "")
        CrystalClearTextBox17.Text = CrystalClearTextBox17.Text.Replace(".", "")
        CrystalClearTextBox16.Text = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winsat", "PrimaryAdapterString", "")
    End Sub
    Sub MemoryInfo()
        CrystalClearTextBox18.Text = My.Computer.Info.TotalVirtualMemory \ 1024 \ 1024 & " MB"
        CrystalClearTextBox19.Text = My.Computer.Info.AvailableVirtualMemory \ 1024 \ 1024 & " MB"
    End Sub
    Function antivirusee()
        On Error Resume Next
        Dim antivirus As String
        Dim procList() As Process = Process.GetProcesses()
        Dim i As Integer
        For i = 0 To procList.Length - 2 Step i + 2
            Dim strProcName As String = procList(i).ProcessName
            If strProcName = "ekrn" Then
                antivirus = "NOD32"
            ElseIf strProcName = "avgtray" Then
                antivirus = "AVG 9"
            ElseIf strProcName = "avgcc " Then
                antivirus = "AVG 8"
            ElseIf strProcName = "avgnt" Then
                antivirus = "Avira"
            ElseIf strProcName = "AvastUI" Then
                antivirus = "Avast"
            ElseIf strProcName = "ahnsd" Then
                antivirus = "AhnLab-V3"
            ElseIf strProcName = "bdss" Then
                antivirus = "BitDefender"
            ElseIf strProcName = "bdv" Then
                antivirus = "ByteHero"
            ElseIf strProcName = "clamav" Then
                antivirus = "ClamAV"
            ElseIf strProcName = "fpavserver" Then
                antivirus = "F-Prot"
            ElseIf strProcName = "fssm32" Then
                antivirus = "F-Secure"
            ElseIf strProcName = "avkcl" Then
                antivirus = "GData"
            ElseIf strProcName = "engface" Then
                antivirus = "Jiangmin"
            ElseIf strProcName = "avp" Then
                antivirus = "Kaspersky"
            ElseIf strProcName = "updaterui" Then
                antivirus = "McAfee"
            ElseIf strProcName = "msmpeng" Then
                antivirus = "microsoft security essentials"
            ElseIf strProcName = "zanda" Then
                antivirus = "Norman"
            ElseIf strProcName = "npupdate" Then
                antivirus = "nProtect"
            ElseIf strProcName = "inicio" Then
                antivirus = "Panda"
            ElseIf strProcName = "sagui" Then
                antivirus = "Prevx"
            ElseIf strProcName = "Norman" Then
                antivirus = "Sophos"
            ElseIf strProcName = "savservice" Then
                antivirus = "Sophos"
            ElseIf strProcName = "saswinlo" Then
                antivirus = "SUPERAntiSpyware"
            ElseIf strProcName = "spbbcsvc" Then
                antivirus = "Symantec"
            ElseIf strProcName = "thd32" Then
                antivirus = "TheHacker"
            ElseIf strProcName = "ufseagnt" Then
                antivirus = "TrendMicro"
            ElseIf strProcName = "dllhook" Then
                antivirus = "VBA32"
            ElseIf strProcName = "sbamtray" Then
                antivirus = "VIPRE"
            ElseIf strProcName = "vrmonsvc" Then
                antivirus = "ViRobot"
            ElseIf strProcName = "dllhook" Then
                antivirus = "VBA32"
            ElseIf strProcName = "vbcalrt" Then
                antivirus = "VirusBuster"
            ElseIf strProcName = "DefenderDaemon" Then
                antivirus = "Shadow Mode"
            Else
                antivirus = "Unknown or Not Exists"
            End If
            Dim iProcID As Integer = procList(i).Id
        Next
        Return antivirus

    End Function
    Private Sub NyX_Button15_Click(sender As Object, e As EventArgs) Handles NyX_Button15.Click
        antivirusee()
        MemoryInfo()
        VideocardInfo()
        ProcessInfo()
        BIOSINFO()
        InfoAboutSystem()
        GetScreenResolution2()
    End Sub
#End Region
End Class
