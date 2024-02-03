Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace QaPlayGround
    <TestClass>
    Public Class DynamicTable
        Private ReadOnly common As Common
        Private ReadOnly dynamicTablePage As DynamicTablePage

        Public Sub New()
            common = New Common()
            dynamicTablePage = New DynamicTablePage(common.GetDriver())
        End Sub

        <TestInitialize>
        Sub TestInitialize()
            common.GoToUrl("https://qaplayground.dev/apps/dynamic-table/")
        End Sub

        <TestCleanup>
        Sub TestCleanup()
            common.Dispose()
        End Sub

        <TestMethod>
        Sub ShouldDisplaySpiderMan()
            dynamicTablePage.VerifySpiderManImageVisible()
            dynamicTablePage.VerifySpiderManEmailVisible()
            dynamicTablePage.VerifySpiderManNameVisible()
        End Sub

    End Class
End Namespace

