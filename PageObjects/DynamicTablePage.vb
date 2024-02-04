Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium

Public Class DynamicTablePage
    Private ReadOnly driver As IWebDriver
    Private ReadOnly pageElements As New Dictionary(Of String, String) From {
        {"columnName", "//th[normalize-space(text())='{columnName}']"},
        {"columnStatus", "//th[normalize-space(text())='Status']"},
        {"columnRealName", "//th[normalize-space(text())='Real Name']"},
        {"superHeroName", "//div[text()='{superHeroName}']"},
        {"superHeroImage", "img[src='./img/{superHeroImage}']"},
        {"superHeroEmail", "//div[text()='{superHeroEmail}']"},
        {"superHeroRealName", "//span[text()='{superHeroRealName}']"},
        {"rowSuperHero", "//*[text()='{superHeroRealName}']/../.."},
        {"realNameCell", "./td[3]"}
    }

    Public Sub New(driver As IWebDriver)
        Me.driver = driver
    End Sub

    Public Sub VerifySuperHeroRealNameAtTheThirdColumn(realName As String)
        Dim superHeroRealName = pageElements("rowSuperHero").Replace("{superHeroRealName}", realName)
        Dim row As WebElement = driver.FindElement(By.XPath(superHeroRealName))
        Dim realNameCell = row.FindElement(By.XPath(pageElements("realNameCell")))
        Assert.AreEqual(realName, realNameCell.Text, $"{realName} is not visible.")
    End Sub

    Public Sub VerifySuperHeroNameVisible(name As String)
        Dim superHeroName = pageElements("superHeroName").Replace("{superHeroName}", name)
        Dim isSuperHeroNameVisible As Boolean = driver.FindElements(By.XPath(superHeroName)).Count <> 0
        Assert.IsTrue(isSuperHeroNameVisible, $"{superHeroName} is not visible.")
    End Sub

    Public Sub VerifySuperHeroImageVisible(imageName As String)
        Dim superHeroImageName = pageElements("superHeroImage").Replace("{superHeroImage}", imageName)
        Dim isSuperHeroImageVisible As Boolean = driver.FindElements(By.CssSelector(superHeroImageName)).Count <> 0
        Assert.IsTrue(isSuperHeroImageVisible, $"{superHeroImageName} is not visible.")
    End Sub

    Public Sub VerifySuperHeroEmailVisible(email As String)
        Dim superHeroEmail = pageElements("superHeroEmail").Replace("{superHeroEmail}", email)
        Dim isSuperHeroEmailVisible As Boolean = driver.FindElements(By.XPath(superHeroEmail)).Count <> 0
        Assert.IsTrue(isSuperHeroEmailVisible, $"{superHeroEmail} is not visible.")
    End Sub

    Public Sub VerifySuperHeroRealNameVisible(realName As String)
        Dim superHeroRealName = pageElements("superHeroRealName").Replace("{superHeroRealName}", realName)
        Dim isSuperHeroRealNameVisible As Boolean = driver.FindElements(By.XPath(superHeroRealName)).Count <> 0
        Assert.IsTrue(isSuperHeroRealNameVisible, $"{superHeroRealName} is not visible.")
    End Sub

    Public Sub VerifyColumnVisible(column As String)
        Dim columnName = pageElements("columnName").Replace("{columnName}", column)
        Dim isSuperColumnVisible As Boolean = driver.FindElements(By.XPath(columnName)).Count <> 0
        Assert.IsTrue(isSuperColumnVisible, $"{columnName} is not visible.")
    End Sub

End Class
