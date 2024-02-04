Imports System.Text.RegularExpressions
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium

Public Class VerifyAccountPage
    Private ReadOnly driver As IWebDriver
    Private ReadOnly pageElements As New Dictionary(Of String, String) From {
        {"confirmationCodeInfo", "//small[@class='info']"},
        {"confirmationInputs", "code"},
        {"successText", ".info.success"}
    }

    Public Sub New(driver As IWebDriver)
        Me.driver = driver
    End Sub

    Public Function GetConfirmationCode() As String
        Dim confirmationCodeElement As IWebElement = driver.FindElement(By.XPath(pageElements("confirmationCodeInfo")))
        Dim confirmationCode As String = Regex.Replace(confirmationCodeElement.Text, "[^\d]", "")
        Return confirmationCode
    End Function

    Public Sub InputConfirmationCode(code As String)
        Dim codes As String() = code.ToCharArray().Select(Function(c) c.ToString()).ToArray()
        Dim codeLength As Integer = codes.Length
        Dim inputCodeFields = driver.FindElements(By.ClassName(pageElements("confirmationInputs")))

        For i As Integer = 0 To codeLength - 1
            inputCodeFields.ElementAt(i).SendKeys(codes(i))
        Next
    End Sub

    Public Sub PressKeyUpOnConfirmationCodeInput(code As String)
        Dim codes As String() = code.ToCharArray().Select(Function(c) c.ToString()).ToArray()
        Dim codeLength As Integer = codes.Length
        Dim inputCodeFields = driver.FindElements(By.ClassName(pageElements("confirmationInputs")))

        For i As Integer = 0 To codeLength - 1
            For j As Integer = 0 To codes(i) - 1
                inputCodeFields.ElementAt(i).SendKeys(Keys.ArrowUp)
            Next
        Next
    End Sub

    Public Sub VerifySuccessTextVisible()
        Dim isSuccessTextVisible As Boolean = driver.FindElement(By.CssSelector(pageElements("successText"))).Displayed
        Assert.IsTrue(isSuccessTextVisible, "successText is not visible.")
    End Sub

    Public Sub VerifySuccessTextNotVisible()
        Dim isSuccessTextNotVisible As Boolean = driver.FindElements(By.CssSelector(pageElements("successText"))).Count = 0
        Assert.IsTrue(isSuccessTextNotVisible, "successText is still visible.")
    End Sub

End Class
