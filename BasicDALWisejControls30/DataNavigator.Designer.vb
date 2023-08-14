<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataNavigator
    Inherits Wisej.Web.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Wisej Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Wisej Designer
    'It can be modified using the Wisej Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ToolBar = New Wisej.Web.ToolBar()
        Me.bFirst = New Wisej.Web.ToolBarButton()
        Me.bPrev = New Wisej.Web.ToolBarButton()
        Me.RecordLabel = New Wisej.Web.ToolBarButton()
        Me.bNext = New Wisej.Web.ToolBarButton()
        Me.bLast = New Wisej.Web.ToolBarButton()
        Me.bRefresh = New Wisej.Web.ToolBarButton()
        Me.bNew = New Wisej.Web.ToolBarButton()
        Me.bDelete = New Wisej.Web.ToolBarButton()
        Me.bFind = New Wisej.Web.ToolBarButton()
        Me.bPrint = New Wisej.Web.ToolBarButton()
        Me.bUndo = New Wisej.Web.ToolBarButton()
        Me.bSave = New Wisej.Web.ToolBarButton()
        Me.bClose = New Wisej.Web.ToolBarButton()
        Me.Panel = New Wisej.Web.Panel()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.AutoSize = False
        Me.ToolBar.BorderStyle = Wisej.Web.BorderStyle.Solid
        Me.ToolBar.Buttons.AddRange(New Wisej.Web.ToolBarButton() {Me.bFirst, Me.bPrev, Me.RecordLabel, Me.bNext, Me.bLast, Me.bRefresh, Me.bNew, Me.bDelete, Me.bFind, Me.bPrint, Me.bUndo, Me.bSave, Me.bClose})
        Me.ToolBar.Dock = Wisej.Web.DockStyle.None
        Me.ToolBar.Font = New System.Drawing.Font("default", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Margin = New Wisej.Web.Padding(0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.Size = New System.Drawing.Size(722, 55)
        Me.ToolBar.TabIndex = 0
        Me.ToolBar.TabStop = False
        '
        'bFirst
        '
        Me.bFirst.AllowHtml = True
        Me.bFirst.ImageSource = "icon-first"
        Me.bFirst.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bFirst.Name = "bFirst"
        Me.bFirst.Text = "Inizio<br>Shift-F6"
        '
        'bPrev
        '
        Me.bPrev.AllowHtml = True
        Me.bPrev.ImageSource = "icon-left"
        Me.bPrev.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bPrev.Name = "bPrev"
        Me.bPrev.Text = "Prec.<br>F6"
        '
        'RecordLabel
        '
        Me.RecordLabel.AllowHtml = True
        Me.RecordLabel.Enabled = False
        Me.RecordLabel.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.RecordLabel.Name = "RecordLabel"
        Me.RecordLabel.Text = "0<br>0"
        '
        'bNext
        '
        Me.bNext.AllowHtml = True
        Me.bNext.ImageSource = "icon-right"
        Me.bNext.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bNext.Name = "bNext"
        Me.bNext.Text = "Succ.<br>F7"
        '
        'bLast
        '
        Me.bLast.AllowHtml = True
        Me.bLast.ImageSource = "icon-last"
        Me.bLast.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bLast.Name = "bLast"
        Me.bLast.Text = "Fine<br>Shift-F7"
        '
        'bRefresh
        '
        Me.bRefresh.AllowHtml = True
        Me.bRefresh.ImageSource = "icon-redo"
        Me.bRefresh.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bRefresh.Name = "bRefresh"
        Me.bRefresh.Text = "Ricarica dati<br>F5"
        '
        'bNew
        '
        Me.bNew.AllowHtml = True
        Me.bNew.ImageSource = "icon-new"
        Me.bNew.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bNew.Name = "bNew"
        Me.bNew.Text = "Nuovo<br>F2"
        '
        'bDelete
        '
        Me.bDelete.AllowHtml = True
        Me.bDelete.ImageSource = "tab-close"
        Me.bDelete.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bDelete.Name = "bDelete"
        Me.bDelete.Text = "Elimina<br>F3"
        '
        'bFind
        '
        Me.bFind.AllowHtml = True
        Me.bFind.ImageSource = "icon-search"
        Me.bFind.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bFind.Name = "bFind"
        Me.bFind.Text = "Ricerca<br>F4"
        '
        'bPrint
        '
        Me.bPrint.AllowHtml = True
        Me.bPrint.ImageSource = "icon-print"
        Me.bPrint.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bPrint.Name = "bPrint"
        Me.bPrint.Text = "Stampa<br>F8"
        '
        'bUndo
        '
        Me.bUndo.AllowHtml = True
        Me.bUndo.ImageSource = "icon-undo"
        Me.bUndo.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bUndo.Name = "bUndo"
        Me.bUndo.Text = "Annulla<br>F9"
        '
        'bSave
        '
        Me.bSave.AllowHtml = True
        Me.bSave.ImageSource = "icon-save"
        Me.bSave.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bSave.Name = "bSave"
        Me.bSave.Text = "Salva<br>F10"
        '
        'bClose
        '
        Me.bClose.AllowHtml = True
        Me.bClose.ImageSource = "icon-exit"
        Me.bClose.Margin = New Wisej.Web.Padding(0, -5, 0, 0)
        Me.bClose.Name = "bClose"
        Me.bClose.Text = "<p style='margin-top: 0px;line-height:1.2;text-align:center;'>Chiudi<br>F12</p>"
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.ToolBar)
        Me.Panel.Font = New System.Drawing.Font("default", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Panel.HeaderSize = 14
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Margin = New Wisej.Web.Padding(0)
        Me.Panel.Name = "Panel"
        Me.Panel.ShowCloseButton = False
        Me.Panel.ShowHeader = True
        Me.Panel.Size = New System.Drawing.Size(763, 70)
        Me.Panel.TabIndex = 1
        Me.Panel.Text = "Navigatore Dati"
        '
        'DataNavigator
        '
        Me.Controls.Add(Me.Panel)
        Me.Name = "DataNavigator"
        Me.Size = New System.Drawing.Size(794, 70)
        Me.Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bFirst As ToolBarButton
    Friend WithEvents bPrev As ToolBarButton
    Friend WithEvents bNext As ToolBarButton
    Friend WithEvents bLast As ToolBarButton
    Friend WithEvents bRefresh As ToolBarButton
    Friend WithEvents bNew As ToolBarButton
    Friend WithEvents bDelete As ToolBarButton
    Friend WithEvents bFind As ToolBarButton
    Friend WithEvents bUndo As ToolBarButton
    Friend WithEvents bSave As ToolBarButton
    Friend WithEvents bPrint As ToolBarButton
    Friend WithEvents bClose As ToolBarButton
    Friend WithEvents RecordLabel As ToolBarButton
    Public WithEvents ToolBar As ToolBar
    Private WithEvents Panel As Panel
End Class
