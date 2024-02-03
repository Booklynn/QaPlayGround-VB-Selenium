Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium

Public Class DynamicTablePage
    Private ReadOnly driver As IWebDriver
    Private ReadOnly pageElements As New Dictionary(Of String, String) From {
        {"spiderManImage", "img[src='./img/spiderman.jpg']"},
        {"spiderManEmail", "//div[text()='spider-man@avengers.com']"},
        {"spiderManName", "//span[text()='Peter Parker']"}
    }

    Public Sub New(driver As IWebDriver)
        Me.driver = driver
    End Sub

    Public Sub VerifySpiderManImageVisible()
        Dim isSpiderManImageVisible As Boolean = driver.FindElements(By.CssSelector(pageElements("spiderManImage"))).Count > 0
        Assert.IsTrue(isSpiderManImageVisible, "Spider-Man image is not visible.")
    End Sub

    Public Sub VerifySpiderManEmailVisible()
        Dim isSpiderManEmailVisible As Boolean = driver.FindElements(By.XPath(pageElements("spiderManEmail"))).Count > 0
        Assert.IsTrue(isSpiderManEmailVisible, "Spider-Man email is not visible.")
    End Sub

    Public Sub VerifySpiderManNameVisible()
        Dim isSpiderManNameVisible As Boolean = driver.FindElements(By.XPath(pageElements("spiderManName"))).Count > 0
        Assert.IsTrue(isSpiderManNameVisible, "Spider-Man name is not visible.")
    End Sub
End Class
