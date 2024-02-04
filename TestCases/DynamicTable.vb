Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace QaPlayGround
    <TestClass>
    Public Class DynamicTable
        Private ReadOnly common As Common
        Private ReadOnly dynamicTablePage As DynamicTablePage
        ReadOnly browserName As String = If(Environment.GetEnvironmentVariable("BROWSER"), "Chrome")

        Public Sub New()
            common = New Common(browserName)
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
        <DataRow("Peter Parker")>
        <DataRow("Robert Bruce Banner")>
        Sub VerifySuperHero_RealName(realName As String)
            dynamicTablePage.VerifySuperHeroRealNameAtTheThirdColumn(realName)
        End Sub

        <TestMethod>
        <DataRow("Spider-Man", "spiderman.jpg", "spider-man@avengers.com", "Peter Parker")>
        <DataRow("Doctor Strange", "doctor-strange.jpg", "doctor-strange@avengers.com", "Stephen Vincent Strange")>
        <DataRow("Black Widow", "black-widow.jpg", "black-widow@avengers.com", "Natasha Alianovna Romanova")>
        <DataRow("Deadpool", "deadpool.jpg", "deadpool@avengers.com", "Wade Wilson")>
        <DataRow("Captain America", "captain-america.jpg", "captain-america@avengers.com", "Steve Rogers")>
        Sub VerifySuperHeroeInformation_DisplayedCorrectly(name As String, imageName As String, email As String, realName As String)
            dynamicTablePage.VerifySuperHeroNameVisible(name)
            dynamicTablePage.VerifySuperHeroImageVisible(imageName)
            dynamicTablePage.VerifySuperHeroEmailVisible(email)
            dynamicTablePage.VerifySuperHeroRealNameVisible(realName)
        End Sub

        <TestMethod>
        <DataRow("Superhero")>
        <DataRow("Status")>
        <DataRow("Real Name")>
        Sub VerifyColumn_DisplayedCorrectly(column As String)
            dynamicTablePage.VerifyColumnVisible(column)
        End Sub

    End Class
End Namespace
