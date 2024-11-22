Imports System.Diagnostics

Public Class Form1
    ' Event Form Load untuk pertama kali membuka form
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Menyiapkan kolom-kolom ListView
        lvProcesses.Columns.Add("PID", 100, HorizontalAlignment.Left)
        lvProcesses.Columns.Add("Name", 200, HorizontalAlignment.Left)
        lvProcesses.Columns.Add("Status", 100, HorizontalAlignment.Left)

        ' Menampilkan daftar proses pertama kali form dibuka
        LoadProcesses()
    End Sub

    ' Fungsi untuk memuat dan menampilkan proses yang sedang berjalan
    Private Sub LoadProcesses()
        ' Membersihkan ListView sebelum menambahkan data baru
        lvProcesses.Items.Clear()

        ' Mengambil semua proses yang sedang berjalan
        For Each proc As Process In Process.GetProcesses()
            Try
                ' Mendapatkan PID, Nama, dan Status Proses
                Dim pid As Integer = proc.Id
                Dim name As String = proc.ProcessName
                Dim status As String = If(proc.Responding, "Running", "Not Responding")

                ' Membuat item baru untuk ListView
                Dim listViewItem As New ListViewItem(pid.ToString())
                listViewItem.SubItems.Add(name)
                listViewItem.SubItems.Add(status)

                ' Menambahkan item ke ListView
                lvProcesses.Items.Add(listViewItem)
            Catch ex As Exception
                ' Menangani error jika ada masalah dengan akses proses
                ' Tidak menambahkan item ke ListView jika ada kesalahan
            End Try
        Next

        
    End Sub

    ' Event handler untuk tombol Refresh, untuk memuat ulang daftar proses
    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        LoadProcesses()
    End Sub
End Class
