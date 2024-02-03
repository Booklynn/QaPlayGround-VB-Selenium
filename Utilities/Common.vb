Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Firefox

Public Class Common
    Implements IDisposable

    Private ReadOnly driver As IWebDriver

    Public Sub New(Optional browser As String = "Chrome")
        Select Case browser
            Case "Chrome"
                Dim chromeOptions As New ChromeOptions()
                chromeOptions.AddArgument("--ignore-certificate-errors")
                chromeOptions.AddArgument("--disable-extensions")
                driver = New ChromeDriver(chromeOptions)
            Case "Firefox"
                driver = New FirefoxDriver()
            Case Else
                Throw New ArgumentException("Invalid browser specified.")
        End Select

        driver.Manage().Cookies.DeleteAllCookies()
        driver.Manage().Window.Maximize()
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15)
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7)
    End Sub

    Public Function GetDriver() As IWebDriver
        Return driver
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposing Then
            driver?.Quit()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Public Sub GoToUrl(url As String)
        driver.Navigate().GoToUrl(url)
    End Sub

End Class
