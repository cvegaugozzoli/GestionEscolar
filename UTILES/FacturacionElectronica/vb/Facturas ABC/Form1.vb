Public Class Form1


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim nroComprobante As ULong
        Dim ptoVta As Integer = 101
        Dim FechaComp As Date = Now
        Dim cae As String = ""
        Dim vencimiento As Date
        Dim resultado As String = ""

        Dim wsfev1 As FEAFIPLib.BIWSFEV1 = New FEAFIPLib.BIWSFEV1
        If wsfev1.login("..\..\..\certificado.pfx", "feafip") Then
            If wsfev1.recuperaLastCMP(ptoVta, 1, nroComprobante) Then
                nroComprobante += 1
                wsfev1.reset()
                wsfev1.agregaFactura(1, 80, 30707219072, nroComprobante, nroComprobante, FechaComp, 242, 0, 200, 0, Nothing, Nothing, Nothing, "PES", 1)
                wsfev1.agregaIVA(5, 200, 42)
                If wsfev1.autorizar(ptoVta, 1) Then
                    wsfev1.autorizarRespuesta(0, cae, vencimiento, resultado)
                    If resultado = "A" Then
                        MsgBox("Felicitaciones! Si ve este mensaje instalo correctamente FEAFIP. CAE y Vencimiento: " + cae + " " + vencimiento)
                    Else
                        MsgBox(wsfev1.autorizarRespuestaObs(0))
                    End If
                Else
                    MsgBox(wsfev1.ErrorDesc)
                End If
            Else
                MsgBox(wsfev1.ErrorDesc)
            End If
        Else
            MsgBox(wsfev1.ErrorDesc)
        End If

    End Sub
End Class
