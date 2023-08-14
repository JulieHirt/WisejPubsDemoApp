Imports BasicDAL
Imports Wisej.Web

Public Class DbLookUpTextBox
    Inherits TextBox

    Private mDisplayMember As String = ""
    Private mValueMember As String = ""
    Private WithEvents mDbLookUp As New BasicDAL.DbLookUp
    Private mValue As Object = Nothing
    Private mLookUpOnEdit As Boolean = True
    Private Lock As Boolean = False
    Private dbf As New BasicDAL.DbFilters
    Private mShowSearchTool As Boolean = True
    Private mShowClearTool As Boolean = False
    Public Property ShowSearchTool() As Boolean
        Get
            Return mShowSearchTool
        End Get
        Set(ByVal value As Boolean)
            mShowSearchTool = value
            Me.Tools.Item("search").Visible = value

        End Set
    End Property
    Public Property ShowClearTool() As Boolean
        Get
            Return mShowClearTool
        End Get
        Set(ByVal value As Boolean)
            mShowClearTool = value
            Me.Tools.Item("clear").Visible = value
        End Set
    End Property
    Public Property LookUpOnEdit() As Boolean
        Get
            Return mLookUpOnEdit
        End Get
        Set(ByVal value As Boolean)
            mLookUpOnEdit = value
        End Set
    End Property


    Property DisplayMember As String
        Get
            DisplayMember = mDisplayMember
        End Get
        Set(ByVal value As String)
            mDisplayMember = value
            SetupDefault()
        End Set
    End Property

    Property Value As Object
        Get
            Value = mValue
        End Get
        Set(ByVal value As Object)
            mValue = value

            If Me.DbLookup.DbObject Is Nothing Then
                Me.Text = mValue
                Return
            End If

            If Me.ValueMember.Trim().ToUpper() = Me.DisplayMember.Trim().ToUpper() Then
                Me.Text = mValue
                Return
            End If

            Dim OldDataBinding = Me.DbLookup.DbObject.DataBinding
            Me.DbLookup.DbObject.DataBinding = DataBoundControlsBehaviour.NoDataBinding

            If mValue IsNot Nothing Then
                dbf.Clear()
                Try
                    Dim _dbc As BasicDAL.DbColumn = Me.DbLookup.DbObject.GetDbColumnByDbColumnNameE(Me.ValueMember)
                    If _dbc IsNot Nothing Then
                        dbf.Add(_dbc, ComparisionOperator.Equal, mValue)
                    End If
                Catch ex As Exception
                    Throw New Exception(Me.ToString() + "", ex)
                End Try
                Me.DbLookup.DbObject.FiltersGroup.Clear()
                Me.DbLookup.DbObject.FiltersGroup.Add(dbf)
                Me.DbLookup.DbObject.Open(True)
                If Me.DbLookup.DbObject.ExecutionResult.Success Then
                    Try
                        Dim _dbc As BasicDAL.DbColumn = Me.DbLookup.DbObject.GetDbColumnByDbColumnNameE(Me.DisplayMember)
                        If _dbc IsNot Nothing Then
                            Me.Text = _dbc.Value.ToString()
                        End If
                    Catch ex As Exception
                        'Throw New Exception(Me.ToString() + "", ex)
                    End Try

                End If
            Else

            End If

            Me.DbLookup.DbObject.DataBinding = OldDataBinding


        End Set
    End Property



    Property ValueMember As String
        Get
            ValueMember = mValueMember
        End Get
        Set(ByVal value As String)
            mValueMember = value
            SetupDefault()
        End Set
    End Property

    Property DbLookup As BasicDAL.DbLookUp
        Get
            DbLookup = mDbLookUp
        End Get
        Set(ByVal value As BasicDAL.DbLookUp)
            mDbLookUp = value
        End Set
    End Property


    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()


    End Sub
    Private Sub DbLookUpTextBox_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged
        If Lock = False Then
            Me.DbLookup.LookUpByFilters()
        End If


    End Sub

    Private Sub DbLookUpTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Me.mLookUpOnEdit Then
            Lock = True
            Me.DbLookup.LookUpByFilters()
            Lock = False
        End If
    End Sub

    Private Sub mDbLookUp_DbObject_Changed() Handles mDbLookUp.DbObject_Changed
        SetupDefault()
    End Sub

    Public Sub SetupDefault()
        If Me.mDbLookUp.DbObject Is Nothing Then
            Return
        End If

        If Me.mDisplayMember = "" Then
            Return
        End If

        Me.mDbLookUp.DbObject.SuppressErrorsNotification = True
        Dim DefaultFilterIndex As Integer = Me.mDbLookUp.GetFilterIndexByBoundControl(Me.Name, "text")
        If DefaultFilterIndex <> -1 Then
            Me.DbLookup.Filters.RemoveAt(DefaultFilterIndex)
        End If

        Dim DefaultValueMemberDbColumnIndex As Integer = Me.mDbLookUp.GetDbColumnIndexByBoundControl(Me.ValueMember, Me.Name)
        If DefaultValueMemberDbColumnIndex <> -1 Then
            Me.DbLookup.BoundControls.RemoveAt(DefaultValueMemberDbColumnIndex)
        End If
        If Me.mDisplayMember <> "" Then
            Dim _dbc As BasicDAL.DbColumn = Me.mDbLookUp.DbObject.GetDbColumnByDbColumnNameE(Me.mDisplayMember)
            If _dbc IsNot Nothing Then
                Me.mDbLookUp.Filters.AddBoundControl(_dbc, ComparisionOperator.Equal, Me, "text", LogicOperator.AND)
            Else

            End If

        End If
        If Me.mValueMember <> "" Then
            Dim _dbc As BasicDAL.DbColumn = Me.mDbLookUp.DbObject.GetDbColumnByDbColumnNameE(Me.mValueMember)
            If _dbc IsNot Nothing Then
                Me.mDbLookUp.BoundControls.Add(_dbc, Me, "value")
            Else

            End If

        End If



    End Sub

    Private Sub DbLookUpTextBox_ToolClick(sender As Object, e As ToolClickEventArgs)

    End Sub
End Class
