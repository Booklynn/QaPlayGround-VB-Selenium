Imports System.Text.RegularExpressions
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium

Public Class VerifyAccountPage
    Private ReadOnly driver As IWebDriver
    Private ReadOnly pageElements As New Dictionary(Of String, String) From {
        {"confirmationCodeInfo", "//small[@class='info']"},
        {"confirmationInputs", "(//input[@type='number'])[{index}]"},
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
        Dim confirmationInputTemplate As String = pageElements("confirmationInputs")

        For i As Integer = 0 To codeLength - 1
            Dim confirmationInput = confirmationInputTemplate.Replace("{index}", (i + 1).ToString())
            driver.FindElement(By.XPath(confirmationInput)).SendKeys(codes(i))
        Next
    End Sub

    Public Sub PressKeyUpOnConfirmationCodeInput(code As String)
        Dim codes As String() = code.ToCharArray().Select(Function(c) c.ToString()).ToArray()
        Dim codeLength As Integer = codes.Length
        Dim confirmationInputTemplate As String = pageElements("confirmationInputs")

        For i As Integer = 0 To codeLength - 1
            Dim confirmationInput = confirmationInputTemplate.Replace("{index}", (i + 1).ToString())
            For j As Integer = 0 To codes(i) - 1
                driver.FindElement(By.XPath(confirmationInput)).SendKeys(Keys.ArrowUp)
            Next
        Next
    End Sub

    Public Sub VerifySuccessTextVisible()
        Dim isSuccessTextVisible As Boolean = driver.FindElements(By.CssSelector(pageElements("successText"))).Count <> 0
        Assert.IsTrue(isSuccessTextVisible, "successText is not visible.")
    End Sub

    Public Sub VerifySuccessTextNotVisible()
        Dim isSuccessTextVisible As Boolean = driver.FindElements(By.CssSelector(pageElements("successText"))).Count <> 0
        Assert.IsFalse(isSuccessTextVisible, "successText is still visible.")
    End Sub

End Class
