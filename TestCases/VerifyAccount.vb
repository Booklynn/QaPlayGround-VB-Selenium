Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace QaPlayGround
    <TestClass>
    Public Class VerifyAccount
        Private ReadOnly common As Common
        Private ReadOnly verifyAccountPage As VerifyAccountPage

        Public Sub New()
            common = New Common()
            verifyAccountPage = New VerifyAccountPage(common.GetDriver())
        End Sub

        <TestInitialize>
        Sub TestInitialize()
            common.GoToUrl("https://qaplayground.dev/apps/verify-account/")
        End Sub

        <TestCleanup>
        Sub TestCleanup()
            common.Dispose()
        End Sub

        <TestMethod>
        Sub VerifyAccount_Success()
            Dim code = verifyAccountPage.GetConfirmationCode()
            verifyAccountPage.InputConfirmationCode(code)
            verifyAccountPage.VerifySuccessTextVisible()
        End Sub

        <TestMethod>
        Sub VerifyAccount_NotSuccess()
            verifyAccountPage.InputConfirmationCode("123456")
            verifyAccountPage.VerifySuccessTextNotVisible()
        End Sub

    End Class
End Namespace
